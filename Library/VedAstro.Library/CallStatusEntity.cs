using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class CallStatusEntity : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public bool IsRunning { get; set; }
}
