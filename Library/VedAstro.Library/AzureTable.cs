using System;
using Azure.Data.Tables;

namespace VedAstro.Library;

public static class AzureTable
{
	public const string AccountName = "vedastrocentralstorage";

	public const string AccountName_Indic = "centralapistorage";

	private static readonly string StorageAccountKey = Secrets.VedAstroCentralStorageKey;

	private static readonly string StorageAccountKey_Indic = Secrets.IndicCentralStorageKey;

	public const string APIAbuseListName = "APIAbuseList";

	public const string PersonListName = "PersonList";

	public const string PersonShareListName = "PersonShareList";

	public const string PersonListRecycleBinName = "PersonListRecycleBin";

	public const string LifeEventListName = "LifeEventList";

	public const string APIAbuseListUri = "https://vedastrocentralstorage.table.core.windows.net/APIAbuseList";

	public const string PersonListUri = "https://vedastrocentralstorage.table.core.windows.net/PersonList";

	public const string PersonListUri_Indic = "https://centralapistorage.table.core.windows.net/PersonList";

	public const string PersonShareListUri = "https://vedastrocentralstorage.table.core.windows.net/PersonShareList";

	public const string PersonListRecycleBinUri = "https://vedastrocentralstorage.table.core.windows.net/PersonListRecycleBin";

	public const string LifeEventListUri = "https://vedastrocentralstorage.table.core.windows.net/LifeEventList";

	public const string LifeEventListUri_Indic = "https://centralapistorage.table.core.windows.net/LifeEventList";

	public static readonly TableClient? PersonList_Indic = new TableServiceClient(new Uri("https://centralapistorage.table.core.windows.net/PersonList"), new TableSharedKeyCredential("centralapistorage", StorageAccountKey_Indic)).GetTableClient("PersonList");

	public static readonly TableClient? APIAbuseList = new TableServiceClient(new Uri("https://vedastrocentralstorage.table.core.windows.net/APIAbuseList"), new TableSharedKeyCredential("vedastrocentralstorage", StorageAccountKey)).GetTableClient("APIAbuseList");

	public static readonly TableClient? PersonListRecycleBin = new TableServiceClient(new Uri("https://vedastrocentralstorage.table.core.windows.net/PersonListRecycleBin"), new TableSharedKeyCredential("vedastrocentralstorage", StorageAccountKey)).GetTableClient("PersonListRecycleBin");

	public static readonly TableClient? LifeEventList_Indic = new TableServiceClient(new Uri("https://centralapistorage.table.core.windows.net/LifeEventList"), new TableSharedKeyCredential("centralapistorage", StorageAccountKey_Indic)).GetTableClient("LifeEventList");

	public static readonly TableClient? PersonShareList = new TableServiceClient(new Uri("https://vedastrocentralstorage.table.core.windows.net/PersonShareList"), new TableSharedKeyCredential("vedastrocentralstorage", StorageAccountKey)).GetTableClient("PersonShareList");
}
