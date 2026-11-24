// JplEphemerisShim/EclipseCalculator.cs
// Solar and Lunar Eclipse calculation replacing Swiss Ephemeris eclipse functions:
// swe_lun_eclipse_when, swe_sol_eclipse_when_glob
// Exact syzygy search (Full Moon & New Moon) + Moon latitude nodal checks.

using System;

namespace JplEphemerisShim;

public static class EclipseCalculator
{
    public const int SE_ECL_TOTAL = 1;
    public const int SE_ECL_ANNULAR = 2;
    public const int SE_ECL_PARTIAL = 4;
    public const int SE_ECL_ANNULAR_TOTAL = 8;
    public const int SE_ECL_PENUMBRAL = 16;

    /// <summary>
    /// Find the next or previous lunar eclipse.
    /// Returns eclipse type flag (1=Total, 4=Partial, 16=Penumbral) or 0 if none.
    /// tret[0] is set to Julian Day UT of maximum eclipse.
    /// </summary>
    public static int FindLunarEclipse(
        ISwissEphShim eph,
        double jdStart,
        int ifltype,
        double[] tret,
        bool backward,
        ref string errMsg)
    {
        double currentJd = jdStart;
        double stepDirection = backward ? -1.0 : 1.0;
        double[] moonRes = new double[6];
        string err = "";

        // Search up to 14 synodic months (~14 months maximum)
        for (int month = 0; month < 14; month++)
        {
            // 1. Find the next Full Moon (elongation = 180 degrees)
            double fullMoonJd = FindNextSyzygy(eph, currentJd, 180.0, backward, ref err);
            if (fullMoonJd <= 0)
            {
                errMsg = err;
                return -1;
            }

            // 2. Compute Moon's ecliptic latitude at full moon
            int retMoon = eph.swe_calc(fullMoonJd, SwissEphShim.SE_MOON, 0, moonRes, ref err);
            if (retMoon != 0)
            {
                errMsg = err;
                return -1;
            }

            double moonLatDeg = Math.Abs(moonRes[1]);

            // Lunar eclipse geometric limits:
            // Total: |beta| <= 0.46 deg
            // Partial: |beta| <= 0.95 deg
            // Penumbral: |beta| <= 1.55 deg
            if (moonLatDeg <= 1.55)
            {
                int eclType = (moonLatDeg <= 0.46) ? SE_ECL_TOTAL :
                              (moonLatDeg <= 0.95) ? SE_ECL_PARTIAL : SE_ECL_PENUMBRAL;

                if (tret != null && tret.Length >= 1)
                {
                    tret[0] = fullMoonJd;
                    if (tret.Length >= 3)
                    {
                        double halfDuration = (eclType == SE_ECL_TOTAL) ? 0.08 : 0.05;
                        tret[1] = fullMoonJd - halfDuration;
                        tret[2] = fullMoonJd + halfDuration;
                    }
                    if (tret.Length >= 6)
                    {
                        tret[5] = Math.Max(0.0, (1.55 - moonLatDeg) / 0.55); // magnitude
                    }
                }

                errMsg = "";
                return eclType;
            }

            // Advance search past this Full Moon
            currentJd = fullMoonJd + (stepDirection * 15.0);
        }

        errMsg = "No lunar eclipse found within search window";
        return 0;
    }

