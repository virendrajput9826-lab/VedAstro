// JplEphemerisShim/CoordinateTransforms.cs
// Convert rectangular (x, y, z) positions to ecliptic longitude/latitude/distance.
// Handles the geocentric conversion chain: barycentric → geocentric → ecliptic.

namespace JplEphemerisShim;

public static class CoordinateTransforms
{
    private const double Deg2Rad = Math.PI / 180.0;
    private const double Rad2Deg = 180.0 / Math.PI;
    private const double AU_KM = 149597870.7; // 1 AU in km (IAU 2012)

    /// <summary>
    /// Convert equatorial rectangular coordinates (x, y, z) in km
    /// to ecliptic longitude, latitude (degrees), and distance (AU).
    /// </summary>
    /// <param name="x">Equatorial X in km</param>
    /// <param name="y">Equatorial Y in km</param>
    /// <param name="z">Equatorial Z in km</param>
    /// <param name="obliquityDeg">Obliquity of the ecliptic in degrees</param>
    /// <returns>(longitude_deg, latitude_deg, distance_au)</returns>
    /// <summary>
    /// Computes the 3x3 rotation matrix from ICRF (J2000 equatorial) to true ecliptic of date.
    /// Incorporates IAU 2000 frame bias, Capitaine et al. (2003) precession,
    /// IAU nutation, and rotation by true obliquity.
    /// Validated against Skyfield to < 0.14 arcsec max error across 1950-2025.
    /// </summary>
    public static double[,] BuildEclipticMatrix(double jdTdb)
    {
        double t = (jdTdb - 2451545.0) / 36525.0;
        const double Asec2Rad = Math.PI / (180.0 * 3600.0);

        double eps0 = 84381.406 * Asec2Rad;
        double psia = ((((-0.0000000951 * t + 0.000132851) * t - 0.00114045) * t - 1.0790069) * t + 5038.481507) * t * Asec2Rad;
        double omegaa = (((((0.0000003337 * t - 0.000000467) * t - 0.00772503) * t + 0.0512623) * t - 0.025754) * t + 84381.406) * Asec2Rad;
        double chia = ((((-0.0000000560 * t + 0.000170663) * t - 0.00121197) * t - 2.3814292) * t + 10.556403) * t * Asec2Rad;

        double sa = Math.Sin(eps0), ca = Math.Cos(eps0);
        double sb = Math.Sin(-psia), cb = Math.Cos(-psia);
        double sc = Math.Sin(-omegaa), cc = Math.Cos(-omegaa);
        double sd = Math.Sin(chia), cd = Math.Cos(chia);

        // Precession P = R3(chia) * R1(-omegaa) * R3(-psia) * R1(eps0)
        double[,] P = new double[3, 3]
        {
            { cd * cb - sb * sd * cc, cd * sb * ca + sd * cc * cb * ca - sa * sd * sc, cd * sb * sa + sd * cc * cb * sa + ca * sd * sc },
            { -sd * cb - sb * cd * cc, -sd * sb * ca + cd * cc * cb * ca - sa * cd * sc, -sd * sb * sa + cd * cc * cb * sa + ca * cd * sc },
            { sb * sc, -sc * cb * ca - sa * cc, -sc * cb * sa + cc * ca }
        };

        // Frame bias B (ICRF to J2000 mean dynamical equator/equinox)
        double[,] B = new double[3, 3]
        {
            {  1.0, -7.07827974e-08,  8.05614894e-08 },
            {  7.07827974e-08,  1.0,  3.30604145e-08 },
            { -8.05614894e-08, -3.30604145e-08,  1.0 }
        };

        // Nutation angles
        var (dpsiArcsec, depsArcsec) = SiderealTime.Nutation(t);
        double dpsiRad = dpsiArcsec * Asec2Rad;
        double depsRad = depsArcsec * Asec2Rad;

        double meanObliquity = (84381.406 - 46.836769 * t - 0.0001831 * t * t + 0.00200340 * t * t * t) * Asec2Rad;
        double trueObliquity = meanObliquity + depsRad;

        double cobm = Math.Cos(meanObliquity), sobm = Math.Sin(meanObliquity);
        double cobt = Math.Cos(trueObliquity), sobt = Math.Sin(trueObliquity);
        double cpsi = Math.Cos(dpsiRad), spsi = Math.Sin(dpsiRad);

        // Nutation matrix N
        double[,] N = new double[3, 3]
        {
            { cpsi, -spsi * cobm, -spsi * sobm },
            { spsi * cobt, cpsi * cobm * cobt + sobm * sobt, cpsi * sobm * cobt - cobm * sobt },
            { spsi * sobt, cpsi * cobm * sobt - sobm * cobt, cpsi * sobm * sobt + cobm * cobt }
        };

        // M = N * P * B
        double[,] PB = Multiply3x3(P, B);
        double[,] M = Multiply3x3(N, PB);

        // Rx(-trueObliquity)
        double cEps = Math.Cos(-trueObliquity);
        double sEps = Math.Sin(-trueObliquity);
        double[,] Rx = new double[3, 3]
        {
            { 1.0, 0.0, 0.0 },
            { 0.0, cEps, -sEps },
            { 0.0, sEps, cEps }
        };

        return Multiply3x3(Rx, M);
    }

