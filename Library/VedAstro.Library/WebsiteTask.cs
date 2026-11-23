using System.Xml.Linq;

namespace VedAstro.Library;

public class WebsiteTask : IToXml
{
	public string? Name { get; set; }

	public string? Description { get; set; }

	public string? Status { get; set; }

	public string? Date { get; set; }

	public XElement ToXml()
	{
		XElement xElement = new XElement("Task");
		XElement xElement2 = new XElement("Name", Tools.AnyTypeToXml(Name));
		XElement xElement3 = new XElement("Description", Tools.AnyTypeToXml(Description));
		XElement xElement4 = new XElement("Status", Tools.AnyTypeToXml(Status));
		XElement xElement5 = new XElement("Date", Tools.AnyTypeToXml(Date));
		xElement.Add(xElement2, xElement3, xElement4, xElement5);
		return xElement;
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	public static WebsiteTask FromXml(XElement root)
	{
		string name = root.Element("Name")?.Value;
		string description = root.Element("Description")?.Value;
		string status = root.Element("Status")?.Value;
		string date = root.Element("Date")?.Value;
		return new WebsiteTask
		{
			Name = name,
			Description = description,
			Status = status,
			Date = date
		};
	}
}
