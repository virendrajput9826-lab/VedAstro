using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class HoroscopePrediction : IToXml, IToJson
{
	public static readonly HoroscopePrediction Empty = new HoroscopePrediction(HoroscopeName.Empty, "Empty", new RelatedBody());

	public HoroscopeName Name { get; }

	public string Description { get; }

	public RelatedBody RelatedBody { get; set; }

	public string FormattedName => Format.FormatName(Name.ToString());

	public HoroscopePrediction(HoroscopeName name, string description, RelatedBody relatedBody)
	{
		Name = name;
		Description = description;
		RelatedBody = relatedBody;
	}

	public static HoroscopePrediction FromXml(XElement predictionXml)
	{
		HoroscopeName name = Enum.Parse<HoroscopeName>(predictionXml.Element("Name")?.Value ?? "Empty");
		string description = predictionXml.Element("Description")?.Value ?? "Empty Description";
		RelatedBody relatedBody = RelatedBody.FromXml(predictionXml?.Element("RelatedBody") ?? new XElement("RelatedBody"));
		return new HoroscopePrediction(name, description, relatedBody);
	}

	public static List<HoroscopePrediction> FromXmlList(XElement rootXml)
	{
		List<HoroscopePrediction> list = new List<HoroscopePrediction>();
		foreach (XElement item in rootXml.Elements())
		{
			list.Add(FromXml(item));
		}
		return list;
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("HoroscopePrediction");
		XElement xElement2 = new XElement("Name", Name.ToString());
		XElement xElement3 = new XElement("Description", Description);
		XElement xElement4 = RelatedBody.ToXml();
		xElement.Add(xElement2, xElement3, xElement4);
		return xElement;
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	private static string SplitCamelCase(string str)
	{
		return Regex.Replace(Regex.Replace(str, "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"), "(\\p{Ll})(\\P{Ll})", "$1 $2");
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(HoroscopePrediction))
		{
			HoroscopePrediction horoscopePrediction = (HoroscopePrediction)value;
			return GetHashCode() == horoscopePrediction.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = Name.GetHashCode();
		int stringHashCode = Tools.GetStringHashCode(Description);
		return hashCode + stringHashCode;
	}

	public override string ToString()
	{
		return FormattedName + " - " + Description;
	}

	public object[] ToDataRow()
	{
		return new string[3]
		{
			FormattedName,
			Description,
			RelatedBody.ToString()
		};
	}

	public bool Contains(string searchText)
	{
		string input = $"{FormattedName} {Description} {RelatedBody.ToString()}";
		string pattern = "\\b" + Regex.Escape(searchText) + "\\b";
		return Regex.Match(input, pattern, RegexOptions.IgnoreCase).Success;
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
			["Description"] = Description,
			["RelatedBody"] = RelatedBody.ToJson()
		};
	}

	public static List<HoroscopePrediction> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<HoroscopePrediction>();
		}
		List<HoroscopePrediction> list = new List<HoroscopePrediction>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static JArray ToJsonList(List<HoroscopePrediction> predictionList)
	{
		JArray jArray = new JArray();
		foreach (HoroscopePrediction prediction in predictionList)
		{
			jArray.Add(prediction.ToJson());
		}
		return jArray;
	}

	public static HoroscopePrediction FromJson(JToken horoscopeInput)
	{
		if (horoscopeInput == null)
		{
			return Empty;
		}
		try
		{
			string value = horoscopeInput["Name"].Value<string>();
			HoroscopeName name = (HoroscopeName)Enum.Parse(typeof(HoroscopeName), value);
			string description = horoscopeInput["Description"].Value<string>();
			RelatedBody relatedBody = RelatedBody.FromJson(horoscopeInput["RelatedBody"]);
			return new HoroscopePrediction(name, description, relatedBody);
		}
		catch (Exception)
		{
			LibLogger.Debug("Failed to parse Person:\n" + horoscopeInput.ToString());
			return Empty;
		}
	}

	internal static HoroscopePrediction FromLLMJson(JToken eachPrediction)
	{
		string value = eachPrediction["metadata"]["name"].Value<string>();
		HoroscopeName name = Enum.Parse<HoroscopeName>(value);
		eachPrediction["score"].Value<double>();
		HoroscopeData horoscopeData = HoroscopeDataListStatic.Rows.FirstOrDefault((HoroscopeData x) => x.Name == name);
		return new HoroscopePrediction(name, horoscopeData.Description, horoscopeData.RelatedBody);
	}
}
