using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class MatchPrediction : IToXml
{
	public static MatchPrediction Empty = new MatchPrediction(MatchPredictionName.Empty, EventNature.Empty, "Empty", "Empty", "Empty", "Empty");

	private string _info = "";

	private string _maleInfo = "";

	private string _femaleInfo = "";

	private string _description = "";

	public MatchPredictionName Name { get; set; }

	public string Description
	{
		get
		{
			return _description;
		}
		set
		{
			if (_description != "")
			{
				throw new InvalidOperationException("Only set once!");
			}
			_description = value;
		}
	}

	public EventNature Nature { get; set; }

	public string Info
	{
		get
		{
			return _info;
		}
		set
		{
			if (_info != "")
			{
				throw new InvalidOperationException("Only set once!");
			}
			_info = value;
		}
	}

	public string MaleInfo
	{
		get
		{
			return _maleInfo;
		}
		set
		{
			if (_maleInfo != "")
			{
				throw new InvalidOperationException("Only set once!");
			}
			_maleInfo = value;
		}
	}

	public string FemaleInfo
	{
		get
		{
			return _femaleInfo;
		}
		set
		{
			if (_femaleInfo != "")
			{
				throw new InvalidOperationException("Only set once!");
			}
			_femaleInfo = value;
		}
	}

	public string FormattedName => Format.FormatName(Name);

	public MatchPrediction(MatchPredictionName name, EventNature nature, string maleInfo, string femaleInfo, string info, string description)
	{
		Name = name;
		Nature = nature;
		MaleInfo = maleInfo;
		FemaleInfo = femaleInfo;
		Info = info;
		Description = description;
	}

	public MatchPrediction()
	{
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	public MatchPrediction FromXml(XElement xml)
	{
		MatchPredictionName name = Enum.Parse<MatchPredictionName>(xml.Element("Name")?.Value);
		EventNature nature = Enum.Parse<EventNature>(xml.Element("Nature")?.Value);
		string maleInfo = xml.Element("MaleInfo")?.Value;
		string femaleInfo = xml.Element("FemaleInfo")?.Value;
		string info = xml.Element("Info")?.Value;
		string description = xml.Element("Description")?.Value;
		return new MatchPrediction(name, nature, maleInfo, femaleInfo, info, description);
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("MatchPrediction");
		XElement xElement2 = new XElement("Name", Name);
		XElement xElement3 = new XElement("Nature", Nature);
		XElement xElement4 = new XElement("MaleInfo", MaleInfo);
		XElement xElement5 = new XElement("FemaleInfo", FemaleInfo);
		XElement xElement6 = new XElement("Info", Info);
		XElement xElement7 = new XElement("Description", Description);
		xElement.Add(xElement2, xElement3, xElement4, xElement5, xElement6, xElement7);
		return xElement;
	}

	public JToken ToJson()
	{
		return new JObject
		{
			["Name"] = Name.ToString(),
			["Nature"] = Nature.ToString(),
			["MaleInfo"] = MaleInfo,
			["FemaleInfo"] = FemaleInfo,
			["Info"] = Info,
			["Description"] = Description
		};
	}

	public static JArray ToJsonList(List<MatchPrediction> predictionList)
	{
		JArray jArray = new JArray();
		foreach (MatchPrediction prediction in predictionList)
		{
			jArray.Add(prediction.ToJson());
		}
		return jArray;
	}
}
