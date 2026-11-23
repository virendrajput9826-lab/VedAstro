using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

[Serializable]
public class GeoLocation : IToXml, IToJpeg, IToJson, IToDataTable, IFromUrl
{
	public static int OpenAPILength = 4;

	public static GeoLocation Empty = new GeoLocation("Empty", 101.0, 4.59);

	public static GeoLocation Tokyo = new GeoLocation("Tokyo, Japan", 139.83, 35.65);

	public static GeoLocation Bangkok = new GeoLocation("Bangkok, Thailand", 100.5, 13.75);

	public static GeoLocation Bangalore = new GeoLocation("Bangalore, India", 77.5946, 12.9716);

	public static GeoLocation Ipoh = new GeoLocation("Ipoh, Malaysia", 101.0758, 4.6005);

	public static GeoLocation LosAngeles = new GeoLocation("Los Angeles, CA, USA", -118.243, 34.055);

	public static GeoLocation Ahmedabad = new GeoLocation("Ahmedabad, India", 72.5714, 23.0225);

	public static GeoLocation Ujjain = new GeoLocation("Ujjain, India", 75.7167, 23.1667);

	public static GeoLocation WashingtonDC = new GeoLocation("Washington D.C., USA", -77.0369, 38.9072);

	public static GeoLocation London = new GeoLocation("London, UK", -0.1276, 51.5074);

	public static GeoLocation Paris = new GeoLocation("Paris, France", 2.3522, 48.8566);

	public static GeoLocation Berlin = new GeoLocation("Berlin, Germany", 13.405, 52.52);

	public static GeoLocation Canberra = new GeoLocation("Canberra, Australia", 149.13, -35.2809);

	public static GeoLocation Ottawa = new GeoLocation("Ottawa, Canada", -75.6972, 45.4215);

	public static GeoLocation Brasilia = new GeoLocation("Brasilia, Brazil", -47.8825, -15.7942);

	public static GeoLocation Moscow = new GeoLocation("Moscow, Russia", 37.6176, 55.7558);

	public static GeoLocation Beijing = new GeoLocation("Beijing, China", 116.4074, 39.9042);

	public static GeoLocation Mumbai = new GeoLocation("Mumbai, India", 72.8775, 19.0761);

	public static GeoLocation Singapore = new GeoLocation("Singapore, Singapore", 103.8198, 1.3521);

	public static GeoLocation Chicago = new GeoLocation("Chicago, USA", -87.6298, 47.8781);

	public static GeoLocation TestLocB = new GeoLocation("TestLocB, TestLocationB", 80.25, 13.0667);

	private readonly string _name;

	private readonly double _longitude;

	private readonly double _latitude;

	public GeoLocation(string name, double longitude, double latitude)
	{
		_name = name;
		if (IsValidLatitudeLongitude(longitude, latitude))
		{
			_longitude = longitude;
			_latitude = latitude;
		}
		else
		{
			_longitude = CorrectDecimalPoint(longitude);
			_latitude = CorrectDecimalPoint(latitude);
		}
	}

	public string Name()
	{
		return _name;
	}

	public double Longitude()
	{
		return _longitude;
	}

