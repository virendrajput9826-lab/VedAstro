using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

[TypeConverter(typeof(PlanetNameTypeConverter))]
public class PlanetName : IToXml, IFromUrl, IToJson
{
	public enum PlanetNameEnum
	{
		Empty,
		Sun,
		Moon,
		Mars,
		Mercury,
		Jupiter,
		Venus,
		Saturn,
		Rahu,
		Ketu,
		Earth,
		Dhuma,
		Vyatipaata,
		Parivesha,
		Indrachaapa,
		Upaketu,
		Kaala,
		Mrityu,
		Arthaprahaara,
		Yamaghantaka,
		Gulika,
		Maandi
	}

	public static int OpenAPILength = 2;

	public static readonly PlanetName Sun = new PlanetName(PlanetNameEnum.Sun);

	public static readonly PlanetName Moon = new PlanetName(PlanetNameEnum.Moon);

	public static readonly PlanetName Mars = new PlanetName(PlanetNameEnum.Mars);

	public static readonly PlanetName Mercury = new PlanetName(PlanetNameEnum.Mercury);

	public static readonly PlanetName Jupiter = new PlanetName(PlanetNameEnum.Jupiter);

	public static readonly PlanetName Venus = new PlanetName(PlanetNameEnum.Venus);

	public static readonly PlanetName Saturn = new PlanetName(PlanetNameEnum.Saturn);

	public static readonly PlanetName Earth = new PlanetName(PlanetNameEnum.Earth);

	public static readonly PlanetName Dhuma = new PlanetName(PlanetNameEnum.Dhuma);

	public static readonly PlanetName Vyatipaata = new PlanetName(PlanetNameEnum.Vyatipaata);

	public static readonly PlanetName Parivesha = new PlanetName(PlanetNameEnum.Parivesha);

	public static readonly PlanetName Indrachaapa = new PlanetName(PlanetNameEnum.Indrachaapa);

	public static readonly PlanetName Upaketu = new PlanetName(PlanetNameEnum.Upaketu);

	public static readonly PlanetName Kaala = new PlanetName(PlanetNameEnum.Kaala);

	public static readonly PlanetName Mrityu = new PlanetName(PlanetNameEnum.Mrityu);

	public static readonly PlanetName Arthaprahaara = new PlanetName(PlanetNameEnum.Arthaprahaara);

	public static readonly PlanetName Yamaghantaka = new PlanetName(PlanetNameEnum.Yamaghantaka);

	public static readonly PlanetName Gulika = new PlanetName(PlanetNameEnum.Gulika);

	public static readonly PlanetName Maandi = new PlanetName(PlanetNameEnum.Maandi);

	public static readonly PlanetName Rahu = new PlanetName(PlanetNameEnum.Rahu);

	public static readonly PlanetName Ketu = new PlanetName(PlanetNameEnum.Ketu);

	public static readonly List<PlanetName> All7Planets = new List<PlanetName> { Sun, Moon, Mars, Mercury, Jupiter, Venus, Saturn };

	public static readonly List<PlanetName> All9Planets = new List<PlanetName> { Sun, Moon, Mars, Mercury, Jupiter, Venus, Saturn, Rahu, Ketu };

	public static readonly List<PlanetName> All9WithUpagrahas = new List<PlanetName>
	{
		Sun, Moon, Mars, Mercury, Jupiter, Venus, Saturn, Rahu, Ketu, Dhuma,
		Vyatipaata, Parivesha, Indrachaapa, Upaketu, Kaala, Mrityu, Arthaprahaara, Yamaghantaka, Gulika, Maandi
	};

	public static PlanetName Empty = new PlanetName(PlanetNameEnum.Empty);

	public PlanetNameEnum Name { get; }

	private PlanetName(PlanetNameEnum planetName)
	{
		Name = planetName;
	}

