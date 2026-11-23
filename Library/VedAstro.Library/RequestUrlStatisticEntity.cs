using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class RequestUrlStatisticEntity : ITableEntity
{
	public static RequestUrlStatisticEntity Empty = new RequestUrlStatisticEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public double CallCount { get; set; }

	public string MetadataHash { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }
}
