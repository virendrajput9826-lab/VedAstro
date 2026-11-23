using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

[Serializable]
public struct Time : IToXml, IFromUrl, IToJson
{
	public static int OpenAPILength = 8;

	private readonly DateTimeOffset _stdTime;

	private readonly GeoLocation _geoLocation;

	private static readonly DateTimeFormatInfo FormatInfo = GetDateTimeFormatInfo();

	public const string DateTimeFormat = "HH:mm dd/MM/yyyy zzz";

	public const string DateTimeFormatTimezone = "zzz";

	public const string DateTimeFormatNoTimezone = "HH:mm dd/MM/yyyy";

	public const string DateTimeFormatSeconds = "HH:mm:ss dd/MM/yyyy zzz";

	public static Time Empty = new Time("00:00 01/01/2000 +08:00", GeoLocation.Empty);

	public DateTimeOffset StdTimeNowAtOffset => DateTimeOffset.Now.ToOffset(GetStdDateTimeOffset().Offset);

	public Time TimeNowAtOffset => new Time(StdTimeNowAtOffset, GetGeoLocation());

	public readonly string StdDateMonthYearText => _stdTime.ToString("dd/MM/yyyy");

	public readonly string StdYearText => _stdTime.ToString("yyyy");

	public readonly string StdTimezoneText => _stdTime.ToString("zzz");

	public readonly string StdHourMinuteText => _stdTime.ToString("HH:mm");

	public Time(DateTimeOffset stdDateTime, GeoLocation geoLocation)
	{
		_stdTime = stdDateTime;
		_geoLocation = geoLocation;
	}

	public Time(string stdDateTimeText, GeoLocation geoLocation)
	{
		try
		{
			DateTimeOffset stdTime = DateTimeOffset.ParseExact(stdDateTimeText, "HH:mm dd/MM/yyyy zzz", null);
			_stdTime = stdTime;
			_geoLocation = geoLocation;
		}
		catch (Exception)
		{
			_stdTime = DateTimeOffset.MinValue;
			_geoLocation = GeoLocation.Empty;
		}
	}

	public Time(DateTime lmtDateTime, TimeSpan stdOffset, GeoLocation geoLocation)
	{
		_stdTime = new DateTimeOffset(lmtDateTime, GetLocalTimeOffset(geoLocation.Longitude())).ToOffset(stdOffset);
		_geoLocation = geoLocation;
	}

	public static Time StandardHoroscope()
	{
		return new Time("14:20 16/10/1918 +05:30", GeoLocation.Bangalore);
	}

	public static Time NowSystem(GeoLocation geoLocation)
	{
		return new Time(DateTimeOffset.Now, geoLocation);
	}

	public static async Task<Time> Now(GeoLocation geoLocation)
	{
		DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow;
		TimeSpan offset = DateTimeOffset.ParseExact((await Tools.GetTimezoneOffsetApi(geoLocation, dateTimeOffset)).Payload, "zzz", null).Offset;
		DateTimeOffset stdDateTime = dateTimeOffset.ToOffset(offset);
		return new Time(stdDateTime, geoLocation);
	}

	public int StdYear()
	{
		return GetStdDateTimeOffset().Year;
	}

	public int StdMonth()
	{
		return GetStdDateTimeOffset().Month;
	}

	public string StdMonthText()
	{
		return GetStdDateTimeOffset().Month.ToString("D2");
	}

	public int StdDate()
	{
		return GetStdDateTimeOffset().Day;
	}

	public string StdDateText()
	{
		return GetStdDateTimeOffset().Day.ToString("D2");
	}

	public int StdHour()
	{
		return GetStdDateTimeOffset().Hour;
	}

	public GeoLocation GetGeoLocation()
	{
		return _geoLocation;
	}

	public static List<Time> GetTimeListFromRange(Time startTime, Time endTime, double precisionInHours)
	{
		List<Time> list = new List<Time>();
		Time item = startTime;
		while (item.GetStdDateTimeOffset() <= endTime.GetStdDateTimeOffset())
		{
			list.Add(item);
			item = item.AddHours(precisionInHours);
		}
		return list;
	}

