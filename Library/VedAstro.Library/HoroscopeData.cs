using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public struct HoroscopeData : IToJson
{
	private string _description;

	public HoroscopeName Name { get; private set; }

	public string FormattedName => Format.FormatName(this);

	public SpecializedSummary SpecializedSummary { get; private set; }

	public EventNature Nature { get; private set; }

	public HoroscopeCalculatorDelegate HoroscopeCalculator { get; private set; }

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

	public HoroscopeData(HoroscopeName name, EventNature nature, SpecializedSummary specializedNature, string description, List<EventTag> eventTags, HoroscopeCalculatorDelegate horoscopeCalculator)
	{
		EventTags = null;
		_description = "";
		Name = HoroscopeName.Empty;
		RelatedBody = new RelatedBody();
		Name = name;
		Nature = nature;
		SpecializedSummary = specializedNature;
		HoroscopeCalculator = horoscopeCalculator;
		Description = description;
		EventTags = eventTags;
	}

	public bool IsEventOccuring(Time time)
	{
		CalculatorResult calculatorResult = HoroscopeCalculator(time);
		bool occuring = calculatorResult.Occuring;
		RelatedBody = calculatorResult.RelatedBody;
		Nature = ((calculatorResult.NatureOverride == EventNature.Empty) ? Nature : calculatorResult.NatureOverride);
		bool flag = !string.IsNullOrEmpty(calculatorResult.DescriptionOverride);
		Description = (flag ? calculatorResult.DescriptionOverride : Description);
		return occuring;
	}

	public static HoroscopeData FromXml(XElement horoscopeData)
	{
		Enum.TryParse<HoroscopeName>(horoscopeData.Element("Name")?.Value, out var result);
		Enum.TryParse<EventNature>(horoscopeData.Element("Nature")?.Value, out var result2);
		string description = CleanText(horoscopeData.Element("Description")?.Value);
		List<EventTag> eventTags = getEventTags(horoscopeData.Element("Tag")?.Value);
		HoroscopeCalculatorDelegate horoscopeCalculatorMethod = EventManager.GetHoroscopeCalculatorMethod(result);
		return new HoroscopeData(result, result2, SpecializedSummary.Empty, description, eventTags, horoscopeCalculatorMethod);
		static string CleanText(string text)
		{
			return HttpUtility.HtmlDecode(Regex.Replace(text, "\\s+", " "));
		}
		static List<EventTag> getEventTags(string rawTags)
		{
			List<EventTag> list = new List<EventTag>();
			string[] array = rawTags.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				if (!Enum.TryParse<EventTag>(array[i], out var result3))
				{
					throw new Exception("Event tag not found!");
				}
				list.Add(result3);
			}
			return list;
		}
	}

	public bool Contains(string searchText)
	{
		string input = $"{FormattedName} {Description} {Nature} {string.Join(",", EventTags)}";
		string pattern = "\\b" + Regex.Escape(searchText) + "\\b";
		return Regex.Match(input, pattern, RegexOptions.IgnoreCase).Success;
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
		return obj;
	}

	public static EventData FromJson(JToken eventData)
	{
		throw new NotImplementedException();
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(HoroscopeData))
		{
			HoroscopeData horoscopeData = (HoroscopeData)value;
			return GetHashCode() == horoscopeData.GetHashCode();
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

	public static bool operator ==(HoroscopeData left, HoroscopeData right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(HoroscopeData left, HoroscopeData right)
	{
		return !(left == right);
	}

	public static List<HoroscopeData> FromXmlList(List<XElement> horoscopeDataListXml)
	{
		List<HoroscopeData> list = new List<HoroscopeData>();
		foreach (XElement item in horoscopeDataListXml)
		{
			list.Add(FromXml(item));
		}
		return list;
	}
}
