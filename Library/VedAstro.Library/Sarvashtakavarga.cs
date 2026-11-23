using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class Sarvashtakavarga : IToJson
{
	private readonly Dictionary<string, int[]> _rows = new Dictionary<string, int[]>();

	public Dictionary<string, int[]> Rows => _rows;

	public int[] this[string index]
	{
		get
		{
			if (_rows.ContainsKey(index))
			{
				return _rows[index];
			}
			return null;
		}
		set
		{
			_rows[index] = value;
		}
	}

	public Dictionary<ZodiacName, int> SarvashtakavargaRow { get; set; } = ZodiacNameExtensions.AllZodiacSignsDictionary(0);

	JObject IToJson.ToJson()
	{
		return (JObject)ToJson();
	}

	public JToken ToJson()
	{
		JObject jObject = new JObject();
		foreach (KeyValuePair<string, int[]> row in _rows)
		{
			JArray value = RowToJArray(row.Value, out var rowTotal);
			JObject value2 = new JObject
			{
				["Total"] = rowTotal,
				["Rows"] = value
			};
			jObject[row.Key] = value2;
		}
		JArray value3 = RowToJArray(SarvashtakavargaRow, out var rowTotal2);
		JObject value4 = new JObject
		{
			["Total"] = rowTotal2,
			["Rows"] = value3
		};
		jObject["Sarvashtakavarga"] = value4;
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

	private static JArray RowToJArray(int[] item, out int rowTotal)
	{
		JArray jArray = new JArray();
		rowTotal = 0;
		foreach (int num in item)
		{
			jArray.Add(num);
			rowTotal += num;
		}
		return jArray;
	}

	public static List<Sarvashtakavarga> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<Sarvashtakavarga>();
		}
		List<Sarvashtakavarga> list = new List<Sarvashtakavarga>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static Sarvashtakavarga FromJson(JToken personInput)
	{
		throw new NotImplementedException();
	}
}
