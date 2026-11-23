// JplEphemerisShim/SwissEphShim.cs
// Drop-in replacement for SwissEphNet.SwissEph that VedAstro calls.
// Implements the exact methods VedAstro uses, backed by JPL DE440s ephemeris.
//
// Call sites in VedAstro source:
//   1. Tools.cs:3930     ephemeris.swe_calc(jul_day_ET, swissPlanet, iflag, results, ref err_msg)
//   2. Core.cs:3531      swissEph.swe_set_sid_mode(Ayanamsa, 0, 0)
//   3. Core.cs:3538      swissEph.swe_houses_ex(jul_day_UT, iflag, lat, lon, 'P', cusps, ascmc)
//   4. Core.cs:1952,2008 ephemeris.swe_rise_trans(...)

using System;
using System.Collections.Generic;
using System.IO;

namespace JplEphemerisShim;

/// <summary>
/// Drop-in replacement for SwissEphNet.SwissEph.
/// Only implements the methods VedAstro actually calls.
/// Uses JPL DE440s via SpkReader instead of Swiss Ephemeris.
/// </summary>
public class SwissEphShim : ISwissEphShim
{
    private SpkReader? _spk;
    private bool _siderealMode = false;
    private int _sidMode = SE_SIDM_LAHIRI;
    private string? _currentPath;

    // Swiss Ephemeris body constants
    public const int SE_SUN = 0;
    public const int SE_MOON = 1;
    public const int SE_MERCURY = 2;
    public const int SE_VENUS = 3;
    public const int SE_MARS = 4;
    public const int SE_JUPITER = 5;
    public const int SE_SATURN = 6;
    public const int SE_URANUS = 7;
    public const int SE_NEPTUNE = 8;
    public const int SE_PLUTO = 9;
    public const int SE_MEAN_NODE = 10;
    public const int SE_TRUE_NODE = 11;
    public const int SE_EARTH = 14;

    // Swiss Ephemeris flags
    public const int SEFLG_JPLEPH = 1;
    public const int SEFLG_SWIEPH = 2;
    public const int SEFLG_SPEED = 256;
    public const int SEFLG_SIDEREAL = 64 * 1024; // 0x10000

    // Rise / Set flags
    public const int SE_CALC_RISE = 1;
    public const int SE_CALC_SET = 2;
    public const int SE_BIT_DISC_CENTER = 256;
    public const int SE_BIT_NO_REFRACTION = 512;

    // Swiss Ephemeris ayanamsa constants
    public const int SE_SIDM_FAGAN_BRADLEY = 0;
    public const int SE_SIDM_LAHIRI = 1;
    public const int SE_SIDM_DELUCE = 2;
    public const int SE_SIDM_RAMAN = 3;
    public const int SE_SIDM_USHASHASHI = 4;
    public const int SE_SIDM_KRISHNAMURTI = 5;
    public const int SE_SIDM_DJWHAL_KHUL = 6;
    public const int SE_SIDM_YUKTESHWAR = 7;
    public const int SE_SIDM_JN_BHASIN = 8;

    /// <summary>
    /// Map from Swiss Ephemeris planet index to NAIF body code.
    /// </summary>
    private static readonly Dictionary<int, int> SwePlanetToNaif = new()
    {
        { SE_SUN,     SpkReader.SUN },
        { SE_MOON,    SpkReader.MOON },
        { SE_MERCURY, SpkReader.MERCURY_BARYCENTER },
        { SE_VENUS,   SpkReader.VENUS_BARYCENTER },
        { SE_MARS,    SpkReader.MARS_BARYCENTER },
        { SE_JUPITER, SpkReader.JUPITER_BARYCENTER },
        { SE_SATURN,  SpkReader.SATURN_BARYCENTER },
        { SE_URANUS,  SpkReader.URANUS_BARYCENTER },
        { SE_NEPTUNE, SpkReader.NEPTUNE_BARYCENTER },
    };

    public SwissEphShim() : this(FindEphemerisPath())
    {
    }

    public SwissEphShim(string de440sPath)
    {
        _currentPath = de440sPath;
        if (File.Exists(de440sPath))
        {
            _spk = new SpkReader(de440sPath);
        }
    }

