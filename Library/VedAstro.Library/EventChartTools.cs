using System;
using System.Collections.Generic;

namespace VedAstro.Library;

public static class EventChartTools
{
	public static TimeRange AutoCalculateTimeRange(Person inputPerson, string timePreset, TimeSpan outputTimezone)
	{
		string birthDateMonthYear = inputPerson.BirthDateMonthYear;
		string stdDateTimeText = "00:00 " + birthDateMonthYear + " " + Tools.GetSystemTimezoneStr();
		Time birthTimeClient = new Time(stdDateTimeText, inputPerson.GetBirthLocation());
		GeoLocation birthLocation = inputPerson.GetBirthLocation();
		DateTimeOffset now = DateTimeOffset.Now.ToOffset(outputTimezone);
		now.ToString("dd/MM/yyyy zzz");
		now.AddDays(-1.0).ToString("dd/MM/yyyy zzz");
		string timePresetString = timePreset.ToLower();
		bool num = timePresetString.Contains("-");
		bool flag = timePresetString.Contains("to");
		if (num)
		{
			return ProcessPresetTypeB();
		}
		Time start;
		Time end;
		if (flag)
		{
			return ProcessPresetTypeC();
		}
		return ProcessPresetTypeA();
		TimeRange ProcessPresetTypeA()
		{
			List<string> list = Tools.SplitAlpha(timePresetString);
			bool num2 = int.TryParse(list[0], out var result);
			result = ((result < 1) ? 1 : result);
			string obj = (num2 ? list[1] : list[0]);
			string text = now.AddDays(-7.0).ToString("dd/MM/yyyy zzz");
			now.AddDays(-60.0).ToString("dd/MM/yyyy zzz");
			now.AddDays(-90.0).ToString("dd/MM/yyyy zzz");
			string text2 = now.AddDays(-182.0).ToString("dd/MM/yyyy zzz");
			string text3 = now.AddDays(-365.0).ToString("dd/MM/yyyy zzz");
			Time time = Time.NowSystem(birthLocation);
			switch (obj.ToLower())
			{
			case "hour":
			case "hours":
			{
				DateTimeOffset stdDateTime3 = now.AddHours(-1.0);
				DateTimeOffset stdDateTime4 = now.AddHours(result);
				start = new Time(stdDateTime3, birthLocation);
				end = new Time(stdDateTime4, birthLocation);
				return new TimeRange(start, end);
			}
			case "days":
			case "today":
			case "day":
			{
				double granularityHours = Tools.DaysToHours(result);
				DateTimeOffset stdDateTime = now.RemoveHours(granularityHours);
				DateTimeOffset stdDateTime2 = now.AddHours(granularityHours);
				start = new Time(stdDateTime, birthLocation);
				end = new Time(stdDateTime2, birthLocation);
				return new TimeRange(start, end);
			}
			case "week":
			case "weeks":
			{
				double granularityHours = Tools.WeeksToHours(result);
				start = time.RemoveHours(granularityHours);
				end = time.AddHours(granularityHours);
				return new TimeRange(start, end);
			}
			case "month":
			case "months":
			{
				double granularityHours = Tools.MonthsToHours(result);
				start = new Time("00:00 " + text, birthLocation);
				end = time.AddHours(granularityHours);
				return new TimeRange(start, end);
			}
			case "year":
			case "years":
			{
				double granularityHours = Tools.YearsToHours(result);
				start = new Time("00:00 " + text2, birthLocation);
				end = time.AddHours(granularityHours);
				return new TimeRange(start, end);
			}
			case "decade":
			case "decades":
			{
				double granularityHours = Tools.DecadesToHours(result);
				start = new Time("00:00 " + text3, birthLocation);
				end = time.AddHours(granularityHours);
				return new TimeRange(start, end);
			}
			case "age1to50":
				start = birthTimeClient;
				end = birthTimeClient.AddYears(50);
				return new TimeRange(start, end);
			case "age1to25":
				start = birthTimeClient;
				end = birthTimeClient.AddYears(25);
				return new TimeRange(start, end);
			case "age10to35":
				start = birthTimeClient.AddYears(10);
				end = birthTimeClient.AddYears(35);
				return new TimeRange(start, end);
			case "age25to50":
				start = birthTimeClient.AddYears(25);
				end = birthTimeClient.AddYears(50);
				return new TimeRange(start, end);
			case "age35to60":
				start = birthTimeClient.AddYears(35);
				end = birthTimeClient.AddYears(60);
				return new TimeRange(start, end);
			case "age50to75":
				start = birthTimeClient.AddYears(50);
				end = birthTimeClient.AddYears(75);
				return new TimeRange(start, end);
			case "age60to85":
				start = birthTimeClient.AddYears(60);
				end = birthTimeClient.AddYears(85);
				return new TimeRange(start, end);
			case "age75to100":
				start = birthTimeClient.AddYears(75);
				end = birthTimeClient.AddYears(100);
				return new TimeRange(start, end);
			case "age50to100":
				start = birthTimeClient.AddYears(50);
				end = birthTimeClient.AddYears(100);
				return new TimeRange(start, end);
			case "fulllife":
				start = birthTimeClient;
				end = birthTimeClient.AddYears(75);
				return new TimeRange(start, end);
			default:
				return new TimeRange(Time.Empty, Time.Empty);
			}
		}
		TimeRange ProcessPresetTypeB()
		{
			string[] array = timePresetString.Split('-');
			string text = array[0];
			string text2 = array[1];
			string text3 = now.ToString("zzz");
			start = new Time("00:00 01/01/" + text + " " + text3, birthLocation);
			end = new Time("00:00 31/12/" + text2 + " " + text3, birthLocation);
			return new TimeRange(start, end);
		}
		TimeRange ProcessPresetTypeC()
		{
			List<string> list = Tools.SplitAlpha(timePresetString);
			int num2 = int.Parse(list[1]);
			int years = int.Parse(list[3]);
			num2 = ((num2 != 1) ? num2 : 0);
			start = birthTimeClient.AddYears(num2);
			end = birthTimeClient.AddYears(years);
			return new TimeRange(start, end);
		}
	}
}
