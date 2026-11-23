using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class DasaEvent(Event sourceEvent)
{
	public int DasaLevel
	{
		get
		{
			if (sourceEvent.EventTags.Contains(EventTag.PD1))
			{
				return 1;
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD2))
			{
				return 2;
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD3))
			{
				return 3;
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD4))
			{
				return 4;
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD5))
			{
				return 5;
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD6))
			{
				return 6;
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD7))
			{
				return 7;
			}
			throw new Exception("Dasa level not found");
		}
	}

	public string DasaName
	{
		get
		{
			if (sourceEvent.EventTags.Contains(EventTag.PD1))
			{
				return "Dasa";
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD2))
			{
				return "Bhukti";
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD3))
			{
				return "Antaram";
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD4))
			{
				return "Sukshma";
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD5))
			{
				return "Prana";
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD6))
			{
				return "Avi Prana";
			}
			if (sourceEvent.EventTags.Contains(EventTag.PD7))
			{
				return "Viprana";
			}
			throw new Exception("Dasa level not found");
		}
	}

	public double Duration => sourceEvent.DurationHour;

	public string Description => sourceEvent.Description;

	public Time StartTime => sourceEvent.StartTime;

	public Time EndTime => sourceEvent.EndTime;

	public EventNature Nature => sourceEvent.Nature;

	public PlanetName Lord => PlanetName.Parse(Tools.GetCamelCaseWord(sourceEvent.Name.ToString(), 1));

	public PlanetName ParentLord => PlanetName.Parse(Tools.GetCamelCaseWord(sourceEvent.Name.ToString()));

	public Event SourceEvent => sourceEvent;

	public JToken ToJson()
	{
		return new JObject
		{
			["Name"] = ConvertToClassicDasaName(sourceEvent),
			["FullName"] = sourceEvent.Name.ToString(),
			["StartTime"] = sourceEvent.StartTime.GetStdDateTimeOffsetText(),
			["EndTime"] = sourceEvent.EndTime.GetStdDateTimeOffsetText(),
			["DurationHour"] = sourceEvent.DurationHour
		};
	}

	private string ConvertToClassicDasaName(Event inputEvent)
	{
		string camelCaseWord = Tools.GetCamelCaseWord(inputEvent.Name.ToString());
		return string.Concat(string.Concat("" + camelCaseWord, " "), DasaName);
	}

	public static List<DasaEvent> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<DasaEvent>();
		}
		List<DasaEvent> list = new List<DasaEvent>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static JArray ToJsonList(List<DasaEvent> eventList)
	{
		JArray jArray = new JArray();
		foreach (DasaEvent @event in eventList)
		{
			jArray.Add(@event.ToJson());
		}
		return jArray;
	}

	public static DasaEvent FromJson(JToken planetInput)
	{
		throw new NotImplementedException();
	}
}
