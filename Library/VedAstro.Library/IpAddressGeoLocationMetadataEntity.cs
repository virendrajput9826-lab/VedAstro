using System;
using System.Security.Cryptography;
using System.Text;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class IpAddressGeoLocationMetadataEntity : ITableEntity
{
	public static IpAddressGeoLocationMetadataEntity Empty = new IpAddressGeoLocationMetadataEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public string AsnName { get; set; }

	public string TimezoneName { get; set; }

	public string TimezoneOffset { get; set; }

	public string IsProxy { get; set; }

	public string IsDatacenter { get; set; }

	public string IsAnonymous { get; set; }

	public string IsKnownAttacker { get; set; }

	public string IsKnownAbuser { get; set; }

	public string IsThreat { get; set; }

	public string IsBogon { get; set; }

	public string CalculateCombinedHash()
	{
		StringBuilder stringBuilder = new StringBuilder().Append(AsnName ?? "").Append(TimezoneName ?? "").Append(TimezoneOffset ?? "")
			.Append(IsProxy ?? "")
			.Append(IsDatacenter ?? "")
			.Append(IsAnonymous ?? "")
			.Append(IsKnownAttacker ?? "")
			.Append(IsKnownAbuser ?? "")
			.Append(IsThreat ?? "")
			.Append(IsBogon ?? "");
		using MD5 mD = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
		return BitConverter.ToString(mD.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant();
	}
}
