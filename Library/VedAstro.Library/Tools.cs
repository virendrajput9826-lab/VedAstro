using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using HtmlAgilityPack;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using Svg;
using SwissEphNet;

namespace VedAstro.Library;

public static class Tools
{
	public const string BlobContainerName = "vedastro-site-data";

	private static readonly Random Random = new Random();

	public static XElement TimeStampSystemXml => new XElement("TimeStamp", GetNowSystemTimeSecondsText());

	public static XElement TimeStampServerXml => new XElement("TimeStampServer", GetNowServerTimeSecondsText());

	public static bool IsSecureConnection(this HttpRequestData incomingRequest)
	{
		if (incomingRequest.Url.Port == 443 || incomingRequest.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return false;
	}

	public static string ExtractHostAddress(this HttpRequestData incomingRequest)
	{
		string text = "http";
		if (incomingRequest.IsSecureConnection())
		{
			text = "https";
		}
		incomingRequest.Headers.ToDictionary<KeyValuePair<string, IEnumerable<string>>, string, IEnumerable<string>>((KeyValuePair<string, IEnumerable<string>> x) => x.Key, (KeyValuePair<string, IEnumerable<string>> x) => x.Value, StringComparer.Ordinal).TryGetValue("Host", out var value);
		string text2 = value?.FirstOrDefault() ?? "no host";
		return text + "://" + text2;
	}

	public static HttpResponseData SendPassHeaderToCaller(BlobClient fileBlobClient, HttpRequestData req, string mimeType)
	{
		HttpResponseData httpResponseData = req.CreateResponse(HttpStatusCode.OK);
		httpResponseData.Headers.Add("Call-Status", "Pass");
		httpResponseData.Headers.Add("Access-Control-Expose-Headers", "Call-Status");
		httpResponseData.Headers.Add("Content-Type", mimeType);
		httpResponseData.Body = fileBlobClient.OpenRead(0L);
		return httpResponseData;
	}

	public static async Task<HttpResponseData> SendPassHeaderToCaller(string dataToSend, HttpRequestData req, string mimeType)
	{
		HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
		response.Headers.Add("Call-Status", "Pass");
		response.Headers.Add("Access-Control-Expose-Headers", "Call-Status");
		response.Headers.Add("Content-Type", mimeType);
		await response.WriteStringAsync(dataToSend);
		return response;
	}

	public static string GetCallerId(string userId, string visitorId)
	{
		if (userId != "101")
		{
			return userId;
		}
		return visitorId;
	}

	public static IPAddress GetCallerIp(this HttpRequestData req)
	{
		Dictionary<string, IEnumerable<string>> dictionary = req.Headers.ToDictionary<KeyValuePair<string, IEnumerable<string>>, string, IEnumerable<string>>((KeyValuePair<string, IEnumerable<string>> x) => x.Key, (KeyValuePair<string, IEnumerable<string>> x) => x.Value, StringComparer.Ordinal);
		string key = "x-forwarded-for";
		string key2 = "x-azure-clientip";
		IPAddress address = null;
		if ((dictionary.ContainsKey(key) || dictionary.ContainsKey(key2)) && !IPAddress.TryParse(dictionary[key]?.FirstOrDefault()?.Split(new char[1] { ',' }).FirstOrDefault()?.Split(new char[1] { ':' }).FirstOrDefault(), out address))
		{
			IPAddress.TryParse(dictionary[key]?.FirstOrDefault()?.Split(new char[1] { ',' }).FirstOrDefault()?.Split(new char[1] { ':' }).FirstOrDefault(), out address);
		}
		return address ?? IPAddress.None;
	}

	public static async Task<string> DownloadToText(BlobClient blobClient)
	{
		if ((await blobClient.ExistsAsync()).Value)
		{
			return ((BlobDownloadResult)(await blobClient.DownloadContentAsync())).Content.ToString();
		}
		throw new Exception("No File in Cloud : " + blobClient.Name);
	}

	public static async Task<string> BlobClientToString(BlobClient blobClient)
	{
		try
		{
			return await DownloadToText(blobClient);
		}
		catch (Exception)
		{
			throw new Exception("Azure Storage Failure : " + blobClient.Name);
		}
	}

	public static IPAddress GetCallerIp(this HttpRequestMessage request)
	{
		IPAddress address = null;
		if (request.Headers.TryGetValues("X-Forwarded-For", out IEnumerable<string> values))
		{
			IPAddress.TryParse(values.FirstOrDefault().Split(new char[1] { ',' }).FirstOrDefault()
				.Split(new char[1] { ':' })
				.FirstOrDefault(), out address);
		}
		return address;
	}

	public static DateTimeOffset RemoveHours(this DateTimeOffset value, double hours)
	{
		return value.AddHours(0.0 - hours);
	}

	public static Stream Clone(this Stream stream)
	{
		long position = stream.Position;
		MemoryStream memoryStream = new MemoryStream();
		stream.CopyTo(memoryStream);
		memoryStream.Seek(position, SeekOrigin.Begin);
		return memoryStream;
	}

	public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
	{
		TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
		using (cancellationToken.Register(delegate(object? s)
		{
			((TaskCompletionSource<bool>)s).TrySetResult(result: true);
		}, taskCompletionSource))
		{
			if (task != await Task.WhenAny(task, taskCompletionSource.Task))
			{
				throw new OperationCanceledException(cancellationToken);
			}
		}
		return await task;
	}

	public static JObject ToJson(this MethodInfo methodInfo)
	{
		return new JObject
		{
			["Name"] = methodInfo.Name,
			["DeclaringType"] = methodInfo.DeclaringType?.FullName,
			["Parameters"] = new JArray(from p in methodInfo.GetParameters()
				select new JObject
				{
					["Name"] = p.Name,
					["ParameterType"] = p.ParameterType.FullName
				})
		};
	}

	public static MethodInfo MethodInfoFromJson(JObject jObject)
	{
		string name = (string?)jObject["Name"];
		Type? type = Type.GetType((string?)jObject["DeclaringType"]);
		Type[] types = ((JArray)jObject["Parameters"]).Select((JToken jt) => Type.GetType((string?)jt["ParameterType"])).ToArray();
		return type?.GetMethod(name, types);
	}

	public static string ListToCSV(List<MLTableRow> tableRowList)
	{
		if (tableRowList == null || !tableRowList.Any())
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		IEnumerable<string> values = tableRowList[0].DataColumns.Select((APIFunctionResult result) => result.MLTableName("NOTHH!"));
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
		handler.AppendLiteral("Time,");
		handler.AppendFormatted(string.Join(",", values));
		stringBuilder2.AppendLine(ref handler);
		foreach (MLTableRow tableRow in tableRowList)
		{
			string item = QuoteValue(tableRow.Time);
			List<string> list = new List<string> { item };
			list.AddRange(tableRow.DataColumns.Select((APIFunctionResult d) => QuoteValue(d.ResultAsString())));
			stringBuilder.AppendLine(string.Join(",", list));
		}
		return stringBuilder.ToString();
	}

	public static byte[] ListToExcel(List<MLTableRow> tableRowList)
	{
		ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
		using ExcelPackage excelPackage = new ExcelPackage();
		ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
		if (tableRowList == null || !tableRowList.Any())
		{
			return excelPackage.GetAsByteArray();
		}
		IEnumerable<string> collection = tableRowList[0].DataColumns.Select((APIFunctionResult result) => result.MLTableName("NOT YET"));
		List<string> list = new List<string> { "Time" };
		list.AddRange(collection);
		excelWorksheet.Cells["A1"].LoadFromArrays(new List<object[]> { list.Cast<object>().ToArray() });
		for (int num = 0; num < tableRowList.Count; num++)
		{
			MLTableRow mLTableRow = tableRowList[num];
			List<string> list2 = new List<string> { mLTableRow.Time.ToString() };
			list2.AddRange(mLTableRow.DataColumns.Select((APIFunctionResult d) => d.ResultAsString()));
			excelWorksheet.Cells[num + 2, 1].LoadFromArrays(new List<object[]> { list2.Cast<object>().ToArray() });
		}
		return excelPackage.GetAsByteArray();
	}

	public static string ConvertJsonToHtmlTable(JToken jObject)
	{
		List<Dictionary<string, string>> list = jObject.ToObject<List<Dictionary<string, string>>>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<table>");
		stringBuilder.Append("<tr>");
		foreach (string key in list[0].Keys)
		{
			stringBuilder.AppendFormat("<th>{0}</th>", key);
		}
		stringBuilder.Append("</tr>");
		foreach (Dictionary<string, string> item in list)
		{
			stringBuilder.Append("<tr>");
			foreach (string value in item.Values)
			{
				stringBuilder.AppendFormat("<td>{0}</td>", value);
			}
			stringBuilder.Append("</tr>");
		}
		stringBuilder.Append("</table>");
		return stringBuilder.ToString();
	}

	public static JObject ConvertHtmlTableToJson(string htmlTable)
	{
		HtmlDocument htmlDocument = new HtmlDocument();
		htmlDocument.LoadHtml(htmlTable);
		HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//table");
		IEnumerable<HtmlNode> enumerable = htmlNode.SelectNodes("tr").Skip(1);
		HtmlNode htmlNode2 = htmlNode.SelectSingleNode("tr");
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		foreach (HtmlNode item in enumerable)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			HtmlNodeCollection htmlNodeCollection = item.SelectNodes("td");
			for (int i = 0; i < htmlNodeCollection.Count; i++)
			{
				string innerText = htmlNodeCollection[i].InnerText;
				string innerText2 = htmlNode2.SelectNodes("th")[i].InnerText;
				dictionary.Add(innerText2, innerText);
			}
			list.Add(dictionary);
		}
		return JObject.FromObject(list);
	}

	public static void Print(dynamic input)
	{
		Console.WriteLine(((JToken)Tools.AnyToJSON("", input)).ToString());
	}

