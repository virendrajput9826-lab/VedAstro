using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class Prastaraka : IToJson
{
	private readonly Dictionary<string, Dictionary<ZodiacName, int>> _dictionary = new Dictionary<string, Dictionary<ZodiacName, int>>();

	public Dictionary<ZodiacName, int> this[string index]
	{
		get
		{
			if (_dictionary.ContainsKey(index))
			{
				return _dictionary[index];
			}
			return null;
		}
		set
		{
			_dictionary[index] = value;
		}
	}

	public Dictionary<ZodiacName, int> BhinnashtakaRow()
	{
		Dictionary<ZodiacName, int> dictionary = ZodiacNameExtensions.AllZodiacSignsDictionary(0);
		foreach (KeyValuePair<ZodiacName, int> item in dictionary)
		{
			int num = 0;
			foreach (KeyValuePair<string, Dictionary<ZodiacName, int>> item2 in _dictionary)
			{
				num += item2.Value[item.Key];
			}
			dictionary[item.Key] = num;
		}
		return dictionary;
	}

	JObject IToJson.ToJson()
	{
		return (JObject)ToJson();
	}

	public JToken ToJson()
	{
		JObject jObject = new JObject();
		foreach (KeyValuePair<string, Dictionary<ZodiacName, int>> item in _dictionary)
		{
			JArray value = RowToJArray(item.Value, out var rowTotal);
			JObject value2 = new JObject
			{
				["Total"] = rowTotal,
				["Rows"] = value
			};
			jObject[item.Key] = value2;
		}
		JArray value3 = RowToJArray(BhinnashtakaRow(), out var rowTotal2);
		JObject value4 = new JObject
		{
			["Total"] = rowTotal2,
			["Rows"] = value3
		};
		jObject["Bhinnashtaka"] = value4;
		return jObject;
	}

	private static JArray RowToJArray(Dictionary<ZodiacName, int> item, out int rowTotal)
	{
		JArray jArray = new JArray();
		rowTotal = 0;
		foreach (KeyValuePair<ZodiacName, int> item2 in item)
		{
			jArray.Add(item2.Value);
			rowTotal += item2.Value;
		}
		return jArray;
	}

	public static List<Prastaraka> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<Prastaraka>();
		}
		List<Prastaraka> list = new List<Prastaraka>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static Prastaraka FromJson(JToken personInput)
	{
		throw new NotImplementedException();
	}
}
