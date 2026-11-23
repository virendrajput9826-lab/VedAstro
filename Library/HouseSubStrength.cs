using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VedAstro.Library;

public class HouseSubStrength : IToJson
{
	public string Name = "";

	public Dictionary<HouseName, double> Power { get; }

	public HouseSubStrength(Dictionary<HouseName, double> power, string name)
	{
		Power = power;
		Name = name;
	}

	public JObject ToJson()
	{
		JArray jArray = new JArray();
		foreach (KeyValuePair<HouseName, double> item in Power)
		{
			JObject jObject = new JObject();
			jObject["House"] = (int)item.Key;
			jObject["Strength"] = item.Value;
			jArray.Add(jObject);
		}
		return new JObject { { Name, jArray } };
	}
}
