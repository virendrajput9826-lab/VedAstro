using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;

namespace VedAstro.Library;

public class MLTable
{
	public static readonly MLTable Empty = new MLTable(new List<MLTableRow>(), new List<OpenAPIMetadata>());

	private static int _progressCounter;

	private List<MLTableRow> RowData { get; set; } = new List<MLTableRow>();

	private List<Time> TimeList { get; set; } = new List<Time>();

	private List<OpenAPIMetadata?> ColumnData { get; set; } = new List<OpenAPIMetadata>();

	public int RowsCount => RowData.Count;

	public int ColumnsCount { get; set; }

	public static int ProgressCounter
	{
		get
		{
			return _progressCounter;
		}
		set
		{
			_progressCounter = value;
			OnProgressCounterChanged?.Invoke(null, value.ToString());
		}
	}

	public static event EventHandler<string> OnProgressCounterChanged;

	private MLTable(List<MLTableRow> rowData, List<OpenAPIMetadata> columnData)
	{
		RowData = rowData;
		ColumnData = columnData;
	}

	public static MLTable FromData(List<Time> timeSlices, List<OpenAPIMetadata> columnData)
	{
		List<MLTableRow> list = new List<MLTableRow>();
		List<OpenAPIMetadata> list2 = columnData.ToList();
		for (int i = 0; i < timeSlices.Count; i++)
		{
			Time time = timeSlices[i];
			List<APIFunctionResult> list3 = new List<APIFunctionResult>();
			foreach (OpenAPIMetadata columnDatum in columnData)
			{
				List<object> param = columnDatum.SelectedParams.ToList();
				param.Add(time);
				List<APIFunctionResult> list4 = AutoCalculator.ExecuteCals(new List<MethodInfo> { columnDatum.MethodInfo }, param.ToArray());
				list4.ForEach(delegate(APIFunctionResult aR)
				{
					aR.AddSelectedParams(param);
				});
				foreach (APIFunctionResult item2 in list4)
				{
					if (item2?.Result is List<APIFunctionResult> list5)
					{
						list3.AddRange(list5);
						if (i != 0)
						{
							continue;
						}
						list2.Remove(columnDatum);
						foreach (APIFunctionResult item3 in list5)
						{
							OpenAPIMetadata item = new OpenAPIMetadata
							{
								Name = item3.Name,
								SelectedParams = item2.SelectedParams
							};
							list2.Add(item);
						}
					}
					else
					{
						list3.AddRange(list4);
					}
				}
			}
			list.Add(new MLTableRow(time, list3));
		}
		return new MLTable(list, list2);
	}

