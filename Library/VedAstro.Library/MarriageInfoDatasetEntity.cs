using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Data.Tables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class MarriageInfoDatasetEntity : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; } = "";

	public string Info { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public void SetMarriages(List<JToken> marriages)
	{
		JObject jObject = this?.InfoJson() ?? new JObject();
		jObject["marriages"] = new JArray(marriages);
		Info = jObject.ToString();
	}

	public List<JToken> GetMarriagesWhereRoddenAA()
	{
		return (from x in GetMarriages()
			where !string.IsNullOrEmpty(x["PersonId"]?.Value<string>())
			select x).ToList();
	}

	public List<JToken> GetMarriages()
	{
		JObject jObject = this?.InfoJson();
		List<JToken> list = new List<JToken>();
		if (jObject != null)
		{
			foreach (JToken item in (IEnumerable<JToken>)jObject["marriages"])
			{
				list.Add(item);
			}
		}
		return list;
	}

	public JObject? InfoJson()
	{
		try
		{
			return JObject.Parse(Info);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public bool IsJson()
	{
		try
		{
			JToken.Parse(Info);
			return true;
		}
		catch (JsonReaderException)
		{
			return false;
		}
	}
}
