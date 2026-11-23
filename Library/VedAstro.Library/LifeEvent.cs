using System;
using System.Collections.Generic;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class LifeEvent : IToXml
{
	public static LifeEvent Empty = new LifeEvent("Empty", "Empty", Time.Empty, "New Life Event", "Event Description", "Neutral", "Normal");

	private string _name;

	private string _description;

	public string Name
	{
		get
		{
			return HttpUtility.HtmlDecode(_name);
		}
		set
		{
			_name = HttpUtility.HtmlEncode(value);
		}
	}

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

	public Time StartTime { get; set; }

	public string Nature { get; set; }

	public string Weight { get; set; }

	public string Id { get; set; }

	public string PersonId { get; set; }

	public string SearchText => string.Concat(string.Concat(string.Concat(string.Concat("" + Name, Description), StartTime.ToString()), Nature), Weight);

	public LifeEvent(string personId, string uniqueId, Time startTime, string name, string description, string nature, string weight)
	{
		PersonId = personId;
		Id = uniqueId;
		Name = name;
		StartTime = startTime;
		Description = description;
		Nature = nature;
		Weight = weight;
	}

	public JObject ToJson()
	{
		return new JObject
		{
			["PersonId"] = PersonId,
			["Id"] = Id,
			["Name"] = Name,
			["StartTime"] = StartTime.ToJson(),
			["Description"] = Description,
			["Nature"] = Nature,
			["Weight"] = Weight
		};
	}

	public LifeEventRow ToAzureRow()
	{
		return new LifeEventRow
		{
			PartitionKey = PersonId,
			RowKey = Id,
			StartTime = StartTime.ToJson().ToString(),
			Name = Name,
			Description = Description,
			Nature = Nature,
			Weight = Weight
		};
	}

	public static LifeEvent FromAzureRow(LifeEventRow rowData)
	{
		Time startTime = Time.FromJson(JToken.Parse(rowData.StartTime));
		return new LifeEvent(rowData.PartitionKey, rowData.RowKey, startTime, rowData.Name, rowData.Description, rowData.Nature, rowData.Weight);
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("LifeEvent");
		XElement xElement2 = new XElement("Id", Id);
		XElement xElement3 = new XElement("PersonId", PersonId);
		XElement xElement4 = new XElement("Name", Name);
		XElement xElement5 = new XElement("StartTime", StartTime.ToXml());
		XElement xElement6 = new XElement("Description", Description);
		XElement xElement7 = new XElement("Nature", Nature);
		XElement xElement8 = new XElement("Weight", this?.Weight ?? "Normal");
		xElement.Add(xElement3, xElement2, xElement4, xElement5, xElement6, xElement7, xElement8);
		return xElement;
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	public static LifeEvent FromXml(XElement lifeEventXml)
	{
		string uniqueId = (string.IsNullOrEmpty(lifeEventXml.Element("Id")?.Value) ? "" : lifeEventXml?.Element("Id")?.Value);
		string personId = (string.IsNullOrEmpty(lifeEventXml.Element("PersonId")?.Value) ? "" : lifeEventXml?.Element("PersonIdId")?.Value);
		string name = (string.IsNullOrEmpty(lifeEventXml.Element("Name")?.Value) ? "" : lifeEventXml?.Element("Name")?.Value);
		string description = (string.IsNullOrEmpty(lifeEventXml.Element("Description")?.Value) ? "" : lifeEventXml?.Element("Description")?.Value);
		string nature = (string.IsNullOrEmpty(lifeEventXml.Element("Nature")?.Value) ? "" : lifeEventXml?.Element("Nature")?.Value);
		string weight = (string.IsNullOrEmpty(lifeEventXml.Element("Weight")?.Value) ? "Normal" : lifeEventXml?.Element("Weight")?.Value);
		Time startTime = Time.FromXml(lifeEventXml.Element("StartTime")?.Element("Time"));
		return new LifeEvent(personId, uniqueId, startTime, name, description, nature, weight);
	}

	public static List<LifeEvent> FromJsonList(JToken lifeEventList)
	{
		List<LifeEvent> list = new List<LifeEvent>();
		foreach (JToken item in (IEnumerable<JToken>)lifeEventList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static LifeEvent FromJson(JToken lifeEvent)
	{
		string? personId = lifeEvent["PersonId"].Value<string>();
		string uniqueId = lifeEvent["Id"].Value<string>();
		string name = lifeEvent["Name"].Value<string>();
		Time startTime = Time.FromJson(lifeEvent["StartTime"]);
		string description = lifeEvent["Description"].Value<string>();
		string nature = lifeEvent["Nature"].Value<string>();
		string weight = lifeEvent["Weight"]?.Value<string>() ?? "Normal";
		return new LifeEvent(personId, uniqueId, startTime, name, description, nature, weight);
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(LifeEvent))
		{
			LifeEvent lifeEvent = (LifeEvent)value;
			return GetHashCode() == lifeEvent.GetHashCode();
		}
		return false;
	}

	public override string ToString()
	{
		return $"{Name} - {Nature} - {Weight} - {StartTime} - {Description}";
	}

	public override int GetHashCode()
	{
		int stringHashCode = Tools.GetStringHashCode(Id);
		int stringHashCode2 = Tools.GetStringHashCode(Name);
		int hashCode = StartTime.GetHashCode();
		int stringHashCode3 = Tools.GetStringHashCode(Description);
		int stringHashCode4 = Tools.GetStringHashCode(Nature);
		int stringHashCode5 = Tools.GetStringHashCode(Weight);
		return Math.Abs(stringHashCode + stringHashCode2 + hashCode + stringHashCode3 + stringHashCode4 + stringHashCode5);
	}

	public int CompareTo(LifeEvent lifeEvent)
	{
		DateTimeOffset stdDateTimeOffset = lifeEvent.StartTime.GetStdDateTimeOffset();
		return StartTime.GetStdDateTimeOffset().CompareTo(stdDateTimeOffset);
	}
}
