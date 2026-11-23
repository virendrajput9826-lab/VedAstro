using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class Event : IToXml, IToJson
{
	public static Event Empty = new Event(EventName.Empty, EventNature.Empty, "", SpecializedSummary.Empty, Time.Empty, Time.Empty, new List<EventTag>());

	private readonly EventName _name;

	private readonly string _description;

	private readonly EventNature _nature;

	private readonly Time _startTime;

	private readonly Time _endTime;

	private readonly List<EventTag> _eventTags;

	public EventName Name => _name;

	public string FormattedName => Format.FormatName(Name);

	public string Description => HttpUtility.HtmlDecode(_description);

	public EventNature Nature => _nature;

	public Time StartTime => _startTime;

	public Time EndTime => _endTime;

	public List<EventTag> EventTags => _eventTags;

	public SpecializedSummary SpecializedSummary { get; private set; }

	public double DurationMin => GetDurationMinutes();

	public double DurationHour => GetDurationHours();

	public double NatureScore { get; set; }

	public Event(EventName name, EventNature nature, string description, SpecializedSummary specializedSummary, Time startTime, Time endTime, List<EventTag> eventTags)
	{
		_name = name;
		_nature = nature;
		_description = HttpUtility.HtmlEncode(description);
		SpecializedSummary = specializedSummary;
		_startTime = startTime;
		_endTime = endTime;
		_eventTags = eventTags;
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
		if (value != null && value.GetType() == typeof(Event))
		{
			Event obj = (Event)value;
			return GetHashCode() == obj.GetHashCode();
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

	public double GetDurationMinutes()
	{
		return (GetEndTime().GetStdDateTimeOffset() - GetStartTime().GetStdDateTimeOffset()).TotalMinutes;
	}

	public double GetDurationHours()
	{
		return (GetEndTime().GetStdDateTimeOffset() - GetStartTime().GetStdDateTimeOffset()).TotalHours;
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	public static List<Event> FromXml(XElement resultsRaw)
	{
		List<Event> list = new List<Event>();
		if (resultsRaw.Name.LocalName == "Root")
		{
			foreach (XElement item in resultsRaw.Elements())
			{
				list.Add(XmlToEvent(item));
			}
		}
		else
		{
			list.Add(XmlToEvent(resultsRaw));
		}
		return list;
		static Event XmlToEvent(XElement eventXml)
		{
			EventName name = Enum.Parse<EventName>((eventXml.Element("Name")?.Element(typeof(EventName).FullName)).Value);
			EventNature nature = Enum.Parse<EventNature>((eventXml.Element("Nature")?.Element(typeof(EventNature).FullName)).Value);
			string value = (eventXml.Element("Description")?.Element(typeof(string).FullName)).Value;
			Time startTime = Time.FromXml(eventXml.Element("StartTime").Element("Time"));
			Time endTime = Time.FromXml(eventXml.Element("EndTime").Element("Time"));
			List<EventTag> eventTags = EventData.GetEventTags(eventXml.Element("Tag")?.Value);
			SpecializedSummary empty = SpecializedSummary.Empty;
			return new Event(name, nature, value, empty, startTime, endTime, eventTags);
		}
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("Event");
		XElement xElement2 = new XElement("Name", Tools.AnyTypeToXml(Name));
		XElement xElement3 = new XElement("Nature", Tools.AnyTypeToXml(Nature));
		XElement xElement4 = new XElement("Description", Tools.AnyTypeToXml(Description));
		XElement xElement5 = new XElement("StartTime", Tools.AnyTypeToXml(StartTime));
		XElement xElement6 = new XElement("EndTime", Tools.AnyTypeToXml(EndTime));
		xElement.Add(xElement2, xElement4, xElement3, xElement5, xElement6);
		return xElement;
	}

	public bool IsOccurredAtTime(Time inputTime)
	{
		bool num = inputTime >= StartTime;
		bool flag = inputTime <= EndTime;
		return num & flag;
	}

	public List<PlanetName> GetRelatedPlanet()
	{
		string text = Name.ToString();
		List<PlanetName> list = new List<PlanetName>();
		foreach (PlanetName all9Planet in PlanetName.All9Planets)
		{
			if (text.Contains(all9Planet.Name.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				list.Add(all9Planet);
			}
		}
		return new List<PlanetName>(list.Distinct());
	}

	public List<HouseName> GetRelatedHouse()
	{
		string input = Name.ToString().ToLower();
		List<int> list = new List<int>();
		foreach (Match item in Regex.Matches(input, "house(\\d+)"))
		{
			if (int.TryParse(item.Groups[1].Value, out var result))
			{
				list.Add(result);
			}
		}
		return new List<HouseName>(list.Select((int x) => (HouseName)x).ToList().Distinct());
	}

	JObject IToJson.ToJson()
	{
		return (JObject)ToJson();
	}

	public JToken ToJson()
	{
		return new JObject
		{
			["Name"] = Name.ToString(),
			["Nature"] = Name.ToString(),
			["Description"] = Name.ToString(),
			["StartTime"] = StartTime.ToJson(),
			["EndTime"] = EndTime.ToJson()
		};
	}

	public static List<Event> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<Event>();
		}
		List<Event> list = new List<Event>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static JArray ToJsonList(List<Event> eventList)
	{
		JArray jArray = new JArray();
		foreach (Event @event in eventList)
		{
			jArray.Add(@event.ToJson());
		}
		return jArray;
	}

	public static Event FromJson(JToken planetInput)
	{
		if (planetInput == null)
		{
			return Empty;
		}
		try
		{
			string value = planetInput["Name"].Value<string>();
			EventName name = (EventName)Enum.Parse(typeof(EventName), value);
			EventNature nature = (EventNature)Enum.Parse(value: planetInput["Nature"].Value<string>(), enumType: typeof(EventNature));
			string description = planetInput["Description"].Value<string>();
			Time startTime = Time.FromJson(planetInput["StartTime"]);
			Time endTime = Time.FromJson(planetInput["EndTime"]);
			SpecializedSummary specializedSummary = SpecializedSummary.FromJson(planetInput["SpecializedSummary"]);
			List<EventTag> eventTags = EventData.GetEventTags(planetInput["Tag"]?.Value<string>());
			return new Event(name, nature, description, specializedSummary, startTime, endTime, eventTags);
		}
		catch (Exception)
		{
			LibLogger.Debug("Failed to parse:\n" + planetInput.ToString());
			return Empty;
		}
	}
}
