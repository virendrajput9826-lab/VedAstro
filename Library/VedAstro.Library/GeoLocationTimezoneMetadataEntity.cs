using System;
using System.Security.Cryptography;
using System.Text;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class GeoLocationTimezoneMetadataEntity : ITableEntity
{
	public static GeoLocationTimezoneMetadataEntity Empty = new GeoLocationTimezoneMetadataEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public string TimezoneText { get; set; }

	public string StandardOffset { get; set; }

	public string DaylightSavings { get; set; }

	public string Tag { get; set; }

	public string Standard_Name { get; set; }

	public string Daylight_Name { get; set; }

	public string ISO_Name { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public string CalculateCombinedHash()
	{
		StringBuilder stringBuilder = new StringBuilder().Append(TimezoneText ?? "").Append(StandardOffset ?? "").Append(DaylightSavings ?? "")
			.Append(Tag ?? "")
			.Append(Standard_Name ?? "")
			.Append(Daylight_Name ?? "")
			.Append(ISO_Name ?? "");
		using MD5 mD = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
		return BitConverter.ToString(mD.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant();
	}
}
