using System;
using System.Text.RegularExpressions;
using Azure;
using Azure.Data.Tables;

namespace VedAstro.Library;

public class ChatMessageEntity : ITableEntity
{
	public string PartitionKey { get; set; }

	public string RowKey { get; set; }

	public string Sender { get; set; }

	public string Text { get; set; }

	public int Rating { get; set; }

	public int MessageNumber { get; set; }

	public string UserId { get; set; }

	public DateTimeOffset? Timestamp { get; set; }

	public ETag ETag { get; set; }

	public ChatMessageEntity()
	{
	}

	public ChatMessageEntity(string sessionId, Time birthTime, string text, string sender, string userId)
	{
		PartitionKey = sessionId;
		string stringHashCodeMD = Tools.GetStringHashCodeMD5(text, 15);
		string text2 = birthTime.ToUrl().Replace("/", "-");
		string rowKey = Regex.Replace(stringHashCodeMD + text2 + "-" + Tools.GenerateId(5), "[^a-zA-Z0-9\\-\\.\\/_]", "");
		RowKey = rowKey;
		UserId = userId;
		Sender = sender;
		Text = text;
		int lastMessageNumberNumberFromSessionId = ChatAPI.GetLastMessageNumberNumberFromSessionId(sessionId);
		MessageNumber = lastMessageNumberNumberFromSessionId + 1;
	}
}
