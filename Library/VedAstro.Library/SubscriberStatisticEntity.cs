using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class SubscriberStatisticEntity : ITableEntity
{
	public static SubscriberStatisticEntity Empty = new SubscriberStatisticEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public double CallCount { get; set; }

	public string MetadataHash { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }
}
