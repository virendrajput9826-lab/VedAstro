using System;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class WebResult<T>
{
	public bool IsPass { get; set; }

	public T Payload { get; set; }

	public WebResult()
	{
	}

	public WebResult(bool result, T payload)
	{
		IsPass = result;
		Payload = payload;
	}

	public static implicit operator T(WebResult<T> value)
	{
		return value.Payload;
	}

	public static implicit operator WebResult<T>(T value)
	{
		return new WebResult<T>
		{
			Payload = value
		};
	}

	public static bool IsResultPass(XElement result)
	{
		try
		{
			return result.Element("Status")?.Value == "Pass";
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static WebResult<XElement> FromXml(XElement inputXml)
	{
		WebResult<XElement> webResult = new WebResult<XElement>();
		webResult.IsPass = inputXml.Element("Status")?.Value == "Pass";
		XElement xElement = inputXml.Element("Payload")?.Elements().FirstOrDefault();
		if (xElement == null)
		{
			string text = inputXml.Element("Payload")?.Value;
			if (string.IsNullOrEmpty(text))
			{
				xElement = new XElement("Root");
			}
			else
			{
				try
				{
					xElement = XElement.Parse(text);
				}
				catch (Exception)
				{
					xElement = new XElement("NotXML", text);
				}
			}
		}
		webResult.Payload = xElement;
		return webResult;
	}

	public static WebResult<JToken> FromVedAstroJson(JObject inputXml)
	{
		WebResult<JToken> obj = new WebResult<JToken>
		{
			IsPass = (inputXml["Status"].Value<string>() == "Pass")
		};
		JToken payload = inputXml["Payload"];
		obj.Payload = payload;
		return obj;
	}
}
