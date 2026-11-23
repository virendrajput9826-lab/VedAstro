using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class RelatedBody : IToXml, IToJson
{
	public static readonly RelatedBody Empty = new RelatedBody();

	public List<PlanetName> RelatedPlanets { get; private set; } = new List<PlanetName>();

	public List<ZodiacName> RelatedZodiac { get; private set; } = new List<ZodiacName>();

	public List<HouseName> RelatedHouses { get; private set; } = new List<HouseName>();

	public bool Contains(PlanetName planetName)
	{
		return RelatedPlanets.Contains(planetName);
	}

	public bool Contains(ZodiacName zodiacName)
	{
		return RelatedZodiac.Contains(zodiacName);
	}

	public bool Contains(HouseName houseName)
	{
		return RelatedHouses.Contains(houseName);
	}

	public override string ToString()
	{
		return string.Concat(string.Concat("" + Tools.ListToString(RelatedPlanets), Tools.ListToString(RelatedHouses)), Tools.ListToString(RelatedZodiac));
	}

	public dynamic FromXml<T>(XElement relatedBodyXml) where T : IToXml
	{
		return FromXml(relatedBodyXml);
	}

	public static RelatedBody FromXml(XElement relatedBodyXml)
	{
		RelatedBody relatedBody = new RelatedBody();
		XElement planetNameListXml = relatedBodyXml?.Element("PlanetNameList") ?? new XElement("PlanetNameList");
		relatedBody.RelatedPlanets = PlanetName.FromXmlList(planetNameListXml);
		XElement houseNameListXml = relatedBodyXml?.Element("HouseNameList") ?? new XElement("HouseNameList");
		relatedBody.RelatedHouses = HouseNameExtensions.FromXmlList(houseNameListXml);
		XElement zodiacNameListXml = relatedBodyXml?.Element("ZodiacNameList") ?? new XElement("ZodiacNameList");
		relatedBody.RelatedZodiac = ZodiacNameExtensions.FromXmlList(zodiacNameListXml);
		return relatedBody;
	}

	public XElement ToXml()
	{
		XElement xElement = PlanetName.ToXmlList(RelatedPlanets);
		XElement xElement2 = HouseNameExtensions.ToXmlList(RelatedHouses);
		XElement xElement3 = ZodiacNameExtensions.ToXmlList(RelatedZodiac);
		return new XElement("RelatedBody", xElement, xElement2, xElement3);
	}

	JObject IToJson.ToJson()
	{
		return (JObject)ToJson();
	}

	public JToken ToJson()
	{
		return new JObject
		{
			["Planets"] = PlanetName.ToJsonList(RelatedPlanets),
			["Houses"] = HouseNameExtensions.ToJsonList(RelatedHouses),
			["Zodiacs"] = ZodiacNameExtensions.ToJsonList(RelatedZodiac)
		};
	}

	public static List<RelatedBody> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<RelatedBody>();
		}
		List<RelatedBody> list = new List<RelatedBody>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static RelatedBody FromJson(JToken horoscopeInput)
	{
		if (horoscopeInput == null)
		{
			return Empty;
		}
		try
		{
			List<PlanetName> relatedPlanets = PlanetName.FromJsonList(horoscopeInput["Planets"]);
			List<HouseName> relatedHouses = HouseNameExtensions.FromJsonList(horoscopeInput["Houses"]);
			List<ZodiacName> relatedZodiac = ZodiacNameExtensions.FromJsonList(horoscopeInput["Zodiacs"]);
			return new RelatedBody
			{
				RelatedPlanets = relatedPlanets,
				RelatedHouses = relatedHouses,
				RelatedZodiac = relatedZodiac
			};
		}
		catch (Exception)
		{
			LibLogger.Debug("Failed to parse Person:\n" + horoscopeInput.ToString());
			return Empty;
		}
	}
}
