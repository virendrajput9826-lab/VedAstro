using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public static class EventTagExtensions
{
	public static EventTag FromXml(XElement eventTagXml)
	{
		Enum.TryParse<EventTag>(eventTagXml.Value, out var result);
		return result;
	}

	public static EventTag FromJson(JToken eventTagJson)
	{
		Enum.TryParse<EventTag>(eventTagJson.Value<string>(), out var result);
		return result;
	}

	public static List<EventTag> FromXmlList(XElement eventTagListXml)
	{
		List<EventTag> list = new List<EventTag>();
		foreach (XElement item in eventTagListXml.Elements())
		{
			list.Add(FromXml(item));
		}
		return list;
	}

	public static List<EventTag> FromJsonList(JToken eventTagJsonList)
	{
		List<EventTag> list = new List<EventTag>();
		foreach (JToken item in (IEnumerable<JToken>)eventTagJsonList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static XElement ToXmlList(List<EventTag> eventTagList)
	{
		XElement xElement = new XElement("EventTagList");
		foreach (EventTag eventTag in eventTagList)
		{
			xElement.Add(eventTag.ToXml());
		}
		return xElement;
	}

	public static JArray ToJsonList(List<EventTag> eventTagList)
	{
		JArray jArray = new JArray();
		foreach (EventTag eventTag in eventTagList)
		{
			jArray.Add(eventTag.ToString());
		}
		return jArray;
	}

	public static XElement ToXml(this EventTag _eventTag)
	{
		return new XElement("EventTag", _eventTag.ToString());
	}

	public static JObject ToJson(this EventTag _eventTag)
	{
		return new JObject(_eventTag.ToString());
	}

	public static List<EventTag> GetAll()
	{
		return Enum.GetValues(typeof(EventTag)).Cast<EventTag>().ToList();
	}

	public static List<EventTag> FromString(string eventTagString)
	{
		return (from s in eventTagString.Split(',')
			select (EventTag)Enum.Parse(typeof(EventTag), s)).ToList();
	}
}