	public double Latitude()
	{
		return _latitude;
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(GeoLocation))
		{
			GeoLocation geoLocation = (GeoLocation)value;
			return GetHashCode() == geoLocation.GetHashCode();
		}
		return false;
	}

	public override string ToString()
	{
		return $"{_name} {_longitude} {_latitude}";
	}

	public static async Task<dynamic> FromUrl(string url)
	{
		string[] array = url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		string name = array[1];
		string[] array2 = array[3].Split(',');
		double latitude = double.Parse(array2[0]);
		double longitude = double.Parse(array2[1]);
		return new GeoLocation(name, longitude, latitude);
	}

	public string ToUrl()
	{
		return $"/Location/{Name()}/Coordinates/{Latitude()},{Longitude()}";
	}

	public override int GetHashCode()
	{
		int stringHashCode = Tools.GetStringHashCode(_name);
		int hashCode = _longitude.GetHashCode();
		int hashCode2 = _latitude.GetHashCode();
		return stringHashCode + hashCode + hashCode2;
	}

	public byte[] ToJpeg()
	{
		return Tools.DataTableToJpeg(ToDataTable());
	}

	public DataTable ToDataTable()
	{
		DataTable dataTable = new DataTable("GeoLocation");
		dataTable.Columns.Add("Name", typeof(string));
		dataTable.Columns.Add("Value", typeof(string));
		dataTable.Rows.Add("Name", Name());
		dataTable.Rows.Add("Longitude", Longitude());
		dataTable.Rows.Add("Latitude", Latitude());
		return dataTable;
	}

	public JToken ToJson()
	{
		return new JObject
		{
			["Name"] = Name(),
			["Longitude"] = Longitude(),
			["Latitude"] = Latitude()
		};
	}

	JObject IToJson.ToJson()
	{
		return (JObject)ToJson();
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("Location");
		XElement xElement2 = new XElement("Name", Name());
		XElement xElement3 = new XElement("Longitude", Longitude());
		XElement xElement4 = new XElement("Latitude", Latitude());
		xElement.Add(xElement2, xElement3, xElement4);
		return xElement;
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	public static GeoLocation FromXml(XElement locationXml)
	{
		try
		{
			string name = locationXml.Element("Name")?.Value;
			double longitude = double.Parse(locationXml.Element("Longitude")?.Value ?? "-1");
			double latitude = double.Parse(locationXml.Element("Latitude")?.Value ?? "-1");
			return new GeoLocation(name, longitude, latitude);
		}
		catch (Exception message)
		{
			LibLogger.Debug(message, $"GeoLocation.FromXml FAIL! : {locationXml}");
			return Empty;
		}
	}

	public static GeoLocation FromJson(JToken rawJson)
	{
		try
		{
			string? name = rawJson["Name"].Value<string>();
			double longitude = rawJson["Longitude"].Value<double>();
			double latitude = rawJson["Latitude"].Value<double>();
			return new GeoLocation(name, longitude, latitude);
		}
		catch (Exception)
		{
			try
			{
				JToken obj = ((JObject)rawJson).Properties().FirstOrDefault()?.Value;
				string name2 = obj["Name"].Value<string>();
				double longitude2 = obj["Longitude"].Value<double>();
				double latitude2 = obj["Latitude"].Value<double>();
				return new GeoLocation(name2, longitude2, latitude2);
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				return Empty;
			}
		}
	}

	public static async Task<GeoLocation> FromName(string locationName)
	{
		WebResult<GeoLocation> webResult = await Tools.AddressToGeoLocation(locationName);
		if (!webResult.IsPass)
		{
			return Empty;
		}
		return webResult.Payload;
	}

	public static async Task<GeoLocation> FromIpAddress()
	{
		try
		{
			return await SystemIpAddressToGeoLocation();
		}
		catch (Exception message)
		{
			LibLogger.Debug(message, "Client Location: FAILED!!!");
			return Empty;
		}
	}

	public static async Task<GeoLocation> CoordinatesToGeoLocation(double latitude, double longitude)
	{
		double value = Math.Round(latitude, 3);
		double value2 = Math.Round(longitude, 3);
		return FromJson((await Tools.ReadFromServerJsonReplyVedAstro(new URL("stable".Contains("beta")).CoordinatesToGeoLocationAPI + $"/Latitude/{value}/Longitude/{value2}")).Payload);
	}

	public static async Task<GeoLocation> SystemIpAddressToGeoLocation()
	{
		URL allUrls = new URL("stable".Contains("beta"));
		string text = await Tools.GetIPAddress();
		return FromJson((await Tools.ReadFromServerJsonReplyVedAstro(allUrls.IpAddressToGeoLocationAPI + "/IpAddress/" + text)).Payload);
	}

	public bool IsValidLatitudeLongitude(double longitude, double latitude)
	{
		if (latitude < -90.0 || latitude > 90.0)
		{
			Console.WriteLine($"Invalid Latitude! {latitude}");
			return false;
		}
		if (longitude < -180.0 || longitude > 180.0)
		{
			Console.WriteLine($"Invalid Longitude! {longitude}");
			return false;
		}
		return true;
	}

	public double CorrectDecimalPoint(double input)
	{
		string text = input.ToString();
		bool num = text.StartsWith("-");
		if (num)
		{
			text = text.Substring(1);
		}
		int startIndex = ((text.Length > 7) ? (text.Length - 7) : 0);
		text = text.Insert(startIndex, ".");
		double num2 = double.Parse(text);
		if (num)
		{
			num2 = 0.0 - num2;
		}
		return num2;
	}

	public static async Task<(bool, GeoLocation)> TryParse(string cellValue)
	{
		return await CacheManager.GetCache(new CacheKey("GeoLocation_TryParse", cellValue), _tryParse);
		async Task<(bool, GeoLocation)> _tryParse()
		{
			try
			{
				GeoLocation geoLocation = await FromName(cellValue);
				return (!geoLocation.Equals(Empty), geoLocation);
			}
			catch
			{
				return (false, Empty);
			}
		}
	}

	public static bool TryParseStd(string stdDateTimeText, out DateTimeOffset parsed)
	{
		try
		{
			parsed = DateTimeOffset.ParseExact(stdDateTimeText, "HH:mm dd/MM/yyyy zzz", null);
			return true;
		}
		catch (Exception)
		{
			parsed = default(DateTimeOffset);
			return false;
		}
	}

	public string GetPartitionKey()
	{
		string text = Math.Round(Longitude(), 1).ToString();
		return Math.Round(Latitude(), 1) + "," + text;
	}
}
