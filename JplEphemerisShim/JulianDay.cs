// JplEphemerisShim/JulianDay.cs
// Clean-room Julian Day calculation — replaces swe_julday.
// Standard Meeus algorithm, no Swiss Ephemeris code referenced.

namespace JplEphemerisShim;

public static class JulianDay
{
    /// <summary>
    /// Convert calendar date + time to Julian Day Number (UT).
    /// Meeus, Astronomical Algorithms (1991), Chapter 7.
    /// </summary>
    public static double CalendarToJd(int year, int month, int day, double hourUtc)
    {
        int y = year;
        int m = month;

        if (m <= 2)
        {
            y -= 1;
            m += 12;
        }

        int A = y / 100;
        int B = 2 - A + (A / 4);

        double dayFraction = day + hourUtc / 24.0;

        return Math.Floor(365.25 * (y + 4716))
             + Math.Floor(30.6001 * (m + 1))
             + dayFraction + B - 1524.5;
    }

    /// <summary>
    /// Convert Julian Day to calendar date components.
    /// Meeus, Chapter 7, inverse algorithm.
    /// </summary>
    public static (int Year, int Month, int Day, double Hour) JdToCalendar(double jd)
    {
        double z = Math.Floor(jd + 0.5);
        double f = (jd + 0.5) - z;

        double a;
        if (z < 2299161)
        {
            a = z;
        }
        else
        {
            double alpha = Math.Floor((z - 1867216.25) / 36524.25);
            a = z + 1 + alpha - Math.Floor(alpha / 4.0);
        }

        double b = a + 1524;
        double c = Math.Floor((b - 122.1) / 365.25);
        double d = Math.Floor(365.25 * c);
        double e = Math.Floor((b - d) / 30.6001);

        double day = b - d - Math.Floor(30.6001 * e) + f;
        int dayInt = (int)Math.Floor(day);
        double hour = (day - dayInt) * 24.0;

        int month = (e < 14) ? (int)e - 1 : (int)e - 13;
        int year = (month > 2) ? (int)c - 4716 : (int)c - 4715;

        return (year, month, dayInt, hour);
    }
}
