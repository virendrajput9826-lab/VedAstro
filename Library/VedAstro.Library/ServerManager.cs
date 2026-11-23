using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.JSInterop;

namespace VedAstro.Library;

public static class ServerManager
{
	public static async Task<Stream> WriteToServerStreamReply(string apiUrl, XElement xmlData, IJSRuntime? jsRuntime, HttpClient httpClient)
	{
		try
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, apiUrl);
			httpRequestMessage.Content = Tools.XmLtoHttpContent(xmlData);
			HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead;
			return (await httpClient.SendAsync(httpRequestMessage, completionOption)).Content.ReadAsStreamAsync().Result;
		}
		catch (Exception inner)
		{
			throw new ApiCommunicationFailed("WriteToServerStreamReply()", inner);
		}
	}

	public static async Task<WebResult<XElement>> WriteToServerXmlReply(string apiUrl, XElement xmlData, int timeout = 60)
	{
		string text;
		while (true)
		{
			try
			{
				text = await Tools.TaskWithTimeoutAndException(Post(apiUrl, xmlData.ToString(SaveOptions.DisableFormatting)), TimeSpan.FromSeconds(timeout));
			}
			catch (Exception)
			{
				LibLogger.Debug($"Call to \"{apiUrl}\" timeout at : {timeout}s");
				continue;
			}
			break;
		}
		if (string.IsNullOrEmpty(text))
		{
			await LibLogger.Debug($"BLZ > Call returned empty\n To:{apiUrl} with payload:\n{xmlData}");
			return new WebResult<XElement>(result: false, new XElement("CallEmptyError"));
		}
		return WebResult<XElement>.FromXml(XElement.Parse(text));
	}

	public static async Task<string> Post(string apiUrl, string data)
	{
		using HttpClient httpClient = new HttpClient();
		StringContent content = new StringContent(data, Encoding.UTF8, "application/xml");
		HttpRequestMessage request = new HttpRequestMessage
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(apiUrl),
			Content = content
		};
		HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			return await httpResponseMessage.Content.ReadAsStringAsync();
		}
		throw new Exception($"Error in Post method: {httpResponseMessage.StatusCode}");
	}
}
