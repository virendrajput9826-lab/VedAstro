using System;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class IpAddressStatisticEntity : ITableEntity
{
	public static IpAddressStatisticEntity Empty = new IpAddressStatisticEntity();

	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public double CallsPerSecond { get; set; }

	public DateTimeOffset? PerSecondTimestamp { get; set; }

	public double CallsPerMinute { get; set; }

	public DateTimeOffset? PerMinuteTimestamp { get; set; }

	public double CallsPerHour { get; set; }

	public DateTimeOffset? PerHourTimestamp { get; set; }

	public double CallsPerDay { get; set; }

	public DateTimeOffset? PerDayTimestamp { get; set; }

	public double CallsPerMonth { get; set; }

	public DateTimeOffset? PerMonthTimestamp { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }
}
