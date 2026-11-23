using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace VedAstro.Library;

public static class EventsChartFactory
{
	public const int SingleRowHeight = 15;

	public const int SummaryRowHeight = 22;

	private const int MaxLifeEventCanvasHeight = 10000;

	private const int DescriptionBackgroundWidth = 100;

	public static int MaxYAxis;

	private const int WidthPerSlice = 1;

	public static List<Event> UnsortedEventList { get; set; }

	private static Dictionary<int, SumData> SummaryRowData { get; set; }

	public static string GenerateEventsChartSvg(EventsChart chartSpecs)
	{
		Person person = chartSpecs.Person;
		TimeRange timeRange = chartSpecs.TimeRange;
		double daysPerPixel = chartSpecs.DaysPerPixel;
		List<EventTag> eventTagList = chartSpecs.EventTagList;
		ChartOptions options = chartSpecs.Options;
		string svgHead = null;
		string contentHead = null;
		string timeHeader = null;
		string eventRows = null;
		string summaryRow = null;
		string nowLine = null;
		string contentTail = null;
		string cursorLine = null;
		string lifeEvents = null;
		string border = null;
		string jsCode = null;
		string svgTail = null;
		string svgDefinitions = null;
		GenerateComponents(person, timeRange.start, timeRange.end, daysPerPixel, eventTagList, options);
		return $" <!--MADE BY MACHINES FOR HUMAN EYES-->\r\n                    {svgHead}\r\n                        {svgDefinitions}\r\n\r\n                        <!--inside border-->\r\n                        {contentHead}\r\n                            {timeHeader}\r\n                            {eventRows}\r\n                            {lifeEvents}\r\n                            {summaryRow}\r\n                            {nowLine}\r\n                        {contentTail}\r\n\r\n                        <!--outside border-->\r\n                        {cursorLine}\r\n                        {border} <!--border painted last-->\r\n                        {jsCode} <!--place last-->\r\n                    {svgTail}\r\n                ";
		void GenerateComponents(Person inputPerson, Time startTime, Time endTime, double num2, List<EventTag> inputedEventTags, ChartOptions summaryOptions)
		{
			string value = "transparent";
			string text = Tools.GenerateId();
			double num = Tools.DaysToHours(num2);
			List<Time> timeListFromRange = Time.GetTimeListFromRange(startTime, endTime, num);
			int value2 = timeListFromRange.Count + 10;
			int headerY = 0;
			UnsortedEventList = EventManager.CalculateEvents(num, startTime, endTime, inputPerson, inputedEventTags);
			timeHeader = GenerateTimeHeaderRow(timeListFromRange, num2, 1, ref headerY);
			eventRows = GenerateEventRows(num, inputPerson, timeListFromRange, summaryOptions, ref headerY);
			int padding = 1;
			summaryRow = GenerateSummaryRow(SummaryRowData, 22, 15, padding, ref headerY);
			nowLine = MakeNowLine(startTime, headerY, timeListFromRange);
			lifeEvents = GetLifeEventLinesSvg(inputPerson, headerY, startTime, timeListFromRange);
			border = GetBorderSvg(timeListFromRange, headerY);
			cursorLine = GetTimeCursorLine(headerY);
			MaxYAxis = ((headerY > MaxYAxis) ? headerY : MaxYAxis);
			int value3 = MaxYAxis + 80;
			string value4 = $"\r\n                width:{value2}px;\r\n                font-family:Calibri;\r\n                height:{value3}px;\r\n                background:{value};";
			string birthTimeString = inputPerson.BirthTimeString;
			svgHead = $"<svg birthtime=\"{birthTimeString}\" birthlocation=\"{inputPerson.GetBirthLocation().Name()}\" class=\"EventChartHolder\" id=\"{text}\" style=\"{value4}\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">";
			jsCode = GetJsCodeSvg(text);
			contentHead = $"<g class=\"EventChartContent\" transform=\"matrix(1, 0, 0, 1, {2}, {2})\">";
			svgTail = "</svg>";
			contentTail = "</g>";
			svgDefinitions = "\r\n                        <defs>\r\n                            <filter id=\"glow\">\r\n                                <feGaussianBlur in=\"SourceAlpha\" stdDeviation=\"1\" result=\"blur\" />\r\n                                <feFlood flood-color=\"white\" flood-opacity=\"1\" result=\"color\" />\r\n                                <feComposite in=\"color\" in2=\"blur\" operator=\"in\" result=\"blur\" />\r\n                                <feMerge>\r\n                                    <feMergeNode in=\"blur\" />\r\n                                    <feMergeNode in=\"SourceGraphic\" />\r\n                                </feMerge>\r\n                            </filter>\r\n                        </defs>";
		}
	}

	public static EventsChart GenerateEventsChart(Person foundPerson, TimeRange timeRange, double daysPerPixel, List<EventTag> eventTags, ChartOptions summaryOptions)
	{
		EventsChart eventsChart = new EventsChart(Tools.GenerateId(), "", foundPerson, timeRange, daysPerPixel, eventTags, summaryOptions);
		string contentSvg = GenerateEventsChartSvg(eventsChart);
		eventsChart.ContentSvg = contentSvg;
		return eventsChart;
	}

	public static string WrapSvgElements(string svgClass, string combinedSvgString, int svgWidth, int svgTotalHeight, string randomId, string svgBackgroundColor = "#f0f9ff")
	{
		int value = svgWidth + 10;
		return $"<svg class=\"{svgClass}\" id=\"{randomId}\" style=\"width:{value}px;height:{svgTotalHeight}px;background:{svgBackgroundColor};\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">{combinedSvgString}</svg>";
	}

	private static string GetJsCodeSvg(string randomId)
	{
		return string.Concat(string.Concat(string.Concat("" + "<script href=\"https://code.jquery.com/jquery-3.6.3.min.js\" />", "<script href=\"https://cdn.jsdelivr.net/npm/@svgdotjs/svg.js@3.0/dist/svg.min.js\" />"), "<script href=\"https://www.vedastro.org/js/VedAstro.js\" />"), "\r\n\t                    <script type=\"text/ecmascript\">\r\n\t\t                    <![CDATA[\r\n\r\n                               //START THE BEAST\r\n\t\t                       var index = new EventsChart(\"", randomId, "\");\r\n\t\t\t                ]]>\r\n\t                    </script>\r\n                            ");
	}

	private static string GetBorderSvg(List<Time> timeSlices, int svgTotalHeight)
	{
		int value = timeSlices.Count + 2;
		int value2 = 3;
		svgTotalHeight += 10;
		return $"<rect class=\"EventChartBorder\" rx=\"{value2}\" width=\"{value}\" height=\"{svgTotalHeight}\" style=\"stroke-width: 2; fill: none; paint-order: stroke; stroke:#333;\"></rect>";
	}

	private static string MakeNowLine(Time startTime, int verticalYAxis, List<Time> timeSlices)
	{
		int num = verticalYAxis + 2;
		DateTimeOffset stdTimeNowAtOffset = startTime.StdTimeNowAtOffset;
		int linePosition = GetLinePosition(timeSlices, stdTimeNowAtOffset);
		bool hideOnLoad = linePosition == 0 || linePosition == timeSlices.Count - 1;
		return GetNowLine(num + 6, linePosition, hideOnLoad);
	}

