using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class DasaChart
{
	public static DasaChart Empty = new DasaChart("Empty", "Empty", Person.Empty, TimeRange.Empty, 0.0, new List<EventTag>(), ChartOptions.Empty);

	public string ChartId { get; set; }

	public string ContentSvg { get; set; }

	public Person Person { get; }

	public double DaysPerPixel { get; }

	public List<EventTag> EventTagList { get; set; }

	public TimeRange TimeRange { get; set; }

	public ChartOptions Options { get; set; }

	public DasaChart(string chartId, string contentSvg, Person person, TimeRange timeRange, double daysPerPixel, List<EventTag> eventTagList, ChartOptions options)
	{
		ChartId = chartId;
		ContentSvg = contentSvg;
		Person = person;
		EventTagList = eventTagList;
		TimeRange = timeRange;
		DaysPerPixel = daysPerPixel;
		Options = options;
	}

	public object GetFormattedName(string personName)
	{
		int value = TimeRange.start.StdYear();
		int value2 = TimeRange.start.StdMonth();
		int value3 = TimeRange.end.StdYear();
		int value4 = TimeRange.end.StdMonth();
		return $"{personName} - {value2}/{value} to {value4}/{value3}";
	}

	public string GetDasaChartSignature()
	{
		string stdDateMonthYearText = TimeRange.end.StdDateMonthYearText;
		string stdDateMonthYearText2 = TimeRange.start.StdDateMonthYearText;
		return new string($"{"DasaChart"}-{Person.Id}-{stdDateMonthYearText2}-{stdDateMonthYearText}-{DaysPerPixel}-{(Ayanamsa)Calculate.Ayanamsa}-{Tools.ListToString(EventTagList, "-")}-{Options}".Where((char ch) => !Enumerable.Contains(Path.GetInvalidFileNameChars(), ch)).ToArray());
	}

	public static async Task<DasaChart> FromJson(JObject? requestJson)
	{
		Person personById = Tools.GetPersonById(requestJson["PersonId"]?.Value<string>() ?? "101");
		List<EventTag> eventTagList = EventTagExtensions.FromJsonList(requestJson["EventTagList"]);
		Time start = Time.FromJson(requestJson["StartTime"]);
		Time end = Time.FromJson(requestJson["EndTime"]);
		double daysPerPixel = requestJson["DaysPerPixel"].Value<double>();
		ChartOptions options = ChartOptions.FromJson(requestJson["ChartOptions"]);
		return new DasaChart(Tools.GenerateId(), "", personById, new TimeRange(start, end), daysPerPixel, eventTagList, options);
	}

	public static DasaChart FromData(Person inputPerson, TimeRange timeRange, List<EventTag> inputedEventTags, int maxWidth, ChartOptions options)
	{
		double dayPerPixel = GetDayPerPixel(timeRange, maxWidth);
		double num = 30.0;
		num = ((dayPerPixel != 0.0) ? dayPerPixel : num);
		return new DasaChart(Tools.GenerateId(), "", inputPerson, timeRange, num, inputedEventTags, options);
	}

	public static async Task<DasaChart> FromUrl(string url)
	{
		string[] array = url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		Person personById = Tools.GetPersonById(array[0]);
		GeoLocation birthLocation = personById.GetBirthLocation();
		var anon = new
		{
			hhmmStr = array[2],
			dateStr = array[3],
			monthStr = array[4],
			yearStr = array[5],
			offsetStr = array[11]
		};
		string stdDateTimeText = $"{anon.hhmmStr} {anon.dateStr}/{anon.monthStr}/{anon.yearStr} {anon.offsetStr}";
		Time start = new Time(stdDateTimeText, birthLocation);
		var anon2 = new
		{
			hhmmStr = array[7],
			dateStr = array[8],
			monthStr = array[9],
			yearStr = array[10],
			offsetStr = array[11]
		};
		string stdDateTimeText2 = $"{anon2.hhmmStr} {anon2.dateStr}/{anon2.monthStr}/{anon2.yearStr} {anon2.offsetStr}";
		Time end = new Time(stdDateTimeText2, birthLocation);
		double daysPerPixel = double.Parse(array[12]);
		List<EventTag> eventTagList = EventTagExtensions.FromString(array[13]);
		ChartOptions options = ChartOptions.FromUrl(array[14]);
		if (url.Contains("Ayanamsa"))
		{
			Calculate.Ayanamsa = (int)Tools.EnumFromUrl(array[^2] + "/" + array[^1]);
		}
		return new DasaChart(Tools.GenerateId(), "", personById, new TimeRange(start, end), daysPerPixel, eventTagList, options);
	}

	public string ToUrl()
	{
		string text = "";
		text = text + "/" + Person.Id;
		Time start = TimeRange.start;
		text = text + "/Start/" + start.StdHourMinuteText + "/" + start.StdDateMonthYearText;
		Time end = TimeRange.end;
		text += $"/End/{end.StdHourMinuteText}/{end.StdDateMonthYearText}/{end.StdTimezoneText}";
		text += $"/{DaysPerPixel}";
		text = text + "/" + string.Join(",", EventTagList);
		return text + "/" + string.Join(",", Options.SelectedAlgorithm.Select((AlgorithmFuncs func) => func.Method.Name));
	}

	public JObject ToJson()
	{
		return new JObject
		{
			["PersonId"] = Person.Id,
			["StartTime"] = TimeRange.start.ToJson(),
			["EndTime"] = TimeRange.end.ToJson(),
			["DaysPerPixel"] = DaysPerPixel,
			["EventTagList"] = EventTagExtensions.ToJsonList(EventTagList),
			["ChartOptions"] = Options.ToJson()
		};
	}

	public static double GetDayPerPixel(TimeRange timeRange, int maxWidth)
	{
		return Math.Round(timeRange.daysBetween / (double)maxWidth, 3);
	}

	public override int GetHashCode()
	{
		return Tools.GetStringHashCode(ChartId);
	}
}
