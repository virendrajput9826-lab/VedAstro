using System.Text.RegularExpressions;
using System.Web;

namespace VedAstro.Library;

public struct Prediction
{
	private readonly EventName _name;

	private string _description;

	private readonly string _strength;

	private readonly EventNature _nature;

	private readonly Time _startTime;

	private readonly Time _endTime;

	public EventName Name => _name;

	public string Description
	{
		get
		{
			return HttpUtility.HtmlDecode(_description);
		}
		set
		{
			_description = HttpUtility.HtmlEncode(value);
		}
	}

	public string Strength => _strength;

	public EventNature Nature => _nature;

	public Time StartTime => _startTime;

	public Time EndTime => _endTime;

	public int Duration => GetDurationMinutes();

	public Prediction(EventName name, EventNature nature, string description, string strength, Time startTime, Time endTime)
	{
		_description = null;
		_strength = null;
		_startTime = default(Time);
		_endTime = default(Time);
		_name = name;
		_nature = nature;
		Description = description;
		_strength = strength;
		_startTime = startTime;
		_endTime = endTime;
	}

	public EventName GetName()
	{
		return _name;
	}

	public EventNature GetNature()
	{
		return _nature;
	}

	public Time GetStartTime()
	{
		return _startTime;
	}

	public string GetDescription()
	{
		return _description;
	}

	public Time GetEndTime()
	{
		return _endTime;
	}

	private static string SplitCamelCase(string str)
	{
		return Regex.Replace(Regex.Replace(str, "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"), "(\\p{Ll})(\\P{Ll})", "$1 $2");
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(Prediction))
		{
			Prediction prediction = (Prediction)value;
			return GetHashCode() == prediction.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = _name.GetHashCode();
		int stringHashCode = Tools.GetStringHashCode(_description);
		int hashCode2 = _nature.GetHashCode();
		int hashCode3 = _startTime.GetHashCode();
		int hashCode4 = _endTime.GetHashCode();
		return hashCode + stringHashCode + hashCode2 + hashCode3 + hashCode4;
	}

	public override string ToString()
	{
		return $"{GetName()} - {_nature} - {_startTime} - {_endTime} - {GetDurationMinutes()}";
	}

	public int GetDurationMinutes()
	{
		return (int)(GetEndTime().GetStdDateTimeOffset() - GetStartTime().GetStdDateTimeOffset()).TotalMinutes;
	}
}
