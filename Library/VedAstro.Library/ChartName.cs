using System.Xml.Linq;

namespace VedAstro.Library;

public readonly struct ChartName(string name, string chartId)
{
	public string Name { get; init; } = name;

	public string ChartId { get; init; } = chartId;

	public static ChartName FromXml(XElement chartNameXml)
	{
		string name = chartNameXml.Element("Name")?.Value;
		string chartId = chartNameXml.Element("ChartId")?.Value;
		return new ChartName(name, chartId);
	}
}
