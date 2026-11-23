using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class EventsChart
{
	public static EventsChart Empty = new EventsChart("Empty", "Empty", Person.Empty, TimeRange.Empty, 0.0, new List<EventTag>(), ChartOptions.Empty);

	public string ChartId { get; set; }

	public string ContentSvg { get; set; }

	public Person Person { get; }

	public double DaysPerPixel { get; }

	public List<EventTag> EventTagList { get; set; }

	public TimeRange TimeRange { get; set; }

	public ChartOptions Options { get; set; }

	public EventsChart(string chartId, string contentSvg, Person person, TimeRange timeRange, double daysPerPixel, List<EventTag> eventTagList, ChartOptions options)
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

	public string GetEventsChartSignature()
	{
		string stdDateMonthYearText = TimeRange.end.StdDateMonthYearText;
		string stdDateMonthYearText2 = TimeRange.start.StdDateMonthYearText;
		return new string((from ch in $"{Person.Id}-{"EventsChart"}-{stdDateMonthYearText2}-{stdDateMonthYearText}-{DaysPerPixel}-{(Ayanamsa)Calculate.Ayanamsa}-{Tools.ListToString(EventTagList, "-")}-{Options}".Replace(" ", "")
			where !Enumerable.Contains(Path.GetInvalidFileNameChars(), ch)
			select ch).ToArray());
	}

	public static async Task<EventsChart> FromCacheName(string chartName)
	{
		throw new NotImplementedException();
	}

	public static async Task<EventsChart> FromJson(JObject? requestJson)
	{
		Person personById = Tools.GetPersonById(requestJson["PersonId"]?.Value<string>() ?? "101");
		List<EventTag> eventTagList = EventTagExtensions.FromJsonList(requestJson["EventTagList"]);
		Time start = Time.FromJson(requestJson["StartTime"]);
		Time end = Time.FromJson(requestJson["EndTime"]);
		double daysPerPixel = requestJson["DaysPerPixel"].Value<double>();
		ChartOptions options = ChartOptions.FromJson(requestJson["ChartOptions"]);
		return new EventsChart(Tools.GenerateId(), "", personById, new TimeRange(start, end), daysPerPixel, eventTagList, options);
	}

	public static EventsChart FromData(Person inputPerson, TimeRange timeRange, List<EventTag> inputedEventTags, double daysPerPixelRaw, ChartOptions options)
	{
		double num = 30.0;
		num = ((daysPerPixelRaw != 0.0) ? daysPerPixelRaw : num);
		return new EventsChart(Tools.GenerateId(), "", inputPerson, timeRange, num, inputedEventTags, options);
	}

	public static async Task<EventsChart> FromUrl(string url)
	{
		string[] parts = url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		return url.Contains("/TimePreset/") ? processType() : processType2();
		EventsChart processType()
		{
			Person personById = Tools.GetPersonById(parts[0]);
			personById.GetBirthLocation();
			TimeSpan systemTimezone = Tools.GetSystemTimezone();
			TimeRange timeRange = EventChartTools.AutoCalculateTimeRange(personById, parts[2], systemTimezone);
			Time start = timeRange.start;
			Time end = timeRange.end;
			double daysPerPixel = double.Parse(parts[4]);
			List<EventTag> eventTagList = EventTagExtensions.FromString(parts[5]);
			ChartOptions options = ChartOptions.FromUrl(parts[6]);
			if (url.Contains("Ayanamsa"))
			{
				Calculate.Ayanamsa = (int)Tools.EnumFromUrl(parts[^2] + "/" + parts[^1]);
			}
			return new EventsChart(Tools.GenerateId(), "", personById, new TimeRange(start, end), daysPerPixel, eventTagList, options);
		}
		EventsChart processType2()
		{
			Person personById = Tools.GetPersonById(parts[0]);
			GeoLocation birthLocation = personById.GetBirthLocation();
			var anon = new
			{
				hhmmStr = parts[2],
				dateStr = parts[3],
				monthStr = parts[4],
				yearStr = parts[5],
				offsetStr = parts[11]
			};
			string stdDateTimeText = $"{anon.hhmmStr} {anon.dateStr}/{anon.monthStr}/{anon.yearStr} {anon.offsetStr}";
			Time start = new Time(stdDateTimeText, birthLocation);
			var anon2 = new
			{
				hhmmStr = parts[7],
				dateStr = parts[8],
				monthStr = parts[9],
				yearStr = parts[10],
				offsetStr = parts[11]
			};
			string stdDateTimeText2 = $"{anon2.hhmmStr} {anon2.dateStr}/{anon2.monthStr}/{anon2.yearStr} {anon2.offsetStr}";
			Time end = new Time(stdDateTimeText2, birthLocation);
			double daysPerPixel = double.Parse(parts[12]);
			List<EventTag> eventTagList = EventTagExtensions.FromString(parts[13]);
			ChartOptions options = ChartOptions.FromUrl(parts[14]);
			if (url.Contains("Ayanamsa"))
			{
				Calculate.Ayanamsa = (int)Tools.EnumFromUrl(parts[^2] + "/" + parts[^1]);
			}
			return new EventsChart(Tools.GenerateId(), "", personById, new TimeRange(start, end), daysPerPixel, eventTagList, options);
		}
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
