using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class FailStatisticEntity : ITableEntity
{
	public static FailStatisticEntity Empty = new FailStatisticEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public double CallCount { get; set; }

	public string MetadataHash { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }
}
