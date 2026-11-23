using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class WebPageStatisticEntity : ITableEntity
{
	public static WebPageStatisticEntity Empty = new WebPageStatisticEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public double CallCount { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }
}
