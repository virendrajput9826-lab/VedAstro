using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class LlamaReplyJson
{
	public class Choice
	{
		public int Index { get; set; }

		public Message Message { get; set; }

		public string FinishReason { get; set; }

		public object Logprobs { get; set; }

		public object StopReason { get; set; }
	}

	public class Message
	{
		public string Role { get; set; }

		public string Content { get; set; }

		public object ToolCalls { get; set; }
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

	public Usages Usage { get; set; }

	public LlamaReplyJson(string json)
	{
		JObject jObject = JObject.Parse(json);
		Id = jObject["id"].ToString();
		Object = jObject["object"].ToString();
		Created = jObject["created"].ToObject<long>();
		Model = jObject["model"].ToString();
		Choices = jObject["choices"].ToObject<List<Choice>>();
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
