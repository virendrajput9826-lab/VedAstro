using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using Azure.Data.Tables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public static class ChatAPI
{
	private static Uri azureOpenAIResourceUri = new Uri("https://openaimodelserver.openai.azure.com/");

	private static AzureKeyCredential azureOpenAIApiKey = new AzureKeyCredential(Environment.GetEnvironmentVariable("AzureOpenAIAPIKey"));

	private static string azureMetaLlama3APIKey = Environment.GetEnvironmentVariable("AzureMetaLlama3APIKey");

	private static string azureMistralLargeAPIKey = Environment.GetEnvironmentVariable("AzureMistralLargeAPIKey");

	private static string azureCohereCommandRPlusAPIKey = Environment.GetEnvironmentVariable("AzureCohereCommandRPlusAPIKey");

	private static string azureCohereEmbedAPIKey = Environment.GetEnvironmentVariable("AzureCohereEmbedAPIKey");

	private static string azureMistralSmallAPIKey = Environment.GetEnvironmentVariable("AzureMistralSmallAPIKey");

	private static OpenAIClient client = new OpenAIClient(azureOpenAIResourceUri, azureOpenAIApiKey);

	private static string chatTableconnectionString = Environment.GetEnvironmentVariable("CENTRAL_API_STORAGE_CONNECTION_STRING");

	private static List<string> followupQuestions = new List<string> { "Why?", "How?", "Tell me more..." };

	private static TableClient chatTableClient = new TableClient(chatTableconnectionString, "ChatMessage");

	private static TableServiceClient presetQuestionEmbeddingsServiceClient;

	private static TableClient presetQuestionEmbeddingsTableClient;

	public static HttpClientHandler Handler { get; } = new HttpClientHandler
	{
		ClientCertificateOptions = ClientCertificateOption.Manual,
		ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
	};

	public static void InitChatAPI()
	{
		string text = "centralapistorage";
		string text2 = "PresetQuestionEmbeddings";
		presetQuestionEmbeddingsServiceClient = new TableServiceClient(new Uri("https://" + text + ".table.core.windows.net/" + text2), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		presetQuestionEmbeddingsTableClient = presetQuestionEmbeddingsServiceClient.GetTableClient(text2);
	}

	public static async Task<string> AutoReplySillyQuestion(string userQuestion)
	{
		if (userQuestion.Length < 5)
		{
			return "That's not a valid question! Please use your brain dear friendo \ud83e\udde0<br>Ask a proper question about understanding your horoscope's predictions<br>Use the ready made questions as a template. \ud83d\ude09";
		}
		Dictionary<List<string>, string> responses = new Dictionary<List<string>, string>
		{
			{
				new List<string>(10) { "dasa", "when", "month", "week", "day", "hour", "minute", "date", "time", "tomorrow" },
				"My job is to interpret Horoscope text, not predict <strong>when</strong> things will happen<br>\ud83c\udfafThe super accurate <strong>Life Predictor</strong> is what you need!1. Go to <strong>Life Predictor</strong> page<br>2. Click <strong>Calculate</strong>, make a cup of tea while waiting \ud83c\udf75<br>3. Scroll down and analyse Steve, Marilyn's and Elon's chart \ud83e\uddd0<br>4. Based on that analysis, you can accurately <strong>predict your future</strong> to the week! \ud83d\uddd3\ufe0f<br>Very easy, give it a try friendo \ud83d\ude01"
			},
			{
				new List<string>(1) { "fastAsker" },
				"You're asking question like a race car \ud83c\udfce\ufe0f (so fast, but going no where)<br>Did you even properly read the replies I've given?\ud83d\ude05<br>Please take the time and understand first! \ud83e\uddd0else you're just wasting public compute resources without care."
			},
			{
				new List<string>(6) { "show", "zodiac", "sign", "house", "planet", "lagna" },
				"I'm not a Super AI that can do everything.\ud83d\ude05<br>To see <strong>raw astro</strong> details :<br>1. Go to <strong>Horoscope</strong> page<br>2. Click <strong>Calculate</strong> and scroll down! \ud83d\uddb1\ufe0f<br>It's not that difficult friendo \ud83d\ude01"
			},
			{
				new List<string>(1) { "noFeedbackEver" },
				"You've asked many questions. And yet <strong>not 1 feedback</strong> you gave!\ud83d\ude05<br>Why friendo?<br>Is all my answers not worthy of feedback?<br>If you don't rate the quality of the answers,<br>how am supposed to learn and improve? (I'm not a mind reader)<br>Please click Good \ud83d\udc4d or Bad \ud83d\udc4e feedback button...so I can <strong>better serve you</strong> friendo \ud83d\ude01"
			},
			{
				new List<string>(1) { "tellFriends" },
				"You like to chat with me. \ud83d\udc8c<br>But you <strong>have not introduced me</strong> to your friends in FB, Insta or Twitter<br>Why friendo? \ud83e\udd14<br>Don't you want others to be helped also?<br>If you don't share me with friends and family,<br>how is the world we share supposed to improve?<br>Please post about me in FB, Insta or Twitter, ...so I can <strong>better serve you</strong> friendo \ud83d\ude01"
			}
		};
		return FindResponse(userQuestion);
		string FindResponse(string text)
		{
			foreach (KeyValuePair<List<string>, string> item in responses)
			{
				if (item.Key.Any((string keyword) => text.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
				{
					return item.Value;
				}
			}
			return "";
		}
	}

	public static async Task<JObject> SendMessageHoroscopeFollowUp(Time birthTime, string followUpQuestion = "", string primaryAnswerHash = "", string userId = "", string sessionId = "")
	{
		SaveToTable(new ChatMessageEntity(sessionId, birthTime, followUpQuestion, "Human", userId));
		ChatMessageEntity chatMessageEntity = ReadFromTable(sessionId, primaryAnswerHash);
		string text = chatMessageEntity.Text;
		int messageNumber = chatMessageEntity.MessageNumber - 1;
		string text2 = ReadFromTableByMessageNumber(sessionId, messageNumber).Text;
		string horoscopePredictions = GetPredictionAsChunks(birthTime)[0];
		_ = SaveToTable(new ChatMessageEntity(sessionId, birthTime, await AnswerFollowUpHoroscopeQuestion_CohereCommandRPlus(text2, text, horoscopePredictions, followUpQuestion), "AI", userId)).RowKey;
		new List<string>();
		throw new NotImplementedException();
	}

	public static async Task<JObject> HoroscopeChatFeedback(string answerHash, int feedbackScore)
	{
		string filter = "RowKey eq '" + answerHash + "'";
		ChatMessageEntity chatMessageEntity = chatTableClient.Query<ChatMessageEntity>(filter).FirstOrDefault();
		chatMessageEntity.Rating += feedbackScore;
		chatTableClient.UpsertEntity(chatMessageEntity, TableUpdateMode.Replace);
		new List<string>();
		_ = chatMessageEntity.PartitionKey;
		new List<string>().Add("noFeedback");
		Tools.GenerateId(10);
		throw new NotImplementedException();
	}

	public static async Task<JObject> SendMessageHoroscope2(Time birthTime, string userQuestion, string sessionId, string userId)
	{
		string aiReplyText = "";
		if (string.IsNullOrEmpty(aiReplyText))
		{
			await AutoReplySillyQuestion(userQuestion);
		}
		if (string.IsNullOrEmpty(aiReplyText))
		{
			await AnswerHoroscopeQuestion(birthTime, userQuestion);
		}
		throw new NotImplementedException();
	}

	public static async Task<JObject> SendMessageHoroscope(Time birthTime, string userQuestion, string sessionId, string userId)
	{
		if (string.IsNullOrEmpty(sessionId))
		{
			sessionId = Tools.GenerateId();
		}
		SaveToTable(new ChatMessageEntity(sessionId, birthTime, userQuestion, "Human", userId));
		await IsHoroscopeAstrology(birthTime, userQuestion);
		throw new NotImplementedException();
	}

	public static int GetLastMessageNumberNumberFromSessionId(string sessionId)
	{
		Expression<Func<ChatMessageEntity, bool>> filter = (ChatMessageEntity call) => call.PartitionKey == sessionId;
		return (chatTableClient?.Query(filter)?.OrderByDescending((ChatMessageEntity call) => call.Timestamp)?.FirstOrDefault())?.MessageNumber ?? 0;
	}

	public static async Task<JObject> SendMessageMatch(Time maleBirthTime, Time femaleBirthTime, string userQuestion, string sessionId = "")
	{
		throw new NotImplementedException();
	}

	public static async Task<List<PresetQuestionEmbeddingsEntity>> FindPresetQuestionEmbeddings_CohereEmbed(string userQuestion)
	{
		JToken jToken = (await GetEmbeddingsForTextList_CohereEmbed(new string[1] { userQuestion }, "search_query"))["embeddings"][0];
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 100; i++)
		{
			double num = double.Parse(jToken[i].ToString());
			double num2 = num * 2.0;
			string value = (num - num2).ToString().Truncate(7, "");
			string value2 = (num + num2).ToString().Truncate(7, "");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(27, 4, stringBuilder2);
			handler.AppendLiteral("(Vector");
			handler.AppendFormatted(i + 1);
			handler.AppendLiteral(" ge ");
			handler.AppendFormatted(value);
			handler.AppendLiteral(" and Vector");
			handler.AppendFormatted(i + 1);
			handler.AppendLiteral(" le ");
			handler.AppendFormatted(value2);
			handler.AppendLiteral(")");
			stringBuilder2.Append(ref handler);
			if (i != 99)
			{
				stringBuilder.Append(" or ");
			}
		}
		string filter = stringBuilder.ToString();
		InitChatAPI();
		return presetQuestionEmbeddingsTableClient.Query<PresetQuestionEmbeddingsEntity>(filter)?.ToList() ?? new List<PresetQuestionEmbeddingsEntity>();
	}

	public static async Task LLMSearchAPICall_CohereEmbed(string searchKeywords)
	{
		double[] target = (await GetEmbeddingsForTextList_CohereEmbed(new string[1] { searchKeywords }, "search_query"))["embeddings"][0].Select((JToken jv) => (double)jv).ToArray();
		string filter = "PartitionKey eq 'APICall'";
		InitChatAPI();
		List<PresetQuestionEmbeddingsEntity> candidatesList = presetQuestionEmbeddingsTableClient.Query<PresetQuestionEmbeddingsEntity>(filter)?.ToList();
		Dictionary<double, PresetQuestionEmbeddingsEntity> similarity = GetSimilarity(target, candidatesList);
		OpenAPIMetadata.FromMethodInfoList();
		foreach (KeyValuePair<double, PresetQuestionEmbeddingsEntity> item in similarity.Take(10).ToDictionary((KeyValuePair<double, PresetQuestionEmbeddingsEntity> x) => x.Key, (KeyValuePair<double, PresetQuestionEmbeddingsEntity> x) => x.Value))
		{
			Console.WriteLine($"{item.Key} = {item.Value.RowKey}");
		}
	}

	public static Dictionary<double, PresetQuestionEmbeddingsEntity> GetSimilarity(double[] target, List<PresetQuestionEmbeddingsEntity> candidatesList)
	{
		Dictionary<double, PresetQuestionEmbeddingsEntity> dictionary = new Dictionary<double, PresetQuestionEmbeddingsEntity>();
		foreach (PresetQuestionEmbeddingsEntity candidates in candidatesList)
		{
			double key = NLPTools.CosineSimilarity(target, candidates.GetEmbeddingsArray());
			dictionary.Add(key, candidates);
		}
		return dictionary.OrderByDescending((KeyValuePair<double, PresetQuestionEmbeddingsEntity> x) => x.Key).ToDictionary((KeyValuePair<double, PresetQuestionEmbeddingsEntity> x) => x.Key, (KeyValuePair<double, PresetQuestionEmbeddingsEntity> x) => x.Value);
	}

	public static async Task CreatePresetQuestionEmbeddings_CohereEmbed()
	{
		List<OpenAPIMetadata> methodListAll = OpenAPIMetadata.FromMethodInfoList().Take(10).ToList();
		List<string> list = new List<string>();
		foreach (OpenAPIMetadata item2 in methodListAll)
		{
			string item = item2.Name + ":" + item2.SearchText;
			list.Add(item);
		}
		string[] presetQuestions = list.ToArray();
		JToken jToken = (await GetEmbeddingsForTextList_CohereEmbed(presetQuestions, "search_document"))["embeddings"];
		List<PresetQuestionEmbeddingsEntity> list2 = new List<PresetQuestionEmbeddingsEntity>();
		for (int i = 0; i < presetQuestions.Length; i++)
		{
			PresetQuestionEmbeddingsEntity presetQuestionEmbeddingsEntity = new PresetQuestionEmbeddingsEntity();
			presetQuestionEmbeddingsEntity.RowKey = methodListAll[i].Name;
			presetQuestionEmbeddingsEntity.PartitionKey = "APICall";
			presetQuestionEmbeddingsEntity.Embeddings = jToken[i].ToString(Formatting.None);
			list2.Add(presetQuestionEmbeddingsEntity);
		}
		InitChatAPI();
		foreach (PresetQuestionEmbeddingsEntity item3 in list2)
		{
			presetQuestionEmbeddingsTableClient.UpsertEntity(item3);
		}
	}

	public static async Task<JObject> GetEmbeddingsForTextList_CohereEmbed(string[] inputTextList, string inputType)
	{
		JObject finalResult = new JObject();
		int textsPerBatch = 95;
		HttpClient httpClient = new HttpClient(Handler);
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureCohereEmbedAPIKey);
		httpClient.BaseAddress = new Uri("https://Cohere-embed-v3-english-bkovp-serverless.westus.inference.ai.azure.com/v1/embed");
		using HttpClient client = httpClient;
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
		return finalResult;
	}

	private static async Task<HttpResponseMessage> MakeApiCall(HttpClient client, string[] textArray, string inputType)
	{
		StringContent content = new StringContent(JsonConvert.SerializeObject(new
		{
			model = "embed-english-v3.0",
			texts = textArray,
			input_type = inputType,
			truncate = "NONE"
		}), Encoding.UTF8, "application/json");
		return await client.PostAsync("", content);
	}

	private static async Task<string> AnswerFollowUpHoroscopeQuestion_CohereCommandRPlus(string primaryQuestion, string primaryAnswer, string horoscopePredictions, string followUpQuestion)
	{
		var array = new[]
		{
			new
			{
				role = "system",
				content = "an over confident astrologer, use context text\nCONTEXT:\n\n" + horoscopePredictions
			},
			new
			{
				role = "user",
				content = (primaryQuestion ?? "")
			},
			new
			{
				role = "assistant",
				content = (primaryAnswer ?? "")
			},
			new
			{
				role = "user",
				content = followUpQuestion + "?"
			}
		};
		PredictionSettings obj = new PredictionSettings
		{
			ServerUrl = "https://Cohere-command-r-plus-rusng-serverless.westus.inference.ai.azure.com/v1/chat/completions",
			ApiKey = azureCohereCommandRPlusAPIKey,
			MaxTokens = 600.0,
			Temperature = 0.9,
			TopP = 0.1
		};
		object[] sysMessage = array;
		obj.SysMessage = sysMessage;
		return await ProcessPrediction(obj);
	}

	private static async Task<string> AnswerHoroscopeQuestion_CohereCommandRPlus(string userQuestion, string horoscopePredictions)
	{
		var array = new[]
		{
			new
			{
				role = "system",
				content = "confident expert astrologer, based on CONTEXT text, judge based on Weight\nCONTEXT:\n\n" + horoscopePredictions
			},
			new
			{
				role = "user",
				content = (userQuestion ?? "")
			}
		};
		PredictionSettings obj = new PredictionSettings
		{
			ServerUrl = "https://Cohere-command-r-plus-rusng-serverless.westus.inference.ai.azure.com/v1/chat/completions",
			ApiKey = azureCohereCommandRPlusAPIKey,
			MaxTokens = 600.0,
			Temperature = 0.7,
			TopP = 0.4
		};
		object[] sysMessage = array;
		obj.SysMessage = sysMessage;
		return await ProcessPrediction(obj);
	}

	private static JObject PackageReply(Time birthTime, string userId, string userQuestion, string aiReplyText, List<string> followUpQuestions, string sessionId, string aiReplyHtml = "", List<string> commands = null)
	{
		string rowKey = SaveToTable(new ChatMessageEntity(sessionId, birthTime, aiReplyText, "AI", userId)).RowKey;
		string text = (string.IsNullOrEmpty(aiReplyHtml) ? aiReplyText : aiReplyHtml);
		if (commands == null)
		{
			commands = new List<string>();
		}
		return new JObject
		{
			{ "SessionId", sessionId },
			{ "Text", aiReplyText },
			{ "TextHtml", text },
			{ "TextHash", rowKey },
			{
				"FollowUpQuestions",
				new JArray(followUpQuestions)
			},
			{
				"Commands",
				new JArray(commands)
			}
		};
	}

	private static ChatMessageEntity ReadFromTableByMessageNumber(string sessionId, int messageNumber)
	{
		Expression<Func<ChatMessageEntity, bool>> filter = (ChatMessageEntity call) => call.PartitionKey == sessionId && call.MessageNumber == messageNumber;
		return chatTableClient.Query(filter).FirstOrDefault();
	}

	public static ChatMessageEntity ReadFromTable(string sessionId, string messageHash)
	{
		string filter = $"PartitionKey eq '{sessionId}' and RowKey ge '{messageHash}'";
		return chatTableClient.Query<ChatMessageEntity>(filter).FirstOrDefault();
	}

	public static ChatMessageEntity SaveToTable(ChatMessageEntity inputChatMessageEntity)
	{
		chatTableClient.AddEntity(inputChatMessageEntity);
		return inputChatMessageEntity;
	}

	private static bool IsElectionalAstrology(Time birthTime, string userQuestion, out string replyText)
	{
		JObject jObject = JObject.Parse(Task.WhenAll(new List<Task<string>> { ExtractTimeRange_MistralLarge(birthTime, userQuestion) }).Result.FirstOrDefault());
		bool.TryParse(jObject["valid"].ToString(), out var result);
		bool flag = false;
		if (result)
		{
			flag = IsTimeRangeValid(jObject, out var _);
		}
		if (!flag)
		{
			replyText = "";
			return false;
		}
		replyText = "Muhurtha feature still being coded. Please come back next week.";
		return true;
		bool IsTimeRangeValid(JObject timeRangeJson, out TimeRange reference)
		{
			try
			{
				string text = timeRangeJson["start"].Value<string>();
				string text2 = timeRangeJson["end"].Value<string>();
				Time start = new Time("00:00 " + text + " " + birthTime.StdTimezoneText, birthTime.GetGeoLocation());
				Time end = new Time("00:00 " + text2 + " " + birthTime.StdTimezoneText, birthTime.GetGeoLocation());
				reference = new TimeRange(start, end);
				return true;
			}
			catch (Exception)
			{
				reference = null;
				return false;
			}
		}
	}

	private static async Task<string> IsHoroscopeAstrology(Time birthTime, string userQuestion)
	{
		List<string> predictionAsChunks = GetPredictionAsChunks(birthTime);
		return await AnswerQuestionDirectly_CohereCommandRPlus(await PickOutMostRelevantPredictions_MistralSmall(birthTime, userQuestion, predictionAsChunks[0]), userQuestion);
	}

	private static async Task<string> AnswerHoroscopeQuestion(Time birthTime, string userQuestion)
	{
		List<string> predictionAsChunks = GetPredictionAsChunks(birthTime);
		return await AnswerQuestionDirectly_CohereCommandRPlus(await PickOutMostRelevantPredictions_MistralSmall(birthTime, userQuestion, predictionAsChunks[0]), userQuestion);
	}

	private static List<string> GetPredictionAsChunks(Time birthTime)
	{
		List<HoroscopePrediction> horoscopePrediction = Tools.GetHoroscopePrediction(birthTime);
		List<object> list = new List<object>();
		foreach (HoroscopePrediction item3 in horoscopePrediction)
		{
			double num = item3.RelatedBody.RelatedHouses.Sum((HouseName relatedHouse) => Calculate.HouseStrength(relatedHouse, birthTime).ToDouble());
			num += item3.RelatedBody.RelatedPlanets.Sum((PlanetName relatedHouse) => Calculate.PlanetStrength(relatedHouse, birthTime).ToDouble());
			var item = new
			{
				Name = item3.FormattedName,
				Description = item3.Description,
				Relevance = string.Empty,
				Weight = num
			};
			list.Add(item);
		}
		list = list.OrderByDescending((dynamic prediction) => prediction.Weight).ToList();
		list.RemoveAll((dynamic prediction) => prediction.Weight == 0);
		string item2 = JsonConvert.SerializeObject(list, Formatting.None);
		return new List<string> { item2 };
	}

	private static async Task<string> AnswerQuestionDirectly_MetaLlama3(string answerLevelN, string userQuestion)
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
		string str = $"analyse life description text, answer question directly\nQUESTION:\n{userQuestion}\nLIFE DESCRIPTION:\n{answerLevelN}";
		str = Regex.Unescape(str);
		using HttpClient client = new HttpClient(handler);
		string content = JsonConvert.SerializeObject(new
		{
			messages = new[]
			{
				new
				{
					role = "user",
					content = str
				}
			},
			max_tokens = 2000,
			temperature = 0.8,
			top_p = 0.1,
			best_of = 1,
			presence_penalty = 0,
			use_beam_search = "false",
			ignore_eos = "false",
			skip_special_tokens = "false",
			logprobs = "false"
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureMetaLlama3APIKey);
		client.BaseAddress = new Uri("https://Meta-Llama-3-70B-Instruct-ydbrc-serverless.westus.inference.ai.azure.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		HttpResponseMessage httpResponseMessage = await client.PostAsync("", stringContent);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			return new LlamaReplyJson(await httpResponseMessage.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
		}
		Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
		Console.WriteLine(httpResponseMessage.Headers.ToString());
		return await httpResponseMessage.Content.ReadAsStringAsync();
	}

	private static async Task<string> AnswerQuestionDirectly_MistralSmall(string answerLevelN, string userQuestion)
	{
		var array = new[]
		{
			new
			{
				role = "system",
				content = $"as expert astrologer analyse life description text, concise answer, based on relevance and weight answer question with reason\nQUESTION:\n{userQuestion}\nLIFE DESCRIPTION:\n{answerLevelN}"
			}
		};
		PredictionSettings obj = new PredictionSettings
		{
			ServerUrl = "https://Mistral-small-xcvuv-serverless.westus.inference.ai.azure.com/v1/chat/completions",
			ApiKey = azureMistralSmallAPIKey,
			MaxTokens = 600.0,
			Temperature = 0.5,
			TopP = 0.2
		};
		object[] sysMessage = array;
		obj.SysMessage = sysMessage;
		return await ProcessPrediction(obj);
	}

	private static async Task<string> AnswerQuestionDirectly_CohereCommandRPlus(string answerLevelN, string userQuestion)
	{
		var array = new[]
		{
			new
			{
				role = "user",
				content = $"as expert astrologer analyse life description text, concise answer, based on relevance and weight answer question with reason\nQUESTION:\n{userQuestion}\nLIFE DESCRIPTION:\n{answerLevelN}"
			}
		};
		PredictionSettings obj = new PredictionSettings
		{
			ServerUrl = "https://Cohere-command-r-plus-rusng-serverless.westus.inference.ai.azure.com/v1/chat/completions",
			ApiKey = azureCohereCommandRPlusAPIKey,
			MaxTokens = 600.0,
			Temperature = 0.5,
			TopP = 0.5
		};
		object[] sysMessage = array;
		obj.SysMessage = sysMessage;
		return await ProcessPrediction(obj);
	}

	private static async Task<string> HighlightKeywords(string userQuestion, string answerLevel3)
	{
		return answerLevel3;
	}

	private static async Task<string> HighlightKeywords_MistralLarge(string answerText, string userQuestion)
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
		string content = "Follow rules:\n1. Output ANSWER text in HTML format for use between <p> tag element\n2. Highlight relevant words and phrases in ANSWER that is related to QUESTION\n3. Break long text and organize ANSWER text structure for easy readability.4. All html element must be valid to be placed inside <p> tag element\n";
		using HttpClient client = new HttpClient(handler);
		string content2 = JsonConvert.SerializeObject(new
		{
			messages = new[]
			{
				new
				{
					role = "system",
					content = content
				},
				new
				{
					role = "user",
					content = "QUESTION:\n\n" + userQuestion + "\n\nANSWER:\n\n" + answerText
				}
			},
			max_tokens = 300,
			temperature = 0.8,
			top_p = 0.4,
			safe_prompt = "false"
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureMistralLargeAPIKey);
		client.BaseAddress = new Uri("https://Mistral-large-cahy-serverless.westus.inference.ai.azure.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content2);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		HttpResponseMessage httpResponseMessage = await client.PostAsync("", stringContent);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			return new LlamaReplyJson(await httpResponseMessage.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
		}
		Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
		Console.WriteLine(httpResponseMessage.Headers.ToString());
		return await httpResponseMessage.Content.ReadAsStringAsync();
	}

	private static async Task<string> HighlightKeywords_MistralSmall(string answerText, string userQuestion)
	{
		var array = new[]
		{
			new
			{
				role = "system",
				content = "bold and paragraph structure DESCRIPTION text as HTML based on relevance to TOPIC text"
			},
			new
			{
				role = "user",
				content = "{TOPIC:\"Quantum Computing\", DESCRIPTION:\"Quantum Computing uses principles of quantum mechanics to process information. It’s expected to revolutionize computing by performing complex calculations quickly.\"}"
			},
			new
			{
				role = "assistant",
				content = "<p><strong>Quantum Computing</strong> uses principles of <strong>quantum mechanics</strong> to process information.<br> It's expected to revolutionize computing by performing complex calculations quickly. </p>"
			},
			new
			{
				role = "user",
				content = "{TOPIC:\"Artificial Intelligence\", DESCRIPTION:\"Artificial Intelligence (AI) refers to the simulation of human intelligence in machines that are programmed to think like humans and mimic their actions.\"}"
			},
			new
			{
				role = "assistant",
				content = "<p>This term refers to the simulation of <strong>human intelligence in machines</strong>.<br>  These machines are <strong>programmed to think</strong> like humans and mimic their actions, <br> which is a significant advancement in the field of technology.</p>"
			},
			new
			{
				role = "user",
				content = $"{{TOPIC:\"{userQuestion}\", DESCRIPTION:\"{answerText}\"}}"
			}
		};
		PredictionSettings obj = new PredictionSettings
		{
			ServerUrl = "https://Cohere-command-r-plus-rusng-serverless.westus.inference.ai.azure.com/v1/chat/completions",
			ApiKey = azureCohereCommandRPlusAPIKey,
			MaxTokens = 8196.0,
			Temperature = 0.4,
			TopP = 0.1
		};
		object[] sysMessage = array;
		obj.SysMessage = sysMessage;
		return await ProcessPrediction(obj);
	}

	private static async Task<string> RemoveAnyDisclaimers(string rawAnswer, string userQuestion)
	{
		ChatCompletionsOptions chatCompletionsOptions = new ChatCompletionsOptions
		{
			DeploymentName = "chatapi-mk8",
			Messages = { (ChatRequestMessage)new ChatRequestSystemMessage("Provide a confident answer without any disclaimers for the following text:\n```TEXT\n" + rawAnswer + "```") },
			Temperature = 0.7f,
			MaxTokens = 300,
			NucleusSamplingFactor = 0.95f,
			FrequencyPenalty = 0f,
			PresencePenalty = 0f,
			ResponseFormat = ChatCompletionsResponseFormat.Text
		};
		return (await client.GetChatCompletionsAsync(chatCompletionsOptions)).Value.Choices[0].Message.Content;
	}

	private static async Task<string> RemoveAnyDisclaimers_MistralLarge(string answerLevel1, string userQuestion)
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
		string content = "Provide a confident answer without any disclaimers for the following text:\n```TEXT\n" + answerLevel1 + "```";
		using HttpClient client = new HttpClient(handler);
		string content2 = JsonConvert.SerializeObject(new
		{
			messages = new[]
			{
				new
				{
					role = "user",
					content = content
				}
			},
			max_tokens = 300,
			temperature = 0.8,
			top_p = 0.4,
			safe_prompt = "false"
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureMistralLargeAPIKey);
		client.BaseAddress = new Uri("https://Mistral-large-cahy-serverless.westus.inference.ai.azure.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content2);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		HttpResponseMessage httpResponseMessage = await client.PostAsync("", stringContent);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			return new LlamaReplyJson(await httpResponseMessage.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
		}
		Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
		Console.WriteLine(httpResponseMessage.Headers.ToString());
		return await httpResponseMessage.Content.ReadAsStringAsync();
	}

	public static async Task<string> RemoveAnyDisclaimers_CohereEmebed(Time birthTime, string userQuestion, string sessionId, string userId)
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
		string result = "";
		using (HttpClient client = new HttpClient(handler))
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(new
			{
				texts = new string[4] { "NATO Parliamentary Assembly declares Russia to be a ‘terrorist state’", "Fifa and Qatar in urgent talks after Wales rainbow hats confiscated | Fifa and the Qataris were in talks on the matter on Tuesday, where Fifa reminded their hosts of their assurances before the tournament that everyone was welcome and rainbow flags would be allowed.", "Qatar Bans Beer Sales at World Cup Stadiums", "Biden calls 'emergency' meeting after missile hits Poland" },
				input_type = "classification",
				truncate = "NONE"
			}), Encoding.UTF8, "application/json");
			if (string.IsNullOrEmpty("vM3mewMokdtgovcDOWcCLztwj0IBWlc4"))
			{
				throw new Exception("A key should be provided to invoke the endpoint");
			}
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "vM3mewMokdtgovcDOWcCLztwj0IBWlc4");
			client.BaseAddress = new Uri("https://Cohere-embed-v3-english-bkovp-serverless.westus.inference.ai.azure.com/v1/embed");
			HttpResponseMessage httpResponseMessage = await client.PostAsync("", content);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				result = await httpResponseMessage.Content.ReadAsStringAsync();
				Console.WriteLine("Result: {0}", result);
			}
			else
			{
				Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
				Console.WriteLine(httpResponseMessage.Headers.ToString());
				Console.WriteLine(await httpResponseMessage.Content.ReadAsStringAsync());
			}
		}
		return result;
	}

	private static async Task<string> ImproveFinalAnswer(string answerLevel1, string userQuestion)
	{
		string content = $"summarize below raw answer as reply to this question, '{userQuestion}?'\nsummary is easier to understand,'\nRAW ANSWER:\n{answerLevel1}";
		ChatCompletionsOptions chatCompletionsOptions = new ChatCompletionsOptions
		{
			DeploymentName = "chatapi-mk8",
			Messages = { (ChatRequestMessage)new ChatRequestSystemMessage(content) },
			Temperature = 0.7f,
			MaxTokens = 300,
			NucleusSamplingFactor = 0.95f,
			FrequencyPenalty = 0f,
			PresencePenalty = 0f
		};
		return (await client.GetChatCompletionsAsync(chatCompletionsOptions)).Value.Choices[0].Message.Content;
	}

	private static async Task<string> ImproveFinalAnswer_MistralLarge(string answerLevelN, string userQuestion)
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
		string content = $"summarize below raw answer as reply to this question, '{userQuestion}?'\nsummary is easier to understand,'\nRAW ANSWER:\n{answerLevelN}";
		using HttpClient client = new HttpClient(handler);
		string content2 = JsonConvert.SerializeObject(new
		{
			messages = new[]
			{
				new
				{
					role = "user",
					content = content
				}
			},
			max_tokens = 300,
			temperature = 0.8,
			top_p = 0.4,
			safe_prompt = "false"
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureMistralLargeAPIKey);
		client.BaseAddress = new Uri("https://Mistral-large-cahy-serverless.westus.inference.ai.azure.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content2);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		HttpResponseMessage httpResponseMessage = await client.PostAsync("", stringContent);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			return new LlamaReplyJson(await httpResponseMessage.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
		}
		Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
		Console.WriteLine(httpResponseMessage.Headers.ToString());
		return await httpResponseMessage.Content.ReadAsStringAsync();
	}

	private static async Task<string> ImproveFinalAnswer_MistralSmall(string answerLevelN, string userQuestion)
	{
		HttpClientHandler handler = CreateHttpClientHandler();
		StringContent stringContent = new StringContent(CreateRequestBody(PrepareSystemMessage()));
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		using (HttpClient client = new HttpClient(handler))
		{
			return await ProcessResponseAsync(await PostRequestAsync(client, stringContent));
		}
		static HttpClientHandler CreateHttpClientHandler()
		{
			return new HttpClientHandler
			{
				ClientCertificateOptions = ClientCertificateOption.Manual,
				ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
			};
		}
		static string CreateRequestBody(string sysMessage)
		{
			return JsonConvert.SerializeObject(new
			{
				messages = new[]
				{
					new
					{
						role = "user",
						content = sysMessage
					}
				},
				max_tokens = 300,
				temperature = 0.8,
				top_p = 0.5,
				safe_prompt = "false"
			});
		}
		static async Task<HttpResponseMessage> PostRequestAsync(HttpClient httpClient, StringContent content)
		{
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureMistralSmallAPIKey);
			httpClient.BaseAddress = new Uri("https://Mistral-small-xcvuv-serverless.westus.inference.ai.azure.com/v1/chat/completions");
			return await httpClient.PostAsync("", content);
		}
		string PrepareSystemMessage()
		{
			return Regex.Unescape($"summarize below raw answer as reply to this question, '{userQuestion}?'\nsummary is easier to understand,'\nRAW ANSWER:\n{answerLevelN}");
		}
		static async Task<string> ProcessResponseAsync(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
			{
				return new LlamaReplyJson(await response.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
			}
			Console.WriteLine($"The request failed with status code: {response.StatusCode}");
			Console.WriteLine(response.Headers.ToString());
			return await response.Content.ReadAsStringAsync();
		}
	}

	private static async Task<string> PickOutMostRelevantPredictions_GPT4(Time birthTime, string userQuestion)
	{
		string text = Tools.ListToJson(Tools.GetHoroscopePrediction(birthTime)).ToString(Formatting.None);
		string content = "Output only JSON.\nReturn all predictions that is relevant to the question, '" + userQuestion + "'.Sort based on relevance, most relevant at top\n```JSON\n" + text + "```";
		ChatCompletionsOptions chatCompletionsOptions = new ChatCompletionsOptions
		{
			DeploymentName = "chatapi-mk8",
			Messages = { (ChatRequestMessage)new ChatRequestSystemMessage(content) },
			Temperature = 0.2f,
			MaxTokens = 4096,
			NucleusSamplingFactor = 0.95f,
			FrequencyPenalty = 0f,
			PresencePenalty = 0f,
			ResponseFormat = ChatCompletionsResponseFormat.JsonObject
		};
		return (await client.GetChatCompletionsAsync(chatCompletionsOptions)).Value.Choices[0].Message.Content;
	}

	private static async Task<string> PickOutMostRelevantPredictions_MetaLlama3(Time birthTime, string userQuestion)
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
		string text = Tools.ListToJson(Tools.GetHoroscopePrediction(birthTime)).ToString(Formatting.None);
		string str = "Output only JSON.\nReturn all predictions that is relevant to the question, '" + userQuestion + "'.Sort based on relevance, most relevant at top\n```JSON\n" + text + "```";
		str = Regex.Unescape(str);
		using HttpClient client = new HttpClient(handler);
		string content = JsonConvert.SerializeObject(new
		{
			messages = new[]
			{
				new
				{
					role = "user",
					content = str
				}
			},
			max_tokens = 3000,
			temperature = 0.8,
			top_p = 0.1,
			best_of = 1,
			presence_penalty = 0,
			use_beam_search = "false",
			ignore_eos = "false",
			skip_special_tokens = "false",
			logprobs = "false"
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureMetaLlama3APIKey);
		client.BaseAddress = new Uri("https://Meta-Llama-3-70B-Instruct-ydbrc-serverless.westus.inference.ai.azure.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		HttpResponseMessage httpResponseMessage = await client.PostAsync("", stringContent);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			return new LlamaReplyJson(await httpResponseMessage.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
		}
		Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
		Console.WriteLine(httpResponseMessage.Headers.ToString());
		return await httpResponseMessage.Content.ReadAsStringAsync();
	}

	private static async Task<string> PickOutMostRelevantPredictions_MistralLarge(Time birthTime, string userQuestion, string predictText)
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
		string str = "Output only JSON.\nReturn all predictions that is relevant to the question, '" + userQuestion + "'.Sort based on relevance, most relevant at top\n```JSON\n" + predictText + "```";
		str = Regex.Unescape(str);
		using HttpClient client = new HttpClient(handler);
		string content = JsonConvert.SerializeObject(new
		{
			messages = new[]
			{
				new
				{
					role = "user",
					content = str
				}
			},
			max_tokens = 8192,
			temperature = 0.8,
			top_p = 0.1,
			safe_prompt = "false"
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureMistralLargeAPIKey);
		client.BaseAddress = new Uri("https://Mistral-large-cahy-serverless.westus.inference.ai.azure.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		HttpResponseMessage httpResponseMessage = await client.PostAsync("", stringContent);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			return new LlamaReplyJson(await httpResponseMessage.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
		}
		Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
		Console.WriteLine(httpResponseMessage.Headers.ToString());
		return await httpResponseMessage.Content.ReadAsStringAsync();
	}

	private static async Task<string> PickOutMostRelevantPredictions_MistralSmall(Time birthTime, string userQuestion, string predictText)
	{
		var array = new[]
		{
			new
			{
				role = "system",
				content = "Output JSON.\nFilter DESCRIPTION relevant to the QUESTION.\nJudge based on weight.\nSort based on relevance, most relevant at top.\n\n"
			},
			new
			{
				role = "user",
				content = "QUESTION:{userQuestion}LIFE DESCRIPTION:{descriptionText}"
			},
			new
			{
				role = "assistant",
				content = "{name:\"{predictionName}\", description:\"{description}\", relevance:\"{relevanceScore}\", weight:\"{weightScore}\"}"
			},
			new
			{
				role = "user",
				content = $"QUESTION:\n{userQuestion}\nLIFE DESCRIPTION:\n{predictText}"
			}
		};
		PredictionSettings obj = new PredictionSettings
		{
			ServerUrl = "https://Mistral-small-xcvuv-serverless.westus.inference.ai.azure.com/v1/chat/completions",
			ApiKey = azureMistralSmallAPIKey,
			MaxTokens = 8196.0,
			Temperature = 0.5,
			TopP = 0.5
		};
		object[] sysMessage = array;
		obj.SysMessage = sysMessage;
		return await ProcessPrediction(obj);
	}

	private static async Task<string> PickOutMostRelevantPredictions_CohereCommandR(Time birthTime, string userQuestion, string predictText)
	{
		var array = new[]
		{
			new
			{
				role = "system",
				content = "Output JSON.\nFilter DESCRIPTION relevant to the QUESTION.\nJudge based on weight.\nSort based on relevance, most relevant at top.\n\n"
			},
			new
			{
				role = "user",
				content = "QUESTION:{userQuestion}LIFE DESCRIPTION:{descriptionText}"
			},
			new
			{
				role = "assistant",
				content = "{name:\"{predictionName}\", description:\"{description}\", relevance:\"{relevanceScore}\", weight:\"{weightScore}\"}"
			},
			new
			{
				role = "user",
				content = $"QUESTION:\n{userQuestion}\nLIFE DESCRIPTION:\n{predictText}"
			}
		};
		PredictionSettings obj = new PredictionSettings
		{
			ServerUrl = "https://Cohere-command-r-plus-rusng-serverless.westus.inference.ai.azure.com/v1/chat/completions",
			ApiKey = azureCohereCommandRPlusAPIKey,
			MaxTokens = 20000.0,
			Temperature = 1.0,
			TopP = 1.0
		};
		object[] sysMessage = array;
		obj.SysMessage = sysMessage;
		return await ProcessPrediction(obj);
	}

	private static async Task<string> ProcessPrediction(PredictionSettings settings)
	{
		HttpClientHandler handler = CreateHttpClientHandler();
		StringContent stringContent = new StringContent(CreateRequestBody(settings.SysMessage, settings.MaxTokens, settings.Temperature, settings.TopP));
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		using HttpClient client = new HttpClient(handler);
		return await ProcessResponseAsync(await PostRequestAsync(client, stringContent, settings.ServerUrl, settings.ApiKey));
	}

	private static string CreateRequestBody(object[] sysMessage, double maxTokens, double temperature, double topP)
	{
		return JsonConvert.SerializeObject(new
		{
			messages = sysMessage,
			max_tokens = maxTokens,
			temperature = temperature,
			top_p = topP,
			safe_prompt = "false"
		});
	}

	private static async Task<HttpResponseMessage> PostRequestAsync(HttpClient client, StringContent content, string serverUrl, string apiKey)
	{
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
		client.BaseAddress = new Uri(serverUrl);
		return await client.PostAsync("", content);
	}

	private static HttpClientHandler CreateHttpClientHandler()
	{
		return new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
	}

	private static async Task<string> ProcessResponseAsync(HttpResponseMessage response)
	{
		if (response.IsSuccessStatusCode)
		{
			return new LlamaReplyJson(await response.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
		}
		Console.WriteLine($"The request failed with status code: {response.StatusCode}");
		Console.WriteLine(response.Headers.ToString());
		return await response.Content.ReadAsStringAsync();
	}

	private static async Task<string> ExtractTimeRange_MistralLarge(Time birthTime, string userQuestion)
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
		using HttpClient client = new HttpClient(handler);
		string content = JsonConvert.SerializeObject(new
		{
			messages = new[]
			{
				new
				{
					role = "user",
					content = "extract time range from this question : ```will i get married in 2014?```"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", start:\"01/01/2014\", end:\"31/12/2014\"}"
				},
				new
				{
					role = "user",
					content = "extract time range from this question : ```will i get married in this year?```"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", start:\"01/01/{thisYear}\", end:\"31/12/{thisYear}\"}"
				},
				new
				{
					role = "user",
					content = "extract time range from this question : ```when will i get married?```"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", start:\"01/01/{birthYear+18}\", end:\"31/12/{birthYear+50}\"}"
				},
				new
				{
					role = "user",
					content = "extract time range from this question : ```should i do business next year?```"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", start:\"01/01/{nextYear}\", end:\"31/12/{nextYear}\"}"
				},
				new
				{
					role = "user",
					content = "extract time range from this question : ```when will i get a job?```"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", start:\"01/01/{birthYear+18}\", end:\"31/12/{birthYear+40}\"}"
				},
				new
				{
					role = "user",
					content = "extract time range from this question : ```describe my life chart```"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", start:\"null\", end:\"null\"}"
				},
				new
				{
					role = "user",
					content = "extract time range from this question : ```Are there any financial highs and lows predicted in my birth chart from the year 2024 to 2027?```"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", start:\"01/01/2024\", end:\"31/12/2027\"}"
				},
				new
				{
					role = "user",
					content = "extract time range from this question : ```My DOB 6th Jan 1982 , Time 5:15 AM and Location Nagpur Maharastra India , I need my job switch information```"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", start:\"null\", end:\"null\"}"
				},
				new
				{
					role = "user",
					content = "extract time range from this question : ```" + userQuestion + "```"
				}
			},
			max_tokens = 8192,
			temperature = 0.8,
			top_p = 0.1,
			safe_prompt = "false"
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureMistralLargeAPIKey);
		client.BaseAddress = new Uri("https://Mistral-large-cahy-serverless.westus.inference.ai.azure.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		HttpResponseMessage httpResponseMessage = await client.PostAsync("", stringContent);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			return new LlamaReplyJson(await httpResponseMessage.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
		}
		Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
		Console.WriteLine(httpResponseMessage.Headers.ToString());
		return await httpResponseMessage.Content.ReadAsStringAsync();
	}

	private static bool IsQuestionValid(string userQuestion, out string replyText)
	{
		JObject jObject = JObject.Parse(Task.WhenAll(new List<Task<string>> { CheckQuestionValidity_MistralLarge(userQuestion) }).Result.FirstOrDefault());
		bool.TryParse(jObject["valid"]?.Value<string>() ?? "false", out var result);
		replyText = jObject["reply"]?.Value<string>() ?? "";
		return result;
	}

	private static async Task<string> CheckQuestionValidity_MistralLarge(string userQuestion)
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback = (HttpRequestMessage httpRequestMessage, X509Certificate2? cert, X509Chain? cetChain, SslPolicyErrors policyErrors) => true
		};
		using HttpClient client = new HttpClient(handler);
		string content = JsonConvert.SerializeObject(new
		{
			messages = new[]
			{
				new
				{
					role = "user",
					content = "hi"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", reply:\"yes hi, please ask questions\"}"
				},
				new
				{
					role = "user",
					content = "how do you work?"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", reply:\"i've analysed predictions about your horoscope, and can answer questions about it\"}"
				},
				new
				{
					role = "user",
					content = "hi"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", reply:\"yes hi, let's talk about your horoscope\"}"
				},
				new
				{
					role = "user",
					content = "I want to learn astrology"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", reply:\"i'm here to help you understand a particular horoscope, not teach you astrology text, sorry\"}"
				},
				new
				{
					role = "user",
					content = "what can you do?"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", reply:\"i'm here to help you understand a particular horoscope\"}"
				},
				new
				{
					role = "user",
					content = "how to generate vedic astro chart "
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", reply:\"to get help on using vedastro please contact us, i'm here to help you understand a particular horoscope\"}"
				},
				new
				{
					role = "user",
					content = "my birth details are date/month/year at location"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", reply:\"i don't need your birth details, i've already analysed your horoscope, please ask questions directly\"}"
				},
				new
				{
					role = "user",
					content = "can you create my chart based on Jan 1, 2001, Delhi 10am"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"false\", reply:\"i don't need your birth details, i've already analysed your horoscope, please ask questions directly\"}"
				},
				new
				{
					role = "user",
					content = "describe yogas in my life"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", reply:\"\"}"
				},
				new
				{
					role = "user",
					content = "character of modi"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", reply:\"\"}"
				},
				new
				{
					role = "user",
					content = "wil he win in 2024 elections ?"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", reply:\"\"}"
				},
				new
				{
					role = "user",
					content = "Can you tell me about money flow throughout the year 2024?"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", reply:\"\"}"
				},
				new
				{
					role = "user",
					content = "Do my stars indicate any entrepreneurial talents or inclinations?"
				},
				new
				{
					role = "assistant",
					content = "{valid:\"true\", reply:\"\"}"
				},
				new
				{
					role = "user",
					content = (userQuestion ?? "")
				}
			},
			max_tokens = 8192,
			temperature = 1,
			top_p = 1,
			safe_prompt = "false"
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureMistralLargeAPIKey);
		client.BaseAddress = new Uri("https://Mistral-large-cahy-serverless.westus.inference.ai.azure.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		HttpResponseMessage httpResponseMessage = await client.PostAsync("", stringContent);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			return new LlamaReplyJson(await httpResponseMessage.Content.ReadAsStringAsync()).Choices.FirstOrDefault().Message.Content;
		}
		Console.WriteLine($"The request failed with status code: {httpResponseMessage.StatusCode}");
		Console.WriteLine(httpResponseMessage.Headers.ToString());
		return await httpResponseMessage.Content.ReadAsStringAsync();
	}

	private static async Task<string> AnswerQuestionDirectly(string relevantPredictions, string userQuestion)
	{
		string content = $"analyse life description text, answer question directly\nQUESTION:\n{userQuestion}\n\nLIFE DESCRIPTION:\n{relevantPredictions}";
		ChatCompletionsOptions chatCompletionsOptions = new ChatCompletionsOptions
		{
			DeploymentName = "chatapi-mk8",
			Messages = { (ChatRequestMessage)new ChatRequestSystemMessage(content) },
			Temperature = 0.7f,
			MaxTokens = 2000,
			NucleusSamplingFactor = 0.95f,
			FrequencyPenalty = 0f,
			PresencePenalty = 0f
		};
		return (await client.GetChatCompletionsAsync(chatCompletionsOptions)).Value.Choices[0].Message.Content;
	}
}
