using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class GeoLocationCoordinatesEntity : ITableEntity
{
	public static GeoLocationCoordinatesEntity Empty = new GeoLocationCoordinatesEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public string Standard_Name { get; set; }

	public double Longitude { get; set; }

	public double Latitude { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }
}
