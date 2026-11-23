using System;
using SwissEphNet;

namespace Pre1849Audit;

public class Program
{
    private const double Deg2Rad = Math.PI / 180.0;
    private const double Rad2Deg = 180.0 / Math.PI;

    public static void Main(string[] args)
    {
        var swissEph = new SwissEph();

        var dates = new[]
        {
            (1800, 1, 1, 12.0),
            (1816, 7, 19, 1.75), // ChatussagaraYogaHoroscope1
            (1830, 6, 15, 6.5),
            (1845, 12, 31, 0.0)
        };

        var planets = new[]
        {
            (0, "Sun"),
            (1, "Moon"),
            (2, "Mercury"),
            (3, "Venus"),
            (4, "Mars"),
            (5, "Jupiter"),
            (6, "Saturn")
        };

        Console.WriteLine("=========================================================================================");
        Console.WriteLine(" PRE-1849 ACCURACY AUDIT: Standish Keplerian Fallback vs SwissEphNet Moshier");
        Console.WriteLine("=========================================================================================");

        foreach (var (y, m, d, h) in dates)
        {
            double jd = swissEph.swe_julday(y, m, d, h, 1);
            Console.WriteLine($"\n--- Date: {y}-{m:02d}-{d:02d} {h:04.1f}h UT (JD {jd:F4}) ---");

            foreach (var (ipl, name) in planets)
            {
                // SwissEph
                double[] results = new double[6];
                string serr = "";
                swissEph.swe_calc(jd, ipl, 2, results, ref serr);
                double sweLon = results[0];

                // Standish fallback
                var (fallLon, fallLat, fallDist) = AnalyticalGeocentricEcliptic(ipl, jd);

                double diffDeg = Math.Abs(fallLon - sweLon);
                if (diffDeg > 180.0) diffDeg = 360.0 - diffDeg;
                double diffArcmin = diffDeg * 60.0;

                Console.WriteLine($"  {name,-8}: Fallback={fallLon,8:F3}° SwissEph={sweLon,8:F3}° Diff={diffArcmin,7:F2}' ({diffDeg,6:F3}°)");
            }
        }
        Console.WriteLine("=========================================================================================");
    }

    private static (double Longitude, double Latitude, double Distance) AnalyticalGeocentricEcliptic(
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

        var (xe, ye, ze) = HelioPos("Earth", T);

        // General precession from J2000 to date
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
