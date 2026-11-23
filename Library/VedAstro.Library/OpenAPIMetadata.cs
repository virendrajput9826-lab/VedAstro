using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class OpenAPIMetadata : EventArgs, IToJson
{
	public new static readonly OpenAPIMetadata Empty = new OpenAPIMetadata("Empty", "Empty", "Empty", "Empty", "Empty");

	private PlanetName _selectedPlanet = PlanetName.Sun;

	private string _name;

	public static List<OpenAPIMetadata> CachedAllMethoInfoList { get; set; } = new List<OpenAPIMetadata>();

	public string Signature { get; set; }

	public string SearchText => Description + ParameterDescription + Signature;

	public MethodInfo? MethodInfo { get; set; }

	public List<Type> ParameterTypes => MethodInfo?.GetParameters().Select((ParameterInfo param) => param.ParameterType).ToList() ?? new List<Type>();

	public string Description { get; set; }

	public string LineNumber { get; set; }

	public string ParameterDescription { get; set; }

	public string ExampleOutput { get; set; }

	public string Name
	{
		get
		{
			if (string.IsNullOrEmpty(_name))
			{
				_name = MethodInfo?.Name;
			}
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public object ReturnType => GetTypeName(MethodInfo?.ReturnType);

	public List<object> SelectedParams { get; set; }

	public PlanetName SelectedPlanet
	{
		get
		{
			return _selectedPlanet;
		}
		set
		{
			SelectedParams?.Clear();
			SelectedParams?.Add(value);
			_selectedPlanet = value;
		}
	}

	public string MLTableName(object resultOverride = null)
	{
		return Tools.GetSpecialMLTableName(this, resultOverride);
	}

	public OpenAPIMetadata(string signature, string lineNumber, string paramDescription, string description, string exampleOutput, MethodInfo methodInfo = null)
	{
		Description = description;
		ExampleOutput = exampleOutput;
		Signature = signature;
		MethodInfo = methodInfo;
		LineNumber = lineNumber;
		ParameterDescription = paramDescription;
	}

	public OpenAPIMetadata()
	{
	}

	public string ToPythonMethodNameStub()
	{
		return Tools.GeneratePythonDef(MethodInfo);
	}

	public string ToPythonMethodDescStub()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("\"\"\"");
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder stringBuilder3 = stringBuilder2;
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
		handler.AppendLiteral("        ");
		handler.AppendFormatted(Description);
		stringBuilder3.AppendLine(ref handler);
		stringBuilder2 = stringBuilder;
		StringBuilder stringBuilder4 = stringBuilder2;
		handler = new StringBuilder.AppendInterpolatedStringHandler(17, 1, stringBuilder2);
		handler.AppendLiteral("        :return: ");
		handler.AppendFormatted(MethodInfo?.ReturnType.Name ?? "NO NAME FOUND!");
		stringBuilder4.AppendLine(ref handler);
		stringBuilder.Append("         \"\"\"");
		return stringBuilder.ToString();
	}

	public static List<OpenAPIMetadata> FromMethodInfoList(IEnumerable<MethodInfo> calcList = null)
	{
		if (CachedAllMethoInfoList.Any())
		{
			return CachedAllMethoInfoList;
		}
		CachedAllMethoInfoList = GenerateMetadataList();
		return CachedAllMethoInfoList;
		List<OpenAPIMetadata> GenerateMetadataList()
		{
			if (calcList == null)
			{
				calcList = Tools.GetAllApiCalculatorsMethodInfo();
			}
			List<OpenAPIMetadata> list = new List<OpenAPIMetadata>();
			foreach (MethodInfo calc in calcList)
			{
				string signature = calc.GetMethodSignature();
				OpenAPIMetadata openAPIMetadata = OpenAPIStaticTable.Rows.FirstOrDefault((OpenAPIMetadata x) => x.Signature == signature);
				if (openAPIMetadata == null)
				{
					LibLogger.Debug("METHOD NOT FOUND!!!! --> " + signature);
				}
				else
				{
					openAPIMetadata.MethodInfo = calc;
					list.Add(openAPIMetadata);
				}
			}
			list.Sort((OpenAPIMetadata metadata1, OpenAPIMetadata metadata2) => metadata1.Name.CompareTo(metadata2.Name));
			return list;
		}
	}

	public static string GetTypeName(Type type)
	{
		if (type == null)
		{
			return "null";
		}
		if (type.IsGenericType)
		{
			Type type2 = type.GetGenericArguments()[0];
			return type.Name.Split('`')[0] + " of " + type2.Name;
		}
		return type.Name;
	}

	public void AddSelectedParams(PlanetName inputPlanet)
	{
		if (SelectedParams == null)
		{
			List<object> list = (SelectedParams = new List<object>());
		}
		SelectedParams.Add(inputPlanet);
	}

	public OpenAPIMetadata Clone()
	{
		return new OpenAPIMetadata(Signature, LineNumber, ParameterDescription, Description, ExampleOutput, MethodInfo);
	}

	public static List<OpenAPIMetadata> FromJsonList(JToken columnDataList)
	{
		if (columnDataList == null)
		{
			return new List<OpenAPIMetadata>();
		}
		List<OpenAPIMetadata> list = new List<OpenAPIMetadata>();
		foreach (JToken item in (IEnumerable<JToken>)columnDataList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static OpenAPIMetadata FromJson(JToken timeJson)
	{
		try
		{
			string signature = timeJson["Signature"].Value<string>();
			string lineNumber = timeJson["LineNumber"].Value<string>();
			string paramDescription = timeJson["ParameterDescription"].Value<string>();
			string description = timeJson["Description"].Value<string>();
			string exampleOutput = timeJson["ExampleOutput"].Value<string>();
			JToken? jToken = timeJson["SelectedParams"];
			OpenAPIMetadata openAPIMetadata = new OpenAPIMetadata(signature, lineNumber, paramDescription, description, exampleOutput);
			List<object> list = new List<object>();
			foreach (JProperty item in (IEnumerable<JToken>)jToken)
			{
				string name = item.Name;
				string text = item.Value.Value<string>();
				if (!(name == "PlanetName"))
				{
					if (name == "HouseName")
					{
						list.Add(Enum.Parse<HouseName>(text));
					}
				}
				else
				{
					list.Add(PlanetName.Parse(text));
				}
			}
			openAPIMetadata.SelectedParams = list;
			MethodInfo methodInfo = Tools.MethodInfoFromJson((JObject)timeJson["MethodInfo"]);
			openAPIMetadata.MethodInfo = methodInfo;
			return openAPIMetadata;
		}
		catch (Exception message)
		{
			LibLogger.Debug(message, "Failed to Parse");
			return Empty;
		}
	}

	public JObject ToJson()
	{
		JObject jObject = new JObject();
		jObject["Signature"] = Signature;
		jObject["Description"] = Description;
		jObject["ExampleOutput"] = ExampleOutput;
		JObject jObject2 = new JObject();
		if (this?.SelectedParams != null)
		{
			foreach (object item in this?.SelectedParams)
			{
				string name = item.GetType().Name;
				string content = item.ToString();
				JProperty content2 = new JProperty(name, content);
				jObject2.Add(content2);
			}
		}
		jObject["SelectedParams"] = jObject2;
		jObject["MethodInfo"] = MethodInfo.ToJson();
		return jObject;
	}

	public string GetParamDesc(string paramName)
	{
		string[] array = ParameterDescription.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(':');
			string text = array2[0].Trim().ToLower();
			string text2 = paramName.ToLower();
			bool flag = text == text2;
			if ((array2.Length == 2) & flag)
			{
				return array2[1].Trim();
			}
		}
		return "";
	}

	public List<ParameterMetadata> GetParamList()
	{
		MethodInfo? obj = this?.MethodInfo;
		List<ParameterMetadata> list = new List<ParameterMetadata>();
		ParameterInfo[] parameters = obj.GetParameters();
		foreach (ParameterInfo parameterInfo in parameters)
		{
			string description = this?.GetParamDesc(parameterInfo.Name) ?? "";
			list.Add(new ParameterMetadata(parameterInfo, description));
		}
		return list;
	}
}
