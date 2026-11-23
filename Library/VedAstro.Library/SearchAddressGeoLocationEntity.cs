using System;
using System.Collections.Generic;
using Azure;
using Azure.Data.Tables;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class SearchAddressGeoLocationEntity : ITableEntity
{
	public static SearchAddressGeoLocationEntity Empty = new SearchAddressGeoLocationEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public string Results { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public List<GeoLocation> ToGeoLocationList()
	{
		try
		{
			if (string.IsNullOrEmpty(PartitionKey))
			{
				return new List<GeoLocation>();
			}
			JArray jArray = JArray.Parse(Results);
			List<GeoLocation> list = new List<GeoLocation>();
			foreach (JToken item in jArray)
			{
				list.Add(GeoLocation.FromJson(item));
			}
			return list;
		}
		catch (Exception)
		{
			return new List<GeoLocation>();
		}
	}
}
