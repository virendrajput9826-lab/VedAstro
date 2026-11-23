using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class Gpt4ReplyJson
{
	public class Choice
	{
		public ContentFilterResults ContentFilterResults { get; set; }

		public string FinishReason { get; set; }

		public int Index { get; set; }

		public object Logprobs { get; set; }

		public Message Message { get; set; }
	}

	public class ContentFilterResults
	{
		public Hate Hate { get; set; }

		public SelfHarm SelfHarm { get; set; }

		public Sexual Sexual { get; set; }

		public Violence Violence { get; set; }
	}

	public class Hate
	{
		public bool Filtered { get; set; }

		public string Severity { get; set; }
	}

	public class SelfHarm
	{
		public bool Filtered { get; set; }

		public string Severity { get; set; }
	}

	public class Sexual
	{
		public bool Filtered { get; set; }

		public string Severity { get; set; }
	}

	public class Violence
	{
		public bool Filtered { get; set; }

		public string Severity { get; set; }
	}

	public class Message
	{
		public string Content { get; set; }

		public string Role { get; set; }
	}

	public class PromptFilterResult
	{
		public int PromptIndex { get; set; }

		public ContentFilterResults ContentFilterResults { get; set; }
	}

	public class Usages
	{
		public int PromptTokens { get; set; }

		public int TotalTokens { get; set; }

		public int CompletionTokens { get; set; }
	}

	public string Id { get; set; }

	public string Object { get; set; }

	public long Created { get; set; }

	public string Model { get; set; }

	public List<Choice> Choices { get; set; }

	public List<PromptFilterResult> PromptFilterResults { get; set; }

	public string SystemFingerprint { get; set; }

	public Usages Usage { get; set; }

	public Gpt4ReplyJson(string json)
	{
		JObject jObject = JObject.Parse(json);
		Id = jObject["id"].ToString();
		Object = jObject["object"].ToString();
		Created = jObject["created"].ToObject<long>();
		Model = jObject["model"].ToString();
		Choices = jObject["choices"].ToObject<List<Choice>>();
		PromptFilterResults = jObject["prompt_filter_results"].ToObject<List<PromptFilterResult>>();
		SystemFingerprint = jObject["system_fingerprint"].ToString();
		int completionTokens = jObject["usage"]["completion_tokens"].ToObject<int>();
		int promptTokens = jObject["usage"]["prompt_tokens"].ToObject<int>();
		int totalTokens = jObject["usage"]["total_tokens"].ToObject<int>();
		Usage = new Usages
		{
			CompletionTokens = completionTokens,
			PromptTokens = promptTokens,
			TotalTokens = totalTokens
		};
	}
}
