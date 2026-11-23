using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class ChartOptions(List<AlgorithmFuncs> SelectedAlgorithm)
{
	public static ChartOptions Empty = new ChartOptions(new List<AlgorithmFuncs>());

	public List<AlgorithmFuncs> SelectedAlgorithm { get; init; } = SelectedAlgorithm;

	public static ChartOptions FromJson(JToken summaryOptionsJson)
	{
		JToken? jToken = summaryOptionsJson["SelectedAlgorithm"];
		List<AlgorithmFuncs> list = new List<AlgorithmFuncs>();
		foreach (JToken item2 in (IEnumerable<JToken>)jToken)
		{
			MethodInfo method = typeof(Algorithm).GetMethod(item2.ToString());
			AlgorithmFuncs item = (AlgorithmFuncs)Delegate.CreateDelegate(typeof(AlgorithmFuncs), method);
			list.Add(item);
		}
		return new ChartOptions(list);
	}

	public static ChartOptions FromUrl(string summaryOptionsUrl)
	{
		List<string> list = summaryOptionsUrl.Split(',').ToList();
		List<AlgorithmFuncs> list2 = new List<AlgorithmFuncs>();
		foreach (string item2 in list)
		{
			MethodInfo method = typeof(Algorithm).GetMethod(item2);
			AlgorithmFuncs item = (AlgorithmFuncs)Delegate.CreateDelegate(typeof(AlgorithmFuncs), method);
			list2.Add(item);
		}
		return new ChartOptions(list2);
	}

	public JObject ToJson()
	{
		JArray value = new JArray(SelectedAlgorithm.Select((AlgorithmFuncs algorithm) => algorithm.Method.Name).ToList());
		return new JObject { ["SelectedAlgorithm"] = value };
	}

	public override string ToString()
	{
		return Tools.ListToString(SelectedAlgorithm.Select((AlgorithmFuncs al) => al.Method.Name).ToList(), "-");
	}
}
