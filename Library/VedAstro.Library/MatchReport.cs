using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class MatchReport : IToXml
{
	public static MatchReport Empty = new MatchReport("0", Person.Empty, Person.Empty, 0.0, "Empty Notes", new List<MatchPrediction>(), new string[1] { "101" });

	private static readonly string[] DefaultUserId = new string[1] { "101" };

	public List<MatchPrediction> PredictionList { get; set; }

	public double KutaScore { get; set; }

	public double[] Embeddings { get; set; }

	public Person Male { get; set; }

	public Person Female { get; set; }

	public string[] UserId { get; set; } = new string[1] { "101" };

	public string UserIdString
	{
		get
		{
			string text = "";
			try
			{
				return string.Join(",", UserId);
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}

	public string Notes { get; set; }

	public string Id { get; set; }

	public MatchSummaryData Summary => GetSummary(KutaScore);

	public MatchReport(string id, Person male, Person female, double kutaScore, string notes, List<MatchPrediction> predictionList, string[] userId)
	{
		Id = id;
		Male = male;
		Female = female;
		KutaScore = kutaScore;
		Notes = notes;
		PredictionList = predictionList;
		UserId = (userId.Any() ? userId : DefaultUserId);
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("MatchReport");
		XElement xElement2 = new XElement("KutaScore", KutaScore);
		XElement xElement3 = new XElement("Male", Male.ToXml());
		XElement xElement4 = new XElement("Female", Female.ToXml());
		XElement xElement5 = PredictionListToXml(PredictionList);
		XElement xElement6 = new XElement("UserId", UserIdString);
		XElement xElement7 = new XElement("Notes", Notes);
		XElement xElement8 = new XElement("Id", Id);
		xElement.Add(xElement8, xElement6, xElement7, xElement3, xElement4, xElement2, xElement5);
		return xElement;
	}

	public JToken ToJson()
	{
		return new JObject
		{
			["Embeddings"] = new JArray(Embeddings),
			["KutaScore"] = KutaScore,
			["Notes"] = Notes,
			["Male"] = Male.ToJson(),
			["Female"] = Female.ToJson(),
			["PredictionList"] = MatchPrediction.ToJsonList(PredictionList),
			["UserId"] = UserIdString,
			["Id"] = Id
		};
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	public static MatchReport FromXml(XElement reportXml)
	{
		if (reportXml == null)
		{
			return null;
		}
		if (reportXml?.Element("Male")?.Element("Person") == null)
		{
			return null;
		}
		string id = reportXml.Element("Id")?.Value ?? "0";
		string notes = reportXml.Element("Notes")?.Value ?? "Notes";
		Person male = Person.FromXml(reportXml.Element("Male")?.Element("Person"));
		Person female = Person.FromXml(reportXml.Element("Female")?.Element("Person"));
		double kutaScore = double.Parse(reportXml.Element("KutaScore")?.Value ?? "0");
		string[] userIdFromData = Tools.GetUserIdFromData(reportXml);
		List<MatchPrediction> predictionList = ParseXmlToPredictionList(reportXml.Element("PredictionList"));
		return new MatchReport(id, male, female, kutaScore, notes, predictionList, userIdFromData);
		static List<MatchPrediction> ParseXmlToPredictionList(XElement xmlData)
		{
			List<MatchPrediction> list = new List<MatchPrediction>();
			foreach (XElement item2 in xmlData.Elements())
			{
				MatchPredictionName name = Enum.Parse<MatchPredictionName>(item2.Element("Name")?.Value);
				EventNature nature = Enum.Parse<EventNature>(item2.Element("Nature")?.Value);
				string maleInfo = item2.Element("MaleInfo")?.Value;
				string femaleInfo = item2.Element("FemaleInfo")?.Value;
				string description = item2.Element("Description")?.Value;
				string info = item2.Element("Info")?.Value;
				MatchPrediction item = new MatchPrediction
				{
					Name = name,
					Nature = nature,
					MaleInfo = maleInfo,
					FemaleInfo = femaleInfo,
					Description = description,
					Info = info
				};
				list.Add(item);
			}
			return list;
		}
	}

	public static List<MatchReport> FromXml(IEnumerable<XElement> xmlList)
	{
		return xmlList.Select((XElement matchXml) => FromXml(matchXml)).ToList();
	}

	private XElement PredictionListToXml(List<MatchPrediction> predictionList)
	{
		XElement xElement = new XElement("PredictionList");
		foreach (MatchPrediction prediction in predictionList)
		{
			xElement.Add(prediction.ToXml());
		}
		return xElement;
	}

	private static MatchSummaryData GetSummary(double kutaScore)
	{
		if (kutaScore < 15.0)
		{
			string scoreColor = "#ff6969";
			string scoreSummary = "Not best, avoid if possible";
			return new MatchSummaryData("ic:round-heart-broken", scoreColor, scoreSummary);
		}
		if (kutaScore >= 15.0 && kutaScore < 30.0)
		{
			string scoreColor2 = "#ff6969";
			string scoreSummary2 = "Problematic relationship";
			return new MatchSummaryData("mdi:heart-flash", scoreColor2, scoreSummary2);
		}
		if (kutaScore >= 30.0 && kutaScore < 40.0)
		{
			string scoreColor3 = "#ff6969";
			string scoreSummary3 = "Better than the worst but not best";
			return new MatchSummaryData("mdi:heart-half-full", scoreColor3, scoreSummary3);
		}
		if (kutaScore >= 40.0 && kutaScore < 50.0)
		{
			string scoreColor4 = "#ff6969";
			string scoreSummary4 = "Average relationship, equal good and bad";
			return new MatchSummaryData("mdi:heart-half-full", scoreColor4, scoreSummary4);
		}
		if (kutaScore >= 50.0 && kutaScore < 60.0)
		{
			string scoreColor5 = "#00a702";
			string scoreSummary5 = "Better than average, more good than bad";
			return new MatchSummaryData("mdi:cards-heart", scoreColor5, scoreSummary5);
		}
		if (kutaScore >= 60.0 && kutaScore <= 80.0)
		{
			string scoreColor6 = "#00a702";
			string scoreSummary6 = "Near perfect match, overall happiness";
			return new MatchSummaryData("mdi:heart-plus", scoreColor6, scoreSummary6);
		}
		if (kutaScore > 80.0)
		{
			string scoreColor7 = "#00a702";
			string scoreSummary7 = "Best possible match, rare in real life";
			return new MatchSummaryData("bi:arrow-through-heart-fill", scoreColor7, scoreSummary7);
		}
		throw new Exception("END OF THE LINE");
	}
}
