using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public struct Person : IToXml, IFromUrl, IToJson
{
	public static int OpenAPILength = 2;

	private static string DefaultUserId = "101";

	public static Person Empty = new Person(DefaultUserId, "0", "Empty", Time.Empty, Gender.Empty, "Empty");

	private string _notes;

	public string Id { get; set; }

	public string Name { get; set; }

	public string OwnerId { get; set; }

	public string Notes
	{
		get
		{
			return HttpUtility.HtmlDecode(_notes);
		}
		set
		{
			_notes = HttpUtility.HtmlEncode(value);
		}
	}

	public Gender Gender { get; set; }

	public Time BirthTime { get; set; }

	public List<LifeEvent> LifeEventList { get; set; }

	public int BirthYear => BirthTime.GetStdDateTimeOffset().Year;

	public string BirthTimeZone => BirthTime.GetStdDateTimeOffset().ToString("zzz");

	public string BirthHourMinute => BirthTime.GetStdDateTimeOffset().ToString("HH:mm");

	public string BirthDateMonthYear => BirthTime.GetStdDateTimeOffset().ToString("dd/MM/yyyy");

	public string GenderString => Gender.ToString();

	public int Hash => GetHashCode();

	public string BirthTimeString => BirthTime.GetStdDateTimeOffsetText();

	public DateTimeOffset StdTimeNowAtBirthLocation => DateTimeOffset.Now.ToOffset(BirthTime.GetStdDateTimeOffset().Offset);

	public Time TimeNowAtBirthLocation => new Time(DateTimeOffset.UtcNow.ToOffset(BirthTime.GetStdDateTimeOffset().Offset), GetBirthLocation());

	public string ImageName => Id + ".jpg";

	public string DisplayName => $"{Name} - {BirthYear}";

	public string NameWithNoSpace => Name.Replace(" ", "") ?? "";

	public JArray LifeEventListJson
	{
		get
		{
			JArray jArray = new JArray();
			foreach (LifeEvent lifeEvent in LifeEventList)
			{
				jArray.Add(lifeEvent.ToJson());
			}
			return jArray;
		}
	}

	public string BirthDateMonthYearOffset => BirthDateMonthYear + " " + BirthTimeZone;

	public Person(string ownerId, string id, string name, Time birthTime, Gender gender, string notes = "", List<LifeEvent> lifeEventList = null)
	{
		_notes = null;
		LifeEventList = new List<LifeEvent>();
		Id = id;
		Name = name;
		BirthTime = birthTime;
		Gender = gender;
		OwnerId = ownerId;
		Notes = notes;
		LifeEventList = lifeEventList ?? new List<LifeEvent>();
	}

	public Person(string name, Time birthTime, Gender gender)
	{
		_notes = null;
		LifeEventList = new List<LifeEvent>();
		Id = Tools.GenerateId();
		Name = name;
		BirthTime = birthTime;
		Gender = gender;
		OwnerId = DefaultUserId;
		Notes = "";
		LifeEventList = new List<LifeEvent>();
	}

	public GeoLocation GetBirthLocation()
	{
		return BirthTime.GetGeoLocation();
	}

	public int GetAge(Time time)
	{
		return time.GetStdDateTimeOffset().Year - BirthYear;
	}

	public int GetAge(int year)
	{
		return year - BirthYear;
	}

	public int GetAge()
	{
		return GetAge(Time.NowSystem(GetBirthLocation()));
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(Person))
		{
			Person person = (Person)value;
			return GetHashCode() == person.GetHashCode();
		}
		return false;
	}

	public override string ToString()
	{
		return Name ?? "";
	}

	public override int GetHashCode()
	{
		int stringHashCode = Tools.GetStringHashCode(Name);
		int hashCode = BirthTime.GetHashCode();
		int stringHashCode2 = Tools.GetStringHashCode(OwnerId);
		return Math.Abs(stringHashCode + hashCode + stringHashCode2);
	}

	public static JArray XmlListToJsonList(List<XElement> personXmlList)
	{
		List<Person> list = FromXml(personXmlList);
		JArray jArray = new JArray();
		foreach (Person item in list)
		{
			jArray.Add(item.ToJson());
		}
		return jArray;
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("Person");
		XElement xElement2 = new XElement("Name", Name);
		XElement xElement3 = new XElement("PersonId", Id);
		XElement xElement4 = new XElement("Notes", Notes);
		XElement xElement5 = new XElement("Gender", Gender.ToString());
		XElement xElement6 = new XElement("BirthTime", BirthTime.ToXml());
		XElement xElement7 = new XElement("OwnerId", OwnerId);
		XElement xElement8 = getLifeEventListXml(LifeEventList);
		xElement.Add(xElement3, xElement2, xElement5, xElement6, xElement7, xElement8, xElement4);
		return xElement;
		static XElement getLifeEventListXml(List<LifeEvent> lifeList)
		{
			XElement xElement9 = new XElement("LifeEventList");
			if (lifeList == null)
			{
				return xElement9;
			}
			foreach (LifeEvent life in lifeList)
			{
				XElement content = life.ToXml();
				xElement9.Add(content);
			}
			return xElement9;
		}
	}

	public dynamic FromXml<T>(XElement xml) where T : IToXml
	{
		return FromXml(xml);
	}

	public static Person FromXml(XElement? personXml)
	{
		if (personXml == null)
		{
			return Empty;
		}
		string id = personXml.Element("PersonId")?.Value ?? "0";
		string name = personXml.Element("Name")?.Value;
		string notes = personXml.Element("Notes")?.Value;
		Time birthTime = Time.FromXml(personXml.Element("BirthTime")?.Element("Time"));
		Gender gender = Enum.Parse<Gender>(personXml.Element("Gender")?.Value);
		string ownerId = personXml.Element("OwnerId")?.Value;
		return new Person(ownerId, id, name, birthTime, gender, notes);
	}

	public static List<Person> FromXml(IEnumerable<XElement> personXmlList)
	{
		return personXmlList.Select((XElement personXml) => FromXml(personXml)).ToList();
	}

	public static async Task<dynamic> FromUrl(string url)
	{
		return Tools.GetPersonById(url.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1]);
	}

	public Person ChangeBirthTime(Time newBirthTime)
	{
		return new Person(OwnerId, Id, Name, newBirthTime, Gender, Notes, LifeEventList);
	}

	public PersonListEntity ToAzureRow()
	{
		return new PersonListEntity
		{
			PartitionKey = OwnerId,
			RowKey = Id,
			Name = Name,
			BirthTime = BirthTime.ToJson().ToString(),
			Gender = Gender.ToString(),
			Notes = Notes
		};
	}

	public static Person FromAzureRow(PersonListEntity rowData)
	{
		Time birthTime = Time.FromJson(JToken.Parse(rowData.BirthTime));
		Gender gender = Enum.Parse<Gender>(rowData.Gender);
		string personId = rowData.RowKey;
		Person result = new Person(rowData.PartitionKey, personId, rowData.Name, birthTime, gender);
		List<LifeEvent> lifeEventList = (from call in AzureTable.LifeEventList_Indic.Query((LifeEventRow call) => call.PartitionKey == personId)
			select LifeEvent.FromAzureRow(call)).ToList();
		result.LifeEventList = lifeEventList;
		return result;
	}

	JObject IToJson.ToJson()
	{
		return (JObject)ToJson();
	}

	public JToken ToJson()
	{
		return new JObject
		{
			["PersonId"] = Id,
			["Name"] = Name,
			["Notes"] = Notes,
			["BirthTime"] = BirthTime.ToJson(),
			["Gender"] = GenderString,
			["OwnerId"] = OwnerId,
			["LifeEventList"] = LifeEventListJson
		};
	}

	public static List<Person> FromJsonList(JToken personList)
	{
		if (personList == null)
		{
			return new List<Person>();
		}
		List<Person> list = new List<Person>();
		foreach (JToken item in (IEnumerable<JToken>)personList)
		{
			list.Add(FromJson(item));
		}
		return list;
	}

	public static Person FromJson(JToken personInput)
	{
		if (personInput == null)
		{
			return Empty;
		}
		try
		{
			string id = personInput["PersonId"].Value<string>();
			string name = personInput["Name"].Value<string>();
			string notes = personInput["Notes"].Value<string>();
			Time birthTime = Time.FromJson(personInput["BirthTime"]);
			Gender gender = Enum.Parse<Gender>(personInput["Gender"].Value<string>());
			string ownerId = personInput["OwnerId"].Value<string>();
			List<LifeEvent> lifeEventList = LifeEvent.FromJsonList(personInput["LifeEventList"]);
			return new Person(ownerId, id, name, birthTime, gender, notes, lifeEventList);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			LibLogger.Debug("Failed to parse Person:\n" + personInput.ToString());
			return Empty;
		}
	}

	public static JArray ListToJson(List<Person> personList)
	{
		JArray jArray = new JArray();
		foreach (Person person in personList)
		{
			jArray.Add(person.ToJson());
		}
		return jArray;
	}
}