    public static string FindEphemerisPath()
    {
        string? env = Environment.GetEnvironmentVariable("JPL_DE440S_PATH");
        if (!string.IsNullOrEmpty(env) && File.Exists(env)) return env;

        string[] candidates = new[]
        {
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "de440s.bsp"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "services", "astrology", "skyfield_service", "de440s.bsp"),
            @"c:\Users\onlyf\OneDrive\Desktop\Devkhatiy Ecom\services\astrology\skyfield_service\de440s.bsp",
            @"c:\Users\onlyf\OneDrive\Desktop\Devkhatiy Ecom\api\astrology\skyfield\de440s.bsp",
            @"c:\Users\onlyf\OneDrive\Desktop\Devkhatiy Ecom\de421.bsp"
        };
        foreach (var c in candidates)
        {
            if (File.Exists(c)) return Path.GetFullPath(c);
        }
        return "de440s.bsp";
    }

    /// <summary>
    /// Replacement for swissEph.swe_set_sid_mode(ayanamsa, t0, ayan_t0).
    /// </summary>
    public void swe_set_sid_mode(int sidMode, double t0, double ayanT0)
    {
        _sidMode = sidMode;
        _siderealMode = true;
    }

    // Ephemeris span bounds (JPL DE440s covers 1849-01-01 to 2150-01-01)
    public const double DE440S_START_JD = 2396424.5;
    public const double DE440S_END_JD = 2506336.5;

    /// <summary>
    /// Set to true if the calculation used analytical fallback rather than JPL DE440s.
    /// This signals callers/users that the chart falls outside the high-precision ephemeris window.
    /// </summary>
    public static bool LastCalculationUsedFallback { get; private set; } = false;

    /// <summary>
    /// User-facing or diagnostic warning describing the fallback reason.
    /// </summary>
    public static string? LastFallbackWarning { get; private set; } = null;

    /// <summary>
    /// Indicates whether a given Julian Day falls within the high-precision JPL DE440s ephemeris window.
    /// </summary>
    public static bool IsWithinEphemerisRange(double jd) => jd >= DE440S_START_JD && jd <= DE440S_END_JD;

    /// <summary>
    /// Replacement for ephemeris.swe_calc(jul_day_ET, swissPlanet, iflag, results, ref err_msg).
    /// </summary>
    public int swe_calc(double julDayEt, int swissPlanet, int iflag,
                        double[] results, ref string errMsg)
    {
        try
        {
            double jdTdb = julDayEt;

            double longitude, latitude, distance;

            if (swissPlanet == SE_MEAN_NODE || swissPlanet == SE_TRUE_NODE)
            {
                longitude = CoordinateTransforms.MeanLunarNodeLongitude(jdTdb);
                latitude = 0.0;
                distance = 0.0;
            }
            else if (!SwePlanetToNaif.TryGetValue(swissPlanet, out int naifCode))
            {
                errMsg = $"Unsupported planet index: {swissPlanet}";
                return -1;
            }
            else
            {
                try
                {
                    EnsureSpkLoaded();
                    (longitude, latitude, distance) =
                        CoordinateTransforms.GeocentricEcliptic(_spk!, naifCode, jdTdb);
                    LastCalculationUsedFallback = false;
                    LastFallbackWarning = null;
                }
                catch (Exception spkEx)
                {
                    LastCalculationUsedFallback = true;
                    LastFallbackWarning = $"[WARNING: OUT_OF_HIGH_PRECISION_RANGE] Date (JD {jdTdb:F2}) is outside JPL DE440s ephemeris coverage (1849-01-01 to 2150-01-01). Using analytical Keplerian fallback with degraded precision (~1-10 arcmin). Reason: {spkEx.Message}";
                    Console.Error.WriteLine(LastFallbackWarning);

                    (longitude, latitude, distance) =
                        CoordinateTransforms.AnalyticalGeocentricEcliptic(swissPlanet, jdTdb);
                }
            }

            bool sidereal = _siderealMode || (iflag & SEFLG_SIDEREAL) != 0;
            if (sidereal)
            {
                longitude = Ayanamsa.TropicalToSidereal(longitude, jdTdb, _sidMode);
            }

            results[0] = longitude;
            results[1] = latitude;
            results[2] = distance;
            results[3] = 0.0;
            results[4] = 0.0;
            results[5] = 0.0;

            errMsg = "";
            return 0;
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            return -1;
        }
    }

    /// <summary>
    /// Replacement for swissEph.swe_houses_ex(jul_day_UT, iflag, lat, lon, 'P', cusps, ascmc).
    /// </summary>
    public int swe_houses_ex(double julDayUt, int iflag,
                              double lat, double lon, char houseSystem,
                              double[] cusps, double[] ascmc)
    {
        bool sidereal = (iflag & SEFLG_SIDEREAL) != 0;
        AscendantMc.FillCusps(cusps, ascmc, julDayUt, lat, lon, sidereal, houseSystem);
        return 0;
    }

    /// <summary>
    /// Calculates solar sunrise and sunset times.
    /// </summary>
    public int swe_rise_trans(double julDayUt, int planet, string starName,
                               int epheFlag, int rsmi, double[] geopos,
                               double atpress, double attemp,
                               ref double transitTime, ref string errMsg)
    {
        try
        {
            double lon = (geopos != null && geopos.Length > 0) ? geopos[0] : 0.0;
            double lat = (geopos != null && geopos.Length > 1) ? geopos[1] : 0.0;
            bool isRise = (rsmi & 1) != 0 || rsmi == 769;
            transitTime = ComputeSunRiseSet(julDayUt, lat, lon, isRise);
            errMsg = "";
            return 0;
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            return -1;
        }
    }

    public static double ComputeSunRiseSet(double jdUt, double latDeg, double lonDeg, bool isRise)
    {
        double t = (jdUt - 2451545.0) / 36525.0;
        double l0 = 280.46646 + 36000.76983 * t + 0.0003032 * t * t;
        double m = 357.52911 + 35999.05029 * t - 0.0001537 * t * t;
        double mRad = m * Math.PI / 180.0;
        double c = (1.914602 - 0.004817 * t - 0.000014 * t * t) * Math.Sin(mRad)
                 + (0.019993 - 0.000101 * t) * Math.Sin(2.0 * mRad)
                 + 0.000289 * Math.Sin(3.0 * mRad);
        double sunTrueLon = l0 + c;
        double omega = 125.04 - 1934.136 * t;
        double lambda = sunTrueLon - 0.00569 - 0.00478 * Math.Sin(omega * Math.PI / 180.0);
        double eps0 = 23.439291 - 0.0130042 * t;
        double eps = eps0 + 0.00256 * Math.Cos(omega * Math.PI / 180.0);
        double lambdaRad = lambda * Math.PI / 180.0;
        double epsRad = eps * Math.PI / 180.0;
        double sinDec = Math.Sin(epsRad) * Math.Sin(lambdaRad);
        double cosDec = Math.Cos(Math.Asin(sinDec));
        double y = Math.Tan(epsRad / 2.0);
        y *= y;
        double l0Rad = l0 * Math.PI / 180.0;
        double eqTime = 4.0 * (180.0 / Math.PI) * (y * Math.Sin(2.0 * l0Rad)
                        - 2.0 * 0.016708634 * Math.Sin(mRad)
                        + 4.0 * 0.016708634 * y * Math.Sin(mRad) * Math.Cos(2.0 * l0Rad)
                        - 0.5 * y * y * Math.Sin(4.0 * l0Rad)
                        - 1.25 * 0.016708634 * 0.016708634 * Math.Sin(2.0 * mRad));
        double latRad = latDeg * Math.PI / 180.0;
        double cosH0 = (Math.Cos(90.8333 * Math.PI / 180.0) - Math.Sin(latRad) * sinDec) / (Math.Cos(latRad) * cosDec);
        cosH0 = Math.Max(-1.0, Math.Min(1.0, cosH0));
        double h0Deg = Math.Acos(cosH0) * 180.0 / Math.PI;
        double noonMin = 720.0 - 4.0 * lonDeg - eqTime;
        double eventMin = isRise ? (noonMin - h0Deg * 4.0) : (noonMin + h0Deg * 4.0);
        // Compute base UT midnight that corresponds to the local calendar day
        double localMidnightJd = jdUt + (lonDeg / 360.0);
        double baseJdMidnight = Math.Floor(localMidnightJd - 0.5) + 0.5;
        double result = baseJdMidnight + eventMin / 1440.0;
        if (result < jdUt) result += 1.0;
        return result;
    }

    public double swe_julday(int year, int month, int day, double hour, int gregFlag)
    {
        return JulianDay.CalendarToJd(year, month, day, hour);
    }

    public static double swe_julday_static(int year, int month, int day, double hour, int gregFlag)
    {
        return JulianDay.CalendarToJd(year, month, day, hour);
    }

    public double swe_deltat(double julDay)
    {
        return DeltaT.Compute(julDay) / 86400.0;
    }

    public static double swe_deltat_static(double julDay)
    {
        return DeltaT.Compute(julDay) / 86400.0;
    }

    public double swe_get_ayanamsa_ex(double julDay, int iflag)
    {
        return Ayanamsa.ComputeAyanamsa(_sidMode, julDay);
    }

    public int swe_get_ayanamsa_ex(double julDayEt, int iflag, out double daya, ref string errMsg)
    {
        daya = Ayanamsa.ComputeAyanamsa(_sidMode, julDayEt);
        errMsg = "";
        return 0;
    }

    public int swe_houses(double julDayUt, double lat, double lon, char houseSystem,
                          double[] cusps, double[] ascmc)
    {
        AscendantMc.FillCusps(cusps, ascmc, julDayUt, lat, lon, false, houseSystem);
        return 0;
    }

    public int swe_houses_armc(double armc, double lat, double eps, char houseSystem,
                               double[] cusps, double[] ascmc)
    {
        var (asc, mc) = AscendantMc.ComputeFromArmc(armc, lat, eps);
        if (ascmc != null && ascmc.Length > 1)
        {
            ascmc[0] = asc;
            ascmc[1] = mc;
            if (ascmc.Length > 2) ascmc[2] = armc;
        }
        if (cusps != null && cusps.Length >= 13)
        {
            for (int i = 1; i <= 12; i++)
            {
                cusps[i] = (asc + (i - 1) * 30.0) % 360.0;
            }
        }
        return 0;
    }

    public string swe_get_library_path() => FindEphemerisPath();
    public string swe_version() => "JPL DE440s Shim v1.0 (Clean-Room)";

    public void swe_jdut1_to_utc(double tjd_ut, int gregflag, ref int iyear, ref int imonth, ref int iday, ref int ihour, ref int imin, ref double dsec)
    {
        double jd = tjd_ut + 0.5;
        long Z = (long)Math.Floor(jd);
        double F = jd - Z;
        long A = Z;
        if (Z >= 2299161)
        {
            long alpha = (long)Math.Floor((Z - 1867216.25) / 36524.25);
            A = Z + 1 + alpha - (alpha / 4);
        }
        long B = A + 1524;
        long C = (long)Math.Floor((B - 122.1) / 365.25);
        long D = (long)Math.Floor(365.25 * C);
        long E = (long)Math.Floor((B - D) / 30.6001);

        double dayWithFraction = B - D - (long)Math.Floor(30.6001 * E) + F;
        iday = (int)Math.Floor(dayWithFraction);
        imonth = (int)((E < 14) ? E - 1 : E - 13);
        iyear = (int)((imonth > 2) ? C - 4716 : C - 4715);

        double dayFrac = dayWithFraction - iday;
        double totalHours = dayFrac * 24.0;
        ihour = (int)Math.Floor(totalHours);
        double totalMinutes = (totalHours - ihour) * 60.0;
        imin = (int)Math.Floor(totalMinutes);
        dsec = (totalMinutes - imin) * 60.0;
    }

    public int swe_day_of_week(double jd)
    {
        int d = (int)Math.Floor(jd + 0.5) % 7;
        return (d < 0) ? d + 7 : d;
    }

    public int swe_lmt_to_lat(double tjd_lmt, double geolon, out double tjd_lat, ref string errMsg)
    {
        tjd_lat = tjd_lmt;
        errMsg = "";
        return 0;
    }

    public int swe_lun_eclipse_when(double tjd_start, int ifl, int ifltype, double[] tret, bool backward, ref string errMsg)
    {
        throw new NotImplementedException("swe_lun_eclipse_when is out of scope.");
    }

    public int swe_sol_eclipse_when_glob(double tjd_start, int ifl, int ifltype, double[] tret, bool backward, ref string errMsg)
    {
        throw new NotImplementedException("swe_sol_eclipse_when_glob is out of scope.");
    }

    public void swe_set_ephe_path(string path)
    {
        if (path != _currentPath && File.Exists(path))
        {
            _spk?.Dispose();
            _currentPath = path;
            _spk = new SpkReader(path);
        }
    }

    public void swe_close() { }

    private void EnsureSpkLoaded()
    {
        if (_spk == null)
        {
            string p = FindEphemerisPath();
            if (File.Exists(p))
            {
                _currentPath = p;
                _spk = new SpkReader(p);
            }
            else
            {
                throw new FileNotFoundException($"JPL ephemeris file not found at: {p}");
            }
        }
    }

    public void Dispose()
    {
        _spk?.Dispose();
    }
}
