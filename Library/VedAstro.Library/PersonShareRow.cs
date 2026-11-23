using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class PersonShareRow : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public PersonShareRow(string ownerId, string sharedPersonId)
	{
		PartitionKey = ownerId;
		RowKey = sharedPersonId;
	}
}