	public static double GetTextWidthPx(string textInput)
	{
		SizeF sizeF;
		using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
		{
			sizeF = graphics.MeasureString(textInput, new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Pixel));
		}
		return Math.Round(sizeF.Width);
	}

	public static async Task<string> GetStringFileHttp(string url)
	{
		using HttpClient client = new HttpClient();
		client.Timeout = Timeout.InfiniteTimeSpan;
		HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
		return await (await client.SendAsync(request, CancellationToken.None)).Content.ReadAsStringAsync();
	}

	public static async Task<byte[]> GetFileHttp(string url)
	{
		using HttpClient client = new HttpClient();
		client.Timeout = Timeout.InfiniteTimeSpan;
		HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
		using HttpResponseMessage response = await client.SendAsync(request, CancellationToken.None);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsByteArrayAsync();
	}

	public static async Task<string> GetSvgIconHttp(string svgFileUrl, double width, double height)
	{
		string text = await GetStringFileHttp(svgFileUrl);
		if (!string.IsNullOrEmpty(text))
		{
			SvgDocument svgDocument = SvgDocument.FromSvg<SvgDocument>(text);
			svgDocument.Height = (float)height;
			svgDocument.Width = (float)width;
			return svgDocument.GetXML().Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "").Replace("<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">", "");
		}
		return "";
	}

	public static Image Svg2Png(string svg, int width, int height)
	{
		MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(svg));
		SvgDocument.EnsureSystemIsGdiPlusCapable();
		return SvgDocument.Open<SvgDocument>(stream).Draw(width, height);
	}

	public static byte[] ImageToByte2(Image img)
	{
		using MemoryStream memoryStream = new MemoryStream();
		img.Save(memoryStream, ImageFormat.Png);
		return memoryStream.ToArray();
	}

	public static T GetValueOrNull<T>(this List<T> list, int index)
	{
		if (index >= 0 && index < list.Count)
		{
			return list[index];
		}
		return default(T);
	}

	public static int GetLastDay(string monthYearText)
	{
		string[] array = monthYearText.Split('/');
		return DateTime.DaysInMonth(month: int.Parse(array[0]), year: int.Parse(array[1]));
	}

	public static async Task<Time> ParseTime(string locationName, string hhmmStr, string dateStr, string monthStr, string yearStr)
	{
		string pattern = "^-?\\d+(\\.\\d+)?,\\-?\\d+(\\.\\d+)?$";
		GeoLocation geoLocation;
		if (Regex.IsMatch(locationName, pattern))
		{
			string[] array = locationName.Split(',');
			double latitude = Convert.ToDouble(array[0]);
			double longitude = Convert.ToDouble(array[1]);
			geoLocation = new GeoLocation(locationName, longitude, latitude);
		}
		else
		{
			geoLocation = (await AddressToGeoLocation(locationName)).Payload;
		}
		Time.TryParseStd($"{hhmmStr} {dateStr}/{monthStr}/{yearStr} +00:00", out var parsed);
		string payload = (await GetTimezoneOffsetApi(geoLocation, parsed)).Payload;
		if (string.IsNullOrEmpty(payload))
		{
			throw new Exception("Timezone failed to get from API!");
		}
		string stdDateTimeText = $"{hhmmStr} {dateStr}/{monthStr}/{yearStr} {payload}";
		return new Time(stdDateTimeText, geoLocation);
	}

	public static async Task AddXElementToXDocumentAzure(XElement dataXml, string fileName, string containerName)
	{
		BlobClient fileClient = await GetBlobClientAzure(fileName, containerName);
		await OverwriteBlobData(fileClient, await AddXElementToXDocument(fileClient, dataXml));
	}

	public static void AddXElementToXDocumentAzure(XElement dataXml, ref XDocument xDocument)
	{
		AddXElementToXDocument(dataXml, ref xDocument);
	}

	public static async Task OverwriteBlobData(BlobClient blobClient, XDocument newData)
	{
		Stream content = GenerateStreamFromString(newData.ToString());
		BlobUploadOptions blobUploadOptions = new BlobUploadOptions();
		blobUploadOptions.AccessTier = AccessTier.Cool;
		await blobClient.UploadAsync(content, blobUploadOptions);
		BlobHttpHeaders httpHeaders = new BlobHttpHeaders
		{
			ContentType = "text/xml"
		};
		await blobClient.SetHttpHeadersAsync(httpHeaders);
	}

	public static Stream GenerateStreamFromString(string s)
	{
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream);
		streamWriter.Write(s);
		streamWriter.Flush();
		memoryStream.Position = 0L;
		return memoryStream;
	}

	public static async Task<XDocument> AddXElementToXDocument(BlobClient xDocuBlobClient, XElement newElement)
	{
		XDocument obj = await DownloadToXDoc(xDocuBlobClient);
		obj.Root.Add(newElement);
		return obj;
	}

	public static void AddXElementToXDocument(XElement newElement, ref XDocument xDocument)
	{
		xDocument.Root.Add(newElement);
	}

	public static async Task DeleteXElementFromXDocumentAzure(XElement dataXmlToDelete, string fileName, string containerName)
	{
		BlobClient fileClient = await GetBlobClientAzure(fileName, containerName);
		XDocument xDocument = await DownloadToXDoc(fileClient);
		IEnumerable<XElement> source = xDocument.Root.Elements();
		Person personToDelete = Person.FromXml(dataXmlToDelete);
		IEnumerable<XElement> source2 = source.Where((XElement x) => Person.FromXml(x).Id == personToDelete.Id);
		if (!source2.Any())
		{
			throw new Exception("Could not find XML record to delete in main list!");
		}
		source2.First().Remove();
		await OverwriteBlobData(fileClient, xDocument);
	}

	public static void DeleteXElementFromXDocumentAzure(XElement dataXmlToDelete, ref XDocument xmlDocFile)
	{
		IEnumerable<XElement> source = xmlDocFile.Root.Elements();
		Person personToDelete = Person.FromXml(dataXmlToDelete);
		IEnumerable<XElement> source2 = source.Where((XElement x) => Person.FromXml(x).Id == personToDelete.Id);
		if (!source2.Any())
		{
			throw new Exception("Could not find XML record to delete in main list!");
		}
		source2.First().Remove();
	}

	public static List<Time> GetTimeSlicesOnBirthDay(Person person, double precisionInHours)
	{
		Time startTime = new Time("00:00 " + person.BirthDateMonthYear + " " + person.BirthTimeZone, person.GetBirthLocation());
		Time endTime = new Time("23:59 " + person.BirthDateMonthYear + " " + person.BirthTimeZone, person.GetBirthLocation());
		return Time.GetTimeListFromRange(startTime, endTime, precisionInHours);
	}

	public static async Task<T> DelayedResultTask<T>(TimeSpan delay, Func<T> fallbackMaker)
	{
		await Task.Delay(delay);
		return fallbackMaker();
	}

	public static async Task<T> DelayedTimeoutExceptionTask<T>(TimeSpan delay)
	{
		await Task.Delay(delay);
		throw new TimeoutException();
	}

	public static async Task<T> TaskWithTimeoutAndException<T>(Task<T> task, TimeSpan timeout)
	{
		return await (await Task.WhenAny(task, DelayedTimeoutExceptionTask<T>(timeout)));
	}

	public static List<HoroscopePrediction> GetHoroscopePrediction(Time birthTime, EventTag filterTag = EventTag.Empty)
	{
		List<HoroscopeData> list = HoroscopeDataListStatic.Rows;
		if (filterTag != EventTag.Empty)
		{
			list = list.Where((HoroscopeData horoData) => horoData.EventTags.Contains(filterTag)).ToList();
		}
		return CalculatePredictions(birthTime, list);
		static List<HoroscopePrediction> CalculatePredictions(Time time, List<HoroscopeData> horoscopeDataList)
		{
			List<HoroscopePrediction> list2 = new List<HoroscopePrediction>();
			try
			{
				foreach (HoroscopeData horoscopeData in horoscopeDataList)
				{
					if (horoscopeData.IsEventOccuring(time))
					{
						HoroscopePrediction item = new HoroscopePrediction(horoscopeData.Name, horoscopeData.Description, horoscopeData.RelatedBody);
						list2.Add(item);
					}
				}
				return list2;
			}
			catch (Exception)
			{
				return new List<HoroscopePrediction>();
			}
		}
	}

	public static List<string> SplitAlpha(string input)
	{
		List<string> list = new List<string> { string.Empty };
		for (int i = 0; i < input.Length; i++)
		{
			list[list.Count - 1] += input[i];
			if (i + 1 < input.Length && char.IsLetter(input[i]) != char.IsLetter(input[i + 1]))
			{
				list.Add(string.Empty);
			}
		}
		return list;
	}

	public static string XmlToString(XElement xml)
	{
		return xml.ToString(SaveOptions.DisableFormatting);
	}

	public static async Task<List<XElement>> GetXmlFile(string url, HttpClient httpClient = null)
	{
		if (httpClient == null)
		{
			httpClient = new HttpClient();
		}
		HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
		return XDocument.Load(await (await httpClient.SendAsync(request)).Content.ReadAsStreamAsync()).Root.Elements().ToList();
	}

	public static XElement AnyTypeToXml<T>(T value)
	{
		if (value is IToXml toXml)
		{
			return toXml.ToXml();
		}
		string content = value?.ToString();
		return new XElement(typeof(T).FullName, content);
	}

	public static XElement AnyTypeToXElement(object o)
	{
		XDocument xDocument = new XDocument();
		using (XmlWriter xmlWriter = xDocument.CreateWriter())
		{
			new XmlSerializer(o.GetType()).Serialize(xmlWriter, o);
		}
		return xDocument.Root;
	}

	public static XElement AnyTypeToXmlList<T>(List<T> xmlList, string rootElementName = "Root") where T : IToXml
	{
		XElement xElement = new XElement(rootElementName);
		foreach (T xml in xmlList)
		{
			xElement.Add(AnyTypeToXml(xml));
		}
		return xElement;
	}

	public static XElement AnyTypeToXmlList(List<XElement> xmlList, string rootElementName = "Root")
	{
		XElement xElement = new XElement(rootElementName);
		foreach (XElement xml in xmlList)
		{
			xElement.Add(xml);
		}
		return xElement;
	}

	public static async Task<List<T>> ConvertXmlListFileToInstanceList<T>(string httpUrl) where T : IToXml, new()
	{
		return await ConvertXmlListFileToInstanceList<T>(await GetXmlFile(httpUrl));
	}

	public static async Task<List<T>> ConvertXmlListFileToInstanceList<T>(List<XElement> eventDataListXml) where T : IToXml, new()
	{
		List<T> list = new List<T>();
		foreach (XElement item in eventDataListXml)
		{
			list.Add(new T().FromXml<T>(item));
		}
		return list;
	}

	public static XElement ExceptionToXML(Exception e)
	{
		Exception baseException = e.GetBaseException();
		StackTrace stackTrace = new StackTrace(e, fNeedFileInfo: true);
		StackFrame? frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
		string content = frame?.GetFileName();
		string content2 = frame.GetMethod()?.Name;
		int fileLineNumber = frame.GetFileLineNumber();
		int fileColumnNumber = frame.GetFileColumnNumber();
		string content3 = baseException.ToString();
		string source = baseException.Source;
		_ = baseException.StackTrace;
		return new XElement("Error", new XElement("Message", content3), new XElement("Source", source), new XElement("FileName", content), new XElement("SourceLineNumber", fileLineNumber), new XElement("SourceColNumber", fileColumnNumber), new XElement("MethodName", content2), new XElement("MethodName", content2));
	}

	public static dynamic XmlToAnyType<T>(XElement xml)
	{
		string fullName = typeof(T).FullName;
		_ = typeof(T).FullName;
		XName xName = xml?.Name;
		string value = xml.Value;
		if (!(xName == fullName) && !(xName == typeof(T).GetShortTypeName()))
		{
			throw new Exception($"Can't parse XML {xName} to {fullName}");
		}
		if (typeof(T).GetInterfaces().Any((Type x) => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IToXml)))
		{
			dynamic instance = GetInstance(typeof(T).FullName);
			return instance.FromXml(xml);
		}
		if (typeof(T).IsEnum)
		{
			return (T)Enum.Parse(typeof(T), value);
		}
		if (typeof(T) == typeof(string))
		{
			return value;
		}
		if (typeof(T) == typeof(double))
		{
			return double.Parse(value);
		}
		if (typeof(T) == typeof(int))
		{
			return int.Parse(value);
		}
		throw new NotImplementedException("XML converter for " + fullName + ", not implemented!");
	}

	public static string GetShortTypeName(this Type type)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string name = type.Name;
		if (!type.IsGenericType)
		{
			return name;
		}
		stringBuilder.Append(name.Substring(0, name.IndexOf('`')));
		stringBuilder.Append("<");
		stringBuilder.Append(string.Join(", ", from t in type.GetGenericArguments()
			select t.GetShortTypeName()));
		stringBuilder.Append(">");
		return stringBuilder.ToString();
	}

	public static bool Implements<I>(this Type type, I @interface) where I : class
	{
		if (@interface as Type == null || !(@interface as Type).IsInterface)
		{
			throw new ArgumentException("Only interfaces can be 'implemented'.");
		}
		return (@interface as Type).IsAssignableFrom(type);
	}

	public static object GetInstance(string strFullyQualifiedName)
	{
		Type type = Type.GetType(strFullyQualifiedName);
		if (type != null)
		{
			return Activator.CreateInstance(type);
		}
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			type = assemblies[i].GetType(strFullyQualifiedName);
			if (type != null)
			{
				return Activator.CreateInstance(type);
			}
		}
		return null;
	}

	public static double DaysToHours(double days)
	{
		return days * 24.0;
	}

	public static double WeeksToHours(double weeks)
	{
		return weeks * 7.0 * 24.0;
	}

	public static double MonthsToHours(double months)
	{
		return months * 30.44 * 24.0;
	}

	public static double YearsToHours(double years)
	{
		return years * 365.25 * 24.0;
	}

	public static double DecadesToHours(double decades)
	{
		return decades * 10.0 * 365.25 * 24.0;
	}

	public static double MinutesToHours(double minutes)
	{
		return minutes / 60.0;
	}

	public static double MinutesToYears(double minutes)
	{
		return minutes / 525600.0;
	}

	public static double MinutesToDays(double minutes)
	{
		return minutes / 1440.0;
	}

	public static double GetDaysToNextYear(Time getBirthDateTime)
	{
		DateTimeOffset stdDateTimeOffset = getBirthDateTime.GetStdDateTimeOffset();
		int year = stdDateTimeOffset.Year + 1;
		return (new DateTimeOffset(year, 1, 1, 0, 0, 0, 0, stdDateTimeOffset.Offset) - stdDateTimeOffset).TotalDays;
	}

	public static string GetNowSystemTimeText()
	{
		return DateTimeOffset.Now.ToString("HH:mm dd/MM/yyyy zzz");
	}

	public static string GetNowSystemTimeSecondsText()
	{
		return DateTimeOffset.Now.ToString("HH:mm:ss dd/MM/yyyy zzz");
	}

	public static string GetNowServerTimeSecondsText()
	{
		return DateTimeOffset.Now.ToOffset(TimeSpan.FromHours(8.0)).ToString("HH:mm:ss dd/MM/yyyy zzz");
	}

	public static int GetStringHashCode(string stringToHash)
	{
		if (stringToHash == null)
		{
			return 0;
		}
		int num = 352654597;
		int num2 = num;
		for (int i = 0; i < stringToHash.Length; i += 2)
		{
			num = ((num << 5) + num) ^ stringToHash[i];
			if (i == stringToHash.Length - 1)
			{
				break;
			}
			num2 = ((num2 << 5) + num2) ^ stringToHash[i + 1];
		}
		return num + num2 * 1566083941;
	}

	public static string GetStringHashCodeMD5(string stringToHash, int truncateLength = 32)
	{
		if (stringToHash == null)
		{
			return "0";
		}
		using MD5 mD = MD5.Create();
		byte[] array = mD.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		string text = stringBuilder.ToString();
		return (text.Length > truncateLength) ? text.Substring(0, truncateLength) : text;
	}

	public static string GenerateId(int? truncate = null)
	{
		string text = Guid.NewGuid().ToString("N");
		if (!truncate.HasValue || truncate.Value >= text.Length)
		{
			return text;
		}
		return text.Substring(0, truncate.Value);
	}

	public static string ListToString<T>(List<T> list, string separator = ",")
	{
		string text = "";
		for (int i = 0; i < list.Count; i++)
		{
			string text2 = ((i == list.Count - 1) ? "" : (separator + " "));
			text = text + list[i].ToString() + text2;
		}
		return text;
	}

	public static string? Truncate(this string? value, int maxLength, string truncationSuffix = "…")
	{
		if (value == null || value.Length <= maxLength)
		{
			return value;
		}
		return value.Substring(0, maxLength) + truncationSuffix;
	}

	public static bool FindCluster(this string haystack, string needle)
	{
		if (haystack == null)
		{
			return false;
		}
		if (needle == null)
		{
			return false;
		}
		if (haystack.Length < needle.Length)
		{
			return false;
		}
		long num = needle.ToCharArray().Sum((char c) => c);
		long num2 = haystack.ToCharArray().Take(needle.Length).Sum((char c) => c);
		int num3 = 0;
		int num4 = needle.Length;
		while (num2 != num)
		{
			if (num4 >= haystack.Length)
			{
				return false;
			}
			num2 -= haystack[num3];
			num2 += haystack[num4];
			num4++;
			num3++;
		}
		return true;
	}

	public static float Remap(this float from, float fromMin, float fromMax, float toMin, float toMax)
	{
		float num = from - fromMin;
		float num2 = fromMax - fromMin;
		float num3 = num / num2;
		return (toMax - toMin) * num3 + toMin;
	}

	public static double Remap(this double from, double fromMin, double fromMax, double toMin, double toMax)
	{
		double num = from - fromMin;
		double num2 = fromMax - fromMin;
		double num3 = num / num2;
		return (toMax - toMin) * num3 + toMin;
	}

	public static string StreamToString(Stream stream)
	{
		return new StreamReader(stream).ReadToEnd();
	}

	public static TimeSpan StringToTimezone(string timezoneRaw)
	{
		return DateTimeOffset.ParseExact(timezoneRaw, "zzz", CultureInfo.InvariantCulture).Offset;
	}

	public static string GetSystemTimezoneStr()
	{
		return DateTimeOffset.Now.ToString("zzz");
	}

	public static TimeSpan GetSystemTimezone()
	{
		return DateTimeOffset.Now.Offset;
	}

	public static async Task<WebResult<GeoLocation>> AddressToGeoLocation(string address)
	{
		WebResult<JToken> webResult = await ReadFromServerJsonReplyVedAstro(new URL("stable".Contains("beta")).AddressToGeoLocationAPI + "/Address/" + address);
		if (!webResult.IsPass)
		{
			return new WebResult<GeoLocation>(result: false, GeoLocation.Empty);
		}
		GeoLocation payload = GeoLocation.FromJson(webResult.Payload);
		return new WebResult<GeoLocation>(result: true, payload);
	}

	public static async Task<TimeSpan> GetTimezoneOffset(string locationName, DateTimeOffset timeAtLocation)
	{
		return StringToTimezone(await GetTimezoneOffsetApi(await GeoLocation.FromName(locationName), timeAtLocation));
	}

	public static async Task<string> GetTimezoneOffsetString(string locationName, DateTime timeAtLocation)
	{
		return await GetTimezoneOffsetApi(await GeoLocation.FromName(locationName), timeAtLocation);
	}

	public static async Task<string> GetTimezoneOffsetString(string location, string dateTime)
	{
		DateTime timeAtLocation = DateTime.ParseExact(dateTime, "HH:mm dd/MM/yyyy", null);
		return await GetTimezoneOffsetString(location, timeAtLocation);
	}

	public static async Task<WebResult<string>> GetTimezoneOffsetApi(GeoLocation geoLocation, DateTimeOffset timeAtLocation)
	{
		return await CacheManager.GetCache(new CacheKey("Tools.GetTimezoneOffsetApi", geoLocation, timeAtLocation), getTimezoneOffsetApi);
		async Task<WebResult<string>> getTimezoneOffsetApi()
		{
			try
			{
				WebResult<JToken> webResult = await ReadFromServerJsonReplyVedAstro(new URL("stable".Contains("beta")).GeoLocationToTimezoneAPI + geoLocation.ToUrl() + timeAtLocation.ToUrl());
				if (!webResult.IsPass)
				{
					return new WebResult<string>(result: false, "");
				}
				string payload = webResult.Payload["GeoLocationToTimezone"].Value<string>();
				return new WebResult<string>(result: true, payload);
			}
			catch (Exception message)
			{
				LibLogger.Debug(message);
				return new WebResult<string>(result: false, "");
			}
		}
	}

	public static string TimeSpanToUTCTimezoneString(TimeSpan offsetMinutes)
	{
		return DateTimeOffset.UtcNow.ToOffset(offsetMinutes).ToString("zzz");
	}

	public static async Task<WebResult<XElement>> ReadFromServerXmlReply(string apiUrl)
	{
		HttpResponseMessage result = await RequestServer(apiUrl);
		string text = (await (result.Content?.ReadAsStringAsync())) ?? "";
		if (!result.IsSuccessStatusCode)
		{
			return new WebResult<XElement>(result: false, new XElement("RawErrorData", text));
		}
		return ParseData(text);
		static WebResult<XElement> ParseData(string inputRawString)
		{
			List<Exception> list = new List<Exception>();
			try
			{
				WebResult<XElement> webResult = WebResult<XElement>.FromXml(XElement.Parse(inputRawString));
				if (!webResult.IsPass)
				{
					throw new InvalidOperationException();
				}
				return webResult;
			}
			catch (Exception item)
			{
				try
				{
					XElement payload = XElement.Parse(inputRawString);
					return new WebResult<XElement>(result: true, payload);
				}
				catch (Exception item2)
				{
					list.Add(item2);
				}
				try
				{
					XElement payload2 = XElement.Parse(JsonConvert.DeserializeXmlNode(inputRawString, "LocationData").InnerXml);
					return new WebResult<XElement>(result: true, payload2);
				}
				catch (Exception item3)
				{
					list.Add(item3);
				}
				list.Add(item);
				foreach (Exception item4 in list)
				{
					LibLogger.Debug(item4, inputRawString);
				}
				return new WebResult<XElement>(result: false, new XElement("Failed"));
			}
		}
		static async Task<HttpResponseMessage> RequestServer(string receiverAddress)
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, receiverAddress);
			using HttpClient client = new HttpClient();
			client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
			HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead;
			return await client.SendAsync(request, completionOption);
		}
	}

	public static async Task<WebResult<JToken>> ReadFromServerJsonReply(string apiUrl)
	{
		new List<Exception>();
		HttpResponseMessage result = await RequestServer(apiUrl, 3);
		string text = (await (result.Content?.ReadAsStringAsync())) ?? "";
		if (!result.IsSuccessStatusCode)
		{
			JObject jObject = new JObject();
			jObject.Add("RawErrorData", text);
			return new WebResult<JToken>(result: false, jObject);
		}
		return ParseData(text);
		static WebResult<JToken> ParseData(string inputRawString)
		{
			try
			{
				JObject payload = JObject.Parse(inputRawString);
				return new WebResult<JToken>(result: true, payload);
			}
			catch (Exception message)
			{
				LibLogger.Debug(message, inputRawString);
				return new WebResult<JToken>(result: false, new JObject("Failed"));
			}
		}
		static async Task<HttpResponseMessage> RequestServer(string receiverAddress, int retryCount)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, receiverAddress);
			using HttpClient client = new HttpClient
			{
				Timeout = new TimeSpan(0, 0, 0, 0, -1)
			};
			HttpCompletionOption waitForContent = HttpCompletionOption.ResponseContentRead;
			for (int attempt = 0; attempt < retryCount; attempt++)
			{
				try
				{
					return await client.SendAsync(httpRequestMessage, waitForContent);
				}
				catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
				{
					await Task.Delay(350);
				}
			}
			return null;
		}
	}

	public static async Task<WebResult<JToken>> ReadFromServerJsonReplyVedAstro(string apiUrl)
	{
		HttpResponseMessage result = await RequestServer(apiUrl, 3);
		string text = (await (result.Content?.ReadAsStringAsync())) ?? "";
		if (!result.IsSuccessStatusCode)
		{
			JObject jObject = new JObject();
			jObject.Add("RawErrorData", text);
			return new WebResult<JToken>(result: false, jObject);
		}
		return ParseData(text);
		WebResult<JToken> ParseData(string inputRawString)
		{
			try
			{
				WebResult<JToken> webResult = WebResult<JObject>.FromVedAstroJson(JObject.Parse(inputRawString));
				if (!webResult.IsPass)
				{
					throw new InvalidOperationException();
				}
				return webResult;
			}
			catch (Exception message)
			{
				LibLogger.Debug(message, "URL:" + apiUrl + "-->" + inputRawString);
				return new WebResult<JToken>(result: false, new JObject("Failed"));
			}
		}
		static async Task<HttpResponseMessage> RequestServer(string receiverAddress, int retryCount)
		{
			HttpCompletionOption waitForContent = HttpCompletionOption.ResponseContentRead;
			using HttpClient client = new HttpClient();
			client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
			for (int attempt = 0; attempt < retryCount; attempt++)
			{
				try
				{
					HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, receiverAddress);
					return await client.SendAsync(request, waitForContent);
				}
				catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
				{
					await Task.Delay(350);
				}
			}
			return null;
		}
	}

	public static string RandomSelect(string[] msgList)
	{
		int num = new Random().Next(msgList.Length);
		return msgList[num];
	}

	public static int GetRandomNumber(int maxNumber)
	{
		return new Random().Next(maxNumber);
	}

	public static IEnumerable<string> SplitByCharCount(string str, int maxChunkSize)
	{
		for (int i = 0; i < str.Length; i += maxChunkSize)
		{
			yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
		}
	}

	public static List<PlanetName> GetPlanetFromName(string eventName)
	{
		List<PlanetName> list = new List<PlanetName>();
		string[] array = eventName.ToLower().Split(' ');
		for (int i = 0; i < array.Length; i++)
		{
			if (PlanetName.TryParse(array[i], out var parsed))
			{
				list.Add(parsed);
			}
		}
		return list;
	}

	public static StringContent XmLtoHttpContent(XElement data)
	{
		string content = XmlToString(data);
		Encoding uTF = Encoding.UTF8;
		string mediaType = "plain/text";
		return new StringContent(content, uTF, mediaType);
	}

	public static StringContent JsontoHttpContent(JToken data)
	{
		string content = data.ToString();
		Encoding uTF = Encoding.UTF8;
		string mediaType = "application/json";
		return new StringContent(content, uTF, mediaType);
	}

	public static JObject ExceptionToJSON(Exception e)
	{
		Exception baseException = e.GetBaseException();
		StackTrace stackTrace = new StackTrace(e, fNeedFileInfo: true);
		StackFrame? frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
		string content = frame?.GetFileName();
		string content2 = frame.GetMethod()?.Name;
		int fileLineNumber = frame.GetFileLineNumber();
		int fileColumnNumber = frame.GetFileColumnNumber();
		string content3 = baseException.ToString();
		string source = baseException.Source;
		_ = baseException.StackTrace;
		return new JObject(new JProperty("Error", new JObject(new JProperty("Message", content3), new JProperty("Source", source), new JProperty("FileName", content), new JProperty("SourceLineNumber", fileLineNumber), new JProperty("SourceColNumber", fileColumnNumber), new JProperty("MethodName", content2))));
	}

	public static object EnumFromUrl(string url)
	{
		string[] array = url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length < 2)
		{
			throw new ArgumentException("Invalid URL format.", "url");
		}
		string text = array[0];
		string text2 = array[1];
		Type type = Type.GetType("VedAstro.Library." + text);
		if (type == null)
		{
			throw new ArgumentException($"Enum type '{text}' not found in namespace '{"VedAstro.Library."}'.", "url");
		}
		try
		{
			return Enum.Parse(type, text2);
		}
		catch (ArgumentException)
		{
			if (text == "Ayanamsa")
			{
				return Enum.Parse(typeof(SimpleAyanamsa), text2);
			}
			if (double.TryParse(text2, out var result))
			{
				return result;
			}
			throw;
		}
	}

	public static object EnumFromUrl(string url, Type enumType)
	{
		string[] array = url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length < 2)
		{
			throw new ArgumentException("Invalid URL format.", "url");
		}
		string text = array[0];
		string text2 = array[1];
		if (enumType == null)
		{
			throw new ArgumentException($"Enum type '{text}' not found in namespace '{"VedAstro.Library."}'.", "url");
		}
		try
		{
			return Enum.Parse(enumType, text2);
		}
		catch (ArgumentException)
		{
			if (text == "Ayanamsa")
			{
				return Enum.Parse(typeof(SimpleAyanamsa), text2);
			}
			if (double.TryParse(text2, out var result))
			{
				return result;
			}
			throw;
		}
	}

	public static string StringFromUrl(string url)
	{
		return url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
	}

	public static int IntFromUrl(string url)
	{
		return int.Parse(url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1]);
	}

	public static double DoubleFromUrl(string url)
	{
		return double.Parse(url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1]);
	}

	public static DateTimeOffset DateTimeOffsetFromUrl(string timeUrl)
	{
		string[] array = timeUrl.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		if (!Time.TryParseStd($"{array[1]} {array[2]}/{array[3]}/{array[4]} {array[5]}", out var parsed))
		{
			throw new Exception("Failed to get timezone!");
		}
		return parsed;
	}

	public static string ToUrl(this DateTimeOffset dateTimeOffset)
	{
		string value = dateTimeOffset.ToString("HH:mm");
		string text = dateTimeOffset.ToString("dd/MM/yyyy");
		string value2 = dateTimeOffset.ToString("zzz");
		text = text.Replace('.', '/');
		text = text.Replace('-', '/');
		return $"/Time/{value}/{text}/{value2}";
	}

	public static object GetRandomEnumValue(Type enumType)
	{
		if (!enumType.IsEnum)
		{
			throw new ArgumentException("Type must be an enumeration");
		}
		Array values = Enum.GetValues(enumType);
		int index = Random.Next(values.Length);
		return values.GetValue(index);
	}

	public static string GetNow()
	{
		TimeSpan offset = new TimeSpan(8, 0, 0);
		return DateTimeOffset.Now.ToUniversalTime().ToOffset(offset).ToString("HH:mm:ss dd/MM/yyyy zzz");
	}

	public static string CleanAndFormatNameText(string nameInput)
	{
		try
		{
			string text = Regex.Replace(nameInput, "[^\\w\\.\\s*-]", "", RegexOptions.None, TimeSpan.FromSeconds(2.0));
			TextInfo textInfo = new CultureInfo("en-US", useUserOverride: false).TextInfo;
			text = text.ToLower();
			return textInfo.ToTitleCase(text);
		}
		catch (RegexMatchTimeoutException)
		{
			return string.Empty;
		}
	}

	public static string CleanText(string uncleanInput)
	{
		try
		{
			return Regex.Replace(uncleanInput, "[^\\w\\.\\s*-]", "", RegexOptions.None, TimeSpan.FromSeconds(2.0));
		}
		catch (RegexMatchTimeoutException)
		{
			return string.Empty;
		}
	}

	public static string XmlToJsonString(XElement xElement)
	{
		string xml = xElement.ToString(SaveOptions.DisableFormatting);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		return JsonConvert.SerializeXmlNode(xmlDocument, Newtonsoft.Json.Formatting.None, omitRootObject: true);
	}

	public static JObject XmlToJson(XElement xElement)
	{
		return JObject.Parse(XmlToJsonString(xElement));
	}

	public static int VedAstroToSwissEph(PlanetName planetName)
	{
		int result = 0;
		if (planetName == PlanetName.Sun)
		{
			result = 0;
		}
		else if (planetName == PlanetName.Moon)
		{
			result = 1;
		}
		else if (planetName == PlanetName.Mars)
		{
			result = 4;
		}
		else if (planetName == PlanetName.Mercury)
		{
			result = 2;
		}
		else if (planetName == PlanetName.Jupiter)
		{
			result = 5;
		}
		else if (planetName == PlanetName.Venus)
		{
			result = 3;
		}
		else if (planetName == PlanetName.Saturn)
		{
			result = 6;
		}
		else if (planetName == PlanetName.Earth)
		{
			result = 14;
		}
		else if (planetName == PlanetName.Rahu)
		{
			result = (Calculate.UseMeanRahuKetu ? 10 : 11);
		}
		else if (planetName == PlanetName.Ketu)
		{
			result = (Calculate.UseMeanRahuKetu ? 10 : 11);
		}
		return result;
	}

	public static int StringToSwissEph(string planetName)
	{
		int result = 0;
		planetName = planetName.ToLower();
		switch (planetName)
		{
		case "sun":
			result = 0;
			break;
		case "moon":
			result = 1;
			break;
		case "mars":
			result = 4;
			break;
		case "Mercury":
			result = 2;
			break;
		case "Jupiter":
			result = 5;
			break;
		case "Venus":
			result = 3;
			break;
		case "Saturn":
			result = 6;
			break;
		case "Rahu":
			result = (Calculate.UseMeanRahuKetu ? 10 : 11);
			break;
		case "Ketu":
			result = (Calculate.UseMeanRahuKetu ? 10 : 11);
			break;
		}
		return result;
	}

	public static IEnumerable<string> ApiDataPropertyCallList()
	{
		List<string> list = new List<string>();
		MethodInfo[] methods = typeof(Calculate).GetMethods();
		foreach (MethodInfo methodInfo in methods)
		{
			list.Add(methodInfo.Name);
		}
		return list;
	}

	public static string RemoveWhiteSpace(string stringWithSpace)
	{
		return string.Join("", stringWithSpace.Split((string[]?)null, StringSplitOptions.RemoveEmptyEntries));
	}

	public static List<OpenAPIMetadata> GetPlanetApiCallList<T1, T2>()
	{
		return OpenAPIMetadata.FromMethodInfoList(GetCalculatorListByParam<T1, T2>());
	}

	public static string GetMethodSignature(this MethodInfo methodInfo)
	{
		IEnumerable<string> parameterDescriptions = from param in methodInfo.GetParameters()
			select GetGenericTypeName(param.ParameterType) + " " + param.Name;
		return GetMethodSignature(methodInfo.Name, parameterDescriptions);
	}

	public static string GetMethodSignature(this MethodDeclarationSyntax methodDeclaration, SemanticModel semanticModel)
	{
		IEnumerable<string> parameterDescriptions = methodDeclaration.ParameterList.Parameters.Select((ParameterSyntax param) => param.Type.ToString() + " " + param.Identifier.Text);
		return GetMethodSignature(methodDeclaration.Identifier.Text, parameterDescriptions);
	}

	public static string GetMethodSignature(string methodName, IEnumerable<string> parameterDescriptions)
	{
		IEnumerable<string> source = parameterDescriptions.Select((string p) => p.Replace("Int32", "int"));
		source = source.Select((string p) => p.Replace("Double", "double"));
		source = source.Select((string p) => p.Replace("String", "string"));
		source = source.Select((string p) => p.Replace("Boolean", "bool"));
		return (methodName + "(" + string.Join(", ", source) + ")").Replace(" ", "");
	}

	public static string GetGenericTypeName(Type type)
	{
		if (!type.IsGenericType)
		{
			return type.Name;
		}
		string name = type.GetGenericTypeDefinition().Name;
		name = name.Substring(0, name.IndexOf('`'));
		string text = string.Join(",", (from t in type.GetGenericArguments()
			select t.Name).ToArray());
		return name + "<" + text + ">";
	}

	public static bool SearchText(this string text, string keyword)
	{
		string text2 = text.Replace(" ", "");
		string value = keyword.Replace(" ", "");
		return text2.Contains(value, StringComparison.OrdinalIgnoreCase);
	}

	public static string GetAllDataAsText(this MethodInfo methodInfo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder stringBuilder3 = stringBuilder2;
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2);
		handler.AppendFormatted(methodInfo.Name);
		stringBuilder3.AppendLine(ref handler);
		stringBuilder2 = stringBuilder;
		StringBuilder stringBuilder4 = stringBuilder2;
		handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2);
		handler.AppendFormatted(methodInfo.ReturnType.Name);
		stringBuilder4.AppendLine(ref handler);
		ParameterInfo[] parameters = methodInfo.GetParameters();
		foreach (ParameterInfo parameterInfo in parameters)
		{
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder5 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(2, 2, stringBuilder2);
			handler.AppendLiteral("\t");
			handler.AppendFormatted(parameterInfo.ParameterType.Name);
			handler.AppendLiteral(" ");
			handler.AppendFormatted(parameterInfo.Name);
			stringBuilder5.AppendLine(ref handler);
		}
		return stringBuilder.ToString();
	}

	public static List<object> GetInitializedSampleParameters(this MethodInfo methodInfo)
	{
		List<object> list = new List<object>();
		try
		{
			ParameterInfo[] parameters = methodInfo.GetParameters();
			for (int i = 0; i < parameters.Length; i++)
			{
				Type parameterType = parameters[i].ParameterType;
				object obj = null;
				if (parameterType == typeof(object))
				{
					obj = new object();
				}
				if (parameterType == typeof(ZodiacSign))
				{
					obj = new ZodiacSign(ZodiacName.Aquarius, Angle.FromDegrees(15.0));
				}
				if (parameterType == typeof(ZodiacName))
				{
					obj = ZodiacName.Aquarius;
				}
				if (parameterType == typeof(Time))
				{
					obj = Time.StandardHoroscope();
				}
				if (parameterType == typeof(Angle))
				{
					obj = Angle.Degrees180;
				}
				if (parameterType == typeof(PlanetName))
				{
					obj = PlanetName.Sun;
				}
				if (parameterType == typeof(Constellation))
				{
					obj = new Constellation(1, 1, Angle.FromDegrees(13.0));
				}
				if (parameterType == typeof(Person))
				{
					obj = new Person("101", "12312323", "Juliet", Time.StandardHoroscope(), Gender.Female);
				}
				if (parameterType == typeof(HouseName))
				{
					obj = HouseName.House4;
				}
				if (parameterType == typeof(TimeSpan))
				{
					obj = new TimeSpan(1, 0, 0);
				}
				if (parameterType == typeof(List<HouseName>))
				{
					obj = new List<HouseName>
					{
						HouseName.House1,
						HouseName.House4
					};
				}
				if (parameterType == typeof(List<PlanetName>))
				{
					obj = new List<PlanetName>
					{
						PlanetName.Moon,
						PlanetName.Mars
					};
				}
				if (parameterType == typeof(int))
				{
					obj = 5;
				}
				if (parameterType == typeof(double))
				{
					obj = 2415018.5;
				}
				if (parameterType == typeof(string))
				{
					obj = "sun";
				}
				if (parameterType == typeof(bool))
				{
					obj = false;
				}
				if (parameterType == typeof(DateTimeOffset))
				{
					obj = DateTimeOffset.Now;
				}
				if (parameterType == typeof(PlanetName[]))
				{
					obj = new PlanetName[2]
					{
						PlanetName.Mars,
						PlanetName.Jupiter
					};
				}
				if (parameterType == typeof(int[]))
				{
					obj = new int[2] { 3, 5 };
				}
				if (parameterType == typeof(Dictionary<PlanetName, Shashtiamsa>))
				{
					obj = new Dictionary<PlanetName, Shashtiamsa>
					{
						{
							PlanetName.Sun,
							new Shashtiamsa(103.244)
						},
						{
							PlanetName.Moon,
							new Shashtiamsa(195.338)
						},
						{
							PlanetName.Mars,
							new Shashtiamsa(28.665)
						},
						{
							PlanetName.Mercury,
							new Shashtiamsa(191.879)
						},
						{
							PlanetName.Jupiter,
							new Shashtiamsa(210.36)
						},
						{
							PlanetName.Venus,
							new Shashtiamsa(117.7177)
						},
						{
							PlanetName.Saturn,
							new Shashtiamsa(114.849)
						}
					};
				}
				if (obj == null)
				{
					obj = GetRandomEnumValue(parameterType);
				}
				list.Add(obj);
			}
			return list;
		}
		catch (Exception)
		{
			Console.WriteLine("Error when getting sample for : " + methodInfo.Name);
			return list;
		}
	}

	public static string ToRowKey(this DateTimeOffset dateTimeOffset)
	{
		return dateTimeOffset.ToString("HH:mm dd/MM/yyyy zzz").Replace('/', '-');
	}

	public static List<string> GetParametersStringList(this MethodInfo methodInfo)
	{
		List<string> list = new List<string>();
		ParameterInfo[] parameters = methodInfo.GetParameters();
		foreach (ParameterInfo parameterInfo in parameters)
		{
			list.Add(parameterInfo.ParameterType.Name ?? "");
		}
		return list;
	}

	public static JObject ExecuteCalculatorByParam<T1, T2>(T1 inputedPram1, T2 inputedPram2)
	{
		List<MethodInfo> list = (from method in GetCalculatorListByParam<T1, T2>()
			orderby method.Name
			select method).ToList();
		JObject jObject = new JObject();
		object[] param = new object[2] { inputedPram1, inputedPram2 };
		foreach (MethodInfo item in list)
		{
			JToken content = JToken.FromObject(ExecuteAPICalculator(item, param));
			jObject.Add(content);
		}
		return jObject;
	}

	public static JObject ExecuteCalculatorByParam<T1>(T1 inputedPram1)
	{
		List<MethodInfo> list = (from method in GetCalculatorListByParam<T1>()
			orderby method.Name
			select method).ToList();
		JObject jObject = new JObject();
		object[] param = new object[1] { inputedPram1 };
		foreach (MethodInfo item in list)
		{
			JToken content = JToken.FromObject(ExecuteAPICalculator(item, param));
			jObject.Add(content);
		}
		return jObject;
	}

	public static JProperty ExecuteCalculatorByApiName<T1, T2>(string methodName, T1 param1, T2 param2)
	{
		MethodInfo methodInfo = (from x in typeof(Calculate).GetMethods()
			where x.Name == methodName
			select x).FirstOrDefault();
		if (methodInfo == null)
		{
			string text = "Call not found, make sure API link is latest version : " + methodName + " ";
			return new JProperty(methodName, "ERROR:" + text);
		}
		return ExecuteCalculatorByApiName(methodInfo, param1, param2);
	}

	public static JProperty ExecuteCalculatorByApiName<T1, T2>(MethodInfo foundMethod, T1 param1, T2 param2)
	{
		Type parameterType = foundMethod.GetParameters()[0].ParameterType;
		object[] array = new object[2] { param1, param2 };
		object[] array2 = new object[2] { param2, param1 };
		object[] parameters = ((parameterType == param1.GetType()) ? array : array2);
		object obj = foundMethod?.Invoke(null, parameters);
		string name = foundMethod.Name;
		if (obj is IList source)
		{
			string content = ListToString(source.Cast<object>().ToList());
			return new JProperty(name, content);
		}
		if (obj is IToJson toJson)
		{
			return new JProperty(name, toJson.ToJson());
		}
		return new JProperty(name, obj?.ToString());
	}

	public static JProperty ExecuteCalculatorByApiName<T1>(MethodInfo foundMethod, T1 param1)
	{
		_ = foundMethod.GetParameters()[0].ParameterType;
		object[] parameters = new object[1] { param1 };
		object obj = foundMethod?.Invoke(null, parameters);
		string name = foundMethod.Name;
		if (obj is IList source)
		{
			string content = ListToString(source.Cast<object>().ToList());
			return new JProperty(name, content);
		}
		if (obj is IToJson toJson)
		{
			return new JProperty(name, toJson.ToJson());
		}
		return new JProperty(name, obj?.ToString());
	}

	public static JProperty ExecuteAPICalculator(MethodInfo methodInfo1, object[] param)
	{
		try
		{
			JProperty result;
			if (param.Length == 1)
			{
				result = ExecuteCalculatorByApiName(methodInfo1, param[0]);
			}
			else
			{
				if (param.Length != 2)
				{
					throw new Exception("END OF THE LINE!");
				}
				result = ExecuteCalculatorByApiName(methodInfo1, param[0], param[1]);
			}
			return result;
		}
		catch (Exception ex)
		{
			try
			{
				if (param.Length == 2)
				{
					return ExecuteCalculatorByApiName(methodInfo1, param[1], param[0]);
				}
				return new JProperty(methodInfo1.Name, "ERROR: " + ex.Message);
			}
			catch (Exception ex2)
			{
				return new JProperty(methodInfo1.Name, "ERROR: " + ex2.Message);
			}
		}
	}

	public static IEnumerable<MethodInfo> GetCalculatorListByParam<T1, T2>()
	{
		Type inputedParamType1 = typeof(T1);
		Type inputedParamType2 = typeof(T2);
		Type? typeFromHandle = typeof(Calculate);
		List<MethodInfo> list = new List<MethodInfo>();
		IEnumerable<MethodInfo> enumerable = from calculatorInfo in typeFromHandle.GetMethods()
			let parameter = calculatorInfo.GetParameters()
			where parameter.Length == 2 && parameter[0].ParameterType == inputedParamType1 && parameter[1].ParameterType == inputedParamType2
			select calculatorInfo;
		list.AddRange(enumerable);
		IEnumerable<MethodInfo> enumerable2 = from calculatorInfo in typeFromHandle.GetMethods()
			let parameter = calculatorInfo.GetParameters()
			where parameter.Length == 2 && parameter[0].ParameterType == inputedParamType2 && parameter[1].ParameterType == inputedParamType1
			select calculatorInfo;
		list.AddRange(enumerable2);
		Console.WriteLine($"Calculators Type 1 : {enumerable?.Count()}");
		Console.WriteLine($"Calculators Type 2 : {enumerable2?.Count()}");
		return list;
	}

	public static IEnumerable<MethodInfo> GetCalculatorListByParam<T1>()
	{
		Type inputedParamType1 = typeof(T1);
		Type? typeFromHandle = typeof(Calculate);
		List<MethodInfo> list = new List<MethodInfo>();
		IEnumerable<MethodInfo> enumerable = from calculatorInfo in typeFromHandle.GetMethods()
			let parameter = calculatorInfo.GetParameters()
			where parameter.Length == 1 && parameter[0].ParameterType == inputedParamType1
			select calculatorInfo;
		list.AddRange(enumerable);
		Console.WriteLine($"Calculators with 1 param : {enumerable?.Count()}");
		return list;
	}

	public static List<MethodInfo> GetAllApiCalculatorsMethodInfo()
	{
		return (from m in typeof(Calculate).GetMethods()
			where !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_") && m.DeclaringType != typeof(object)
			select m).ToList();
	}

	public static JToken AnyToJSON(string dataName, dynamic anyTypeData)
	{
		JProperty jProperty = null;
		if (!(anyTypeData is JObject content))
		{
			if (!(anyTypeData is List<House> list))
			{
				if (!(anyTypeData is List<Tuple<Time, Time, ZodiacName, PlanetName>> list2))
				{
					if (!(anyTypeData is List<APIFunctionResult> apiFunctionResultList))
					{
						if (!(anyTypeData is List<HoroscopePrediction> predictionList))
						{
							if (!(anyTypeData is List<PlanetName> planetNameList))
							{
								if (!(anyTypeData is List<JObject> itemList))
								{
									if (!(anyTypeData is List<DasaEvent> eventList))
									{
										if (!(anyTypeData is IList source))
										{
											if (!(anyTypeData is Dictionary<PlanetName, ZodiacSign> dictionary))
											{
												if (!(anyTypeData is Dictionary<PlanetName, Angle> dictionary2))
												{
													if (!(anyTypeData is Dictionary<PlanetName, PlanetName> dictionary3))
													{
														if (!(anyTypeData is Dictionary<PlanetName, ZodiacName> dictionary4))
														{
															if (!(anyTypeData is Dictionary<PlanetName, Constellation> dictionary5))
															{
																if (!(anyTypeData is Dictionary<PlanetName, HouseName> dictionary6))
																{
																	if (!(anyTypeData is Dictionary<HouseName, Angle> dictionary7))
																	{
																		if (!(anyTypeData is Dictionary<HouseName, ZodiacSign> dictionary8))
																		{
																			if (!(anyTypeData is Dictionary<HouseName, PlanetName> dictionary9))
																			{
																				if (!(anyTypeData is Dictionary<HouseName, ZodiacName> dictionary10))
																				{
																					if (!(anyTypeData is Dictionary<HouseName, Constellation> dictionary11))
																					{
																						if (!(anyTypeData is Dictionary<string, object> dictionary12))
																						{
																							if (!(anyTypeData is Dictionary<HouseName, IList> dictionary13))
																							{
																								if (!(anyTypeData is Dictionary<ZodiacName, int> source2))
																								{
																									if (anyTypeData is IToJson toJson)
																									{
																										return new JProperty(dataName, toJson.ToJson());
																									}
																									return new JProperty(dataName, anyTypeData?.ToString());
																								}
																								string content2 = ListToString(source2.Cast<object>().ToList());
																								return new JProperty(dataName, content2);
																							}
																							JArray jArray = new JArray();
																							foreach (KeyValuePair<HouseName, IList> item5 in dictionary13)
																							{
																								JObject item = new JObject
																								{
																									{
																										"House",
																										item5.Key.ToString()
																									},
																									{
																										dataName,
																										ListToString((List<IList>)item5.Value)
																									}
																								};
																								jArray.Add(item);
																							}
																							return new JProperty(dataName, jArray);
																						}
																						List<JProperty> list3 = new List<JProperty>();
																						foreach (KeyValuePair<string, object> item6 in dictionary12)
																						{
																							string dataName2 = item6.Key.ToString();
																							object value = item6.Value;
																							JToken jToken = AnyToJSON(dataName2, value);
																							list3.Add((JProperty)jToken);
																						}
																						JArray jArray2 = new JArray();
																						foreach (JProperty item7 in list3)
																						{
																							JObject item2 = new JObject(item7);
																							jArray2.Add(item2);
																						}
																						return new JProperty(dataName, jArray2);
																					}
																					return RootPayloadJson("House", dataName, dictionary11);
																				}
																				return RootPayloadJson("House", dataName, dictionary10);
																			}
																			return RootPayloadJson("House", dataName, dictionary9);
																		}
																		return RootPayloadJson("House", dataName, dictionary8);
																	}
																	return RootPayloadJson("House", dataName, dictionary7);
																}
																return RootPayloadJson("Planet", dataName, dictionary6);
															}
															return RootPayloadJson("Planet", dataName, dictionary5);
														}
														return RootPayloadJson("Planet", dataName, dictionary4);
													}
													return RootPayloadJson("Planet", dataName, dictionary3);
												}
												return RootPayloadJson("Planet", dataName, dictionary2);
											}
											return RootPayloadJson("Planet", dataName, dictionary);
										}
										string content3 = ListToString(source.Cast<object>().ToList());
										return new JProperty(dataName, content3);
									}
									JArray content4 = DasaEvent.ToJsonList(eventList);
									return new JProperty(dataName, content4);
								}
								JArray content5 = ListToJson(itemList);
								return new JProperty(dataName, content5);
							}
							JArray content6 = PlanetName.ToJsonList(planetNameList);
							return new JProperty(dataName, content6);
						}
						return HoroscopePrediction.ToJsonList(predictionList);
					}
					JToken content7 = APIFunctionResult.ToJsonList(apiFunctionResultList);
					return new JProperty(dataName, content7);
				}
				JArray jArray3 = new JArray();
				foreach (Tuple<Time, Time, ZodiacName, PlanetName> item8 in list2)
				{
					JObject item3 = new JObject
					{
						{
							"Start",
							item8.Item1.ToJson()
						},
						{
							"End",
							item8.Item2.ToJson()
						},
						{
							"ZodiacSign",
							item8.Item3.ToString()
						},
						{
							"Planet",
							item8.Item4.ToString()
						}
					};
					jArray3.Add(item3);
				}
				return new JProperty(dataName, jArray3);
			}
			JArray jArray4 = new JArray();
			foreach (House item9 in list)
			{
				JObject item4 = new JObject
				{
					{
						"House",
						item9.GetHouseName().ToString()
					},
					{
						"Begin",
						item9.GetBeginLongitude().ToString()
					},
					{
						"Mid",
						item9.GetMiddleLongitude().ToString()
					},
					{
						"End",
						item9.GetEndLongitude().ToString()
					}
				};
				jArray4.Add(item4);
			}
			return new JProperty(dataName, jArray4);
		}
		return new JProperty(dataName, content);
	}

	public static DataTable AnyToDataTable(string dataName, dynamic anyTypeData)
	{
		DataTable dataTable = new DataTable();
		if (!(anyTypeData is List<HoroscopePrediction> list))
		{
			if (!(anyTypeData is IList list2))
			{
				if (!(anyTypeData is Dictionary<PlanetName, ZodiacSign> dictionary))
				{
					if (!(anyTypeData is Dictionary<PlanetName, Angle> dictionary2))
					{
						if (!(anyTypeData is Dictionary<PlanetName, PlanetName> dictionary3))
						{
							if (!(anyTypeData is Dictionary<PlanetName, ZodiacName> dictionary4))
							{
								if (!(anyTypeData is Dictionary<PlanetName, Constellation> dictionary5))
								{
									if (!(anyTypeData is Dictionary<PlanetName, HouseName> dictionary6))
									{
										if (!(anyTypeData is Dictionary<string, object> dictionary7))
										{
											if (!(anyTypeData is Dictionary<HouseName, Angle> dictionary8))
											{
												if (!(anyTypeData is Dictionary<HouseName, ZodiacSign> dictionary9))
												{
													if (!(anyTypeData is Dictionary<HouseName, PlanetName> dictionary10))
													{
														if (!(anyTypeData is Dictionary<HouseName, ZodiacName> dictionary11))
														{
															if (!(anyTypeData is Dictionary<HouseName, Constellation> dictionary12))
															{
																if (!(anyTypeData is Dictionary<HouseName, IList> dictionary13))
																{
																	if (anyTypeData is IToJson)
																	{
																	}
																}
																else
																{
																	DictionaryToDataTable(dictionary13, dataTable);
																}
															}
															else
															{
																DictionaryToDataTable(dictionary12, dataTable);
															}
														}
														else
														{
															DictionaryToDataTable(dictionary11, dataTable);
														}
													}
													else
													{
														DictionaryToDataTable(dictionary10, dataTable);
													}
												}
												else
												{
													DictionaryToDataTable(dictionary9, dataTable);
												}
											}
											else
											{
												DictionaryToDataTable(dictionary8, dataTable);
											}
										}
										else
										{
											DictionaryToDataTable(dictionary7, dataTable);
										}
									}
									else
									{
										DictionaryToDataTable(dictionary6, dataTable);
									}
								}
								else
								{
									DictionaryToDataTable(dictionary5, dataTable);
								}
							}
							else
							{
								DictionaryToDataTable(dictionary4, dataTable);
							}
						}
						else
						{
							DictionaryToDataTable(dictionary3, dataTable);
						}
					}
					else
					{
						DictionaryToDataTable(dictionary2, dataTable);
					}
				}
				else
				{
					DictionaryToDataTable(dictionary, dataTable);
				}
			}
			else
			{
				foreach (object item in list2)
				{
					dataTable.Rows.Add(item.ToString());
				}
			}
		}
		else
		{
			dataTable.Columns.Add("Column1", typeof(string));
			dataTable.Columns.Add("Column2", typeof(string));
			dataTable.Columns.Add("Column3", typeof(string));
			foreach (HoroscopePrediction item2 in list)
			{
				dataTable.Rows.Add(item2.ToDataRow());
			}
		}
		return dataTable;
	}

	public static void DictionaryToDataTable<T, Y>(Dictionary<T, Y> dictionary, DataTable table)
	{
		string name = dictionary.First().Key.GetType().Name;
		table.Columns.Add(name);
		Y value = dictionary.First().Value;
		if (value is List<APIFunctionResult> list)
		{
			foreach (APIFunctionResult item in list)
			{
				table.Columns.Add(item.Name);
			}
		}
		else
		{
			string name2 = value.GetType().Name;
			table.Columns.Add(name2);
		}
		foreach (KeyValuePair<T, Y> item2 in dictionary)
		{
			T key = item2.Key;
			Y value2 = item2.Value;
			if (value2 is List<APIFunctionResult> list2)
			{
				List<object> list3 = new List<object>();
				foreach (APIFunctionResult item3 in list2)
				{
					object result = item3.Result;
					list3.Add(AnyToString(result));
				}
				table.Rows.Add(list3.ToArray());
			}
			else if (value2 is IList source)
			{
				string text = string.Join(",", source.Cast<object>());
				table.Rows.Add(key, text);
			}
			else
			{
				table.Rows.Add(key.ToString(), value2.ToString());
			}
		}
	}

	private static JProperty RootPayloadJson(string keyColumn, string dataName, dynamic dictionary)
	{
		JArray jArray = new JArray();
		foreach (dynamic item2 in dictionary)
		{
			JObject jObject = new JObject();
			jObject.Add(keyColumn, item2.Key.ToString());
			jObject.Add(dataName, item2.Value.ToString());
			JObject item = jObject;
			jArray.Add(item);
		}
		return new JProperty(dataName, jArray);
	}

	public static string AnyToString(object result)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!(result is IList source))
		{
			if (!(result is Enum obj))
			{
				if (!(result is Dictionary<PlanetName, ZodiacName> dict))
				{
					if (!(result is Dictionary<PlanetName, ZodiacSign> dict2))
					{
						if (!(result is Dictionary<PlanetName, Constellation> dict3))
						{
							if (!(result is Dictionary<PlanetName, Dictionary<ZodiacName, int>> dictionary))
							{
								if (!(result is Dictionary<ZodiacName, int> dict4))
								{
									if (result is Dictionary<PlanetName, double> dict5)
									{
										AppendDictionary(stringBuilder, dict5);
									}
									else
									{
										stringBuilder.Append(result.ToString());
									}
								}
								else
								{
									AppendDictionary(stringBuilder, dict4);
								}
							}
							else
							{
								foreach (KeyValuePair<PlanetName, Dictionary<ZodiacName, int>> item in dictionary)
								{
									StringBuilder stringBuilder2 = stringBuilder;
									StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder2);
									handler.AppendFormatted(item.Key);
									handler.AppendLiteral(": ");
									handler.AppendFormatted(AnyToString(item.Value));
									handler.AppendLiteral(", ");
									stringBuilder2.Append(ref handler);
								}
							}
						}
						else
						{
							AppendDictionary(stringBuilder, dict3);
						}
					}
					else
					{
						AppendDictionary(stringBuilder, dict2);
					}
				}
				else
				{
					AppendDictionary(stringBuilder, dict);
				}
			}
			else
			{
				stringBuilder.Append(obj.ToString());
			}
		}
		else
		{
			stringBuilder.Append(string.Join(", ", source.Cast<object>()));
		}
		return stringBuilder.ToString();
	}

	private static void AppendDictionary<TKey, TValue>(StringBuilder sb, Dictionary<TKey, TValue> dict)
	{
		foreach (KeyValuePair<TKey, TValue> item in dict)
		{
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, sb);
			handler.AppendFormatted(item.Key);
			handler.AppendLiteral(": ");
			handler.AppendFormatted(item.Value);
			handler.AppendLiteral(", ");
			sb.Append(ref handler);
		}
	}

	public static string QuoteValue(object value)
	{
		string text = value?.ToString() ?? string.Empty;
		text = text.Replace("\"", "\"\"");
		return "\"" + text + "\"";
	}

	public static string StringToMimeType(string fileFormat)
	{
		return fileFormat.ToLower() switch
		{
			"pdf" => "application/pdf", 
			"xml" => "application/xml", 
			"gif" => "image/gif", 
			"jpeg" => "image/jpeg", 
			"jpg" => "image/jpeg", 
			"tiff" => "image/tiff", 
			_ => throw new Exception("END OF LINE"), 
		};
	}

	public static JArray ListToJson<T>(List<T> itemList)
	{
		JArray jArray = new JArray();
		foreach (T item3 in itemList)
		{
			if (item3 is XElement xElement)
			{
				JObject item = XmlToJson(xElement);
				jArray.Add(item);
			}
			else if (item3 is IToJson toJson)
			{
				jArray.Add(toJson.ToJson());
			}
			else if (item3 is JObject item2)
			{
				jArray.Add(item2);
			}
			else
			{
				jArray.Add(item3.ToString());
			}
		}
		return jArray;
	}

	public static string[] GetUserIdFromData(XElement inputXml)
	{
		return (inputXml.Element("UserId")?.Value ?? "").Replace("\n", "").Replace(" ", "").Split(',');
	}

	public static string[] GetUserIdFromData(JToken input)
	{
		return input["UserId"].Value<string>().Replace("\n", "").Replace(" ", "")
			.Split(',');
	}

	public static List<XElement> FindXmlByUserId(XDocument allListXmlDoc, string inputUserId)
	{
		List<XElement> list = new List<XElement>();
		foreach (XElement item in allListXmlDoc.Root?.Elements())
		{
			if (IsUserIdMatch(item.Element("UserId")?.Value ?? "", inputUserId))
			{
				list.Add(item);
			}
		}
		return list;
	}

	public static bool IsUserIdMatch(string userIdStringA, string userIdStringB)
	{
		string[] array = userIdStringA.Split(',');
		string[] array2 = userIdStringB.Split(',');
		string[] array3 = array;
		foreach (string text in array3)
		{
			string[] array4 = array2;
			foreach (string text2 in array4)
			{
				if (text.ToLower() == text2.ToLower())
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool IsWithinLastHour(Time logItemTime, double hours)
	{
		DateTimeOffset dateTimeOffset = DateTimeOffset.Now.AddHours(hours);
		return logItemTime.GetStdDateTimeOffset() >= dateTimeOffset;
	}

	public static async Task<bool> DoesFileExist(string url)
	{
		HttpClient httpClient = new HttpClient();
		using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url);
		using HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
		return httpResponseMessage.StatusCode == HttpStatusCode.OK;
	}

	public static string TimeZoneToLocation(string timeZone)
	{
		return "Earth";
	}

	public static async Task<T> ReadServerRaw<T>(string receiverAddress)
	{
		HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, receiverAddress);
		HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead;
		using HttpClient client = new HttpClient();
		client.Timeout = Timeout.InfiniteTimeSpan;
		HttpResponseMessage httpResponseMessage = await client.SendAsync(request, completionOption);
		if (typeof(T) == typeof(byte[]))
		{
			return (T)(object)(await httpResponseMessage.Content.ReadAsByteArrayAsync());
		}
		string text = await httpResponseMessage.Content.ReadAsStringAsync();
		if (typeof(T) == typeof(string))
		{
			return (T)(object)text;
		}
		if (typeof(T) == typeof(JObject))
		{
			return (T)(object)JObject.Parse(text);
		}
		throw new InvalidOperationException("Unsupported type parameter");
	}

	public static async Task<T> WriteServer<T, Z>(HttpMethod method, string receiverAddress, Z payload = default(Z))
	{
		HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, receiverAddress);
		HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead;
		if (payload != null)
		{
			if (payload is JToken data)
			{
				httpRequestMessage.Content = JsontoHttpContent(data);
			}
			else
			{
				if (!(payload is byte[] content))
				{
					throw new ArgumentException("Payload must be either a JToken or a byte array.", "payload");
				}
				httpRequestMessage.Content = new ByteArrayContent(content);
			}
		}
		using HttpClient client = new HttpClient();
		client.Timeout = Timeout.InfiniteTimeSpan;
		HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage, completionOption);
		if (typeof(T) == typeof(byte[]))
		{
			return (T)(object)(await httpResponseMessage.Content.ReadAsByteArrayAsync());
		}
		string text = await httpResponseMessage.Content.ReadAsStringAsync();
		if (typeof(T) == typeof(string))
		{
			return (T)(object)text;
		}
		if (typeof(T) == typeof(JObject))
		{
			return (T)(object)JObject.Parse(text);
		}
		throw new InvalidOperationException("Unsupported type parameter");
	}

	public static MethodInfo MethodNameToMethodInfo(string methodName, Type[] calculatorClass)
	{
		for (int i = 0; i < calculatorClass.Length; i++)
		{
			IEnumerable<MethodInfo> enumerable = from x in calculatorClass[i].GetMethods()
				where x.Name == methodName
				select x;
			MethodInfo methodInfo = enumerable?.FirstOrDefault();
			if (methodInfo != null)
			{
				if (enumerable.Count() > 1)
				{
					Console.WriteLine("POTENTIAL ERROR: Duplicate API Names : " + methodName);
				}
				return methodInfo;
			}
		}
		throw new Exception("Calculator method not found!");
	}

	public static Person GetPersonById(string personId, string ownerId = "")
	{
		Pageable<PersonListEntity> pageable = null;
		pageable = ((!string.IsNullOrEmpty(ownerId)) ? AzureTable.PersonList_Indic.Query((PersonListEntity row) => row.PartitionKey == ownerId && row.RowKey == personId) : AzureTable.PersonList_Indic.Query((PersonListEntity row) => row.RowKey == personId));
		if (!pageable.Any() && AzureTable.PersonShareList.Query((PersonListEntity row) => row.PartitionKey == ownerId && row.RowKey == personId).Any())
		{
			pageable = AzureTable.PersonList_Indic.Query((PersonListEntity row) => row.RowKey == personId);
		}
		if (pageable.Count() > 1)
		{
			LibLogger.Debug("More than 1 Person found : PersonId -> " + personId + " OwnerId -> " + ownerId);
		}
		if (!pageable.Any())
		{
			LibLogger.Debug($"Person NOT FOUND : {personId} OwnerID :{ownerId}, EMPTY GIVEN");
			return Person.Empty;
		}
		return Person.FromAzureRow(pageable.FirstOrDefault());
	}

	public static async Task<Person> GetPersonByIdViaAPI(string personId, string ownerId)
	{
		return GetPayload(await ReadServerRaw<JObject>($"{"https://vedastroapi.azurewebsites.net/api"}/GetPerson/OwnerId/{ownerId}/PersonId/{personId}"), Person.FromJson);
	}

	public static async Task<XDocument> GetXmlFileFromAzureStorage(string fileName, string blobContainerName)
	{
		return await DownloadToXDoc(await GetBlobClientAzure(fileName, blobContainerName));
	}

	public static async Task<XDocument> DownloadToXDoc(BlobClient blobClient)
	{
		if ((await blobClient.ExistsAsync()).Value)
		{
			XDocument xDoc;
			await using (Stream stream = (await blobClient.DownloadStreamingAsync()).Value.Content)
			{
				xDoc = await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);
			}
			return xDoc;
		}
		throw new Exception("No File in Cloud! : " + blobClient.Name);
	}

	public static async Task<BlobClient> GetBlobClientAzure(string fileName, string blobContainerName)
	{
		return new BlobContainerClient(Secrets.API_STORAGE, blobContainerName).GetBlobClient(fileName);
	}

	public static string CutOutString(string input, int cutCount)
	{
		IEnumerable<string> values = input.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries).Take(cutCount);
		return "/" + string.Join("/", values) + "/";
	}

	public static string CutRemoveString(string input, int cutCount)
	{
		IEnumerable<string> values = input.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries).Skip(cutCount);
		return "/" + string.Join("/", values) + "/";
	}

	public static int LevenshteinDistance(string a, string b)
	{
		int[,] array = new int[a.Length + 1, b.Length + 1];
		for (int i = 0; i <= a.Length; i++)
		{
			array[i, 0] = i;
		}
		for (int j = 0; j <= b.Length; j++)
		{
			array[0, j] = j;
		}
		for (int k = 1; k <= a.Length; k++)
		{
			for (int l = 1; l <= b.Length; l++)
			{
				int num = ((a[k - 1] != b[l - 1]) ? 1 : 0);
				array[k, l] = Math.Min(Math.Min(array[k - 1, l] + 1, array[k, l - 1] + 1), array[k - 1, l - 1] + num);
			}
		}
		return array[a.Length, b.Length];
	}

	public static string GeneratePythonDef(MethodInfo methodInfo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string name = methodInfo.Name;
		stringBuilder.Append("def ");
		stringBuilder.Append(name);
		stringBuilder.Append("(");
		ParameterInfo[] parameters = methodInfo.GetParameters();
		if (parameters.Length == 0)
		{
			stringBuilder.Append("cls");
		}
		else
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				stringBuilder.Append(parameterInfo.Name);
				stringBuilder.Append(": ");
				string text = (parameterInfo.ParameterType.Name.Contains("`") ? "Any" : parameterInfo.ParameterType.Name);
				text = text.Replace("[", "").Replace("]", "");
				stringBuilder.Append(text);
				if (i < parameters.Length - 1)
				{
					stringBuilder.Append(", ");
				}
			}
		}
		stringBuilder.Append(")");
		Type returnType = methodInfo.ReturnType;
		if (returnType.Name.Contains("`"))
		{
			stringBuilder.Append(" -> Any");
		}
		else
		{
			stringBuilder.Append(" -> ");
			string value = returnType.Name.Replace("[", "").Replace("]", "");
			stringBuilder.Append(value);
		}
		stringBuilder.Append(":");
		return stringBuilder.ToString();
	}

	public static string GetSpecialMLTableName(dynamic openApiMetadata, object resultOverride = null)
	{
		if (openApiMetadata.SelectedParams == null)
		{
			return string.Format("{0}_{1}", (object?)openApiMetadata.Name, resultOverride?.ToString() ?? "PLEASE INJECT VALUE");
		}
		string text = "";
		foreach (dynamic item in openApiMetadata.SelectedParams)
		{
			if (item is Time)
			{
				continue;
			}
			if (item is IList list)
			{
				foreach (object item2 in list)
				{
					if (!(item2 is Time))
					{
						string text2 = AnyToString(item2);
						text = text + "_" + text2;
					}
				}
			}
			else
			{
				dynamic val = Tools.AnyToString(item);
				text += "_" + val;
			}
		}
		return $"{(object?)openApiMetadata.Name}{text}";
	}

	public static dynamic ephemeris_swe_calc(Time time, int swissPlanet)
	{
		int iflag = 2;
		double[] array = new double[6];
		string serr = "";
		SwissEph swissEph = new SwissEph();
		double tjd = Calculate.TimeToEphemerisTime(time);
		swissEph.swe_calc(tjd, swissPlanet, iflag, array, ref serr);
		return new
		{
			Longitude = array[0],
			Latitude = array[1],
			DistanceAU = array[2],
			SpeedLongitude = array[3],
			SpeedLatitude = array[4],
			SpeedDistance = array[5]
		};
	}

	public static void PrintList<T>(List<T> list)
	{
		foreach (T item in list)
		{
			Console.WriteLine(item.ToString());
		}
	}

	public static bool IsMethodReturnAsync(MethodInfo method)
	{
		if (method.ReturnType == typeof(Task) || (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>)))
		{
			return true;
		}
		return false;
	}

	public static string GetCamelCaseWord(string input, int wordPosition = 0)
	{
		if (string.IsNullOrEmpty(input))
		{
			return string.Empty;
		}
		List<string> list = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in input)
		{
			if (char.IsUpper(c) && stringBuilder.Length > 0)
			{
				list.Add(stringBuilder.ToString());
				stringBuilder.Clear();
			}
			stringBuilder.Append(c);
		}
		list.Add(stringBuilder.ToString());
		return list[wordPosition];
	}

	public static string TimeDurationToHumanText(double durationInHours)
	{
		if (!(durationInHours < 24.0))
		{
			double num = durationInHours / 24.0;
			if (!(num < 30.0))
			{
				double num2 = num / 30.0;
				if (!(num2 < 12.0))
				{
					double value = num2 / 12.0;
					return $"{Math.Round(value, 1)} years";
				}
				return $"{Math.Round(num2, 1)} months";
			}
			return $"{Math.Round(num, 1)} days";
		}
		return $"{Math.Round(durationInHours, 1)} hours";
	}

	public static string BytesToHumanText(long bytes)
	{
		string[] array = new string[5] { "B", "KB", "MB", "GB", "TB" };
		int num = 0;
		while (bytes >= 1024 && num < array.Length - 1)
		{
			num++;
			bytes /= 1024;
		}
		return $"{bytes:0.##} {array[num]}";
	}

	public static T GetPayload<T>(JToken rawResult, Func<JToken, T>? parser)
	{
		bool num = rawResult["Status"]?.Value<string>() == "Pass";
		JToken jToken = rawResult["Payload"] ?? new JObject();
		if (num)
		{
			if (parser != null)
			{
				return parser(jToken);
			}
			return jToken.Value<T>();
		}
		throw new Exception("Failed to get " + typeof(T).AssemblyQualifiedName + " from API payload");
	}

	public static byte[] DataTableToJpeg(DataTable table)
	{
		Bitmap image = new Bitmap(1, 1);
		Graphics graphics = Graphics.FromImage(image);
		int[] array = new int[table.Columns.Count];
		for (int i = 0; i < table.Columns.Count; i++)
		{
			Font font = new Font("Arial", 10f, FontStyle.Bold);
			array[i] = (int)graphics.MeasureString(table.Columns[i].ColumnName, font).Width;
			for (int j = 0; j < table.Rows.Count; j++)
			{
				Font font2 = new Font("Arial", 10f);
				SizeF sizeF = graphics.MeasureString(table.Rows[j][i].ToString(), font2);
				array[i] = Math.Max(array[i], (int)sizeF.Width);
			}
		}
		graphics.Dispose();
		image = new Bitmap(array.Sum() + table.Columns.Count * 2, (table.Rows.Count + 1) * 20);
		graphics = Graphics.FromImage(image);
		int num = 0;
		for (int k = 0; k < table.Columns.Count; k++)
		{
			graphics.FillRectangle(Brushes.White, new Rectangle(num, 0, array[k] + 2, 20));
			graphics.DrawRectangle(Pens.Black, new Rectangle(num, 0, array[k] + 2, 20));
			Font font3 = new Font("Arial", 10f, FontStyle.Bold);
			graphics.DrawString(table.Columns[k].ColumnName, font3, Brushes.Black, new PointF(num + 3, 1f));
			for (int l = 0; l < table.Rows.Count; l++)
			{
				graphics.FillRectangle(Brushes.White, new Rectangle(num, (l + 1) * 20, array[k] + 2, 20));
				graphics.DrawRectangle(Pens.Black, new Rectangle(num, (l + 1) * 20, array[k] + 2, 20));
				Font font4 = new Font("Arial", 10f);
				graphics.DrawString(table.Rows[l][k].ToString(), font4, Brushes.Black, new PointF(num + 3, (l + 1) * 20 + 1));
			}
			num += array[k] + 2;
		}
		using MemoryStream memoryStream = new MemoryStream();
		image.Save(memoryStream, ImageFormat.Jpeg);
		return memoryStream.ToArray();
	}

	public static DataTable ConvertJPropertyToDataTable(JProperty jProperty)
	{
		DataTable dataTable = new DataTable();
		bool flag = true;
		foreach (JObject item in (IEnumerable<JToken>)jProperty.Value)
		{
			DataRow dataRow = dataTable.NewRow();
			foreach (JProperty item2 in item.Properties())
			{
				if (flag)
				{
					dataTable.Columns.Add(item2.Name, typeof(string));
				}
				dataRow[item2.Name] = (string?)item2.Value;
			}
			dataTable.Rows.Add(dataRow);
			flag = false;
		}
		return dataTable;
	}

	public static async Task<JToken> MakePostRequest(string url, string jsonData)
	{
		using HttpClient client = new HttpClient();
		StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
		HttpRequestMessage request = new HttpRequestMessage
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(url),
			Content = content
		};
		client.Timeout = TimeSpan.FromMinutes(10.0);
		return JToken.Parse(await (await client.SendAsync(request)).Content.ReadAsStringAsync());
	}

	public static async Task<List<T>> GetListNoPolling<T>(string inputUrl, Func<JToken, List<T>> converter)
	{
		JToken arg = (await ReadServerRaw<JObject>(inputUrl))[(object)"Payload"];
		return converter(arg);
	}

	public static void PasswordProtect(string inputPassword)
	{
		if (inputPassword != Secrets.Password)
		{
			throw new ArgumentException("Invalid password");
		}
	}

	public static async Task<string> GetIPAddress()
	{
		try
		{
			return await ReadServerRaw<string>("https://api.ipify.org");
		}
		catch (WebException innerException)
		{
			throw new Exception("Failed to connect to external endpoint.", innerException);
		}
	}

	public static string CleanAzureTableKey(string input, string newValue = "")
	{
		char[] array = new char[4] { '/', '\\', '#', '?' };
		foreach (char c in array)
		{
			input = input.Replace(c.ToString(), newValue);
		}
		input = new string(input.Where((char ch) => !char.IsControl(ch)).ToArray());
		return input;
	}

	public static double[] ConvertStringToDoubleArray(string input)
	{
		string[] array = input.Trim('[', ']').Split(',');
		double[] array2 = new double[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			if (double.TryParse(array[i], NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
			{
				array2[i] = result;
				continue;
			}
			throw new ArgumentException($"Invalid value at index {i}: {array[i]}");
		}
		return array2;
	}
}
