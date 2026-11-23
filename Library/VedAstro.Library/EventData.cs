using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public struct EventData : IToXml, IToJson
{
	public static EventData Empty;

	private string _description;

	public EventName Name { get; private set; }

	public string FormattedName => Format.FormatName(Name);

	public EventNature Nature { get; private set; }

	public SpecializedSummary SpecializedSummary { get; private set; }

	public EventCalculatorDelegate EventCalculator { get; private set; }

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

	public RelatedBody RelatedBody { get; set; }

	public List<EventTag> EventTags { get; }

	public EventData(EventName name, EventNature nature, SpecializedSummary specializedNature, string description, List<EventTag> eventTags, EventCalculatorDelegate eventCalculator)
	{
		EventTags = null;
		_description = "";
		Name = EventName.Empty;
		RelatedBody = new RelatedBody();
		Name = name;
		Nature = nature;
		SpecializedSummary = specializedNature;
		EventCalculator = eventCalculator;
		Description = description;
		EventTags = eventTags;
	}

	public static List<EventData> FromXmlList(List<XElement> eventDataListXml)
	{
		List<EventData> list = new List<EventData>();
		foreach (XElement item in eventDataListXml)
		{
			list.Add(FromXml(item));
		}
		return list;
	}

	public XElement ToXml()
	{
		throw new NotImplementedException();
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	public static EventData FromXml(XElement eventData)
	{
		if (eventData == null)
		{
			throw new ArgumentNullException("eventData");
		}
		Enum.TryParse<EventName>(eventData.Element("Name")?.Value ?? "Empty", out var result);
		Enum.TryParse<EventNature>(eventData.Element("Nature")?.Value ?? "Empty", out var result2);
		SpecializedSummary empty = SpecializedSummary.Empty;
		string description = CleanText(eventData.Element("Description")?.Value ?? "Empty");
		List<EventTag> eventTags = GetEventTags(eventData.Element("Tag")?.Value);
		EventCalculatorDelegate eventCalculatorMethod = EventManager.GetEventCalculatorMethod(result);
		return new EventData(result, result2, empty, description, eventTags, eventCalculatorMethod);
	}

	public static List<EventTag> GetEventTags(string rawTags)
	{
		if (string.IsNullOrEmpty(rawTags))
		{
			return new List<EventTag>();
		}
		return rawTags.Split(',').Select(delegate(string rawTag)
		{
			if (!Enum.TryParse<EventTag>(rawTag, out var result))
			{
				throw new Exception("Event tag '" + rawTag + "' not found!");
			}
			return result;
		}).ToList();
	}

	private static string CleanText(string text)
	{
		return HttpUtility.HtmlDecode(Regex.Replace(text, "\\s+", " "));
	}

	public bool Contains(string searchText)
	{
		string input = $"{FormattedName} {Description} {Nature} {string.Join(",", EventTags)}";
		string pattern = "\\b" + Regex.Escape(searchText) + "\\b";
		return Regex.Match(input, pattern, RegexOptions.IgnoreCase).Success;
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(EventData))
		{
			EventData eventData = (EventData)value;
			return GetHashCode() == eventData.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = Name.GetHashCode();
		int hashCode2 = Nature.GetHashCode();
		int stringHashCode = Tools.GetStringHashCode(Description);
		return hashCode + hashCode2 + stringHashCode;
	}

	public override string ToString()
	{
		return $"{Name} - {Nature} - {Description}";
	}

	public static bool operator ==(EventData left, EventData right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(EventData left, EventData right)
	{
		return !(left == right);
	}

	public static List<EventData> FromJsonList(JToken eventDataList)
	{
		if (eventDataList == null)
		{
			return new List<EventData>();
		}
		List<EventData> list = new List<EventData>();
		foreach (JToken item in (IEnumerable<JToken>)eventDataList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	JObject IToJson.ToJson()
	{
		return ToJson();
	}

	public JObject ToJson()
	{
		JObject obj = new JObject
		{
			["Name"] = Name.ToString(),
			["Nature"] = Nature.ToString(),
			["SpecializedSummary"] = SpecializedSummary.ToJson(),
			["Description"] = Description
		};
		string text = string.Join(",", EventTags);
		obj["Tag"] = text;
		obj["CalculatorMethod"] = EventCalculator.Method.Name;
		return obj;
	}

	public static EventData FromJson(JToken eventData)
	{
		if (eventData == null)
		{
			return Empty;
		}
		Enum.TryParse<EventName>(eventData["Name"]?.Value<string>() ?? "Empty", out var result);
		Enum.TryParse<EventNature>(eventData["Nature"]?.Value<string>() ?? "Empty", out var result2);
		SpecializedSummary specializedNature = SpecializedSummary.FromJson(eventData["SpecializedSummary"] as JObject);
		string description = CleanText(eventData["Description"]?.Value<string>() ?? "Empty");
		List<EventTag> eventTags = GetEventTags(eventData["Tag"]?.Value<string>());
		EventCalculatorDelegate eventCalculatorMethod = EventManager.GetEventCalculatorMethod(result);
		return new EventData(result, result2, specializedNature, description, eventTags, eventCalculatorMethod);
	}

	public static JArray ListToJson(List<EventData> eventDataList)
	{
		JArray jArray = new JArray();
		foreach (EventData eventData in eventDataList)
		{
			jArray.Add(eventData.ToJson());
		}
		return jArray;
	}
}
