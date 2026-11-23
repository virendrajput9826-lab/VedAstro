using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class APIAbuseRow : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; } = Tools.GenerateId();

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }
}
