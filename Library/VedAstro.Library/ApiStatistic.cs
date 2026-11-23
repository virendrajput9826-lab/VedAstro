using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker.Http;

namespace VedAstro.Library;

public static class ApiStatistic
{
	public record GeoLocationRawAPI(dynamic MainRow, dynamic MetadataRow);

	private static readonly TableServiceClient ipAddressServiceClient;

	private static readonly TableServiceClient webPageServiceClient;

	private static readonly TableServiceClient requestUrlStatisticServiceClient;

	private static readonly TableServiceClient subscriberStatisticServiceClient;

	private static readonly TableServiceClient userAgentStatisticServiceClient;

	private static readonly TableServiceClient rawRequestStatisticServiceClient;

	private static readonly TableClient ipAddressStatisticTableClient;

	private static readonly TableClient webPageStatisticTableClient;

	private static readonly TableClient requestUrlStatisticTableClient;

	private static readonly TableClient subscriberStatisticTableClient;

	private static readonly TableClient userAgentStatisticTableClient;

	private static readonly TableClient rawRequestStatisticTableClient;

	static ApiStatistic()
	{
		string text = "centralapistorage";
		string text2 = "RawRequestStatistic";
		rawRequestStatisticServiceClient = new TableServiceClient(new Uri("https://" + text + ".table.core.windows.net/" + text2), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		rawRequestStatisticTableClient = rawRequestStatisticServiceClient.GetTableClient(text2);
		string text3 = "RequestUrlStatistic";
		requestUrlStatisticServiceClient = new TableServiceClient(new Uri("https://" + text + ".table.core.windows.net/" + text3), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		requestUrlStatisticTableClient = requestUrlStatisticServiceClient.GetTableClient(text3);
		string text4 = "SubscriberStatistic";
		subscriberStatisticServiceClient = new TableServiceClient(new Uri("https://" + text + ".table.core.windows.net/" + text4), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		subscriberStatisticTableClient = subscriberStatisticServiceClient.GetTableClient(text4);
		string text5 = "UserAgentStatistic";
		userAgentStatisticServiceClient = new TableServiceClient(new Uri("https://" + text + ".table.core.windows.net/" + text5), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		userAgentStatisticTableClient = userAgentStatisticServiceClient.GetTableClient(text5);
		string text6 = "IpAddressStatistic";
		ipAddressServiceClient = new TableServiceClient(new Uri("https://" + text + ".table.core.windows.net/" + text6), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		ipAddressStatisticTableClient = ipAddressServiceClient.GetTableClient(text6);
		string text7 = "WebPageStatistic";
		webPageServiceClient = new TableServiceClient(new Uri("https://" + text + ".table.core.windows.net/" + text7), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		webPageStatisticTableClient = webPageServiceClient.GetTableClient(text7);
	}

	public static void LogIpAddress(HttpRequestData incomingRequest)
	{
		string todayRecord = DateTime.Now.ToString("yyyy-MM");
		string ipAddress = incomingRequest?.GetCallerIp()?.ToString() ?? "0.0.0.0";
		Expression<Func<IpAddressStatisticEntity, bool>> filter = (IpAddressStatisticEntity call) => call.PartitionKey == ipAddress && call.RowKey == todayRecord;
		IpAddressStatisticEntity ipAddressStatisticEntity = ipAddressStatisticTableClient.Query(filter).FirstOrDefault();
		if (ipAddressStatisticEntity != null)
		{
			if (!ipAddressStatisticEntity.PerSecondTimestamp.HasValue || (DateTimeOffset.UtcNow - ipAddressStatisticEntity.PerSecondTimestamp.Value).TotalSeconds >= 60.0)
			{
				ipAddressStatisticEntity.CallsPerSecond = 1.0;
				ipAddressStatisticEntity.PerSecondTimestamp = DateTimeOffset.UtcNow;
			}
			else
			{
				ipAddressStatisticEntity.CallsPerSecond++;
			}
			if (!ipAddressStatisticEntity.PerMinuteTimestamp.HasValue || (DateTimeOffset.UtcNow - ipAddressStatisticEntity.PerMinuteTimestamp.Value).TotalMinutes >= 1.0)
			{
				ipAddressStatisticEntity.CallsPerMinute = ipAddressStatisticEntity.CallsPerSecond;
				ipAddressStatisticEntity.CallsPerSecond = 0.0;
				ipAddressStatisticEntity.PerSecondTimestamp = null;
				ipAddressStatisticEntity.PerMinuteTimestamp = DateTimeOffset.UtcNow;
			}
			else
			{
				ipAddressStatisticEntity.CallsPerMinute += ipAddressStatisticEntity.CallsPerSecond;
				ipAddressStatisticEntity.CallsPerSecond = 0.0;
			}
			if (!ipAddressStatisticEntity.PerHourTimestamp.HasValue || (DateTimeOffset.UtcNow - ipAddressStatisticEntity.PerHourTimestamp.Value).TotalHours >= 1.0)
			{
				ipAddressStatisticEntity.CallsPerHour = ipAddressStatisticEntity.CallsPerMinute;
				ipAddressStatisticEntity.CallsPerMinute = 0.0;
				ipAddressStatisticEntity.PerMinuteTimestamp = null;
				ipAddressStatisticEntity.PerHourTimestamp = DateTimeOffset.UtcNow;
			}
			else
			{
				ipAddressStatisticEntity.CallsPerHour += ipAddressStatisticEntity.CallsPerMinute;
				ipAddressStatisticEntity.CallsPerMinute = 0.0;
			}
			if (!ipAddressStatisticEntity.PerDayTimestamp.HasValue || (DateTimeOffset.UtcNow - ipAddressStatisticEntity.PerDayTimestamp.Value).TotalDays >= 1.0)
			{
				ipAddressStatisticEntity.CallsPerDay = ipAddressStatisticEntity.CallsPerHour;
				ipAddressStatisticEntity.CallsPerHour = 0.0;
				ipAddressStatisticEntity.PerHourTimestamp = null;
				ipAddressStatisticEntity.PerDayTimestamp = DateTimeOffset.UtcNow;
			}
			else
			{
				ipAddressStatisticEntity.CallsPerDay += ipAddressStatisticEntity.CallsPerHour;
				ipAddressStatisticEntity.CallsPerHour = 0.0;
			}
			if (!ipAddressStatisticEntity.PerMonthTimestamp.HasValue || (DateTimeOffset.UtcNow - ipAddressStatisticEntity.PerMonthTimestamp.Value).TotalDays >= (double)DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month))
			{
				ipAddressStatisticEntity.CallsPerMonth = ipAddressStatisticEntity.CallsPerDay;
				ipAddressStatisticEntity.CallsPerDay = 0.0;
				ipAddressStatisticEntity.PerDayTimestamp = null;
				ipAddressStatisticEntity.PerMonthTimestamp = DateTimeOffset.UtcNow;
			}
			else
			{
				ipAddressStatisticEntity.CallsPerMonth += ipAddressStatisticEntity.CallsPerDay;
				ipAddressStatisticEntity.CallsPerDay = 0.0;
			}
			ipAddressStatisticTableClient.UpsertEntityAsync(ipAddressStatisticEntity);
		}
		else
		{
			IpAddressStatisticEntity ipAddressStatisticEntity2 = new IpAddressStatisticEntity();
			ipAddressStatisticEntity2.PartitionKey = Tools.CleanAzureTableKey(ipAddress);
			ipAddressStatisticEntity2.RowKey = todayRecord;
			ipAddressStatisticTableClient.AddEntity(ipAddressStatisticEntity2);
		}
	}

	public static void LogWebPage(string webPage)
	{
		string todayRecord = DateTime.Now.ToString("yyyy-MM");
		string cleanWebPageUrl = Tools.CleanAzureTableKey(webPage);
		Expression<Func<WebPageStatisticEntity, bool>> filter = (WebPageStatisticEntity call) => call.PartitionKey == cleanWebPageUrl && call.RowKey == todayRecord;
		WebPageStatisticEntity webPageStatisticEntity = webPageStatisticTableClient.Query(filter).FirstOrDefault();
		if (webPageStatisticEntity != null)
		{
			webPageStatisticEntity.CallCount = ++webPageStatisticEntity.CallCount;
			webPageStatisticTableClient.UpsertEntity(webPageStatisticEntity);
			return;
		}
		WebPageStatisticEntity webPageStatisticEntity2 = new WebPageStatisticEntity();
		webPageStatisticEntity2.PartitionKey = cleanWebPageUrl;
		webPageStatisticEntity2.RowKey = todayRecord;
		webPageStatisticEntity2.CallCount = 1.0;
		webPageStatisticTableClient.AddEntity(webPageStatisticEntity2);
	}

	public static void LogRequestUrl(HttpRequestData incomingRequest)
	{
		string input = incomingRequest?.Url.AbsolutePath ?? "no URL";
		string todayRecord = DateTime.Now.ToString("yyyy-MM");
		string cleanAzureTableKey = Tools.CleanAzureTableKey(input, "-").Truncate(100);
		Expression<Func<RequestUrlStatisticEntity, bool>> filter = (RequestUrlStatisticEntity call) => call.PartitionKey == cleanAzureTableKey && call.RowKey == todayRecord;
		RequestUrlStatisticEntity requestUrlStatisticEntity = requestUrlStatisticTableClient.Query(filter).FirstOrDefault();
		if (requestUrlStatisticEntity != null)
		{
			requestUrlStatisticEntity.CallCount = ++requestUrlStatisticEntity.CallCount;
			requestUrlStatisticTableClient.UpsertEntity(requestUrlStatisticEntity);
			return;
		}
		RequestUrlStatisticEntity requestUrlStatisticEntity2 = new RequestUrlStatisticEntity();
		requestUrlStatisticEntity2.PartitionKey = cleanAzureTableKey;
		requestUrlStatisticEntity2.RowKey = todayRecord;
		requestUrlStatisticEntity2.CallCount = 1.0;
		requestUrlStatisticTableClient.AddEntity(requestUrlStatisticEntity2);
	}

	public static void LogSubscriber(HttpRequestData incomingRequest)
	{
		string input = incomingRequest.ExtractHostAddress();
		string currentDate = DateTime.Now.ToString("yyyy-MM");
		string cleanHostAddress = Tools.CleanAzureTableKey(input, "|");
		Expression<Func<RequestUrlStatisticEntity, bool>> filter = (RequestUrlStatisticEntity call) => call.PartitionKey == cleanHostAddress && call.RowKey == currentDate;
		RequestUrlStatisticEntity requestUrlStatisticEntity = subscriberStatisticTableClient.Query(filter).FirstOrDefault();
		if (requestUrlStatisticEntity != null)
		{
			requestUrlStatisticEntity.CallCount = ++requestUrlStatisticEntity.CallCount;
			subscriberStatisticTableClient.UpsertEntity(requestUrlStatisticEntity);
			return;
		}
		SubscriberStatisticEntity subscriberStatisticEntity = new SubscriberStatisticEntity();
		subscriberStatisticEntity.PartitionKey = cleanHostAddress;
		subscriberStatisticEntity.RowKey = currentDate;
		subscriberStatisticEntity.CallCount = 1.0;
		subscriberStatisticTableClient.AddEntity(subscriberStatisticEntity);
	}

	public static void LogUserAgent(HttpRequestData incomingRequest)
	{
		incomingRequest.Headers.ToDictionary<KeyValuePair<string, IEnumerable<string>>, string, IEnumerable<string>>((KeyValuePair<string, IEnumerable<string>> x) => x.Key, (KeyValuePair<string, IEnumerable<string>> x) => x.Value, StringComparer.Ordinal).TryGetValue("User-Agent", out var value);
		string input = value?.FirstOrDefault() ?? "no User-Agent";
		string currentDate = DateTime.Now.ToString("yyyy-MM");
		string cleanUserAgent = Tools.CleanAzureTableKey(input, "|");
		Expression<Func<UserAgentStatisticEntity, bool>> filter = (UserAgentStatisticEntity call) => call.PartitionKey == cleanUserAgent && call.RowKey == currentDate;
		UserAgentStatisticEntity userAgentStatisticEntity = userAgentStatisticTableClient.Query(filter).FirstOrDefault();
		if (userAgentStatisticEntity != null)
		{
			userAgentStatisticEntity.CallCount = ++userAgentStatisticEntity.CallCount;
			userAgentStatisticTableClient.UpsertEntity(userAgentStatisticEntity);
			return;
		}
		UserAgentStatisticEntity userAgentStatisticEntity2 = new UserAgentStatisticEntity();
		userAgentStatisticEntity2.PartitionKey = cleanUserAgent;
		userAgentStatisticEntity2.RowKey = currentDate;
		userAgentStatisticEntity2.CallCount = 1.0;
		userAgentStatisticTableClient.AddEntity(userAgentStatisticEntity2);
	}

	public static void LogRawRequest(HttpRequestData incomingRequest)
	{
		RawRequestStatisticEntity rawRequestStatisticEntity = new RawRequestStatisticEntity();
		Dictionary<string, IEnumerable<string>> dictionary = incomingRequest.Headers.ToDictionary<KeyValuePair<string, IEnumerable<string>>, string, IEnumerable<string>>((KeyValuePair<string, IEnumerable<string>> x) => x.Key, (KeyValuePair<string, IEnumerable<string>> x) => x.Value, StringComparer.Ordinal);
		for (int num = 0; num < dictionary.Count; num++)
		{
			KeyValuePair<string, IEnumerable<string>> keyValuePair = dictionary.ElementAt(num);
			string key = keyValuePair.Key;
			string value = Tools.ListToString(keyValuePair.Value.ToList());
			PropertyInfo[] properties = rawRequestStatisticEntity.GetType().GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				DescriptionAttribute obj = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false).FirstOrDefault();
				if (obj != null && obj.Description.Equals(key, StringComparison.OrdinalIgnoreCase))
				{
					propertyInfo.SetValue(rawRequestStatisticEntity, value);
					break;
				}
			}
		}
		rawRequestStatisticEntity.PartitionKey = incomingRequest?.GetCallerIp()?.ToString() ?? "no ip";
		string input = incomingRequest.Url.ToString() ?? "no URL";
		rawRequestStatisticEntity.RowKey = Tools.CleanAzureTableKey(input, "|");
		rawRequestStatisticTableClient.UpsertEntity(rawRequestStatisticEntity);
	}

	public static void Log(HttpRequestData incomingRequest)
	{
		LogIpAddress(incomingRequest);
		LogRequestUrl(incomingRequest);
		LogSubscriber(incomingRequest);
		LogUserAgent(incomingRequest);
	}
}
