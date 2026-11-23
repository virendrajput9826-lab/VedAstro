using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class IpAddressGeoLocationEntity : ITableEntity
{
	public static IpAddressGeoLocationEntity Empty = new IpAddressGeoLocationEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public string LocationName { get; set; }

	public double Longitude { get; set; }

	public double Latitude { get; set; }

	public string MetadataHash { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public GeoLocation ToGeoLocation()
	{
		try
		{
			if (string.IsNullOrEmpty(LocationName))
			{
				return GeoLocation.Empty;
			}
			return new GeoLocation(LocationName, Longitude, Latitude);
		}
		catch (Exception)
		{
			return GeoLocation.Empty;
		}
	}
}
