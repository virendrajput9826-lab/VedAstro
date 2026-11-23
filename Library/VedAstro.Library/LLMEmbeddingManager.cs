using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public static class LLMEmbeddingManager
{
	private static string AzureOpenAIAPIKey = "498f893da29940bb916712e993d6854f";

	private static string azureCohereEmbedAPIKey = "vM3mewMokdtgovcDOWcCLztwj0IBWlc4";

	public static HttpClientHandler Handler { get; } = new HttpClientHandler
	{
		ClientCertificateOptions = ClientCertificateOption.Manual,
		ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
	};

	public static async Task<string> GetEmbeddingsForText_CohereEmbedV3(string[] inputTextList, string inputType)
	{
		JObject finalResult = new JObject();
		int textsPerBatch = 95;
		HttpClient httpClient = new HttpClient(Handler);
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureCohereEmbedAPIKey);
		httpClient.BaseAddress = new Uri("https://Cohere-embed-v3-english-bkovp-serverless.westus.inference.ai.azure.com/v1/embed");
		using (HttpClient client = httpClient)
		{
			for (int i = 0; i < inputTextList.Length; i += textsPerBatch)
			{
				string[] textArray = inputTextList.Skip(i).Take(textsPerBatch).ToArray();
				HttpResponseMessage httpResponseMessage = await MakeApiCall(client, textArray, inputType);
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					JObject content = JObject.Parse(await httpResponseMessage.Content.ReadAsStringAsync());
					finalResult.Merge(content, new JsonMergeSettings
					{
						MergeArrayHandling = MergeArrayHandling.Concat
					});
				}
				else
				{
					Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
					Console.WriteLine(httpResponseMessage.Headers.ToString());
					Console.WriteLine(await httpResponseMessage.Content.ReadAsStringAsync());
				}
			}
			return finalResult["embeddings"][0].ToString(Formatting.None);
		}
		static async Task<HttpResponseMessage> MakeApiCall(HttpClient httpClient2, string[] texts, string input_type)
		{
			StringContent content2 = new StringContent(JsonConvert.SerializeObject(new
			{
				model = "embed-english-v3.0",
				texts = texts,
				input_type = input_type,
				truncate = "NONE"
			}), Encoding.UTF8, "application/json");
			return await httpClient2.PostAsync("", content2);
		}
	}

	public static async Task<string> GetEmbeddingsForText_Ada002(string textToEmbed)
	{
		using HttpClient client = new HttpClient();
		client.DefaultRequestHeaders.Add("api-key", AzureOpenAIAPIKey);
		StringContent content = new StringContent(JsonConvert.SerializeObject(new
		{
			input = textToEmbed
		}), Encoding.UTF8, "application/json");
		return JToken.Parse(await (await client.PostAsync("https://openaimodelserver.openai.azure.com/openai/deployments/text-embedding-ada-002/embeddings?api-version=2023-05-15", content)).Content.ReadAsStringAsync())["data"][0]["embedding"].ToString(Formatting.None);
	}

	public static async Task<double[]> GetEmbeddingsArrayForText_Ada002(string textToEmbed)
	{
		using HttpClient client = new HttpClient();
		client.DefaultRequestHeaders.Add("api-key", AzureOpenAIAPIKey);
		StringContent content = new StringContent(JsonConvert.SerializeObject(new
		{
			input = textToEmbed
		}), Encoding.UTF8, "application/json");
		return JToken.Parse(await (await client.PostAsync("https://openaimodelserver.openai.azure.com/openai/deployments/text-embedding-ada-002/embeddings?api-version=2023-05-15", content)).Content.ReadAsStringAsync())["data"][0]["embedding"].Select((JToken jv) => (double)jv).ToArray();
	}
}
