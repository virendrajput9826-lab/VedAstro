using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class GeoLocationTimezoneEntity : ITableEntity
{
	public static GeoLocationTimezoneEntity Empty = new GeoLocationTimezoneEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public string TimezoneText { get; set; }

	public string MetadataHash { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }
}
