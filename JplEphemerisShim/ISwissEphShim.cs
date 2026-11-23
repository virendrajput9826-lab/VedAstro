// JplEphemerisShim/ISwissEphShim.cs
// Interface matching VedAstro's SwissEph call surface.
// Defines the exact methods invoked by VedAstro for drop-in compatibility.

namespace JplEphemerisShim;

public interface ISwissEphShim : IDisposable
{
    void swe_set_sid_mode(int sidMode, double t0, double ayanT0);

    int swe_calc(double julDayEt, int swissPlanet, int iflag,
                 double[] results, ref string errMsg);

    int swe_houses(double julDayUt, double lat, double lon, char houseSystem,
                   double[] cusps, double[] ascmc);

    int swe_houses_ex(double julDayUt, int iflag,
                      double lat, double lon, char houseSystem,
                      double[] cusps, double[] ascmc);

    int swe_houses_armc(double armc, double lat, double eps, char houseSystem,
                        double[] cusps, double[] ascmc);

    double swe_get_ayanamsa_ex(double julDay, int iflag);
    int swe_get_ayanamsa_ex(double julDayEt, int iflag, out double daya, ref string errMsg);

    int swe_rise_trans(double julDayUt, int planet, string starName,
                       int epheFlag, int rsmi, double[] geopos,
                       double atpress, double attemp,
                       ref double transitTime, ref string errMsg);

    void swe_set_ephe_path(string path);
    string swe_get_library_path();
    string swe_version();

    double swe_julday(int year, int month, int day, double hour, int gregFlag);
    void swe_jdut1_to_utc(double tjd_ut, int gregflag, ref int iyear, ref int imonth, ref int iday, ref int ihour, ref int imin, ref double dsec);
    int swe_day_of_week(double jd);
    double swe_deltat(double julDay);
    int swe_lmt_to_lat(double tjd_lmt, double geolon, out double tjd_lat, ref string errMsg);
    int swe_lun_eclipse_when(double tjd_start, int ifl, int ifltype, double[] tret, bool backward, ref string errMsg);
    int swe_sol_eclipse_when_glob(double tjd_start, int ifl, int ifltype, double[] tret, bool backward, ref string errMsg);

    void swe_close();
}