	private static string GetColor(EventNature? eventNature)
	{
		return GetColor(eventNature.ToString());
	}

	public static string GetColor(double value, double min = -2.0, double max = 2.0)
	{
		if (value < min || value > max)
		{
			throw new ArgumentOutOfRangeException("value", "Value must be within the range of min and max.");
		}
		double num = (value - min) / (max - min);
		int value2 = (int)(255.0 * Math.Max(0.0, 1.0 - num));
		int value3 = (int)(255.0 * Math.Max(0.0, num));
		int value4 = 0;
		return $"#{value2:X2}{value3:X2}{value4:X2}";
	}

	private static string GetColor(string nature)
	{
		return nature switch
		{
			"Good" => "#00FF00", 
			"Neutral" => "#D3D3D3", 
			"Bad" => "#FF0000", 
			_ => throw new Exception("Invalid Nature: " + nature), 
		};
	}

	private static string GetSummaryColor(double totalNature, double minValue, double maxValue)
	{
		string text;
		if (totalNature >= 0.0)
		{
			int num = (int)totalNature.Remap(0.0, maxValue, 0.0, 255.0);
			if (num <= 10)
			{
				return "#FFFFFF";
			}
			if (num >= 220)
			{
				return "#00DD00";
			}
			num = 255 - num;
			text = $"{num:X}";
			return "#" + text + "FF" + text;
		}
		int num2 = (int)totalNature.Remap(minValue, 0.0, 0.0, 255.0);
		if (num2 <= 10)
		{
			return "#DD0000";
		}
		if (num2 >= 220)
		{
			return "#FFFFFF";
		}
		text = $"{num2:X}";
		return "#FF" + text + text;
	}

	private static string GenerateLifeEventLine(LifeEvent lifeEvent, int lineHeight, DateTimeOffset lifeEvtTime, int positionX, out int totalHeight)
	{
		string text = ShortenName(lifeEvent.Name, 14);
		int num = lineHeight + 7;
		int value = num + 2;
		string value2 = "-7.5";
		int num2 = 15;
		bool flag = lifeEvent.Weight == "Major";
		string value3 = (((lifeEvent.Weight == "Normal") | flag) ? "" : "display: none;");
		bool flag2 = !string.IsNullOrEmpty(lifeEvent.Description);
		string value4 = ((flag & flag2) ? "" : "display:none;");
		string value5 = StringToSvgTextBox(lifeEvent.Description, out var boxHeightPx);
		double num3 = GetTextWidthPx(text) + 14.0;
		int num4 = 82;
		double value6 = (flag ? ((double)num4) : num3);
		int num5 = boxHeightPx + 5;
		totalHeight = (flag ? num5 : 0) + num2;
		string value7 = $"\r\n                                <!-- POINTER LINE -->\r\n                                <rect class=\"vertical-line\" y=\"-2\" fill=\"#1E1EEA\" width=\"2\" height=\"{value}\"></rect>\r\n\r\n                                <!-- EVENT ICON LABEL -->\r\n                                <g transform=\"translate({value2},{num})\">\r\n                                    <g class=\"name-label\" style=\" cursor: pointer; \" >\r\n                                        <!-- EVENT NAME-->\r\n                                        <g transform=\"translate(18,0)\" style=\"{value3}\">\r\n\t\t\t\t\t\t                    <rect class=\"background\" x=\"0\" y=\"0\" style=\"fill: blue; opacity: 0.8;\" width=\"{value6}\" height=\"{num2}\" rx=\"2\" ry=\"2\" />\r\n\t\t\t\t\t\t                    <text class=\"event-name\" x=\"3\" y=\"11\" style=\"fill:#FFFFFF; font-size:12px;\">{text}</text>\r\n\t\t\t\t\t                    </g>\r\n\r\n                                        <!-- EVENT ICON-->\r\n\t\t\t\t                        <g class=\"nature-icon\" transform=\"translate(8,8)\">\r\n                                            <rect class=\"background\" fill=\"{GetColor(lifeEvent.Nature)}\" x=\"-7.5\" y=\"-8\" width=\"15\" height=\"15\" rx=\"2\" ry=\"2\"/>\r\n\t\t\t\t\t                        <path d=\"M2-0.2H0.7C0.5-0.2,0.3,0,0.3,0.2v1.3c0,0.2,0.2,0.4,0.4,0.4H2c0.2,0,0.4-0.2,0.4-0.4V0.2C2.5,0,2.3-0.2,2-0.2z M2-4.5v0.4 h-3.6v-0.4c0-0.2-0.2-0.4-0.4-0.4c-0.2,0-0.4,0.2-0.4,0.4v0.4h-0.4c-0.5,0-0.9,0.4-0.9,0.9v6.1c0,0.5,0.4,0.9,0.9,0.9h6.3 c0.5,0,0.9-0.4,0.9-0.9v-6.1c0-0.5-0.4-0.9-0.9-0.9H3.1v-0.4c0-0.2-0.2-0.4-0.4-0.4S2-4.8,2-4.5z M2.9,2.9h-5.4 c-0.2,0-0.4-0.2-0.4-0.4v-4.4h6.3v4.4C3.4,2.7,3.2,2.9,2.9,2.9z\"/>\r\n\t\t\t\t                        </g>\r\n                                    </g>\r\n\r\n                                    <!-- DESCRIPTION -->\r\n\t\t                            <g class=\"description-label\" style=\"{value4}\" transform=\"translate(0,{17})\">\r\n                                        <rect class=\"background\" style=\"fill: blue; opacity: 0.8;\" width=\"{100}\" height=\"{num5}\" rx=\"2\" ry=\"2\"/>\r\n                                        <text transform=\"translate(2,11)\">\r\n                                            {value5}\r\n\t\t\t                            </text>\r\n\t\t                            </g>\r\n                                </g>\r\n                                ";
		return $"<g eventname=\"{lifeEvent.Name}\" eventweight=\"{lifeEvent.Weight}\" class=\"LifeEventLines\" stdtime=\"{lifeEvtTime:dd/MM/yyyy}\" \r\n                              transform=\"translate({positionX}, 0)\">{value7}</g>";
	}

	private static string ShortenName(string rawInput, int nameCharLimit)
	{
		string text = rawInput;
		if (rawInput.Length > nameCharLimit)
		{
			text = text.Substring(0, nameCharLimit);
			text += "...";
		}
		return text;
	}

	private static double GetTextWidthPx(string textInput)
	{
		SizeF sizeF;
		using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
		{
			sizeF = graphics.MeasureString(textInput, new Font("Calibri", 10f, FontStyle.Regular, GraphicsUnit.Pixel));
		}
		return Math.Round(sizeF.Width);
	}

	private static string StringToSvgTextBox(string inputStr, out int boxHeightPx)
	{
		inputStr = ShortenName(inputStr, 44);
		List<string> list = (from x in (from rawStr in Tools.SplitByCharCount(inputStr, 22)
				select HttpUtility.HtmlEncode(rawStr)).ToList()
			select x.Trim()).ToList();
		if (list.Any() && list.Last() == "...")
		{
			list.RemoveAt(list.Count - 1);
			List<string> list2 = list;
			list2[list2.Count - 1] += "...";
		}
		string text = "";
		int num = 0;
		foreach (string item in list)
		{
			string text2 = $"<tspan x=\"0\" y=\"{num}\" fill=\"#FFFFFF\" font-size=\"10\">{item}</tspan>";
			text += text2;
			num += 12;
		}
		boxHeightPx = num;
		return text;
	}

