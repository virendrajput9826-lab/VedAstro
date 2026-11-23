using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public static class HouseNameExtensions
{
	public static string ToString(this HouseName inputHouse)
	{
		return $"House {(int)inputHouse}";
	}

	public static HouseName? FromString(string inputHouseName)
	{
		return (HouseName)Enum.Parse(typeof(HouseName), inputHouseName, ignoreCase: true);
	}

	public static HouseName FromXml(XElement houseNameXml)
	{
		Enum.TryParse<HouseName>(houseNameXml.Value, out var result);
		return result;
	}

	public static List<HouseName> FromXmlList(XElement houseNameListXml)
	{
		List<HouseName> list = new List<HouseName>();
		foreach (XElement item in houseNameListXml.Elements())
		{
			list.Add(FromXml(item));
		}
		return list;
	}

	public static XElement ToXmlList(List<HouseName> houseNameList)
	{
		XElement xElement = new XElement("HouseNameList");
		foreach (HouseName houseName in houseNameList)
		{
			xElement.Add(houseName.ToXml());
		}
		return xElement;
	}

	public static XElement ToXml(this HouseName _eventTag)
	{
		return new XElement("HouseName", _eventTag.ToString());
	}

	public static async Task<dynamic> FromUrl(string url)
	{
		return (HouseName)int.Parse(url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1]);
	}

	public static List<HouseName> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<HouseName>();
		}
		List<HouseName> list = new List<HouseName>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static JArray ToJsonList(List<HouseName> houseNameList)
	{
		JArray jArray = new JArray();
		foreach (HouseName houseName in houseNameList)
		{
			jArray.Add(houseName.ToString());
		}
		return jArray;
	}

	public static HouseName FromJson(JToken planetInput)
	{
		if (planetInput == null)
		{
			return HouseName.Empty;
		}
		try
		{
			string value = planetInput.Value<string>();
			return (HouseName)Enum.Parse(typeof(HouseName), value);
		}
		catch (Exception)
		{
			LibLogger.Debug("Failed to parse:\n" + planetInput.ToString());
			return HouseName.Empty;
		}
	}
}