	public Time AddHours(double granularityHours)
	{
		DateTimeOffset stdDateTime = _stdTime.AddHours(granularityHours);
		return new Time(stdDateTime, _geoLocation);
	}

	public Time RemoveHours(double granularityHours)
	{
		DateTimeOffset stdDateTime = _stdTime.RemoveHours(granularityHours);
		return new Time(stdDateTime, _geoLocation);
	}

	public Time MoveToNextDay()
	{
		DateTimeOffset stdDateTime = _stdTime.AddDays(1.0).AddTicks(-_stdTime.TimeOfDay.Ticks);
		return new Time(stdDateTime, _geoLocation);
	}

	public Time AddYears(int years)
	{
		Time result = this;
		for (int i = 0; i < years; i++)
		{
			result = result.AddHours(8760.0);
		}
		return result;
	}

	public Time SubtractHours(double granularityHours)
	{
		double hours = Math.Abs(granularityHours) * -1.0;
		DateTimeOffset stdDateTime = _stdTime.AddHours(hours);
		return new Time(stdDateTime, _geoLocation);
	}

	public DateTimeOffset GetLmtDateTimeOffset()
	{
		double longitudeDeg = _geoLocation.Longitude();
		return StdToLmt(_stdTime, longitudeDeg);
	}

	public string GetStdDateTimeOffsetText()
	{
		string text = _stdTime.ToString("HH:mm dd/MM/yyyy");
		return string.Concat(str2: _stdTime.ToString("zzz"), str0: text.Replace('.', '/').Replace('-', '/'), str1: " ");
	}

	public string GetStdDateTimeSecondsOffsetText()
	{
		string text = _stdTime.ToString("HH:mm:ss dd/MM/yyyy");
		return string.Concat(str2: _stdTime.ToString("zzz"), str0: text.Replace('.', '/').Replace('-', '/'), str1: " ");
	}

	public DateTimeOffset GetStdDateTimeOffset()
	{
		return _stdTime;
	}

	public static DateTimeFormatInfo GetDateTimeFormatInfo()
	{
		return new DateTimeFormatInfo
		{
			FullDateTimePattern = "HH:mm dd/MM/yyyy zzz"
		};
	}

	public TimeSpan Subtract(Time time)
	{
		return _stdTime.Subtract(time._stdTime);
	}

	public string GetLmtDateTimeOffsetText()
	{
		return GetLmtDateTimeOffset().ToString("HH:mm dd/MM/yyyy zzz");
	}

	public static bool TryParseStd(string stdDateTimeText, out DateTimeOffset parsed)
	{
		try
		{
			parsed = DateTimeOffset.ParseExact(stdDateTimeText, "HH:mm dd/MM/yyyy zzz", null);
			return true;
		}
		catch (Exception)
		{
			parsed = default(DateTimeOffset);
			return false;
		}
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("Time");
		string stdDateTimeOffsetText = GetStdDateTimeOffsetText();
		XElement xElement2 = new XElement("StdTime", stdDateTimeOffsetText);
		XElement xElement3 = GetGeoLocation().ToXml();
		xElement.Add(xElement2, xElement3);
		return xElement;
	}

