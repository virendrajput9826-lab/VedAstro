using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public record APIFunctionResult(string Name, object Result)
{
	public List<object> SelectedParams { get; private set; }

	public string MLTableName(object resultOverride = null)
	{
		return Tools.GetSpecialMLTableName(this, resultOverride);
	}

	public override string ToString()
	{
		if (Result is IList source)
		{
			return Tools.ListToString(source.Cast<object>().ToList());
		}
		return Result?.ToString();
	}

	public JProperty ToJson()
	{
		if (Result is IList source)
		{
			string content = Tools.ListToString(source.Cast<object>().ToList());
			return new JProperty(Name, content);
		}
		if (Result is IToJson toJson)
		{
			return new JProperty(Name, toJson.ToJson());
		}
		return new JProperty(Name, Result?.ToString());
	}

	public static JToken ToJsonList(List<APIFunctionResult> apiFunctionResultList)
	{
		new JArray();
		JObject jObject = new JObject();
		foreach (APIFunctionResult apiFunctionResult in apiFunctionResultList)
		{
			object result = apiFunctionResult.Result;
			string name = apiFunctionResult.Name;
			JToken jToken = Tools.AnyToJSON(name, result);
			if (jToken is JObject)
			{
				jObject.Add(name, jToken);
			}
			else
			{
				jObject.Add(jToken);
			}
		}
		return jObject;
	}

	public string ResultAsString()
	{
		return Tools.AnyToString(Result);
	}

	public void AddSelectedParams(dynamic inputPlanet)
	{
		if (SelectedParams == null)
		{
			List<object> list = (SelectedParams = new List<object>());
		}
		SelectedParams.Add(inputPlanet);
	}
}
