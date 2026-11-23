using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class Bhinnashtakavarga : IToJson
{
	private readonly Dictionary<PlanetName, Dictionary<ZodiacName, int>> _dictionary = new Dictionary<PlanetName, Dictionary<ZodiacName, int>>();

	public Dictionary<ZodiacName, int> this[PlanetName index]
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

	public Dictionary<PlanetName, Dictionary<ZodiacName, int>> Dictionary => _dictionary;

	JObject IToJson.ToJson()
	{
		return (JObject)ToJson();
	}

	public JToken ToJson()
	{
		JObject jObject = new JObject();
		foreach (KeyValuePair<PlanetName, Dictionary<ZodiacName, int>> item in _dictionary)
		{
			JArray value = RowToJArray(item.Value, out var rowTotal);
			JObject value2 = new JObject
			{
				["Total"] = rowTotal,
				["Rows"] = value
			};
			jObject[item.Key.ToString()] = value2;
		}
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

	public static List<Bhinnashtakavarga> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<Bhinnashtakavarga>();
		}
		List<Bhinnashtakavarga> list = new List<Bhinnashtakavarga>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static Bhinnashtakavarga FromJson(JToken personInput)
	{
		throw new NotImplementedException();
	}
}
