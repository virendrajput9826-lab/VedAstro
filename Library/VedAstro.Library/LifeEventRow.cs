using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class LifeEventRow : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public string StartTime { get; set; }

	public string Nature { get; set; }

	public string Weight { get; set; }
}