	private static string GetLifeEventLinesSvg(Person person, int verticalYAxis, Time startTime, List<Time> timeSlices)
	{
		int num = timeSlices.Count + 1000;
		bool[,] virtualSpace = new bool[num, 10000];
		int num2 = verticalYAxis + 9;
		TimeSpan offset = startTime.GetStdDateTimeOffset().Offset;
		List<LifeEvent> lifeEventList = person.LifeEventList;
		lifeEventList.Sort((LifeEvent x, LifeEvent y) => x.CompareTo(y));
		List<string> list = new List<string>();
		foreach (LifeEvent item in lifeEventList)
		{
			DateTimeOffset stdDateTimeOffset = item.StartTime.GetStdDateTimeOffset();
			DateTimeOffset inputTime = stdDateTimeOffset.ToOffset(offset);
			int linePosition = GetLinePosition(timeSlices, inputTime);
			if (linePosition != 0 && !(item.Weight == "Minor"))
			{
				int num3 = GetRowNumber(linePosition);
				int num4 = num3 + num2;
				string text = GenerateLifeEventLine(item, num4, stdDateTimeOffset, linePosition, out var totalHeight);
				MarkRowNumber(linePosition, num3, 100, totalHeight, 15, 15);
				MaxYAxis = ((num4 > MaxYAxis) ? num4 : MaxYAxis);
				while (num3 > list.Count - 1)
				{
					list.Add("");
				}
				list[num3] += text;
			}
		}
		string text2 = "";
		for (int num5 = list.Count - 1; num5 >= 0; num5--)
		{
			string value = list[num5];
			string text3 = $"<g id=\"row{num5}\">{value}</g>";
			text2 += text3;
		}
		return $"<g id=\"LifeEventLinesHolder\" transform=\"matrix(1, 0, 0, 1, {2}, {2})\">{text2}</g>";
		int GetRowNumber(int columnIndex)
		{
			for (int i = 0; i < 10000; i++)
			{
				if (!virtualSpace[columnIndex, i])
				{
					return i;
				}
			}
			throw new Exception("End of Virtual Rows!");
		}
		void MarkRowNumber(int startCol, int startRow, int widthPx, int heightPx, int verticalPadding, int horizontalPadding)
		{
			int num6 = startCol + widthPx + horizontalPadding;
			int num7 = startRow + heightPx + verticalPadding;
			for (int i = startCol; i <= num6; i++)
			{
				for (int j = startRow; j <= num7; j++)
				{
					virtualSpace[i, j] = true;
				}
			}
		}
	}