	public static async Task<List<Time>> GetTimeListFromExcel(Stream inputedFile)
	{
		List<DateTimeOffset> foundRawTimeList = await ExtractTimeColumnFromExcel(inputedFile);
		List<GeoLocation> foundGeoLocationList = await ExtractLocationColumnFromExcel(inputedFile);
		return foundRawTimeList.Select((DateTimeOffset dateTimeOffset) => new Time(dateTimeOffset, foundGeoLocationList[foundRawTimeList.IndexOf(dateTimeOffset)])).ToList();
		static async Task<List<GeoLocation>> ExtractLocationColumnFromExcel(Stream excelBinary)
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			List<GeoLocation> geoLocations = new List<GeoLocation>();
			int geoLocationColumnIndex = -1;
			excelBinary.Position = 0L;
			using (MemoryStream excelFileStream = new MemoryStream())
			{
				await excelBinary.CopyToAsync(excelFileStream);
				excelFileStream.Position = 0L;
				using ExcelPackage package = new ExcelPackage(excelFileStream);
				ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
				int rowsInSheet = worksheet.Dimension.Rows;
				for (int rowIndex = 2; rowIndex <= rowsInSheet; rowIndex++)
				{
					if (geoLocationColumnIndex == -1)
					{
						geoLocationColumnIndex = await FindGeoLocationColumnIndex(worksheet, rowIndex);
					}
					if (geoLocationColumnIndex != -1)
					{
						string text = worksheet.Cells[rowIndex, geoLocationColumnIndex].Value?.ToString();
						if (string.IsNullOrWhiteSpace(text))
						{
							break;
						}
						(bool, GeoLocation) tuple = await GeoLocation.TryParse(text);
						if (tuple.Item1)
						{
							geoLocations.Add(tuple.Item2);
							ProgressCounter++;
						}
					}
				}
			}
			return geoLocations;
		}
		static async Task<List<DateTimeOffset>> ExtractTimeColumnFromExcel(Stream excelBinary)
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			List<DateTimeOffset> timeList = new List<DateTimeOffset>();
			int timeColumnIndex = -1;
			MemoryStream excelFileStream = new MemoryStream();
			await excelBinary.CopyToAsync(excelFileStream);
			excelFileStream.Position = 0L;
			using (ExcelPackage excelPackage = new ExcelPackage(excelFileStream))
			{
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
				int rows = excelWorksheet.Dimension.Rows;
				for (int i = 2; i <= rows; i++)
				{
					if (timeColumnIndex == -1)
					{
						for (int j = 1; j <= excelWorksheet.Dimension.Columns; j++)
						{
							if (Time.TryParseStd(excelWorksheet.Cells[i, j].Value?.ToString(), out var _))
							{
								timeColumnIndex = j;
								break;
							}
						}
					}
					if (timeColumnIndex != -1)
					{
						string text = excelWorksheet.Cells[i, timeColumnIndex].Value?.ToString();
						if (string.IsNullOrWhiteSpace(text))
						{
							break;
						}
						if (Time.TryParseStd(text, out var parsed2))
						{
							timeList.Add(parsed2);
							ProgressCounter++;
						}
					}
				}
			}
			return timeList;
		}
		static async Task<int> FindGeoLocationColumnIndex(ExcelWorksheet worksheet, int rowIndex)
		{
			for (int i = 1; i <= worksheet.Dimension.Columns; i++)
			{
				string text = worksheet.Cells[1, i].Value?.ToString();
				if (text != null && text.ToLower().Contains("location"))
				{
					return i;
				}
			}
			return -1;
		}
	}

	public static async Task<List<Time>> GetTimeListFromCsv(Stream inputedFile)
	{
		using (MemoryStream copiedInputedFile = new MemoryStream())
		{
			inputedFile.CopyTo(copiedInputedFile);
			copiedInputedFile.Position = 0L;
			List<DateTimeOffset> foundRawTimeList = await ExtractTimeColumnFromCsv(copiedInputedFile.Clone());
			copiedInputedFile.Position = 0L;
			List<GeoLocation> foundGeoLocationList = await ExtractLocationColumnFromCsv(copiedInputedFile.Clone());
			return foundRawTimeList.Select((DateTimeOffset dateTimeOffset, int index) => new Time(dateTimeOffset, foundGeoLocationList[index])).ToList();
		}
		static async Task<List<GeoLocation>> ExtractLocationColumnFromCsv(Stream csvStream)
		{
			csvStream.Position = 0L;
			using StreamReader reader = new StreamReader(csvStream);
			bool headersFound = false;
			int geoLocationColumnIndex = -1;
			List<GeoLocation> geoLocations = new List<GeoLocation>();
			string text;
			while ((text = await reader.ReadLineAsync()) != null)
			{
				string[] array = text.Split(',');
				if (!headersFound)
				{
					geoLocationColumnIndex = Array.FindIndex(array, (string v) => v.ToLower().Contains("location") || v.ToLower().Contains("latitude") || v.ToLower().Contains("longitude"));
					headersFound = true;
				}
				else if (geoLocationColumnIndex >= 0 && geoLocationColumnIndex < array.Length)
				{
					(bool, GeoLocation) tuple = await GeoLocation.TryParse(array[geoLocationColumnIndex]);
					if (tuple.Item1)
					{
						geoLocations.Add(tuple.Item2);
						ProgressCounter++;
					}
				}
			}
			return geoLocations;
		}
		static async Task<List<DateTimeOffset>> ExtractTimeColumnFromCsv(Stream csvStream)
		{
			using StreamReader reader = new StreamReader(csvStream);
			bool headersFound = false;
			int timeColumnIndex = -1;
			ConcurrentBag<DateTimeOffset> timeList = new ConcurrentBag<DateTimeOffset>();
			ParallelOptions options = new ParallelOptions
			{
				MaxDegreeOfParallelism = Environment.ProcessorCount * 2
			};
			string text;
			while ((text = await reader.ReadLineAsync()) != null)
			{
				List<string> list = (from v in text.Split(',', StringSplitOptions.RemoveEmptyEntries)
					select v.Trim()).ToList();
				if (!headersFound)
				{
					timeColumnIndex = list.FindLastIndex((string x) => x.Equals("Date", StringComparison.OrdinalIgnoreCase));
					headersFound = true;
				}
				else if (timeColumnIndex >= 0 && timeColumnIndex < list.Count)
				{
					Parallel.ForEach(list, options, delegate(string value)
					{
						if (DateTimeOffset.TryParseExact(value, "yyyy-MM-dd HH:mm:ss zzzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
						{
							timeList.Add(result);
						}
					});
				}
			}
			return timeList.OrderByDescending((DateTimeOffset t) => t).TakeWhile((DateTimeOffset _, int i) => i <= 5).Reverse()
				.ToList();
		}
	}

	public static async Task<T> GenerateMLTable<T>(List<Time> timeList, List<OpenAPIMetadata> columnNameList, string selectedFormat)
	{
		MLTable mLTable = FromData(timeList, columnNameList);
		return selectedFormat switch
		{
			"HTML" => (T)(object)mLTable.ToHtml(), 
			"CSV" => (T)(object)mLTable.ToCSV(), 
			"JSON" => (T)(object)mLTable.ToJson(), 
			"EXCEL" => (T)(object)mLTable.ToExcel(), 
			_ => throw new Exception("END OF LINE!"), 
		};
	}

	public string ToCSV()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Time,");
		foreach (OpenAPIMetadata columnDatum in ColumnData)
		{
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder2);
			handler.AppendFormatted(columnDatum.MLTableName(columnDatum.SelectedPlanet));
			handler.AppendLiteral(",");
			stringBuilder3.Append(ref handler);
		}
		stringBuilder.AppendLine();
		foreach (MLTableRow rowDatum in RowData)
		{
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder2);
			handler.AppendFormatted(rowDatum.Time);
			handler.AppendLiteral(",");
			stringBuilder4.Append(ref handler);
			foreach (APIFunctionResult dataColumn in rowDatum.DataColumns)
			{
				stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder5 = stringBuilder2;
				handler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder2);
				handler.AppendFormatted(dataColumn.ResultAsString());
				handler.AppendLiteral(",");
				stringBuilder5.Append(ref handler);
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	public JObject ToJson()
	{
		JObject jObject = new JObject();
		JArray jArray = new JArray();
		JArray jArray2 = new JArray();
		foreach (OpenAPIMetadata columnDatum in ColumnData)
		{
			jArray.Add(columnDatum.MLTableName(columnDatum.SelectedPlanet));
		}
		foreach (MLTableRow rowDatum in RowData)
		{
			JObject jObject2 = new JObject();
			jObject2.Add("Time", rowDatum.Time.ToJson());
			foreach (APIFunctionResult dataColumn in rowDatum.DataColumns)
			{
				jObject2.Add(dataColumn.ResultAsString(), dataColumn.ResultAsString());
			}
			jArray2.Add(jObject2);
		}
		jObject.Add("Columns", jArray);
		jObject.Add("Rows", jArray2);
		return jObject;
	}

	public async Task<byte[]> ToParquet()
	{
		throw new NotImplementedException();
	}

	public byte[] ToExcel()
	{
		ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
		using ExcelPackage excelPackage = new ExcelPackage();
		ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
		excelWorksheet.Cells[1, 1].Value = "Time";
		int num = 2;
		foreach (OpenAPIMetadata columnDatum in ColumnData)
		{
			excelWorksheet.Cells[1, num].Value = columnDatum.MLTableName(columnDatum.SelectedPlanet);
			num++;
		}
		int num2 = 2;
		foreach (MLTableRow rowDatum in RowData)
		{
			excelWorksheet.Cells[num2, 1].Value = rowDatum.Time;
			int num3 = 2;
			foreach (APIFunctionResult dataColumn in rowDatum.DataColumns)
			{
				excelWorksheet.Cells[num2, num3].Value = dataColumn.ResultAsString();
				num3++;
			}
			num2++;
		}
		return excelPackage.GetAsByteArray();
	}

	public byte[] ToHDF5()
	{
		throw new NotImplementedException();
	}

	public string ToHtml()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("<table id=\"GeneratedTable\" class=\"table table-bordered table-hover\">");
		stringBuilder.AppendLine("<thead class=\"table-dark\">");
		stringBuilder.AppendLine("<tr>");
		stringBuilder.AppendLine("<th>Time</th>");
		foreach (OpenAPIMetadata columnDatum in ColumnData)
		{
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
			handler.AppendLiteral("<th>");
			handler.AppendFormatted(columnDatum.MLTableName(columnDatum.SelectedPlanet));
			handler.AppendLiteral("</th>");
			stringBuilder3.AppendLine(ref handler);
		}
		stringBuilder.AppendLine("</tr>");
		stringBuilder.AppendLine("</thead>");
		stringBuilder.AppendLine("<tbody>");
		foreach (MLTableRow rowDatum in RowData)
		{
			stringBuilder.AppendLine("<tr>");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
			handler.AppendLiteral("<td>");
			handler.AppendFormatted(rowDatum.Time);
			handler.AppendLiteral("</td>");
			stringBuilder4.AppendLine(ref handler);
			foreach (APIFunctionResult dataColumn in rowDatum.DataColumns)
			{
				stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder5 = stringBuilder2;
				handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
				handler.AppendLiteral("<td>");
				handler.AppendFormatted(dataColumn.ResultAsString());
				handler.AppendLiteral("</td>");
				stringBuilder5.AppendLine(ref handler);
			}
			stringBuilder.AppendLine("</tr>");
		}
		stringBuilder.AppendLine("</tbody>");
		stringBuilder.AppendLine("</table>");
		return stringBuilder.ToString();
	}
}
