using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public static class ZodiacNameExtensions
{
	public static List<ZodiacName> AllZodiacSigns = (from ZodiacName z in Enum.GetValues(typeof(ZodiacName))
		where z != ZodiacName.Empty
		select z).ToList();

	public static ZodiacName FromXml(XElement zodiacNameXml)
	{
		Enum.TryParse<ZodiacName>(zodiacNameXml.Value, out var result);
		return result;
	}

	public static List<ZodiacName> FromXmlList(XElement zodiacNameListXml)
	{
		List<ZodiacName> list = new List<ZodiacName>();
		foreach (XElement item in zodiacNameListXml.Elements())
		{
			list.Add(FromXml(item));
		}
		return list;
	}

	public static XElement ToXmlList(List<ZodiacName> zodiacNameList)
	{
		XElement xElement = new XElement("ZodiacNameList");
		foreach (ZodiacName zodiacName in zodiacNameList)
		{
			xElement.Add(zodiacName.ToXml());
		}
		return xElement;
	}

	public static XElement ToXml(this ZodiacName _eventTag)
	{
		return new XElement("ZodiacName", _eventTag.ToString());
	}

	public static Dictionary<ZodiacName, T> AllZodiacSignsDictionary<T>(T defaultValue)
	{
		Dictionary<ZodiacName, T> dictionary = new Dictionary<ZodiacName, T>();
		foreach (ZodiacName allZodiacSign in AllZodiacSigns)
		{
			dictionary.Add(allZodiacSign, defaultValue);
		}
		return dictionary;
	}

	public static List<ZodiacName> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<ZodiacName>();
		}
		List<ZodiacName> list = new List<ZodiacName>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static JArray ToJsonList(List<ZodiacName> zodiacNameList)
	{
		JArray jArray = new JArray();
		foreach (ZodiacName zodiacName in zodiacNameList)
		{
			jArray.Add(zodiacName.ToString());
		}
		return jArray;
	}

	public static ZodiacName FromJson(JToken planetInput)
	{
		if (planetInput == null)
		{
			return ZodiacName.Empty;
		}
		try
		{
			string value = planetInput.Value<string>();
			return (ZodiacName)Enum.Parse(typeof(ZodiacName), value);
		}
		catch (Exception)
		{
			LibLogger.Debug("Failed to parse:\n" + planetInput.ToString());
			return ZodiacName.Empty;
		}
	}
}
