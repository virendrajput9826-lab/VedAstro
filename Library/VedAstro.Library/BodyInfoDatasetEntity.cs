using System;
using Azure;
using Azure.Data.Tables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class BodyInfoDatasetEntity : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; } = "";

	public string Info { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public JObject InfoJson()
	{
		return JObject.Parse(Info);
	}

	public bool IsJson()
	{
		try
		{
			JToken.Parse(Info);
			return true;
		}
		catch (JsonReaderException)
		{
			return false;
		}
	}
}
