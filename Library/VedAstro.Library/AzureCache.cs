using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.Functions.Worker.Http;

namespace VedAstro.Library;

public static class AzureCache
{
	private static readonly BlobContainerClient blobContainerClient;

	private const string blobContainerName = "cache";

	static AzureCache()
	{
		blobContainerClient = new BlobContainerClient(Secrets.API_STORAGE, "cache");
	}

	public static List<BlobItem> ListBlobs(string searchKeyword)
	{
		new List<BlobItem>();
		return blobContainerClient.GetBlobs(BlobTraits.None, BlobStates.None, searchKeyword).ToList();
	}

	public static async Task<bool> IsExist(string callerId)
	{
		return await blobContainerClient.GetBlobClient(callerId).ExistsAsync(CancellationToken.None);
	}

	public static async Task<dynamic> GetData<T>(string callerId)
	{
		_ = 1;
		try
		{
			BlobClient blobClient = blobContainerClient.GetBlobClient(callerId);
			if (typeof(T) == typeof(string))
			{
				return await Tools.BlobClientToString(blobClient);
			}
			if (typeof(T) == typeof(byte[]))
			{
				using MemoryStream ms = new MemoryStream();
				await blobClient.DownloadToAsync(ms);
				return ms.ToArray();
			}
			if (typeof(T) == typeof(BlobClient))
			{
				return blobClient;
			}
		}
		catch (Exception)
		{
			return "";
		}
		throw new Exception("END OF LINE!");
	}

	public static async Task<BlobClient?> Add<T>(string fileName, T value, string mimeType = "", Dictionary<string, string> metadata = null)
	{
		BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
		if (typeof(T) == typeof(string))
		{
			string s = (value as string) ?? string.Empty;
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			using MemoryStream ms = new MemoryStream(bytes);
			new BlobUploadOptions().AccessTier = AccessTier.Cool;
			Dictionary<string, string> metadata2 = metadata ?? new Dictionary<string, string>();
			await blobClient.UploadAsync(ms, null, metadata2, null, null, AccessTier.Cool);
		}
		else if (typeof(T) == typeof(byte[]))
		{
			byte[] buffer = value as byte[];
			using MemoryStream ms = new MemoryStream(buffer, writable: false);
			BlobUploadOptions blobUploadOptions = new BlobUploadOptions();
			blobUploadOptions.AccessTier = AccessTier.Cool;
			await blobClient.UploadAsync(ms, blobUploadOptions);
		}
		if (!string.IsNullOrEmpty(mimeType))
		{
			BlobHttpHeaders httpHeaders = new BlobHttpHeaders
			{
				ContentType = mimeType
			};
			await blobClient.SetHttpHeadersAsync(httpHeaders);
		}
		await blobClient.SetAccessTierAsync(AccessTier.Cool);
		return blobClient;
	}

	public static async Task Delete(string callerId)
	{
		Response<bool> obj = await blobContainerClient.GetBlobClient(callerId).DeleteIfExistsAsync();
		if (obj != null)
		{
			_ = !obj.Value;
		}
	}

	public static async Task<HttpResponseData> CacheExecute(Func<Task<BlobClient>> cacheExecuteTask3, CallerInfo callerInfo, HttpRequestData httpRequestData)
	{
		if (CallTracker.IsRunning(callerInfo.CallerId))
		{
			HttpResponseData httpResponseData = httpRequestData.CreateResponse(HttpStatusCode.OK);
			httpResponseData.Headers.Add("Call-Status", "Running");
			httpResponseData.Headers.Add("Access-Control-Expose-Headers", "Call-Status");
			return httpResponseData;
		}
		if (await IsExist(callerInfo.CallerId))
		{
			return Tools.SendPassHeaderToCaller((BlobClient)(await GetData<BlobClient>(callerInfo.CallerId)), httpRequestData, "application/json");
		}
		cacheExecuteTask3();
		HttpResponseData httpResponseData2 = httpRequestData.CreateResponse(HttpStatusCode.OK);
		httpResponseData2.Headers.Add("Call-Status", "Running");
		httpResponseData2.Headers.Add("Access-Control-Expose-Headers", "Call-Status");
		return httpResponseData2;
	}

	public static async Task DeleteCacheRelatedToPerson(Person newPerson)
	{
		if (Person.Empty.Equals(newPerson))
		{
			return;
		}
		Pageable<BlobItem> blobs = blobContainerClient.GetBlobs(BlobTraits.All, BlobStates.None, newPerson.Id);
		foreach (BlobItem item in blobs)
		{
			await blobContainerClient.DeleteBlobIfExistsAsync(item.Name);
		}
	}

	public static async Task DeleteCacheRelatedToPerson(string personId)
	{
		if (personId == "Empty")
		{
			return;
		}
		Pageable<BlobItem> blobs = blobContainerClient.GetBlobs(BlobTraits.All, BlobStates.None, personId);
		foreach (BlobItem item in blobs)
		{
			await blobContainerClient.DeleteBlobIfExistsAsync(item.Name);
		}
	}
}
