using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace VedAstro.Library;

public static class DatabaseManager
{
	public static List<EventData> GetEventDataList(string filePath)
	{
		Data data = new Data(filePath);
		List<EventData> list = new List<EventData>();
		foreach (XElement allRecord in data.GetAllRecords())
		{
			list.Add(EventData.FromXml(allRecord));
		}
		return list;
	}

	public static List<EventData> GetEventDataList(Stream eventDataListFileStream)
	{
		return GetEventDataList(new Data(eventDataListFileStream));
	}

	public static List<EventData> GetEventDataList(Data eventDataListFile)
	{
		List<EventData> list = new List<EventData>();
		foreach (XElement allRecord in eventDataListFile.GetAllRecords())
		{
			list.Add(EventData.FromXml(allRecord));
		}
		return list;
	}

	public static List<EventData> GetEventDataListByTag(EventTag tag, string filePath)
	{
		List<EventData> eventDataList = GetEventDataList(filePath);
		return GetEventDataListByTag(tag, eventDataList);
	}

	public static List<EventData> GetEventDataListByTag(EventTag tag, List<EventData> eventDataList)
	{
		return eventDataList.FindAll((EventData eventData) => eventData.EventTags.Contains(tag));
	}

	public static void SavePersonList(List<Person> personList, string filePath)
	{
		throw new NotImplementedException();
	}

	public static List<GeoLocation> GetLocationList(string dataLocationlistXml)
	{
		return new List<GeoLocation>
		{
			new GeoLocation("Ipoh", 101.0901, 4.5975),
			new GeoLocation("Kuala", 101.0901, 4.5975),
			new GeoLocation("Teluk", 101.0901, 4.5975),
			new GeoLocation("Mangaluru", 74.8625, 12.9172)
		};
	}
}
