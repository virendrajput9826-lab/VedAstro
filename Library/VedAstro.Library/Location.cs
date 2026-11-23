using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Data.Tables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class Location
{
	public record GeoLocationRawAPI(dynamic MainRow, dynamic MetadataRow);

	public enum APIProvider
	{
		VedAstro,
		Azure,
		Google,
		IpData
	}

	private readonly TableServiceClient timezoneServiceClient;

	private readonly TableServiceClient timezoneMetadataServiceClient;

	private readonly TableServiceClient addressServiceClient;

	private readonly TableServiceClient searchAddressServiceClient;

	private readonly TableServiceClient addressMetadataServiceClient;

	private readonly TableServiceClient coordinatesServiceClient;

	private readonly TableServiceClient coordinatesMetadataServiceClient;

	private readonly TableServiceClient ipAddressServiceClient;

	private readonly TableServiceClient ipAddressMetadataServiceClient;

	private readonly TableClient timezoneTableClient;

	private readonly TableClient timezoneMetadataTableClient;

	private readonly TableClient addressTableClient;

	private readonly TableClient searchAddressTableClient;

	private readonly TableClient addressMetadataTableClient;

	private readonly TableClient coordinatesTableClient;

	private readonly TableClient coordinatesMetadataTableClient;

	private readonly TableClient ipAddressTableClient;

	private readonly TableClient ipAddressMetadataTableClient;

	public Location()
	{
		string text = "centralapistorage";
		string text2 = "SearchAddressGeoLocation";
		string uriString = "https://" + text + ".table.core.windows.net/" + text2;
		searchAddressServiceClient = new TableServiceClient(new Uri(uriString), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		searchAddressTableClient = searchAddressServiceClient.GetTableClient(text2);
		string text3 = "AddressGeoLocation";
		string uriString2 = "https://" + text + ".table.core.windows.net/" + text3;
		addressServiceClient = new TableServiceClient(new Uri(uriString2), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		addressTableClient = addressServiceClient.GetTableClient(text3);
		string text4 = "AddressGeoLocationMetadata";
		string uriString3 = "https://" + text + ".table.core.windows.net/" + text4;
		addressMetadataServiceClient = new TableServiceClient(new Uri(uriString3), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		addressMetadataTableClient = addressMetadataServiceClient.GetTableClient(text4);
		string text5 = "CoordinatesGeoLocation";
		string uriString4 = "https://" + text + ".table.core.windows.net/" + text5;
		coordinatesServiceClient = new TableServiceClient(new Uri(uriString4), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		coordinatesTableClient = coordinatesServiceClient.GetTableClient(text5);
		string text6 = "CoordinatesGeoLocationMetadata";
		string uriString5 = "https://" + text + ".table.core.windows.net/" + text6;
		coordinatesMetadataServiceClient = new TableServiceClient(new Uri(uriString5), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		coordinatesMetadataTableClient = coordinatesMetadataServiceClient.GetTableClient(text6);
		string text7 = "IpAddressGeoLocation";
		string uriString6 = "https://" + text + ".table.core.windows.net/" + text7;
		ipAddressServiceClient = new TableServiceClient(new Uri(uriString6), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		ipAddressTableClient = ipAddressServiceClient.GetTableClient(text7);
		string text8 = "IpAddressGeoLocationMetadata";
		string uriString7 = "https://" + text + ".table.core.windows.net/" + text8;
		ipAddressMetadataServiceClient = new TableServiceClient(new Uri(uriString7), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		ipAddressMetadataTableClient = ipAddressMetadataServiceClient.GetTableClient(text8);
		string text9 = "GeoLocationTimezone";
		string uriString8 = "https://" + text + ".table.core.windows.net/" + text9;
		timezoneServiceClient = new TableServiceClient(new Uri(uriString8), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		timezoneTableClient = timezoneServiceClient.GetTableClient(text9);
		string text10 = "GeoLocationTimezoneMetadata";
		string uriString9 = "https://" + text + ".table.core.windows.net/" + text10;
		timezoneMetadataServiceClient = new TableServiceClient(new Uri(uriString9), new TableSharedKeyCredential(text, Secrets.AzureGeoLocationStorageKey));
		timezoneMetadataTableClient = timezoneMetadataServiceClient.GetTableClient(text10);
	}

	public async Task<GeoLocation> AddressToGeoLocation(string userInputAddressRaw)
	{
		string userInputAddress = Tools.CleanAzureTableKey(userInputAddressRaw.ToLower());
		Dictionary<APIProvider, Func<string, Task<GeoLocationRawAPI>>> dictionary = new Dictionary<APIProvider, Func<string, Task<GeoLocationRawAPI>>>
		{
			{
				APIProvider.VedAstro,
				AddressToGeoLocation_VedAstro
			},
			{
				APIProvider.Azure,
				AddressToGeoLocation_Azure
			},
			{
				APIProvider.Google,
				AddressToGeoLocation_Google
			}
		};
		GeoLocation geoLocation = GeoLocation.Empty;
		foreach (KeyValuePair<APIProvider, Func<string, Task<GeoLocationRawAPI>>> row in dictionary)
		{
			GeoLocationRawAPI geoLocationRawAPI = await row.Value(userInputAddress);
			geoLocation = geoLocationRawAPI.MainRow.ToGeoLocation();
			bool flag = geoLocation.Name() != GeoLocation.Empty.Name();
			bool flag2 = row.Key != APIProvider.VedAstro;
			if (flag & flag2)
			{
				AddToAddressTable(geoLocationRawAPI.MainRow);
			}
			if (flag)
			{
				break;
			}
		}
		return geoLocation;
	}

	public async Task<List<GeoLocation>> SearchAddressToGeoLocation(string userInputAddressRaw)
	{
		string userInputAddress = Tools.CleanAzureTableKey(userInputAddressRaw.ToLower());
		Dictionary<APIProvider, Func<string, Task<GeoLocationRawAPI>>> dictionary = new Dictionary<APIProvider, Func<string, Task<GeoLocationRawAPI>>>
		{
			{
				APIProvider.VedAstro,
				SearchAddressToGeoLocation_VedAstro
			},
			{
				APIProvider.Azure,
				SearchAddressToGeoLocation_Azure
			}
		};
		List<GeoLocation> list = new List<GeoLocation>();
		foreach (KeyValuePair<APIProvider, Func<string, Task<GeoLocationRawAPI>>> row in dictionary)
		{
			GeoLocationRawAPI geoLocationRawAPI = await row.Value(userInputAddress);
			list = geoLocationRawAPI.MainRow.ToGeoLocationList();
			bool flag = list.Any();
			bool flag2 = row.Key != APIProvider.VedAstro;
			if (flag & flag2)
			{
				AddToSearchAddressTable(geoLocationRawAPI.MainRow);
			}
			if (flag)
			{
				break;
			}
		}
		return list;
	}

	public async Task<GeoLocation> IpAddressToGeoLocation(string ipAddress)
	{
		Dictionary<APIProvider, Func<string, Task<GeoLocationRawAPI>>> dictionary = new Dictionary<APIProvider, Func<string, Task<GeoLocationRawAPI>>>
		{
			{
				APIProvider.VedAstro,
				IpAddressToGeoLocation_VedAstro
			},
			{
				APIProvider.IpData,
				IpAddressToGeoLocation_IpData
			}
		};
		GeoLocation geoLocation = GeoLocation.Empty;
		foreach (KeyValuePair<APIProvider, Func<string, Task<GeoLocationRawAPI>>> row in dictionary)
		{
			GeoLocationRawAPI geoLocationRawAPI = await row.Value(ipAddress);
			geoLocation = geoLocationRawAPI.MainRow.ToGeoLocation();
			bool flag = geoLocation.Name() != GeoLocation.Empty.Name();
			bool flag2 = row.Key != APIProvider.VedAstro;
			if (flag & flag2)
			{
				AddToIpAddressTable(geoLocationRawAPI.MainRow);
				AddToIpAddressMetadataTable(geoLocationRawAPI.MetadataRow);
			}
			if (flag)
			{
				break;
			}
		}
		return geoLocation;
	}

	public async Task<GeoLocation> CoordinatesToGeoLocation(string latitudeStr, string longitudeStr)
	{
		double latitude = Math.Round(double.Parse(latitudeStr), 3);
		double longitude = Math.Round(double.Parse(longitudeStr), 3);
		Dictionary<APIProvider, Func<double, double, Task<GeoLocationRawAPI>>> dictionary = new Dictionary<APIProvider, Func<double, double, Task<GeoLocationRawAPI>>>
		{
			{
				APIProvider.VedAstro,
				CoordinatesToGeoLocation_Vedastro
			},
			{
				APIProvider.Azure,
				CoordinatesToGeoLocation_Google
			}
		};
		GeoLocation geoLocation = GeoLocation.Empty;
		foreach (KeyValuePair<APIProvider, Func<double, double, Task<GeoLocationRawAPI>>> row in dictionary)
		{
			GeoLocationRawAPI geoLocationRawAPI = await row.Value(longitude, latitude);
			geoLocation = geoLocationRawAPI.MainRow.ToGeoLocation();
			bool flag = geoLocation.Name() != GeoLocation.Empty.Name();
			bool flag2 = row.Key != APIProvider.VedAstro;
			if (flag & flag2)
			{
				AddToCoordinatesTable(geoLocationRawAPI.MainRow);
			}
			if (flag)
			{
				break;
			}
		}
		return geoLocation;
	}

	public async Task<string> GeoLocationToTimezone(GeoLocation geoLocation, DateTimeOffset stdTimeAtLocation)
	{
		Dictionary<APIProvider, Func<GeoLocation, DateTimeOffset, Task<GeoLocationRawAPI>>> dictionary = new Dictionary<APIProvider, Func<GeoLocation, DateTimeOffset, Task<GeoLocationRawAPI>>>
		{
			{
				APIProvider.VedAstro,
				GeoLocationToTimezone_Vedastro
			},
			{
				APIProvider.Azure,
				GeoLocationToTimezone_Azure
			},
			{
				APIProvider.Google,
				GeoLocationToTimezone_Google
			}
		};
		string text = "";
		foreach (KeyValuePair<APIProvider, Func<GeoLocation, DateTimeOffset, Task<GeoLocationRawAPI>>> row in dictionary)
		{
			GeoLocationRawAPI geoLocationRawAPI = await row.Value(geoLocation, stdTimeAtLocation);
			text = geoLocationRawAPI.MainRow.TimezoneText;
			bool flag = !string.IsNullOrEmpty(text);
			bool flag2 = row.Key != APIProvider.VedAstro;
			if (flag & flag2)
			{
				AddToTimezoneTable(geoLocationRawAPI.MainRow);
				AddToTimezoneMetadataTable(geoLocationRawAPI.MetadataRow);
			}
			if (flag)
			{
				break;
			}
		}
		return text;
	}

	private void AddToTimezoneTable(GeoLocationTimezoneEntity newRow)
	{
		try
		{
			timezoneTableClient.AddEntity(newRow);
		}
		catch (Exception)
		{
			throw new Exception("Can't add duplicate GeoLocationTimezone row : PartKey:" + newRow.PartitionKey + ", RowKey:" + newRow.RowKey);
		}
	}

	private void AddToTimezoneMetadataTable(GeoLocationTimezoneMetadataEntity newRow)
	{
		try
		{
			timezoneMetadataTableClient.AddEntity(newRow);
		}
		catch (Exception)
		{
		}
	}

	private void AddToIpAddressMetadataTable(IpAddressGeoLocationMetadataEntity newRow)
	{
		try
		{
			ipAddressMetadataTableClient.AddEntity(newRow);
		}
		catch (Exception)
		{
		}
	}

	private void AddToAddressTable(AddressGeoLocationEntity newRow)
	{
		try
		{
			addressTableClient.AddEntity(newRow);
		}
		catch (Exception)
		{
			throw new Exception("Can't add duplicate AddressGeoLocation row : PartKey:" + newRow.PartitionKey + ", RowKey:" + newRow.RowKey);
		}
	}

	private void AddToSearchAddressTable(SearchAddressGeoLocationEntity newRow)
	{
		try
		{
			searchAddressTableClient.AddEntity(newRow);
		}
		catch (Exception)
		{
			throw new Exception("Can't add duplicate SearchAddressGeoLocation row : PartKey:" + newRow.PartitionKey + ", RowKey:" + newRow.RowKey);
		}
	}

	private void AddToCoordinatesTable(CoordinatesGeoLocationEntity newRow)
	{
		try
		{
			coordinatesTableClient.AddEntity(newRow);
		}
		catch (Exception)
		{
			throw new Exception("Can't add duplicate CoordinatesGeoLocation row : PartKey:" + newRow.PartitionKey + ", RowKey:" + newRow.RowKey);
		}
	}

	private void AddToIpAddressTable(IpAddressGeoLocationEntity newRow)
	{
		try
		{
			ipAddressTableClient.AddEntity(newRow);
		}
		catch (Exception)
		{
			throw new Exception("Can't add duplicate IpAddressGeoLocation row : PartKey:" + newRow.PartitionKey + ", RowKey:" + newRow.RowKey);
		}
	}

	private async Task<GeoLocationRawAPI> IpAddressToGeoLocation_VedAstro(string ipAddress)
	{
		Expression<Func<IpAddressGeoLocationEntity, bool>> filter = (IpAddressGeoLocationEntity call) => call.PartitionKey == ipAddress;
		return new GeoLocationRawAPI(ipAddressTableClient.Query(filter).FirstOrDefault() ?? IpAddressGeoLocationEntity.Empty, null);
	}

	private async Task<GeoLocationRawAPI> GeoLocationToTimezone_Vedastro(GeoLocation geoLocation, DateTimeOffset timeAtLocation)
	{
		DateTimeOffset roundedTime = new DateTimeOffset(timeAtLocation.Year, timeAtLocation.Month, timeAtLocation.Day, 0, 0, 0, timeAtLocation.Offset);
		Expression<Func<GeoLocationTimezoneEntity, bool>> filter = (GeoLocationTimezoneEntity call) => call.PartitionKey == geoLocation.GetPartitionKey() && call.RowKey == roundedTime.ToRowKey();
		return new GeoLocationRawAPI(timezoneTableClient.Query(filter).FirstOrDefault() ?? GeoLocationTimezoneEntity.Empty, null);
	}

	private async Task<GeoLocationRawAPI> AddressToGeoLocation_VedAstro(string userInputAddress)
	{
		Expression<Func<AddressGeoLocationEntity, bool>> filter = (AddressGeoLocationEntity call) => call.RowKey == userInputAddress;
		return new GeoLocationRawAPI(addressTableClient.Query(filter).FirstOrDefault() ?? AddressGeoLocationEntity.Empty, null);
	}

	private async Task<GeoLocationRawAPI> SearchAddressToGeoLocation_VedAstro(string userInputAddress)
	{
		Expression<Func<SearchAddressGeoLocationEntity, bool>> filter = (SearchAddressGeoLocationEntity call) => call.PartitionKey == userInputAddress;
		return new GeoLocationRawAPI(searchAddressTableClient.Query(filter).FirstOrDefault() ?? SearchAddressGeoLocationEntity.Empty, null);
	}

	private async Task<GeoLocationRawAPI> CoordinatesToGeoLocation_Vedastro(double longitude, double latitude)
	{
		return new GeoLocationRawAPI(coordinatesTableClient.Query((CoordinatesGeoLocationEntity call) => call.PartitionKey == ((double)latitude).ToString() && call.RowKey == ((double)longitude).ToString()).FirstOrDefault() ?? CoordinatesGeoLocationEntity.Empty, null);
	}

	private static async Task<GeoLocationRawAPI> IpAddressToGeoLocation_Google(string ipAddress)
	{
		throw new NotImplementedException();
	}

	private static async Task<GeoLocationRawAPI> GeoLocationToTimezone_Google(GeoLocation geoLocation, DateTimeOffset timeAtLocation)
	{
		WebResult<GeoLocationRawAPI> returnResult = new WebResult<GeoLocationRawAPI>();
		long value = timeAtLocation.ToUnixTimeSeconds();
		double value2 = geoLocation.Longitude();
		double value3 = geoLocation.Latitude();
		string googleAPIKey = Secrets.GoogleAPIKey;
		WebResult<XElement> webResult = await Tools.ReadFromServerXmlReply(string.Format($"https://maps.googleapis.com/maps/api/timezone/xml?location={value3},{value2}&timestamp={value}&key={googleAPIKey}"));
		if (webResult.IsPass)
		{
			dynamic val = TryParseGoogleTimeZoneResponse(timeAtLocation, geoLocation, webResult.Payload);
			if ((bool)val.IsParsed)
			{
				returnResult.Payload = new GeoLocationRawAPI(val.MainRow, val.MetadataRow);
				returnResult.IsPass = true;
			}
			else
			{
				returnResult.IsPass = false;
				returnResult.Payload = new GeoLocationRawAPI(GeoLocationTimezoneEntity.Empty, GeoLocationTimezoneMetadataEntity.Empty);
			}
		}
		else
		{
			returnResult.IsPass = false;
			returnResult.Payload = new GeoLocationRawAPI(GeoLocationTimezoneEntity.Empty, GeoLocationTimezoneMetadataEntity.Empty);
		}
		return returnResult;
	}

	private static async Task<GeoLocationRawAPI> CoordinatesToGeoLocation_Google(double longitude, double latitude)
	{
		string googleAPIKey = Secrets.GoogleAPIKey;
		WebResult<JToken> webResult = await Tools.ReadFromServerJsonReply($"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={googleAPIKey}");
		WebResult<GeoLocationRawAPI> webResult2 = new WebResult<GeoLocationRawAPI>();
		if (webResult.IsPass)
		{
			dynamic val = TryParseGoogleCoordinatesResponse(webResult.Payload, longitude, latitude);
			if ((bool)val.IsParsed)
			{
				webResult2.Payload = new GeoLocationRawAPI(val.MainRow, null);
				webResult2.IsPass = true;
			}
			else
			{
				webResult2.IsPass = false;
				webResult2.Payload = new GeoLocationRawAPI(CoordinatesGeoLocationEntity.Empty, null);
			}
		}
		else
		{
			webResult2.IsPass = false;
			webResult2.Payload = new GeoLocationRawAPI(CoordinatesGeoLocationEntity.Empty, null);
		}
		return webResult2;
	}

	private static async Task<GeoLocationRawAPI> AddressToGeoLocation_Google(string userInputAddress)
	{
		WebResult<GeoLocationRawAPI> returnResult = new WebResult<GeoLocationRawAPI>();
		string googleAPIKey = Secrets.GoogleAPIKey;
		WebResult<JToken> webResult = await Tools.ReadFromServerJsonReply($"https://maps.googleapis.com/maps/api/geocode/json?key={googleAPIKey}&address={Uri.EscapeDataString(userInputAddress)}&sensor=false");
		if (webResult.IsPass)
		{
			dynamic val = TryParseGoogleAddressResponse(webResult.Payload, userInputAddress);
			if ((bool)val.IsParsed)
			{
				returnResult.Payload = new GeoLocationRawAPI(val.MainRow, null);
				returnResult.IsPass = true;
			}
			else
			{
				returnResult.IsPass = false;
				returnResult.Payload = new GeoLocationRawAPI(AddressGeoLocationEntity.Empty, null);
			}
		}
		else
		{
			returnResult.IsPass = false;
			returnResult.Payload = new GeoLocationRawAPI(GeoLocationTimezoneEntity.Empty, GeoLocationTimezoneMetadataEntity.Empty);
		}
		return returnResult;
	}

	private static async Task<GeoLocationRawAPI> IpAddressToGeoLocation_Azure(string ipAddress)
	{
		throw new NotImplementedException();
	}

	public static async Task<GeoLocationRawAPI> SearchAddressToGeoLocation_Azure(string userInputAddress)
	{
		WebResult<GeoLocationRawAPI> returnResult = new WebResult<GeoLocationRawAPI>();
		string azureMapsAPIKey = Secrets.AzureMapsAPIKey;
		WebResult<JToken> webResult = await Tools.ReadFromServerJsonReply("https://atlas.microsoft.com/search/address/json?api-version=1.0&subscription-key=" + azureMapsAPIKey + "&query=" + Uri.EscapeDataString(userInputAddress));
		if (webResult.IsPass)
		{
			dynamic val = TryParseAzureSearchAddressResponse(webResult.Payload, userInputAddress);
			if ((bool)val.IsParsed)
			{
				returnResult.Payload = new GeoLocationRawAPI(val.MainRow, null);
				returnResult.IsPass = true;
			}
			else
			{
				returnResult.IsPass = false;
				returnResult.Payload = new GeoLocationRawAPI(SearchAddressGeoLocationEntity.Empty, null);
			}
		}
		else
		{
			returnResult.IsPass = false;
			returnResult.Payload = new GeoLocationRawAPI(SearchAddressGeoLocationEntity.Empty, null);
		}
		return returnResult;
	}

	public static async Task<GeoLocationRawAPI> AddressToGeoLocation_Azure(string userInputAddress)
	{
		WebResult<GeoLocationRawAPI> returnResult = new WebResult<GeoLocationRawAPI>();
		string azureMapsAPIKey = Secrets.AzureMapsAPIKey;
		WebResult<JToken> webResult = await Tools.ReadFromServerJsonReply("https://atlas.microsoft.com/search/address/json?api-version=1.0&subscription-key=" + azureMapsAPIKey + "&query=" + Uri.EscapeDataString(userInputAddress));
		if (webResult.IsPass)
		{
			dynamic val = TryParseAzureAddressResponse(webResult.Payload, userInputAddress);
			if ((bool)val.IsParsed)
			{
				returnResult.Payload = new GeoLocationRawAPI(val.MainRow, null);
				returnResult.IsPass = true;
			}
			else
			{
				returnResult.IsPass = false;
				returnResult.Payload = new GeoLocationRawAPI(AddressGeoLocationEntity.Empty, null);
			}
		}
		else
		{
			returnResult.IsPass = false;
			returnResult.Payload = new GeoLocationRawAPI(GeoLocationTimezoneEntity.Empty, GeoLocationTimezoneMetadataEntity.Empty);
		}
		return returnResult;
	}

	private static async Task<GeoLocationRawAPI> GeoLocationToTimezone_Azure(GeoLocation geoLocation, DateTimeOffset timeAtLocation)
	{
		WebResult<GeoLocationRawAPI> returnResult = new WebResult<GeoLocationRawAPI>();
		string stringToEscape = timeAtLocation.ToString("O", CultureInfo.InvariantCulture);
		string azureMapsAPIKey = Secrets.AzureMapsAPIKey;
		WebResult<JToken> webResult = await Tools.ReadFromServerJsonReply($"https://atlas.microsoft.com/timezone/byCoordinates/json?api-version=1.0&subscription-key={azureMapsAPIKey}&query={geoLocation.Latitude()},{geoLocation.Longitude()}&timestamp={Uri.EscapeDataString(stringToEscape)}");
		if (webResult.IsPass)
		{
			dynamic val = TryParseAzureTimeZoneResponse(timeAtLocation, geoLocation, webResult.Payload);
			if ((bool)val.IsParsed)
			{
				returnResult.Payload = new GeoLocationRawAPI(val.MainRow, val.MetadataRow);
				returnResult.IsPass = true;
			}
			else
			{
				returnResult.IsPass = false;
				returnResult.Payload = new GeoLocationRawAPI(GeoLocationTimezoneEntity.Empty, GeoLocationTimezoneMetadataEntity.Empty);
			}
		}
		else
		{
			returnResult.IsPass = false;
			returnResult.Payload = new GeoLocationRawAPI(GeoLocationTimezoneEntity.Empty, GeoLocationTimezoneMetadataEntity.Empty);
		}
		return returnResult;
	}

	private static dynamic TryParseGoogleTimeZoneResponse(DateTimeOffset timeAtLocation, GeoLocation geoLocation, XElement apiResultPayload)
	{
		try
		{
			dynamic val = getOffsetMinFromGoogleXml();
			GeoLocationTimezoneEntity geoLocationTimezoneEntity = new GeoLocationTimezoneEntity();
			geoLocationTimezoneEntity.PartitionKey = geoLocation.GetPartitionKey();
			DateTimeOffset dateTimeOffset = new DateTimeOffset(timeAtLocation.Year, timeAtLocation.Month, timeAtLocation.Day, 0, 0, 0, timeAtLocation.Offset);
			dynamic val2 = Tools.TimeSpanToUTCTimezoneString(val.StandardOffset);
			geoLocationTimezoneEntity.TimezoneText = val2;
			geoLocationTimezoneEntity.RowKey = dateTimeOffset.ToRowKey();
			GeoLocationTimezoneMetadataEntity geoLocationTimezoneMetadataEntity = new GeoLocationTimezoneMetadataEntity();
			geoLocationTimezoneMetadataEntity.StandardOffset = Tools.TimeSpanToUTCTimezoneString(val.StandardOffset);
			geoLocationTimezoneMetadataEntity.DaylightSavings = Tools.TimeSpanToUTCTimezoneString(val.DaylightSavings);
			geoLocationTimezoneMetadataEntity.Tag = "";
			geoLocationTimezoneMetadataEntity.Standard_Name = val.StandardName;
			geoLocationTimezoneMetadataEntity.Daylight_Name = val.DaylightName;
			geoLocationTimezoneMetadataEntity.ISO_Name = val.ISOName;
			geoLocationTimezoneMetadataEntity.RowKey = "0";
			geoLocationTimezoneMetadataEntity.PartitionKey = geoLocationTimezoneMetadataEntity.CalculateCombinedHash();
			geoLocationTimezoneEntity.MetadataHash = geoLocationTimezoneMetadataEntity.PartitionKey;
			return new
			{
				IsParsed = true,
				MainRow = geoLocationTimezoneEntity,
				MetadataRow = geoLocationTimezoneMetadataEntity
			};
		}
		catch
		{
			return new
			{
				IsParsed = false,
				MainRow = GeoLocationTimezoneEntity.Empty,
				MetadataRow = GeoLocationTimezoneMetadataEntity.Empty
			};
		}
		dynamic getOffsetMinFromGoogleXml()
		{
			TimeSpan standardOffset = default(TimeSpan);
			TimeSpan daylightSavings = default(TimeSpan);
			bool num = (apiResultPayload?.Element("status")?.Value ?? "").Contains("INVALID_REQUEST");
			string text = "";
			string iSOName = "";
			if (!num)
			{
				string text2 = apiResultPayload?.Element("raw_offset")?.Value;
				string s = apiResultPayload?.Element("dst_offset")?.Value;
				iSOName = apiResultPayload?.Element("time_zone_id")?.Value;
				text = apiResultPayload?.Element("time_zone_name")?.Value;
				double result = 0.0;
				double result2 = 0.0;
				if (!string.IsNullOrEmpty(text2))
				{
					double.TryParse(text2, out result);
					double.TryParse(s, out result2);
				}
				standardOffset = TimeSpan.FromMinutes((int)Math.Round(TimeSpan.FromSeconds(result).TotalMinutes));
				daylightSavings = TimeSpan.FromMinutes((int)Math.Round(TimeSpan.FromSeconds(result2).TotalMinutes));
			}
			return new
			{
				StandardOffset = standardOffset,
				DaylightSavings = daylightSavings,
				StandardName = text,
				DaylightName = text,
				ISOName = iSOName
			};
		}
	}

	private static dynamic TryParseAzureTimeZoneResponse(DateTimeOffset timeAtLocation, GeoLocation geoLocation, JToken timeZoneResponseJson)
	{
		try
		{
			if (!(timeZoneResponseJson["TimeZones"] is JArray { HasValues: not false } jArray))
			{
				throw new ArgumentException("Invalid or missing 'TimeZones' property in Azure timezone response.");
			}
			if (!(jArray[0] is JObject jObject))
			{
				throw new ArgumentException("Invalid or missing timezone object in Azure timezone response.");
			}
			if (!(jObject["ReferenceTime"] is JObject jObject2))
			{
				throw new ArgumentException("Invalid or missing 'ReferenceTime' object in Azure timezone response.");
			}
			TimeSpan timeSpan = TimeSpan.Parse(jObject2["StandardOffset"].Value<string>());
			TimeSpan timeSpan2 = TimeSpan.Parse(jObject2["DaylightSavings"].Value<string>());
			string timezoneText = Tools.TimeSpanToUTCTimezoneString(timeSpan + timeSpan2);
			GeoLocationTimezoneEntity geoLocationTimezoneEntity = new GeoLocationTimezoneEntity();
			geoLocationTimezoneEntity.PartitionKey = geoLocation.GetPartitionKey();
			DateTimeOffset dateTimeOffset = new DateTimeOffset(timeAtLocation.Year, timeAtLocation.Month, timeAtLocation.Day, 0, 0, 0, timeAtLocation.Offset);
			geoLocationTimezoneEntity.TimezoneText = timezoneText;
			geoLocationTimezoneEntity.RowKey = dateTimeOffset.ToRowKey();
			GeoLocationTimezoneMetadataEntity geoLocationTimezoneMetadataEntity = new GeoLocationTimezoneMetadataEntity();
			geoLocationTimezoneMetadataEntity.StandardOffset = Tools.TimeSpanToUTCTimezoneString(timeSpan);
			geoLocationTimezoneMetadataEntity.DaylightSavings = Tools.TimeSpanToUTCTimezoneString(timeSpan2);
			geoLocationTimezoneMetadataEntity.Tag = (jObject2["Tag"] ?? ((JToken)"")).Value<string>() ?? string.Empty;
			geoLocationTimezoneMetadataEntity.Standard_Name = (jObject["Names"]?["Standard"] ?? ((JToken)"")).Value<string>() ?? string.Empty;
			geoLocationTimezoneMetadataEntity.Daylight_Name = (jObject["Names"]?["Daylight"] ?? ((JToken)"")).Value<string>() ?? string.Empty;
			geoLocationTimezoneMetadataEntity.ISO_Name = (jObject["Id"] ?? ((JToken)"")).Value<string>() ?? string.Empty;
			geoLocationTimezoneMetadataEntity.RowKey = "0";
			geoLocationTimezoneMetadataEntity.PartitionKey = geoLocationTimezoneMetadataEntity.CalculateCombinedHash();
			geoLocationTimezoneEntity.MetadataHash = geoLocationTimezoneMetadataEntity.PartitionKey;
			return new
			{
				IsParsed = true,
				MainRow = geoLocationTimezoneEntity,
				MetadataRow = geoLocationTimezoneMetadataEntity
			};
		}
		catch
		{
			return new
			{
				IsParsed = false,
				MainRow = GeoLocationTimezoneEntity.Empty,
				MetadataRow = GeoLocationTimezoneMetadataEntity.Empty
			};
		}
	}

	private static dynamic TryParseAzureAddressResponse(JToken geocodeResponseJson, string userInputAddress)
	{
		try
		{
			JToken jToken = geocodeResponseJson["results"][0];
			if (jToken == null || jToken["type"].Value<string>() != "Geography")
			{
				return null;
			}
			JToken? jToken2 = jToken["position"];
			double value = double.Parse(jToken2["lat"].Value<string>() ?? "0");
			double value2 = double.Parse(jToken2["lon"].Value<string>() ?? "0");
			value = Math.Round(value, 3);
			value2 = Math.Round(value2, 3);
			string? text = jToken["address"]["freeformAddress"].Value<string>();
			string text2 = jToken["address"]["country"].Value<string>();
			string partitionKey = text + ", " + text2;
			AddressGeoLocationEntity addressGeoLocationEntity = new AddressGeoLocationEntity();
			addressGeoLocationEntity.Latitude = value;
			addressGeoLocationEntity.Longitude = value2;
			addressGeoLocationEntity.PartitionKey = partitionKey;
			addressGeoLocationEntity.RowKey = Tools.CleanAzureTableKey(userInputAddress);
			return new
			{
				IsParsed = true,
				MainRow = addressGeoLocationEntity
			};
		}
		catch
		{
			return new
			{
				IsParsed = false,
				TimezoneRow = AddressGeoLocationEntity.Empty
			};
		}
	}

	private static dynamic TryParseAzureSearchAddressResponse(JToken geocodeResponseJson, string userInputAddress)
	{
		try
		{
			JToken? jToken = geocodeResponseJson["results"];
			List<GeoLocation> list = new List<GeoLocation>();
			foreach (JToken item2 in (IEnumerable<JToken>)jToken)
			{
				if (item2 == null || item2["type"].Value<string>() != "Geography")
				{
					return null;
				}
				JToken? jToken2 = item2["position"];
				double value = double.Parse(jToken2["lat"].Value<string>() ?? "0");
				double value2 = double.Parse(jToken2["lon"].Value<string>() ?? "0");
				value = Math.Round(value, 3);
				value2 = Math.Round(value2, 3);
				string? text = item2["address"]["freeformAddress"].Value<string>();
				string text2 = item2["address"]["country"].Value<string>();
				GeoLocation item = new GeoLocation(text + ", " + text2, value2, value);
				list.Add(item);
			}
			string results = Tools.ListToJson(list).ToString(Formatting.None);
			SearchAddressGeoLocationEntity mainRow = new SearchAddressGeoLocationEntity
			{
				PartitionKey = userInputAddress,
				RowKey = "",
				Results = results
			};
			return new
			{
				IsParsed = true,
				MainRow = mainRow
			};
		}
		catch
		{
			return new
			{
				IsParsed = false,
				MainRow = new List<GeoLocation>()
			};
		}
	}

	private static dynamic TryParseGoogleAddressResponse(JToken geocodeResponseJson, string userInputAddress)
	{
		try
		{
			JToken? jToken = geocodeResponseJson["results"];
			geocodeResponseJson["status"].Value<string>();
			JToken? jToken2 = jToken[0];
			JToken? jToken3 = jToken2["geometry"]["location"];
			double value = jToken3["lat"].Value<double>();
			double value2 = jToken3["lng"].Value<double>();
			value = Math.Round(value, 3);
			value2 = Math.Round(value2, 3);
			string partitionKey = jToken2["formatted_address"].Value<string>();
			AddressGeoLocationEntity addressGeoLocationEntity = new AddressGeoLocationEntity();
			addressGeoLocationEntity.Latitude = value;
			addressGeoLocationEntity.Longitude = value2;
			addressGeoLocationEntity.PartitionKey = partitionKey;
			addressGeoLocationEntity.RowKey = Tools.CleanAzureTableKey(userInputAddress);
			return new
			{
				IsParsed = true,
				MainRow = addressGeoLocationEntity
			};
		}
		catch
		{
			return new
			{
				IsParsed = false,
				TimezoneRow = AddressGeoLocationEntity.Empty
			};
		}
	}

	private static dynamic TryParseGoogleCoordinatesResponse(JToken geocodeResponseJson, double longitude, double latitude)
	{
		try
		{
			string[] array = geocodeResponseJson["results"][0]["formatted_address"].Value<string>().Split(',');
			string text = $"{array[^3]},{array[^2]},{array[^1]}";
			CoordinatesGeoLocationEntity coordinatesGeoLocationEntity = new CoordinatesGeoLocationEntity();
			coordinatesGeoLocationEntity.PartitionKey = latitude.ToString();
			coordinatesGeoLocationEntity.RowKey = longitude.ToString();
			coordinatesGeoLocationEntity.Name = text.Trim();
			return new
			{
				IsParsed = true,
				MainRow = coordinatesGeoLocationEntity
			};
		}
		catch
		{
			return new
			{
				IsParsed = false,
				MainRow = CoordinatesGeoLocationEntity.Empty
			};
		}
	}

	private static async Task<GeoLocationRawAPI> IpAddressToGeoLocation_IpData(string ipAddress)
	{
		string ipDataAPIKey = Secrets.IpDataAPIKey;
		WebResult<JToken> webResult = await Tools.ReadFromServerJsonReply($"{"https://api.ipdata.co"}/{ipAddress}?api-key={ipDataAPIKey}");
		WebResult<GeoLocationRawAPI> webResult2 = new WebResult<GeoLocationRawAPI>();
		if (webResult.IsPass)
		{
			dynamic val = TryParseIpDataCoordinatesResponse(webResult.Payload, ipAddress);
			if ((bool)val.IsParsed)
			{
				webResult2.Payload = new GeoLocationRawAPI(val.MainRow, val.MetadataRow);
				webResult2.IsPass = true;
			}
			else
			{
				webResult2.IsPass = false;
				webResult2.Payload = new GeoLocationRawAPI(IpAddressGeoLocationEntity.Empty, IpAddressGeoLocationMetadataEntity.Empty);
			}
		}
		else
		{
			webResult2.IsPass = false;
			webResult2.Payload = new GeoLocationRawAPI(IpAddressGeoLocationEntity.Empty, IpAddressGeoLocationMetadataEntity.Empty);
		}
		return webResult2;
	}

	private static dynamic TryParseIpDataCoordinatesResponse(JToken geocodeResponseJson, string ipAddress)
	{
		try
		{
			double value = double.Parse(geocodeResponseJson?["latitude"]?.Value<string>() ?? "0");
			double value2 = double.Parse(geocodeResponseJson?["longitude"]?.Value<string>() ?? "0");
			value = Math.Round(value, 3);
			value2 = Math.Round(value2, 3);
			string? text = geocodeResponseJson["region"].Value<string>();
			string text2 = geocodeResponseJson["country_name"].Value<string>();
			string text3 = text + ", " + text2;
			string asnName = geocodeResponseJson["asn"]["name"].Value<string>();
			string timezoneName = geocodeResponseJson["time_zone"]["name"].Value<string>();
			string timezoneOffset = geocodeResponseJson["time_zone"]["offset"].Value<string>();
			string isProxy = geocodeResponseJson["threat"]["is_proxy"].Value<string>();
			string isDatacenter = geocodeResponseJson["threat"]["is_datacenter"].Value<string>();
			string isAnonymous = geocodeResponseJson["threat"]["is_anonymous"].Value<string>();
			string isKnownAttacker = geocodeResponseJson["threat"]["is_known_attacker"].Value<string>();
			string isKnownAbuser = geocodeResponseJson["threat"]["is_known_abuser"].Value<string>();
			string isThreat = geocodeResponseJson["threat"]["is_threat"].Value<string>();
			string isBogon = geocodeResponseJson["threat"]["is_bogon"].Value<string>();
			IpAddressGeoLocationEntity ipAddressGeoLocationEntity = new IpAddressGeoLocationEntity();
			ipAddressGeoLocationEntity.PartitionKey = ipAddress;
			ipAddressGeoLocationEntity.RowKey = "";
			ipAddressGeoLocationEntity.Latitude = value;
			ipAddressGeoLocationEntity.Longitude = value2;
			ipAddressGeoLocationEntity.LocationName = text3.Trim();
			IpAddressGeoLocationMetadataEntity ipAddressGeoLocationMetadataEntity = new IpAddressGeoLocationMetadataEntity();
			ipAddressGeoLocationMetadataEntity.AsnName = asnName;
			ipAddressGeoLocationMetadataEntity.TimezoneName = timezoneName;
			ipAddressGeoLocationMetadataEntity.TimezoneOffset = timezoneOffset;
			ipAddressGeoLocationMetadataEntity.IsProxy = isProxy;
			ipAddressGeoLocationMetadataEntity.IsDatacenter = isDatacenter;
			ipAddressGeoLocationMetadataEntity.IsAnonymous = isAnonymous;
			ipAddressGeoLocationMetadataEntity.IsKnownAttacker = isKnownAttacker;
			ipAddressGeoLocationMetadataEntity.IsKnownAbuser = isKnownAbuser;
			ipAddressGeoLocationMetadataEntity.IsThreat = isThreat;
			ipAddressGeoLocationMetadataEntity.IsBogon = isBogon;
			ipAddressGeoLocationMetadataEntity.RowKey = "0";
			ipAddressGeoLocationMetadataEntity.PartitionKey = ipAddressGeoLocationMetadataEntity.CalculateCombinedHash();
			ipAddressGeoLocationEntity.MetadataHash = ipAddressGeoLocationMetadataEntity.PartitionKey;
			return new
			{
				IsParsed = true,
				MainRow = ipAddressGeoLocationEntity,
				MetadataRow = ipAddressGeoLocationMetadataEntity
			};
		}
		catch
		{
			return new
			{
				IsParsed = false,
				MainRow = IpAddressGeoLocationEntity.Empty,
				MetadataRow = IpAddressGeoLocationMetadataEntity.Empty
			};
		}
	}
}
