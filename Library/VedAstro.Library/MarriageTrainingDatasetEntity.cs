using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class MarriageTrainingDatasetEntity : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; } = "";

	public string Outcome { get; set; }

	public string MarriageDate { get; set; }

	public string ChildrenData { get; set; }

	public string DivorceData { get; set; }

	public string DivorceDate { get; set; }

	public string MalePersonId { get; set; }

	public string FemalePersonId { get; set; }

	public string Embeddings { get; set; }

	public double KutaScore { get; set; }

	public double MarriageDuration { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public double[] GetEmbeddingsArray()
	{
		return Tools.ConvertStringToDoubleArray(Embeddings);
	}
}