	private static string GetTimeCursorLine(int verticalYAxis)
	{
		int num = verticalYAxis + 8;
		return $"\r\n                        <g id=\"CursorLine\" x=\"0\" y=\"0\">\r\n                            <!--place where asset icons are stored-->\r\n                            <g id=\"CursorLineLegendIcons\" style=\"display:none;\">\r\n                                <circle id=\"CursorLineBadIcon\" cx=\"6.82\" cy=\"7.573\" r=\"4.907\" fill=\"red\"></circle>\r\n                                <circle id=\"CursorLineGoodIcon\" cx=\"6.82\" cy=\"7.573\" r=\"4.907\" fill=\"green\"></circle>\r\n                                <g id=\"CursorLineClockIcon\" fill=\"#fff\" transform=\"matrix(0.5, 0, 0, 0.5, 2, 3)\" width=\"12\" height=\"12\">\r\n\t\t\t\t                    <path d=\"M10 0a10 10 0 1 0 10 10A10 10 0 0 0 10 0zm2.5 14.5L9 11V4h2v6l3 3z\"/>\r\n\t\t\t                    </g>\r\n                                <path id=\"CursorLineSumIcon\" transform=\"matrix(0.045, 0, 0, 0.045, -14, -4)\" fill=\"#fff\" d=\"M437 122c-15 2-26 5-38 10-38 16-67 51-75 91-4 17-4 36 0 54 10 48 47 86 95 98 11 2 15 3 30 3s19-1 30-3c48-12 86-50 96-98 3-18 3-37 0-54-10-47-48-86-95-98-10-2-16-3-29-3h-14zm66 59c2 2 3 3 4 6s1 17 0 20c-2 7-11 9-15 2-1-2-1-3-1-7v-5h-37-37s8 11 18 23l21 25c1 2 1 5 1 7-1 1-10 13-21 26l-19 24c0 1 13 1 37 1h37v-5c0-6 1-9 5-11 5-2 11 1 11 8 1 1 1 6 1 10-1 7-1 8-2 10s-3 4-7 4h-52-50l-2-1c-4-3-5-7-3-11 0 0 11-14 24-29l22-28-22-28c-13-16-24-29-24-30-2-3-1-7 2-9 2-3 2-3 55-3h51l3 1z\" stroke=\"none\" fill-rule=\"nonzero\"/>\r\n                            </g>\r\n\r\n                            <g id=\"IBeam\">\r\n\t\t\t                    <rect width=\"20\" height=\"2\" style=\"fill:black;\" x=\"-9\" y=\"0\"></rect>\r\n\t\t\t                    <rect width=\"2\" height=\"{num}\" style=\"fill:#000000;\" x=\"0\" y=\"0\"></rect>\r\n\t\t\t                    <rect width=\"20\" height=\"2\" style=\"fill:black;\" x=\"-9\" y=\"{num - 2}\"></rect>\r\n\t\t                    </g>\r\n                            <!--TIME ROW-->\r\n\t\t                    <g id=\"TimeRowLegendTemplate\" transform=\"matrix(1, 0, 0, 1, 10, 26)\" style=\"display:none;\">\r\n                                <!--BACKGROUND-->\r\n                                <rect opacity=\"0.80\" fill=\"blue\" x=\"-1\" y=\"0\" width=\"160\" height=\"12\" rx=\"2\" ry=\"2\"></rect>\r\n\t\t\t                    <!--TIME-->\r\n                                <text fill=\"#FFFFFF\" font-size=\"11\" font-weight=\"100\" x=\"14\" y=\"9\">Template</text>\r\n                                <!--CLOCK ICON-->\r\n                                <g fill=\"#fff\" transform=\"matrix(0.5, 0, 0, 0.5, 2, 1)\" width=\"12\" height=\"12\">\r\n\t\t\t\t                    <path d=\"M10 0a10 10 0 1 0 10 10A10 10 0 0 0 10 0zm2.5 14.5L9 11V4h2v6l3 3z\"></path>\r\n\t\t\t                    </g>\r\n                            </g>\r\n\r\n                            <!--cloned to CursorLineLegendClone -->\r\n\t\t                    <g id=\"CursorLineLegendTemplate\" transform=\"matrix(1, 0, 0, 1, 10, 26)\" style=\"display:none;\">\r\n                                <!--BACKGROUND-->\r\n                                <rect opacity=\"0.80\" fill=\"blue\" x=\"-1\" y=\"0\" width=\"160\" height=\"15\" rx=\"2\" ry=\"2\"></rect>\r\n\t\t\t                    <!--EVENT NAME-->\r\n                                <text class=\"event-name\" fill=\"#FFFFFF\" font-size=\"11\" font-weight=\"400\" x=\"14\" y=\"11\">Template</text>\r\n                                <!--ICON SET DYNAMIC BY JS-->\r\n                                <circle class=\"icon-holder\" cx=\"6.82\" cy=\"7.573\" r=\"4.907\" fill=\"grey\"></circle>\r\n                                <text class=\"nature-score\" fill=\"#FFFFFF\" font-size=\"7\" font-weight=\"100\" x=\"5.3\" y=\"9.9\"></text>\r\n                            </g>\r\n                            <!--place where dynamic event names are placed by JS-->\r\n                            <g id=\"CursorLineLegendHolder\" transform=\"matrix(1, 0, 0, 1, 0, 4)\"></g>\r\n                            <g id=\"CursorLineLegendDescriptionHolder\" transform=\"matrix(1, 0, 0, 1, 0, 0)\" style=\"display:none;\">\r\n\t\t\t                    <rect id=\"CursorLineLegendDescriptionBackground\" fill=\"#0096FF\" x=\"170\" y=\"11.244\" width=\"150\" height=\"0\" rx=\"2\" ry=\"2\"></rect>\r\n                                \r\n                                <!--PREDICTION INSERTED BY JS AT RUNTIME-->                                \r\n                                <g id=\"CursorLineLegendDescription\" transform=\"matrix(1, 0, 0, 1, 0, 19)\"></g>\r\n                                \r\n                                <!--ICON ABOVE PREDICTION BY LLM-->\r\n\t\t                        <g id=\"CursorLineLegendSpecializedSummary\" transform=\"matrix(0.8, 0, 0, 0.8, 174, 14)\">\r\n\t\t\t                        <g>\r\n\t\t\t\t                        <path fill=\"#CCCCCC\" d=\"M158,5c0.7,0,1.2,0.5,1.2,1.2s-0.6,1.2-1.2,1.2c-0.7,0-1.2-0.5-1.2-1.2S157.3,5,158,5 M158,0.4\r\n\t\t\t\t\t                        c3.4,0,6.1,2.6,6.1,5.8c0,2.3-1.4,4.3-3.5,5.3v3.9h-6.1v-2.5h-0.9c-1,0-1.7-0.7-1.7-1.7V8.7h-1.3c-0.4,0-0.6-0.4-0.4-0.7\r\n\t\t\t\t\t                        l1.7-2.1C152.1,2.8,154.8,0.4,158,0.4 M160.6,6.2c0-0.1,0-0.2-0.1-0.3l0.8-0.5c0,0,0.1-0.2,0-0.2L160.7,4c0-0.1-0.2-0.1-0.2-0.1\r\n\t\t\t\t\t                        l-0.9,0.4c-0.2-0.2-0.4-0.3-0.6-0.4L158.9,3c0-0.1-0.1-0.2-0.2-0.2h-1.4c-0.1,0-0.2,0-0.2,0.2L157,3.9c-0.2,0.1-0.4,0.2-0.6,0.3\r\n\t\t\t\t\t                        l-0.9-0.3c-0.1,0-0.1,0-0.2,0.1l-0.7,1.1c0,0.1,0,0.2,0,0.2l0.7,0.5c0,0.1,0,0.2,0,0.3c0,0.1,0,0.2,0,0.3l-0.7,0.5\r\n\t\t\t\t\t                        c-0.1,0-0.1,0.1,0,0.2l0.7,1.2c0.1,0.1,0.1,0.1,0.2,0.1l0.9-0.4c0.2,0.2,0.4,0.2,0.6,0.3l0.1,0.9c0,0.1,0.1,0.1,0.2,0.1h1.4\r\n\t\t\t\t\t                        c0.1,0,0.2-0.1,0.2-0.1l0.1-0.9c0.2-0.1,0.4-0.2,0.6-0.3l0.9,0.4c0.1,0,0.2,0,0.2-0.1l0.7-1.2c0-0.1,0-0.2,0-0.2l-0.8-0.3V6.2z\"\r\n\t\t\t\t\t                        />\r\n\t\t\t\t                        <text transform=\"matrix(1.25 0 0 1.25 151.0147 21.533)\" fill=\"#FFFFFF\" font-family=\"'Calibri'\" font-size=\"5px\">MIND</text>\r\n\t\t\t                        </g>\r\n\t\t\t                        <g>\r\n\t\t\t\t                        <g>\r\n\t\t\t\t\t                        <circle fill=\"#CCCCCC\" cx=\"128.7\" cy=\"1.5\" r=\"1.8\"/>\r\n\t\t\t\t\t                        <path fill=\"#CCCCCC\" d=\"M134.5,3.8H123c-0.5,0-0.9,0.4-0.9,0.9s0.4,0.9,0.9,0.9h3.2c0.2,0,0.5,0.1,0.6,0.5\r\n\t\t\t\t\t\t                        c0.2,0.4,0.1,1.3,0,1.9l-0.1,0.7l0,0l-1.1,6.2c-0.1,0.5,0.2,0.9,0.7,1s0.9-0.2,1-0.7l0,0l0.8-4.3c0,0,0.2-1,0.7-1s0.7,1,0.7,1\r\n\t\t\t\t\t\t                        l0.8,4.3c0.1,0.5,0.5,0.8,1,0.7s0.8-0.5,0.7-1l0,0l-1.1-6.2l0,0L130.6,8c-0.1-0.7-0.2-1.5,0-1.9c0.1-0.4,0.4-0.5,0.6-0.5h3.2\r\n\t\t\t\t\t\t                        c0.5,0,0.9-0.4,0.9-0.9C135.3,4.2,134.9,3.8,134.5,3.8L134.5,3.8z\"/>\r\n\t\t\t\t                        </g>\r\n\t\t\t\t                        <text transform=\"matrix(1.25 0 0 1.25 122.0824 21.533)\" fill=\"#FFFFFF\" font-family=\"'Calibri'\" font-size=\"5px\">BODY</text>\r\n\t\t\t                        </g>\r\n\t\t\t                        <g>\r\n\t\t\t\t                        <path fill=\"#CCCCCC\" d=\"M91.7,8.5C91.7,8.8,92,9,92.3,9c0.2,0,0.4-0.1,0.5-0.2l6.8-6.2c0.1-0.1,0.2-0.1,0.3-0.1\r\n\t\t\t\t\t                        c0.1,0,0.2,0,0.2,0.1l6.8,6.2c0.1,0.1,0.3,0.2,0.5,0.2c0.3,0,0.6-0.2,0.6-0.5c0-0.2-0.1-0.3-0.2-0.5l-2.4-2.2V1.7\r\n\t\t\t\t\t                        c0-0.3-0.2-0.5-0.5-0.5H104c-0.3,0-0.5,0.2-0.5,0.5v2.4l-2.8-2.5c-0.2-0.2-0.5-0.3-0.8-0.3s-0.6,0.1-0.8,0.3L92,8\r\n\t\t\t\t\t                        C91.8,8.1,91.7,8.3,91.7,8.5 M93.7,14.3c0,1,0.6,1.5,1.6,1.5h2.8v-4.9c0-0.3,0.2-0.5,0.5-0.5h2.5c0.3,0,0.5,0.2,0.5,0.5v4.9h2.8\r\n\t\t\t\t\t                        c1,0,1.6-0.6,1.6-1.5V9.2l-5.9-5.3c-0.1-0.1-0.2-0.1-0.2-0.1c-0.1,0-0.2,0-0.2,0.1l-5.9,5.3v5.1H93.7z\"/>\r\n\t\t\t\t                        <text transform=\"matrix(1.25 0 0 1.25 91.3778 21.6136)\" fill=\"#FFFFFF\" font-family=\"'Calibri'\" font-size=\"5px\">FAMILY</text>\r\n\t\t\t                        </g>\r\n\t\t\t                        <g>\r\n\t\t\t\t                        <path fill-rule=\"evenodd\" clip-rule=\"evenodd\" fill=\"#CCCCCC\" d=\"M70.5,1.3c-1.8,0-3.5,0.6-4.4,1.1c-0.1,0-0.2,0.1-0.2,0.1\r\n\t\t\t\t\t                        c-0.2,0.1-0.3,0.2-0.4,0.2l1.1,1.6l0.5,0.2c2,1,4.8,1,6.8,0l0.6-0.2l1.1-1.5c-0.2-0.1-0.4-0.3-0.7-0.4\r\n\t\t\t\t\t                        C73.9,1.9,72.3,1.3,70.5,1.3 M67.9,3.1c-0.4,0-0.8-0.1-1.1-0.2C67.7,2.4,69,2,70.5,2c1,0,2,0.2,2.8,0.5\r\n\t\t\t\t\t                        c-0.9,0.1-1.9,0.4-2.9,0.6C69.7,3.3,68.8,3.3,67.9,3.1 M74.3,5.2L74.3,5.2c-2.3,1.2-5.3,1.2-7.6,0h-0.1\r\n\t\t\t\t\t                        c-3.4,3.7-6,10.6,3.9,10.6S77.7,8.8,74.3,5.2 M70.1,8.5c-0.4,0-0.8,0.4-0.8,0.8c0,0.4,0.4,0.8,0.8,0.8V8.5z M70.9,7.7V7.3h-0.8\r\n\t\t\t\t\t                        v0.4c-0.9,0-1.6,0.7-1.6,1.6s0.7,1.6,1.6,1.6v1.6c-0.3,0-0.6-0.2-0.8-0.5c-0.1-0.2-0.3-0.3-0.5-0.3c-0.2,0.1-0.3,0.3-0.3,0.5\r\n\t\t\t\t\t                        l0,0c0.2,0.6,0.8,1.1,1.5,1.1v0.4h0.8v-0.4c0.9,0,1.6-0.7,1.6-1.6c0-0.9-0.7-1.6-1.6-1.6V8.5c0.3,0,0.6,0.2,0.8,0.5\r\n\t\t\t\t\t                        c0.1,0.2,0.3,0.3,0.5,0.3c0.3-0.1,0.4-0.3,0.3-0.5l0,0C72.2,8.1,71.6,7.7,70.9,7.7 M70.9,10.9v1.6c0.4,0,0.8-0.4,0.8-0.8\r\n\t\t\t\t\t                        C71.7,11.3,71.3,10.9,70.9,10.9\"/>\r\n\t\t\t\t                        <text transform=\"matrix(1.25 0 0 1.25 60.7608 21.533)\" fill=\"#FFFFFF\" font-family=\"'Calibri'\" font-size=\"5px\">MONEY</text>\r\n\t\t\t                        </g>\r\n\t\t\t                        <g>\r\n\t\t\t\t                        <path fill=\"#CCCCCC\" d=\"M38.2,1c0.1,0,0.2,0,0.2,0l6,1.2C44.8,2.3,45,2.6,45,2.9s-0.1,0.6-0.5,0.7l-2.3,0.5v1.7\r\n\t\t\t\t\t                        c0,2-1.7,3.8-3.9,3.8s-3.9-1.7-3.9-3.8V4.1l-1.5-0.2v1.9L33.4,8c0,0.1,0,0.2-0.1,0.4c-0.1,0.1-0.2,0.1-0.4,0.1h-1\r\n\t\t\t\t\t                        c-0.1,0-0.2-0.1-0.4-0.1c-0.1-0.1-0.1-0.2-0.1-0.4l0.5-2.2V3.5c-0.2-0.1-0.5-0.4-0.5-0.7s0.2-0.6,0.6-0.7L38.2,1z M35,10.6\r\n\t\t\t\t\t                        c0.4-0.1,0.6,0,0.9,0.2l2.2,2.2c0.2,0.2,0.5,0.2,0.7,0l2.1-2.2c0.2-0.2,0.6-0.4,0.9-0.2c2,0.6,3.4,2.4,3.4,4.5\r\n\t\t\t\t\t                        c0,0.5-0.4,0.9-1,0.9H32.5c-0.5,0-1-0.4-1-0.9C31.5,12.9,33,11.2,35,10.6\"/>\r\n\t\t\t\t                        <text transform=\"matrix(1.25 0 0 1.25 27.4842 21.5617)\" fill=\"#FFFFFF\" font-family=\"'Calibri'\" font-size=\"5px\">STUDIES</text>\r\n\t\t\t                        </g>\r\n\t\t\t                        <g>\r\n\t\t\t\t                        <path fill-rule=\"evenodd\" clip-rule=\"evenodd\" fill=\"#CCCCCC\" d=\"M4.5,16c-0.2,0.2-0.5,0.2-0.7,0c-0.1-0.1-0.1-0.2-0.1-0.4v-1.4\r\n\t\t\t\t\t                        H2.2c-0.2,0-0.5-0.2-0.5-0.5c0-0.1,0-0.2,0.1-0.4L3.2,12c0.2,0,0.3,0,0.5,0h1.7l2.9-2.9c0.2-0.2,0.5-0.2,0.7,0\r\n\t\t\t\t\t                        c0.2,0.2,0.2,0.5,0,0.7l-2.9,2.7v1.7c0,0.1,0,0.2-0.1,0.4L4.5,16z M16.7,4.5c0,0.2-0.1,0.5-0.5,0.5c-0.1,0-0.2,0-0.4-0.1l-1-1.1\r\n\t\t\t\t\t                        l-1,1C14,5,14.2,5.3,14.4,5.6C14.9,6.7,15,8,14.2,9.4c-0.7,1.4-2.3,3.1-4.8,4.8l-0.2,0.1L9,14.2c-0.6-0.4-1.2-0.8-1.8-1.3\r\n\t\t\t\t\t                        l2.4-2.4c0.6-0.6,0.6-1.4,0-2s-1.4-0.6-2,0l-2.4,2.4c-0.5-0.5-0.8-1-1.1-1.5C3.4,7.8,3.5,6.5,4,5.4c1-1.9,3.6-2.6,5.2-1.2\r\n\t\t\t\t\t                        c1.2-1,2.7-0.8,3.9-0.1L14.3,3l-1.1-1c-0.2-0.2-0.2-0.5,0-0.7c0.1-0.1,0.2-0.1,0.4-0.1h2.7c0.2,0,0.5,0.2,0.5,0.5v2.8H16.7z\"/>\r\n\t\t\t\t                        <text transform=\"matrix(1.25 0 0 1.25 2.662 21.5617)\" fill=\"#FFFFFF\" font-family=\"'Calibri'\" font-size=\"5px\">LOVE</text>\r\n\t\t\t                        </g>\r\n\t\t                        </g>\r\n\t\t                    </g>\r\n                       </g>\r\n                        ";
	}

