namespace VedAstro.Library;

public record TimeRange(Time start, Time end)
{
	public double daysBetween => end.Subtract(start).TotalDays;

	public static TimeRange Empty = new TimeRange(Time.Empty, Time.Empty);

	public override string ToString()
	{
		return start.StdDateMonthYearText + " - " + end.StdDateMonthYearText;
	}
}