	public static PlanetName Parse(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return Empty;
		}
		return name.ToLower() switch
		{
			"sun" => Sun, 
			"moon" => Moon, 
			"mars" => Mars, 
			"mercury" => Mercury, 
			"jupiter" => Jupiter, 
			"venus" => Venus, 
			"saturn" => Saturn, 
			"ketu" => Ketu, 
			"rahu" => Rahu, 
			"dhuma" => Dhuma, 
			"vyatipaata" => Vyatipaata, 
			"parivesha" => Parivesha, 
			"indrachaapa" => Indrachaapa, 
			"upaketu" => Upaketu, 
			"kaala" => Kaala, 
			"mrityu" => Mrityu, 
			"arthaprahaara" => Arthaprahaara, 
			"yamaghantaka" => Yamaghantaka, 
			"gulika" => Gulika, 
			"maandi" => Maandi, 
			_ => Empty, 
		};
	}

	public static bool TryParse(string possiblePlanetName, out PlanetName parsed)
	{
		switch (possiblePlanetName.ToLower())
		{
		case "sun":
			parsed = Sun;
			return true;
		case "moon":
			parsed = Moon;
			return true;
		case "mars":
			parsed = Mars;
			return true;
		case "mercury":
			parsed = Mercury;
			return true;
		case "jupiter":
			parsed = Jupiter;
			return true;
		case "venus":
			parsed = Venus;
			return true;
		case "saturn":
			parsed = Saturn;
			return true;
		case "rahu":
			parsed = Rahu;
			return true;
		case "ketu":
			parsed = Ketu;
			return true;
		case "dhuma":
			parsed = Dhuma;
			return true;
		case "vyatipaata":
			parsed = Vyatipaata;
			return true;
		case "parivesha":
			parsed = Parivesha;
			return true;
		case "indrachaapa":
			parsed = Indrachaapa;
			return true;
		case "upaketu":
			parsed = Upaketu;
			return true;
		case "kaala":
			parsed = Kaala;
			return true;
		case "mrityu":
			parsed = Mrityu;
			return true;
		case "arthaprahaara":
			parsed = Arthaprahaara;
			return true;
		case "yamaghantaka":
			parsed = Yamaghantaka;
			return true;
		case "gulika":
			parsed = Gulika;
			return true;
		case "maandi":
			parsed = Maandi;
			return true;
		default:
			parsed = null;
			return false;
		}
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("PlanetName");
		XElement content = new XElement("Name", Name.ToString());
		xElement.Add(content);
		return xElement;
	}

	public dynamic FromXml<T>(XElement planetNameXml) where T : IToXml
	{
		return FromXml(planetNameXml);
	}

	public static PlanetName FromXml(XElement planetNameXml)
	{
		return new PlanetName(Enum.Parse<PlanetNameEnum>(planetNameXml?.Element("Name")?.Value ?? "Empty"));
	}

	public static List<PlanetName> FromXmlList(XElement planetNameListXml)
	{
		List<PlanetName> list = new List<PlanetName>();
		foreach (XElement item in planetNameListXml.Elements())
		{
			list.Add(FromXml(item));
		}
		return list;
	}

	public static async Task<dynamic> FromUrl(string url)
	{
		return Parse(url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1]);
	}

	public static XElement ToXmlList(List<PlanetName> planetNameList)
	{
		XElement xElement = new XElement("PlanetNameList");
		foreach (PlanetName planetName in planetNameList)
		{
			xElement.Add(planetName.ToXml());
		}
		return xElement;
	}

	JObject IToJson.ToJson()
	{
		return (JObject)ToJson();
	}

	public JToken ToJson()
	{
		return new JObject { ["Name"] = Name.ToString() };
	}

	public static List<PlanetName> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<PlanetName>();
		}
		List<PlanetName> list = new List<PlanetName>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static JArray ToJsonList(List<PlanetName> planetNameList)
	{
		JArray jArray = new JArray();
		foreach (PlanetName planetName in planetNameList)
		{
			jArray.Add(planetName.ToString());
		}
		return jArray;
	}

	public static PlanetName FromJson(JToken planetInput)
	{
		if (planetInput == null)
		{
			return Empty;
		}
		try
		{
			string value = planetInput["Name"].Value<string>();
			return new PlanetName((PlanetNameEnum)Enum.Parse(typeof(PlanetNameEnum), value));
		}
		catch (Exception)
		{
			LibLogger.Debug("Failed to parse:\n" + planetInput.ToString());
			return Empty;
		}
	}

	public static bool operator ==(PlanetName left, PlanetName right)
	{
		return left?.Equals(right) ?? ((object)right == null);
	}

	public static bool operator !=(PlanetName left, PlanetName right)
	{
		return !(left == right);
	}

	public override string ToString()
	{
		return Name.ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() == typeof(PlanetName))
		{
			PlanetName planetName = (PlanetName)obj;
			return GetHashCode() == planetName.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}
}