	private static string GetNowLine(int positionX, int positionY, bool hideOnLoad = false)
	{
		string value = (hideOnLoad ? "style=\"display: none;\"" : "");
		positionX += 10;
		return $"\r\n                       <g id=\"NowVerticalLine\" x=\"0\" y=\"0\" {value} transform=\"matrix(1, 0, 0, 1, {positionY}, 0)\">\r\n\t\t                    <rect width=\"2\" height=\"{positionX}\" style=\" fill:blue; stroke-width:0.5px; stroke:#000;\"></rect>\r\n\t\t                    <g transform=\"matrix(2, 0, 0, 2, -12, {positionX})\">\r\n\t\t\t                    <rect style=\"fill: blue; opacity: 0.8; filter:url(#glow);\" x=\"0\" y=\"0\" width=\"13.5\" height=\"9.95\" rx=\"2.5\" ry=\"2.5\"></rect>\r\n\t\t\t                    <text style=\"fill:#FFF; font-size: 5px; filter:url(#glow);\" x=\"1.135\" y=\"6.367\">NOW</text>\r\n\t\t                    </g>\r\n\t                    </g>\r\n                        ";
	}

	private static int GetLinePosition(List<Time> timeSliceList, DateTimeOffset inputTime)
	{
		TimeSpan offset = timeSliceList[0].GetStdDateTimeOffset().Offset;
		inputTime = inputTime.ToOffset(offset);
		int nowHour = inputTime.Hour;
		int nowDay = inputTime.Day;
		int nowYear = inputTime.Year;
		int nowMonth = inputTime.Month;
		int num = GetNearestHour();
		if (num != 0)
		{
			return num;
		}
		int num2 = GetNearestDay();
		if (num2 != 0)
		{
			return num2;
		}
		int num3 = GetNearestMonth();
		if (num3 != 0)
		{
			return num3;
		}
		int num4 = GetNearestYear();
		if (num4 != 0)
		{
			return num4;
		}
		return 0;
		int GetNearestDay()
		{
			int num5 = 0;
			foreach (Time timeSlice in timeSliceList)
			{
				bool flag = timeSlice.StdDate() == nowDay;
				bool flag2 = timeSlice.StdYear() == nowYear;
				if ((timeSlice.StdMonth() == nowMonth) & flag2 & flag)
				{
					return num5;
				}
				num5++;
			}
			return 0;
		}
		int GetNearestHour()
		{
			int num5 = 0;
			foreach (Time timeSlice2 in timeSliceList)
			{
				bool flag = timeSlice2.GetStdDateTimeOffset().Hour == nowHour;
				bool num6 = timeSlice2.StdDate() == nowDay;
				bool flag2 = timeSlice2.StdYear() == nowYear;
				bool flag3 = timeSlice2.StdMonth() == nowMonth;
				if (num6 & flag & flag3 & flag2)
				{
					return num5;
				}
				num5++;
			}
			return 0;
		}
		int GetNearestMonth()
		{
			int num5 = 0;
			foreach (Time timeSlice3 in timeSliceList)
			{
				bool flag = timeSlice3.StdYear() == nowYear;
				if ((timeSlice3.StdMonth() == nowMonth) & flag)
				{
					return num5;
				}
				num5++;
			}
			return 0;
		}
		int GetNearestYear()
		{
			int num5 = 0;
			foreach (Time timeSlice4 in timeSliceList)
			{
				if (timeSlice4.StdYear() == nowYear)
				{
					return num5;
				}
				num5++;
			}
			return 0;
		}
	}