	public JObject ToJson()
	{
		return new JObject
		{
			["StdTime"] = GetStdDateTimeOffsetText(),
			["Location"] = GetGeoLocation().ToJson()
		};
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	public static Time FromXml(XElement timeXmlElement)
	{
		try
		{
			string text = timeXmlElement.Element("StdTime")?.Value ?? "00:00 01/01/2000 +08:00";
			text = text.Replace('.', '/');
			GeoLocation geoLocation = GeoLocation.FromXml(timeXmlElement.Element("Location"));
			return new Time(text, geoLocation);
		}
		catch (Exception message)
		{
			LibLogger.Debug(message, $"Time.FromXml FAIL! : {timeXmlElement}");
			return Empty;
		}
	}

	public static List<Time> FromXml(IEnumerable<XElement> xmlList)
	{
		return xmlList.Select((XElement timeXml) => FromXml(timeXml)).ToList();
	}

	public static Time FromJson(JToken timeJson)
	{
		try
		{
			string text = timeJson["StdTime"].Value<string>();
			text = text.Replace('.', '/');
			GeoLocation geoLocation = GeoLocation.FromJson(timeJson["Location"]);
			return new Time(text, geoLocation);
		}
		catch (Exception value)
		{
			Console.WriteLine($"JSON PARSE FAIL:\n{timeJson}\n{value}");
			return Empty;
		}
	}

	public static List<Time> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<Time>();
		}
		List<Time> list = new List<Time>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static Task<dynamic> FromUrl(string url)
	{
		try
		{
			string[] array = url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
			return Task.FromResult((object)Tools.ParseTime(array[1], array[3], array[4], array[5], array[6]).Result);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			return Task.FromResult((object)Empty);
		}
	}

	public string ToUrl()
	{
		string text = Tools.RemoveWhiteSpace(GetGeoLocation().Name());
		string text2 = GetStdDateTimeOffsetText().Replace(" ", "/");
		return "/Location/" + text + "/Time/" + text2;
	}

	public override bool Equals(object obj)
	{
		if (obj.GetType() == typeof(Time))
		{
			Time time = (Time)obj;
			return GetHashCode() == time.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = (int)_stdTime.Ticks;
		int num2 = _geoLocation?.GetHashCode() ?? 0;
		return num + num2;
	}

	public override string ToString()
	{
		return GetStdDateTimeOffsetText();
	}

	public static bool operator ==(Time left, Time right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Time left, Time right)
	{
		return !(left == right);
	}

	public static bool operator >(Time a, Time b)
	{
		return a.GetStdDateTimeOffset() > b.GetStdDateTimeOffset();
	}

	public static bool operator <(Time a, Time b)
	{
		return a.GetStdDateTimeOffset() < b.GetStdDateTimeOffset();
	}

	public static bool operator >=(Time a, Time b)
	{
		return a.GetStdDateTimeOffset() >= b.GetStdDateTimeOffset();
	}

	public static bool operator <=(Time a, Time b)
	{
		return a.GetStdDateTimeOffset() <= b.GetStdDateTimeOffset();
	}

	private static DateTimeOffset StdToLmt(DateTimeOffset stdDateTime, double longitudeDeg)
	{
		TimeSpan localTimeOffset = GetLocalTimeOffset(longitudeDeg);
		return stdDateTime.ToOffset(localTimeOffset);
	}

	public static TimeSpan GetLocalTimeOffset(double longitudeDeg)
	{
		int num = 0;
		int num2 = 3;
		try
		{
			while (!(longitudeDeg >= -180.0) || !(longitudeDeg <= 180.0))
			{
				if (num < num2)
				{
					double value = longitudeDeg;
					longitudeDeg /= 1000.0;
					num++;
					LibLogger.Debug($"Longitude out of range : {value} > Auto correct to : {longitudeDeg}");
					continue;
				}
				throw new Exception($"Longitude out of range : {longitudeDeg} > Auto correct failed!");
			}
			return TimeSpan.FromMinutes(Math.Round(TimeSpan.FromHours(longitudeDeg / 15.0).TotalMinutes));
		}
		catch (Exception message)
		{
			LibLogger.Debug(message);
			return TimeSpan.Zero;
		}
	}

	public static Angle TimeToLongitude(TimeSpan time)
	{
		return Angle.FromDegrees(time.TotalHours * 15.0);
	}

	public static bool TryParse(string cellValue, out object o)
	{
		throw new NotImplementedException();
	}

	public static Time FromLMT(string lmtDateTime, GeoLocation geoLocation)
	{
		if (!DateTime.TryParseExact(lmtDateTime, "HH:mm dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
		{
			throw new ArgumentException("Invalid LMT format. Expected format is 'HH:mm MM/dd/yyyy'.", "lmtDateTime");
		}
		return new Time(result, geoLocation);
	}
}
