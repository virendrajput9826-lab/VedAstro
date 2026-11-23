using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

[Serializable]
public class Angle : IAngle, IToJson, IFromUrl
{
	private const long SecondsPerDegree = 3600L;

	private const long SecondsPerMinute = 60L;

	private const double MinutesPerSecond = 1.0 / 60.0;

	private const double DegreesPerSecond = 0.0002777777777777778;

	public static readonly Angle Zero = new Angle(0.0, 0.0, 0L);

	public static readonly Angle Degrees45 = new Angle(45.0, 0.0, 0L);

	public static readonly Angle Degrees90 = new Angle(90.0, 0.0, 0L);

	public static readonly Angle Degrees180 = new Angle(180.0, 0.0, 0L);

	public static readonly Angle Degrees360 = new Angle(360.0, 0.0, 0L);

	private readonly long _seconds;

	public long Degrees => _seconds / 3600;

	public long Minutes => _seconds % 3600 / 60;

	public long Seconds => _seconds % 3600 % 60;

	public double TotalDegrees => SecondsToDegrees(_seconds);

	public double TotalMinutes => SecondsToMinutes(_seconds);

	public double Rounded => Math.Round(TotalDegrees, 4);

	public string DegreesMinutesSecondsText => $"{Degrees}° {Math.Abs(Minutes)}' {Math.Abs(Seconds)}";

	public Angle(double degrees = 0.0, double minutes = 0.0, long seconds = 0L)
	{
		_seconds = DegreesToSeconds(degrees);
		_seconds += MinutesToSeconds(minutes);
		_seconds += seconds;
	}

	public Angle(double degrees = 0.0, double minutes = 0.0, double seconds = 0.0)
	{
		_seconds = DegreesToSeconds(degrees);
		_seconds += MinutesToSeconds(minutes);
		_seconds += (long)seconds;
	}

	private static long DegreesToSeconds(double degrees)
	{
		return (long)(degrees * 3600.0);
	}

	private static long MinutesToSeconds(double minutes)
	{
		return (long)(minutes * 60.0);
	}

	private static double SecondsToDegrees(long seconds)
	{
		return (double)seconds * 0.0002777777777777778;
	}

	private static double SecondsToMinutes(long seconds)
	{
		return (double)seconds * (1.0 / 60.0);
	}

	public static Angle FromDegrees(double value)
	{
		return new Angle(value, 0.0, 0L);
	}

	public static double ConvertDegreeMinuteToTotalDegrees(double degree, double minute)
	{
		return new Angle(degree, minute, 0L).TotalDegrees;
	}

	public Angle Expunge360()
	{
		if (TotalDegrees > 360.0)
		{
			return this - Degrees360;
		}
		return this;
	}

	public Angle Divide(double divisor)
	{
		return FromDegrees(TotalDegrees / divisor);
	}

	public Angle GetDifference(Angle value)
	{
		return FromDegrees(Math.Abs((this - value).TotalDegrees));
	}

	public static Angle operator +(Angle a1, Angle a2)
	{
		return new Angle(0.0, 0.0, a1._seconds + a2._seconds);
	}

	public static Angle operator -(Angle a1, Angle a2)
	{
		return new Angle(0.0, 0.0, a1._seconds - a2._seconds);
	}

	public static bool operator ==(Angle left, Angle right)
	{
		return left?.Equals(right) ?? ((object)right == null);
	}

	public static bool operator !=(Angle left, Angle right)
	{
		return !(left == right);
	}

	public static bool operator >(Angle left, Angle right)
	{
		return left._seconds > right._seconds;
	}

	public static bool operator <(Angle left, Angle right)
	{
		long num = left?._seconds ?? 0;
		long num2 = right?._seconds ?? 0;
		return num < num2;
	}

	public static bool operator >=(Angle left, Angle right)
	{
		long num = left?._seconds ?? 0;
		long num2 = right?._seconds ?? 0;
		return num >= num2;
	}

	public static bool operator <=(Angle left, Angle right)
	{
		return left._seconds <= right._seconds;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (value.GetType() == typeof(Angle))
		{
			Angle angle = (Angle)value;
			return GetHashCode() == angle.GetHashCode();
		}
		return false;
	}

	public override string ToString()
	{
		return TotalDegrees.ToString() ?? "";
	}

	public static async Task<dynamic> FromUrl(string url)
	{
		return FromDegrees(double.Parse(url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1]));
	}

	public JObject ToJson()
	{
		return new JObject
		{
			["DegreeMinuteSecond"] = DegreesMinutesSecondsText,
			["TotalDegrees"] = TotalDegrees.ToString()
		};
	}

	public override int GetHashCode()
	{
		return _seconds.GetHashCode();
	}
}