	private static string GenerateTimeHeaderRow(List<Time> timeSlices, double daysPerPixel, int _widthPerSlice, ref int headerY)
	{
		string text = "";
		int num = timeSlices[0].StdYear();
		int num2 = timeSlices.Last().StdYear() - num;
		List<Func<List<Time>, int, int, int, string>> list = new List<Func<List<Time>, int, int, int, string>>();
		bool flag = daysPerPixel <= 15.0;
		if (num2 >= 10 && !flag)
		{
			list.Add(GenerateDecadeRowSvg);
		}
		if (num2 >= 5 && num2 < 10)
		{
			list.Add(Generate5YearRowSvg);
		}
		if (flag)
		{
			list.Add(GenerateYearRowSvg);
		}
		if (daysPerPixel <= 1.3)
		{
			list.Add(GenerateMonthRowSvg);
		}
		if (daysPerPixel <= 0.07)
		{
			list.Add(GenerateDateRowSvg);
		}
		if (daysPerPixel <= 0.001)
		{
			list.Add(GenerateHourRowSvg);
		}
		int num3 = 2;
		int num4 = 11;
		foreach (Func<List<Time>, int, int, int, string> item in list)
		{
			text += item(timeSlices, headerY, 0, num4);
			headerY = headerY + num4 + num3;
		}
		return text;
		string Generate5YearRowSvg(List<Time> list2, int yAxis, int xAxis, int rowHeight)
		{
			string text2 = "";
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = list2[0].StdYear();
			int num10 = num9 + 5;
			foreach (Time item2 in list2)
			{
				bool flag2 = list2.IndexOf(item2) == list2.Count - 1;
				if (((num5 != item2.StdYear()) | flag2) && num10 == item2.StdYear())
				{
					num8 += num7;
					num7 = num6 * _widthPerSlice;
					int value = num7 / 2;
					string text3 = $"<g transform=\"matrix(1, 0, 0, 1, {num8}, 0)\"><rect fill=\"#0d6efd\" x=\"0\" y=\"0\" width=\"{num7}\" height=\"{rowHeight}\"  style=\"paint-order: stroke; stroke: rgb(255, 255, 255); stroke-opacity: 1; stroke-linejoin: round;\"/><text x=\"{value}\" y=\"{9}\" width=\"{num7}\" fill=\"white\" style=\"fill: rgb(255, 255, 255); font-size: 10px; font-weight: 700; text-anchor: middle; white-space: pre;\">{num9} - {num10}</text></g>";
					text2 += text3;
					num6 = 0;
					num9 = num10 + 1;
					num10 = num9 + 5;
				}
				num5 = item2.StdYear();
				num6++;
			}
			return $"<g transform=\"matrix(1, 0, 0, 1, {xAxis}, {yAxis})\">{text2}</g>";
		}
		string GenerateDateRowSvg(List<Time> list2, int yAxis, int xAxis, int rowHeight)
		{
			string text2 = "";
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			foreach (Time item3 in list2)
			{
				bool flag2 = list2.IndexOf(item3) == list2.Count - 1;
				if ((num5 != item3.StdDate()) | flag2)
				{
					if (num5 == 0)
					{
						num6 = 0;
					}
					else
					{
						num8 += num7;
						num7 = num6 * _widthPerSlice;
						int value = num7 / 2;
						string text3 = $"<g transform=\"matrix(1, 0, 0, 1, {num8}, 0)\"><rect fill=\"#0d6efd\" x=\"0\" y=\"0\" width=\"{num7}\" height=\"{rowHeight}\"  style=\"paint-order: stroke; stroke: rgb(255, 255, 255); stroke-opacity: 1; stroke-linejoin: round;\"/><text x=\"{value}\" y=\"{9}\" width=\"{num7}\" fill=\"white\" style=\"fill: rgb(255, 255, 255); font-size: 10px; font-weight: 700; text-anchor: middle; white-space: pre;\">{num5}</text></g>";
						text2 += text3;
						num6 = 0;
					}
				}
				num5 = item3.StdDate();
				num6++;
			}
			return $"<g transform=\"matrix(1, 0, 0, 1, {xAxis}, {yAxis})\">{text2}</g>";
		}
		string GenerateDecadeRowSvg(List<Time> list2, int yAxis, int xAxis, int rowHeight)
		{
			string text2 = "";
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = list2[0].StdYear();
			int num10 = num9 + 10;
			foreach (Time item4 in list2)
			{
				bool flag2 = list2.IndexOf(item4) == list2.Count - 1;
				if (((num5 != item4.StdYear()) | flag2) && num10 == item4.StdYear())
				{
					num8 += num7;
					num7 = num6 * _widthPerSlice;
					int value = num7 / 2;
					string text3 = $"<g transform=\"matrix(1, 0, 0, 1, {num8}, 0)\"><rect fill=\"#0d6efd\" x=\"0\" y=\"0\" width=\"{num7}\" height=\"{rowHeight}\"  style=\"paint-order: stroke; stroke: rgb(255, 255, 255); stroke-opacity: 1; stroke-linejoin: round;\"/><text x=\"{value}\" y=\"{9}\" width=\"{num7}\" fill=\"white\" style=\"fill: rgb(255, 255, 255); font-size: 10px; font-weight: 700; text-anchor: middle; white-space: pre;\">{num9} - {num10}</text></g>";
					text2 += text3;
					num6 = 0;
					num9 = num10 + 1;
					num10 = num9 + 10;
				}
				num5 = item4.StdYear();
				num6++;
			}
			return $"<g transform=\"matrix(1, 0, 0, 1, {xAxis}, {yAxis})\">{text2}</g>";
		}
		string GenerateHourRowSvg(List<Time> list2, int yAxis, int xAxis, int rowHeight)
		{
			string text2 = "";
			int num5 = -1;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			foreach (Time item5 in list2)
			{
				bool flag2 = list2.IndexOf(item5) == list2.Count - 1;
				if ((num5 != item5.StdHour()) | flag2)
				{
					if (num5 == -1)
					{
						num6 = 0;
					}
					else
					{
						num8 += num7;
						num7 = num6 * _widthPerSlice;
						int value = num7 / 2;
						string text3 = $"<g transform=\"matrix(1, 0, 0, 1, {num8}, 0)\"><rect fill=\"#0d6efd\" x=\"0\" y=\"0\" width=\"{num7}\" height=\"{rowHeight}\"  style=\"paint-order: stroke; stroke: rgb(255, 255, 255); stroke-opacity: 1; stroke-linejoin: round;\"/><text x=\"{value}\" y=\"{9}\" width=\"{num7}\" fill=\"white\" style=\"fill: rgb(255, 255, 255); font-size: 10px; font-weight: 700; text-anchor: middle; white-space: pre;\">{num5}</text></g>";
						text2 += text3;
						num6 = 0;
					}
				}
				num5 = item5.StdHour();
				num6++;
			}
			return $"<g transform=\"matrix(1, 0, 0, 1, {xAxis}, {yAxis})\">{text2}</g>";
		}
		string GenerateMonthRowSvg(List<Time> list2, int yAxis, int xAxis, int rowHeight)
		{
			string text2 = "";
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			foreach (Time item6 in list2)
			{
				bool flag2 = list2.IndexOf(item6) == list2.Count - 1;
				if ((num5 != item6.StdMonth()) | flag2)
				{
					if (num5 == 0)
					{
						num6 = 0;
					}
					else
					{
						num8 += num7;
						num7 = num6 * _widthPerSlice;
						int value = num7 / 2;
						string text3 = $"<g transform=\"matrix(1, 0, 0, 1, {num8}, 0)\"><rect fill=\"#0d6efd\" x=\"0\" y=\"0\" width=\"{num7}\" height=\"{rowHeight}\"  style=\"paint-order: stroke; stroke: rgb(255, 255, 255); stroke-opacity: 1; stroke-linejoin: round;\"/><text x=\"{value}\" y=\"{9}\" width=\"{num7}\" fill=\"white\" style=\"fill: rgb(255, 255, 255); font-size: 10px; font-weight: 700; text-anchor: middle; white-space: pre;\">{GetMonthName(num5)}</text></g>";
						text2 += text3;
						num6 = 0;
					}
				}
				num5 = item6.StdMonth();
				num6++;
			}
			return $"<g transform=\"matrix(1, 0, 0, 1, {xAxis}, {yAxis})\">{text2}</g>";
		}
		string GenerateYearRowSvg(List<Time> list2, int yAxis, int xAxis, int rowHeight)
		{
			string text2 = "";
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			foreach (Time item7 in list2)
			{
				bool flag2 = list2.IndexOf(item7) == list2.Count - 1;
				if ((num5 != item7.StdYear()) | flag2)
				{
					if (num5 == 0)
					{
						num6 = 0;
					}
					else
					{
						num8 += num7;
						num7 = num6 * _widthPerSlice;
						int value = num7 / 2;
						string text3 = $"<g transform=\"matrix(1, 0, 0, 1, {num8}, 0)\"><rect fill=\"#0d6efd\" x=\"0\" y=\"0\" width=\"{num7}\" height=\"{rowHeight}\"  style=\"paint-order: stroke; stroke: rgb(255, 255, 255); stroke-opacity: 1; stroke-linejoin: round;\"/><text x=\"{value}\" y=\"{9}\" width=\"{num7}\" fill=\"white\" style=\"fill: rgb(255, 255, 255); font-size: 10px; font-weight: 700; text-anchor: middle; white-space: pre;\">{num5}</text></g>";
						text2 += text3;
						num6 = 0;
					}
				}
				num5 = item7.StdYear();
				num6++;
			}
			return $"<g transform=\"matrix(1, 0, 0, 1, {xAxis}, {yAxis})\">{text2}</g>";
		}
		static string GetMonthName(int monthNum)
		{
			return monthNum switch
			{
				1 => "JAN", 
				2 => "FEB", 
				3 => "MAR", 
				4 => "APR", 
				5 => "MAY", 
				6 => "JUN", 
				7 => "JUL", 
				8 => "AUG", 
				9 => "SEP", 
				10 => "OCT", 
				11 => "NOV", 
				12 => "DEC", 
				_ => throw new Exception($"Invalid Month: {monthNum}"), 
			};
		}
	}

