using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class AddressGeoLocationEntity : ITableEntity
{
	public static AddressGeoLocationEntity Empty = new AddressGeoLocationEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public double Longitude { get; set; }

	public double Latitude { get; set; }

	public string MetadataHash { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public GeoLocation ToGeoLocation()
	{
		try
		{
			if (string.IsNullOrEmpty(PartitionKey))
			{
				return GeoLocation.Empty;
			}
			return new GeoLocation(PartitionKey, Longitude, Latitude);
		}
		catch (Exception)
		{
			return GeoLocation.Empty;
		}
	}
}
