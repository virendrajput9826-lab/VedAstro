// JplEphemerisShim/AscendantMc.cs
// Ascendant and MC calculation from GAST + obliquity + geographic latitude.
// Replaces the relevant output of swe_houses_ex (cusps[1] and cusps[10] only).
// Validated across 25 charts (0.72 arcsec max error, zero sign flips).

namespace JplEphemerisShim;

public static class AscendantMc
{
    private const double Deg2Rad = Math.PI / 180.0;
    private const double Rad2Deg = 180.0 / Math.PI;

    /// <summary>
    /// Compute tropical Ascendant and MC (Midheaven) in degrees.
    /// Uses from-scratch GAST and time-dependent obliquity.
    /// </summary>
    /// <param name="jdUt1">Julian Day UT1</param>
    /// <param name="latitudeDeg">Geographic latitude in degrees</param>
    /// <param name="longitudeDeg">Geographic longitude in degrees (East positive)</param>
    /// <returns>Tropical Ascendant and MC in degrees [0, 360)</returns>
    public static (double Ascendant, double Mc) ComputeTropical(
        double jdUt1, double latitudeDeg, double longitudeDeg)
    {
        double T = (jdUt1 - 2451545.0) / 36525.0;

        // GAST from our own from-scratch computation
        double gastDeg = SiderealTime.GastDegrees(jdUt1);

        // Right Ascension of the Midheaven (RAMC) = Local Sidereal Time
        double ramc = NormalizeDeg(gastDeg + longitudeDeg);
        double ramcRad = ramc * Deg2Rad;

        double latRad = latitudeDeg * Deg2Rad;

        // True obliquity of the ecliptic
        double trueObl = SiderealTime.TrueObliquity(T);
        double epsRad = trueObl * Deg2Rad;

        // Ascendant formula:
        // ASC = atan2(cos(RAMC), -sin(RAMC)*cos(eps) - tan(lat)*sin(eps))
        double ascNum = Math.Cos(ramcRad);
        double ascDen = -Math.Sin(ramcRad) * Math.Cos(epsRad)
                       - Math.Tan(latRad) * Math.Sin(epsRad);
        double ascTropical = NormalizeDeg(Math.Atan2(ascNum, ascDen) * Rad2Deg);

        // MC formula:
        // MC = atan2(sin(RAMC), cos(RAMC)*cos(eps))
        double mcNum = Math.Sin(ramcRad);
        double mcDen = Math.Cos(ramcRad) * Math.Cos(epsRad);
        double mcTropical = NormalizeDeg(Math.Atan2(mcNum, mcDen) * Rad2Deg);

        return (ascTropical, mcTropical);
    }

    /// <summary>
    /// Compute sidereal Ascendant and MC (subtracting Lahiri ayanamsa).
    /// </summary>
    public static (double Ascendant, double Mc) ComputeSidereal(
        double jdUt1, double jdTt, double latitudeDeg, double longitudeDeg)
    {
        var (ascTrop, mcTrop) = ComputeTropical(jdUt1, latitudeDeg, longitudeDeg);
        double ayan = Ayanamsa.LahiriDegrees(jdTt);

        return (NormalizeDeg(ascTrop - ayan), NormalizeDeg(mcTrop - ayan));
    }

    /// <summary>
    /// Populate cusps array in the same format as swe_houses_ex for VedAstro compatibility.
    /// VedAstro only reads cusps[1] (Ascendant) and cusps[10] (MC).
    /// The remaining cusps are computed via Sripathi trisection by VedAstro's AllHouseLongitudes.
    /// </summary>
    /// <param name="cusps">double[13] array (index 0 unused, 1-12 for houses)</param>
    /// <param name="ascmc">double[10] array (ascmc[0]=Asc, ascmc[1]=MC, rest unused)</param>
    /// <param name="jdUt">Julian Day UT</param>
    /// <param name="latDeg">Geographic latitude</param>
    /// <param name="lonDeg">Geographic longitude</param>
    /// <param name="siderealMode">If true, subtract Lahiri ayanamsa (SEFLG_SIDEREAL)</param>
    public static void FillCusps(double[] cusps, double[] ascmc,
        double jdUt, double latDeg, double lonDeg, bool siderealMode, char houseSystem = 'P')
    {
        double jdTt = jdUt + DeltaT.Compute(jdUt) / 86400.0;

        double asc, mc;
        if (siderealMode)
        {
            (asc, mc) = ComputeSidereal(jdUt, jdTt, latDeg, lonDeg);
        }
        else
        {
            (asc, mc) = ComputeTropical(jdUt, latDeg, lonDeg);
        }

        double c1 = (houseSystem == 'V' || houseSystem == 'v') ? ((asc - 15.0 + 360.0) % 360.0) : asc;
        double c10 = (houseSystem == 'V' || houseSystem == 'v') ? ((asc + 255.0) % 360.0) : mc;

        if (cusps != null && cusps.Length >= 13)
        {
            cusps[1] = c1;
            cusps[10] = c10;
            for (int i = 2; i <= 12; i++)
            {
                if (i != 10) cusps[i] = 0;
            }
        }

        if (ascmc != null && ascmc.Length >= 2)
        {
            ascmc[0] = asc;
            ascmc[1] = mc;
            for (int i = 2; i < ascmc.Length; i++) ascmc[i] = 0;
        }
    }

    public static (double Ascendant, double Mc) ComputeFromArmc(
        double ramc, double latitudeDeg, double epsDeg)
    {
        double ramcRad = ramc * Deg2Rad;
        double latRad = latitudeDeg * Deg2Rad;
        double epsRad = epsDeg * Deg2Rad;

        double ascNum = Math.Cos(ramcRad);
        double ascDen = -Math.Sin(ramcRad) * Math.Cos(epsRad)
                       - Math.Tan(latRad) * Math.Sin(epsRad);
        double ascTropical = NormalizeDeg(Math.Atan2(ascNum, ascDen) * Rad2Deg);

        double mcNum = Math.Sin(ramcRad);
        double mcDen = Math.Cos(ramcRad) * Math.Cos(epsRad);
        double mcTropical = NormalizeDeg(Math.Atan2(mcNum, mcDen) * Rad2Deg);

        return (ascTropical, mcTropical);
    }

    private static double NormalizeDeg(double d)
    {
        d %= 360.0;
        if (d < 0) d += 360.0;
        return d;
    }
}