	private static string GenerateEventRows(double hoursPerPixel, Person inputPerson, List<Time> timeSlices, ChartOptions options, ref int yAxis)
	{
		List<Event> list = UnsortedEventList.OrderByDescending((Event x) => x.DurationMin).ToList();
		int value = list.RemoveAll((Event evt) => evt.DurationHour < hoursPerPixel * 0.85);
		Console.WriteLine($"!! REMOVED EVENT TOO SHORT COUNT : {value} !!");
		Console.WriteLine($"Number Of Events In Chart :{list.Count}");
		int num = 1;
		string text = "";
		if (list.Any())
		{
			SummaryRowData = new Dictionary<int, SumData>();
			text += GenerateMultipleRowSvg(list, timeSlices, yAxis, 0, options, out var finalHeight);
			yAxis = yAxis + finalHeight + num;
		}
		return text;
		string GenerateMultipleRowSvg(List<Event> eventList, List<Time> list2, int num9, int xAxis, ChartOptions summaryOptions, out int reference)
		{
			string text2 = "";
			int num2 = 0;
			int num3 = 0;
			int num4 = 1;
			int num5 = 0;
			int num6 = 0;
			Dictionary<int, EventName> dictionary = new Dictionary<int, EventName>();
			foreach (Time slice in list2)
			{
				List<Event> list3 = eventList.FindAll((Event tempEvent) => tempEvent.IsOccurredAtTime(slice));
				foreach (Event item in list3)
				{
					double num7 = 0.0;
					num7 = CalculateNatureScore(item, inputPerson, summaryOptions.SelectedAlgorithm);
					item.NatureScore = num7;
				}
				double maxValue = 0.0;
				double minValue = 0.0;
				if (list3.Any())
				{
					maxValue = list3.Aggregate((Event l, Event r) => (!(l.NatureScore > r.NatureScore)) ? r : l).NatureScore;
					minValue = list3.Aggregate((Event l, Event r) => (!(l.NatureScore < r.NatureScore)) ? r : l).NatureScore;
				}
				foreach (Event item2 in list3)
				{
					int num8 = num9 + num3;
					string value2 = ((dictionary.TryGetValue(num8, out var value3) && value3 != item2.Name) ? "black" : GetSummaryColor(item2.NatureScore, minValue, maxValue));
					dictionary[num8] = item2.Name;
					string text3 = $"<rect eventname=\"{item2?.FormattedName}\" eventdescription=\"{item2?.Description}\" naturescore=\"{item2?.NatureScore}\" mind=\"{item2?.SpecializedSummary.Mind}\" body=\"{item2?.SpecializedSummary.Body}\" family=\"{item2?.SpecializedSummary.Family}\" money=\"{item2?.SpecializedSummary.Money}\" studies=\"{item2?.SpecializedSummary.Studies}\" age=\"{inputPerson.GetAge(slice)}\" stdtime=\"{slice.GetStdDateTimeOffset().ToString("HH:mm dd/MM/yyyy zzz")}\" x=\"{num2}\" y=\"{num8}\" width=\"{1}\" height=\"{15}\" fill=\"{value2}\" />";
					text2 += text3;
					double num10 = (SummaryRowData.ContainsKey(num2) ? SummaryRowData[num2].NatureScore : 0.0);
					SumData value4 = new SumData
					{
						BirthTime = inputPerson.BirthTime,
						Planet = Tools.GetPlanetFromName(item2.FormattedName),
						NatureScore = item2.NatureScore + num10
					};
					SummaryRowData[num2] = value4;
					num3 += 15 + num4;
					num6++;
				}
				num2++;
				num3 = 0;
				int num11 = num6 * (15 + num4) - num4;
				int num12 = ((num6 > 1) ? num11 : 15);
				num5 = ((num12 > num5) ? num12 : num5);
				num6 = 0;
			}
			text2 = $"<g class=\"EventListHolder\" transform=\"matrix(1, 0, 0, 1, {xAxis}, 0)\">{text2}</g>";
			reference = num5;
			return text2;
		}
	}

