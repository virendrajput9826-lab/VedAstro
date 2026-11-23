using System.Web;

namespace VedAstro.Library;

public class EventSlice
{
	public static EventSlice Empty = new EventSlice(EventName.Empty, EventNature.Empty, "", SpecializedSummary.Empty, Time.Empty, isOccuring: false);

	private readonly string _description;

	public EventName Name { get; }

	public string FormattedName => Format.FormatName(this);

	public string Description => HttpUtility.HtmlDecode(_description);

	public SpecializedSummary SpecializedSummary { get; private set; }

	public EventNature Nature { get; }

	public Time Time { get; }

	public bool IsOccuring { get; init; }

	public EventSlice(EventName name, EventNature nature, string description, SpecializedSummary specializedSummary, Time time, bool isOccuring)
	{
		Name = name;
		Nature = nature;
		_description = HttpUtility.HtmlEncode(description);
		SpecializedSummary = specializedSummary;
		Time = time;
		IsOccuring = isOccuring;
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(EventSlice))
		{
			EventSlice eventSlice = (EventSlice)value;
			return GetHashCode() == eventSlice.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = Name.GetHashCode();
		int stringHashCode = Tools.GetStringHashCode(_description);
		int hashCode2 = Nature.GetHashCode();
		int hashCode3 = Time.GetHashCode();
		return hashCode + stringHashCode + hashCode2 + hashCode3;
	}

	public override string ToString()
	{
		return $"{Name} - {Nature} - {Time}";
	}

	public bool IsOccurredAtTime(Time inputTime)
	{
		return inputTime == Time;
	}
}