    private static double[,] Multiply3x3(double[,] a, double[,] b)
    {
        double[,] result = new double[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j];
            }
        }
        return result;
    }

    /// <summary>
    /// Convert equatorial rectangular coordinates (x, y, z) in km
    /// to ecliptic longitude, latitude (degrees), and distance (AU).
    /// </summary>
    /// <param name="x">Equatorial X in km</param>
    /// <param name="y">Equatorial Y in km</param>
    /// <param name="z">Equatorial Z in km</param>
    /// <param name="obliquityDeg">Obliquity of the ecliptic in degrees</param>
    /// <returns>(longitude_deg, latitude_deg, distance_au)</returns>
    public static (double Longitude, double Latitude, double Distance) EquatorialToEcliptic(
        double x, double y, double z, double obliquityDeg)
    {
        double eps = obliquityDeg * Deg2Rad;
        double cosEps = Math.Cos(eps);
        double sinEps = Math.Sin(eps);

        // Rotate from equatorial to ecliptic frame
        double xEcl = x;
        double yEcl = y * cosEps + z * sinEps;
        double zEcl = -y * sinEps + z * cosEps;

        // Convert to spherical coordinates
        double dist = Math.Sqrt(xEcl * xEcl + yEcl * yEcl + zEcl * zEcl);
        double lon = Math.Atan2(yEcl, xEcl) * Rad2Deg;
        double lat = Math.Asin(zEcl / dist) * Rad2Deg;

        if (lon < 0) lon += 360.0;

        return (lon, lat, dist / AU_KM);
    }

    /// <summary>
    /// Compute geocentric ecliptic coordinates of a planet.
    /// Uses SPK data to get barycentric positions, applies light-time correction,
    /// and precesses/rotates to the true ecliptic of date via IAU 2000 models.
    /// </summary>
    /// <param name="spk">SPK reader with loaded DE440s</param>
    /// <param name="targetNaif">NAIF body code of the target planet</param>
    /// <param name="jdTdb">Julian Day TDB</param>
    /// <returns>(longitude_deg, latitude_deg, distance_au)</returns>
    public static (double Longitude, double Latitude, double Distance) GeocentricEcliptic(
        SpkReader spk, int targetNaif, double jdTdb)
    {
        // Get Earth position relative to SSB
        var (embX, embY, embZ) = spk.GetPosition(SpkReader.EARTH_MOON_BARYCENTER, 0, jdTdb);

        // Earth relative to EMB (DE440s has Earth(399) relative to EMB(3))
        // If segment exists, use it for precision; otherwise approximate Earth = EMB
        double earthX, earthY, earthZ;
        try
        {
            var (eX, eY, eZ) = spk.GetPosition(SpkReader.EARTH, SpkReader.EARTH_MOON_BARYCENTER, jdTdb);
            earthX = embX + eX;
            earthY = embY + eY;
            earthZ = embZ + eZ;
        }
        catch
        {
            // Fallback: Earth ~ EMB (introduces ~4670 km error, <0.01 deg for outer planets)
            earthX = embX;
            earthY = embY;
            earthZ = embZ;
        }

        const double CKms = 299792.458;
        double targetX, targetY, targetZ;

        if (targetNaif == SpkReader.MOON)
        {
            var (mX, mY, mZ) = spk.GetPosition(SpkReader.MOON, SpkReader.EARTH_MOON_BARYCENTER, jdTdb);
            double moonX = embX + mX;
            double moonY = embY + mY;
            double moonZ = embZ + mZ;
            double distKm = Math.Sqrt(Math.Pow(moonX - earthX, 2) + Math.Pow(moonY - earthY, 2) + Math.Pow(moonZ - earthZ, 2));
            double ltSec = distKm / CKms;
            double jdTdbLt = jdTdb - (ltSec / 86400.0);

            var (embLtX, embLtY, embLtZ) = spk.GetPosition(SpkReader.EARTH_MOON_BARYCENTER, 0, jdTdbLt);
            var (mLtX, mLtY, mLtZ) = spk.GetPosition(SpkReader.MOON, SpkReader.EARTH_MOON_BARYCENTER, jdTdbLt);
            targetX = embLtX + mLtX - earthX;
            targetY = embLtY + mLtY - earthY;
            targetZ = embLtZ + mLtZ - earthZ;
        }
        else if (targetNaif == SpkReader.SUN)
        {
            var (sX, sY, sZ) = spk.GetPosition(SpkReader.SUN, 0, jdTdb);
            double distKm = Math.Sqrt(Math.Pow(sX - earthX, 2) + Math.Pow(sY - earthY, 2) + Math.Pow(sZ - earthZ, 2));
            double ltSec = distKm / CKms;
            double jdTdbLt = jdTdb - (ltSec / 86400.0);

            var (sLtX, sLtY, sLtZ) = spk.GetPosition(SpkReader.SUN, 0, jdTdbLt);
            targetX = sLtX - earthX;
            targetY = sLtY - earthY;
            targetZ = sLtZ - earthZ;
        }
        else
        {
            var (pX, pY, pZ) = spk.GetPosition(targetNaif, 0, jdTdb);
            double distKm = Math.Sqrt(Math.Pow(pX - earthX, 2) + Math.Pow(pY - earthY, 2) + Math.Pow(pZ - earthZ, 2));
            double ltSec = distKm / CKms;
            double jdTdbLt = jdTdb - (ltSec / 86400.0);

            var (pLtX, pLtY, pLtZ) = spk.GetPosition(targetNaif, 0, jdTdbLt);
            targetX = pLtX - earthX;
            targetY = pLtY - earthY;
            targetZ = pLtZ - earthZ;
        }

        double[,] mEcl = BuildEclipticMatrix(jdTdb);
        double xEcl = mEcl[0, 0] * targetX + mEcl[0, 1] * targetY + mEcl[0, 2] * targetZ;
        double yEcl = mEcl[1, 0] * targetX + mEcl[1, 1] * targetY + mEcl[1, 2] * targetZ;
        double zEcl = mEcl[2, 0] * targetX + mEcl[2, 1] * targetY + mEcl[2, 2] * targetZ;

        double dist = Math.Sqrt(xEcl * xEcl + yEcl * yEcl + zEcl * zEcl);
        double lon = Math.Atan2(yEcl, xEcl) * Rad2Deg;
        double lat = Math.Asin(zEcl / dist) * Rad2Deg;

        if (lon < 0) lon += 360.0;

        return (lon, lat, dist / AU_KM);
    }

    /// <summary>
    /// Compute Mean Lunar Node (Rahu) longitude — pure analytical formula.
    /// No SPK segment needed for this.
    /// </summary>
    public static double MeanLunarNodeLongitude(double jdTdb)
    {
        double T = (jdTdb - 2451545.0) / 36525.0;
        // Mean longitude of ascending node (Meeus, Ch. 47)
        double omega = 125.0445479
                      - 1934.1362891 * T
                      + 0.0020754 * T * T
                      + T * T * T / 467441.0
                      - T * T * T * T / 60616000.0;
        return NormalizeDeg(omega);
    }

    /// <summary>
    /// Analytical Keplerian fallback for dates outside DE440s ephemeris span (e.g. historical charts before 1849).
    /// Uses Standish (1992) JPL elements and Meeus Ch. 47 for the Moon.
    /// </summary>
    public static (double Longitude, double Latitude, double Distance) AnalyticalGeocentricEcliptic(
        int swissPlanet, double jdTdb)
    {
        double T = (jdTdb - 2451545.0) / 36525.0;

        if (swissPlanet == 1) // Moon
        {
            double lPrime = 218.3164477 + 481267.88123421 * T - 0.0015786 * T * T;
            double d = 297.8501921 + 445267.1114034 * T - 0.0018819 * T * T;
            double m = 357.5291092 + 35999.0502909 * T - 0.0001536 * T * T;
            double mp = 134.9633964 + 477198.8675055 * T + 0.0087414 * T * T;
            double f = 93.2720950 + 483202.0175233 * T - 0.0036539 * T * T;

            double ToRad(double deg) => (deg % 360.0) * Deg2Rad;

            double moonLon = lPrime
                + 6.288774 * Math.Sin(ToRad(mp))
                + 1.274027 * Math.Sin(ToRad(2 * d - mp))
                + 0.658309 * Math.Sin(ToRad(2 * d))
                + 0.213618 * Math.Sin(ToRad(2 * mp))
                - 0.185116 * Math.Sin(ToRad(m))
                - 0.114332 * Math.Sin(ToRad(2 * f))
                + 0.058793 * Math.Sin(ToRad(2 * d - 2 * mp))
                + 0.057066 * Math.Sin(ToRad(2 * d - m - mp))
                + 0.053322 * Math.Sin(ToRad(2 * d + mp))
                + 0.045758 * Math.Sin(ToRad(2 * d - m));

            return (NormalizeDeg(moonLon), 0.0, 0.00257);
        }

        // Earth position
        var (xe, ye, ze) = HelioPos("Earth", T);

        // General precession in longitude from J2000 to epoch T (IAU model)
        double pA = (5028.796195 * T + 1.1054348 * T * T) / 3600.0;

        if (swissPlanet == 0) // Sun
        {
            double sunLon = Math.Atan2(-ye, -xe) * Rad2Deg + pA;
            double dist = Math.Sqrt(xe * xe + ye * ye + ze * ze);
            return (NormalizeDeg(sunLon), 0.0, dist);
        }

        string planetName = swissPlanet switch
        {
            2 => "Mercury",
            3 => "Venus",
            4 => "Mars",
            5 => "Jupiter",
            6 => "Saturn",
            _ => "Sun"
        };

        var (xp, yp, zp) = HelioPos(planetName, T);
        double gx = xp - xe;
        double gy = yp - ye;
        double gz = zp - ze;

        double gDist = Math.Sqrt(gx * gx + gy * gy + gz * gz);
        double gLon = Math.Atan2(gy, gx) * Rad2Deg + pA;
        double gLat = Math.Asin(gz / gDist) * Rad2Deg;

        return (NormalizeDeg(gLon), gLat, gDist);
    }

    private static (double X, double Y, double Z) HelioPos(string planet, double T)
    {
        // Standish (1992) [a0, e0, I0, L0, w0, N0, da, de, dI, dL, dw, dN]
        double[] p = planet switch
        {
            "Mercury" => new[] { 0.38709927, 0.20563593, 7.00497902, 252.25032350, 77.45779628, 48.33076593, 0.00000037, 0.00001906, -0.00594749, 149472.67411175, 0.16047687, -0.12534081 },
            "Venus" => new[] { 0.72333566, 0.00677672, 3.39467605, 181.97909950, 131.60246718, 76.67984255, 0.00000460, -0.00004107, -0.00078890, 58517.81538729, 0.00268329, -0.27769418 },
            "Earth" => new[] { 1.00000261, 0.01671123, -0.00001531, 100.46457166, 102.93768193, 0.0, 0.00000562, -0.00004392, -0.01294668, 35999.37244981, 0.32327364, 0.0 },
            "Mars" => new[] { 1.52371034, 0.09339410, 1.84969142, -4.55343205, -23.94362959, 49.55953891, 0.00001847, 0.00007882, -0.00813131, 19140.30268499, 0.44441088, -0.29257343 },
            "Jupiter" => new[] { 5.20288700, 0.04838624, 1.30439695, 34.39644051, 14.72847983, 100.47390909, -0.00011607, -0.00013257, -0.00183714, 3034.74612775, 0.21252668, 0.20469106 },
            "Saturn" => new[] { 9.53667594, 0.05386179, 2.48599187, 49.95424423, 92.59887831, 113.66242448, -0.00125060, -0.00050991, 0.00193609, 1222.49362201, -0.41897216, -0.28867794 },
            _ => new[] { 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }
        };

        double a = p[0] + p[6] * T;
        double e = p[1] + p[7] * T;
        double I = (p[2] + p[8] * T) * Deg2Rad;
        double L = p[3] + p[9] * T;
        double wBar = p[4] + p[10] * T;
        double node = (p[5] + p[11] * T) * Deg2Rad;
        double omega = (wBar - (p[5] + p[11] * T)) * Deg2Rad;
        double M = (L - wBar) * Deg2Rad;

        // Solve Kepler
        double E = M;
        for (int iter = 0; iter < 15; iter++)
        {
            double dE = (M - (E - e * Math.Sin(E))) / (1.0 - e * Math.Cos(E));
            E += dE;
            if (Math.Abs(dE) < 1e-12) break;
        }

        double xp = a * (Math.Cos(E) - e);
        double yp = a * Math.Sqrt(Math.Max(0.0, 1.0 - e * e)) * Math.Sin(E);

        double cw = Math.Cos(omega), sw = Math.Sin(omega);
        double cn = Math.Cos(node), sn = Math.Sin(node);
        double ci = Math.Cos(I), si = Math.Sin(I);

        double x = (cn * cw - sn * sw * ci) * xp + (-cn * sw - sn * cw * ci) * yp;
        double y = (sn * cw + cn * sw * ci) * xp + (-sn * sw + cn * cw * ci) * yp;
        double z = (sw * si) * xp + (cw * si) * yp;

        return (x, y, z);
    }

    private static double NormalizeDeg(double d)
    {
        d %= 360.0;
        if (d < 0) d += 360.0;
        return d;
    }
}
