using System;
using Azure;
using Azure.Data.Tables;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class PersonListEntity : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public string Name { get; set; }

	public string BirthTime { get; set; }

	public string Gender { get; set; }

	public string Notes { get; set; }

	public PersonListEntity Clone()
	{
		return new PersonListEntity
		{
			PartitionKey = PartitionKey,
			RowKey = RowKey,
			Timestamp = Timestamp,
			ETag = ETag,
			Name = Name,
			BirthTime = BirthTime,
			Gender = Gender,
			Notes = Notes
		};
	}

	public string GetBirthYear()
	{
		return JObject.Parse(BirthTime)["StdTime"].Value<string>().Split(" ")[1];
	}

	public Time ToBirthTime()
	{
		return Time.FromJson(JObject.Parse(BirthTime));
	}

	public bool IsMale()
	{
		return Gender.ToLower() == "male";
	}
}
