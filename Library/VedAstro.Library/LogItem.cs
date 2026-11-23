using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace VedAstro.Library;

public readonly record struct LogItem(Time Time, string VisitorId, string UserId, string Url, string Branch, string Source, string Data)
{
	public static LogItem FromXml(XElement logItemXml)
	{
		string userId = logItemXml.Element("UserId")?.Value ?? "";
		string visitorId = logItemXml.Element("VisitorId")?.Value ?? "";
		string url = logItemXml.Element("Url")?.Value ?? "";
		string branch = logItemXml.Element("Branch")?.Value ?? "";
		string source = logItemXml.Element("Source")?.Value ?? "";
		string data = logItemXml.Element("Data")?.Value ?? "";
		string text = logItemXml.Element("TimeStampServer")?.Value ?? "00:00 01/01/2000 +08:00";
		text = text.Replace('.', '/');
		GeoLocation geoLocation = new GeoLocation("Ipoh", 101.0901, 4.5975);
		Time time = new Time(text, geoLocation);
		return new LogItem(time, visitorId, userId, url, branch, source, data);
	}

	public static List<LogItem> FromXml(IEnumerable<XElement> xmlRecordList)
	{
		return xmlRecordList.Select((XElement logItemXml) => FromXml(logItemXml)).ToList();
	}

	public override string ToString()
	{
		return $"Visitor:{VisitorId} - Url:{Url} - Branch:{Branch} - Data:{Data} - ";
	}
}
