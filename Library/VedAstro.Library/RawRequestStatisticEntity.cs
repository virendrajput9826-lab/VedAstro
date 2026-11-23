using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

[Serializable]
public class RawRequestStatisticEntity : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	[Description("Accept")]
	public string Accept { get; set; }

	[Description("Accept-Charset")]
	public string AcceptCharset { get; set; }

	[Description("Accept-Encoding")]
	public string AcceptEncoding { get; set; }

	[Description("Accept-Language")]
	public string AcceptLanguage { get; set; }

	[Description("Authorization")]
	public string Authorization { get; set; }

	[Description("Cache-Control")]
	public string CacheControl { get; set; }

	[Description("Connection")]
	public string Connection { get; set; }

	[Description("Cookie")]
	public string Cookie { get; set; }

	[Description("Content-Length")]
	public string ContentLength { get; set; }

	[Description("Content-MD5")]
	public string ContentMD5 { get; set; }

	[Description("Content-Type")]
	public string ContentType { get; set; }

	[Description("Date")]
	public string Date { get; set; }

	[Description("Expect")]
	public string Expect { get; set; }

	[Description("From")]
	public string From { get; set; }

	[Description("Host")]
	public string Host { get; set; }

	[Description("If-Match")]
	public string IfMatch { get; set; }

	[Description("If-Modified-Since")]
	public string IfModifiedSince { get; set; }

	[Description("If-None-Match")]
	public string IfNoneMatch { get; set; }

	[Description("If-Range")]
	public string IfRange { get; set; }

	[Description("If-Unmodified-Since")]
	public string IfUnmodifiedSince { get; set; }

	[Description("Max-Forwards")]
	public string MaxForwards { get; set; }

	[Description("Pragma")]
	public string Pragma { get; set; }

	[Description("Proxy-Authorization")]
	public string ProxyAuthorization { get; set; }

	[Description("Range")]
	public string Range { get; set; }

	[Description("Referer")]
	public string Referer { get; set; }

	[Description("TE")]
	public string TE { get; set; }

	[Description("Upgrade")]
	public string Upgrade { get; set; }

	[Description("User-Agent")]
	public string UserAgent { get; set; }

	[Description("Via")]
	public string Via { get; set; }

	[Description("Warning")]
	public string Warning { get; set; }

	[Description("sec-fetch-referer")]
	public string SecFetchReferer { get; set; }

	[Description("sec-fetch-origin")]
	public string SecFetchOrigin { get; set; }

	[Description("sec-fetch-dest")]
	public string SecFetchDest { get; set; }

	[Description("sec-fetch-mode")]
	public string SecFetchMode { get; set; }

	[Description("sec-fetch-site")]
	public string SecFetchSite { get; set; }

	[Description("sec-fetch-user")]
	public string SecFetchUser { get; set; }

	[Description("sec-ch-ua-platform")]
	public string SecChUaPlatform { get; set; }

	[Description("sec-ch-ua")]
	public string SecChUa { get; set; }

	[Description("sec-ch-ua-mobile")]
	public string SecChUaMobile { get; set; }

	[Description("sec-ch-ua-full-version")]
	public string SecChUaFullVersion { get; set; }

	[Description("sec-ch-ua-arch")]
	public string SecChUaArch { get; set; }

	[Description("sec-ch-ua-model")]
	public string SecChUaModel { get; set; }

	[Description("sec-ch-ua-platform-version")]
	public string SecChUaPlatformVersion { get; set; }

	[Description("X-Azure-ClientIP")]
	public string XAzureClientIP { get; set; }

	[Description("X-Forwarded-For")]
	public string XForwardedFor { get; set; }

	[Description("X-Forwarded-Host")]
	public string XForwardedHost { get; set; }

	[Description("X-Forwarded-Proto")]
	public string XForwardedProto { get; set; }

	[Description("X-Real-IP")]
	public string XRealIP { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public string CalculateCombinedHash()
	{
		StringBuilder stringBuilder = new StringBuilder();
		PropertyInfo[] properties = GetType().GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (Attribute.IsDefined(propertyInfo, typeof(DescriptionAttribute)))
			{
				string text = propertyInfo.GetValue(this) as string;
				stringBuilder.Append(text ?? "");
			}
		}
		using MD5 mD = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
		return BitConverter.ToString(mD.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant();
	}
}
