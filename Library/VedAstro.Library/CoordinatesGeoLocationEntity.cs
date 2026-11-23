using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class CoordinatesGeoLocationEntity : ITableEntity
{
	public static CoordinatesGeoLocationEntity Empty = new CoordinatesGeoLocationEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public string Name { get; set; }

	public string MetadataHash { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public GeoLocation ToGeoLocation()
	{
		try
		{
			if (string.IsNullOrEmpty(Name))
			{
				return GeoLocation.Empty;
			}
			double latitude = double.Parse(PartitionKey);
			double longitude = double.Parse(RowKey);
			return new GeoLocation(Name, longitude, latitude);
		}
		catch (Exception)
		{
			return GeoLocation.Empty;
		}
	}
}