	private static string GenerateSummaryRow(Dictionary<int, SumData> summaryRowData, int summaryRowHeight, int singleRowHeight, int padding, ref int yAxis)
	{
		double valueOrDefault = (summaryRowData?.Values?.Max((SumData x) => x.NatureScore)).GetValueOrDefault();
		double valueOrDefault2 = (summaryRowData?.Values?.Min((SumData x) => x.NatureScore)).GetValueOrDefault();
		double maxValue = valueOrDefault - valueOrDefault * 0.4;
		double minValue = valueOrDefault2 - valueOrDefault2 * 0.2;
		string text = "";
		string text2 = "";
		foreach (KeyValuePair<int, SumData> summaryRowDatum in summaryRowData)
		{
			int key = summaryRowDatum.Key;
			string summaryColor = GetSummaryColor(summaryRowDatum.Value.NatureScore, minValue, maxValue);
			string text3 = $"<rect x=\"{key}\" y=\"{yAxis}\" width=\"{1}\" height=\"{summaryRowHeight}\" fill=\"{summaryColor}\" />";
			text2 += text3;
		}
		text = text + "<g id=\"ColorRow\">" + text2 + "</g>";
		float value = yAxis - singleRowHeight - padding;
		text += $"\r\n                    <g id=\"SummaryLabel\" transform=\"matrix(1, 0, 0, 1, 0, {value})\">\r\n\t\t\t\t        <rect style=\"fill: blue; opacity: 0.80;\" x=\"-1\" y=\"0\" width=\"100\" height=\"15\" rx=\"2\" ry=\"2\"/>\r\n\t\t\t\t        <text style=\"fill:#FFFFFF; font-size:11px; font-weight:400;\" x=\"16\" y=\"11\">Smart Summary</text>\r\n\t\t\t\t        <path transform=\"matrix(0.045, 0, 0, 0.045, -14, -4)\" fill=\"#fff\" d=\"M437 122c-15 2-26 5-38 10-38 16-67 51-75 91-4 17-4 36 0 54 10 48 47 86 95 98 11 2 15 3 30 3s19-1 30-3c48-12 86-50 96-98 3-18 3-37 0-54-10-47-48-86-95-98-10-2-16-3-29-3h-14zm66 59c2 2 3 3 4 6s1 17 0 20c-2 7-11 9-15 2-1-2-1-3-1-7v-5h-37-37s8 11 18 23l21 25c1 2 1 5 1 7-1 1-10 13-21 26l-19 24c0 1 13 1 37 1h37v-5c0-6 1-9 5-11 5-2 11 1 11 8 1 1 1 6 1 10-1 7-1 8-2 10s-3 4-7 4h-52-50l-2-1c-4-3-5-7-3-11 0 0 11-14 24-29l22-28-22-28c-13-16-24-29-24-30-2-3-1-7 2-9 2-3 2-3 55-3h51l3 1z\" stroke=\"none\" fill-rule=\"nonzero\"/>\r\n\t\t\t        </g>";
		text = "<g id=\"SummaryRow\">" + text + "</g>";
		yAxis += 15;
		return text;
	}

	private static double CalculateNatureScore(Event foundEvent, Person person, List<AlgorithmFuncs> selectedAlgorithm)
	{
		double num = 0.0;
		foreach (AlgorithmFuncs item in selectedAlgorithm)
		{
			num += item(foundEvent, person);
		}
		return Math.Round(num, 2);
	}

	public static object GenerateEventsChartForChat(Time birthTime, TimeRange timeRangeParsed)
	{
		throw new NotImplementedException();
	}
}
