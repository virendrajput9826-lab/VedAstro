using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public static class AutoCalculator
{
	public static List<APIFunctionResult> FindAndExecuteFunctions(MethodInfo callerToExclude = null, params object[] paramInput)
	{
		return ExecuteCals(FindCalcs(callerToExclude, paramInput), paramInput);
	}

	public static JToken ExecuteFunctionsJSON(MethodInfo methodName, params object[] paramInput)
	{
		return ExecuteFunctionsJSON(new List<MethodInfo> { methodName }, paramInput);
	}

	public static JToken ExecuteFunctionsJSON(List<MethodInfo> methodInfoList, params object[] paramInput)
	{
		return APIFunctionResult.ToJsonList(ExecuteCals(methodInfoList, paramInput));
	}

	public static JToken FindAndExecuteFunctionsJSON(MethodInfo callerToExclude = null, params object[] paramInput)
	{
		return APIFunctionResult.ToJsonList(FindAndExecuteFunctions(callerToExclude, paramInput));
	}

	public static List<APIFunctionResult> ExecuteCals(IEnumerable<MethodInfo> foundCalcs, params object[] paramInput)
	{
		List<APIFunctionResult> list = new List<APIFunctionResult>();
		foreach (MethodInfo foundCalc in foundCalcs)
		{
			object[] parameters = OrderParamToMatch(foundCalc, paramInput);
			object result;
			try
			{
				result = foundCalc?.Invoke(null, parameters);
			}
			catch (Exception ex)
			{
				result = ex;
			}
			APIFunctionResult item = new APIFunctionResult(foundCalc.Name, result);
			list.Add(item);
		}
		return list;
	}

	public static IEnumerable<MethodInfo> FindCalcs(MethodInfo callerToExclude = null, params object[] paramInput)
	{
		List<Type> typeList = paramInput.Select((object param) => param.GetType()).ToList();
		return (from calculatorInfo in typeof(Calculate).GetMethods()
			let parameter = calculatorInfo.GetParameters()
			where ParamListMatch(parameter, typeList) && calculatorInfo != callerToExclude
			select calculatorInfo into method
			orderby method.Name
			select method).ToList();
	}

	private static object[] OrderParamToMatch(MethodInfo calc, object[] paramInput)
	{
		ParameterInfo[] parameters = calc.GetParameters();
		object[] array = new object[parameters.Length];
		List<object> list = paramInput.ToList();
		for (int i = 0; i < parameters.Length; i++)
		{
			Type needType = parameters[i].ParameterType;
			list.Remove(array[i] = list.First((object param) => param.GetType() == needType));
		}
		return array;
	}

	private static bool ParamListMatch(ParameterInfo[] inputParamList, List<Type> neededTypeList)
	{
		if (inputParamList.Length != neededTypeList.Count)
		{
			return false;
		}
		List<Type> list = inputParamList.Select((ParameterInfo p) => p.ParameterType).ToList();
		bool result = true;
		foreach (Type neededType in neededTypeList)
		{
			if (!list.Contains(neededType))
			{
				result = false;
				break;
			}
		}
		return result;
	}
}
