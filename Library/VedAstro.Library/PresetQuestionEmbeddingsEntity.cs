using System;
using System.Linq;
using Azure;
using Azure.Data.Tables;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class PresetQuestionEmbeddingsEntity : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public string Embeddings { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public double[] GetEmbeddingsArray()
	{
		return (from jv in JArray.Parse(Embeddings)
			select (double)jv).ToArray();
	}
}
