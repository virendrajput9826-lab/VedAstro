// JplEphemerisShim/Ayanamsa.cs
// Lahiri (Chitrapaksha) Ayanamsa — replaces swe_get_ayanamsa_ex / swe_set_sid_mode.
// Exact constants verified against IAE standard and chart-engine-pure.ts.

namespace JplEphemerisShim;

public static class Ayanamsa
{
    // Lahiri (Chitrapaksha) Ayanamsa constants
    // Epoch J2000.0 (JD 2451545.0 TT): 23 deg 51' 11" = 23.853056 deg
    // Precession rate: 50.29 arcsec/year = 1.396888 deg/century
    private const double LahiriEpochDeg = 23.853056;
    private const double LahiriRatePerCentury = 1.396888;
    private const double J2000_JD = 2451545.0;

    /// <summary>
    /// Compute Lahiri (Chitrapaksha) ayanamsa in degrees for a given Julian Day (TT).
    /// Formula: 23.853056 + 1.396888 * T, where T = (JD_TT - 2451545.0) / 36525.0
    /// </summary>
    public static double LahiriDegrees(double jdTt)
    {
        double T = (jdTt - J2000_JD) / 36525.0;
        return LahiriEpochDeg + LahiriRatePerCentury * T;
    }

    /// <summary>
    /// Compute ayanamsa in degrees for a given Julian Day (TT) and sidereal mode.
    /// Matched to SwissEphNet constants:
    /// Mode 0: Fagan-Bradley (+0.883358 deg from Lahiri)
    /// Mode 1: Lahiri (Chitrapaksha)
    /// Mode 3: Raman (-1.446033 deg from Lahiri)
    /// Mode 5: Krishnamurti KP (-0.096584 deg from Lahiri)
    /// Mode 7: Yukteshwar (-1.378251 deg from Lahiri)
    /// Mode 18: J2000 (0.0 deg)
    /// </summary>
    public static double ComputeAyanamsa(int sidMode, double jdTt)
    {
        double lahiri = LahiriDegrees(jdTt);
        return sidMode switch
        {
            0 => lahiri + 0.8833577, // Fagan-Bradley
            1 => lahiri,             // Lahiri (Chitrapaksha)
            3 => lahiri - 1.4460330, // Raman
            5 => lahiri - 0.0965840, // Krishnamurti KP
            7 => lahiri - 1.3782510, // Yukteshwar
            18 => 0.0,               // J2000
            _ => lahiri
        };
    }

    /// <summary>
    /// Convert tropical ecliptic longitude to sidereal (using specified or default Lahiri mode).
    /// </summary>
    public static double TropicalToSidereal(double tropicalLongitude, double jdTt, int sidMode = 1)
    {
        double ayan = ComputeAyanamsa(sidMode, jdTt);
        double sid = (tropicalLongitude - ayan) % 360.0;
        if (sid < 0) sid += 360.0;
        return sid;
    }
}