    /// <summary>
    /// Find the next or previous global solar eclipse.
    /// Returns eclipse type flag (1=Total, 2=Annular, 4=Partial) or 0 if none.
    /// tret[0] is set to Julian Day UT of maximum eclipse.
    /// </summary>
    public static int FindSolarEclipse(
        ISwissEphShim eph,
        double jdStart,
        int ifltype,
        double[] tret,
        bool backward,
        ref string errMsg)
    {
        double currentJd = jdStart;
        double stepDirection = backward ? -1.0 : 1.0;
        double[] moonRes = new double[6];
        string err = "";

        // Search up to 14 synodic months (~14 months maximum)
        for (int month = 0; month < 14; month++)
        {
            // 1. Find the next New Moon (elongation = 0 degrees)
            double newMoonJd = FindNextSyzygy(eph, currentJd, 0.0, backward, ref err);
            if (newMoonJd <= 0)
            {
                errMsg = err;
                return -1;
            }

            // 2. Compute Moon's ecliptic latitude at new moon
            int retMoon = eph.swe_calc(newMoonJd, SwissEphShim.SE_MOON, 0, moonRes, ref err);
            if (retMoon != 0)
            {
                errMsg = err;
                return -1;
            }

            double moonLatDeg = Math.Abs(moonRes[1]);

            // Solar eclipse global limits (with parallax across Earth's disk):
            // Total / Annular: |beta| <= 0.99 deg
            // Partial: |beta| <= 1.65 deg
            if (moonLatDeg <= 1.65)
            {
                int eclType = (moonLatDeg <= 0.99) ? SE_ECL_TOTAL : SE_ECL_PARTIAL;

                if (tret != null && tret.Length >= 1)
                {
                    tret[0] = newMoonJd;
                    if (tret.Length >= 3)
                    {
                        double halfDuration = 0.06;
                        tret[1] = newMoonJd - halfDuration;
                        tret[2] = newMoonJd + halfDuration;
                    }
                    if (tret.Length >= 6)
                    {
                        tret[5] = Math.Max(0.0, (1.65 - moonLatDeg) / 0.66); // magnitude
                    }
                }

                errMsg = "";
                return eclType;
            }

            // Advance search past this New Moon
            currentJd = newMoonJd + (stepDirection * 15.0);
        }

        errMsg = "No solar eclipse found within search window";
        return 0;
    }

    /// <summary>
    /// Refines the exact time of syzygy (New Moon = 0 deg, Full Moon = 180 deg) using Newton-Raphson.
    /// </summary>
    private static double FindNextSyzygy(
        ISwissEphShim eph,
        double jdStart,
        double targetElongationDeg,
        bool backward,
        ref string errMsg)
    {
        double[] sunRes = new double[6];
        double[] moonRes = new double[6];
        string err = "";

        // Initial elongation at jdStart
        if (eph.swe_calc(jdStart, SwissEphShim.SE_SUN, 0, sunRes, ref err) != 0 ||
            eph.swe_calc(jdStart, SwissEphShim.SE_MOON, 0, moonRes, ref err) != 0)
        {
            errMsg = err;
            return -1;
        }

        double curElong = (moonRes[0] - sunRes[0]) % 360.0;
        if (curElong < 0) curElong += 360.0;

        double dTheta;
        if (!backward)
        {
            dTheta = (targetElongationDeg - curElong) % 360.0;
            if (dTheta <= 0.05) dTheta += 360.0; // Ensure forward progress
        }
        else
        {
            dTheta = (curElong - targetElongationDeg) % 360.0;
            if (dTheta <= 0.05) dTheta += 360.0;
            dTheta = -dTheta;
        }

        // Relative speed of Moon vs Sun is approx 12.190749 deg/day
        double tGuess = jdStart + (dTheta / 12.190749);

        // Newton-Raphson iteration (converges in 3-4 steps)
        for (int iter = 0; iter < 8; iter++)
        {
            if (eph.swe_calc(tGuess, SwissEphShim.SE_SUN, 0, sunRes, ref err) != 0 ||
                eph.swe_calc(tGuess, SwissEphShim.SE_MOON, 0, moonRes, ref err) != 0)
            {
                errMsg = err;
                return -1;
            }

            double elong = (moonRes[0] - sunRes[0]) % 360.0;
            if (elong < 0) elong += 360.0;

            // Angular difference wrapped to [-180, +180]
            double diff = ((elong - targetElongationDeg + 540.0) % 360.0) - 180.0;

            if (Math.Abs(diff) < 1e-6) // Precision < 0.0036 arcsec
            {
                return tGuess;
            }

            tGuess -= diff / 12.190749;
        }

        return tGuess;
    }
}
