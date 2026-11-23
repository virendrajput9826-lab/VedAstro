using System;
using System.Linq;
using Azure.Data.Tables;

namespace VedAstro.Library;

public static class CallTracker
{
	private static readonly TableServiceClient tableServiceClient;

	private static string tableName;

	private static readonly TableClient tableClient;

	static CallTracker()
	{
		tableName = "CallTracker";
		string uriString = "https://vedastroapistorage.table.core.windows.net/" + tableName;
		string accountName = "vedastroapistorage";
		tableServiceClient = new TableServiceClient(credential: new TableSharedKeyCredential(accountName, Secrets.VedAstroApiStorageKey), endpoint: new Uri(uriString));
		tableClient = tableServiceClient.GetTableClient(tableName);
	}

	public static bool IsRunning(string callerId)
	{
		try
		{
			return (tableClient.Query((CallStatusEntity call) => call.PartitionKey == callerId)?.FirstOrDefault())?.IsRunning ?? false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static void CallStart(string callerId)
	{
		CallStatusEntity entity = new CallStatusEntity
		{
			PartitionKey = callerId,
			RowKey = "",
			IsRunning = true
		};
		tableClient.UpsertEntity(entity);
	}

	public static void CallEnd(string callerId)
	{
		CallStatusEntity entity = new CallStatusEntity
		{
			PartitionKey = callerId,
			RowKey = "",
			IsRunning = false
		};
		tableClient.UpsertEntity(entity);
	}
}
