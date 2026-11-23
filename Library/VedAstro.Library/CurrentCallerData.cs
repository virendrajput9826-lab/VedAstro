using System.Linq;
using Microsoft.Azure.Functions.Worker.Http;

namespace VedAstro.Library;

public static class CurrentCallerData
{
	public static HttpRequestData originalHttpRequest { get; set; }

	public static void AddOriginalCallerHeadersIfAny(HttpResponseData httpResponseData)
	{
		try
		{
			if (originalHttpRequest != null && originalHttpRequest.Headers.Contains("Host"))
			{
				LibLogger.Debug("HOST OVERRIDE!!!");
				httpResponseData.Headers.TryAddWithoutValidation("Host", originalHttpRequest.Headers.GetValues("Host").ToArray());
			}
		}
		catch
		{
			LibLogger.Debug("HOST OVERRIDE FAIL!!!");
		}
	}
}
