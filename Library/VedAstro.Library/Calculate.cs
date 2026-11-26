using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwissEphNet;

namespace VedAstro.Library;

public class Calculate
{
	public class Movie
	{
		public string Title { get; set; }

		public string Director { get; set; }
	}

	public class SearchResults
	{
		public Movie[] Value { get; set; }
	}

	public static string CurrentServerAddress;

	public static int Ayanamsa { get; set; } = 1;

	public static double SolarYearTimeSpan { get; set; } = 365.35;

	public static ZodiacSign PlanetRasiD1Sign(PlanetName planetName, Time time) => PlanetZodiacSign(planetName, time);
	public static ZodiacName PlanetHoraD2Signs(PlanetName planetName, Time time) => PlanetHoraSigns(planetName, time).GetSignName();
	public static ZodiacName PlanetDrekkanaD3Sign(PlanetName planetName, Time time) => PlanetDrekkanaSign(planetName, time).GetSignName();

	public static bool UseVedhankaInGochara { get; set; } = true;

	public static bool UseMeanRahuKetu { get; set; } = true;

	public static Secrets Secrets { get; set; }

	public static async Task<string> AddPerson(string ownerId, Time birthTime, string personName, Gender gender, string notes = "", bool failIfDuplicate = false)
	{
		Person newPerson = new Person(ownerId, await PersonManagerTools.GeneratePersonId(ownerId, personName, birthTime.StdYearText, failIfDuplicate), personName, birthTime, gender, notes);
		await AzureCache.DeleteCacheRelatedToPerson(newPerson);
		AzureTable.PersonList_Indic.UpsertEntity(newPerson.ToAzureRow());
		return newPerson.Id;
	}

	public static string BouncBackInputAsString(PlanetName planetName, Time time)
	{
		return planetName.ToString();
	}

	public static GeoLocation CurrentGeoLocation(Time time)
	{
		return time.GetGeoLocation();
	}

	public static async Task<GeoLocation> AddressToGeoLocation(string address)
	{
		return await new Location().AddressToGeoLocation(address);
	}

	public static async Task<dynamic> SearchLocation(string address)
	{
		return await new Location().SearchAddressToGeoLocation(address);
	}

	public static async Task<GeoLocation> CoordinatesToGeoLocation(string latitude, string longitude)
	{
		return await new Location().CoordinatesToGeoLocation(latitude, longitude);
	}

	public static async Task<string> GeoLocationToTimezone(GeoLocation geoLocation, DateTimeOffset timeAtLocation)
	{
		return await new Location().GeoLocationToTimezone(geoLocation, timeAtLocation);
	}

	public static async Task<GeoLocation> IpAddressToGeoLocation(string ipAddress)
	{
		return await new Location().IpAddressToGeoLocation(ipAddress);
	}

	public static List<Event> EventsAtTime(Time birthTime, Time checkTime, List<EventTag> eventTagList)
	{
		Person inputPerson = new Person("", birthTime, Gender.Empty);
		return EventManager.CalculateEvents(1.0, checkTime, checkTime, inputPerson, eventTagList);
	}

	public static Event EventStartEndTime(Time birthTime, Time checkTime, EventName nameOfEvent)
	{
		EventData eventData = EventDataListStatic.Rows.Where((EventData x) => x.Name == nameOfEvent).FirstOrDefault();
		int precisionInHours = 1;
		EventSlice? obj = EventManager.ConvertToEventSlice(person: new Person("", birthTime, Gender.Male), time: checkTime, eventData: eventData);
		if (obj != null && obj.IsOccuring)
		{
			Time startTime = EventStartTime(birthTime, checkTime, eventData, precisionInHours);
			Time endTime = EventEndTime(birthTime, checkTime, eventData, precisionInHours);
			List<EventTag> tagsByEventName = EventManager.GetTagsByEventName(eventData.Name);
			return new Event(eventData.Name, eventData.Nature, eventData.Description, eventData.SpecializedSummary, startTime, endTime, tagsByEventName);
		}
		return Event.Empty;
	}

	public static Time EventStartTime(Time birthTime, Time checkTime, EventData eventData, int precisionInHours)
	{
		Person person = new Person("", birthTime, Gender.Male);
		Time time = checkTime;
		Time time2 = time;
		bool flag = false;
		while (!flag)
		{
			EventSlice eventSlice = EventManager.ConvertToEventSlice(time, eventData, person);
			if (eventSlice != null && eventSlice.IsOccuring)
			{
				time2 = time;
				time = time.SubtractHours(precisionInHours);
			}
			else
			{
				time = time2;
				flag = true;
			}
		}
		return time;
	}

	public static Time EventEndTime(Time birthTime, Time checkTime, EventData eventData, int precisionInHours)
	{
		Person person = new Person("", birthTime, Gender.Male);
		Time time = checkTime;
		Time time2 = time;
		bool flag = false;
		while (!flag)
		{
			EventSlice eventSlice = EventManager.ConvertToEventSlice(time, eventData, person);
			if (eventSlice != null && eventSlice.IsOccuring)
			{
				time2 = time;
				time = time.AddHours(precisionInHours);
			}
			else
			{
				time = time2;
				flag = true;
			}
		}
		return time;
	}

	public static MatchReport CompatibilityMatch(Time maleBirthTime, Time femaleBirthTime)
	{
		Person male = new Person("", maleBirthTime, Gender.Male);
		Person female = new Person("", femaleBirthTime, Gender.Female);
		return MatchReportFactory.GetNewMatchReport(male, female, "101");
	}

	public static async Task<string> BirthTimeLocationAutoAIFill(string personFullName)
	{
		string birthTime = await BirthTimeAutoAIFill(personFullName);
		string birthLocation = await BirthLocationAutoAIFill(personFullName);
		string marriagePartnerName = await MarriagePartnerNameAutoAIFill(personFullName);
		string marriagePartnerBirthTime = await BirthTimeAutoAIFill(marriagePartnerName);
		string marriagePartnerBirthLocation = await BirthLocationAutoAIFill(marriagePartnerName);
		string value = await MarriageTagsAutoAIFill(personFullName, marriagePartnerName);
		return $"{value},{personFullName},{birthTime},{birthLocation},{marriagePartnerName},{marriagePartnerBirthTime},{marriagePartnerBirthLocation}";
	}

	public static async Task<string> BirthTimeAutoAIFill(string personFullName)
	{
		string environmentVariable = Environment.GetEnvironmentVariable("AnyScaleAPIKey");
		using HttpClient client = new HttpClient();
		string content = JsonConvert.SerializeObject(new
		{
			model = "meta-llama/Meta-Llama-3-70B-Instruct",
			messages = new List<object>
			{
				new
				{
					role = "system",
					content = "given person name output birth time as {HH:mm DD/MM/YYYY zzz}"
				},
				new
				{
					role = "user",
					content = "Monroe, Marilyn"
				},
				new
				{
					role = "assistant",
					content = "09:30 01/06/1926 -08:00"
				},
				new
				{
					role = "user",
					content = personFullName
				}
			}
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", environmentVariable);
		client.BaseAddress = new Uri("https://api.endpoints.anyscale.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		return JObject.Parse(await (await client.PostAsync("", stringContent)).Content.ReadAsStringAsync())["choices"][0]["message"]["content"].Value<string>();
	}

	public static async Task<string> MarriageTagsAutoAIFill(string personA, string personB)
	{
		string environmentVariable = Environment.GetEnvironmentVariable("AnyScaleAPIKey");
		using HttpClient client = new HttpClient();
		string content = JsonConvert.SerializeObject(new
		{
			model = "meta-llama/Meta-Llama-3-70B-Instruct",
			messages = new List<object>
			{
				new
				{
					role = "system",
					content = "given married couple name output marriage duration in years"
				},
				new
				{
					role = "user",
					content = "Brad Pitt & Angelina Jolie"
				},
				new
				{
					role = "assistant",
					content = "#2Years"
				},
				new
				{
					role = "user",
					content = "Napoleon Bonaparte & Joséphine"
				},
				new
				{
					role = "assistant",
					content = "#14Years"
				},
				new
				{
					role = "user",
					content = "Dax Shepard & Kristen Bell"
				},
				new
				{
					role = "assistant",
					content = "#StillMarried"
				},
				new
				{
					role = "user",
					content = personA + " & " + personB
				}
			}
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", environmentVariable);
		client.BaseAddress = new Uri("https://api.endpoints.anyscale.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		return JObject.Parse(await (await client.PostAsync("", stringContent)).Content.ReadAsStringAsync())["choices"][0]["message"]["content"].Value<string>();
	}

	public static async Task<string> BirthLocationAutoAIFill(string personFullName)
	{
		string environmentVariable = Environment.GetEnvironmentVariable("AnyScaleAPIKey");
		using HttpClient client = new HttpClient();
		string content = JsonConvert.SerializeObject(new
		{
			model = "meta-llama/Meta-Llama-3-70B-Instruct",
			messages = new List<object>
			{
				new
				{
					role = "system",
					content = "given person name output birth location as {city state country}"
				},
				new
				{
					role = "user",
					content = "Monroe, Marilyn"
				},
				new
				{
					role = "assistant",
					content = "Los Angeles California USA"
				},
				new
				{
					role = "user",
					content = personFullName
				}
			}
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", environmentVariable);
		client.BaseAddress = new Uri("https://api.endpoints.anyscale.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		return JObject.Parse(await (await client.PostAsync("", stringContent)).Content.ReadAsStringAsync())["choices"][0]["message"]["content"].Value<string>();
	}

	public static async Task<string> MarriagePartnerNameAutoAIFill(string personFullName)
	{
		string environmentVariable = Environment.GetEnvironmentVariable("AnyScaleAPIKey");
		using HttpClient client = new HttpClient();
		string content = JsonConvert.SerializeObject(new
		{
			model = "meta-llama/Meta-Llama-3-70B-Instruct",
			messages = new List<object>
			{
				new
				{
					role = "system",
					content = "given person name output first marriage partner name"
				},
				new
				{
					role = "user",
					content = "Monroe, Marilyn"
				},
				new
				{
					role = "assistant",
					content = "James Dougherty"
				},
				new
				{
					role = "user",
					content = personFullName
				}
			}
		});
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", environmentVariable);
		client.BaseAddress = new Uri("https://api.endpoints.anyscale.com/v1/chat/completions");
		StringContent stringContent = new StringContent(content);
		stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		return JObject.Parse(await (await client.PostAsync("", stringContent)).Content.ReadAsStringAsync())["choices"][0]["message"]["content"].Value<string>();
	}

	public static async Task<JObject> GetData(string searchQuery)
	{
		string bING_IMAGE_SEARCH = Secrets.BING_IMAGE_SEARCH;
		string text = "https://api.bing.microsoft.com/v7.0/entities";
		using HttpClient client = new HttpClient();
		Uri requestUri = new Uri(text + "?q=" + Uri.EscapeDataString(searchQuery) + "&count=100&mkt=en-US");
		client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", bING_IMAGE_SEARCH);
		return JObject.Parse(await (await client.GetAsync(requestUri)).Content.ReadAsStringAsync());
	}

	public static async Task<JObject> HoroscopeChat(Time birthTime, string userQuestion, string userId, string sessionId = "")
	{
		return await ChatAPI.SendMessageHoroscope(birthTime, userQuestion, sessionId, userId);
	}

	public static async Task HoroscopeChat2(Time birthTime, string userQuestion, string userId, string sessionId = "")
	{
		await ChatAPI.LLMSearchAPICall_CohereEmbed(userQuestion);
	}

	public static async Task<JObject> HoroscopeChatFeedback(string answerHash, int feedbackScore)
	{
		return await ChatAPI.HoroscopeChatFeedback(answerHash, feedbackScore);
	}

	public static async Task<JObject> HoroscopeFollowUpChat(Time birthTime, string followUpQuestion, string primaryAnswerHash, string userId, string sessionId)
	{
		return await ChatAPI.SendMessageHoroscopeFollowUp(birthTime, followUpQuestion, primaryAnswerHash, userId, sessionId);
	}

	public static async Task<JObject> MatchChat(Time maleBirthTime, Time femaleBirthTime, string userQuestion, string chatSession = "")
	{
		return await ChatAPI.SendMessageMatch(maleBirthTime, femaleBirthTime, userQuestion, chatSession);
	}

	public static async Task<List<HoroscopePrediction>> HoroscopeLLMSearch(Time birthTime, string textInput)
	{
		string value = birthTime.ToUrl();
		string jsonData = $"{{\"query\":\"{textInput}\",\r\n                                \"birth_time\":\"{value}\",\r\n                                \"llm_model_name\":\"sentence-transformers/all-MiniLM-L6-v2\",\r\n                                \"search_type\" : \"similarity\"\r\n                            }}";
		JToken obj = await Tools.MakePostRequest("https://vedastrocontainer.delightfulground-a2445e4b.westus2.azurecontainerapps.io/HoroscopeLLMSearch", jsonData);
		List<HoroscopePrediction> list = new List<HoroscopePrediction>();
		foreach (JToken item in (IEnumerable<JToken>)obj)
		{
			list.Add(HoroscopePrediction.FromLLMJson(item));
		}
		return list;
	}

	public static string GenerateTimeListCSV(Time startTime, Time endTime, double hoursBetween)
	{
		List<Time> timeListFromRange = Time.GetTimeListFromRange(startTime, endTime, hoursBetween);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Name,Time,Location");
		for (int i = 0; i < timeListFromRange.Count; i++)
		{
			Time time = timeListFromRange[i];
			string value = time.GetGeoLocation().Name().Replace(",", "");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(5, 3, stringBuilder2);
			handler.AppendLiteral("row");
			handler.AppendFormatted(i);
			handler.AppendLiteral(",");
			handler.AppendFormatted(time.GetStdDateTimeOffsetText());
			handler.AppendLiteral(",");
			handler.AppendFormatted(value);
			stringBuilder2.AppendLine(ref handler);
		}
		return stringBuilder.ToString();
	}

	public static Angle PunyaSahamLongitude(Time birthTime)
	{
		_ = PlanetNirayanaLongitude(PlanetName.Moon, birthTime).TotalDegrees;
		_ = PlanetNirayanaLongitude(PlanetName.Sun, birthTime).TotalDegrees;
		TajikaDateForYear(birthTime, 205);
		return Angle.Degrees180;
	}

	public static Angle VidyaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle YasasSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle MitraSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle MahatmyaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle AshaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle SamarthaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle BhratruSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle GauravaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle PitruSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle RajyaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle MatruSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle PutraSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle JeevastambaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle KarmaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle RogaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle KalaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle ShashtrasthanaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle BandhuSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle MrityuSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle ParadeshSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle ArthastambaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle ParameshthisthanaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle VanijSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle KaryasiddhiSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle VivahaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle SanthanasthanaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle SradhdhasthanamSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle PreethistambhaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle JadysthanamSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle VyanjansthanaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle SathruSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle JaladoshamSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle BandhanasthanaSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle ApamrithyusthanamSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	public static Angle LabhesthanamSahamLongitude(Time standardHoroscope)
	{
		throw new NotImplementedException();
	}

	private static bool IsSahamCBetweenBToA(double aLong, double bLong, double cLong)
	{
		int num = (int)(aLong / 30.0);
		int num2 = (int)(bLong / 30.0);
		int num3 = (int)(cLong / 30.0);
		bool result = false;
		for (int i = num2; i < num2 + 11; i++)
		{
			int num4 = (i + 1) % 12;
			if (num4 == num3)
			{
				result = true;
				break;
			}
			if (num4 == num)
			{
				break;
			}
		}
		return result;
	}

	public static Angle PlanetDivisionalLongitude(PlanetName planetName, Time inputTime, int divisionalNo)
	{
		double num;
		for (num = PlanetNirayanaLongitude(planetName, inputTime).TotalDegrees * (double)divisionalNo; num >= 60.0; num -= 60.0)
		{
		}
		return Angle.FromDegrees(num);
	}

	public static Angle DivisionalLongitude(double totalDegrees, int divisionalNo)
	{
		double num;
		for (num = totalDegrees * (double)divisionalNo; num >= 60.0; num -= 60.0)
		{
		}
		return Angle.FromDegrees(num);
	}

	public static ZodiacSign PlanetZodiacSign(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetZodiacSign", planetName, time, Ayanamsa, UseMeanRahuKetu), _planetZodiacSign);
		ZodiacSign _planetZodiacSign()
		{
			return ZodiacSignAtLongitude(PlanetNirayanaLongitude(planetName, time));
		}
	}

	public static ZodiacSign PlanetHoraSigns(PlanetName planetName, Time time)
	{
		return DrekkanaSignName(PlanetZodiacSign(planetName, time));
	}

	public static ZodiacSign HoraSignName(ZodiacSign zodiacSign)
	{
		return Vargas.VargasCoreCalculator(zodiacSign, Vargas.HoraTable[zodiacSign.GetSignName()], 2);
	}

	public static ZodiacSign HoraSignAtLongitude(Angle longitude)
	{
		return HoraSignName(ZodiacSignAtLongitude(longitude));
	}

	public static ZodiacSign HouseHoraSign(HouseName houseNumber, Time time)
	{
		return HoraSignAtLongitude(AllHouseMiddleLongitudes(time).Find((House house) => house.GetHouseName() == houseNumber).GetMiddleLongitude());
	}

	public static ZodiacSign PlanetDrekkanaSign(PlanetName planetName, Time time)
	{
		return DrekkanaSignName(PlanetZodiacSign(planetName, time));
	}

	public static ZodiacSign DrekkanaSignName(ZodiacSign zodiacSign)
	{
		return Vargas.VargasCoreCalculator(zodiacSign, Vargas.DrekkanaTable[zodiacSign.GetSignName()], 3);
	}

	public static ZodiacSign PlanetChaturthamshaSign(PlanetName planetName, Time time)
	{
		return ChaturthamshaSignName(PlanetZodiacSign(planetName, time));
	}

	public static ZodiacSign ChaturthamshaSignName(ZodiacSign zodiacSign)
	{
		return Vargas.VargasCoreCalculator(zodiacSign, Vargas.ChaturthamshaTable[zodiacSign.GetSignName()], 4);
	}

	public static Dictionary<PlanetName, ZodiacSign> AllPlanetSigns(Time time)
	{
		return PlanetName.All9Planets.ToDictionary((PlanetName planet) => planet, (PlanetName planet) => new ZodiacSign(PlanetZodiacSign(planet, time).GetSignName(), Angle.Zero));
	}

	public static Dictionary<PlanetName, ZodiacSign> AllPlanetHoraSign(Time time)
	{
		return PlanetName.All9Planets.ToDictionary((PlanetName planet) => planet, (PlanetName planet) => PlanetHoraSigns(planet, time));
	}

	public static Dictionary<PlanetName, ZodiacSign> AllPlanetDrekkanaSign(Time time)
	{
		return PlanetName.All9Planets.ToDictionary((PlanetName planet) => planet, (PlanetName planet) => PlanetDrekkanaSign(planet, time));
	}

	public static Dictionary<PlanetName, ZodiacSign> AllPlanetChaturthamsaSign(Time time)
	{
		return PlanetName.All9Planets.ToDictionary((PlanetName planet) => planet, (PlanetName planet) => PlanetChaturthamshaSign(planet, time));
	}

	public static Dictionary<PlanetName, ZodiacSign> AllPlanetPanchamsaSign(Time time)
	{
		return PlanetName.All9Planets.ToDictionary((PlanetName planet) => planet, (PlanetName planet) => PlanetPanchamsaSign(planet, time));
	}

	public static Angle PlanetTajikaLongitude(PlanetName planetName, Time birthTime, int scanYear)
	{
		Time time = TajikaDateForYear(birthTime, scanYear);
		return PlanetNirayanaLongitude(planetName, time);
	}

	public static Constellation PlanetTajikaConstellation(PlanetName planetName, Time birthTime, int scanYear)
	{
		return ConstellationAtLongitude(PlanetTajikaLongitude(planetName, birthTime, scanYear));
	}

	public static ZodiacSign PlanetTajikaZodiacSign(PlanetName planetName, Time birthTime, int scanYear)
	{
		return ZodiacSignAtLongitude(PlanetTajikaLongitude(planetName, birthTime, scanYear));
	}

	public static Time TajikaDateForYear2(Time birthTime, int scanYear)
	{
		return CacheManager.GetCache(new CacheKey("TajikaDateForYear2", birthTime, scanYear, Ayanamsa), _tajikaDateForYear);
		Time _tajikaDateForYear()
		{
			ZodiacSign zodiacSign = SunSign(birthTime);
			bool flag = false;
			Time time = new Time($"00:00 {birthTime.StdDateText()}/{birthTime.StdMonthText()}/{scanYear} {birthTime.StdTimezoneText}", birthTime.GetGeoLocation());
			Time time2 = time.SubtractHours(Tools.DaysToHours(5.0));
			while (!flag)
			{
				ZodiacSign zodiacSign2 = SunSign(time2);
				bool num = zodiacSign.GetSignName() == zodiacSign2.GetSignName();
				double totalDegrees = zodiacSign.GetDegreesInSign().TotalDegrees;
				double totalDegrees2 = zodiacSign2.GetDegreesInSign().TotalDegrees;
				double num2 = 0.008;
				bool flag2 = Math.Abs(totalDegrees - totalDegrees2) <= num2;
				if (num & flag2)
				{
					flag = true;
				}
				else
				{
					time2 = time2.AddHours(0.3);
				}
			}
			return time2;
		}
	}

	public static Time TajikaDateForYear(Time birthTime, int scanYear)
	{
		return CacheManager.GetCache(new CacheKey("TajikaDateForYear", birthTime, scanYear, Ayanamsa), _tajikaDateForYear);
		static Time _tajikaDateForYear()
		{
			new Dictionary<int, Dictionary<string, int>>
			{
				{
					1,
					new Dictionary<string, int>
					{
						{ "Days", 1 },
						{ "Hrs", 6 },
						{ "Mts", 9 },
						{ "Secs", 12 }
					}
				},
				{
					2,
					new Dictionary<string, int>
					{
						{ "Days", 2 },
						{ "Hrs", 12 },
						{ "Mts", 18 },
						{ "Secs", 18 }
					}
				},
				{
					3,
					new Dictionary<string, int>
					{
						{ "Days", 3 },
						{ "Hrs", 18 },
						{ "Mts", 27 },
						{ "Secs", 30 }
					}
				},
				{
					4,
					new Dictionary<string, int>
					{
						{ "Days", 5 },
						{ "Hrs", 0 },
						{ "Mts", 36 },
						{ "Secs", 36 }
					}
				},
				{
					5,
					new Dictionary<string, int>
					{
						{ "Days", 6 },
						{ "Hrs", 6 },
						{ "Mts", 45 },
						{ "Secs", 48 }
					}
				},
				{
					6,
					new Dictionary<string, int>
					{
						{ "Days", 0 },
						{ "Hrs", 12 },
						{ "Mts", 55 },
						{ "Secs", 0 }
					}
				},
				{
					7,
					new Dictionary<string, int>
					{
						{ "Days", 1 },
						{ "Hrs", 19 },
						{ "Mts", 4 },
						{ "Secs", 6 }
					}
				},
				{
					8,
					new Dictionary<string, int>
					{
						{ "Days", 3 },
						{ "Hrs", 1 },
						{ "Mts", 13 },
						{ "Secs", 18 }
					}
				},
				{
					9,
					new Dictionary<string, int>
					{
						{ "Days", 4 },
						{ "Hrs", 7 },
						{ "Mts", 22 },
						{ "Secs", 30 }
					}
				},
				{
					10,
					new Dictionary<string, int>
					{
						{ "Days", 5 },
						{ "Hrs", 13 },
						{ "Mts", 31 },
						{ "Secs", 36 }
					}
				},
				{
					20,
					new Dictionary<string, int>
					{
						{ "Days", 4 },
						{ "Hrs", 13 },
						{ "Mts", 3 },
						{ "Secs", 12 }
					}
				},
				{
					30,
					new Dictionary<string, int>
					{
						{ "Days", 2 },
						{ "Hrs", 16 },
						{ "Mts", 34 },
						{ "Secs", 54 }
					}
				},
				{
					40,
					new Dictionary<string, int>
					{
						{ "Days", 1 },
						{ "Hrs", 6 },
						{ "Mts", 6 },
						{ "Secs", 30 }
					}
				},
				{
					50,
					new Dictionary<string, int>
					{
						{ "Days", 6 },
						{ "Hrs", 19 },
						{ "Mts", 38 },
						{ "Secs", 6 }
					}
				},
				{
					60,
					new Dictionary<string, int>
					{
						{ "Days", 5 },
						{ "Hrs", 9 },
						{ "Mts", 9 },
						{ "Secs", 42 }
					}
				},
				{
					70,
					new Dictionary<string, int>
					{
						{ "Days", 3 },
						{ "Hrs", 22 },
						{ "Mts", 41 },
						{ "Secs", 24 }
					}
				},
				{
					80,
					new Dictionary<string, int>
					{
						{ "Days", 2 },
						{ "Hrs", 12 },
						{ "Mts", 13 },
						{ "Secs", 0 }
					}
				},
				{
					90,
					new Dictionary<string, int>
					{
						{ "Days", 1 },
						{ "Hrs", 1 },
						{ "Mts", 44 },
						{ "Secs", 36 }
					}
				},
				{
					100,
					new Dictionary<string, int>
					{
						{ "Days", 6 },
						{ "Hrs", 15 },
						{ "Mts", 13 },
						{ "Secs", 12 }
					}
				}
			};
			throw new Exception();
		}
	}

	public static HouseName TransitHouseFromLagna(PlanetName transitPlanet, Time checkTime, Time birthTime)
	{
		ZodiacSign zodiacSign = HouseZodiacSign(HouseName.House1, birthTime);
		ZodiacSign zodiacSign2 = PlanetZodiacSign(transitPlanet, checkTime);
		return (HouseName)CountFromSignToSign(zodiacSign.GetSignName(), zodiacSign2.GetSignName());
	}

	public static HouseName TransitHouseFromNavamsaLagna(PlanetName transitPlanet, Time checkTime, Time birthTime)
	{
		return (HouseName)CountFromSignToSign(HouseNavamsaSign(HouseName.House1, birthTime), PlanetZodiacSign(transitPlanet, checkTime).GetSignName());
	}

	public static HouseName TransitHouseFromMoon(PlanetName transitPlanet, Time checkTime, Time birthTime)
	{
		ZodiacSign zodiacSign = PlanetZodiacSign(PlanetName.Moon, birthTime);
		ZodiacSign zodiacSign2 = PlanetZodiacSign(transitPlanet, checkTime);
		return (HouseName)CountFromSignToSign(zodiacSign.GetSignName(), zodiacSign2.GetSignName());
	}

	public static HouseName TransitHouseFromNavamsaMoon(PlanetName transitPlanet, Time checkTime, Time birthTime)
	{
		return (HouseName)CountFromSignToSign(PlanetNavamsaSign(PlanetName.Moon, birthTime), PlanetZodiacSign(transitPlanet, checkTime).GetSignName());
	}

	public static string Murthi(PlanetName transitPlanet, Time checkTime, Time birthTime)
	{
		return "";
	}

	public static BirdActivity AbstractActivity(Time checkTime)
	{
		Time time = BirthYama(checkTime).YamaStartTime;
		if (IsDayBirth(checkTime))
		{
			foreach (KeyValuePair<BirdActivity, double> item in new Dictionary<BirdActivity, double>
			{
				{
					BirdActivity.Eating,
					30.0
				},
				{
					BirdActivity.Walking,
					36.0
				},
				{
					BirdActivity.Ruling,
					48.0
				},
				{
					BirdActivity.Sleeping,
					18.0
				},
				{
					BirdActivity.Dying,
					12.0
				}
			})
			{
				double value = item.Value;
				Time time2 = time.AddHours(Tools.MinutesToHours(value));
				if (time < checkTime && time2 > checkTime)
				{
					return item.Key;
				}
				time = time2;
			}
		}
		else
		{
			foreach (KeyValuePair<BirdActivity, double> item2 in new Dictionary<BirdActivity, double>
			{
				{
					BirdActivity.Eating,
					30.0
				},
				{
					BirdActivity.Ruling,
					24.0
				},
				{
					BirdActivity.Dying,
					36.0
				},
				{
					BirdActivity.Walking,
					30.0
				},
				{
					BirdActivity.Sleeping,
					24.0
				}
			})
			{
				double value2 = item2.Value;
				Time time3 = time.AddHours(Tools.MinutesToHours(value2));
				if (time < checkTime && time3 > checkTime)
				{
					return item2.Key;
				}
				time = time3;
			}
		}
		throw new Exception("END OF LINE!");
	}

	public static BirdActivity MainActivity(Time birthTime, Time checkTime)
	{
		BirdName key = PanchaPakshiBirthBird(birthTime);
		PanchaPakshi.TimeOfDay key2 = (IsDayBirth(checkTime) ? PanchaPakshi.TimeOfDay.Day : PanchaPakshi.TimeOfDay.Night);
		DayOfWeek key3 = DayOfWeek(checkTime);
		int yamaCount = BirthYama(checkTime).YamaCount;
		return PanchaPakshi.TableData[key2][key3][yamaCount][key];
	}

	public static BirthYama BirthYama(Time inputTime)
	{
		Time time = VedicDayStartTime(inputTime);
		bool flag = false;
		int num = 1;
		Time time2 = time;
		while (!flag)
		{
			Time time3 = time2.AddHours(2.4);
			if (time2 <= inputTime && time3 >= inputTime)
			{
				if (num > 5)
				{
					num -= 5;
				}
				return new BirthYama(num, time2, time3);
			}
			time2 = time3;
			num++;
		}
		throw new Exception("END OF LINE!");
	}

	public static Time VedicDayStartTime(Time inputTime)
	{
		Time time = SunriseTime(inputTime);
		if (time > inputTime)
		{
			return SunriseTime(inputTime.SubtractHours(23.0));
		}
		return time;
	}

	public static double AbstractActivityStrength(Time birthTime, Time checkTime)
	{
		BirdName key = PanchaPakshiBirthBird(birthTime);
		BirdActivity key2 = MainActivity(birthTime, checkTime);
		BirdActivity key3 = AbstractActivity(checkTime);
		return PanchaPakshi.AbstractActivityStrengthTable[key][key2][key3];
	}

	public static BirdName PanchaPakshiBirthBird(Time birthTime)
	{
		int constellationName = (int)MoonConstellation(birthTime).GetConstellationName();
		if (IsWaxingMoon(birthTime))
		{
			switch (constellationName)
			{
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				return BirdName.Vulture;
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
				return BirdName.Owl;
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
				return BirdName.Crow;
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
				return BirdName.Cock;
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
				return BirdName.Peacock;
			}
		}
		else
		{
			switch (constellationName)
			{
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				return BirdName.Peacock;
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
				return BirdName.Cock;
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
				return BirdName.Crow;
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
				return BirdName.Owl;
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
				return BirdName.Vulture;
			}
		}
		throw new Exception("END OF LINE!");
	}

	public static BirdName PanchaPakshiBirthBirdFromName(string name)
	{
		throw new NotImplementedException();
	}

	public static bool IsWaxingMoon(Time birthTime)
	{
		return LunarDay(birthTime).GetMoonPhase() == MoonPhase.BrightHalf;
	}

	public static bool IsWaningMoon(Time birthTime)
	{
		return LunarDay(birthTime).GetMoonPhase() == MoonPhase.DarkHalf;
	}

	public static string FirstVowelSound(string word)
	{
		new HashSet<char>("aeiouAEIOU");
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "AI", "I" },
			{ "AE", "A" },
			{ "AO", "A" },
			{ "AU", "A" },
			{ "EZ", "EA" },
			{ "JA", "EA" },
			{ "PE", "EA" },
			{ "ES", "EA" },
			{ "EI", "E" },
			{ "MI", "E" },
			{ "EA", "E" },
			{ "EO", "E" },
			{ "EU", "E" },
			{ "IA", "I" },
			{ "IE", "I" },
			{ "IO", "I" },
			{ "IU", "I" },
			{ "OA", "O" },
			{ "OE", "O" },
			{ "OI", "O" },
			{ "OU", "OW" },
			{ "OP", "O" },
			{ "UA", "U" },
			{ "UE", "U" },
			{ "UI", "U" },
			{ "UO", "U" }
		};
		List<string> list = Syllables(new string(word.Where(char.IsLetter).ToArray()));
		for (int i = 0; i < list.Count; i++)
		{
			string text = list[i];
			char reference;
			if (!IsVowel(text))
			{
				if (i >= list.Count - 1)
				{
					continue;
				}
				reference = text[text.Length - 1];
				if (!IsVowel(reference.ToString()))
				{
					continue;
				}
				reference = list[i + 1][0];
				if (!IsVowel(reference.ToString()))
				{
					continue;
				}
			}
			if (i < list.Count - 1)
			{
				reference = text[text.Length - 1];
				if (IsVowel(reference.ToString()))
				{
					reference = list[i + 1][0];
					if (IsVowel(reference.ToString()))
					{
						reference = text[text.Length - 1];
						string text2 = string.Concat(new ReadOnlySpan<char>(in reference), new ReadOnlySpan<char>(list[i + 1][0]));
						if (dictionary.TryGetValue(text2.ToUpper(), out var value))
						{
							return value;
						}
						return text2;
					}
				}
			}
			if (IsVowel(text) && dictionary.TryGetValue(text.ToUpper(), out var value2))
			{
				return value2;
			}
			if (i < list.Count - 1)
			{
				if (IsVowel(text[text.Length - 1].ToString()) && !IsVowel(list[i + 1][0].ToString()))
				{
					return text[text.Length - 1].ToString();
				}
			}
			return text;
		}
		return "";
		static bool IsVowel(string syllable)
		{
			return syllable.Any((char c) => "aeiou".Contains(char.ToLower(c)));
		}
		static List<string> Syllables(string text3)
		{
			HashSet<char> hashSet = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
			List<string> list2 = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			for (int j = 0; j < text3.Length; j++)
			{
				stringBuilder.Append(text3[j]);
				if (hashSet.Contains(char.ToLower(text3[j])))
				{
					list2.Add(stringBuilder.ToString());
					stringBuilder.Clear();
					if (j < text3.Length - 1 && !hashSet.Contains(char.ToLower(text3[j + 1])))
					{
						stringBuilder.Append(text3[j + 1]);
						j++;
					}
				}
			}
			if (stringBuilder.Length > 0)
			{
				list2.Add(stringBuilder.ToString());
			}
			for (int k = 0; k < list2.Count - 1; k++)
			{
				if (list2[k].Length == 1 && list2[k + 1].Length == 1 && hashSet.Contains(char.ToLower(list2[k][0])) && hashSet.Contains(char.ToLower(list2[k + 1][0])))
				{
					list2[k] += list2[k + 1];
					list2.RemoveAt(k + 1);
					k--;
				}
			}
			return list2;
		}
	}

	public static PanchangaTable PanchangaTable(Time inputTime)
	{
		string degreesMinutesSecondsText = AyanamsaDegree(inputTime).DegreesMinutesSecondsText;
		LunarDay tithi = LunarDay(inputTime);
		LunarMonth lunarMonth = LunarMonth(inputTime);
		DayOfWeek vara = DayOfWeek(inputTime);
		Constellation nakshatra = MoonConstellation(inputTime);
		NithyaYoga yoga = NithyaYoga(inputTime);
		Karana karana = Karana(inputTime);
		PlanetName horaLord = LordOfHoraFromTime(inputTime);
		string dishaShool = DishaShool(inputTime);
		Time sunrise = SunriseTime(inputTime);
		Time sunset = SunsetTime(inputTime);
		Angle ishtaKaala = IshtaKaala(inputTime);
		return new PanchangaTable(degreesMinutesSecondsText, tithi, lunarMonth, vara, nakshatra, yoga, karana, horaLord, dishaShool, sunrise, sunset, ishtaKaala);
	}

	public static string DishaShool(Time inputTime)
	{
		return DayOfWeek(inputTime) switch
		{
			VedAstro.Library.DayOfWeek.Monday => "East", 
			VedAstro.Library.DayOfWeek.Tuesday => "North", 
			VedAstro.Library.DayOfWeek.Wednesday => "North", 
			VedAstro.Library.DayOfWeek.Thursday => "South", 
			VedAstro.Library.DayOfWeek.Friday => "West", 
			VedAstro.Library.DayOfWeek.Saturday => "East", 
			VedAstro.Library.DayOfWeek.Sunday => "West", 
			_ => throw new Exception("END OF LINE!"), 
		};
	}

	public static LunarMonth LunarMonth(Time inputTime, bool ignoreLeapMonth = false)
	{
		Time inputTime2 = SunriseTime(inputTime);
		Time time = PreviousNewMoon(inputTime2);
		Time time2 = NextNewMoon(inputTime2);
		ZodiacName num = MoonSignName(time);
		int num2 = (int)MoonSignName(time2);
		bool flag = num == (ZodiacName)num2;
		int num3 = (int)(num + 1);
		if (num3 > 12)
		{
			num3 %= 12;
		}
		if (flag && !ignoreLeapMonth)
		{
			LunarMonth lunarMonth = LunarMonth(NextNewMoon(time2.AddHours(24.0)), ignoreLeapMonth: true);
			LunarMonth lunarMonth2 = (LunarMonth)num3;
			string value = lunarMonth2.ToString();
			if (!lunarMonth.ToString().Contains(value))
			{
				flag = false;
			}
		}
		LunarMonth result = VedAstro.Library.LunarMonth.Empty;
		switch (num3)
		{
		case 1:
			result = ((!flag) ? VedAstro.Library.LunarMonth.Chaitra : VedAstro.Library.LunarMonth.ChaitraAdhika);
			break;
		case 2:
			result = (flag ? VedAstro.Library.LunarMonth.VaisaakhaAdhika : VedAstro.Library.LunarMonth.Vaisaakha);
			break;
		case 3:
			result = (flag ? VedAstro.Library.LunarMonth.JyeshthaAdhika : VedAstro.Library.LunarMonth.Jyeshtha);
			break;
		case 4:
			result = (flag ? VedAstro.Library.LunarMonth.AashaadhaAdhika : VedAstro.Library.LunarMonth.Aashaadha);
			break;
		case 5:
			result = (flag ? VedAstro.Library.LunarMonth.SraavanaAdhika : VedAstro.Library.LunarMonth.Sraavana);
			break;
		case 6:
			result = (flag ? VedAstro.Library.LunarMonth.BhaadrapadaAdhika : VedAstro.Library.LunarMonth.Bhaadrapada);
			break;
		case 7:
			result = (flag ? VedAstro.Library.LunarMonth.AaswayujaAdhika : VedAstro.Library.LunarMonth.Aaswayuja);
			break;
		case 8:
			result = (flag ? VedAstro.Library.LunarMonth.KaarteekaAdhika : VedAstro.Library.LunarMonth.Kaarteeka);
			break;
		case 9:
			result = (flag ? VedAstro.Library.LunarMonth.MaargasiraAdhika : VedAstro.Library.LunarMonth.Maargasira);
			break;
		case 10:
			result = (flag ? VedAstro.Library.LunarMonth.PushyaAdhika : VedAstro.Library.LunarMonth.Pushya);
			break;
		case 11:
			result = (flag ? VedAstro.Library.LunarMonth.MaaghaAdhika : VedAstro.Library.LunarMonth.Maagha);
			break;
		case 12:
			result = (flag ? VedAstro.Library.LunarMonth.PhaalgunaAdhika : VedAstro.Library.LunarMonth.Phaalguna);
			break;
		}
		return result;
	}

	public static Time NextNewMoon(Time inputTime)
	{
		Time time = inputTime;
		while (!(SunMoonConjunctionAngle(time).TotalDegrees < 1.0))
		{
			time = time.AddHours(0.5);
		}
		return time;
	}

	public static Time PreviousNewMoon(Time inputTime)
	{
		Time time = inputTime;
		while (!(SunMoonConjunctionAngle(time).TotalDegrees < 1.0))
		{
			time = time.SubtractHours(0.5);
		}
		return time;
	}

	public static Angle SunMoonConjunctionAngle(Time ccc)
	{
		Angle value = PlanetNirayanaLongitude(PlanetName.Sun, ccc);
		return PlanetNirayanaLongitude(PlanetName.Moon, ccc).GetDifference(value).Expunge360();
	}

	public static int BirthNumber(Time birthTime)
	{
		int num;
		for (num = birthTime.StdDate(); num > 9; num = (from x in num.ToString()
			select x - 48).Sum())
		{
		}
		return num;
	}

	public static int DestinyNumber(Time birthTime)
	{
		int num;
		for (num = (from x in birthTime.StdDateMonthYearText.Replace("/", "")
			select x - 48).Sum(); num > 9; num = (from x in num.ToString()
			select x - 48).Sum())
		{
		}
		return num;
	}

	public static int NameNumber(string fullName)
	{
		Dictionary<char, int> dictionary = new Dictionary<char, int>
		{
			{ 'a', 1 },
			{ 'b', 2 },
			{ 'c', 3 },
			{ 'd', 4 },
			{ 'e', 5 },
			{ 'f', 8 },
			{ 'g', 3 },
			{ 'h', 5 },
			{ 'i', 1 },
			{ 'j', 1 },
			{ 'k', 2 },
			{ 'l', 3 },
			{ 'm', 4 },
			{ 'n', 5 },
			{ 'o', 7 },
			{ 'p', 8 },
			{ 'q', 1 },
			{ 'r', 2 },
			{ 's', 3 },
			{ 't', 4 },
			{ 'u', 6 },
			{ 'v', 6 },
			{ 'w', 6 },
			{ 'x', 5 },
			{ 'y', 1 },
			{ 'z', 7 }
		};
		Dictionary<char, int> dictionary2 = new Dictionary<char, int>
		{
			{ 'a', 1 },
			{ 'b', 2 },
			{ 'c', 3 },
			{ 'd', 4 },
			{ 'e', 5 },
			{ 'f', 8 },
			{ 'g', 3 },
			{ 'h', 5 },
			{ 'i', 10 },
			{ 'j', 10 },
			{ 'k', 20 },
			{ 'l', 30 },
			{ 'm', 40 },
			{ 'n', 50 },
			{ 'o', 70 },
			{ 'p', 80 },
			{ 'q', 100 },
			{ 'r', 200 },
			{ 's', 30 },
			{ 't', 400 },
			{ 'u', 6 },
			{ 'v', 6 },
			{ 'w', 6 },
			{ 'x', 5 },
			{ 'y', 10 },
			{ 'z', 7 }
		};
		fullName = fullName.Replace(".", "");
		fullName = Regex.Replace(fullName, "[^a-zA-Z]", "");
		fullName = fullName.ToLower();
		string[] array = fullName.Split(" ");
		int num = 0;
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Length == 1)
			{
				num += dictionary2[text[0]];
				continue;
			}
			string text2 = text;
			foreach (char key in text2)
			{
				num += dictionary[key];
			}
		}
		return num;
	}

	public static string NameNumberPrediction(string fullName)
	{
		int num = NameNumber(fullName);
		Dictionary<int, string> dictionary = new Dictionary<int, string>
		{
			{ 10, "This number when comes as a name indicates the sound or resonance of the primal force. This is depicted in the ancient texts as a snake enmeshed within a wheel. Those named under this number will be dignified and popular. Confidence and patience coexist in their lives but their fortunes will change frequently. It is like a revolving wheel, with ups and downs frequently. They must be honest in all their activities and they are bound to gain popularity. They will lead happy lives since there will be no paucity of funds" },
			{ 19, "Ancient books on this subject attribute mastery over the Three Worlds to this Number and as such, these people will be the focus of attention wherever they are. This number indicates the Rising Sun. This also has been described as the “Prince of the Celestial World” in ancient Indian texts and as an ‘‘Ideal Lover’’ in Egyptian scriptures. The sun becomes brighter as the day lengthens and so also these people progress as their age advances. Position, status, happiness, success and wealth will be gradually on the rise. Being well-disciplined, they will look young and will be very active even in their advanced age. They must be honest even in matters related to sensual pleasures.\r" },
			{ 28, "Those with this name number do progress and get all the comforts during the early part of life but they frequently face struggles or difficulties in all their endeavours in life. They may have to start their lives again and again always afresh, many times over. Although they progress very fast in their lives, they finally lose everything due to the cruel stroke of fate. One of the examples of such people born under this number is General MacArthur, a fine soldier who deserved more of honour and recognition, but was deprived of his position and career by President Truman of USA! Those coming under this number may incur unexpected losses due to their friends and relatives. Money lent by them rarely comes back. As such, this number can only be regarded as an unlucky one, since all the hardearned money may be lost unexpectedly." },
			{ 37, "This is a very lucky number. It will lift even an ordinary person to the most prominent positions in life. It brings success in love and the patronage of the elite. These people will have good friends from both sexes. They will be greatly favoured by men if they are women and vice versa. As a result, their lives will improve greatly. People will come forward to invest their capital with such people. Accumulation of money and wealth will be easy through various means. They will have an active interest in the fine arts and in all probability, lead comfortable and luxurious lives. They will be renowned for their pleasing manners and countenance. Some of them will be philanderers because of their casual attitude towards opposite sex. This number, which gives unexpected success, is a desirable one. (Note: If people who occupy very high positions have their names under this number, it may bring them unnecessary problems. This number will bring good fortune to ordinary people. These people should remain satisfied when they attain a certain position in life and should not be too ambitious. This number, will bring fortune automatically, but will lose its power when one becomes too greedy.)\r" },
			{ 46, "This has been described as the “Crowned Head” in the ancient texts. It means that when prudence, intelligence and knowledge are used wisely, it will bring the crown of life. Whatever may be the business, this number will help one to reach the pinnacle of success and is capable of raising even the most ordinary person to the position of a ruler. Wealth and status will go up with the advancement of age. People belonging to this number should be honest in all walks of life." },
			{ 55, "This number predicts that both creation and destruction can be done by a single power. This will bring victory over enemies. Before entering the battlefield, Greek soldiers were ordered to wear a talisman marked with number 55 around their necks. This number is the epitome of will-power and intuition. People under this number will astonish others by their knowledge and win them over. They are acknowledged as scholars. Wisdom and intelligence will be as bright as lightning. If not used in a proper way, this may destroy them. Knowledge in various subjects could be acquired by those born under this number.\r" },
			{ 64, "This number will create equal number of friends and foes. Opposition will be experienced in life. This gives extraordinary will power, intelligence and knowledge. This will bestow fame by enabling them to do things that are considered impossible. This ensures high position in the Government. At times, this will give such a high position that everyone will pay respect and hold these people in high esteem and awe. Their words would cast a powerful influence." },
			{ 73, "This name number strengthens mental faculties and bestows fame, wealth and power. People having this number will aspire to lead comfortable lives and will accomplish their desires. Support from the people of authority will be available and material possessions will be in plenty. If they are not honest, they will lose their fame. If they are the spiritual types, they will lead a peaceful and comfortable life with pure hearts and noble thoughts.\r" },
			{ 82, "This is one of the most powerful numbers and it can elevate even an ordinary person to the status of a ruler. Those having this number in their names are duty-conscious. With unceasing efforts, they will dominate the scene in any field they are placed in. They would own lands, gold mines and precious gems. They are lovers of high-bred horses and will attain the pinnacle of fame by making a fortune either in horse races, car races or in similar sports or business. They create unnecessary problems in their love matters and will be over-adamant in nature. Their eyes have magnetic powers. If the power of this number is properly understood and practiced, no physical or mental feat is impossible to perform.\r" },
			{ 91, "This indicates strong determination and profitable journeys. They also undertake many journeys for trade or otherwise and will do all things with great vigour. Maritime trade using boats and ships will bring them plenty of wealth. They can attain success in breathing exercises like meditation or concentration. Comfortable living awaits them" },
			{ 100, "Even though this number is capable of giving success in all efforts, it will not offer many opportunities. There will be plenty of money. This number implies a long and comfortable life, without any major achievements." },
			{ 11, "Those having 11 as their name number will come up in life by their sheer faith in God. They will proft by various means very easily. They may be riddled with unforeseen problems and dangers, as if to test their faith. Sometimes, they tend to meddle with matters that do not concern them. They are liable to be let down by their family and friends. If they have faith in God, they will definitely attain great heights in life. If they lack faith, they are bound to face a lot of dangers." },
			{ 20, "This spiritual number represents a drumbeat heralding triumph or victory. People having this Name number work for liberation and social reforms. They are capable of providing relief to the masses from grief and struggles. The world will admire them. When they work with personal motives, they are extremely selfish and highly destructive. The 20 number people will excel in medical practice using toxic medicines and deal with poisonous drugs. These people possess the ability to awaken the sleeping masses and lead them to very great achievements. When they go out of their way to satisfy their selfish needs, delay and utter failure will be imminent. (HITLER, born on the 20th, spurred Germany into war and faced a humiliating defeat. He is a very good example of this Name number. He was represented by the battle drum that goaded the people to follow a selfish motive which led to destruction)" },
			{ 29, "Those under this Name number often find it necessary to go to court to settle disputes. They will experience all sorts of problems in their families and will generally be let down by family and friends. Those who praised them yesterday may curse them today. These people live a life of mental agony and sorrow with their life partner. They get into deep troubles with the opposite sex. Any remedial measures taken to come out of these troubles may result in considerable delay and huge loss of money. The personal life will be full of ups and downs. Family life consists of events similar to the feats in a circus! Unless the name number is corrected properly, these people will encounter these problems orever." },
			{ 38, "The people under this name number will be honest, peaceloving and gentle. When it is a name number of a person or a business, it will earn the help of the influential. This Name number can bring great success. People under this number will make rapid development and earn fame and wealth even from very humble beginnings. At times, they will face a lot of dangers and get cheated by bad people, resulting in various dificulties. Even their deaths will be sudden, rather unexpected and unusual.\r" },
			{ 47, "Those who come up very fast in life can be seen amongst the people having this name number. They will be very much concerned about their own progress and will work out plans to achieve the same and will not rest until they reach their goal. As for as money matters are concerned, they will be very lucky and can be considered as very fortunate people. Many people in this number tend to lose their eyesight. Even the best of treatment may be in vain and they suffer very much. For those who have the habit of hunting, it would be better for them to abstain from hunting and eating flesh of any kind.\r" },
			{ 56, "This number is full of wonders. Though this number tends to bring fortune and fame, it is the one that is used by those practising various forms of occultism and divination. This number can free a person from all ties and can break bondage of any kind. Locks would open. Even the animals inside the cage would find their way out. As too much of an explanation would be dangerous, I do not wish to pursue this subject any further. (As explained earlier, the number 29 represents powers of the body and mind, whereas Number 56 gives magical powers). These people will lose their wealth and fame all of a sudden." },
			{ 65, "This number denotes divine grace and progress in spiritual life. It will earn the help of wealthy and powerful patrons. Marital life will be blissful. Persons under this Name number may be sometimes injured in accidents and may have cuts or bruises on their bodies.\r" },
			{ 74, "These people have great affnity towards their religion. They run short of money often. They will introduce social and religious reforms and spread their principles. However, this is not a desirable number. This Name number is best suited only for hermits and priests and is not favourable to others. These people always remain worried about something or the other.\r" },
			{ 83, "This Name Number bestows prestigious posts, which will earn the respect and adoration of many. They will achieve a life of splendour and authority. These people will be successful." },
			{ 92, "This number signifies gold, silver, land, wealth and possession of yogic power. If people having this Name number can carefully practise the art of yogic breathing, they may even acquire the power of Astral projection (defying gravity) or Kechari Mu-dra (defying diseases and death)." },
			{ 101, "Those under this Name number will have greater help from governments or the people of authority (than from their own efforts). There will be lots of obstacles in their business. Slump in business will be common. This cannot be considered a lucky number." },
			{ 3, "This name number denotes hard work, intelligence, success and a comfortable life. They will be highly educated and will gradually progress in life." },
			{ 12, "These people naturally possess the ability to attract people by their power of speech. They sacrifice their lives for the welfare and happiness of others by shouldering their burdens too.\r" },
			{ 21, "These people are self-centered and concerned about their own happiness and matters profitable to them. With great determination, they rise steadily in life and reach the pinnacle of success. Their tactful behaviour helps them to solve all their problems. They struggle hard in their early days but achieve success and happiness as they grow up. They will attain and retain good positions permanently in their lives." },
			{ 30, "These people tend to live in a world of fantasy. They are wise thinkers. They like to do what they feel is right. At times, just for their own satisfaction they get involved in certain difficult tasks, without expecting any returns. They have less interest in making money. They know their minds and conquer the same easily. They gain mystic powers through mind control and related mental exercises.\r" },
			{ 39, "These people are very sincere and hardworking. Invariably, the name and fame that are rightfully due to them will be enjoyed by others. They work unceasingly for the welfare of others. They are not as healthy as the other Number 3 people. At some stage in their lives they are prone to some kind of skin diseases." },
			{ 48, "They will be more interested in religious matters, but face opposition in matters that involve the society at large. They will do a lot of work for public welfare, and create problems for themselves while attempting to do things beyond their capacity. Fate is against them most of the time.\r" },
			{ 57, "This number gives victory or success in the beginning, but brings about gradual downfall and loss of interest in the end. Life which progresses at a very swift pace will grind to a halt all of a sudden. People named under this number will achieve great heights from humble beginnings but will later revert to their original positions.\r" },
			{ 66, "This number denotes dynamism and oratorical skills, perfection in the fine arts, patronage from the government authorities and also a comfortable life.\r" },
			{ 75, "All of a sudden they attain great fame. They will make good friends very soon. Unexpectedly, they become very popular. Fame and comforts will come in search of them. They become good poets and writers." },
			{ 84, "Early days will be full of struggles and worries. They earn enemies unnecessarily. Travelling benefits them. They do not get rewards commensurate to their efforts. They improve themselves to some extent spiritually. Though generally lacking in enthusiasm at first, they can go to extremes, if need be! If the influence of their birth date is favourable, they can be great achievers.\r" },
			{ 93, "These people are capable of doing marvelous things. They improve their worldly knowledge and are lucky to have their desires fulfilled. They excel in the field of histrionics through which they attain more fame. They earn through many business pursuits and lead very dignified lives.\r" },
			{ 102, "This number signifies success at first ,followed by struggles and confusion. These people cannot be called lucky." },
			{ 4, "As this name number will be only for very short names, it signifies a person or a thing that is popular. It does not bring luck as one might deserve. They will have needless fears, sickness and opposition. They can be well informed and worldlywise, but still they would work only as subordinates to others" },
			{ 13, "People in the western counties regard this number as unlucky and ominous. They do not stay in rooms or houses having this number and some hotels even do not have rooms with this number. Unexpected events of sorrowful nature occur frequently. Men of this number have bitter experiences and face a lot of difficulties because of women. Though these people do manage to come up in life materially, they would still lead lives full of struggles. This is not a desirable name number. This number gives only severe grief, if birth and destiny numbers are also unlucky.\r" },
			{ 22, "The characteristics of those born on the 22nd hold equally good for this Name number also. This number instigates base feelings and emotions. They are drawn towards gambling, drinking, speculation and other vices and will readily indulge in them. They may move towards self-destruction at a great speed and are generally surrounded by wicked and fraudulent people. They invariably earn a bad reputation. They dislike the counsel of others. If the influence of their date of birth is favourable, they can be successful. Otherwise, they have to struggle to prevent total failure. Those with selfish motives invariably urge these people to devious ways in order to further their own interests. They are good administrators and can meet any problem or difficulty with courage. Dangerous circumstances are foreseen. They often face humiliations." },
			{ 31, "These people do not care for profit or loss but want only the freedom to do what they desire. Whatever may be the gain involved, they would not like to indulge in anything against their wish. They evince interest in astrology, philosophy and related sciences. These people do not care about what others do or say about them. They only wish to succeed and are never keen on the monetary benefits they gain from such successes. Having succeeded, they sometimes even forgo their due profits. By the 31st year they lose all their material possession and savings. They regain them only by the age of 37. Unexpected happenings will bring about major changes in life. Even their death will be sudden and abrupt. However, when death draws nearer, they somehow become intuitive and sense it well in advance. If their birth number is 1 of any month, this number helps them to achieve great positions in their official career.\r" },
			{ 40, "Those under this number earn good friends, who will be of immense help to them in gaining jobs and positions of distinction. It provides accumulation of fine jewellery and wealth. It also brings fame and prosperity. Yet it is their negative qualities that are noticed by others. They can perform any work without any fear. Eventually, their lives will turn out to be fruitless and in vain. They will lose all their money. They will blame the society for not recognizing their services or help. Lot of problems will come up in their lives and the end will be pathetic.\r" },
			{ 49, "This name number brings abundant riches. Their fame will spread far and wide and their achievements will be the envy of others. They lead highly eventful lives and travel a lot. Wonderful experiences, permanent prosperity, excellent properties and sudden fortunes will come to them. Accidents can also happen suddenly. If the birth number is a fortunate one, they lead happy lives. If not, they can end up being hated by others in the society and life will end in a tragic manner. This number kindles the power of imagination." },
			{ 58, "This number gives outstanding popularity and the power to captivate others. They are great achievers. Life’s progress will be swift. They are pious and orthodox and are great reformers, though attached to religion. If their birth number is 4 or 8 of any month, they will hold positions of great responsibility and fame. They may be sometimes forced to carry out certain things against their wish. Outwardly, these people appear to be very lucky but they also have a lot of unwanted fears within. If the names of those born under other birth numbers also come under this number, life will slowly take a turn for the worse and they will lose their reputation. They may become selfish and may have to undergo a lot of difficulties during their lifetime." },
			{ 67, "These people are exemplary artists (they may be artistes who perform) and work with great determination and vigour. They are patronized by power barons and they reveal noble ideas. (Men should control passions and lust for women.) Love, affection and grace make these people endearing. They can never achieve anything if they are selfish. This number, which helps to attract and conquer others, does not help non-artists." },
			{ 76, "Those having this name number lose all their worldly possessions at some point of time. They are very popular. They will be successful in philanthropic deeds. Surprisingly, they make money in new ways. Income or material gains come through unexpected means. Their last years are generally spent in solitude, doing nothing but eating and sleeping.\r" },
			{ 85, "This name number signifies those who come up the hard way. They not only overcome all afflictions, but help in solving others’ problems too. They reveal new ideas about religion and nature. They shine well in the field of medicine. They generally attain a position of distinction and honour." },
			{ 94, "These people execute lots of good services for the sake of mankind in general. They bring reforms in society. Comfort and fame will come and go in their lives. Their fame and good work will generally be remembered even after their demise. This is a fortunate name number." },
			{ 103, "This name number is also favourable. There will be improvement in material success initially, followed by a change in business. They will face a lot of competition. Later years will be pleasant and comfortable." },
			{ 5, "This number gives the power to charm people, exude dynamism and to lead a luxurious life enjoying fame and prominence. They spend money lavishly. These people should cultivate perseverance and concentration of mind.\r" },
			{ 14, "This number is suitable for trade. Those having this Name number are always surrounded by a lot of people and things. They are successful in various trades and will meet a lot of friends. They may have strange problems and may face disappointments by trusting others. They may also face risk from thunder, lightning, water and fire. They undertake frequent travels. These people are advised to be careful while travelling in fast-moving vehicles. If the product in which they trade also comes under number 14, it will have excellent public patronage. The matters concerning love and marriage must be considered and reconsidered many times before a decision is taken. If not, these people may marry in haste and repent at leisure. This number can be called a very lucky number." },
			{ 23, "This number is the luckiest of all Mercury (5) numbers. These people find success in all their endeavours. All their plans will succeed. They can achieve things which others won’t even imagine. Their accomplishments will astonish those around them. In spite of being such lucky people, if they do not strive hard, they will end up leading ordinary lives. Since they succeed in all their efforts, they will earn the patronage, respect, honour and favour of people in very high positions. Hence, these people are advised to keep up high standards and work out plans to achieve their goals. If not, they might end up leading lives of luxury and pomp devoid of any personal accomplishment. The positive types among them are the most-soughtafter type executives in governments or in private enterprises. The negative types devote time to sleep and daydreaming.\r" },
			{ 32, "This number can attract a variety of people. They have a mass appeal and they come out with unique ideas and techniques even without prior experience. This potent and forceful number can make anyone a prominent person. If they lead their life following their intuition, life will be wonderful. If they listen to the advice of others, failures may recur one after another. This number is said to be the epitome of wisdom and intuition. They have aboveaverage intelligence and a witty manner of speaking. They will become geniuses. Ups and downs will be common in their lives. They will attain high positions in life and will be youthful in appearance even in old age.\r" },
			{ 41, "This number denotes the qualities of charming and controlling. They are renowned achievers and they have high ideals. They are keen about their development and will be world-famous. When they become heady with success, they get into things or matters which are beyond their capability. The failures that could result from such situations will be cleverly hidden from the public scrutiny. They are found to lead successful lives." },
			{ 50, "They are very intelligent people and analyse everything thoroughly. They excel in education. Some people will shine as good teachers. Some others use their intelligence to make money. They are lucky after the age of 50. Their life span will improve and they live longer.\r" },
			{ 59, "Similar to persons belonging to number 50, these people are also research-minded. Their writings are full of humour and they would shine as “Humour Kings” among writers. They would become rich by writing and get excellent public support. Their aim will be to earn money. They will enjoy permanent fortunes. They may suffer from nervous diseases including paralysis. Hence, it is necessary for them to have good habits and keep themselves healthy.\r" },
			{ 68, "This number is lucky to a certain extent. However, life that starts quite pleasantly may suddenly grind to a halt. They will get involved in schemes that they cannot execute and will be badly hurt. Their greed will spoil their career and life. The fortunes that came through an unforeseen stroke of luck may soon disappear. Hence, this number is not quite fortunate." },
			{ 77, "This number denotes sincere effort, selfconfidence and hard work. Support from others brings in profits, fame and honour. Life will be very enchanting. They reap full benefits of this number only if they repose faith in god. They get chances to travel aboard.\r" },
			{ 86, "This number denotes those who come up in a gradual manner and the hard way. They get what they deserve. They earn the favour and help of rich people. With the help so received, they will lead comfortable and happy lives. They will have good savings and lead happy lives.\r" },
			{ 95, "This number signifies a disciplined life combined with daring events and honour. They are successful in trade and achieve distinction. By trading in a variety of new things, they amass wealth. They are excellent orators and will become popular in their line of business.\r" },
			{ 104, "This number will bring success in life followed by unexpected changes. Though they can be good achievers, they can only earn fame and not money. In other words, they become popular but material success may be a far cry" },
			{ 6, "This number signifies a peaceful life, a satisfied and contented mind and a good standard of living. Being a single digit, it does not have much power.\r" },
			{ 15, "The determination to succeed in all the plans and earn money and the quest for achieving one’s ends are signifed by this number. Lust, revenge and malice may push the people of this Name number to a vile state of mind. They may become selfish gradually. A charming appearance and forceful speech will help them in achieving their interests. Though this name number is not one conducive to leading a virtuous life, it is one that is ideally suited for purely material success. An alluring personality, excellence in fine arts and a witty nature yield positive results in any activity that can generate huge profits. Many people come forward to help them in need. Life will be luxurious. If their birth number is also favourable, these people will attain fame, wealth and distinction in all aspects of life" },
			{ 24, "Those named under this number 24 will receive many favours from the government. This number helps them to reach very high positions in their careers easily. They will marry those who are much higher in status and wealth. If the name number comes under 24, these people can be found progressing very fast in uniformed service like the Defense, Para-military forces and the Police. Even if they join as the lowest rank in any field, this number will help them to rise to very high position by its powerful vibrations." },
			{ 33, "This number signifies simultaneous growth in divine grace and prosperity. Those with this name number with or without their knowledge attain spiritual enlightenment surprisingly. Along with divine grace, they are blessed with abundant wealth and properties like granaries, mills etc. They will have many luxurious things at their disposal. They may have everlasting wealth.\r" },
			{ 42, "Those named under this number, even if they are poor at the beginning of their lives, will attain a very prominent rank or position in their careers. They may be greedy at times. They will have thrifty bent of mind and are smart in saving money. They hesitate to part with money even for their own comforts in life. Strength of mind and grace will flourish.\r" },
			{ 51, "This is the most powerful of all numbers under six. It signifies sudden progress. Those who were just commoners yesterday will become popular and prominent to-day. Unusual circumstances will bring about an unexpected ascent in rank and status. Their body and mind will be bubbling with energy and become uncontrollable. They will be frequently lost in thought, or will become emotionally active and put in untiring efforts in their work. These people who are active in body and mind cannot sleep peacefully. They become restless like a caged lion. To be precise, these people will be ruled by an extra-ordinary energy or power of both body and mind. As there is a possibility of these people making enemies who could threaten their lives, it is advisable for them not to hurt others’ sentiments or feelings. This number is considered to be fortunate, as it signifes the accumulation of abundant wealth." },
			{ 60, "This number signifies peace, prosperity, appreciation of fine arts, a balanced state of mind and wisdom. They are skilled conversationalists who can put forth very logical arguments. Their family life will be happy and idealistic. This is quite a fortunate number.\r" },
			{ 69, "The person named under this number will be like an uncrowned king in any business they are involved in. They overtake others and retain their position safely by their own efforts. They are majestic in appearance, very prosperous and will achieve awe-inspiring status. Spurred by emotions, they are known to spend money lavishly for their self-satisfaction. They possess majesty and will lead extremely comfortable and luxurious lives. They are incomparable when it comes to charming others with their tact and speech.\r" },
			{ 78, "They are the most righteous type among all the Number 6 people. They have a great leaning towards their religion and sometimes follow orthodox beliefs. They can become good poets and can bring the listeners under their spell. They are very generous and are fond of social service. They earn or inherit large sums of money very easily. But, if they are not careful, they could lose all their possessions except the Divine grace. Some of them attain success in occult practices and will be respected by one and all in society" },
			{ 87, "This number can give mystic powers. Money will be earned by devious and illegal means. In case of a “negative swing”, this number makes people steal at midnight and helps them to charm snakes and tame animals. If birth and destiny numbers are not positive, this number could be related to criminals and bad people. So, the less we discuss, the better." },
			{ 96, "This can give a combination of prosperity and higher education. All desires will be fulfilled. They can excel in the fine arts easily. Women will be charmed easily by these people. This is a fortunate number." },
			{ 105, "This number can give fortunes, satisfactory environment, great fame and accumulation of wealth. It will beget good progeny.\r" },
			{ 7, "This name number represents high principles and virtuous qualities, which may flourish with divine grace. Unexpected changes will take place. Efforts will not produce the desired results." },
			{ 16, "This number signifies speedy progress and a sudden downfall. Ancient texts depict this number by a picture showing the shattering of a tall tower and a king’s head with his crown falling from its top. This truth was proved when Japan (16) fell prey to the nuclear bombs. The Japanese Emperor was considered to be God-incarnate and his people would not even look at him from an elevated place. Unfortunately, the Americans bombed Japan stripping the Emperor of his status and the consequences are well known even today. If your name number is 16, it is better to change it to some other lucky number. This number induces new imaginative thoughts which will be refected in the writings of the person.\r" },
			{ 25, "As this number gives good results in the end, it can be considered a good number. These people will undergo many trials in life. Every step in life will present problems and difficulties. The victory gained over such problems will give them selfconfidence, spiritual growth and the support of those around them. They are worldly-wise, known for clarity of thought and hence their actions will be well-planned. These people will establish ideals and standards for themselves and will adhere to them at all costs. Just as gold when cleansed of all impurities becomes shiny and precious, the lives of these people will end with respect and honour after many trials. (Note the life of Mahatma Gandhi who used to sign as M.K.Gandhi).\r" },
			{ 34, "In a way, this number can also be called lucky. This number will openly display the best qualities and capabilities of these persons in an attractive manner. It improves their stature but cannot be considered as fortunate. If the birth number is also a favourable one, they can earn enormous wealth quite easily. If not, earning money itself will become a problem. There will be some problem in their family life. Most of the men will either be addicted to women or wine. Their minds easily succumb to sensuous pleasures. This is the most fearful aspect of this number. (Be cautious about it)! Hence, they are advised to change this Name number to a more fortunate one.\r" },
			{ 43, "This is a strange number. Their whole life will be revolutionary. Whatever profession in which they are involved, this number produces new enemies. They have the tendency to resign from their jobs often. They will be constantly bringing out extreme ideas. They have extraordinary powers of imagination, speaking and writing as in the case of the other name numbers under 7. Their desires will be fulfilled at the end. This number, which is regarded as somewhat unlucky, indicates trials, great obstacles and revolutionary changes. They are sure to succeed in their ideals. (It is unlucky in the sense that they do not enjoy the luxuries or comforts of a peaceful life. Even their success will not yield them any personal gains). Their shrewdness increases with age, but they will encounter more criticism than praise for their capabilities and intelligence." },
			{ 52, "This number also signifies some type of revolutionary qualities. If the birth number is favourable it could bring world renown. They readily offer a solution to any problem and can charm many. If they are on the spiritual path, they can attain great powers and immense popularity. All their desires will be fulfilled. They can bring about a new era in the lives of others. (This power can also be found in number 25 to a certain extent). Their end will come abruptly, leaving their work unaccomplished. Although their personal life will be fraught with problems, they are sure to be famous and favoured by all.\r" },
			{ 61, "These people will quit a comfortable life and try new avenues according to their wishes. Successes and failures come in succession. If they can take care of their health, their later years will be quite fruitful helping them win prestigious posts. Though they may seem to be leading happy lives, in reality, they will be unhappy in their family lives. They spend much time in making new efforts and will achieve victory. They will earn great fame.\r" },
			{ 70, "People represented by this number are of extreme nature. Their comfortable life gets disturbed by circumstances. There are frequent disappointments, failures and problems. But the later years will be fruitful, successful and filled with blessings. This number does not possess much power. If their destiny number is favourable, these people will be happy during their final years. If not, their problems may drown them in misery" },
			{ 79, "People of this number tend to suffer very badly in the beginning of their lives due to many difficulties. Later, these people will rise quickly by their cleverness and sheer will power. They will settle down very comfortably and will succeed in their endeavours. They will have popular support, a comfortable life and will achieve enduring success. They become very fortunate with the passage of time and also become great personalities.\r" },
			{ 88, "This number gives spiritual progress. They are generous and compassionate. They are affectionate to all creatures and will become popular" },
			{ 97, "This number gives proficiency in the scriptures and fine arts. It also gives eminence in spiritual career. They will be successful in all their efforts and will be prosperous due to their astounding achievements in chosen fields." },
			{ 106, "There will be drastic changes in life. They will experience many problems during their middle age. Their later years will be comfortable. They get into big troubles that cannot be solved easily. This number is not a lucky one. Greed for worldly things will supersede the interest in seeking divine grace.\r" },
			{ 8, "This Name number gives you great success in spiritual life. If they have no control over pleasures, success will delayed. After a big struggle they may succeed. They will have to face unexpected dangers and difficult circumstances in life.\r" },
			{ 17, "This name number gives demonic qualities while pursuing the goals. It brings many problems and trials. However, they will persistently struggle without giving up. Failures will prompt them to struggle more actively. In the end they will be successful, and they get permanent prosperity and great fame. Some of them risk their lives to attain their goals and so achieve progress. The world can never forget them. This number can give mystic powers also." },
			{ 26, "This number denotes poverty in old age and fruitless efforts. Those who have this name number undergo great losses due to friends and partners. Circumstances lead them to failure and confusion. This number reduces one’s span of life and earns enemies who may even go to the extent of murdering them. Those with Name numbers 26 at frst begin their life with great principles and later change their minds and end up only in pursuit of money and status, (Based on their general qualities of number 8, they will be a little more fortunate in their later years)." },
			{ 35, "This number outwardly seems to be fortunate but the person will suffer losses because of friends and associates. These people will become very rich and popular but later lose all their money. Unexpected accidents may happen. This number helps in earning money through illegal means. Today’s friends will become tomorrow’s foes. They are very fickle- minded. Expenses will mount. This number would create severe incurable pain in the stomach. (For those with heart problems, this Name number will be a curative factor). Those with this name number must be very careful in their large business endeavours." },
			{ 44, "This number helps in earning money easily. Industries involving many people, like cinema theatres, printing presses, coal and iron mining, painting, making of furniture and sports goods, and organizing contests will help them earn a good income. Hiring out vehicles like buses, trucks and cars will also be rewarding. They can also run banks. One day everything may come to a halt. Only the owner will enjoy the profits in a proprietary concern. There is danger from fire and collapse of building. This number indicates that they may have to spend some time in prison. Their minds will go astray towards bad ways. Their lives may be comfortable outside prison. Generally, either they suffer from some disease or spend some time in prison, especially when the birth and destiny numbers are also not harmonious.\r" },
			{ 53, "They experience success and failure in the beginning of life itself. As they grow older, their lives will become steadier and they will become well-known. Though they are intelligent, they are bound to get into problems beyond their control. These people, who can convert failure into success, will perform good deeds and earn prestige and popularity. (This is an unstable number. Only if the birth number is favourable, will it bring desirable effects). They will be lucky in their old age.\r" },
			{ 62, "Generally it will give great fame, victories and a comfortable life. At times, great dangers and failures alternatively affect them. It could bring about serious enmity. It also causes misunderstanding among relatives. Family life will not be pleasant. Intellectual faculties will improve. These people can charm everyone easily. This name number helps in charming enemies too!" },
			{ 71, "This number which brings about obstacles initially will later shower prosperity. They will be good counsellors to others because of their intelligence. This number may be considered fortunate." },
			{ 80, "This number has strange mystic powers, but may lead to grave dangers if the date of birth is not favourable. Research in theology will be successful. Nature will change its course and help them. Though their lives are full of dangers and anxieties, they will be comfortable. Miracles will happen. It is a fortunate number." },
			{ 89, "This number, which also signifies benefits, brings problems initially. They have a helping tendency and they will acquire great riches like land, houses and jewellery. Women are attracted to them easily. Society will respect the women of this Name number. They have a combination of beauty and wealth. They lead fearless lives with the help of their great power of speech and action. Initially, fire accidents may occur in their lives." },
			{ 98, "Like the people under Number 71, these people are also intelligent. But their lives are filled with worries and desires. Though they are intelligent, they may not benefit from that quality. Difficulties and chronic diseases may affect them.\r" },
			{ 107, "This number will bring fame and success. If they are men, they will have problems due to women and if they are women, it will be from men. Even if they attain wealth, life will not be comfortable. However, they will be famous and influential.\r" },
			{ 9, "If the name comes under this number, it signifies wisdom and capability. It also denotes travel, struggles against odd situations and victory in the end. When they finally succeed, they will have a long life of luxury." },
			{ 18, "This name number, which signifies the decline of divinity, will bring in problems, procrastination in all matters, deviousness, and dangerous enemies. Their selfishness may induce them to indulge in antisocial activities. They follow evil ways consciously and become highly selfish. Life devoid of peace and rest will be the order of the day. This number signifies growth of personal desires at the cost of virtue. Desires will come to an end. Divine grace will get destroyed. (Hindu Epics record that Mahabharat war was fought for 18 days and 18 divisions fought the war in which the Pandavas had to kill their own elders and gurus in the battle. Although considered holy by the Hindus, it is the eighteen-chaptered Bhagavat Gita that spurred Arjuna into the war). This number, which denotes jealousy, malice and dangers due to fire and weapons, is not considered desirable." },
			{ 27, "This number signifies a clear mind and intelligence, unceasing hard work, accumulation of wealth, all round influence and positions of prominence and high rank. Especially in uniformed services like police, army, etc., they will rise very high in their ranks. This is as fortunate as number 24, which has been explained earlier in this book. They will be respected and treated as the best in their profession or service. They like to do social service and will be involved also in matters that would benefit them. This is a very fortunate number that brings spirituality and magical powers." },
			{ 36, "This number can raise even poor people to an enviable status and make them live in mansions. Only when these people go away from their place of birth to distant regions, do they attain success. They will travel extensively and occupy high positions. This number, though it appears very fortunate, will cause problems within the family. They may be surrounded by disloyal people.\r" },
			{ 45, "This is a lucky Name number. Even those who struggle at lower levels will be raised to a higher status and positions. They are good conversationalists and will be found in gatherings that involve entertaining people. These hard-working people will earn outstanding places in their career. They will achieve their goals at any cost. People would wonder if their life was a big show. Even though they may have nagging problems, they will retain their smile and will never allow anyone to know their problems. This number, which assures a comfortable life, fame and wealth, is a desirable one. Diseases will also be cured." },
			{ 54, "This number will give success step by step. Failures can also happen. They may begin their lives with prestige, reputation and prosperity. Stubbornness and thoughtless decisions will make them lose their name and fame. Greed is their worst enemy that could make them lose all their wealth if they are not careful. In the fag end of their lives, they may achieve success. Their life will be without freedom and they will be under the control of others.\r" },
			{ 63, "This is also a lucky number. However, if this comes as a Name number, it will lead one into wrong ways. The ancient texts describe this number as one related to thieves; so the less said, the better!\r" },
			{ 72, "This is the best of all numbers under 9. Although these people struggle in their early years, they later enjoy life with all comforts. A mind devoid of doubt will be filled with joy. The wealth acquired by these people will remain intact in their family for many future generations. Money keeps on coming continuously, without fail. (Businessmen should take note of this advantageous number). It will also bring repute. This number signifies permanent wealth." },
			{ 81, "This number signifies a fortunate life. This will give development, good position and wealth. If these people are not careful, their luck could change for the worse. They will have opportunities to become teachers." },
			{ 90, "As this number derives its full power from number 9, its people will go to any extent to get their desires fulfilled. Victory will be certain. They will become very wealthy and famous. For those who are interested in spiritual pursuits this number is not desirable.\r" },
			{ 99, "This Name number will lure its native to devious ways. Success will come along with enmity. This number signifies being attacked by enemies, and hence it is not a good number. (However they will be blessed with education, wealth and prosperity).\r" },
			{ 108, "This number can give high positions and success. Everything will happen according to their desire. As this number induces its people to make good efforts resulting in success, it is a very lucky number" }
		};
		if (dictionary.ContainsKey(num))
		{
			return dictionary[num];
		}
		return $"NO Prediction for name number {num}";
	}

	public static List<Avasta> PlanetAvasta(PlanetName planetName, Time time)
	{
		return new Avasta?[6]
		{
			IsPlanetInLajjitaAvasta(planetName, time) ? new Avasta?(Avasta.LajjitaShamed) : ((Avasta?)null),
			IsPlanetInGarvitaAvasta(planetName, time) ? new Avasta?(Avasta.GarvitaProud) : ((Avasta?)null),
			IsPlanetInKshuditaAvasta(planetName, time) ? new Avasta?(Avasta.KshuditaStarved) : ((Avasta?)null),
			IsPlanetInTrashitaAvasta(planetName, time) ? new Avasta?(Avasta.TrishitaThirst) : ((Avasta?)null),
			IsPlanetInMuditaAvasta(planetName, time) ? new Avasta?(Avasta.MuditaDelighted) : ((Avasta?)null),
			IsPlanetInKshobhitaAvasta(planetName, time) ? new Avasta?(Avasta.KshobitaAgitated) : ((Avasta?)null)
		}.OfType<Avasta>().ToList();
	}

	public static bool IsPlanetInLajjitaAvasta(PlanetName planetName, Time time)
	{
		bool num = IsPlanetInHouse(planetName, HouseName.House5, time);
		bool flag = IsAllPlanetInHouse(new List<PlanetName>
		{
			PlanetName.Rahu,
			PlanetName.Ketu,
			PlanetName.Saturn,
			PlanetName.Mars
		}, HouseName.House5, time);
		return num & flag;
	}

	public static bool IsPlanetInGarvitaAvasta(PlanetName planetName, Time time)
	{
		bool num = IsPlanetExalted(planetName, time);
		bool flag = IsPlanetInMoolatrikona(planetName, time);
		return num | flag;
	}

	public static bool IsPlanetInKshuditaAvasta(PlanetName planetName, Time time)
	{
		bool num = IsPlanetInEnemyHouse(planetName, time);
		bool flag = IsPlanetConjunctWithEnemyPlanets(planetName, time);
		bool flag2 = IsPlanetAspectedByEnemyPlanets(planetName, time);
		return num | flag | flag2;
	}

	public static bool IsPlanetInTrashitaAvasta(PlanetName planetName, Time time)
	{
		bool num = IsPlanetInWaterySign(planetName, time);
		bool flag = IsPlanetAspectedByEnemyPlanets(planetName, time);
		bool flag2 = !IsPlanetAspectedByBeneficPlanets(planetName, time);
		return num & flag & flag2;
	}

	public static bool IsPlanetInMuditaAvasta(PlanetName planetName, Time time)
	{
		bool num = IsPlanetInFriendHouse(planetName, time);
		bool flag = IsPlanetConjunctWithPlanet(planetName, PlanetName.Jupiter, time);
		bool num2 = IsPlanetConjunctWithFriendPlanets(planetName, time);
		bool flag2 = IsPlanetAspectedByFriendPlanets(planetName, time);
		bool flag3 = num2 | flag2;
		return num | flag | flag3;
	}

	public static bool IsPlanetInKshobhitaAvasta(PlanetName planetName, Time time)
	{
		bool num = IsPlanetConjunctWithPlanet(planetName, PlanetName.Sun, time);
		bool num2 = !IsPlanetAspectedByEnemyPlanets(planetName, time);
		bool flag = !IsPlanetAspectedByMaleficPlanets(planetName, time);
		bool flag2 = num2 | flag;
		return num & flag2;
	}

	public static List<Tuple<Time, Time, ZodiacName, PlanetName>> PlanetSignTransit(Time startTime, Time endTime, PlanetName planetName)
	{
		double precisionInHours = 0.05;
		List<Time> timeListFromRange = Time.GetTimeListFromRange(startTime, endTime, precisionInHours);
		List<Tuple<Time, Time, ZodiacName, PlanetName>> list = new List<Tuple<Time, Time, ZodiacName, PlanetName>>();
		ZodiacName zodiacName = PlanetZodiacSign(planetName, startTime).GetSignName();
		Time item = timeListFromRange[0];
		foreach (Time item2 in timeListFromRange)
		{
			ZodiacName signName = PlanetZodiacSign(planetName, item2).GetSignName();
			if (signName != zodiacName)
			{
				list.Add(new Tuple<Time, Time, ZodiacName, PlanetName>(item, item2, zodiacName, planetName));
				item = item2;
			}
			zodiacName = signName;
		}
		return list;
	}

	public static List<Tuple<Time, ConstellationName, ZodiacSign>> GetConstellationTransitStartTime(Time startTime, Time endTime, PlanetName planetName)
	{
		double precisionInHours = 0.05;
		List<Time> timeListFromRange = Time.GetTimeListFromRange(startTime, endTime, precisionInHours);
		List<Tuple<Time, ConstellationName, ZodiacSign>> list = new List<Tuple<Time, ConstellationName, ZodiacSign>>();
		ConstellationName constellationName = PlanetConstellation(planetName, startTime).GetConstellationName();
		foreach (Time item2 in timeListFromRange)
		{
			ConstellationName constellationName2 = PlanetConstellation(planetName, item2).GetConstellationName();
			ZodiacSign item = ZodiacSignAtLongitude(PlanetNirayanaLongitude(planetName, item2));
			if (constellationName2 != constellationName)
			{
				list.Add(new Tuple<Time, ConstellationName, ZodiacSign>(item2, constellationName2, item));
			}
			constellationName = constellationName2;
		}
		return list;
	}

	public static Dictionary<PlanetName, Constellation> AllPlanetConstellation(Time time)
	{
		return PlanetName.All9Planets.ToDictionary((PlanetName planet) => planet, (PlanetName planet) => PlanetConstellation(planet, time));
	}

	public static List<APIFunctionResult> AllTimeData(Time time)
	{
		return AutoCalculator.FindAndExecuteFunctions(MethodBase.GetCurrentMethod() as MethodInfo, time);
	}

	public static List<APIFunctionResult> AllPlanetData(PlanetName planetName, Time time)
	{
		return AutoCalculator.FindAndExecuteFunctions(MethodBase.GetCurrentMethod() as MethodInfo, planetName, time);
	}

	public static List<APIFunctionResult> AllHouseData(HouseName houseName, Time time)
	{
		return AutoCalculator.FindAndExecuteFunctions(MethodBase.GetCurrentMethod() as MethodInfo, houseName, time);
	}

	public static List<APIFunctionResult> AllPlanetHouseData(PlanetName planetName, HouseName houseName, Time time)
	{
		return AutoCalculator.FindAndExecuteFunctions(MethodBase.GetCurrentMethod() as MethodInfo, planetName, houseName, time);
	}

	public static List<APIFunctionResult> AllZodiacSignData(ZodiacName zodiacName, Time time)
	{
		return AutoCalculator.FindAndExecuteFunctions(MethodBase.GetCurrentMethod() as MethodInfo, zodiacName, time);
	}

	public static List<string> GhatakaChakra(Time time, Time birthTime)
	{
		Dictionary<ZodiacName, GhatakaRow> obj = new Dictionary<ZodiacName, GhatakaRow>
		{
			{
				ZodiacName.Aries,
				new GhatakaRow(ZodiacName.Aries, LunarDayGroup.Nanda, VedAstro.Library.DayOfWeek.Sunday, ConstellationName.Makha, ZodiacName.Aries, ZodiacName.Libra)
			},
			{
				ZodiacName.Taurus,
				new GhatakaRow(ZodiacName.Virgo, LunarDayGroup.Purna, VedAstro.Library.DayOfWeek.Saturday, ConstellationName.Hasta, ZodiacName.Taurus, ZodiacName.Scorpio)
			},
			{
				ZodiacName.Gemini,
				new GhatakaRow(ZodiacName.Aquarius, LunarDayGroup.Bhadra, VedAstro.Library.DayOfWeek.Monday, ConstellationName.Swathi, ZodiacName.Cancer, ZodiacName.Capricorn)
			},
			{
				ZodiacName.Cancer,
				new GhatakaRow(ZodiacName.Leo, LunarDayGroup.Bhadra, VedAstro.Library.DayOfWeek.Wednesday, ConstellationName.Anuradha, ZodiacName.Libra, ZodiacName.Aries)
			},
			{
				ZodiacName.Leo,
				new GhatakaRow(ZodiacName.Capricorn, LunarDayGroup.Jaya, VedAstro.Library.DayOfWeek.Saturday, ConstellationName.Moola, ZodiacName.Capricorn, ZodiacName.Cancer)
			},
			{
				ZodiacName.Virgo,
				new GhatakaRow(ZodiacName.Gemini, LunarDayGroup.Purna, VedAstro.Library.DayOfWeek.Saturday, ConstellationName.Sravana, ZodiacName.Pisces, ZodiacName.Virgo)
			},
			{
				ZodiacName.Libra,
				new GhatakaRow(ZodiacName.Sagittarius, LunarDayGroup.Rikta, VedAstro.Library.DayOfWeek.Thursday, ConstellationName.Satabhisha, ZodiacName.Virgo, ZodiacName.Pisces)
			},
			{
				ZodiacName.Scorpio,
				new GhatakaRow(ZodiacName.Taurus, LunarDayGroup.Nanda, VedAstro.Library.DayOfWeek.Friday, ConstellationName.Revathi, ZodiacName.Taurus, ZodiacName.Scorpio)
			},
			{
				ZodiacName.Sagittarius,
				new GhatakaRow(ZodiacName.Pisces, LunarDayGroup.Jaya, VedAstro.Library.DayOfWeek.Friday, ConstellationName.Aswini, ZodiacName.Sagittarius, ZodiacName.Gemini)
			},
			{
				ZodiacName.Capricorn,
				new GhatakaRow(ZodiacName.Leo, LunarDayGroup.Rikta, VedAstro.Library.DayOfWeek.Tuesday, ConstellationName.Rohini, ZodiacName.Aquarius, ZodiacName.Leo)
			},
			{
				ZodiacName.Aquarius,
				new GhatakaRow(ZodiacName.Sagittarius, LunarDayGroup.Jaya, VedAstro.Library.DayOfWeek.Thursday, ConstellationName.Aridra, ZodiacName.Gemini, ZodiacName.Sagittarius)
			},
			{
				ZodiacName.Pisces,
				new GhatakaRow(ZodiacName.Aquarius, LunarDayGroup.Purna, VedAstro.Library.DayOfWeek.Thursday, ConstellationName.Aslesha, ZodiacName.Leo, ZodiacName.Aquarius)
			}
		};
		ZodiacName key = MoonSignName(birthTime);
		ZodiacName zodiacName = MoonSignName(time);
		LunarDayGroup lunarDayGroup = LunarDay(time).GetLunarDayGroup();
		DayOfWeek dayOfWeek = DayOfWeek(time);
		ConstellationName constellationName = MoonConstellation(time).GetConstellationName();
		ZodiacName signName = HouseZodiacSign(HouseName.House1, time).GetSignName();
		List<string> list = new List<string>();
		if (obj.TryGetValue(key, out var value))
		{
			if (value.MoonSign == zodiacName)
			{
				list.Add("MoonSign");
			}
			if (value.TithiGroup == lunarDayGroup)
			{
				list.Add("TithiGroup");
			}
			if (value.WeekDay == dayOfWeek)
			{
				list.Add("WeekDay");
			}
			if (value.MoonConstellation == constellationName)
			{
				list.Add("MoonConstellation");
			}
			if (value.LagnaSameSex == signName)
			{
				list.Add("LagnaSameSex");
			}
		}
		return list;
	}

	public static double DayDurationHours(Time time)
	{
		Time time2 = SunsetTime(time);
		Time time3 = SunriseTime(time);
		return time2.Subtract(time3).TotalHours;
	}

	public static bool IsNightBirth(Time birthTime)
	{
		Time time = SunsetTime(birthTime);
		Time time2 = SunriseTime(birthTime.AddHours(23.0));
		bool num = birthTime >= time;
		bool flag = birthTime <= time2;
		return num & flag;
	}

	public static bool IsDayBirth(Time birthTime)
	{
		Time time = SunriseTime(birthTime);
		Time time2 = SunsetTime(birthTime);
		bool num = birthTime >= time;
		bool flag = birthTime <= time2;
		return num & flag;
	}

	public static Person ParseJHDFiles(string personName, string rawTextData)
	{
		string[] array = rawTextData.Trim().Split('\n');
		double num = double.Parse(array[3]);
		int num2 = (int)num;
		int minute = (int)Math.Round((num - (double)num2) * 100.0);
		int month = int.Parse(array[0]);
		int day = int.Parse(array[1]);
		int year = int.Parse(array[2]);
		TimeSpan offset = ConvertRawTimezoneToTimeSpan(array[4]);
		DateTimeOffset stdDateTime = new DateTimeOffset(year, month, day, num2, minute, 0, 0, offset);
		stdDateTime.ToString("HH:mm dd/MM/yyyy zzz");
		string name = Regex.Replace(array[12].Trim() + ", " + array[13].Trim(), "[^a-zA-Z0-9 ,]", "");
		double longitude = ConvertRawLongitude(array[5]);
		double latitude = double.Parse(array[6]);
		GeoLocation geoLocation = new GeoLocation(name, longitude, latitude);
		Time birthTime = new Time(stdDateTime, geoLocation);
		Gender gender = ((int.Parse(array[17].Trim()) == 1) ? Gender.Male : Gender.Female);
		return new Person(personName, birthTime, gender);
		static double ConvertRawLongitude(string rawLongitude)
		{
			if (double.TryParse(rawLongitude.Trim(), out var result))
			{
				return (result < 0.0) ? Math.Abs(result) : (0.0 - Math.Abs(result));
			}
			throw new FormatException("Invalid format for longitude.");
		}
		static TimeSpan ConvertRawTimezoneToTimeSpan(string input)
		{
			string[] array2 = input.Replace("/r", "").Split('.');
			int num3 = int.Parse(array2[0]);
			int minutes = int.Parse(array2[1].Substring(0, 2));
			num3 = -num3;
			return new TimeSpan(num3, minutes, 0);
		}
	}

	public static List<HouseName> HousesOwnedByPlanetKP(PlanetName inputPlanet, Time time, int horaryNumber = 0)
	{
		List<ZodiacName> list = ZodiacSignsOwnedByPlanet(inputPlanet);
		List<HouseName> list2 = new List<HouseName>();
		Dictionary<HouseName, ZodiacSign> source = _AllHouseZodiacSignKP(time, horaryNumber);
		foreach (ZodiacName zodiacName in list)
		{
			List<HouseName> collection = (from pair in source
				where pair.Value.GetSignName() == zodiacName
				select pair.Key).ToList();
			list2.AddRange(collection);
		}
		return list2;
		static Dictionary<HouseName, ZodiacSign> _AllHouseZodiacSignKP(Time time2, int horaryNumber2 = 0)
		{
			Dictionary<HouseName, ZodiacSign> dictionary = new Dictionary<HouseName, ZodiacSign>();
			foreach (HouseName allHouse in House.AllHouses)
			{
				ZodiacSign value = HouseZodiacSignKP(allHouse, time2, horaryNumber2);
				dictionary.Add(allHouse, value);
			}
			return dictionary;
		}
	}

	public static List<HouseName> HousesOwnedByPlanet(PlanetName inputPlanet, Time time)
	{
		List<ZodiacName> list = ZodiacSignsOwnedByPlanet(inputPlanet);
		List<HouseName> list2 = new List<HouseName>();
		Dictionary<HouseName, ZodiacSign> source = AllHouseSign(time);
		foreach (ZodiacName zodiacName in list)
		{
			List<HouseName> collection = (from pair in source
				where pair.Value.GetSignName() == zodiacName
				select pair.Key).ToList();
			list2.AddRange(collection);
		}
		return list2;
	}

	public static HouseName HouseFromSignName(ZodiacName zodiacName, Time inputTime)
	{
		return (from e in AllHouseSign(inputTime)
			where e.Value.GetSignName() == zodiacName
			select e.Key).FirstOrDefault();
	}

	public static async Task<List<JObject>> HoroscopePredictionAlpacaTemplateLoRA(Time birthTime)
	{
		List<JObject> list = new List<JObject>();
		foreach (HoroscopeData row in HoroscopeDataListStatic.Rows)
		{
			JObject item = new JObject
			{
				["instruction"] = row.Name.ToString(),
				["input"] = "",
				["output"] = row.Description
			};
			list.Add(item);
		}
		return list;
	}

	public static List<HoroscopePrediction> HoroscopePredictions(Time birthTime, EventTag filterTag = EventTag.Empty)
	{
		return Tools.GetHoroscopePrediction(birthTime, filterTag);
	}

	public static List<string> HoroscopePredictionNames(Time birthTime)
	{
		return (from x in Tools.GetHoroscopePrediction(birthTime)
			select x.Name.ToString()).ToList();
	}

	public static string LocalMeanTime(Time time)
	{
		return time.GetLmtDateTimeOffsetText();
	}

	public static string LocalStandardTime(Time time)
	{
		return time.GetStdDateTimeOffsetText();
	}

	public static PlanetName LordOfConstellation(ConstellationName constellation)
	{
		switch (constellation)
		{
		case ConstellationName.Aswini:
		case ConstellationName.Makha:
		case ConstellationName.Moola:
			return PlanetName.Ketu;
		case ConstellationName.Bharani:
		case ConstellationName.Pubba:
		case ConstellationName.Poorvashada:
			return PlanetName.Venus;
		case ConstellationName.Krithika:
		case ConstellationName.Uttara:
		case ConstellationName.Uttarashada:
			return PlanetName.Sun;
		case ConstellationName.Rohini:
		case ConstellationName.Hasta:
		case ConstellationName.Sravana:
			return PlanetName.Moon;
		case ConstellationName.Mrigasira:
		case ConstellationName.Chitta:
		case ConstellationName.Dhanishta:
			return PlanetName.Mars;
		case ConstellationName.Aridra:
		case ConstellationName.Swathi:
		case ConstellationName.Satabhisha:
			return PlanetName.Rahu;
		case ConstellationName.Punarvasu:
		case ConstellationName.Vishhaka:
		case ConstellationName.Poorvabhadra:
			return PlanetName.Jupiter;
		case ConstellationName.Pushyami:
		case ConstellationName.Anuradha:
		case ConstellationName.Uttarabhadra:
			return PlanetName.Saturn;
		case ConstellationName.Aslesha:
		case ConstellationName.Jyesta:
		case ConstellationName.Revathi:
			return PlanetName.Mercury;
		default:
			return PlanetName.Empty;
		}
	}

	public static PlanetName LordOfConstellationKP(HouseName inputHouse, Time time, int horaryNumber = 0, double rotateDegrees = 0.0)
	{
		return LordOfConstellation(ConstellationAtLongitude(Krishnamurti.AllHouseCuspLongitudes(time, horaryNumber, rotateDegrees)[inputHouse]).GetConstellationName());
	}

	public static int FortunaPoint(ZodiacName ascZodiacSignName, Time time)
	{
		_ = AllHouseMiddleLongitudes(time)[0].GetBeginLongitude().TotalDegrees;
		double totalDegrees = AllHouseMiddleLongitudes(time)[0].GetMiddleLongitude().TotalDegrees;
		double totalDegrees2 = PlanetNirayanaLongitude(PlanetName.Moon, time).TotalDegrees;
		double totalDegrees3 = PlanetNirayanaLongitude(PlanetName.Sun, time).TotalDegrees;
		double num = 0.0;
		double num2 = totalDegrees2 - totalDegrees3;
		if (num2 < 0.0)
		{
			num2 += 360.0;
		}
		num = totalDegrees + num2;
		if (num >= 360.0)
		{
			num -= 360.0;
		}
		ZodiacName signName = ZodiacSignAtLongitude(Angle.FromDegrees(num)).GetSignName();
		return CountFromSignToSign(ascZodiacSignName, signName);
	}

	public static int DestinyPoint(Time time, ZodiacName ascZodiacSignName)
	{
		double totalDegrees = PlanetNirayanaLongitude(PlanetName.Rahu, time).TotalDegrees;
		double num = PlanetNirayanaLongitude(PlanetName.Moon, time).TotalDegrees - totalDegrees;
		if (num < 0.0)
		{
			num += 360.0;
		}
		double num2 = num / 2.0;
		double num3 = totalDegrees + num2;
		if (num3 >= 360.0)
		{
			num3 -= 360.0;
		}
		ZodiacName signName = ZodiacSignAtLongitude(Angle.FromDegrees(num3)).GetSignName();
		return CountFromSignToSign(ascZodiacSignName, signName);
	}

	public static string YoniKutaAnimalFromPerson(Person person)
	{
		ConstellationAnimal constellationAnimal = YoniKutaAnimalFromConstellation(MoonConstellation(person.BirthTime).GetConstellationName());
		return "" + constellationAnimal.ToString();
	}

	public static ConstellationAnimal YoniKutaAnimalFromConstellation(ConstellationName sign)
	{
		return sign switch
		{
			ConstellationName.Aswini => new ConstellationAnimal("Male", AnimalName.Horse), 
			ConstellationName.Satabhisha => new ConstellationAnimal("Female", AnimalName.Horse), 
			ConstellationName.Bharani => new ConstellationAnimal("Male", AnimalName.Elephant), 
			ConstellationName.Revathi => new ConstellationAnimal("Female", AnimalName.Elephant), 
			ConstellationName.Pushyami => new ConstellationAnimal("Male", AnimalName.Sheep), 
			ConstellationName.Krithika => new ConstellationAnimal("Female", AnimalName.Sheep), 
			ConstellationName.Rohini => new ConstellationAnimal("Male", AnimalName.Serpent), 
			ConstellationName.Mrigasira => new ConstellationAnimal("Female", AnimalName.Serpent), 
			ConstellationName.Moola => new ConstellationAnimal("Male", AnimalName.Dog), 
			ConstellationName.Aridra => new ConstellationAnimal("Female", AnimalName.Dog), 
			ConstellationName.Aslesha => new ConstellationAnimal("Male", AnimalName.Cat), 
			ConstellationName.Punarvasu => new ConstellationAnimal("Female", AnimalName.Cat), 
			ConstellationName.Makha => new ConstellationAnimal("Male", AnimalName.Rat), 
			ConstellationName.Pubba => new ConstellationAnimal("Female", AnimalName.Rat), 
			ConstellationName.Uttara => new ConstellationAnimal("Male", AnimalName.Cow), 
			ConstellationName.Uttarabhadra => new ConstellationAnimal("Female", AnimalName.Cow), 
			ConstellationName.Swathi => new ConstellationAnimal("Male", AnimalName.Buffalo), 
			ConstellationName.Hasta => new ConstellationAnimal("Female", AnimalName.Buffalo), 
			ConstellationName.Vishhaka => new ConstellationAnimal("Male", AnimalName.Tiger), 
			ConstellationName.Chitta => new ConstellationAnimal("Female", AnimalName.Tiger), 
			ConstellationName.Jyesta => new ConstellationAnimal("Male", AnimalName.Hare), 
			ConstellationName.Anuradha => new ConstellationAnimal("Female", AnimalName.Hare), 
			ConstellationName.Poorvashada => new ConstellationAnimal("Male", AnimalName.Monkey), 
			ConstellationName.Sravana => new ConstellationAnimal("Female", AnimalName.Monkey), 
			ConstellationName.Poorvabhadra => new ConstellationAnimal("Male", AnimalName.Lion), 
			ConstellationName.Dhanishta => new ConstellationAnimal("Female", AnimalName.Lion), 
			ConstellationName.Uttarashada => new ConstellationAnimal("Male", AnimalName.Mongoose), 
			_ => throw new Exception("Yoni Kuta Animal Not Found!"), 
		};
	}

	public static async Task<byte[]> SkyChartGIF(Time time)
	{
		return await SkyChartFactory.GenerateChartGif(time, 750.0, 230.0);
	}

	public static async Task<string> SkyChart(Time time)
	{
		return await SkyChartFactory.GenerateChart(time, 750.0, 230.0);
	}

	public static string SouthIndianChart(Time time, ChartType chartType = ChartType.Rasi)
	{
		return new SouthChartFactory(time, 1000.0, 1000.0, chartType).SVGChart;
	}

	public static string NorthIndianChart(Time time)
	{
		return NorthChartFactory.GenerateChart(time, 1000.0, 1000.0);
	}

	public static bool IsPlanetInWaterySign(PlanetName planetName, Time time)
	{
		return IsWaterSign(PlanetZodiacSign(planetName, time).GetSignName());
	}

	public static double ResidentialStrength(PlanetName planetName, Time time)
	{
		return 0.0;
	}

	public static Angle TimeToLongitude(TimeSpan time)
	{
		return Angle.FromDegrees(time.TotalHours * 15.0);
	}

	public static double TimeToEphemerisTime(Time time)
	{
		return CacheManager.GetCache(new CacheKey("TimeToEphemerisTime", time, Ayanamsa), _timeToEphemerisTime);
		double _timeToEphemerisTime()
		{
			SwissEph swissEph = new SwissEph();
			int gregflag = 1;
			DateTimeOffset dateTimeOffset = LmtToUtc(time);
			int year = dateTimeOffset.Year;
			int month = dateTimeOffset.Month;
			int day = dateTimeOffset.Day;
			double totalHours = dateTimeOffset.TimeOfDay.TotalHours;
			double num = swissEph.swe_julday(year, month, day, totalHours, gregflag);
			return num + swissEph.swe_deltat(num);
		}
	}

	public static LunarDay LunarDay(Time time)
	{
		Angle angle = PlanetNirayanaLongitude(PlanetName.Sun, time);
		Angle angle2 = PlanetNirayanaLongitude(PlanetName.Moon, time);
		double a = ((!(angle2.TotalDegrees > angle.TotalDegrees)) ? ((angle2 + Angle.Degrees360 - angle).TotalDegrees / 12.0) : ((angle2 - angle).TotalDegrees / 12.0));
		int lunarDateNumber = (int)Math.Ceiling(a);
		return new LunarDay(lunarDateNumber);
	}

	public static Constellation MoonConstellation(Time time)
	{
		return PlanetConstellation(PlanetName.Moon, time);
	}

	public static Constellation PlanetConstellation(PlanetName planet, Time time)
	{
		return ConstellationAtLongitude(PlanetNirayanaLongitude(planet, time));
	}

	public static Tarabala Tarabala(Time time, Person person)
	{
		int constellationNumber = MoonConstellation(time).GetConstellationNumber();
		int constellationNumber2 = MoonConstellation(person.BirthTime).GetConstellationNumber();
		int num = 0;
		if (constellationNumber2 > constellationNumber)
		{
			int num2 = 27 - constellationNumber2 + 1;
			num = constellationNumber + num2;
		}
		else if (constellationNumber2 == constellationNumber)
		{
			num = 1;
		}
		else if (constellationNumber2 < constellationNumber)
		{
			num = constellationNumber - constellationNumber2 + 1;
		}
		int cycle = (int)Math.Ceiling((double)num / 9.0);
		if (num > 9)
		{
			num %= 9;
			if (num == 0)
			{
				num = 9;
			}
		}
		return new Tarabala(num, cycle);
	}

	public static int Chandrabala(Time time, Person person)
	{
		int result = 0;
		int num = (int)MoonSignName(time);
		int num2 = (int)MoonSignName(person.BirthTime);
		if (num2 > num)
		{
			int num3 = 12 - num2 + 1;
			result = num + num3;
		}
		else if (num2 == num)
		{
			result = 1;
		}
		else if (num2 < num)
		{
			result = num - num2 + 1;
		}
		return result;
	}

	public static ZodiacName MoonSignName(Time time)
	{
		return PlanetZodiacSign(PlanetName.Moon, time).GetSignName();
	}

	public static ZodiacName LagnaSignName(Time time)
	{
		return HouseSignName(HouseName.House1, time);
	}

	public static NithyaYoga NithyaYoga(Time time)
	{
		Angle angle = PlanetNirayanaLongitude(PlanetName.Sun, time);
		Angle angle2 = PlanetNirayanaLongitude(PlanetName.Moon, time);
		return VedAstro.Library.NithyaYoga.FromNumber(Math.Ceiling((angle + angle2).Expunge360().TotalMinutes / 800.0));
	}

	public static Karana Karana(Time time)
	{
		Karana? karana = null;
		Angle angle = PlanetNirayanaLongitude(PlanetName.Sun, time);
		Angle angle2 = PlanetNirayanaLongitude(PlanetName.Moon, time);
		double num = ((!(angle2.TotalDegrees > angle.TotalDegrees)) ? ((angle2 + Angle.Degrees360 - angle).TotalDegrees / 12.0) : ((angle2 - angle).TotalDegrees / 12.0));
		int num2 = (int)Math.Ceiling(num);
		double num3 = num - Math.Floor(num);
		switch (num2)
		{
		case 1:
			karana = ((num3 <= 0.5) ? VedAstro.Library.Karana.Kimstughna : VedAstro.Library.Karana.Bava);
			break;
		case 2:
		case 9:
		case 16:
		case 23:
			karana = ((num3 <= 0.5) ? VedAstro.Library.Karana.Balava : VedAstro.Library.Karana.Kaulava);
			break;
		case 3:
		case 10:
		case 17:
		case 24:
			karana = ((num3 <= 0.5) ? VedAstro.Library.Karana.Taitula : VedAstro.Library.Karana.Garija);
			break;
		case 4:
		case 11:
		case 18:
		case 25:
			karana = ((num3 <= 0.5) ? VedAstro.Library.Karana.Vanija : VedAstro.Library.Karana.Visti);
			break;
		case 5:
		case 12:
		case 19:
		case 26:
			karana = ((!(num3 <= 0.5)) ? VedAstro.Library.Karana.Balava : VedAstro.Library.Karana.Bava);
			break;
		case 6:
		case 13:
		case 20:
		case 27:
			karana = ((num3 <= 0.5) ? VedAstro.Library.Karana.Kaulava : VedAstro.Library.Karana.Taitula);
			break;
		case 7:
		case 14:
		case 21:
		case 28:
			karana = ((num3 <= 0.5) ? VedAstro.Library.Karana.Garija : VedAstro.Library.Karana.Vanija);
			break;
		case 8:
		case 15:
		case 22:
			karana = ((num3 <= 0.5) ? VedAstro.Library.Karana.Visti : VedAstro.Library.Karana.Bava);
			break;
		case 29:
			karana = ((num3 <= 0.5) ? VedAstro.Library.Karana.Visti : VedAstro.Library.Karana.Sakuna);
			break;
		case 30:
			karana = ((num3 <= 0.5) ? VedAstro.Library.Karana.Chatushpada : VedAstro.Library.Karana.Naga);
			break;
		}
		if (!karana.HasValue)
		{
			throw new Exception("Karana could not be found!");
		}
		return karana.Value;
	}

	public static ZodiacSign SunSign(Time time)
	{
		return PlanetZodiacSign(PlanetName.Sun, time);
	}

	public static Time TimeSunEnteredCurrentSign(Time time)
	{
		return CacheManager.GetCache(new CacheKey("TimeSunEnteredCurrentSign", time, Ayanamsa), _timeSunEnteredCurrentSign);
		Time _timeSunEnteredCurrentSign()
		{
			double minute = TimePreset.Minute3;
			double num = 96.0;
			Time time2 = time;
			Time time3 = time;
			ZodiacSign zodiacSign = SunSign(time);
			while (true)
			{
				ZodiacSign zodiacSign2 = SunSign(time2);
				if (zodiacSign2.GetSignName() == zodiacSign.GetSignName())
				{
					if (zodiacSign2.GetDegreesInSign().TotalDegrees < 0.001)
					{
						break;
					}
					time3 = time2;
					time2 = time2.SubtractHours(num);
				}
				else
				{
					time2 = time3;
					if (num <= minute)
					{
						break;
					}
					num /= 2.0;
				}
			}
			return time2;
		}
	}

	public static Time TimeSunLeavesCurrentSign(Time time)
	{
		return CacheManager.GetCache(new CacheKey("TimeSunLeavesCurrentSign", time, Ayanamsa), _getTimeSunLeavesCurrentSign);
		Time _getTimeSunLeavesCurrentSign()
		{
			double minute = TimePreset.Minute3;
			double num = 96.0;
			Time time2 = time;
			Time time3 = time;
			ZodiacSign zodiacSign = SunSign(time);
			while (true)
			{
				ZodiacSign zodiacSign2 = SunSign(time2);
				if (zodiacSign2.GetSignName() == zodiacSign.GetSignName())
				{
					if (zodiacSign2.GetDegreesInSign().TotalDegrees > 29.999)
					{
						break;
					}
					time3 = time2;
					time2 = time2.AddHours(num);
				}
				else
				{
					time2 = time3;
					if (num <= minute)
					{
						break;
					}
					num /= 2.0;
				}
			}
			return time2;
		}
	}

	public static double TimeToJulianDay(Time time)
	{
		DateTimeOffset dateTimeOffset = time.GetLmtDateTimeOffset().ToUniversalTime();
		return new SwissEph().swe_julday(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, dateTimeOffset.TimeOfDay.TotalHours, 1);
	}

	public static List<House> AllHouseMiddleLongitudes(Time time)
	{
		return CacheManager.GetCache(new CacheKey("AllHouseMiddleLongitudes", time, Ayanamsa), _getHouses);
		List<House> _getHouses()
		{
			double[] house1And10Longitudes = GetHouse1And10Longitudes(time);
			Angle angle = Angle.FromDegrees(house1And10Longitudes[1]);
			Angle angle2 = Angle.FromDegrees(house1And10Longitudes[10]);
			Angle angle3 = AyanamsaDegree(time);
			Angle angle4 = angle - angle3;
			Angle angle5 = angle2 - angle3;
			Angle angle6 = angle4 + Angle.Degrees180;
			Angle angle7 = angle5 + Angle.Degrees180;
			angle6 = angle6.Expunge360();
			Angle angle8 = angle7.Expunge360();
			Angle angle9 = angle4 + Angle.FromDegrees(15.0);
			Angle angle10 = angle8 + Angle.FromDegrees(15.0);
			Angle angle11 = angle6 + Angle.FromDegrees(15.0);
			Angle angle12 = angle5 + Angle.FromDegrees(15.0);
			Angle angle13 = ((!(angle10 < angle9)) ? (angle10 - angle9) : (angle10 + Angle.Degrees360 - angle9));
			Angle angle14 = ((!(angle11 < angle10)) ? (angle11 - angle10) : (angle11 + Angle.Degrees360 - angle10));
			Angle angle15 = ((!(angle12 < angle11)) ? (angle12 - angle11) : (angle12 + Angle.Degrees360 - angle11));
			Angle angle16 = ((!(angle9 < angle12)) ? (angle9 - angle12) : (angle9 + Angle.Degrees360 - angle12));
			Angle angle17 = angle9 + angle13.Divide(3.0);
			angle17 = angle17.Expunge360();
			Angle angle18 = angle17 + angle13.Divide(3.0);
			angle18 = angle18.Expunge360();
			Angle angle19 = angle10 + angle14.Divide(3.0);
			angle19 = angle19.Expunge360();
			Angle angle20 = angle19 + angle14.Divide(3.0);
			angle20 = angle20.Expunge360();
			Angle angle21 = angle11 + angle15.Divide(3.0);
			angle21 = angle21.Expunge360();
			Angle angle22 = angle21 + angle15.Divide(3.0);
			angle22 = angle22.Expunge360();
			Angle angle23 = angle12 + angle16.Divide(3.0);
			angle23 = angle23.Expunge360();
			Angle angle24 = angle23 + angle16.Divide(3.0);
			angle24 = angle24.Expunge360();
			Angle beginLongitude;
			Angle endLongitude = (beginLongitude = HouseJunctionPoint(angle9, angle17));
			Angle beginLongitude2;
			Angle endLongitude2 = (beginLongitude2 = HouseJunctionPoint(angle17, angle18));
			Angle beginLongitude3;
			Angle endLongitude3 = (beginLongitude3 = HouseJunctionPoint(angle18, angle10));
			Angle beginLongitude4;
			Angle endLongitude4 = (beginLongitude4 = HouseJunctionPoint(angle10, angle19));
			Angle beginLongitude5;
			Angle endLongitude5 = (beginLongitude5 = HouseJunctionPoint(angle19, angle20));
			Angle beginLongitude6;
			Angle endLongitude6 = (beginLongitude6 = HouseJunctionPoint(angle20, angle11));
			Angle beginLongitude7;
			Angle endLongitude7 = (beginLongitude7 = HouseJunctionPoint(angle11, angle21));
			Angle beginLongitude8;
			Angle endLongitude8 = (beginLongitude8 = HouseJunctionPoint(angle21, angle22));
			Angle beginLongitude9;
			Angle endLongitude9 = (beginLongitude9 = HouseJunctionPoint(angle22, angle12));
			Angle beginLongitude10;
			Angle endLongitude10 = (beginLongitude10 = HouseJunctionPoint(angle12, angle23));
			Angle beginLongitude11;
			Angle endLongitude11 = (beginLongitude11 = HouseJunctionPoint(angle23, angle24));
			Angle beginLongitude12;
			Angle endLongitude12 = (beginLongitude12 = HouseJunctionPoint(angle24, angle9));
			return new List<House>
			{
				new House(HouseName.House1, beginLongitude12, angle9, endLongitude),
				new House(HouseName.House2, beginLongitude, angle17, endLongitude2),
				new House(HouseName.House3, beginLongitude2, angle18, endLongitude3),
				new House(HouseName.House4, beginLongitude3, angle10, endLongitude4),
				new House(HouseName.House5, beginLongitude4, angle19, endLongitude5),
				new House(HouseName.House6, beginLongitude5, angle20, endLongitude6),
				new House(HouseName.House7, beginLongitude6, angle11, endLongitude7),
				new House(HouseName.House8, beginLongitude7, angle21, endLongitude8),
				new House(HouseName.House9, beginLongitude8, angle22, endLongitude9),
				new House(HouseName.House10, beginLongitude9, angle12, endLongitude10),
				new House(HouseName.House11, beginLongitude10, angle23, endLongitude11),
				new House(HouseName.House12, beginLongitude11, angle24, endLongitude12)
			};
		}
	}

	public static double ConvertLmtToJulian(Time time)
	{
		return CacheManager.GetCache(new CacheKey("ConvertLmtToJulian", time, Ayanamsa), _convertLmtToJulian);
		double _convertLmtToJulian()
		{
			DateTimeOffset lmtDateTimeOffset = time.GetLmtDateTimeOffset();
			int year = lmtDateTimeOffset.Year;
			int month = lmtDateTimeOffset.Month;
			int day = lmtDateTimeOffset.Day;
			double totalHours = lmtDateTimeOffset.TimeOfDay.TotalHours;
			int gregflag = 1;
			return new SwissEph().swe_julday(year, month, day, totalHours, gregflag);
		}
	}

	public static List<PlanetName> PlanetsInConjuction(PlanetName inputPlanet, Time time)
	{
		Angle angle = new Angle(8.0, 0.0, 0L);
		Angle planet = PlanetNirayanaLongitude(inputPlanet, time);
		List<PlanetLongitude> list = AllPlanetLongitude(time);
		List<PlanetName> list2 = new List<PlanetName>();
		foreach (PlanetLongitude item in list)
		{
			if (!(item.GetPlanetName() == inputPlanet))
			{
				Angle angle2 = DistanceBetweenPlanets(planet, item.GetPlanetLongitude());
				if (angle2 >= Angle.Zero && angle2 <= angle)
				{
					list2.Add(item.GetPlanetName());
				}
			}
		}
		return list2;
	}

	public static Angle DistanceBetweenPlanets(PlanetName planet1, PlanetName planet2, Time time)
	{
		Angle angle = PlanetNirayanaLongitude(planet1, time);
		return Angle.FromDegrees(planetDistance(len2: PlanetNirayanaLongitude(planet2, time).TotalDegrees, len1: angle.TotalDegrees));
		static double a_red(double x, double a)
		{
			return x - Math.Floor(x / a) * a;
		}
		static double planetDistance(double len1, double len2)
		{
			double num = red_deg(Math.Abs(len2 - len1));
			if (num > 180.0)
			{
				return 360.0 - num;
			}
			return num;
		}
		static double red_deg(double input)
		{
			return a_red(input, 360.0);
		}
	}

	public static Angle DistanceBetweenPlanets(Angle planet1, Angle planet2)
	{
		return Angle.FromDegrees(planetDistance(planet1.TotalDegrees, planet2.TotalDegrees));
		static double a_red(double x, double a)
		{
			return x - Math.Floor(x / a) * a;
		}
		static double planetDistance(double len1, double len2)
		{
			double num = red_deg(Math.Abs(len2 - len1));
			if (num > 180.0)
			{
				return 360.0 - num;
			}
			return num;
		}
		static double red_deg(double input)
		{
			return a_red(input, 360.0);
		}
	}

	public static List<PlanetName> PlanetsInHouse(HouseName houseNumber, Time time)
	{
		List<PlanetName> list = new List<PlanetName>();
		House house = AllHouseMiddleLongitudes(time).Find((House h) => h.GetHouseName() == houseNumber);
		foreach (PlanetLongitude item in AllPlanetLongitude(time))
		{
			if (house.IsLongitudeInHouseRange(item.GetPlanetLongitude()))
			{
				list.Add(item.GetPlanetName());
			}
		}
		return list;
	}

	public static List<PlanetName> PlanetsInHouseKP(HouseName inputHouse, Time time, int horaryNumber = 0, double rotateDegrees = 0.0)
	{
		Dictionary<HouseName, Angle> allHouseCuspsRaw = Krishnamurti.AllHouseCuspLongitudes(time, horaryNumber, rotateDegrees);
		return PlanetName.All9Planets.Where(delegate(PlanetName planet)
		{
			Angle planetNirayanaDegrees = PlanetNirayanaLongitude(planet, time);
			return IsPlanetInHouseKP(allHouseCuspsRaw, planetNirayanaDegrees, inputHouse);
		}).ToList();
	}

	public static List<PlanetName> PlanetsInHouseBasedOnSign(HouseName houseNumber, Time time)
	{
		return PlanetsInSign(HouseSignName(houseNumber, time), time);
	}

	public static List<PlanetName> PlanetsInSign(ZodiacName signName, Time time)
	{
		List<PlanetName> list = new List<PlanetName>();
		foreach (PlanetName all9Planet in PlanetName.All9Planets)
		{
			if (PlanetZodiacSign(all9Planet, time).GetSignName() == signName)
			{
				list.Add(all9Planet);
			}
		}
		return list;
	}

	public static List<PlanetLongitude> AllPlanetLongitude(Time time)
	{
		Angle planetLongitude = PlanetNirayanaLongitude(PlanetName.Sun, time);
		PlanetLongitude item = new PlanetLongitude(PlanetName.Sun, planetLongitude);
		Angle planetLongitude2 = PlanetNirayanaLongitude(PlanetName.Moon, time);
		PlanetLongitude item2 = new PlanetLongitude(PlanetName.Moon, planetLongitude2);
		Angle planetLongitude3 = PlanetNirayanaLongitude(PlanetName.Mars, time);
		PlanetLongitude item3 = new PlanetLongitude(PlanetName.Mars, planetLongitude3);
		Angle planetLongitude4 = PlanetNirayanaLongitude(PlanetName.Mercury, time);
		PlanetLongitude item4 = new PlanetLongitude(PlanetName.Mercury, planetLongitude4);
		Angle planetLongitude5 = PlanetNirayanaLongitude(PlanetName.Jupiter, time);
		PlanetLongitude item5 = new PlanetLongitude(PlanetName.Jupiter, planetLongitude5);
		Angle planetLongitude6 = PlanetNirayanaLongitude(PlanetName.Venus, time);
		PlanetLongitude item6 = new PlanetLongitude(PlanetName.Venus, planetLongitude6);
		Angle planetLongitude7 = PlanetNirayanaLongitude(PlanetName.Saturn, time);
		PlanetLongitude item7 = new PlanetLongitude(PlanetName.Saturn, planetLongitude7);
		Angle planetLongitude8 = PlanetNirayanaLongitude(PlanetName.Rahu, time);
		PlanetLongitude item8 = new PlanetLongitude(PlanetName.Rahu, planetLongitude8);
		Angle planetLongitude9 = PlanetNirayanaLongitude(PlanetName.Ketu, time);
		PlanetLongitude item9 = new PlanetLongitude(PlanetName.Ketu, planetLongitude9);
		return new List<PlanetLongitude> { item, item2, item3, item4, item5, item6, item7, item9, item8 };
	}

	public static List<PlanetLongitude> AllPlanetFixedLongitude(Time time)
	{
		Angle planetLongitude = PlanetSayanaLongitude(PlanetName.Sun, time);
		PlanetLongitude item = new PlanetLongitude(PlanetName.Sun, planetLongitude);
		Angle planetLongitude2 = PlanetSayanaLongitude(PlanetName.Moon, time);
		PlanetLongitude item2 = new PlanetLongitude(PlanetName.Moon, planetLongitude2);
		Angle planetLongitude3 = PlanetSayanaLongitude(PlanetName.Mars, time);
		PlanetLongitude item3 = new PlanetLongitude(PlanetName.Mars, planetLongitude3);
		Angle planetLongitude4 = PlanetSayanaLongitude(PlanetName.Mercury, time);
		PlanetLongitude item4 = new PlanetLongitude(PlanetName.Mercury, planetLongitude4);
		Angle planetLongitude5 = PlanetSayanaLongitude(PlanetName.Jupiter, time);
		PlanetLongitude item5 = new PlanetLongitude(PlanetName.Jupiter, planetLongitude5);
		Angle planetLongitude6 = PlanetSayanaLongitude(PlanetName.Venus, time);
		PlanetLongitude item6 = new PlanetLongitude(PlanetName.Venus, planetLongitude6);
		Angle planetLongitude7 = PlanetSayanaLongitude(PlanetName.Saturn, time);
		PlanetLongitude item7 = new PlanetLongitude(PlanetName.Saturn, planetLongitude7);
		Angle planetLongitude8 = PlanetSayanaLongitude(PlanetName.Rahu, time);
		PlanetLongitude item8 = new PlanetLongitude(PlanetName.Rahu, planetLongitude8);
		Angle planetLongitude9 = PlanetSayanaLongitude(PlanetName.Ketu, time);
		PlanetLongitude item9 = new PlanetLongitude(PlanetName.Ketu, planetLongitude9);
		return new List<PlanetLongitude> { item, item2, item3, item4, item5, item6, item7, item9, item8 };
	}

	public static HouseName HousePlanetOccupies(PlanetName planetName, Time time)
	{
		Angle longitude = PlanetNirayanaLongitude(planetName, time);
		foreach (House item in AllHouseMiddleLongitudes(time))
		{
			if (item.IsLongitudeInHouseRange(longitude))
			{
				return item.GetHouseName();
			}
		}
		throw new Exception("Planet not in any house, error!");
	}

	public static HouseName HousePlanetOccupiesKP(PlanetName inputPlanet, Time time, int horaryNumber = 0, double rotateDegrees = 0.0)
	{
		Dictionary<HouseName, Angle> allHouseCuspsRaw = Krishnamurti.AllHouseCuspLongitudes(time, horaryNumber, rotateDegrees);
		Angle planetLongitude = PlanetNirayanaLongitude(inputPlanet, time);
		return House.AllHouses.FirstOrDefault((HouseName house) => IsPlanetInHouseKP(allHouseCuspsRaw, planetLongitude, house));
	}

	public static Dictionary<PlanetName, HouseName> HouseAllPlanetOccupiesBasedOnSign(Time time)
	{
		Dictionary<PlanetName, ZodiacSign> dictionary = AllPlanetSigns(time);
		Dictionary<HouseName, ZodiacSign> source = AllHouseSign(time);
		Dictionary<PlanetName, HouseName> dictionary2 = new Dictionary<PlanetName, HouseName>();
		foreach (PlanetName all9Planet in PlanetName.All9Planets)
		{
			ZodiacSign planetSign = dictionary[all9Planet];
			dictionary2.Add(all9Planet, source.Where((KeyValuePair<HouseName, ZodiacSign> yy) => yy.Value.GetSignName() == planetSign.GetSignName()).FirstOrDefault().Key);
		}
		return dictionary2;
	}

	public static Dictionary<PlanetName, HouseName> HouseAllPlanetOccupies(Time time)
	{
		Dictionary<PlanetName, HouseName> dictionary = new Dictionary<PlanetName, HouseName>();
		foreach (PlanetName all9Planet in PlanetName.All9Planets)
		{
			HouseName value = HousePlanetOccupies(all9Planet, time);
			dictionary.Add(all9Planet, value);
		}
		return dictionary;
	}

	public static PlanetName LordOfHouse(HouseName houseNumber, Time time)
	{
		return LordOfZodiacSign(HouseSignName(houseNumber, time));
	}

	public static PlanetName LordOfHouseKP(HouseName inputHouse, Time time, int horaryNumber = 0, double rotateDegrees = 0.0)
	{
		return LordOfZodiacSign(ZodiacSignAtLongitude(Krishnamurti.AllHouseCuspLongitudes(time, horaryNumber, rotateDegrees)[inputHouse]).GetSignName());
	}

	public static PlanetName PlanetLordOfZodiacSign(PlanetName inputPlanet, Time time)
	{
		return LordOfZodiacSign(ZodiacSignAtLongitude(PlanetNirayanaLongitude(inputPlanet, time)).GetSignName());
	}

	public static PlanetName PlanetLordOfConstellation(PlanetName inputPlanet, Time time)
	{
		return LordOfConstellation(ConstellationAtLongitude(PlanetNirayanaLongitude(inputPlanet, time)).GetConstellationName());
	}

	public static List<PlanetName> LordOfHouseList(List<HouseName> houseList, Time time)
	{
		List<PlanetName> list = new List<PlanetName>();
		foreach (HouseName house in houseList)
		{
			PlanetName item = LordOfHouse(house, time);
			list.Add(item);
		}
		return list;
	}

	public static bool IsHouseSignName(HouseName house, ZodiacName sign, Time time)
	{
		return HouseSignName(house, time) == sign;
	}

	public static ZodiacName HouseSignName(HouseName houseNumber, Time time)
	{
		if (houseNumber == HouseName.Empty)
		{
			return ZodiacName.Aries;
		}
		return HouseZodiacSign(houseNumber, time).GetSignName();
	}

	public static ZodiacSign HouseZodiacSign(HouseName houseNumber, Time time)
	{
		return ZodiacSignAtLongitude(AllHouseMiddleLongitudes(time).Find((House house) => house.GetHouseName() == houseNumber).GetMiddleLongitude());
	}

	public static ZodiacSign HouseZodiacSignKP(HouseName inputHouse, Time time, int horaryNumber = 0, double rotateDegrees = 0.0)
	{
		return ZodiacSignAtLongitude(Krishnamurti.AllHouseCuspLongitudes(time, horaryNumber, rotateDegrees)[inputHouse]);
	}

	public static Angle HouseLongitudeKP(HouseName inputHouse, Time time, int horaryNumber = 0, double rotateDegrees = 0.0)
	{
		return Krishnamurti.AllHouseCuspLongitudes(time, horaryNumber, rotateDegrees)[inputHouse];
	}

	public static Dictionary<HouseName, ZodiacSign> AllHouseSign(Time time)
	{
		Dictionary<HouseName, ZodiacSign> dictionary = new Dictionary<HouseName, ZodiacSign>();
		foreach (HouseName allHouse in House.AllHouses)
		{
			ZodiacSign value = HouseZodiacSign(allHouse, time);
			dictionary.Add(allHouse, value);
		}
		return dictionary;
	}

	public static Dictionary<HouseName, PlanetName> AllHouseConstellationLord(Time time)
	{
		Dictionary<HouseName, PlanetName> dictionary = new Dictionary<HouseName, PlanetName>();
		foreach (HouseName allHouse in House.AllHouses)
		{
			PlanetName value = LordOfConstellation(HouseConstellation(allHouse, time).GetConstellationName());
			dictionary.Add(allHouse, value);
		}
		return dictionary;
	}

	public static Constellation HouseConstellationKP(HouseName inputHouse, Time time, int horaryNumber = 0, double rotateDegrees = 0.0)
	{
		return ConstellationAtLongitude(Krishnamurti.AllHouseCuspLongitudes(time, horaryNumber, rotateDegrees)[inputHouse]);
	}

	public static Constellation HouseConstellation(HouseName houseNumber, Time time)
	{
		return ConstellationAtLongitude(AllHouseMiddleLongitudes(time).Find((House house) => house.GetHouseName() == houseNumber).GetMiddleLongitude());
	}

	public static Dictionary<HouseName, List<PlanetName>> AllHousePlanetsInHouseBasedOnSign(Time time)
	{
		Dictionary<HouseName, List<PlanetName>> dictionary = new Dictionary<HouseName, List<PlanetName>>();
		foreach (HouseName allHouse in House.AllHouses)
		{
			List<PlanetName> value = PlanetsInHouseBasedOnSign(allHouse, time);
			dictionary.Add(allHouse, value);
		}
		return dictionary;
	}

	public static ZodiacName NavamsaSignNameFromLongitude(Angle longitude)
	{
		ZodiacSign zodiacSign = ZodiacSignAtLongitude(longitude);
		ZodiacName inputSign;
		switch (zodiacSign.GetSignName())
		{
		case ZodiacName.Aries:
		case ZodiacName.Leo:
		case ZodiacName.Sagittarius:
			inputSign = ZodiacName.Aries;
			break;
		case ZodiacName.Taurus:
		case ZodiacName.Virgo:
		case ZodiacName.Capricorn:
			inputSign = ZodiacName.Capricorn;
			break;
		case ZodiacName.Gemini:
		case ZodiacName.Libra:
		case ZodiacName.Aquarius:
			inputSign = ZodiacName.Libra;
			break;
		case ZodiacName.Cancer:
		case ZodiacName.Scorpio:
		case ZodiacName.Pisces:
			inputSign = ZodiacName.Cancer;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		int countToNextSign = (int)Math.Ceiling(zodiacSign.GetDegreesInSign().TotalDegrees / 3.333333333);
		return SignCountedFromInputSign(inputSign, countToNextSign);
	}

	public static ZodiacName SignCountedFromInputSign(ZodiacName inputSign, int countToNextSign)
	{
		ZodiacName zodiacName = inputSign;
		for (int i = 1; i < countToNextSign; i++)
		{
			zodiacName = NextZodiacSign(zodiacName);
		}
		return zodiacName;
	}

	public static ZodiacName SignCountedFromPlanetSign(int countToNextSign, PlanetName startPlanet, Time inputTime)
	{
		return SignCountedFromInputSign(PlanetZodiacSign(startPlanet, inputTime).GetSignName(), countToNextSign);
	}

	public static ZodiacName SignCountedFromPlanetSign(int countToNextSign, Time inputTime, PlanetName startPlanet)
	{
		return SignCountedFromInputSign(PlanetZodiacSign(startPlanet, inputTime).GetSignName(), countToNextSign);
	}

	public static ZodiacName SignCountedFromLagnaSign(int countToNextSign, Time inputTime)
	{
		return SignCountedFromInputSign(LagnaSignName(inputTime), countToNextSign);
	}

	public static int HouseCountedFromInputHouse(int inputHouseNumber, int countToNextHouse)
	{
		int num = inputHouseNumber;
		for (int i = 1; i < countToNextHouse; i++)
		{
			num = NextHouseNumber(num);
		}
		return num;
	}

	public static PlanetName HouseSubLordKP(HouseName inputHouse, Time time, int horaryNumber = 0, double rotateDegrees = 0.0)
	{
		return Krishnamurti.SubLordAtLongitude(Krishnamurti.AllHouseCuspLongitudes(time, horaryNumber, rotateDegrees)[inputHouse]);
	}

	public static PlanetName PlanetSubLordKP(PlanetName inputPlanet, Time time)
	{
		return PlanetName.Sun;
	}

	public static bool IsPlanetInSign(PlanetName planetName, ZodiacName signInput, Time time)
	{
		return PlanetZodiacSign(planetName, time).GetSignName() == signInput;
	}

	public static ZodiacName PlanetNavamsaSign(PlanetName planetName, Time time)
	{
		return NavamsaSignNameFromLongitude(PlanetNirayanaLongitude(planetName, time));
	}

	public static List<ZodiacName> SignsPlanetIsAspecting(PlanetName planetName, Time time)
	{
		List<ZodiacName> list = new List<ZodiacName>();
		ZodiacName signName = PlanetZodiacSign(planetName, time).GetSignName();
		if (planetName == PlanetName.Saturn)
		{
			ZodiacName item = SignCountedFromInputSign(signName, 3);
			ZodiacName item2 = SignCountedFromInputSign(signName, 10);
			list.Add(item);
			list.Add(item2);
		}
		if (planetName == PlanetName.Maandi)
		{
			ZodiacName item3 = SignCountedFromInputSign(signName, 2);
			ZodiacName item4 = SignCountedFromInputSign(signName, 7);
			ZodiacName item5 = SignCountedFromInputSign(signName, 12);
			list.Add(item3);
			list.Add(item4);
			list.Add(item5);
		}
		if (planetName == PlanetName.Gulika)
		{
			ZodiacName item6 = SignCountedFromInputSign(signName, 2);
			ZodiacName item7 = SignCountedFromInputSign(signName, 7);
			ZodiacName item8 = SignCountedFromInputSign(signName, 12);
			list.Add(item6);
			list.Add(item7);
			list.Add(item8);
		}
		if (planetName == PlanetName.Jupiter)
		{
			ZodiacName item9 = SignCountedFromInputSign(signName, 5);
			ZodiacName item10 = SignCountedFromInputSign(signName, 9);
			list.Add(item9);
			list.Add(item10);
		}
		if (planetName == PlanetName.Mars)
		{
			ZodiacName item11 = SignCountedFromInputSign(signName, 4);
			ZodiacName item12 = SignCountedFromInputSign(signName, 8);
			list.Add(item11);
			list.Add(item12);
		}
		ZodiacName item13 = SignCountedFromInputSign(signName, 7);
		list.Add(item13);
		return list;
	}

	public static ZodiacName HouseNavamsaSign(HouseName house, Time time)
	{
		if (house == HouseName.Empty)
		{
			return ZodiacName.Aries;
		}
		return NavamsaSignNameFromLongitude(AllHouseMiddleLongitudes(time).Find((House hs) => hs.GetHouseName() == house).GetMiddleLongitude());
	}

	public static ZodiacName PlanetThrimsamsaSign(PlanetName planetName, Time time)
	{
		ZodiacSign zodiacSign = PlanetZodiacSign(planetName, time);
		ZodiacName signName = zodiacSign.GetSignName();
		int num = (int)Math.Ceiling(zodiacSign.GetDegreesInSign().TotalDegrees % 30.0 / 1.0);
		if (IsOddSign(signName))
		{
			if (num >= 0 && num <= 5)
			{
				return ZodiacName.Scorpio;
			}
			if (num >= 6 && num <= 10)
			{
				return ZodiacName.Capricorn;
			}
			if (num >= 11 && num <= 18)
			{
				return ZodiacName.Sagittarius;
			}
			if (num >= 19 && num <= 25)
			{
				return ZodiacName.Gemini;
			}
			if (num >= 26 && num <= 30)
			{
				return ZodiacName.Taurus;
			}
		}
		if (IsEvenSign(signName))
		{
			if (num >= 0 && num <= 5)
			{
				return ZodiacName.Taurus;
			}
			if (num >= 6 && num <= 12)
			{
				return ZodiacName.Gemini;
			}
			if (num >= 13 && num <= 20)
			{
				return ZodiacName.Sagittarius;
			}
			if (num >= 21 && num <= 25)
			{
				return ZodiacName.Capricorn;
			}
			if (num >= 26 && num <= 30)
			{
				return ZodiacName.Scorpio;
			}
		}
		throw new Exception("Thrimsamsa not found, error!");
	}

	public static ZodiacName PlanetDwadasamsaSign(PlanetName planetName, Time time)
	{
		ZodiacSign zodiacSign = PlanetZodiacSign(planetName, time);
		ZodiacName signName = zodiacSign.GetSignName();
		int countToNextSign = (int)Math.Ceiling(zodiacSign.GetDegreesInSign().TotalDegrees % 30.0 / 2.5);
		return SignCountedFromInputSign(signName, countToNextSign);
	}

	public static ZodiacName PlanetSaptamsaSign(PlanetName planetName, Time time)
	{
		ZodiacSign zodiacSign = PlanetZodiacSign(planetName, time);
		ZodiacName signName = zodiacSign.GetSignName();
		int num = (int)Math.Ceiling(zodiacSign.GetDegreesInSign().TotalDegrees % 30.0 / 4.285714285714286);
		if (IsOddSign(signName))
		{
			return SignCountedFromInputSign(signName, num);
		}
		if (IsEvenSign(signName))
		{
			int countToNextSign = num + 6;
			return SignCountedFromInputSign(signName, countToNextSign);
		}
		throw new Exception("Saptamsa not found, error!");
	}

	public static ZodiacSign PlanetChaturthamsaSign(PlanetName planetName, Time time)
	{
		return ChaturthamsaSignName(PlanetZodiacSign(planetName, time));
	}

	public static ZodiacSign PlanetPanchamsaSign(PlanetName planetName, Time time)
	{
		return PanchamsaSignName(PlanetZodiacSign(planetName, time));
	}

	public static ZodiacSign ChaturthamsaSignName(ZodiacSign zodiacSign)
	{
		return ZodiacSign.Empty;
	}

	public static ZodiacSign PanchamsaSignName(ZodiacSign zodiacSign)
	{
		return default(ZodiacSign);
	}

	public static bool IsPlanetInMoolatrikona(PlanetName planetName, Time time)
	{
		ZodiacSign zodiacSign = PlanetZodiacSign(planetName, time);
		if (planetName == PlanetName.Sun && zodiacSign.GetSignName() == ZodiacName.Leo)
		{
			double totalDegrees = zodiacSign.GetDegreesInSign().TotalDegrees;
			if (totalDegrees >= 0.0 && totalDegrees <= 20.0)
			{
				return true;
			}
		}
		if (planetName == PlanetName.Moon && zodiacSign.GetSignName() == ZodiacName.Taurus)
		{
			double totalDegrees2 = zodiacSign.GetDegreesInSign().TotalDegrees;
			if (totalDegrees2 >= 4.0 && totalDegrees2 <= 30.0)
			{
				return true;
			}
		}
		if (planetName == PlanetName.Mercury && zodiacSign.GetSignName() == ZodiacName.Virgo)
		{
			double totalDegrees3 = zodiacSign.GetDegreesInSign().TotalDegrees;
			if (totalDegrees3 >= 16.0 && totalDegrees3 <= 20.0)
			{
				return true;
			}
		}
		if (planetName == PlanetName.Jupiter && zodiacSign.GetSignName() == ZodiacName.Sagittarius)
		{
			double totalDegrees4 = zodiacSign.GetDegreesInSign().TotalDegrees;
			if (totalDegrees4 >= 0.0 && totalDegrees4 <= 13.0)
			{
				return true;
			}
		}
		if (planetName == PlanetName.Mars && zodiacSign.GetSignName() == ZodiacName.Aries)
		{
			double totalDegrees5 = zodiacSign.GetDegreesInSign().TotalDegrees;
			if (totalDegrees5 >= 0.0 && totalDegrees5 <= 18.0)
			{
				return true;
			}
		}
		if (planetName == PlanetName.Venus && zodiacSign.GetSignName() == ZodiacName.Libra)
		{
			double totalDegrees6 = zodiacSign.GetDegreesInSign().TotalDegrees;
			if (totalDegrees6 >= 0.0 && totalDegrees6 <= 10.0)
			{
				return true;
			}
		}
		if (planetName == PlanetName.Saturn && zodiacSign.GetSignName() == ZodiacName.Aquarius)
		{
			double totalDegrees7 = zodiacSign.GetDegreesInSign().TotalDegrees;
			if (totalDegrees7 >= 0.0 && totalDegrees7 <= 20.0)
			{
				return true;
			}
		}
		return false;
	}

	public static PlanetToSignRelationship PlanetRelationshipWithSign(PlanetName planetName, ZodiacName zodiacSignName, Time time)
	{
		bool num = planetName.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag = planetName.Name == PlanetName.PlanetNameEnum.Ketu;
		if (num | flag)
		{
			return PlanetToSignRelationship.Empty;
		}
		PlanetName planetName2 = LordOfZodiacSign(zodiacSignName);
		if (planetName == planetName2)
		{
			return PlanetToSignRelationship.OwnVarga;
		}
		return PlanetCombinedRelationshipWithPlanet(planetName, planetName2, time) switch
		{
			PlanetToPlanetRelationship.BestFriend => PlanetToSignRelationship.BestFriendVarga, 
			PlanetToPlanetRelationship.Friend => PlanetToSignRelationship.FriendVarga, 
			PlanetToPlanetRelationship.BitterEnemy => PlanetToSignRelationship.BitterEnemyVarga, 
			PlanetToPlanetRelationship.Enemy => PlanetToSignRelationship.EnemyVarga, 
			PlanetToPlanetRelationship.Neutral => PlanetToSignRelationship.NeutralVarga, 
			_ => PlanetToSignRelationship.Empty, 
		};
	}

	public static PlanetToPlanetRelationship PlanetCombinedRelationshipWithPlanet(PlanetName mainPlanet, PlanetName secondaryPlanet, Time time)
	{
		bool num = mainPlanet.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag = mainPlanet.Name == PlanetName.PlanetNameEnum.Ketu;
		bool flag2 = secondaryPlanet.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag3 = secondaryPlanet.Name == PlanetName.PlanetNameEnum.Ketu;
		if (num | flag | flag2 | flag3)
		{
			return PlanetToPlanetRelationship.Empty;
		}
		if (mainPlanet == secondaryPlanet)
		{
			return PlanetToPlanetRelationship.SamePlanet;
		}
		PlanetToPlanetRelationship planetToPlanetRelationship = PlanetPermanentRelationshipWithPlanet(mainPlanet, secondaryPlanet);
		PlanetToPlanetRelationship planetToPlanetRelationship2 = PlanetTemporaryRelationshipWithPlanet(mainPlanet, secondaryPlanet, time);
		if (planetToPlanetRelationship2 == PlanetToPlanetRelationship.Friend && planetToPlanetRelationship == PlanetToPlanetRelationship.Friend)
		{
			return PlanetToPlanetRelationship.BestFriend;
		}
		if (planetToPlanetRelationship2 == PlanetToPlanetRelationship.Friend && planetToPlanetRelationship == PlanetToPlanetRelationship.Enemy)
		{
			return PlanetToPlanetRelationship.Neutral;
		}
		if (planetToPlanetRelationship2 == PlanetToPlanetRelationship.Friend && planetToPlanetRelationship == PlanetToPlanetRelationship.Neutral)
		{
			return PlanetToPlanetRelationship.Friend;
		}
		if (planetToPlanetRelationship2 == PlanetToPlanetRelationship.Enemy && planetToPlanetRelationship == PlanetToPlanetRelationship.Enemy)
		{
			return PlanetToPlanetRelationship.BitterEnemy;
		}
		if (planetToPlanetRelationship2 == PlanetToPlanetRelationship.Enemy && planetToPlanetRelationship == PlanetToPlanetRelationship.Friend)
		{
			return PlanetToPlanetRelationship.Neutral;
		}
		if (planetToPlanetRelationship2 == PlanetToPlanetRelationship.Enemy && planetToPlanetRelationship == PlanetToPlanetRelationship.Neutral)
		{
			return PlanetToPlanetRelationship.Enemy;
		}
		return PlanetToPlanetRelationship.Empty;
	}

	public static PlanetToSignRelationship PlanetRelationshipWithHouse(HouseName house, PlanetName planet, Time time)
	{
		ZodiacName zodiacSignName = HouseSignName(house, time);
		return PlanetRelationshipWithSign(planet, zodiacSignName, time);
	}

	public static PlanetToPlanetRelationship PlanetTemporaryRelationshipWithPlanet(PlanetName mainPlanet, PlanetName secondaryPlanet, Time time)
	{
		if (mainPlanet == secondaryPlanet)
		{
			return PlanetToPlanetRelationship.SamePlanet;
		}
		if (PlanetTemporaryFriendList(mainPlanet, time).Contains(secondaryPlanet))
		{
			return PlanetToPlanetRelationship.Friend;
		}
		return PlanetToPlanetRelationship.Enemy;
	}

	public static List<PlanetName> PlanetInSign(ZodiacName signName, Time time)
	{
		ZodiacName signName2 = PlanetZodiacSign(PlanetName.Sun, time).GetSignName();
		ZodiacName signName3 = PlanetZodiacSign(PlanetName.Moon, time).GetSignName();
		ZodiacName signName4 = PlanetZodiacSign(PlanetName.Mars, time).GetSignName();
		ZodiacName signName5 = PlanetZodiacSign(PlanetName.Mercury, time).GetSignName();
		ZodiacName signName6 = PlanetZodiacSign(PlanetName.Jupiter, time).GetSignName();
		ZodiacName signName7 = PlanetZodiacSign(PlanetName.Venus, time).GetSignName();
		ZodiacName signName8 = PlanetZodiacSign(PlanetName.Saturn, time).GetSignName();
		ZodiacName signName9 = PlanetZodiacSign(PlanetName.Rahu, time).GetSignName();
		ZodiacName signName10 = PlanetZodiacSign(PlanetName.Ketu, time).GetSignName();
		List<PlanetName> list = new List<PlanetName>();
		if (signName2 == signName)
		{
			list.Add(PlanetName.Sun);
		}
		if (signName3 == signName)
		{
			list.Add(PlanetName.Moon);
		}
		if (signName4 == signName)
		{
			list.Add(PlanetName.Mars);
		}
		if (signName5 == signName)
		{
			list.Add(PlanetName.Mercury);
		}
		if (signName6 == signName)
		{
			list.Add(PlanetName.Jupiter);
		}
		if (signName7 == signName)
		{
			list.Add(PlanetName.Venus);
		}
		if (signName8 == signName)
		{
			list.Add(PlanetName.Saturn);
		}
		if (signName9 == signName)
		{
			list.Add(PlanetName.Rahu);
		}
		if (signName10 == signName)
		{
			list.Add(PlanetName.Ketu);
		}
		return list;
	}

	public static List<PlanetName> PlanetTemporaryFriendList(PlanetName planetName, Time time)
	{
		ZodiacName signName = PlanetZodiacSign(planetName, time).GetSignName();
		ZodiacName item = SignCountedFromInputSign(signName, 2);
		ZodiacName item2 = SignCountedFromInputSign(signName, 3);
		ZodiacName item3 = SignCountedFromInputSign(signName, 4);
		ZodiacName item4 = SignCountedFromInputSign(signName, 10);
		ZodiacName item5 = SignCountedFromInputSign(signName, 11);
		ZodiacName item6 = SignCountedFromInputSign(signName, 12);
		List<ZodiacName> obj = new List<ZodiacName> { item, item2, item3, item4, item5, item6 };
		List<PlanetName> list = new List<PlanetName>();
		foreach (ZodiacName item7 in obj)
		{
			List<PlanetName> collection = PlanetInSign(item7, time);
			list.AddRange(collection);
		}
		list.Remove(PlanetName.Rahu);
		list.Remove(PlanetName.Ketu);
		return list;
	}

	public static double GreenwichApparentInJulianDays(Time time)
	{
		double tjd_lmt = GreenwichLmtInJulianDays(time);
		double geolon = time.GetGeoLocation().Longitude();
		string serr = "";
		using SwissEph swissEph = new SwissEph();
		swissEph.swe_lmt_to_lat(tjd_lmt, geolon, out var tjd_lat, ref serr);
		return tjd_lat;
	}

	public static DateTime LocalApparentTime(Time time)
	{
		return CacheManager.GetCache(new CacheKey("LocalApparentTime", time, Ayanamsa), _getLocalApparentTime);
		DateTime _getLocalApparentTime()
		{
			double tjd_lmt = ConvertLmtToJulian(time);
			double geolon = time.GetGeoLocation().Longitude();
			string serr = null;
			new SwissEph().swe_lmt_to_lat(tjd_lmt, geolon, out var tjd_lat, ref serr);
			return ConvertJulianTimeToNormalTime(tjd_lat);
		}
	}

	public static House HouseLongitude(HouseName houseNumber, Time time)
	{
		return CacheManager.GetCache(new CacheKey("HouseLongitude", houseNumber, time, Ayanamsa), _getHouse);
		House _getHouse()
		{
			return AllHouseMiddleLongitudes(time).Find((House h) => h.GetHouseName() == houseNumber);
		}
	}

	public static PanchakaName Panchaka(Time time)
	{
		int lunarDateNumber = LunarDay(time).GetLunarDateNumber();
		int constellationNumber = MoonConstellation(time).GetConstellationNumber();
		int num = (int)DayOfWeek(time);
		int num2 = (int)HouseSignName(HouseName.House1, time);
		double num3 = (double)(lunarDateNumber + constellationNumber + num + num2) % 9.0;
		if (num3 != 1.0)
		{
			if (num3 != 2.0)
			{
				if (num3 != 4.0)
				{
					if (num3 != 6.0)
					{
						if (num3 != 8.0)
						{
							if (num3 == 3.0 || num3 == 5.0 || num3 == 7.0 || num3 == 0.0)
							{
								return PanchakaName.Shubha;
							}
							throw new Exception("Panchaka not found, error!");
						}
						return PanchakaName.Roga;
					}
					return PanchakaName.Chora;
				}
				return PanchakaName.Raja;
			}
			return PanchakaName.Agni;
		}
		return PanchakaName.Mrityu;
	}

	public static PlanetName LordOfWeekday(Time time)
	{
		return DayOfWeek(time) switch
		{
			VedAstro.Library.DayOfWeek.Sunday => PlanetName.Sun, 
			VedAstro.Library.DayOfWeek.Monday => PlanetName.Moon, 
			VedAstro.Library.DayOfWeek.Tuesday => PlanetName.Mars, 
			VedAstro.Library.DayOfWeek.Wednesday => PlanetName.Mercury, 
			VedAstro.Library.DayOfWeek.Thursday => PlanetName.Jupiter, 
			VedAstro.Library.DayOfWeek.Friday => PlanetName.Venus, 
			VedAstro.Library.DayOfWeek.Saturday => PlanetName.Saturn, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public static PlanetName LordOfWeekday(DayOfWeek weekday)
	{
		return weekday switch
		{
			VedAstro.Library.DayOfWeek.Sunday => PlanetName.Sun, 
			VedAstro.Library.DayOfWeek.Monday => PlanetName.Moon, 
			VedAstro.Library.DayOfWeek.Tuesday => PlanetName.Mars, 
			VedAstro.Library.DayOfWeek.Wednesday => PlanetName.Mercury, 
			VedAstro.Library.DayOfWeek.Thursday => PlanetName.Jupiter, 
			VedAstro.Library.DayOfWeek.Friday => PlanetName.Venus, 
			VedAstro.Library.DayOfWeek.Saturday => PlanetName.Saturn, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public static DateTimeOffset LmtToStd(DateTimeOffset lmtDateTime, TimeSpan stdOffset)
	{
		return lmtDateTime.ToOffset(stdOffset);
	}

	public static Angle IshtaKaala(Time birthTime)
	{
		TimeSpan timeSpan;
		if (IsBeforeSunrise(birthTime))
		{
			Time time = SunriseTime(birthTime.SubtractHours(23.0));
			timeSpan = birthTime.Subtract(time);
		}
		else
		{
			Time time2 = SunriseTime(birthTime);
			timeSpan = birthTime.Subtract(time2);
		}
		double num = timeSpan.TotalHours * 2.5;
		VedicTime.FromTotalGhatis(num);
		return Angle.FromDegrees(num);
	}

	public static bool IsBeforeSunrise(Time birthTime)
	{
		Time time = SunriseTime(birthTime);
		return birthTime < time;
	}

	public static int HoraAtBirth(Time time)
	{
		DateTimeOffset lmtDateTimeOffset = time.GetLmtDateTimeOffset();
		DateTimeOffset lmtDateTimeOffset2 = SunriseTime(time).GetLmtDateTimeOffset();
		TimeSpan timeSpan;
		if (lmtDateTimeOffset >= lmtDateTimeOffset2)
		{
			timeSpan = lmtDateTimeOffset.Subtract(lmtDateTimeOffset2);
		}
		else
		{
			lmtDateTimeOffset2 = SunriseTime(new Time(time.GetLmtDateTimeOffset().DateTime.AddDays(-1.0), time.GetStdDateTimeOffset().Offset, time.GetGeoLocation())).GetLmtDateTimeOffset();
			timeSpan = lmtDateTimeOffset.Subtract(lmtDateTimeOffset2);
		}
		double num = Math.Ceiling(timeSpan.TotalHours);
		if (num == 0.0)
		{
			num = 1.0;
		}
		if (num > 24.0)
		{
			num = 24.0;
		}
		return (int)num;
	}

	public static Time SunriseTime(Time time)
	{
		return CacheManager.GetCache(new CacheKey("SunriseTime", time, Ayanamsa), _getSunriseTime);
		Time _getSunriseTime()
		{
			int rsmi = 769;
			int ipl = 0;
			double[] geopos = new double[3]
			{
				time.GetGeoLocation().Longitude(),
				time.GetGeoLocation().Latitude(),
				0.0
			};
			double tret = 0.0;
			string serr = "";
			DateTimeOffset lmtDateTimeOffset = time.GetLmtDateTimeOffset();
			DateTime lmtDateTime = new DateTime(lmtDateTimeOffset.Year, lmtDateTimeOffset.Month, lmtDateTimeOffset.Day, 0, 0, 0);
			double tjd_ut = GreenwichLmtInJulianDays(new Time(lmtDateTime, time.GetStdDateTimeOffset().Offset, time.GetGeoLocation()));
			using SwissEph swissEph = new SwissEph();
			swissEph.swe_rise_trans(tjd_ut, ipl, "", 65794, rsmi, geopos, 0.0, 0.0, ref tret, ref serr);
			DateTimeOffset stdDateTime = GreenwichTimeFromJulianDays(tret).ToOffset(time.GetStdDateTimeOffset().Offset);
			return new Time(stdDateTime, time.GetGeoLocation());
		}
	}

	public static Time SunsetTime(Time time)
	{
		return CacheManager.GetCache(new CacheKey("SunsetTime", time, Ayanamsa), _getSunsetTime);
		Time _getSunsetTime()
		{
			int rsmi = 770;
			int ipl = 0;
			double[] geopos = new double[3]
			{
				time.GetGeoLocation().Longitude(),
				time.GetGeoLocation().Latitude(),
				0.0
			};
			double tret = 0.0;
			string serr = "";
			DateTimeOffset lmtDateTimeOffset = time.GetLmtDateTimeOffset();
			DateTime lmtDateTime = new DateTime(lmtDateTimeOffset.Year, lmtDateTimeOffset.Month, lmtDateTimeOffset.Day, 0, 0, 0);
			double tjd_ut = GreenwichLmtInJulianDays(new Time(lmtDateTime, time.GetStdDateTimeOffset().Offset, time.GetGeoLocation()));
			using SwissEph swissEph = new SwissEph();
			swissEph.swe_rise_trans(tjd_ut, ipl, "", 65794, rsmi, geopos, 0.0, 0.0, ref tret, ref serr);
			DateTimeOffset stdDateTime = GreenwichTimeFromJulianDays(tret).ToOffset(time.GetStdDateTimeOffset().Offset);
			return new Time(stdDateTime, time.GetGeoLocation());
		}
	}

	public static DateTime NoonTime(Time time)
	{
		DateTime dateTime = LocalApparentTime(time);
		return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 12, 0, 0);
	}

	public static bool IsPlanetInGoodAspectToPlanet(PlanetName receivingAspect, PlanetName transmitingAspect, Time time)
	{
		bool flag = IsPlanetAspectedByPlanet(receivingAspect, transmitingAspect, time);
		if (!flag)
		{
			return false;
		}
		PlanetToPlanetRelationship planetToPlanetRelationship = PlanetCombinedRelationshipWithPlanet(receivingAspect, transmitingAspect, time);
		bool flag2 = planetToPlanetRelationship == PlanetToPlanetRelationship.BestFriend || planetToPlanetRelationship == PlanetToPlanetRelationship.Friend;
		return flag & flag2;
	}

	public static bool IsPlanetInGoodAspectToHouse(HouseName receivingAspect, PlanetName transmitingAspect, Time time)
	{
		bool flag = IsHouseAspectedByPlanet(receivingAspect, transmitingAspect, time);
		if (!flag)
		{
			return false;
		}
		PlanetToSignRelationship planetToSignRelationship = PlanetRelationshipWithHouse(receivingAspect, transmitingAspect, time);
		bool flag2 = planetToSignRelationship == PlanetToSignRelationship.OwnVarga || planetToSignRelationship == PlanetToSignRelationship.FriendVarga || planetToSignRelationship == PlanetToSignRelationship.BestFriendVarga;
		return flag & flag2;
	}

	public static double PlanetSthanaBalaNeutralPoint(PlanetName planet)
	{
		bool num = planet.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag = planet.Name == PlanetName.PlanetNameEnum.Ketu;
		if (num | flag)
		{
			return 0.0;
		}
		return CacheManager.GetCache(new CacheKey("PlanetSthanaBalaNeutralPoint", planet, Ayanamsa), _getPlanetSthanaBalaNeutralPoint);
		double _getPlanetSthanaBalaNeutralPoint()
		{
			int num2 = 0;
			int num3 = 0;
			if (planet == PlanetName.Saturn)
			{
				num2 = 297;
				num3 = 59;
			}
			if (planet == PlanetName.Mars)
			{
				num2 = 362;
				num3 = 60;
			}
			if (planet == PlanetName.Jupiter)
			{
				num2 = 296;
				num3 = 77;
			}
			if (planet == PlanetName.Mercury)
			{
				num2 = 295;
				num3 = 47;
			}
			if (planet == PlanetName.Venus)
			{
				num2 = 284;
				num3 = 60;
			}
			if (planet == PlanetName.Sun)
			{
				num2 = 327;
				num3 = 52;
			}
			if (planet == PlanetName.Moon)
			{
				num2 = 311;
				num3 = 54;
			}
			int num4 = (num2 - num3) / 2 + num3;
			if (num4 <= 0)
			{
				throw new Exception("Planet does not have neutral point!");
			}
			return num4;
		}
	}

	public static bool IsPlanetInTrikona(PlanetName planet, Time time)
	{
		HouseName houseName = HousePlanetOccupies(planet, time);
		if (houseName != HouseName.House1 && houseName != HouseName.House5)
		{
			return houseName == HouseName.House9;
		}
		return true;
	}

	public static bool IsPlanetInKendra(PlanetName planet, Time time)
	{
		HouseName houseName = HousePlanetOccupies(planet, time);
		if (houseName != HouseName.House1 && houseName != HouseName.House4 && houseName != HouseName.House7)
		{
			return houseName == HouseName.House10;
		}
		return true;
	}

	public static bool IsPlanetInUpachaya(PlanetName planet, Time time)
	{
		HouseName houseName = HousePlanetOccupies(planet, time);
		if (houseName != HouseName.House3 && houseName != HouseName.House6 && houseName != HouseName.House10)
		{
			return houseName == HouseName.House11;
		}
		return true;
	}

	public static bool IsPlanetInKendra(PlanetName[] planetList, Time time)
	{
		bool result = false;
		for (int i = 0; i < planetList.Length; i++)
		{
			if (IsPlanetInKendra(planetList[i], time))
			{
				return true;
			}
		}
		return result;
	}

	public static bool IsPlanetInKendraFromPlanet(PlanetName kendraFrom, PlanetName kendraTo, Time time)
	{
		int num = SignDistanceFromPlanetToPlanet(kendraTo, kendraFrom, time);
		if (num != 1 && num != 4 && num != 7)
		{
			return num == 10;
		}
		return true;
	}

	public static int SignDistanceFromPlanetToPlanet(PlanetName startPlanet, PlanetName endPlanet, Time time)
	{
		ZodiacSign zodiacSign = PlanetZodiacSign(startPlanet, time);
		ZodiacSign zodiacSign2 = PlanetZodiacSign(endPlanet, time);
		return CountFromSignToSign(zodiacSign.GetSignName(), zodiacSign2.GetSignName());
	}

	public static bool IsHouseLordInHouse(HouseName lordHouse, HouseName occupiedHouse, Time time)
	{
		return HousePlanetOccupies(LordOfHouse(lordHouse, time), time) == occupiedHouse;
	}

	public static bool IsPlanetConjunctWithMaleficPlanets(PlanetName planetName, Time time)
	{
		List<PlanetName> list = PlanetsInConjuction(planetName, time);
		List<PlanetName> evilPlanets = MaleficPlanetList(time);
		return list.FindAll((PlanetName planet) => evilPlanets.Contains(planet)).Any();
	}

	public static bool IsPlanetConjunctWithEnemyPlanets(PlanetName inputPlanet, Time time)
	{
		foreach (PlanetName item in PlanetsInConjuction(inputPlanet, time))
		{
			PlanetToPlanetRelationship planetToPlanetRelationship = PlanetCombinedRelationshipWithPlanet(inputPlanet, item, time);
			if (planetToPlanetRelationship == PlanetToPlanetRelationship.Enemy || planetToPlanetRelationship == PlanetToPlanetRelationship.BitterEnemy)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsPlanetConjunctWithFriendPlanets(PlanetName inputPlanet, Time time)
	{
		foreach (PlanetName item in PlanetsInConjuction(inputPlanet, time))
		{
			PlanetToPlanetRelationship planetToPlanetRelationship = PlanetCombinedRelationshipWithPlanet(inputPlanet, item, time);
			if (planetToPlanetRelationship == PlanetToPlanetRelationship.Friend || planetToPlanetRelationship == PlanetToPlanetRelationship.BestFriend)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsMaleficPlanetInHouse(HouseName houseNumber, Time time)
	{
		List<PlanetName> list = PlanetsInHouse(houseNumber, time);
		List<PlanetName> evilPlanets = MaleficPlanetList(time);
		return list.FindAll((PlanetName planet) => evilPlanets.Contains(planet)).Any();
	}

	public static bool IsBeneficPlanetInHouse(HouseName houseNumber, Time time)
	{
		List<PlanetName> list = PlanetsInHouse(houseNumber, time);
		List<PlanetName> goodPlanets = BeneficPlanetList(time);
		return list.FindAll((PlanetName planet) => goodPlanets.Contains(planet)).Any();
	}

	public static bool IsBeneficsInKendra(Time time)
	{
		foreach (PlanetName item in BeneficPlanetList(time))
		{
			if (IsPlanetInKendra(item, time))
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsAllMaleficsInUpachayas(Time time)
	{
		foreach (PlanetName item in MaleficPlanetList(time))
		{
			if (!IsPlanetInUpachaya(item, time))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsMaleficPlanetInSign(ZodiacName sign, Time time)
	{
		List<PlanetName> list = PlanetInSign(sign, time);
		List<PlanetName> evilPlanets = MaleficPlanetList(time);
		return list.FindAll((PlanetName planet) => evilPlanets.Contains(planet)).Any();
	}

	public static List<PlanetName> MaleficPlanetListInSign(ZodiacName sign, Time time)
	{
		List<PlanetName> list = PlanetInSign(sign, time);
		List<PlanetName> evilPlanets = MaleficPlanetList(time);
		return list.FindAll((PlanetName planet) => evilPlanets.Contains(planet));
	}

	public static bool IsBeneficPlanetInSign(ZodiacName sign, Time time)
	{
		List<PlanetName> list = PlanetInSign(sign, time);
		List<PlanetName> goodPlanets = BeneficPlanetList(time);
		return list.FindAll((PlanetName planet) => goodPlanets.Contains(planet)).Any();
	}

	public static List<PlanetName> BeneficPlanetListInSign(ZodiacName sign, Time time)
	{
		List<PlanetName> list = PlanetInSign(sign, time);
		List<PlanetName> goodPlanets = BeneficPlanetList(time);
		return list.FindAll((PlanetName planet) => goodPlanets.Contains(planet));
	}

	public static bool IsMaleficPlanetAspectHouse(HouseName house, Time time)
	{
		return MaleficPlanetList(time).FindAll((PlanetName evilPlanet) => IsHouseAspectedByPlanet(house, evilPlanet, time)).Any();
	}

	public static bool IsBeneficPlanetAspectHouse(HouseName house, Time time)
	{
		return BeneficPlanetList(time).FindAll((PlanetName goodPlanet) => IsHouseAspectedByPlanet(house, goodPlanet, time)).Any();
	}

	public static bool IsPlanetAspectedByMaleficPlanets(PlanetName lord, Time time)
	{
		return MaleficPlanetList(time).FindAll((PlanetName evilPlanet) => IsPlanetAspectedByPlanet(lord, evilPlanet, time)).Any();
	}

	public static bool IsPlanetAspectedByBeneficPlanets(PlanetName lord, Time time)
	{
		return BeneficPlanetList(time).FindAll((PlanetName goodPlanet) => IsPlanetAspectedByPlanet(lord, goodPlanet, time)).Any();
	}

	public static bool IsPlanetAspectedByEnemyPlanets(PlanetName inputPlanet, Time time)
	{
		foreach (PlanetName item in PlanetsAspectingPlanet(inputPlanet, time))
		{
			PlanetToPlanetRelationship planetToPlanetRelationship = PlanetCombinedRelationshipWithPlanet(inputPlanet, item, time);
			if (planetToPlanetRelationship == PlanetToPlanetRelationship.Enemy || planetToPlanetRelationship == PlanetToPlanetRelationship.BitterEnemy)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsPlanetAspectedByFriendPlanets(PlanetName inputPlanet, Time time)
	{
		foreach (PlanetName item in PlanetsAspectingPlanet(inputPlanet, time))
		{
			PlanetToPlanetRelationship planetToPlanetRelationship = PlanetCombinedRelationshipWithPlanet(inputPlanet, item, time);
			if (planetToPlanetRelationship == PlanetToPlanetRelationship.Friend || planetToPlanetRelationship == PlanetToPlanetRelationship.BestFriend)
			{
				return true;
			}
		}
		return false;
	}

	public static ZodiacName ArudhaLagnaSign(Time time)
	{
		ZodiacName startSign = HouseSignName(HouseName.House1, time);
		ZodiacName signName = PlanetZodiacSign(LordOfHouse(HouseName.House1, time), time).GetSignName();
		int countToNextSign = CountFromSignToSign(startSign, signName);
		return SignCountedFromInputSign(signName, countToNextSign);
	}

	public static int CountFromSignToSign(ZodiacName startSign, ZodiacName endSign)
	{
		int result = 0;
		if (startSign > endSign)
		{
			int num = (int)(12 - startSign + 1);
			result = (int)(endSign + num);
		}
		else if (startSign == endSign)
		{
			result = 1;
		}
		else if (startSign < endSign)
		{
			result = endSign - startSign + 1;
		}
		return result;
	}

	public static int CountFromConstellationToConstellation(Constellation start, Constellation end)
	{
		int constellationNumber = end.GetConstellationNumber();
		int constellationNumber2 = start.GetConstellationNumber();
		int result = 0;
		if (constellationNumber2 > constellationNumber)
		{
			int num = 27 - constellationNumber2 + 1;
			result = constellationNumber + num;
		}
		else if (constellationNumber2 == constellationNumber)
		{
			result = 1;
		}
		else if (constellationNumber2 < constellationNumber)
		{
			result = constellationNumber - constellationNumber2 + 1;
		}
		return result;
	}

	public static bool IsPlanetInHouse(PlanetName planet, HouseName houseNumber, Time time)
	{
		return HousePlanetOccupies(planet, time) == houseNumber;
	}

	public static bool IsPlanetInHouseKP(Dictionary<HouseName, Angle> cusps, Angle planetNirayanaDegrees, HouseName house)
	{
		if (house >= HouseName.Empty && (int)house < cusps.Count)
		{
			if ((int)(house + 1) < cusps.Count && cusps[house + 1] > cusps[house])
			{
				if (planetNirayanaDegrees.TotalDegrees >= cusps[house].TotalDegrees)
				{
					return planetNirayanaDegrees.TotalDegrees <= cusps[house + 1].TotalDegrees;
				}
				return false;
			}
			if ((int)(house + 1) < cusps.Count)
			{
				if (!(planetNirayanaDegrees.TotalDegrees >= cusps[house].TotalDegrees))
				{
					return planetNirayanaDegrees.TotalDegrees <= cusps[house + 1].TotalDegrees;
				}
				return true;
			}
			return planetNirayanaDegrees.TotalDegrees >= cusps[house].TotalDegrees;
		}
		return false;
	}

	public static bool IsAllPlanetInHouse(List<PlanetName> planetList, HouseName houseNumber, Time time)
	{
		foreach (PlanetName planet in planetList)
		{
			if (!IsPlanetInHouse(planet, houseNumber, time))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsAnyPlanetInHouse(List<PlanetName> planetList, HouseName houseNumber, Time time)
	{
		foreach (PlanetName planet in planetList)
		{
			if (IsPlanetInHouse(planet, houseNumber, time))
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsPlanetDebilitated(PlanetName planet, Time time)
	{
		ZodiacSign zodiacSign = ZodiacSignAtLongitude(PlanetNirayanaLongitude(planet, time));
		ZodiacSign zodiacSign2 = PlanetDebilitationPoint(planet);
		bool num = zodiacSign.GetSignName() == zodiacSign2.GetSignName();
		bool flag = zodiacSign.GetDegreesInSign().Degrees == zodiacSign2.GetDegreesInSign().Degrees;
		return num & flag;
	}

	public static bool IsPlanetExalted(PlanetName planet, Time time)
	{
		ZodiacSign zodiacSign = ZodiacSignAtLongitude(PlanetNirayanaLongitude(planet, time));
		ZodiacSign zodiacSign2 = PlanetExaltationPoint(planet);
		bool num = zodiacSign.GetSignName() == zodiacSign2.GetSignName();
		bool flag = zodiacSign.GetDegreesInSign().Degrees == zodiacSign2.GetDegreesInSign().Degrees;
		return num & flag;
	}

	public static bool IsFullMoon(Time time)
	{
		return LunarDay(time).GetLunarDayNumber() == 15;
	}

	public static bool IsNewMoon(Time time)
	{
		int lunarDayNumber = LunarDay(time).GetLunarDayNumber();
		if (lunarDayNumber != 1)
		{
			return lunarDayNumber == 0;
		}
		return true;
	}

	public static bool IsWaterSign(ZodiacName moonSign)
	{
		if (moonSign == ZodiacName.Cancer || moonSign == ZodiacName.Scorpio || moonSign == ZodiacName.Pisces)
		{
			return true;
		}
		return false;
	}

	public static bool IsFireSign(ZodiacName moonSign)
	{
		if (moonSign == ZodiacName.Aries || moonSign == ZodiacName.Leo || moonSign == ZodiacName.Sagittarius)
		{
			return true;
		}
		return false;
	}

	public static bool IsEarthSign(ZodiacName moonSign)
	{
		if (moonSign == ZodiacName.Taurus || moonSign == ZodiacName.Virgo || moonSign == ZodiacName.Capricorn)
		{
			return true;
		}
		return false;
	}

	public static bool IsAirSign(ZodiacName moonSign)
	{
		if (moonSign == ZodiacName.Gemini || moonSign == ZodiacName.Libra || moonSign == ZodiacName.Aquarius)
		{
			return true;
		}
		return false;
	}

	public static EventNature PlanetAntaramNature(Person person, PlanetName planet)
	{
		if (planet == PlanetName.Rahu || planet == PlanetName.Ketu)
		{
			return EventNature.Neutral;
		}
		EventNature eventNature = GetNatureFromLagna();
		if (eventNature == EventNature.Neutral)
		{
			switch (PlanetRelationshipWithHouse(HousePlanetOccupies(planet, person.BirthTime), planet, person.BirthTime))
			{
			case PlanetToSignRelationship.OwnVarga:
			case PlanetToSignRelationship.BestFriendVarga:
			case PlanetToSignRelationship.FriendVarga:
			case PlanetToSignRelationship.Moolatrikona:
				return EventNature.Good;
			case PlanetToSignRelationship.NeutralVarga:
				return EventNature.Neutral;
			case PlanetToSignRelationship.EnemyVarga:
			case PlanetToSignRelationship.BitterEnemyVarga:
				return EventNature.Bad;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		return eventNature;
		EventNature GetNatureFromLagna()
		{
			dynamic val = GetPlanetData(HouseSignName(HouseName.House1, person.BirthTime));
			List<PlanetName> list = val.Good;
			List<PlanetName> list2 = val.Bad;
			if (list.Contains(planet))
			{
				return EventNature.Good;
			}
			if (list2.Contains(planet))
			{
				return EventNature.Bad;
			}
			return EventNature.Neutral;
		}
		static object GetPlanetData(ZodiacName lagna)
		{
			List<PlanetName> list = null;
			List<PlanetName> list2 = null;
			switch (lagna)
			{
			case ZodiacName.Aries:
				list = new List<PlanetName>
				{
					PlanetName.Jupiter,
					PlanetName.Sun
				};
				list2 = new List<PlanetName>
				{
					PlanetName.Saturn,
					PlanetName.Mercury,
					PlanetName.Venus
				};
				break;
			case ZodiacName.Taurus:
				list = new List<PlanetName> { PlanetName.Saturn };
				list2 = new List<PlanetName>
				{
					PlanetName.Jupiter,
					PlanetName.Venus,
					PlanetName.Moon
				};
				break;
			case ZodiacName.Gemini:
				list = new List<PlanetName> { PlanetName.Venus };
				list2 = new List<PlanetName>
				{
					PlanetName.Mars,
					PlanetName.Jupiter,
					PlanetName.Sun
				};
				break;
			case ZodiacName.Cancer:
				list = new List<PlanetName>
				{
					PlanetName.Jupiter,
					PlanetName.Mars
				};
				list2 = new List<PlanetName>
				{
					PlanetName.Venus,
					PlanetName.Mercury
				};
				break;
			case ZodiacName.Leo:
				list = new List<PlanetName> { PlanetName.Mars };
				list2 = new List<PlanetName>
				{
					PlanetName.Saturn,
					PlanetName.Venus,
					PlanetName.Mercury
				};
				break;
			case ZodiacName.Virgo:
				list = new List<PlanetName> { PlanetName.Venus };
				list2 = new List<PlanetName>
				{
					PlanetName.Mars,
					PlanetName.Moon
				};
				break;
			case ZodiacName.Libra:
				list = new List<PlanetName>
				{
					PlanetName.Saturn,
					PlanetName.Mercury
				};
				list2 = new List<PlanetName>
				{
					PlanetName.Jupiter,
					PlanetName.Sun,
					PlanetName.Mars
				};
				break;
			case ZodiacName.Scorpio:
				list = new List<PlanetName> { PlanetName.Jupiter };
				list2 = new List<PlanetName>
				{
					PlanetName.Mercury,
					PlanetName.Venus
				};
				break;
			case ZodiacName.Sagittarius:
				list = new List<PlanetName> { PlanetName.Mars };
				list2 = new List<PlanetName> { PlanetName.Venus };
				break;
			case ZodiacName.Capricorn:
				list = new List<PlanetName> { PlanetName.Venus };
				list2 = new List<PlanetName>
				{
					PlanetName.Mars,
					PlanetName.Jupiter,
					PlanetName.Moon
				};
				break;
			case ZodiacName.Aquarius:
				list = new List<PlanetName> { PlanetName.Venus };
				list2 = new List<PlanetName>
				{
					PlanetName.Jupiter,
					PlanetName.Moon
				};
				break;
			case ZodiacName.Pisces:
				list = new List<PlanetName>
				{
					PlanetName.Moon,
					PlanetName.Mars
				};
				list2 = new List<PlanetName>
				{
					PlanetName.Saturn,
					PlanetName.Venus,
					PlanetName.Sun,
					PlanetName.Mercury
				};
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return new
			{
				Good = list,
				Bad = list2
			};
		}
	}

	public static bool IsPlanetBeneficToLagna(PlanetName planetName, ZodiacName lagna)
	{
		switch (lagna)
		{
		case ZodiacName.Aries:
			if (!(planetName == PlanetName.Sun) && !(planetName == PlanetName.Mars))
			{
				return planetName == PlanetName.Jupiter;
			}
			return true;
		case ZodiacName.Taurus:
			if (!(planetName == PlanetName.Sun) && !(planetName == PlanetName.Mars) && !(planetName == PlanetName.Mercury))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Gemini:
			if (!(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Cancer:
			if (!(planetName == PlanetName.Mars))
			{
				return planetName == PlanetName.Jupiter;
			}
			return true;
		case ZodiacName.Leo:
			if (!(planetName == PlanetName.Sun))
			{
				return planetName == PlanetName.Mars;
			}
			return true;
		case ZodiacName.Virgo:
			return planetName == PlanetName.Venus;
		case ZodiacName.Libra:
			if (!(planetName == PlanetName.Mercury) && !(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Scorpio:
			if (!(planetName == PlanetName.Jupiter) && !(planetName == PlanetName.Sun))
			{
				return planetName == PlanetName.Moon;
			}
			return true;
		case ZodiacName.Sagittarius:
			if (!(planetName == PlanetName.Sun))
			{
				return planetName == PlanetName.Mars;
			}
			return true;
		case ZodiacName.Capricorn:
			if (!(planetName == PlanetName.Mercury) && !(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Aquarius:
			if (!(planetName == PlanetName.Venus) && !(planetName == PlanetName.Mars) && !(planetName == PlanetName.Sun))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Pisces:
			if (!(planetName == PlanetName.Mars))
			{
				return planetName == PlanetName.Moon;
			}
			return true;
		default:
			throw new InvalidOperationException();
		}
	}

	public static bool IsPlanetMaleficToLagna(PlanetName planetName, ZodiacName lagna)
	{
		switch (lagna)
		{
		case ZodiacName.Aries:
			if (!(planetName == PlanetName.Venus) && !(planetName == PlanetName.Mercury))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Taurus:
			if (!(planetName == PlanetName.Moon) && !(planetName == PlanetName.Jupiter))
			{
				return planetName == PlanetName.Venus;
			}
			return true;
		case ZodiacName.Gemini:
			if (!(planetName == PlanetName.Sun) && !(planetName == PlanetName.Mars))
			{
				return planetName == PlanetName.Jupiter;
			}
			return true;
		case ZodiacName.Cancer:
			if (!(planetName == PlanetName.Mercury) && !(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Leo:
			if (!(planetName == PlanetName.Mercury) && !(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Virgo:
			if (!(planetName == PlanetName.Mars) && !(planetName == PlanetName.Moon))
			{
				return planetName == PlanetName.Jupiter;
			}
			return true;
		case ZodiacName.Libra:
			if (!(planetName == PlanetName.Sun) && !(planetName == PlanetName.Moon))
			{
				return planetName == PlanetName.Jupiter;
			}
			return true;
		case ZodiacName.Scorpio:
			if (!(planetName == PlanetName.Mercury))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Sagittarius:
			if (!(planetName == PlanetName.Saturn) && !(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Mercury;
			}
			return true;
		case ZodiacName.Capricorn:
			if (!(planetName == PlanetName.Moon) && !(planetName == PlanetName.Mars))
			{
				return planetName == PlanetName.Jupiter;
			}
			return true;
		case ZodiacName.Aquarius:
			if (!(planetName == PlanetName.Jupiter))
			{
				return planetName == PlanetName.Moon;
			}
			return true;
		case ZodiacName.Pisces:
			if (!(planetName == PlanetName.Sun) && !(planetName == PlanetName.Mercury) && !(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		default:
			throw new InvalidOperationException();
		}
	}

	public static bool IsPlanetYogakarakaToLagna(PlanetName planetName, ZodiacName lagna)
	{
		return false;
	}

	public static bool IsPlanetMarakaToLagna(PlanetName planetName, ZodiacName lagna)
	{
		switch (lagna)
		{
		case ZodiacName.Aries:
			if (!(planetName == PlanetName.Mercury))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Taurus:
			if (!(planetName == PlanetName.Jupiter))
			{
				return planetName == PlanetName.Venus;
			}
			return true;
		case ZodiacName.Gemini:
			if (!(planetName == PlanetName.Mars))
			{
				return planetName == PlanetName.Jupiter;
			}
			return true;
		case ZodiacName.Cancer:
			if (!(planetName == PlanetName.Mercury))
			{
				return planetName == PlanetName.Venus;
			}
			return true;
		case ZodiacName.Leo:
			if (!(planetName == PlanetName.Mercury))
			{
				return planetName == PlanetName.Venus;
			}
			return true;
		case ZodiacName.Virgo:
			if (!(planetName == PlanetName.Mars))
			{
				return planetName == PlanetName.Jupiter;
			}
			return true;
		case ZodiacName.Libra:
			return planetName == PlanetName.Jupiter;
		case ZodiacName.Scorpio:
			if (!(planetName == PlanetName.Mercury) && !(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Sagittarius:
			if (!(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		case ZodiacName.Capricorn:
			if (!(planetName == PlanetName.Mars))
			{
				return planetName == PlanetName.Jupiter;
			}
			return true;
		case ZodiacName.Aquarius:
			return planetName == PlanetName.Mars;
		case ZodiacName.Pisces:
			if (!(planetName == PlanetName.Mercury) && !(planetName == PlanetName.Venus))
			{
				return planetName == PlanetName.Saturn;
			}
			return true;
		default:
			throw new InvalidOperationException();
		}
	}

	public static bool IsPlanetInOwnHouse(PlanetName planetName, Time time)
	{
		bool num = planetName == PlanetName.Rahu || planetName == PlanetName.Ketu;
		HouseName house = HousePlanetOccupies(planetName, time);
		if (((!num) ? PlanetRelationshipWithHouse(house, planetName, time) : PlanetToSignRelationship.Empty) == PlanetToSignRelationship.OwnVarga)
		{
			return true;
		}
		return false;
	}

	public static bool IsPlanetInEnemyHouse(PlanetName planetName, Time time)
	{
		bool num = planetName == PlanetName.Rahu || planetName == PlanetName.Ketu;
		HouseName house = HousePlanetOccupies(planetName, time);
		PlanetToSignRelationship num2 = ((!num) ? PlanetRelationshipWithHouse(house, planetName, time) : PlanetToSignRelationship.Empty);
		bool flag = num2 == PlanetToSignRelationship.EnemyVarga;
		bool flag2 = num2 == PlanetToSignRelationship.BitterEnemyVarga;
		if (flag | flag2)
		{
			return true;
		}
		return false;
	}

	public static bool IsPlanetInFriendHouse(PlanetName planetName, Time time)
	{
		bool num = planetName == PlanetName.Rahu || planetName == PlanetName.Ketu;
		HouseName house = HousePlanetOccupies(planetName, time);
		PlanetToSignRelationship num2 = ((!num) ? PlanetRelationshipWithHouse(house, planetName, time) : PlanetToSignRelationship.Empty);
		bool flag = num2 == PlanetToSignRelationship.EnemyVarga;
		bool flag2 = num2 == PlanetToSignRelationship.BitterEnemyVarga;
		if (flag | flag2)
		{
			return true;
		}
		return false;
	}

	public static dynamic SwissEphemeris(PlanetName planetName, Time time)
	{
		int swissPlanet = Tools.VedAstroToSwissEph(planetName);
		return Tools.ephemeris_swe_calc(time, swissPlanet);
	}

	public static List<dynamic> SwissEphemerisAll(Time time)
	{
		List<int> obj = new List<int>
		{
			0, 1, 2, 4, 3, 5, 6, 7, 8, 9,
			11, 13
		};
		List<object> list = new List<object>();
		foreach (int item in obj)
		{
			dynamic val = Tools.ephemeris_swe_calc(time, item);
			list.Add(val);
		}
		return list;
	}

	public static bool IsPlanetSameHouseWithHouseLord(int houseNumber, PlanetName planet, Time birthTime)
	{
		HouseName houseName = HousePlanetOccupies(LordOfHouse((HouseName)houseNumber, birthTime), birthTime);
		if (HousePlanetOccupies(planet, birthTime) == houseName)
		{
			return true;
		}
		return false;
	}

	public static int HouseNatureScore(HouseName inputHouse, Time personBirthTime)
	{
		if (inputHouse == HouseName.Empty)
		{
			return 0;
		}
		double num = HouseStrength(inputHouse, personBirthTime).ToDouble();
		if (!(num > 550.0))
		{
			if (!(num >= 450.0))
			{
				if (!(num < 250.0))
				{
					if (!(num < 350.0))
					{
						if (num < 450.0)
						{
							return -1;
						}
						throw new Exception("No Strength Power defined!");
					}
					return -2;
				}
				return -3;
			}
			return 1;
		}
		return 2;
	}

	public static double HouseNatureScoreMK4(Time personBirthTime, HouseName inputHouse)
	{
		if (inputHouse == HouseName.Empty)
		{
			return 0.0;
		}
		double num = HouseStrength(inputHouse, personBirthTime).ToDouble();
		double fromMax = HouseStrength(AllHousesOrderedByStrength(personBirthTime)[0], personBirthTime).ToDouble();
		double fromMin = HouseStrength(AllHousesOrderedByStrength(personBirthTime)[11], personBirthTime).ToDouble();
		return num.Remap(fromMin, fromMax, -3.0, 3.0);
	}

	public static double PlanetNatureScoreMK4(Time personBirthTime, PlanetName inputPlanet)
	{
		if (inputPlanet == PlanetName.Empty)
		{
			return 0.0;
		}
		return IsPlanetStrongInShadbala(inputPlanet, personBirthTime) ? 1 : (-1);
	}

	public static int PlanetNatureScore(Time personBirthTime, PlanetName inputPlanet)
	{
		double num = PlanetShadbalaPinda(inputPlanet, personBirthTime).ToDouble();
		if (!(num > 550.0))
		{
			if (!(num >= 450.0))
			{
				if (!(num < 250.0))
				{
					if (!(num < 350.0))
					{
						if (num < 450.0)
						{
							return -1;
						}
						throw new Exception("No Strength Power defined!");
					}
					return -2;
				}
				return -3;
			}
			return 1;
		}
		return 2;
	}

	public static Varna BirthVarna(Time birthTime)
	{
		return GetGrade(PlanetZodiacSign(PlanetName.Moon, birthTime).GetSignName());
		static Varna GetGrade(ZodiacName sign)
		{
			switch (sign)
			{
			case ZodiacName.Cancer:
			case ZodiacName.Scorpio:
			case ZodiacName.Pisces:
				return Varna.BrahminScholar;
			case ZodiacName.Leo:
			case ZodiacName.Libra:
			case ZodiacName.Sagittarius:
				return Varna.KshatriyaWarrior;
			case ZodiacName.Aries:
			case ZodiacName.Gemini:
			case ZodiacName.Aquarius:
				return Varna.VaisyaWorkmen;
			case ZodiacName.Taurus:
			case ZodiacName.Virgo:
			case ZodiacName.Capricorn:
				return Varna.SudraServant;
			default:
				throw new Exception("");
			}
		}
	}

	public static double PlanetIshtaKashtaScore(PlanetName planet, Time birthTime)
	{
		double num = PlanetIshtaScore(planet, birthTime);
		double num2 = PlanetKashtaScore(planet, birthTime);
		return (num > num2) ? 1 : (-1);
	}

	public static double PlanetIshtaKashtaScoreDegree(PlanetName planet, Time birthTime)
	{
		double num = PlanetIshtaScore(planet, birthTime);
		double num2 = PlanetKashtaScore(planet, birthTime);
		bool num3 = num > num2;
		double num4 = (num3 ? num : num2);
		double num5 = Math.Abs(num - num2) / num4 * 100.0;
		double num6 = 0.0;
		num6 = ((!num3) ? num5.Remap(0.0, 100.0, -4.0, 0.0) : num5.Remap(0.0, 100.0, 0.0, 4.0));
		return Math.Round(num6, 3);
	}

	public static double PlanetKashtaScore(PlanetName planet, Time birthTime)
	{
		double num = PlanetOchchaBala(planet, birthTime).ToDouble();
		double num2 = PlanetChestaBala(planet, birthTime, useSpecialSunMoon: true).ToDouble();
		return Math.Sqrt((60.0 - num) * (60.0 - num2));
	}

	public static double PlanetIshtaScore(PlanetName planet, Time birthTime)
	{
		double num = PlanetOchchaBala(planet, birthTime).ToDouble();
		double num2 = PlanetChestaBala(planet, birthTime, useSpecialSunMoon: true).ToDouble();
		return Math.Sqrt(num * num2);
	}

	public static List<PlanetName> AllPlanetsSignsFromPlanet(int signsFromMoon, PlanetName startPlanet, Time birthTime)
	{
		return PlanetsInSign(SignCountedFromPlanetSign(signsFromMoon, startPlanet, birthTime), birthTime);
	}

	public static List<PlanetName> AllPlanetsInASignFromLagna(int signsFromLagna, Time birthTime)
	{
		return PlanetsInSign(SignCountedFromLagnaSign(signsFromLagna, birthTime), birthTime);
	}

	public static List<PlanetName> AllPlanetsSignsFromPlanet(int[] signsFromList, PlanetName startPlanet, Time birthTime)
	{
		List<PlanetName> list = new List<PlanetName>();
		for (int i = 0; i < signsFromList.Length; i++)
		{
			List<PlanetName> collection = AllPlanetsSignsFromPlanet(signsFromList[i], startPlanet, birthTime);
			list.AddRange(collection);
		}
		return list.Distinct().ToList();
	}

	public static List<PlanetName> AllPlanetsSignsFromPlanet(int[] signsFromList, Time birthTime, PlanetName startPlanet)
	{
		List<PlanetName> list = new List<PlanetName>();
		for (int i = 0; i < signsFromList.Length; i++)
		{
			List<PlanetName> collection = AllPlanetsSignsFromPlanet(signsFromList[i], birthTime, startPlanet);
			list.AddRange(collection);
		}
		return list.Distinct().ToList();
	}

	public static List<PlanetName> AllPlanetsSignsFromPlanet(int signsFromMoon, Time birthTime, PlanetName startPlanet)
	{
		return PlanetsInSign(SignCountedFromPlanetSign(signsFromMoon, birthTime, startPlanet), birthTime);
	}

	public static List<PlanetName> AllPlanetsInSignsFromLagna(int[] signsFromList, Time birthTime)
	{
		List<PlanetName> list = new List<PlanetName>();
		for (int i = 0; i < signsFromList.Length; i++)
		{
			List<PlanetName> collection = AllPlanetsInASignFromLagna(signsFromList[i], birthTime);
			list.AddRange(collection);
		}
		return list.Distinct().ToList();
	}

	public static bool IsPlanetsInSignsFromPlanet(int[] signsFromList, PlanetName[] planetList, PlanetName startPlanet, Time birthTime)
	{
		List<PlanetName> list = AllPlanetsSignsFromPlanet(signsFromList, birthTime, startPlanet);
		bool result = false;
		foreach (PlanetName item in list)
		{
			if (Enumerable.Contains(planetList, item))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public static bool IsPlanetsInSignsFromLagna(int[] signsFromList, PlanetName[] planetList, Time birthTime)
	{
		List<PlanetName> list = AllPlanetsInSignsFromLagna(signsFromList, birthTime);
		bool result = false;
		foreach (PlanetName item in list)
		{
			if (Enumerable.Contains(planetList, item))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public static bool IsBeneficsInSignsFromPlanet(int[] signsFromList, PlanetName startPlanet, Time birthTime)
	{
		PlanetName[] planetList = BeneficPlanetList(birthTime).ToArray();
		return IsPlanetsInSignsFromPlanet(signsFromList, planetList, startPlanet, birthTime);
	}

	public static bool IsBeneficsInSignsFromLagna(int[] signsFromList, Time birthTime)
	{
		PlanetName[] planetList = BeneficPlanetList(birthTime).ToArray();
		return IsPlanetsInSignsFromLagna(signsFromList, planetList, birthTime);
	}

	public static Angle DhumaLongitude(Time time)
	{
		Angle angle = PlanetNirayanaLongitude(PlanetName.Sun, time);
		return (new Angle(133.0, 20.0, 0L) + angle).Expunge360();
	}

	public static Angle VyatipaataLongitude(Time time)
	{
		Angle angle = DhumaLongitude(time);
		return (Angle.Degrees360 - angle).Expunge360();
	}

	public static Angle PariveshaLongitude(Time time)
	{
		return (VyatipaataLongitude(time) + Angle.Degrees180).Expunge360();
	}

	public static Angle IndrachaapaLongitude(Time time)
	{
		Angle angle = PariveshaLongitude(time);
		return (Angle.Degrees360 - angle).Expunge360();
	}

	public static Angle UpaketuLongitude(Time time)
	{
		Angle angle = IndrachaapaLongitude(time);
		Angle angle2 = new Angle(16.0, 40.0, 0L);
		return (angle + angle2).Expunge360();
	}

	public static Angle KaalaLongitude(Time time)
	{
		return UpagrahaLongitude(time, PlanetName.PlanetNameEnum.Sun, "middle");
	}

	public static Angle MrityuLongitude(Time time)
	{
		return UpagrahaLongitude(time, PlanetName.PlanetNameEnum.Mars, "middle");
	}

	public static Angle ArthaprahaaraLongitude(Time time)
	{
		return UpagrahaLongitude(time, PlanetName.PlanetNameEnum.Mercury, "middle");
	}

	public static Angle YamaghantakaLongitude(Time time)
	{
		return UpagrahaLongitude(time, PlanetName.PlanetNameEnum.Jupiter, "middle");
	}

	public static Angle GulikaLongitude(Time time)
	{
		return UpagrahaLongitude(time, PlanetName.PlanetNameEnum.Saturn, "begin");
	}

	public static Angle MaandiLongitude(Time time)
	{
		return UpagrahaLongitude(time, PlanetName.PlanetNameEnum.Saturn, "middle");
	}

	public static Angle UpagrahaLongitude(Time time, PlanetName.PlanetNameEnum relatedPlanet, string upagrahaPart)
	{
		int num = UpagrahaPartNumber(time, relatedPlanet);
		bool flag = IsDayBirth(time);
		int num2 = num - 1;
		double num3 = DayDurationHours(time) / 8.0;
		House house;
		if (flag)
		{
			double granularityHours = (double)num2 * num3;
			Time time2 = SunriseTime(time).AddHours(granularityHours);
			double granularityHours2 = num3 / 2.0;
			Time time3 = time2.AddHours(granularityHours2);
			Time time4;
			if (!(upagrahaPart == "middle"))
			{
				if (!(upagrahaPart == "begin"))
				{
					throw new Exception("END OF LINE!");
				}
				time4 = time2;
			}
			else
			{
				time4 = time3;
			}
			house = (from x in AllHouseMiddleLongitudes(time4)
				where x.GetHouseName() == HouseName.House1
				select x).First();
		}
		else
		{
			double granularityHours3 = (double)num2 * num3;
			Time time5 = SunsetTime(time).AddHours(granularityHours3);
			double granularityHours4 = num3 / 2.0;
			Time time6 = time5.AddHours(granularityHours4);
			Time time7;
			if (!(upagrahaPart == "middle"))
			{
				if (!(upagrahaPart == "begin"))
				{
					throw new Exception("END OF LINE!");
				}
				time7 = time5;
			}
			else
			{
				time7 = time6;
			}
			house = (from x in AllHouseMiddleLongitudes(time7)
				where x.GetHouseName() == HouseName.House1
				select x).First();
		}
		return house.GetMiddleLongitude();
	}

	public static int UpagrahaPartNumber(Time inputTime, PlanetName.PlanetNameEnum inputPlanet)
	{
		if (IsDayBirth(inputTime))
		{
			return UpagrahaPartNumberDayBirth(inputTime, inputPlanet);
		}
		return UpagrahaPartNumberNightBirth(inputTime, inputPlanet);
		static int UpagrahaPartNumberDayBirth(Time time, PlanetName.PlanetNameEnum key2)
		{
			DayOfWeek key = DayOfWeek(time);
			if (new Dictionary<DayOfWeek, Dictionary<PlanetName.PlanetNameEnum, int>>
			{
				{
					VedAstro.Library.DayOfWeek.Sunday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Sun,
							1
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							2
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							3
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							4
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							5
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							6
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							7
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Monday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Moon,
							1
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							2
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							3
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							4
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							5
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							6
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							7
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Tuesday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Mars,
							1
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							2
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							3
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							4
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							5
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							6
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							7
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Wednesday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Mercury,
							1
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							2
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							3
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							4
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							5
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							6
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							7
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Thursday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Jupiter,
							1
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							2
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							3
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							4
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							5
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							6
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							7
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Friday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Venus,
							1
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							2
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							3
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							4
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							5
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							6
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							7
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Saturday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Saturn,
							1
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							2
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							3
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							4
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							5
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							6
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							7
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							8
						}
					}
				}
			}.TryGetValue(key, out var value))
			{
				if (value.TryGetValue(key2, out var value2))
				{
					return value2;
				}
				throw new Exception("Invalid planet name");
			}
			throw new Exception("Invalid day of week");
		}
		static int UpagrahaPartNumberNightBirth(Time time, PlanetName.PlanetNameEnum key2)
		{
			DayOfWeek key = DayOfWeek(time);
			if (new Dictionary<DayOfWeek, Dictionary<PlanetName.PlanetNameEnum, int>>
			{
				{
					VedAstro.Library.DayOfWeek.Sunday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Jupiter,
							1
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							2
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							3
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							4
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							5
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							6
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							7
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Monday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Venus,
							1
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							2
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							3
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							4
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							5
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							6
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							7
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Tuesday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Saturn,
							1
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							2
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							3
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							4
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							5
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							6
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							7
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Wednesday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Sun,
							1
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							2
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							3
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							4
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							5
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							6
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							7
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Thursday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Moon,
							1
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							2
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							3
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							4
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							5
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							6
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							7
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Friday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Mars,
							1
						},
						{
							PlanetName.PlanetNameEnum.Mercury,
							2
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							3
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							4
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							5
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							6
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							7
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							8
						}
					}
				},
				{
					VedAstro.Library.DayOfWeek.Saturday,
					new Dictionary<PlanetName.PlanetNameEnum, int>
					{
						{
							PlanetName.PlanetNameEnum.Mercury,
							1
						},
						{
							PlanetName.PlanetNameEnum.Jupiter,
							2
						},
						{
							PlanetName.PlanetNameEnum.Venus,
							3
						},
						{
							PlanetName.PlanetNameEnum.Saturn,
							4
						},
						{
							PlanetName.PlanetNameEnum.Empty,
							5
						},
						{
							PlanetName.PlanetNameEnum.Sun,
							6
						},
						{
							PlanetName.PlanetNameEnum.Moon,
							7
						},
						{
							PlanetName.PlanetNameEnum.Mars,
							8
						}
					}
				}
			}.TryGetValue(key, out var value))
			{
				if (value.TryGetValue(key2, out var value2))
				{
					return value2;
				}
				throw new Exception("Invalid planet name");
			}
			throw new Exception("Invalid day of week");
		}
	}

	public static bool IsUpagraha(PlanetName planet)
	{
		PlanetName.PlanetNameEnum name = planet.Name;
		if ((uint)(name - 11) <= 10u)
		{
			return true;
		}
		return false;
	}

	public static double Nutation(Time time)
	{
		SwissEph swissEph = new SwissEph();
		double[] array = new double[6];
		string serr = "";
		double tjd = TimeToJulianDay(time);
		swissEph.swe_calc(tjd, -1, 0, array, ref serr);
		return array[2];
	}

	public static double AscendantDegreesToARMC(double ascendant, double obliquityOfEcliptic, double geographicLatitude, Time time)
	{
		double num = 6.64;
		double num2 = 4.98 - Math.Asin(Math.Tan(num * Math.PI / 180.0) * Math.Tan(geographicLatitude * Math.PI / 180.0)) * 180.0 / Math.PI;
		double result = 0.0;
		if (ascendant >= 0.0 && ascendant < 90.0)
		{
			result = 270.0 + num2;
		}
		else if (ascendant >= 90.0 && ascendant < 180.0)
		{
			result = 90.0 + num2;
		}
		else if (ascendant >= 180.0 && ascendant < 270.0)
		{
			result = 90.0 + num2;
		}
		else if (ascendant >= 270.0 && ascendant < 360.0)
		{
			result = 270.0 + num2;
		}
		return result;
	}

	public static Angle AyanamsaDegree(Time time)
	{
		return CacheManager.GetCache(new CacheKey("AyanamsaDegree", time, Ayanamsa), _getAyanamsaDegree);
		Angle _getAyanamsaDegree()
		{
			int iflag = 65536;
			SwissEph swissEph = new SwissEph();
			double tjd_et = TimeToEphemerisTime(time);
			swissEph.swe_set_sid_mode(Ayanamsa, 0.0, 0.0);
			string serr = "";
			swissEph.swe_get_ayanamsa_ex(tjd_et, iflag, out var daya, ref serr);
			return Angle.FromDegrees(daya);
		}
	}

	public static Angle PlanetSayanaLongitude(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetSayanaLongitude", time, planetName, Ayanamsa), _getPlanetSayanaLongitude);
		Angle _getPlanetSayanaLongitude()
		{
			int iflag = 2;
			double[] array = new double[6];
			string serr = "";
			SwissEph swissEph = new SwissEph();
			double tjd = TimeToEphemerisTime(time);
			int ipl = Tools.VedAstroToSwissEph(planetName);
			swissEph.swe_calc(tjd, ipl, iflag, array, ref serr);
			Angle angle = Angle.FromDegrees(array[0]);
			if (planetName == PlanetName.Ketu)
			{
				angle = (angle + Angle.Degrees180).Expunge360();
			}
			return angle;
		}
	}

	public static Angle PlanetNirayanaLongitude(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetNirayanaLongitude", time, planetName, Ayanamsa, UseMeanRahuKetu), _getPlanetNirayanaLongitude);
		Angle _getPlanetNirayanaLongitude()
		{
			if (IsUpagraha(planetName))
			{
				switch (planetName.Name)
				{
				case PlanetName.PlanetNameEnum.Dhuma:
					return DhumaLongitude(time);
				case PlanetName.PlanetNameEnum.Vyatipaata:
					return VyatipaataLongitude(time);
				case PlanetName.PlanetNameEnum.Parivesha:
					return PariveshaLongitude(time);
				case PlanetName.PlanetNameEnum.Indrachaapa:
					return IndrachaapaLongitude(time);
				case PlanetName.PlanetNameEnum.Upaketu:
					return UpaketuLongitude(time);
				case PlanetName.PlanetNameEnum.Kaala:
					return KaalaLongitude(time);
				case PlanetName.PlanetNameEnum.Mrityu:
					return MrityuLongitude(time);
				case PlanetName.PlanetNameEnum.Arthaprahaara:
					return ArthaprahaaraLongitude(time);
				case PlanetName.PlanetNameEnum.Yamaghantaka:
					return YamaghantakaLongitude(time);
				case PlanetName.PlanetNameEnum.Gulika:
					return GulikaLongitude(time);
				case PlanetName.PlanetNameEnum.Maandi:
					return MaandiLongitude(time);
				}
			}
			int iflag = 65538;
			double[] array = new double[6];
			string serr = "";
			SwissEph swissEph = new SwissEph();
			double tjd = TimeToEphemerisTime(time);
			int ipl = Tools.VedAstroToSwissEph(planetName);
			swissEph.swe_set_sid_mode(Ayanamsa, 0.0, 0.0);
			swissEph.swe_calc(tjd, ipl, iflag, array, ref serr);
			Angle angle = Angle.FromDegrees(array[0]);
			if (planetName == PlanetName.Ketu)
			{
				angle = (angle + Angle.Degrees180).Expunge360();
			}
			return angle;
		}
	}

	public static DateTime NextLunarEclipse(Time time)
	{
		return CacheManager.GetCache(new CacheKey("NextLunarEclipse", time, Ayanamsa), _getNextLunarEclipse);
		DateTime _getNextLunarEclipse()
		{
			int ifl = 2;
			double[] array = new double[10];
			string serr = "";
			SwissEph swissEph = new SwissEph();
			double tjd_start = ConvertLmtToJulian(time);
			int ifltype = 0;
			bool backward = false;
			swissEph.swe_lun_eclipse_when(tjd_start, ifl, ifltype, array, backward, ref serr);
			return ConvertJulianTimeToNormalTime(array[0]);
		}
	}

	public static DateTime NextSolarEclipse(Time time)
	{
		return CacheManager.GetCache(new CacheKey("NextSolarEclipse", time, Ayanamsa), _getNextSolarEclipse);
		DateTime _getNextSolarEclipse()
		{
			int ifl = 2;
			double[] array = new double[10];
			string serr = "";
			SwissEph swissEph = new SwissEph();
			double tjd_start = ConvertLmtToJulian(time);
			int ifltype = 0;
			bool backward = false;
			swissEph.swe_sol_eclipse_when_glob(tjd_start, ifl, ifltype, array, backward, ref serr);
			return ConvertJulianTimeToNormalTime(array[0]);
		}
	}

	public static Angle PlanetEphemerisLongitude(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetEphemerisLongitude", time, planetName, Ayanamsa), _getPlanetSayanaLongitude);
		Angle _getPlanetSayanaLongitude()
		{
			int iflag = 2;
			double[] array = new double[6];
			string serr = "";
			SwissEph swissEph = new SwissEph();
			double tjd = TimeToEphemerisTime(time);
			int ipl = Tools.VedAstroToSwissEph(planetName);
			swissEph.swe_calc(tjd, ipl, iflag, array, ref serr);
			Angle angle = Angle.FromDegrees(array[0]);
			if (planetName == PlanetName.Ketu)
			{
				angle = (angle + Angle.Degrees180).Expunge360();
			}
			return angle;
		}
	}

	public static Angle PlanetSayanaLatitude(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetSayanaLatitude", time, planetName, Ayanamsa), _getPlanetSayanaLatitude);
		Angle _getPlanetSayanaLatitude()
		{
			int ipl = 0;
			int iflag = 2;
			double[] array = new double[6];
			string serr = "";
			SwissEph swissEph = new SwissEph();
			double tjd = TimeToEphemerisTime(time);
			if (planetName == PlanetName.Sun)
			{
				ipl = 0;
			}
			else if (planetName == PlanetName.Moon)
			{
				ipl = 1;
			}
			else if (planetName == PlanetName.Mars)
			{
				ipl = 4;
			}
			else if (planetName == PlanetName.Mercury)
			{
				ipl = 2;
			}
			else if (planetName == PlanetName.Jupiter)
			{
				ipl = 5;
			}
			else if (planetName == PlanetName.Venus)
			{
				ipl = 3;
			}
			else if (planetName == PlanetName.Saturn)
			{
				ipl = 6;
			}
			else if (planetName == PlanetName.Rahu)
			{
				ipl = 10;
			}
			else if (planetName == PlanetName.Ketu)
			{
				ipl = 10;
			}
			swissEph.swe_calc(tjd, ipl, iflag, array, ref serr);
			return Angle.FromDegrees(array[1]);
		}
	}

	public static double PlanetSpeed(PlanetName planetName, Time time)
	{
		int ipl = 0;
		int iflag = 258;
		double[] array = new double[6];
		string serr = "";
		SwissEph swissEph = new SwissEph();
		double tjd = TimeToEphemerisTime(time);
		if (planetName == PlanetName.Sun)
		{
			ipl = 0;
		}
		else if (planetName == PlanetName.Moon)
		{
			ipl = 1;
		}
		else if (planetName == PlanetName.Mars)
		{
			ipl = 4;
		}
		else if (planetName == PlanetName.Mercury)
		{
			ipl = 2;
		}
		else if (planetName == PlanetName.Jupiter)
		{
			ipl = 5;
		}
		else if (planetName == PlanetName.Venus)
		{
			ipl = 3;
		}
		else if (planetName == PlanetName.Saturn)
		{
			ipl = 6;
		}
		else if (planetName == PlanetName.Rahu)
		{
			ipl = 10;
		}
		else if (planetName == PlanetName.Ketu)
		{
			ipl = 10;
		}
		swissEph.swe_calc(tjd, ipl, iflag, array, ref serr);
		return array[3];
	}

	public static Constellation ConstellationAtLongitude(Angle planetLongitude)
	{
		return CacheManager.GetCache(new CacheKey("ConstellationAtLongitude", planetLongitude, Ayanamsa), _constellationAtLongitude);
		Constellation _constellationAtLongitude()
		{
			if (planetLongitude == null)
			{
				return Constellation.Empty;
			}
			if (planetLongitude.TotalDegrees < 0.0)
			{
				planetLongitude = Angle.FromDegrees(360.0 + planetLongitude.TotalDegrees);
			}
			double num = planetLongitude.TotalMinutes / 800.0;
			int num2 = (int)Math.Ceiling(num);
			if (num2 == 0)
			{
				num2 = 1;
			}
			double num3 = num - Math.Floor(num);
			int quarter = ((num3 >= 0.0 && num3 < 0.25) ? 1 : ((num3 >= 0.25 && num3 < 0.5) ? 2 : ((num3 >= 0.5 && num3 < 0.75) ? 3 : ((num3 >= 0.75 && num3 <= 1.0) ? 4 : 0))));
			double num4 = num3 * 800.0;
			Angle degreeInConstellation = new Angle(0.0, num4, 0L);
			Constellation constellation = default(Constellation);
			return (num4 != 0.0) ? new Constellation(num2, quarter, degreeInConstellation) : new Constellation(num2 + 1, quarter, degreeInConstellation);
		}
	}

	public static ZodiacSign ZodiacSignAtLongitude(Angle longitude)
	{
		return CacheManager.GetCache(new CacheKey("ZodiacSignAtLongitude", longitude, Ayanamsa), _zodiacSignAtLongitude);
		ZodiacSign _zodiacSignAtLongitude()
		{
			double num;
			for (num = longitude.TotalDegrees; num < 0.0; num += 360.0)
			{
			}
			double num2 = num % 360.0 / 30.0;
			double value = Math.Round((num2 - Math.Truncate(num2)) * 30.0, 7);
			int num3 = (int)Math.Ceiling(num2);
			if (num == 0.0)
			{
				num3 = 1;
			}
			ZodiacName signName = (ZodiacName)num3;
			Angle degreesInSign = Angle.FromDegrees(Math.Abs(value));
			return new ZodiacSign(signName, degreesInSign);
		}
	}

	public static Angle LongitudeAtZodiacSign(ZodiacSign zodiacSign)
	{
		return CacheManager.GetCache(new CacheKey("LongitudeAtZodiacSign", zodiacSign, Ayanamsa), _getLongitudeAtZodiacSign);
		Angle _getLongitudeAtZodiacSign()
		{
			int num = (int)(zodiacSign.GetSignName() - 1);
			return Angle.FromDegrees(30.0 * (double)num) + zodiacSign.GetDegreesInSign();
		}
	}

	public static DayOfWeek DayOfWeek(Time time)
	{
		return CacheManager.GetCache(new CacheKey("DayOfWeek", time, Ayanamsa), _getDayOfWeek);
		DayOfWeek _getDayOfWeek()
		{
			Time time2 = SunriseTime(time);
			DateTimeOffset lmtDateTimeOffset = SunriseTime(time.AddHours(24.0)).GetLmtDateTimeOffset();
			DateTimeOffset lmtDateTimeOffset2 = time2.GetLmtDateTimeOffset();
			DateTimeOffset lmtDateTimeOffset3 = time.GetLmtDateTimeOffset();
			if (lmtDateTimeOffset3 >= lmtDateTimeOffset2 && lmtDateTimeOffset3 < lmtDateTimeOffset)
			{
				Enum.TryParse<DayOfWeek>(lmtDateTimeOffset3.DayOfWeek.ToString(), out var result);
				return result;
			}
			Enum.TryParse<DayOfWeek>(lmtDateTimeOffset3.AddDays(-1.0).DayOfWeek.ToString(), out var result2);
			return result2;
		}
	}

	public static PlanetName LordOfHoraFromWeekday(int hora, DayOfWeek day)
	{
		switch (day)
		{
		case VedAstro.Library.DayOfWeek.Sunday:
			switch (hora)
			{
			case 1:
				return PlanetName.Sun;
			case 2:
				return PlanetName.Venus;
			case 3:
				return PlanetName.Mercury;
			case 4:
				return PlanetName.Moon;
			case 5:
				return PlanetName.Saturn;
			case 6:
				return PlanetName.Jupiter;
			case 7:
				return PlanetName.Mars;
			case 8:
				return PlanetName.Sun;
			case 9:
				return PlanetName.Venus;
			case 10:
				return PlanetName.Mercury;
			case 11:
				return PlanetName.Moon;
			case 12:
				return PlanetName.Saturn;
			case 13:
				return PlanetName.Jupiter;
			case 14:
				return PlanetName.Mars;
			case 15:
				return PlanetName.Sun;
			case 16:
				return PlanetName.Venus;
			case 17:
				return PlanetName.Mercury;
			case 18:
				return PlanetName.Moon;
			case 19:
				return PlanetName.Saturn;
			case 20:
				return PlanetName.Jupiter;
			case 21:
				return PlanetName.Mars;
			case 22:
				return PlanetName.Sun;
			case 23:
				return PlanetName.Venus;
			case 24:
				return PlanetName.Mercury;
			}
			break;
		case VedAstro.Library.DayOfWeek.Monday:
			switch (hora)
			{
			case 1:
				return PlanetName.Moon;
			case 2:
				return PlanetName.Saturn;
			case 3:
				return PlanetName.Jupiter;
			case 4:
				return PlanetName.Mars;
			case 5:
				return PlanetName.Sun;
			case 6:
				return PlanetName.Venus;
			case 7:
				return PlanetName.Mercury;
			case 8:
				return PlanetName.Moon;
			case 9:
				return PlanetName.Saturn;
			case 10:
				return PlanetName.Jupiter;
			case 11:
				return PlanetName.Mars;
			case 12:
				return PlanetName.Sun;
			case 13:
				return PlanetName.Venus;
			case 14:
				return PlanetName.Mercury;
			case 15:
				return PlanetName.Moon;
			case 16:
				return PlanetName.Saturn;
			case 17:
				return PlanetName.Jupiter;
			case 18:
				return PlanetName.Mars;
			case 19:
				return PlanetName.Sun;
			case 20:
				return PlanetName.Venus;
			case 21:
				return PlanetName.Mercury;
			case 22:
				return PlanetName.Moon;
			case 23:
				return PlanetName.Saturn;
			case 24:
				return PlanetName.Jupiter;
			}
			break;
		case VedAstro.Library.DayOfWeek.Tuesday:
			switch (hora)
			{
			case 1:
				return PlanetName.Mars;
			case 2:
				return PlanetName.Sun;
			case 3:
				return PlanetName.Venus;
			case 4:
				return PlanetName.Mercury;
			case 5:
				return PlanetName.Moon;
			case 6:
				return PlanetName.Saturn;
			case 7:
				return PlanetName.Jupiter;
			case 8:
				return PlanetName.Mars;
			case 9:
				return PlanetName.Sun;
			case 10:
				return PlanetName.Venus;
			case 11:
				return PlanetName.Mercury;
			case 12:
				return PlanetName.Moon;
			case 13:
				return PlanetName.Saturn;
			case 14:
				return PlanetName.Jupiter;
			case 15:
				return PlanetName.Mars;
			case 16:
				return PlanetName.Sun;
			case 17:
				return PlanetName.Venus;
			case 18:
				return PlanetName.Mercury;
			case 19:
				return PlanetName.Moon;
			case 20:
				return PlanetName.Saturn;
			case 21:
				return PlanetName.Jupiter;
			case 22:
				return PlanetName.Mars;
			case 23:
				return PlanetName.Sun;
			case 24:
				return PlanetName.Venus;
			}
			break;
		case VedAstro.Library.DayOfWeek.Wednesday:
			switch (hora)
			{
			case 1:
				return PlanetName.Mercury;
			case 2:
				return PlanetName.Moon;
			case 3:
				return PlanetName.Saturn;
			case 4:
				return PlanetName.Jupiter;
			case 5:
				return PlanetName.Mars;
			case 6:
				return PlanetName.Sun;
			case 7:
				return PlanetName.Venus;
			case 8:
				return PlanetName.Mercury;
			case 9:
				return PlanetName.Moon;
			case 10:
				return PlanetName.Saturn;
			case 11:
				return PlanetName.Jupiter;
			case 12:
				return PlanetName.Mars;
			case 13:
				return PlanetName.Sun;
			case 14:
				return PlanetName.Venus;
			case 15:
				return PlanetName.Mercury;
			case 16:
				return PlanetName.Moon;
			case 17:
				return PlanetName.Saturn;
			case 18:
				return PlanetName.Jupiter;
			case 19:
				return PlanetName.Mars;
			case 20:
				return PlanetName.Sun;
			case 21:
				return PlanetName.Venus;
			case 22:
				return PlanetName.Mercury;
			case 23:
				return PlanetName.Moon;
			case 24:
				return PlanetName.Saturn;
			}
			break;
		case VedAstro.Library.DayOfWeek.Thursday:
			switch (hora)
			{
			case 1:
				return PlanetName.Jupiter;
			case 2:
				return PlanetName.Mars;
			case 3:
				return PlanetName.Sun;
			case 4:
				return PlanetName.Venus;
			case 5:
				return PlanetName.Mercury;
			case 6:
				return PlanetName.Moon;
			case 7:
				return PlanetName.Saturn;
			case 8:
				return PlanetName.Jupiter;
			case 9:
				return PlanetName.Mars;
			case 10:
				return PlanetName.Sun;
			case 11:
				return PlanetName.Venus;
			case 12:
				return PlanetName.Mercury;
			case 13:
				return PlanetName.Moon;
			case 14:
				return PlanetName.Saturn;
			case 15:
				return PlanetName.Jupiter;
			case 16:
				return PlanetName.Mars;
			case 17:
				return PlanetName.Sun;
			case 18:
				return PlanetName.Venus;
			case 19:
				return PlanetName.Mercury;
			case 20:
				return PlanetName.Moon;
			case 21:
				return PlanetName.Saturn;
			case 22:
				return PlanetName.Jupiter;
			case 23:
				return PlanetName.Mars;
			case 24:
				return PlanetName.Sun;
			}
			break;
		case VedAstro.Library.DayOfWeek.Friday:
			switch (hora)
			{
			case 1:
				return PlanetName.Venus;
			case 2:
				return PlanetName.Mercury;
			case 3:
				return PlanetName.Moon;
			case 4:
				return PlanetName.Saturn;
			case 5:
				return PlanetName.Jupiter;
			case 6:
				return PlanetName.Mars;
			case 7:
				return PlanetName.Sun;
			case 8:
				return PlanetName.Venus;
			case 9:
				return PlanetName.Mercury;
			case 10:
				return PlanetName.Moon;
			case 11:
				return PlanetName.Saturn;
			case 12:
				return PlanetName.Jupiter;
			case 13:
				return PlanetName.Mars;
			case 14:
				return PlanetName.Sun;
			case 15:
				return PlanetName.Venus;
			case 16:
				return PlanetName.Mercury;
			case 17:
				return PlanetName.Moon;
			case 18:
				return PlanetName.Saturn;
			case 19:
				return PlanetName.Jupiter;
			case 20:
				return PlanetName.Mars;
			case 21:
				return PlanetName.Sun;
			case 22:
				return PlanetName.Venus;
			case 23:
				return PlanetName.Mercury;
			case 24:
				return PlanetName.Moon;
			}
			break;
		case VedAstro.Library.DayOfWeek.Saturday:
			switch (hora)
			{
			case 1:
				return PlanetName.Saturn;
			case 2:
				return PlanetName.Jupiter;
			case 3:
				return PlanetName.Mars;
			case 4:
				return PlanetName.Sun;
			case 5:
				return PlanetName.Venus;
			case 6:
				return PlanetName.Mercury;
			case 7:
				return PlanetName.Moon;
			case 8:
				return PlanetName.Saturn;
			case 9:
				return PlanetName.Jupiter;
			case 10:
				return PlanetName.Mars;
			case 11:
				return PlanetName.Sun;
			case 12:
				return PlanetName.Venus;
			case 13:
				return PlanetName.Mercury;
			case 14:
				return PlanetName.Moon;
			case 15:
				return PlanetName.Saturn;
			case 16:
				return PlanetName.Jupiter;
			case 17:
				return PlanetName.Mars;
			case 18:
				return PlanetName.Sun;
			case 19:
				return PlanetName.Venus;
			case 20:
				return PlanetName.Mercury;
			case 21:
				return PlanetName.Moon;
			case 22:
				return PlanetName.Saturn;
			case 23:
				return PlanetName.Jupiter;
			case 24:
				return PlanetName.Mars;
			}
			break;
		}
		throw new Exception("Did not find hora, something wrong!");
	}

	public static PlanetName LordOfHoraFromTime(Time time)
	{
		DayOfWeek day = DayOfWeek(time);
		return LordOfHoraFromWeekday(HoraAtBirth(time), day);
	}

	public static Angle HouseJunctionPoint(Angle previousHouse, Angle nextHouse)
	{
		return CacheManager.GetCache(new CacheKey("HouseJunctionPoint", previousHouse, nextHouse, Ayanamsa), _getHouseJunctionPoint);
		Angle _getHouseJunctionPoint()
		{
			Angle angle = previousHouse + nextHouse;
			if (nextHouse < previousHouse)
			{
				angle += Angle.Degrees360;
				Angle angle2 = angle.Divide(2.0);
				return angle2 - Angle.Degrees360;
			}
			return angle.Divide(2.0);
		}
	}

	public static PlanetName LordOfZodiacSign(ZodiacName signName)
	{
		switch (signName)
		{
		case ZodiacName.Empty:
			return PlanetName.Empty;
		case ZodiacName.Aries:
		case ZodiacName.Scorpio:
			return PlanetName.Mars;
		case ZodiacName.Taurus:
		case ZodiacName.Libra:
			return PlanetName.Venus;
		case ZodiacName.Gemini:
		case ZodiacName.Virgo:
			return PlanetName.Mercury;
		case ZodiacName.Cancer:
			return PlanetName.Moon;
		case ZodiacName.Leo:
			return PlanetName.Sun;
		case ZodiacName.Sagittarius:
		case ZodiacName.Pisces:
			return PlanetName.Jupiter;
		case ZodiacName.Capricorn:
		case ZodiacName.Aquarius:
			return PlanetName.Saturn;
		default:
			throw new Exception("Lord of sign not found, error!");
		}
	}

	public static List<ZodiacName> ZodiacSignsOwnedByPlanet(PlanetName planetName)
	{
		List<ZodiacName> list = new List<ZodiacName>();
		switch (planetName.Name)
		{
		case PlanetName.PlanetNameEnum.Mars:
			list.Add(ZodiacName.Aries);
			list.Add(ZodiacName.Scorpio);
			break;
		case PlanetName.PlanetNameEnum.Venus:
			list.Add(ZodiacName.Taurus);
			list.Add(ZodiacName.Libra);
			break;
		case PlanetName.PlanetNameEnum.Mercury:
			list.Add(ZodiacName.Gemini);
			list.Add(ZodiacName.Virgo);
			break;
		case PlanetName.PlanetNameEnum.Moon:
			list.Add(ZodiacName.Cancer);
			break;
		case PlanetName.PlanetNameEnum.Sun:
			list.Add(ZodiacName.Leo);
			break;
		case PlanetName.PlanetNameEnum.Jupiter:
			list.Add(ZodiacName.Sagittarius);
			list.Add(ZodiacName.Pisces);
			break;
		case PlanetName.PlanetNameEnum.Saturn:
			list.Add(ZodiacName.Capricorn);
			list.Add(ZodiacName.Aquarius);
			break;
		case PlanetName.PlanetNameEnum.Dhuma:
			list.Add(ZodiacName.Capricorn);
			break;
		case PlanetName.PlanetNameEnum.Vyatipaata:
			list.Add(ZodiacName.Gemini);
			break;
		case PlanetName.PlanetNameEnum.Parivesha:
			list.Add(ZodiacName.Sagittarius);
			break;
		case PlanetName.PlanetNameEnum.Indrachaapa:
			list.Add(ZodiacName.Cancer);
			break;
		case PlanetName.PlanetNameEnum.Upaketu:
			list.Add(ZodiacName.Cancer);
			break;
		case PlanetName.PlanetNameEnum.Gulika:
			list.Add(ZodiacName.Aquarius);
			break;
		case PlanetName.PlanetNameEnum.Yamaghantaka:
			list.Add(ZodiacName.Sagittarius);
			break;
		case PlanetName.PlanetNameEnum.Arthaprahaara:
			list.Add(ZodiacName.Gemini);
			break;
		case PlanetName.PlanetNameEnum.Kaala:
			list.Add(ZodiacName.Capricorn);
			break;
		case PlanetName.PlanetNameEnum.Mrityu:
			list.Add(ZodiacName.Scorpio);
			break;
		default:
			list.Add(ZodiacName.Empty);
			break;
		}
		return list;
	}

	public static ZodiacName NextZodiacSign(ZodiacName inputSign)
	{
		return CacheManager.GetCache(new CacheKey("NextZodiacSign", inputSign, Ayanamsa), _getNextZodiacSign);
		ZodiacName _getNextZodiacSign()
		{
			int num = (int)inputSign;
			if (num == 12)
			{
				return ZodiacName.Aries;
			}
			return (ZodiacName)(num + 1);
		}
	}

	public static int NextHouseNumber(int inputHouseNumber)
	{
		return CacheManager.GetCache(new CacheKey("NextHouseNumber", inputHouseNumber, Ayanamsa), _getNextHouseNumber);
		int _getNextHouseNumber()
		{
			if (inputHouseNumber == 12)
			{
				return 1;
			}
			return inputHouseNumber + 1;
		}
	}

	public static ZodiacSign PlanetExaltationPoint(PlanetName planetName)
	{
		return CacheManager.GetCache(new CacheKey("PlanetExaltationPoint", planetName, Ayanamsa), _getPlanetExaltationPoint);
		ZodiacSign _getPlanetExaltationPoint()
		{
			if (planetName == PlanetName.Sun)
			{
				return new ZodiacSign(ZodiacName.Aries, Angle.FromDegrees(10.0));
			}
			if (planetName == PlanetName.Moon)
			{
				return new ZodiacSign(ZodiacName.Taurus, Angle.FromDegrees(3.0));
			}
			if (planetName == PlanetName.Mars)
			{
				return new ZodiacSign(ZodiacName.Capricorn, Angle.FromDegrees(28.0));
			}
			if (planetName == PlanetName.Mercury)
			{
				return new ZodiacSign(ZodiacName.Virgo, Angle.FromDegrees(15.0));
			}
			if (planetName == PlanetName.Jupiter)
			{
				return new ZodiacSign(ZodiacName.Cancer, Angle.FromDegrees(5.0));
			}
			if (planetName == PlanetName.Venus)
			{
				return new ZodiacSign(ZodiacName.Pisces, Angle.FromDegrees(27.0));
			}
			if (planetName == PlanetName.Saturn)
			{
				return new ZodiacSign(ZodiacName.Libra, Angle.FromDegrees(20.0));
			}
			if (planetName == PlanetName.Rahu)
			{
				return new ZodiacSign(ZodiacName.Taurus, Angle.FromDegrees(20.0));
			}
			if (planetName == PlanetName.Ketu)
			{
				return new ZodiacSign(ZodiacName.Scorpio, Angle.FromDegrees(20.0));
			}
			if (planetName == PlanetName.Dhuma)
			{
				return new ZodiacSign(ZodiacName.Leo, Angle.FromDegrees(1.0));
			}
			if (planetName == PlanetName.Vyatipaata)
			{
				return new ZodiacSign(ZodiacName.Scorpio, Angle.FromDegrees(1.0));
			}
			if (planetName == PlanetName.Parivesha)
			{
				return new ZodiacSign(ZodiacName.Gemini, Angle.FromDegrees(1.0));
			}
			if (planetName == PlanetName.Indrachaapa)
			{
				return new ZodiacSign(ZodiacName.Sagittarius, Angle.FromDegrees(1.0));
			}
			if (planetName == PlanetName.Upaketu)
			{
				return new ZodiacSign(ZodiacName.Aquarius, Angle.FromDegrees(1.0));
			}
			throw new Exception("Planet exaltation point not found, error!");
		}
	}

	public static ZodiacSign PlanetDebilitationPoint(PlanetName planetName)
	{
		return CacheManager.GetCache(new CacheKey("PlanetDebilitationPoint", planetName, Ayanamsa), _getPlanetDebilitationPoint);
		ZodiacSign _getPlanetDebilitationPoint()
		{
			if (planetName == PlanetName.Sun)
			{
				return new ZodiacSign(ZodiacName.Libra, Angle.FromDegrees(10.0));
			}
			if (planetName == PlanetName.Moon)
			{
				return new ZodiacSign(ZodiacName.Scorpio, Angle.FromDegrees(0.0));
			}
			if (planetName == PlanetName.Mars)
			{
				return new ZodiacSign(ZodiacName.Cancer, Angle.FromDegrees(28.0));
			}
			if (planetName == PlanetName.Mercury)
			{
				return new ZodiacSign(ZodiacName.Pisces, Angle.FromDegrees(15.0));
			}
			if (planetName == PlanetName.Jupiter)
			{
				return new ZodiacSign(ZodiacName.Capricorn, Angle.FromDegrees(5.0));
			}
			if (planetName == PlanetName.Venus)
			{
				return new ZodiacSign(ZodiacName.Virgo, Angle.FromDegrees(27.0));
			}
			if (planetName == PlanetName.Saturn)
			{
				return new ZodiacSign(ZodiacName.Aries, Angle.FromDegrees(20.0));
			}
			if (planetName == PlanetName.Rahu)
			{
				return new ZodiacSign(ZodiacName.Scorpio, Angle.FromDegrees(20.0));
			}
			if (planetName == PlanetName.Ketu)
			{
				return new ZodiacSign(ZodiacName.Taurus, Angle.FromDegrees(20.0));
			}
			if (planetName == PlanetName.Dhuma)
			{
				return new ZodiacSign(ZodiacName.Aquarius, Angle.FromDegrees(1.0));
			}
			if (planetName == PlanetName.Vyatipaata)
			{
				return new ZodiacSign(ZodiacName.Taurus, Angle.FromDegrees(1.0));
			}
			if (planetName == PlanetName.Parivesha)
			{
				return new ZodiacSign(ZodiacName.Sagittarius, Angle.FromDegrees(1.0));
			}
			if (planetName == PlanetName.Indrachaapa)
			{
				return new ZodiacSign(ZodiacName.Gemini, Angle.FromDegrees(1.0));
			}
			if (planetName == PlanetName.Upaketu)
			{
				return new ZodiacSign(ZodiacName.Leo, Angle.FromDegrees(1.0));
			}
			throw new Exception("Planet debilitation point not found, error!");
		}
	}

	public static bool IsEvenSign(ZodiacName planetSignName)
	{
		return CacheManager.GetCache(new CacheKey("IsEvenSign", planetSignName, Ayanamsa), _isEvenSign);
		bool _isEvenSign()
		{
			if (planetSignName == ZodiacName.Taurus || planetSignName == ZodiacName.Cancer || planetSignName == ZodiacName.Virgo || planetSignName == ZodiacName.Scorpio || planetSignName == ZodiacName.Capricorn || planetSignName == ZodiacName.Pisces)
			{
				return true;
			}
			return false;
		}
	}

	public static bool IsOddSign(ZodiacName planetSignName)
	{
		return CacheManager.GetCache(new CacheKey("IsOddSign", planetSignName, Ayanamsa), _isOddSign);
		bool _isOddSign()
		{
			if (planetSignName == ZodiacName.Aries || planetSignName == ZodiacName.Gemini || planetSignName == ZodiacName.Leo || planetSignName == ZodiacName.Libra || planetSignName == ZodiacName.Sagittarius || planetSignName == ZodiacName.Aquarius)
			{
				return true;
			}
			return false;
		}
	}

	public static bool IsFixedSign(ZodiacName sunSign)
	{
		switch (sunSign)
		{
		case ZodiacName.Taurus:
		case ZodiacName.Leo:
		case ZodiacName.Scorpio:
		case ZodiacName.Aquarius:
			return true;
		default:
			return false;
		}
	}

	public static bool IsMovableSign(ZodiacName sunSign)
	{
		switch (sunSign)
		{
		case ZodiacName.Aries:
		case ZodiacName.Cancer:
		case ZodiacName.Libra:
		case ZodiacName.Capricorn:
			return true;
		default:
			return false;
		}
	}

	public static bool IsCommonSign(ZodiacName sunSign)
	{
		switch (sunSign)
		{
		case ZodiacName.Gemini:
		case ZodiacName.Virgo:
		case ZodiacName.Sagittarius:
		case ZodiacName.Pisces:
			return true;
		default:
			return false;
		}
	}

	public static PlanetToPlanetRelationship PlanetPermanentRelationshipWithPlanet(PlanetName mainPlanet, PlanetName secondaryPlanet)
	{
		bool num = mainPlanet.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag = mainPlanet.Name == PlanetName.PlanetNameEnum.Ketu;
		bool flag2 = secondaryPlanet.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag3 = secondaryPlanet.Name == PlanetName.PlanetNameEnum.Ketu;
		if (num | flag | flag2 | flag3)
		{
			return PlanetToPlanetRelationship.Empty;
		}
		return CacheManager.GetCache(new CacheKey("PlanetPermanentRelationshipWithPlanet", mainPlanet, secondaryPlanet, Ayanamsa), _getPlanetPermanentRelationshipWithPlanet);
		PlanetToPlanetRelationship _getPlanetPermanentRelationshipWithPlanet()
		{
			if (mainPlanet == secondaryPlanet)
			{
				return PlanetToPlanetRelationship.SamePlanet;
			}
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			if (mainPlanet == PlanetName.Sun)
			{
				List<PlanetName> list = new List<PlanetName>
				{
					PlanetName.Moon,
					PlanetName.Mars,
					PlanetName.Jupiter
				};
				List<PlanetName> list2 = new List<PlanetName> { PlanetName.Mercury };
				List<PlanetName> obj = new List<PlanetName>
				{
					PlanetName.Venus,
					PlanetName.Saturn
				};
				flag6 = list.Contains(secondaryPlanet);
				flag5 = list2.Contains(secondaryPlanet);
				flag4 = obj.Contains(secondaryPlanet);
			}
			if (mainPlanet == PlanetName.Moon)
			{
				List<PlanetName> list3 = new List<PlanetName>
				{
					PlanetName.Sun,
					PlanetName.Mercury
				};
				List<PlanetName> list4 = new List<PlanetName>
				{
					PlanetName.Mars,
					PlanetName.Jupiter,
					PlanetName.Venus,
					PlanetName.Saturn
				};
				List<PlanetName> list5 = new List<PlanetName>();
				flag6 = list3.Contains(secondaryPlanet);
				flag5 = list4.Contains(secondaryPlanet);
				flag4 = list5.Contains(secondaryPlanet);
			}
			if (mainPlanet == PlanetName.Mars)
			{
				List<PlanetName> list6 = new List<PlanetName>
				{
					PlanetName.Sun,
					PlanetName.Moon,
					PlanetName.Jupiter
				};
				List<PlanetName> list7 = new List<PlanetName>
				{
					PlanetName.Venus,
					PlanetName.Saturn
				};
				List<PlanetName> obj2 = new List<PlanetName> { PlanetName.Mercury };
				flag6 = list6.Contains(secondaryPlanet);
				flag5 = list7.Contains(secondaryPlanet);
				flag4 = obj2.Contains(secondaryPlanet);
			}
			if (mainPlanet == PlanetName.Mercury)
			{
				List<PlanetName> list8 = new List<PlanetName>
				{
					PlanetName.Sun,
					PlanetName.Venus
				};
				List<PlanetName> list9 = new List<PlanetName>
				{
					PlanetName.Mars,
					PlanetName.Jupiter,
					PlanetName.Saturn
				};
				List<PlanetName> obj3 = new List<PlanetName> { PlanetName.Moon };
				flag6 = list8.Contains(secondaryPlanet);
				flag5 = list9.Contains(secondaryPlanet);
				flag4 = obj3.Contains(secondaryPlanet);
			}
			if (mainPlanet == PlanetName.Jupiter)
			{
				List<PlanetName> list10 = new List<PlanetName>
				{
					PlanetName.Sun,
					PlanetName.Moon,
					PlanetName.Mars
				};
				List<PlanetName> list11 = new List<PlanetName> { PlanetName.Saturn };
				List<PlanetName> obj4 = new List<PlanetName>
				{
					PlanetName.Mercury,
					PlanetName.Venus
				};
				flag6 = list10.Contains(secondaryPlanet);
				flag5 = list11.Contains(secondaryPlanet);
				flag4 = obj4.Contains(secondaryPlanet);
			}
			if (mainPlanet == PlanetName.Venus)
			{
				List<PlanetName> list12 = new List<PlanetName>
				{
					PlanetName.Mercury,
					PlanetName.Saturn
				};
				List<PlanetName> list13 = new List<PlanetName>
				{
					PlanetName.Mars,
					PlanetName.Jupiter
				};
				List<PlanetName> obj5 = new List<PlanetName>
				{
					PlanetName.Sun,
					PlanetName.Moon
				};
				flag6 = list12.Contains(secondaryPlanet);
				flag5 = list13.Contains(secondaryPlanet);
				flag4 = obj5.Contains(secondaryPlanet);
			}
			if (mainPlanet == PlanetName.Saturn)
			{
				List<PlanetName> list14 = new List<PlanetName>
				{
					PlanetName.Mercury,
					PlanetName.Venus
				};
				List<PlanetName> list15 = new List<PlanetName> { PlanetName.Jupiter };
				List<PlanetName> obj6 = new List<PlanetName>
				{
					PlanetName.Sun,
					PlanetName.Moon,
					PlanetName.Mars
				};
				flag6 = list14.Contains(secondaryPlanet);
				flag5 = list15.Contains(secondaryPlanet);
				flag4 = obj6.Contains(secondaryPlanet);
			}
			if (mainPlanet == PlanetName.Rahu || mainPlanet == PlanetName.Ketu)
			{
				throw new Exception("No Permenant Relation for Rahu and Ketu, use Temporary Relation!");
			}
			if (flag6)
			{
				return PlanetToPlanetRelationship.Friend;
			}
			if (flag5)
			{
				return PlanetToPlanetRelationship.Neutral;
			}
			if (flag4)
			{
				return PlanetToPlanetRelationship.Enemy;
			}
			return PlanetToPlanetRelationship.Empty;
		}
	}

	public static DateTime ConvertJulianTimeToNormalTime(double julianTime)
	{
		return CacheManager.GetCache(new CacheKey("ConvertJulianTimeToNormalTime", julianTime, Ayanamsa), _convertJulianTimeToNormalTime);
		DateTime _convertJulianTimeToNormalTime()
		{
			SwissEph swissEph = new SwissEph();
			int gregflag = 1;
			int iyear = 0;
			int imonth = 0;
			int iday = 0;
			int ihour = 0;
			int imin = 0;
			double dsec = 0.0;
			swissEph.swe_jdut1_to_utc(julianTime, gregflag, ref iyear, ref imonth, ref iday, ref ihour, ref imin, ref dsec);
			return new DateTime(iyear, imonth, iday, ihour, imin, (int)dsec);
		}
	}

	public static DateTimeOffset GreenwichTimeFromJulianDays(double julianTime)
	{
		return CacheManager.GetCache(new CacheKey("GreenwichTimeFromJulianDays", julianTime, Ayanamsa), _convertJulianTimeToNormalTime);
		DateTimeOffset _convertJulianTimeToNormalTime()
		{
			SwissEph swissEph = new SwissEph();
			int gregflag = 1;
			int iyear = 0;
			int imonth = 0;
			int iday = 0;
			int ihour = 0;
			int imin = 0;
			double dsec = 0.0;
			swissEph.swe_jdut1_to_utc(julianTime, gregflag, ref iyear, ref imonth, ref iday, ref ihour, ref imin, ref dsec);
			DateTime dateTime = new DateTime(iyear, imonth, iday, ihour, imin, (int)dsec);
			return new DateTimeOffset(dateTime, new TimeSpan(0, 0, 0));
		}
	}

	public static double GreenwichLmtInJulianDays(Time time)
	{
		return CacheManager.GetCache(new CacheKey("GreenwichLmtInJulianDays", time, Ayanamsa), _getGreenwichLmtInJulianDays);
		double _getGreenwichLmtInJulianDays()
		{
			DateTimeOffset dateTimeOffset = time.GetLmtDateTimeOffset().ToUniversalTime();
			int year = dateTimeOffset.Year;
			int month = dateTimeOffset.Month;
			int day = dateTimeOffset.Day;
			double totalHours = dateTimeOffset.TimeOfDay.TotalHours;
			int gregflag = 1;
			return new SwissEph().swe_julday(year, month, day, totalHours, gregflag);
		}
	}

	public static double[] GetHouse1And10Longitudes(Time time)
	{
		return CacheManager.GetCache(new CacheKey("GetHouse1And10Longitudes", time, Ayanamsa), _getHouse1And10Longitudes);
		double[] _getHouse1And10Longitudes()
		{
			GeoLocation geoLocation = time.GetGeoLocation();
			double tjd_ut = TimeToJulianDay(time);
			SwissEph swissEph = new SwissEph();
			double[] array = new double[13];
			double[] ascmc = new double[10];
			swissEph.swe_set_sid_mode(Ayanamsa, 0.0, 0.0);
			swissEph.swe_houses(tjd_ut, geoLocation.Latitude(), geoLocation.Longitude(), 'V', array, ascmc);
			return array;
		}
	}

	public static DateTimeOffset LmtToUtc(Time time)
	{
		return CacheManager.GetCache(new CacheKey("LmtToUtc", time, Ayanamsa), _lmtToUtc);
		DateTimeOffset _lmtToUtc()
		{
			return time.GetLmtDateTimeOffset().ToUniversalTime();
		}
	}

	public static Sarvashtakavarga SarvashtakavargaChart(Time birthTime)
	{
		return Ashtakavarga.SarvashtakavargaChart2(birthTime);
	}

	public static Bhinnashtakavarga BhinnashtakavargaChart(Time birthTime)
	{
		Bhinnashtakavarga bhinnashtakavarga = new Bhinnashtakavarga();
		foreach (PlanetName all7Planet in PlanetName.All7Planets)
		{
			Prastaraka prastaraka = Ashtakavarga.PlanetPrastaraka(all7Planet, birthTime);
			bhinnashtakavarga[all7Planet] = prastaraka.BhinnashtakaRow();
		}
		return bhinnashtakavarga;
	}

	public static int PlanetAshtakvargaBindu(PlanetName planet, ZodiacName signToCheck, Time time)
	{
		return Ashtakavarga.BhinnashtakavargaChartForPlanet(planet, time)[signToCheck];
	}

	public static GocharaKakshas GocharaKakshas(Time checkTime, Time birthTime)
	{
		List<PlanetName> all7Planets = PlanetName.All7Planets;
		Dictionary<PlanetName, ZodiacSign> dictionary = new Dictionary<PlanetName, ZodiacSign>();
		foreach (PlanetName item in all7Planets)
		{
			dictionary.Add(item, PlanetZodiacSign(item, checkTime));
		}
		Dictionary<PlanetName, string> dictionary2 = new Dictionary<PlanetName, string>();
		foreach (KeyValuePair<PlanetName, ZodiacSign> item2 in dictionary)
		{
			dictionary2.Add(item2.Key, GetKakshyaLord(item2.Value));
		}
		Dictionary<PlanetName, int> dictionary3 = new Dictionary<PlanetName, int>();
		foreach (PlanetName item3 in all7Planets)
		{
			Prastaraka prastaraka = Ashtakavarga.PlanetPrastaraka(item3, birthTime);
			string index = dictionary2[item3];
			int value = prastaraka[index][dictionary[item3].GetSignName()];
			dictionary3.Add(item3, value);
		}
		Dictionary<PlanetName, int> dictionary4 = new Dictionary<PlanetName, int>();
		foreach (PlanetName item4 in all7Planets)
		{
			int value2 = Ashtakavarga.PlanetPrastaraka(item4, birthTime).BhinnashtakaRow()[dictionary[item4].GetSignName()];
			dictionary4.Add(item4, value2);
		}
		Dictionary<PlanetName, int> dictionary5 = new Dictionary<PlanetName, int>();
		foreach (PlanetName item5 in all7Planets)
		{
			Sarvashtakavarga sarvashtakavarga = SarvashtakavargaChart(birthTime);
			ZodiacSign zodiacSign = dictionary[item5];
			int value3 = sarvashtakavarga.SarvashtakavargaRow[zodiacSign.GetSignName()];
			dictionary5.Add(item5, value3);
		}
		return new GocharaKakshas(all7Planets, dictionary, dictionary2, dictionary3, dictionary4, dictionary5);
		static string GetKakshyaLord(ZodiacSign inputZodiacSign)
		{
			double totalDegrees = inputZodiacSign.GetDegreesInSign().TotalDegrees;
			if (totalDegrees >= 0.0 && totalDegrees <= 3.75)
			{
				return "Saturn";
			}
			if (totalDegrees > 3.75 && totalDegrees <= 7.5)
			{
				return "Jupiter";
			}
			if (totalDegrees > 7.5 && totalDegrees <= 11.25)
			{
				return "Mars";
			}
			if (totalDegrees > 11.25 && totalDegrees <= 15.0)
			{
				return "Sun";
			}
			if (totalDegrees > 15.0 && totalDegrees <= 18.75)
			{
				return "Venus";
			}
			if (totalDegrees > 18.75 && totalDegrees <= 22.5)
			{
				return "Mercury";
			}
			if (totalDegrees > 22.5 && totalDegrees <= 26.25)
			{
				return "Moon";
			}
			if (totalDegrees > 26.25 && totalDegrees <= 30.0)
			{
				return "Ascendant";
			}
			throw new Exception("END OF LINE");
		}
	}

	public static int GocharaZodiacSignCountFromMoon(Time birthTime, Time currentTime, PlanetName planet)
	{
		ZodiacName startSign = MoonSignName(birthTime);
		ZodiacName signName = PlanetZodiacSign(planet, currentTime).GetSignName();
		return CountFromSignToSign(startSign, signName);
	}

	public static bool IsGocharaObstructed(PlanetName planet, int gocharaHouse, Time birthTime, Time currentTime)
	{
		int obstructionHouse = Vedhanka(planet, gocharaHouse);
		if (obstructionHouse == 0)
		{
			return false;
		}
		List<PlanetName> list = PlanetsInGocharaHouse(birthTime, currentTime, obstructionHouse);
		if (planet == PlanetName.Sun || planet == PlanetName.Saturn)
		{
			list.Remove(PlanetName.Sun);
			list.Remove(PlanetName.Saturn);
		}
		if (planet == PlanetName.Moon || planet == PlanetName.Mercury)
		{
			list.Remove(PlanetName.Moon);
			list.Remove(PlanetName.Mercury);
		}
		return list.Any();
	}

	public static List<PlanetName> PlanetsInGocharaHouse(Time birthTime, Time currentTime, int gocharaHouse)
	{
		int num = GocharaZodiacSignCountFromMoon(birthTime, currentTime, PlanetName.Sun);
		int num2 = GocharaZodiacSignCountFromMoon(birthTime, currentTime, PlanetName.Moon);
		int num3 = GocharaZodiacSignCountFromMoon(birthTime, currentTime, PlanetName.Mars);
		int num4 = GocharaZodiacSignCountFromMoon(birthTime, currentTime, PlanetName.Mercury);
		int num5 = GocharaZodiacSignCountFromMoon(birthTime, currentTime, PlanetName.Jupiter);
		int num6 = GocharaZodiacSignCountFromMoon(birthTime, currentTime, PlanetName.Venus);
		int num7 = GocharaZodiacSignCountFromMoon(birthTime, currentTime, PlanetName.Saturn);
		List<PlanetName> list = new List<PlanetName>();
		if (num == gocharaHouse)
		{
			list.Add(PlanetName.Sun);
		}
		if (num2 == gocharaHouse)
		{
			list.Add(PlanetName.Moon);
		}
		if (num3 == gocharaHouse)
		{
			list.Add(PlanetName.Mars);
		}
		if (num4 == gocharaHouse)
		{
			list.Add(PlanetName.Mercury);
		}
		if (num5 == gocharaHouse)
		{
			list.Add(PlanetName.Jupiter);
		}
		if (num6 == gocharaHouse)
		{
			list.Add(PlanetName.Venus);
		}
		if (num7 == gocharaHouse)
		{
			list.Add(PlanetName.Saturn);
		}
		return list;
	}

	public static int Vedhanka(PlanetName planet, int house)
	{
		if (planet == PlanetName.Sun)
		{
			switch (house)
			{
			case 11:
				return 5;
			case 3:
				return 9;
			case 10:
				return 4;
			case 6:
				return 12;
			case 5:
				return 11;
			case 9:
				return 3;
			case 4:
				return 10;
			case 12:
				return 6;
			}
		}
		if (planet == PlanetName.Moon)
		{
			switch (house)
			{
			case 7:
				return 2;
			case 1:
				return 5;
			case 6:
				return 12;
			case 11:
				return 8;
			case 10:
				return 4;
			case 3:
				return 9;
			case 2:
				return 7;
			case 5:
				return 1;
			case 12:
				return 6;
			case 8:
				return 11;
			case 4:
				return 10;
			case 9:
				return 3;
			}
		}
		if (planet == PlanetName.Mars)
		{
			switch (house)
			{
			case 3:
				return 12;
			case 11:
				return 5;
			case 6:
				return 9;
			case 12:
				return 3;
			case 5:
				return 11;
			case 9:
				return 6;
			}
		}
		if (planet == PlanetName.Mercury)
		{
			switch (house)
			{
			case 2:
				return 5;
			case 4:
				return 3;
			case 6:
				return 9;
			case 8:
				return 1;
			case 10:
				return 7;
			case 11:
				return 12;
			case 5:
				return 2;
			case 3:
				return 4;
			case 9:
				return 6;
			case 1:
				return 8;
			case 7:
				return 10;
			case 12:
				return 11;
			}
		}
		if (planet == PlanetName.Jupiter)
		{
			switch (house)
			{
			case 2:
				return 12;
			case 11:
				return 8;
			case 9:
				return 10;
			case 5:
				return 4;
			case 7:
				return 3;
			case 12:
				return 2;
			case 8:
				return 11;
			case 10:
				return 9;
			case 4:
				return 5;
			case 3:
				return 7;
			}
		}
		if (planet == PlanetName.Venus)
		{
			switch (house)
			{
			case 1:
				return 8;
			case 2:
				return 7;
			case 3:
				return 1;
			case 4:
				return 10;
			case 5:
				return 9;
			case 8:
				return 5;
			case 9:
				return 11;
			case 11:
				return 6;
			case 12:
				return 3;
			}
			switch (house)
			{
			case 8:
				return 1;
			case 7:
				return 2;
			case 1:
				return 3;
			case 10:
				return 4;
			case 9:
				return 5;
			case 5:
				return 8;
			case 11:
				return 9;
			case 6:
				return 11;
			case 3:
				return 12;
			}
		}
		if (planet == PlanetName.Saturn)
		{
			switch (house)
			{
			case 3:
				return 12;
			case 11:
				return 5;
			case 6:
				return 9;
			case 12:
				return 3;
			case 5:
				return 11;
			case 9:
				return 6;
			}
		}
		if (planet == PlanetName.Rahu)
		{
			switch (house)
			{
			case 3:
				return 12;
			case 11:
				return 5;
			case 6:
				return 9;
			case 12:
				return 3;
			case 5:
				return 11;
			case 9:
				return 6;
			}
		}
		if (planet == PlanetName.Ketu)
		{
			switch (house)
			{
			case 3:
				return 12;
			case 11:
				return 5;
			case 6:
				return 9;
			case 12:
				return 3;
			case 5:
				return 11;
			case 9:
				return 6;
			}
		}
		return 0;
	}

	public static bool IsGocharaOccurring(Time birthTime, Time time, PlanetName planet, int gocharaHouse)
	{
		bool num = GocharaZodiacSignCountFromMoon(birthTime, time, planet) == gocharaHouse;
		bool flag = true;
		if (UseVedhankaInGochara)
		{
			flag = !IsGocharaObstructed(planet, gocharaHouse, birthTime, time);
		}
		return num & flag;
	}

	public static bool IsPlanetGocharaBindu(Time birthTime, Time nowTime, PlanetName planet, int bindu)
	{
		int num = GocharaZodiacSignCountFromMoon(birthTime, nowTime, planet);
		if (IsGocharaObstructed(planet, num, birthTime, nowTime))
		{
			return false;
		}
		ZodiacName signToCheck = HouseSignName((HouseName)num, nowTime);
		return PlanetAshtakvargaBindu(planet, signToCheck, nowTime) == bindu;
	}

	public static JObject DasaForLife(Time birthTime, int levels = 3, int precisionHours = 100, int scanYears = 100)
	{
		Time startTime = birthTime;
		Time endTime = birthTime.AddYears(scanYears);
		List<EventTag> list = new List<EventTag>();
		for (int i = 1; i <= levels; i++)
		{
			list.Add((EventTag)Enum.Parse(typeof(EventTag), $"PD{i}"));
		}
		Person inputPerson = new Person("", birthTime, Gender.Empty);
		return VimshottariDasa.GetDasaJson((from e in EventManager.CalculateEvents(precisionHours, startTime, endTime, inputPerson, list)
			select new DasaEvent(e)).ToList(), 1);
	}

	public static JObject DasaAtRange(Time birthTime, Time startTime, Time endTime, int levels = 3, int precisionHours = 100)
	{
		List<EventTag> list = new List<EventTag>();
		for (int i = 1; i <= levels; i++)
		{
			list.Add((EventTag)Enum.Parse(typeof(EventTag), $"PD{i}"));
		}
		Person inputPerson = new Person("", birthTime, Gender.Empty);
		return VimshottariDasa.GetDasaJson((from e in EventManager.CalculateEvents(precisionHours, startTime, endTime, inputPerson, list)
			select new DasaEvent(e)).ToList(), 1);
	}

	public static JObject DasaAtTime(Time birthTime, Time checkTime, int levels = 3)
	{
		List<EventTag> list = new List<EventTag>();
		for (int i = 1; i <= levels; i++)
		{
			list.Add((EventTag)Enum.Parse(typeof(EventTag), $"PD{i}"));
		}
		Person inputPerson = new Person("", birthTime, Gender.Empty);
		return VimshottariDasa.GetDasaJson((from e in EventManager.CalculateEvents(1.0, checkTime, checkTime, inputPerson, list, filter0Duration: false)
			select new DasaEvent(e)).ToList(), 1);
	}

	public static JObject DasaForNow(Time birthTime, int levels = 3)
	{
		List<EventTag> list = new List<EventTag>();
		for (int i = 1; i <= levels; i++)
		{
			list.Add((EventTag)Enum.Parse(typeof(EventTag), $"PD{i}"));
		}
		Person inputPerson = new Person("", birthTime, Gender.Empty);
		Time time = Time.NowSystem(birthTime.GetGeoLocation());
		return VimshottariDasa.GetDasaJson((from e in EventManager.CalculateEvents(1.0, time, time, inputPerson, list, filter0Duration: false)
			select new DasaEvent(e)).ToList(), 1);
	}

	public static bool IsMercuryAfflicted(Time time)
	{
		return IsMercuryMalefic(time);
	}

	public static bool IsMercuryMalefic(Time time)
	{
		return CacheManager.GetCache(new CacheKey("IsMercuryMalefic", time, Ayanamsa), _isMercuryMalefic);
		bool _isMercuryMalefic()
		{
			if (conjunctWithMalefic())
			{
				return true;
			}
			conjunctWithBenefic();
			return false;
		}
		bool conjunctWithBenefic()
		{
			List<PlanetName> list = new List<PlanetName>
			{
				PlanetName.Jupiter,
				PlanetName.Venus
			};
			if (IsMoonBenefic(time))
			{
				list.Add(PlanetName.Moon);
			}
			List<PlanetName> list2 = PlanetsInConjuction(PlanetName.Mercury, time);
			bool flag = false;
			foreach (PlanetName item in list)
			{
				flag = list2.Contains(item);
				if (flag)
				{
					break;
				}
			}
			return flag;
		}
		bool conjunctWithMalefic()
		{
			List<PlanetName> list = new List<PlanetName>
			{
				PlanetName.Sun,
				PlanetName.Saturn,
				PlanetName.Mars,
				PlanetName.Rahu,
				PlanetName.Ketu
			};
			if (!IsMoonBenefic(time))
			{
				list.Add(PlanetName.Moon);
			}
			List<PlanetName> list2 = PlanetsInConjuction(PlanetName.Mercury, time);
			bool flag = false;
			foreach (PlanetName item2 in list)
			{
				flag = list2.Contains(item2);
				if (flag)
				{
					break;
				}
			}
			return flag;
		}
	}

	public static bool IsMoonBenefic(Time time)
	{
		int lunarDateNumber = LunarDay(time).GetLunarDateNumber();
		if (lunarDateNumber >= 8 && lunarDateNumber <= 23)
		{
			return true;
		}
		return false;
	}

	public static bool IsPlanetBenefic(PlanetName planetName, Time time)
	{
		return BeneficPlanetList(time).Contains(planetName);
	}

	public static List<PlanetName> BeneficPlanetList(Time time)
	{
		List<PlanetName> list = new List<PlanetName>
		{
			PlanetName.Jupiter,
			PlanetName.Venus
		};
		if (IsMoonBenefic(time))
		{
			list.Add(PlanetName.Moon);
		}
		if (!IsMercuryMalefic(time))
		{
			list.Add(PlanetName.Mercury);
		}
		return list;
	}

	public static bool IsPlanetMalefic(PlanetName planetName, Time time)
	{
		return MaleficPlanetList(time).Contains(planetName);
	}

	public static List<PlanetName> MaleficPlanetList(Time time)
	{
		List<PlanetName> list = new List<PlanetName>
		{
			PlanetName.Sun,
			PlanetName.Saturn,
			PlanetName.Mars,
			PlanetName.Rahu,
			PlanetName.Ketu
		};
		if (!IsMoonBenefic(time))
		{
			list.Add(PlanetName.Moon);
		}
		if (IsMercuryMalefic(time))
		{
			list.Add(PlanetName.Mercury);
		}
		return list;
	}

	public static List<PlanetName> PlanetsInAspect(PlanetName inputPlanet, Time time)
	{
		List<ZodiacName> list = SignsPlanetIsAspecting(inputPlanet, time);
		List<PlanetName> list2 = new List<PlanetName>();
		foreach (ZodiacName item in list)
		{
			List<PlanetName> collection = PlanetInSign(item, time);
			list2.AddRange(collection);
		}
		return list2;
	}

	public static double PlanetAspectDegree(PlanetName receiver, PlanetName trasmitter, Time time)
	{
		double totalDegrees = PlanetNirayanaLongitude(receiver, time).TotalDegrees;
		double totalDegrees2 = PlanetNirayanaLongitude(trasmitter, time).TotalDegrees;
		double num = totalDegrees - totalDegrees2;
		if (num < 0.0)
		{
			num += 360.0;
		}
		double num2 = FindViseshaDrishti(num, trasmitter);
		return FindDrishtiValue(num) + num2;
	}

	public static List<PlanetName> PlanetsAspectingPlanet(PlanetName receivingAspect, Time time)
	{
		return PlanetName.All9Planets.FindAll((PlanetName transmitPlanet) => IsPlanetAspectedByPlanet(receivingAspect, transmitPlanet, time));
	}

	public static List<HouseName> HousesInAspect(PlanetName planet, Time time)
	{
		List<ZodiacName> list = SignsPlanetIsAspecting(planet, time);
		List<HouseName> list2 = new List<HouseName>();
		foreach (HouseName allHouse in House.AllHouses)
		{
			ZodiacName item = HouseSignName(allHouse, time);
			if (list.Contains(item))
			{
				list2.Add(allHouse);
			}
		}
		return list2;
	}

	public static List<PlanetName> PlanetsAspectingHouse(HouseName inputHouse, Time time)
	{
		List<PlanetName> list = new List<PlanetName>();
		foreach (PlanetName all9Planet in PlanetName.All9Planets)
		{
			if (HousesInAspect(all9Planet, time).FindAll((HouseName house) => house == inputHouse).Any())
			{
				list.Add(all9Planet);
			}
		}
		return list;
	}

	public static bool IsPlanetAspectedByPlanet(PlanetName receiveingAspect, PlanetName transmitingAspect, Time time)
	{
		return PlanetsInAspect(transmitingAspect, time).Contains(receiveingAspect);
	}

	public static bool IsHouseAspectedByPlanet(HouseName receiveingAspect, PlanetName transmitingAspect, Time time)
	{
		return HousesInAspect(transmitingAspect, time).Contains(receiveingAspect);
	}

	public static bool IsPlanetConjunctWithPlanet(PlanetName planetA, PlanetName planetB, Time time)
	{
		List<PlanetName> list = PlanetsInConjuction(planetA, time);
		List<PlanetName> list2 = PlanetsInConjuction(planetB, time);
		if (list.Contains(planetB))
		{
			return list2.Contains(planetA);
		}
		return false;
	}

	public static double PlanetPowerPercentage(PlanetName inputPlanet, Time time)
	{
		List<(double, PlanetName)> source = AllPlanetStrength(time);
		double item = source.FirstOrDefault(((double, PlanetName) x) => x.Item2 == inputPlanet).Item1;
		double fromMin = source.Min(((double, PlanetName) x) => x.Item1);
		double fromMax = source.Max(((double, PlanetName) x) => x.Item1);
		return item.Remap(fromMin, fromMax, 0.0, 100.0);
	}

	public static List<PlanetName> AllPlanetOrderedByStrength(Time time)
	{
		return CacheManager.GetCache(new CacheKey("AllPlanetOrderedByStrength", time, Ayanamsa), _getAllPlanetOrderedByStrength);
		List<PlanetName> _getAllPlanetOrderedByStrength()
		{
			Dictionary<PlanetName, double> dictionary = new Dictionary<PlanetName, double>();
			foreach (PlanetName all9Planet in PlanetName.All9Planets)
			{
				double value = PlanetShadbalaPinda(all9Planet, time).ToDouble();
				dictionary.Add(all9Planet, value);
			}
			return (from x in dictionary
				orderby x.Value descending
				select x.Key).ToList();
		}
	}

	public static bool IsPlanetStrongInShadbala(PlanetName planet, Time time)
	{
		double num = 0.0;
		if (planet == PlanetName.Sun)
		{
			num = 5.0;
		}
		else if (planet == PlanetName.Moon)
		{
			num = 6.0;
		}
		else if (planet == PlanetName.Mars)
		{
			num = 5.0;
		}
		else if (planet == PlanetName.Mercury)
		{
			num = 7.0;
		}
		else if (planet == PlanetName.Jupiter)
		{
			num = 6.5;
		}
		else if (planet == PlanetName.Venus)
		{
			num = 5.5;
		}
		else if (planet == PlanetName.Saturn)
		{
			num = 5.0;
		}
		else if (planet == PlanetName.Rahu)
		{
			num = 5.0;
		}
		else if (planet == PlanetName.Ketu)
		{
			num = 5.0;
		}
		return Math.Round(PlanetShadbalaPinda(planet, time).ToRupa(), 1) / num >= 1.1;
	}

	public static bool IsHouseBeneficInShadbala(HouseName house, Time birthTime, double threshold)
	{
		return HouseStrength(house, birthTime).ToDouble() > threshold;
	}

	public static List<(double, PlanetName)> AllPlanetStrength(Time time)
	{
		List<(double, PlanetName)> list = new List<(double, PlanetName)>();
		foreach (PlanetName all9Planet in PlanetName.All9Planets)
		{
			double item = PlanetShadbalaPinda(all9Planet, time).ToDouble();
			list.Add((item, all9Planet));
		}
		return list;
	}

	public static HouseName[] AllHousesOrderedByStrength(Time time)
	{
		return CacheManager.GetCache(new CacheKey("AllHousesOrderedByStrength", time, Ayanamsa), _getAllHousesOrderedByStrength);
		HouseName[] _getAllHousesOrderedByStrength()
		{
			Dictionary<double, HouseName> dictionary = new Dictionary<double, HouseName>();
			foreach (HouseName allHouse in House.AllHouses)
			{
				double key = HouseStrength(allHouse, time).ToRupa();
				dictionary[key] = allHouse;
			}
			List<double> list = dictionary.Keys.ToList();
			list.Sort();
			HouseName[] array = new HouseName[12];
			int num = 11;
			foreach (double item in list)
			{
				array[num] = dictionary[item];
				num--;
			}
			return array;
		}
	}

	public static Shashtiamsa PlanetShadbalaPinda(PlanetName planetName, Time time)
	{
		try
		{
			if (planetName == null)
			{
				return Shashtiamsa.Zero;
			}
			return CacheManager.GetCache(new CacheKey("PlanetShadbalaPinda", planetName, time, Ayanamsa), _getPlanetShadbalaPinda);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			return Shashtiamsa.Zero;
		}
		Shashtiamsa _getPlanetShadbalaPinda()
		{
			if (planetName == PlanetName.Rahu || planetName == PlanetName.Ketu)
			{
				PlanetName planetName2 = LordOfHousePlanetIsIn(planetName, time);
				planetName = planetName2;
			}
			Shashtiamsa shashtiamsa = PlanetSthanaBala(planetName, time);
			Shashtiamsa shashtiamsa2 = PlanetDigBala(planetName, time);
			Shashtiamsa shashtiamsa3 = PlanetKalaBala(planetName, time);
			Shashtiamsa shashtiamsa4 = PlanetChestaBala(planetName, time);
			Shashtiamsa shashtiamsa5 = PlanetNaisargikaBala(planetName, time);
			Shashtiamsa shashtiamsa6 = PlanetDrikBala(planetName, time);
			return new Shashtiamsa(Math.Round((shashtiamsa + shashtiamsa2 + shashtiamsa3 + shashtiamsa4 + shashtiamsa5 + shashtiamsa6).ToDouble(), 2));
		}
	}

	public static Shashtiamsa PlanetStrength(PlanetName planetName, Time time)
	{
		return PlanetShadbalaPinda(planetName, time);
	}

	private static PlanetName LordOfHousePlanetIsIn(PlanetName planetName, Time time)
	{
		return LordOfHouse(HousePlanetOccupies(planetName, time), time);
	}

	public static Shashtiamsa PlanetDrikBala(PlanetName planetName, Time time)
	{
		bool num = planetName.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag = planetName.Name == PlanetName.PlanetNameEnum.Ketu;
		if (num | flag)
		{
			return Shashtiamsa.Zero;
		}
		Dictionary<string, double> dictionary = new Dictionary<string, double>();
		Dictionary<PlanetName, int> dictionary2 = new Dictionary<PlanetName, int>();
		foreach (PlanetName all7Planet in PlanetName.All7Planets)
		{
			if (IsPlanetBenefic(all7Planet, time))
			{
				dictionary2[all7Planet] = 1;
			}
			else
			{
				dictionary2[all7Planet] = -1;
			}
		}
		foreach (PlanetName all7Planet2 in PlanetName.All7Planets)
		{
			foreach (PlanetName all7Planet3 in PlanetName.All7Planets)
			{
				double totalDegrees = PlanetNirayanaLongitude(all7Planet3, time).TotalDegrees;
				double totalDegrees2 = PlanetNirayanaLongitude(all7Planet2, time).TotalDegrees;
				double num2 = totalDegrees - totalDegrees2;
				if (num2 < 0.0)
				{
					num2 += 360.0;
				}
				double num3 = FindViseshaDrishti(num2, all7Planet2);
				dictionary[all7Planet2.ToString() + all7Planet3.ToString()] = FindDrishtiValue(num2) + num3;
			}
		}
		double num4 = 0.0;
		Dictionary<PlanetName, double> dictionary3 = new Dictionary<PlanetName, double>();
		foreach (PlanetName all7Planet4 in PlanetName.All7Planets)
		{
			num4 = 0.0;
			foreach (PlanetName all7Planet5 in PlanetName.All7Planets)
			{
				num4 += (double)dictionary2[all7Planet5] * dictionary[all7Planet5.ToString() + all7Planet4.ToString()];
			}
			dictionary3[all7Planet4] = num4 / 4.0;
		}
		return new Shashtiamsa(dictionary3[planetName]);
	}

	public static double FindViseshaDrishti(double dk, PlanetName p)
	{
		double result = 0.0;
		if (p == PlanetName.Saturn)
		{
			if ((dk >= 60.0 && dk <= 90.0) || (dk >= 270.0 && dk <= 300.0))
			{
				result = 45.0;
			}
		}
		else if (p == PlanetName.Jupiter)
		{
			if ((dk >= 120.0 && dk <= 150.0) || (dk >= 240.0 && dk <= 270.0))
			{
				result = 30.0;
			}
		}
		else if (p == PlanetName.Mars)
		{
			if ((dk >= 90.0 && dk <= 120.0) || (dk >= 210.0 && dk <= 240.0))
			{
				result = 15.0;
			}
		}
		else
		{
			result = 0.0;
		}
		return result;
	}

	public static double FindDrishtiValue(double dk)
	{
		double result = 0.0;
		if (dk >= 30.0 && dk <= 60.0)
		{
			result = (dk - 30.0) / 2.0;
		}
		else if (dk > 60.0 && dk <= 90.0)
		{
			result = dk - 60.0 + 15.0;
		}
		else if (dk > 90.0 && dk <= 120.0)
		{
			result = (120.0 - dk) / 2.0 + 30.0;
		}
		else if (dk > 120.0 && dk <= 150.0)
		{
			result = 150.0 - dk;
		}
		else if (dk > 150.0 && dk <= 180.0)
		{
			result = (dk - 150.0) * 2.0;
		}
		else if (dk > 180.0 && dk <= 300.0)
		{
			result = (300.0 - dk) / 2.0;
		}
		return result;
	}

	public static Shashtiamsa PlanetNaisargikaBala(PlanetName planetName, Time time)
	{
		bool num = planetName.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag = planetName.Name == PlanetName.PlanetNameEnum.Ketu;
		if (num | flag)
		{
			return Shashtiamsa.Zero;
		}
		if (planetName == PlanetName.Sun)
		{
			return new Shashtiamsa(60.0);
		}
		if (planetName == PlanetName.Moon)
		{
			return new Shashtiamsa(51.43);
		}
		if (planetName == PlanetName.Venus)
		{
			return new Shashtiamsa(42.85);
		}
		if (planetName == PlanetName.Jupiter)
		{
			return new Shashtiamsa(34.28);
		}
		if (planetName == PlanetName.Mercury)
		{
			return new Shashtiamsa(25.7);
		}
		if (planetName == PlanetName.Mars)
		{
			return new Shashtiamsa(17.14);
		}
		if (planetName == PlanetName.Saturn)
		{
			return new Shashtiamsa(8.57);
		}
		throw new Exception("Planet not specified!");
	}

	public static Shashtiamsa PlanetChestaBala(PlanetName planetName, Time time, bool useSpecialSunMoon = false)
	{
		if ((planetName == PlanetName.Sun) & useSpecialSunMoon)
		{
			return SunChestaBala(time);
		}
		if ((planetName == PlanetName.Moon) & useSpecialSunMoon)
		{
			return MoonChestaBala(time);
		}
		if (planetName == PlanetName.Sun || planetName == PlanetName.Moon || planetName == PlanetName.Rahu || planetName == PlanetName.Ketu)
		{
			return Shashtiamsa.Zero;
		}
		double epochToBirthDays = EpochInterval(time);
		Dictionary<PlanetName, double> dictionary = Madhya(epochToBirthDays, time);
		Dictionary<PlanetName, double> dictionary2 = GetSeeghrochcha(dictionary, epochToBirthDays, time);
		double totalDegrees = PlanetNirayanaLongitude(planetName, time).TotalDegrees;
		double num = dictionary2[planetName];
		double num2 = (dictionary[planetName] + totalDegrees) / 2.0;
		double num3 = num - num2;
		if (num3 < 360.0)
		{
			num3 += 360.0;
		}
		num3 %= 360.0;
		if (num3 > 180.0)
		{
			num3 = 360.0 - num3;
		}
		return new Shashtiamsa(num3 / 3.0);
		static Dictionary<PlanetName, double> GetSeeghrochcha(Dictionary<PlanetName, double> mean, double num9, Time time2)
		{
			int year = time2.GetLmtDateTimeOffset().Year;
			Dictionary<PlanetName, double> dictionary3 = new Dictionary<PlanetName, double>();
			PlanetName mars = PlanetName.Mars;
			PlanetName jupiter = PlanetName.Jupiter;
			double num4 = (dictionary3[PlanetName.Saturn] = mean[PlanetName.Sun]);
			double value = (dictionary3[jupiter] = num4);
			dictionary3[mars] = value;
			double num7 = 6.67 + 0.00133 * (double)(year - 1900);
			double num8 = num9 * 4.092385;
			double num10 = ((num8 < 0.0) ? (164.0 - num8) : (164.0 + num8));
			num10 -= num7;
			dictionary3[PlanetName.Mercury] = (num10 + num7) % 360.0;
			num7 = 5.0 + 0.0001 * (double)(year - 1900);
			double num11 = num9 * 1.602159;
			double num12 = ((num11 < 0.0) ? (328.51 - num11) : (328.51 + num11));
			num12 -= num7;
			dictionary3[PlanetName.Venus] = num12 % 360.0;
			return dictionary3;
		}
	}

	public static Shashtiamsa SunChestaBala(Time inputTime)
	{
		double num = (PlanetSayanaLatitude(PlanetName.Sun, inputTime) + Angle.Degrees90).TotalDegrees;
		if (num > 180.0)
		{
			num = 360.0 - num;
		}
		return new Shashtiamsa(num / 3.0);
	}

	public static Shashtiamsa MoonChestaBala(Time inputTime)
	{
		Angle value = PlanetNirayanaLongitude(PlanetName.Sun, inputTime);
		double num = PlanetNirayanaLongitude(PlanetName.Moon, inputTime).GetDifference(value).TotalDegrees;
		if (num > 180.0)
		{
			num = 360.0 - num;
		}
		return new Shashtiamsa(num / 3.0);
	}

	public static Dictionary<PlanetName, double> Madhya(double epochToBirthDays, Time time1)
	{
		int year = time1.GetLmtDateTimeOffset().Year;
		Dictionary<PlanetName, double> dictionary = new Dictionary<PlanetName, double>();
		double num = 257.4568;
		double num2 = epochToBirthDays * 0.9855931;
		double num3 = ((num2 < 0.0) ? (num - num2) : (num + num2));
		num3 %= 360.0;
		dictionary[PlanetName.Sun] = num3;
		PlanetName mercury = PlanetName.Mercury;
		double value = (dictionary[PlanetName.Venus] = dictionary[PlanetName.Sun]);
		dictionary[mercury] = value;
		double num5 = 270.22;
		double num6 = epochToBirthDays * 0.5240218;
		double num7 = ((num6 < 0.0) ? (num5 - num6) : (num5 + num6));
		num7 %= 360.0;
		dictionary[PlanetName.Mars] = num7;
		double num8 = 220.04;
		double num9 = epochToBirthDays * 0.08310024;
		double num10 = ((num9 < 0.0) ? (num8 - num9) : (num8 + num9));
		double num11 = 3.33 + 0.0067 * (double)(year - 1900);
		num10 -= num11;
		num10 %= 360.0;
		dictionary[PlanetName.Jupiter] = num10;
		double num12 = 220.04;
		double num13 = epochToBirthDays * 0.03333857;
		double num14 = ((num13 < 0.0) ? (num12 - num13) : (num12 + num13));
		double num15 = 5.0 + 0.001 * (double)(year - 1900);
		num14 += num15;
		num14 %= 360.0;
		dictionary[PlanetName.Saturn] = num14;
		if (dictionary.Any((KeyValuePair<PlanetName, double> x) => x.Value < 0.0))
		{
			throw new Exception("Madya/Mean can't be negative!");
		}
		return dictionary;
	}

	public static double EpochInterval(Time time1)
	{
		int year = time1.GetLmtDateTimeOffset().Year;
		int month = time1.GetLmtDateTimeOffset().Month;
		int day = time1.GetLmtDateTimeOffset().Day;
		int[] array = new int[13]
		{
			0, 31, 59, 90, 120, 151, 181, 212, 243, 273,
			304, 334, 365
		};
		int num = year - 1900;
		int num2 = num * 365 + num / 4 + array[month - 1] - 1 + day;
		int hour = time1.GetLmtDateTimeOffset().Hour;
		int minute = time1.GetLmtDateTimeOffset().Minute;
		double totalHours = time1.GetLmtDateTimeOffset().Offset.TotalHours;
		double num3 = new TimeSpan(hour, minute, 0).TotalHours + (5.066666666666666 - totalHours);
		return Math.Round((double)num2 + num3 / 24.0, 3);
	}

	public static PlanetMotion PlanetMotionName(PlanetName planetName, Time time)
	{
		return PlanetMotion.Direct;
	}

	public static bool IsPlanetRetrograde(PlanetName planetName, Time time)
	{
		bool result = false;
		if (planetName.Name == PlanetName.PlanetNameEnum.Sun || planetName.Name == PlanetName.PlanetNameEnum.Moon)
		{
			return false;
		}
		if (planetName.Name == PlanetName.PlanetNameEnum.Rahu || planetName.Name == PlanetName.PlanetNameEnum.Ketu)
		{
			return false;
		}
		Angle angle = PlanetNirayanaLongitude(planetName, time);
		Time time2 = time.AddHours(24.0);
		Angle angle2 = PlanetNirayanaLongitude(planetName, time2);
		Time time3 = time.AddHours(48.0);
		PlanetNirayanaLongitude(planetName, time3);
		Time time4 = time.AddHours(72.0);
		PlanetNirayanaLongitude(planetName, time4);
		if (angle2 <= angle)
		{
			result = ((!(angle.TotalDegrees >= 355.0) || !(angle.TotalDegrees <= 360.0) || !(angle2.TotalDegrees >= 0.0) || !(angle2.TotalDegrees <= 5.0)) ? true : false);
		}
		if (angle2 >= angle)
		{
			result = ((angle.TotalDegrees >= 0.0 && angle.TotalDegrees <= 5.0 && angle2.TotalDegrees >= 355.0 && angle2.TotalDegrees <= 0.0) ? true : false);
		}
		return result;
	}

	public static bool IsPlanetCombust()
	{
		return false;
	}

	public static double PlanetCirculationTime(PlanetName planetName)
	{
		if (planetName == PlanetName.Sun)
		{
			return 1.0;
		}
		if (planetName == PlanetName.Moon)
		{
			return 0.082;
		}
		if (planetName == PlanetName.Mars)
		{
			return 1.88;
		}
		if (planetName == PlanetName.Mercury)
		{
			return 0.24;
		}
		if (planetName == PlanetName.Jupiter)
		{
			return 11.86;
		}
		if (planetName == PlanetName.Venus)
		{
			return 0.62;
		}
		if (planetName == PlanetName.Saturn)
		{
			return 29.46;
		}
		throw new Exception("Planet circulation time not defined!");
	}

	public static Shashtiamsa PlanetSaptavargajaBala(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetSaptavargajaBala", planetName, time, Ayanamsa), _getPlanetSaptavargajaBala);
		Shashtiamsa _getPlanetSaptavargajaBala()
		{
			double num = 0.0;
			List<PlanetToSignRelationship> list = new List<PlanetToSignRelationship>();
			if (IsPlanetInMoolatrikona(planetName, time))
			{
				list.Add(PlanetToSignRelationship.Moolatrikona);
			}
			else
			{
				ZodiacName signName = PlanetZodiacSign(planetName, time).GetSignName();
				PlanetToSignRelationship item = PlanetRelationshipWithSign(planetName, signName, time);
				list.Add(item);
			}
			ZodiacName signName2 = PlanetHoraSigns(planetName, time).GetSignName();
			PlanetToSignRelationship item2 = PlanetRelationshipWithSign(planetName, signName2, time);
			list.Add(item2);
			ZodiacName signName3 = PlanetDrekkanaSign(planetName, time).GetSignName();
			PlanetToSignRelationship item3 = PlanetRelationshipWithSign(planetName, signName3, time);
			list.Add(item3);
			ZodiacName zodiacSignName = PlanetSaptamsaSign(planetName, time);
			PlanetToSignRelationship item4 = PlanetRelationshipWithSign(planetName, zodiacSignName, time);
			list.Add(item4);
			ZodiacName zodiacSignName2 = PlanetNavamsaSign(planetName, time);
			PlanetToSignRelationship item5 = PlanetRelationshipWithSign(planetName, zodiacSignName2, time);
			list.Add(item5);
			ZodiacName zodiacSignName3 = PlanetDwadasamsaSign(planetName, time);
			PlanetToSignRelationship item6 = PlanetRelationshipWithSign(planetName, zodiacSignName3, time);
			list.Add(item6);
			ZodiacName zodiacSignName4 = PlanetThrimsamsaSign(planetName, time);
			PlanetToSignRelationship item7 = PlanetRelationshipWithSign(planetName, zodiacSignName4, time);
			list.Add(item7);
			foreach (PlanetToSignRelationship item8 in list)
			{
				if (item8 == PlanetToSignRelationship.Moolatrikona)
				{
					num += 45.0;
				}
				if (item8 == PlanetToSignRelationship.OwnVarga)
				{
					num += 30.0;
				}
				if (item8 == PlanetToSignRelationship.BestFriendVarga)
				{
					num += 22.5;
				}
				if (item8 == PlanetToSignRelationship.FriendVarga)
				{
					num += 15.0;
				}
				if (item8 == PlanetToSignRelationship.NeutralVarga)
				{
					num += 7.5;
				}
				if (item8 == PlanetToSignRelationship.EnemyVarga)
				{
					num += 3.75;
				}
				if (item8 == PlanetToSignRelationship.BitterEnemyVarga)
				{
					num += 1.875;
				}
			}
			return new Shashtiamsa(num);
		}
	}

	public static Shashtiamsa PlanetSthanaBala(PlanetName planetName, Time time)
	{
		bool num = planetName.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag = planetName.Name == PlanetName.PlanetNameEnum.Ketu;
		if (num | flag)
		{
			return Shashtiamsa.Zero;
		}
		return CacheManager.GetCache(new CacheKey("PlanetSthanaBala", planetName, time, Ayanamsa), _getPlanetSthanaBala);
		Shashtiamsa _getPlanetSthanaBala()
		{
			Shashtiamsa shashtiamsa = PlanetOchchaBala(planetName, time);
			Shashtiamsa shashtiamsa2 = PlanetSaptavargajaBala(planetName, time);
			Shashtiamsa shashtiamsa3 = PlanetOjayugmarasyamsaBala(planetName, time);
			Shashtiamsa shashtiamsa4 = PlanetKendraBala(planetName, time);
			Shashtiamsa shashtiamsa5 = PlanetDrekkanaBala(planetName, time);
			return shashtiamsa + shashtiamsa2 + shashtiamsa3 + shashtiamsa4 + shashtiamsa5;
		}
	}

	public static Shashtiamsa PlanetDrekkanaBala(PlanetName planetName, Time time)
	{
		double totalDegrees = PlanetZodiacSign(planetName, time).GetDegreesInSign().TotalDegrees;
		if ((planetName == PlanetName.Sun || planetName == PlanetName.Jupiter || planetName == PlanetName.Mars) && totalDegrees >= 0.0 && totalDegrees <= 10.0)
		{
			return new Shashtiamsa(15.0);
		}
		if ((planetName == PlanetName.Saturn || planetName == PlanetName.Mercury) && totalDegrees > 10.0 && totalDegrees <= 20.0)
		{
			return new Shashtiamsa(15.0);
		}
		if ((planetName == PlanetName.Moon || planetName == PlanetName.Venus) && totalDegrees > 20.0 && totalDegrees <= 30.0)
		{
			return new Shashtiamsa(15.0);
		}
		return new Shashtiamsa(0.0);
	}

	public static Shashtiamsa PlanetKendraBala(PlanetName planetName, Time time)
	{
		switch ((int)PlanetZodiacSign(planetName, time).GetSignName())
		{
		case 1:
		case 4:
		case 7:
		case 10:
			return new Shashtiamsa(60.0);
		case 2:
		case 5:
		case 8:
		case 11:
			return new Shashtiamsa(30.0);
		case 3:
		case 6:
		case 9:
		case 12:
			return new Shashtiamsa(15.0);
		default:
			throw new Exception("Kendra Bala not found, error");
		}
	}

	public static Shashtiamsa PlanetOjayugmarasyamsaBala(PlanetName planetName, Time time)
	{
		ZodiacName signName = PlanetZodiacSign(planetName, time).GetSignName();
		ZodiacName planetSignName = PlanetNavamsaSign(planetName, time);
		double num = 0.0;
		if (planetName == PlanetName.Moon || planetName == PlanetName.Venus)
		{
			if (IsEvenSign(signName))
			{
				num += 15.0;
			}
			if (IsEvenSign(planetSignName))
			{
				num += 15.0;
			}
		}
		else if (planetName == PlanetName.Sun || planetName == PlanetName.Mars || planetName == PlanetName.Jupiter || planetName == PlanetName.Mercury || planetName == PlanetName.Saturn)
		{
			if (IsOddSign(signName))
			{
				num += 15.0;
			}
			if (IsOddSign(planetSignName))
			{
				num += 15.0;
			}
		}
		return new Shashtiamsa(num);
	}

	public static Shashtiamsa PlanetKalaBala(PlanetName planetName, Time time)
	{
		bool num = planetName.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag = planetName.Name == PlanetName.PlanetNameEnum.Ketu;
		if (num | flag)
		{
			return Shashtiamsa.Zero;
		}
		return CacheManager.GetCache(new CacheKey("PlanetKalaBala", planetName, time, Ayanamsa), _getPlanetKalaBala);
		Shashtiamsa _getPlanetKalaBala()
		{
			Dictionary<PlanetName, Shashtiamsa> dictionary = new Dictionary<PlanetName, Shashtiamsa>();
			foreach (PlanetName all7Planet in PlanetName.All7Planets)
			{
				Shashtiamsa value = GetPreKalaBala(all7Planet, time);
				dictionary.Add(all7Planet, value);
			}
			Shashtiamsa shashtiamsa = PlanetYuddhaBala(planetName, dictionary, time);
			return dictionary[planetName] + shashtiamsa;
		}
		static Shashtiamsa GetPreKalaBala(PlanetName planetName2, Time time2)
		{
			Shashtiamsa shashtiamsa = PlanetNathonnathaBala(planetName2, time2);
			Shashtiamsa shashtiamsa2 = PlanetPakshaBala(planetName2, time2);
			Shashtiamsa shashtiamsa3 = PlanetTribhagaBala(planetName2, time2);
			Shashtiamsa shashtiamsa4 = PlanetAbdaBala(planetName2, time2);
			Shashtiamsa shashtiamsa5 = PlanetMasaBala(planetName2, time2);
			Shashtiamsa shashtiamsa6 = PlanetVaraBala(planetName2, time2);
			Shashtiamsa shashtiamsa7 = PlanetHoraBala(planetName2, time2);
			Shashtiamsa shashtiamsa8 = PlanetAyanaBala(planetName2, time2);
			return shashtiamsa + shashtiamsa2 + shashtiamsa3 + shashtiamsa4 + shashtiamsa5 + shashtiamsa6 + shashtiamsa7 + shashtiamsa8;
		}
	}

	public static Shashtiamsa PlanetYuddhaBala(PlanetName inputedPlanet, Dictionary<PlanetName, Shashtiamsa> preKalaBalaValues, Time time)
	{
		if (inputedPlanet == PlanetName.Moon || inputedPlanet == PlanetName.Sun)
		{
			return Shashtiamsa.Zero;
		}
		Dictionary<PlanetName, Shashtiamsa> dictionary = new Dictionary<PlanetName, Shashtiamsa>();
		List<PlanetName> list = PlanetsInConjuction(inputedPlanet, time);
		list.RemoveAll((PlanetName pl) => pl == PlanetName.Rahu || pl == PlanetName.Ketu);
		foreach (PlanetName item in list)
		{
			if (item == PlanetName.Moon || item == PlanetName.Sun)
			{
				continue;
			}
			Angle angle = PlanetNirayanaLongitude(inputedPlanet, time);
			Angle angle2 = PlanetNirayanaLongitude(item, time);
			if (DistanceBetweenPlanets(angle, angle2) < Angle.FromDegrees(1.0))
			{
				PlanetName key = null;
				PlanetName key2 = null;
				if (angle < angle2)
				{
					key = inputedPlanet;
					key2 = item;
				}
				else if (angle > angle2)
				{
					key = item;
					key2 = inputedPlanet;
				}
				else if (angle == angle2)
				{
					LogManager.Error("Planets same longitude! Not expected, random result used!");
					key = inputedPlanet;
					key2 = item;
				}
				double num = Math.Abs(preKalaBalaValues[inputedPlanet].ToDouble() - preKalaBalaValues[item].ToDouble());
				double num2 = PlanetDiscDiameter(inputedPlanet).GetDifference(PlanetDiscDiameter(item)).TotalDegrees / num;
				dictionary[key] = new Shashtiamsa(num2);
				dictionary[key2] = new Shashtiamsa(0.0 - num2);
			}
		}
		if (!dictionary.TryGetValue(inputedPlanet, out var value))
		{
			return Shashtiamsa.Zero;
		}
		return value;
	}

	private static Angle PlanetDiscDiameter(PlanetName planet)
	{
		if (planet == PlanetName.Mars)
		{
			return new Angle(0.0, 9.0, 4L);
		}
		if (planet == PlanetName.Mercury)
		{
			return new Angle(0.0, 6.0, 6L);
		}
		if (planet == PlanetName.Jupiter)
		{
			return new Angle(0.0, 190.0, 4L);
		}
		if (planet == PlanetName.Venus)
		{
			return new Angle(0.0, 16.0, 6L);
		}
		if (planet == PlanetName.Saturn)
		{
			return new Angle(0.0, 158.0, 0L);
		}
		throw new Exception("Disc diameter now found!");
	}

	public static Shashtiamsa PlanetAyanaBala(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetAyanaBala", planetName, time, Ayanamsa), _getPlanetAyanaBala);
		Shashtiamsa _getPlanetAyanaBala()
		{
			double num = 0.0;
			double num2 = PlanetDeclination(planetName, time);
			Angle.FromDegrees(24.0);
			bool flag = !(num2 < 0.0);
			double num3 = Math.Abs(num2);
			if (planetName == PlanetName.Venus || planetName == PlanetName.Sun || planetName == PlanetName.Mars || planetName == PlanetName.Jupiter)
			{
				num = ((!flag) ? ((24.0 - num3) / 48.0 * 60.0) : ((24.0 + num3) / 48.0 * 60.0));
				if (planetName == PlanetName.Sun)
				{
					num *= 2.0;
				}
			}
			else if (planetName == PlanetName.Saturn || planetName == PlanetName.Moon)
			{
				num = (flag ? ((24.0 - num3) / 48.0 * 60.0) : ((24.0 + num3) / 48.0 * 60.0));
			}
			else if (planetName == PlanetName.Mercury)
			{
				num = (24.0 + num3) / 48.0 * 60.0;
			}
			return new Shashtiamsa(num);
		}
	}

	public static double PlanetDeclination(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetDeclination", planetName, time, Ayanamsa), _getPlanetDeclination);
		double _getPlanetDeclination()
		{
			double num = EclipticObliquity(time);
			Angle angle = PlanetSayanaLongitude(planetName, time);
			return PlanetSayanaLatitude(planetName, time).TotalDegrees + num * Math.Sin(0.0174532925199433 * angle.TotalDegrees);
		}
	}

	public static double EclipticObliquity(Time time)
	{
		return CacheManager.GetCache(new CacheKey("EclipticObliquity", time, Ayanamsa), _getPlanetEps);
		double _getPlanetEps()
		{
			string serr = "";
			double[] array = new double[6];
			SwissEph swissEph = new SwissEph();
			double tjd = TimeToEphemerisTime(time);
			swissEph.swe_calc(tjd, -1, 0, array, ref serr);
			return array[0];
		}
	}

	public static Shashtiamsa PlanetHoraBala(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetHoraBala", planetName, time, Ayanamsa), _getPlanetHoraBala);
		Shashtiamsa _getPlanetHoraBala()
		{
			DayOfWeek day = DayOfWeek(time);
			if (LordOfHoraFromWeekday(HoraAtBirth(time), day) == planetName)
			{
				return new Shashtiamsa(60.0);
			}
			return Shashtiamsa.Zero;
		}
	}

	public static Shashtiamsa PlanetAbdaBala(PlanetName planetName, Time time)
	{
		return CacheManager.GetCache(new CacheKey("PlanetAbdaBala", planetName, time, Ayanamsa), _getPlanetAbdaBala);
		Shashtiamsa _getPlanetAbdaBala()
		{
			dynamic val = YearAndMonthLord(time);
			if (val.YearLord == planetName)
			{
				return new Shashtiamsa(15.0);
			}
			return Shashtiamsa.Zero;
		}
	}

	public static Shashtiamsa PlanetMasaBala(PlanetName planetName, Time time)
	{
		dynamic val = YearAndMonthLord(time);
		if (val.MonthLord == planetName)
		{
			return new Shashtiamsa(30.0);
		}
		return Shashtiamsa.Zero;
	}

	public static Shashtiamsa PlanetVaraBala(PlanetName planetName, Time time)
	{
		if (LordOfWeekday(time) == planetName)
		{
			return new Shashtiamsa(45.0);
		}
		return Shashtiamsa.Zero;
	}

	public static object YearAndMonthLord(Time time)
	{
		return CacheManager.GetCache(new CacheKey("YearAndMonthLord", time, Ayanamsa), _getYearAndMonthLord);
		object _getYearAndMonthLord()
		{
			_ = PlanetName.Sun;
			PlanetName sun = PlanetName.Sun;
			using SwissEph swissEph = new SwissEph();
			double num = swissEph.swe_julday(1827, 5, 2, 0.0, 1);
			double num2 = GreenwichLmtInJulianDays(time);
			double num3 = num2 - num;
			if (num3 >= 0.0)
			{
				double num4 = Math.Floor(num3 / 360.0);
				num3 -= num4 * 360.0;
			}
			else
			{
				double num5 = Math.Ceiling((0.0 - num3) / 360.0);
				num3 += num5 * 360.0;
			}
			double num6 = num3;
			while (num3 > 30.0)
			{
				num3 -= 30.0;
			}
			double num7 = num3;
			while (num3 > 7.0)
			{
				num3 -= 7.0;
			}
			int dayNumber = swissEph.swe_day_of_week(num2 - num6);
			int dayNumber2 = swissEph.swe_day_of_week(num2 - num7);
			DayOfWeek weekday = swissEphWeekDayToMuhurthaDay(dayNumber);
			DayOfWeek weekday2 = swissEphWeekDayToMuhurthaDay(dayNumber2);
			PlanetName yearLord = LordOfWeekday(weekday);
			sun = LordOfWeekday(weekday2);
			return new
			{
				YearLord = yearLord,
				MonthLord = sun
			};
		}
		static DayOfWeek swissEphWeekDayToMuhurthaDay(int dayNumber)
		{
			return dayNumber switch
			{
				0 => VedAstro.Library.DayOfWeek.Monday, 
				1 => VedAstro.Library.DayOfWeek.Tuesday, 
				2 => VedAstro.Library.DayOfWeek.Wednesday, 
				3 => VedAstro.Library.DayOfWeek.Thursday, 
				4 => VedAstro.Library.DayOfWeek.Friday, 
				5 => VedAstro.Library.DayOfWeek.Saturday, 
				6 => VedAstro.Library.DayOfWeek.Sunday, 
				_ => throw new Exception("Invalid day number!"), 
			};
		}
	}

	public static Shashtiamsa PlanetTribhagaBala(PlanetName planetName, Time time)
	{
		PlanetName planetName2 = PlanetName.Jupiter;
		Time time2 = SunsetTime(time);
		if (IsDayBirth(time))
		{
			Time time3 = SunriseTime(time);
			double num = time2.Subtract(time3).TotalHours / 3.0;
			switch ((int)Math.Floor(time.Subtract(time3).TotalHours / num))
			{
			case 0:
				planetName2 = PlanetName.Mercury;
				break;
			case 1:
				planetName2 = PlanetName.Sun;
				break;
			case 2:
				planetName2 = PlanetName.Saturn;
				break;
			}
		}
		else
		{
			double num2 = SunriseTime(time.AddHours(24.0)).Subtract(time2).TotalHours / 3.0;
			switch ((int)Math.Floor(time.Subtract(time2).TotalHours / num2))
			{
			case 0:
				planetName2 = PlanetName.Moon;
				break;
			case 1:
				planetName2 = PlanetName.Venus;
				break;
			case 2:
				planetName2 = PlanetName.Mars;
				break;
			}
		}
		if (planetName == PlanetName.Jupiter || planetName == planetName2)
		{
			return new Shashtiamsa(60.0);
		}
		return new Shashtiamsa(0.0);
	}

	public static Shashtiamsa PlanetOchchaBala(PlanetName planetName, Time time)
	{
		Angle planet = PlanetNirayanaLongitude(planetName, time);
		Angle planet2 = LongitudeAtZodiacSign(PlanetDebilitationPoint(planetName));
		Angle angle = DistanceBetweenPlanets(planet, planet2);
		if (angle.TotalDegrees > 180.0)
		{
			angle = DistanceBetweenPlanets(angle, Angle.Degrees360);
		}
		return new Shashtiamsa(angle.TotalDegrees / 3.0);
	}

	public static Shashtiamsa PlanetPakshaBala(PlanetName planetName, Time time)
	{
		double num = 0.0;
		MoonPhase moonPhase = LunarDay(time).GetMoonPhase();
		Angle planet = PlanetNirayanaLongitude(PlanetName.Sun, time);
		Angle angle = DistanceBetweenPlanets(PlanetNirayanaLongitude(PlanetName.Moon, time), planet);
		if (angle.TotalDegrees > 180.0)
		{
			angle = DistanceBetweenPlanets(angle, Angle.Degrees360);
		}
		double num2 = 0.0;
		switch (moonPhase)
		{
		case MoonPhase.BrightHalf:
			num2 = angle.TotalDegrees / 3.0;
			break;
		case MoonPhase.DarkHalf:
			num2 = DistanceBetweenPlanets(angle, Angle.Degrees360).TotalDegrees / 3.0;
			break;
		}
		double num3 = 60.0 - num2;
		bool flag = IsPlanetMalefic(planetName, time);
		bool num4 = IsPlanetBenefic(planetName, time);
		if (num4 && !flag)
		{
			num = num2;
		}
		if (!num4 && flag)
		{
			num = num3;
		}
		if (planetName == PlanetName.Moon)
		{
			num *= 2.0;
		}
		if (num == 0.0)
		{
			throw new Exception("Paksha bala not found, error!");
		}
		return new Shashtiamsa(num);
	}

	public static Shashtiamsa PlanetNathonnathaBala(PlanetName planetName, Time time)
	{
		bool num = planetName.Name == PlanetName.PlanetNameEnum.Rahu;
		bool flag = planetName.Name == PlanetName.PlanetNameEnum.Ketu;
		if (num | flag)
		{
			return Shashtiamsa.Zero;
		}
		DateTime dateTime = LocalApparentTime(time);
		int hour = dateTime.Hour;
		double num2 = (double)dateTime.Minute / 60.0;
		double num3 = (double)dateTime.Second / 3600.0;
		double num4 = ((double)hour + num2 + num3) * 15.0;
		if (num4 > 180.0)
		{
			num4 = 360.0 - num4;
		}
		if (planetName == PlanetName.Sun || planetName == PlanetName.Jupiter || planetName == PlanetName.Venus)
		{
			return new Shashtiamsa(num4 / 3.0);
		}
		if (planetName == PlanetName.Saturn || planetName == PlanetName.Moon || planetName == PlanetName.Mars)
		{
			return new Shashtiamsa((180.0 - num4) / 3.0);
		}
		if (planetName == PlanetName.Mercury)
		{
			return new Shashtiamsa(60.0);
		}
		throw new Exception("Planet Nathonnatha Bala not found, error!");
	}

	public static Shashtiamsa PlanetDigBala(PlanetName planetName, Time time)
	{
		try
		{
			bool num = planetName.Name == PlanetName.PlanetNameEnum.Rahu;
			bool flag = planetName.Name == PlanetName.PlanetNameEnum.Ketu;
			if (num | flag)
			{
				return Shashtiamsa.Zero;
			}
			Angle planet = PlanetNirayanaLongitude(planetName, time);
			Angle angle = null;
			if (planetName == PlanetName.Sun || planetName == PlanetName.Mars)
			{
				angle = HouseLongitude(HouseName.House4, time).GetMiddleLongitude();
			}
			if (planetName == PlanetName.Jupiter || planetName == PlanetName.Mercury)
			{
				angle = HouseLongitude(HouseName.House7, time).GetMiddleLongitude();
			}
			if (planetName == PlanetName.Venus || planetName == PlanetName.Moon)
			{
				angle = HouseLongitude(HouseName.House10, time).GetMiddleLongitude();
			}
			if (planetName == PlanetName.Saturn)
			{
				angle = HouseLongitude(HouseName.House1, time).GetMiddleLongitude();
			}
			_ = angle.TotalDegrees;
			Angle planet2 = angle;
			Angle angle2 = DistanceBetweenPlanets(planet, planet2);
			if (angle2 > Angle.Degrees180)
			{
				angle2 = DistanceBetweenPlanets(angle2, Angle.Degrees360);
			}
			return new Shashtiamsa(angle2.TotalDegrees / 3.0);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			return Shashtiamsa.Zero;
		}
	}

	public static Shashtiamsa HouseStrength(HouseName inputHouse, Time time)
	{
		return CacheManager.GetCache(new CacheKey("HouseStrength", inputHouse, time, Ayanamsa), _getBhavabala);
		Shashtiamsa _getBhavabala()
		{
			List<HouseSubStrength> list = new List<HouseSubStrength>
			{
				BhavaAdhipathiBala(time),
				BhavaDigBala(time),
				BhavaDrishtiBala(time)
			};
			Dictionary<HouseName, double> dictionary = new Dictionary<HouseName, double>();
			foreach (HouseName allHouse in House.AllHouses)
			{
				double num = 0.0;
				foreach (HouseSubStrength item in list)
				{
					num += item.Power[allHouse];
				}
				dictionary[allHouse] = num;
			}
			return new Shashtiamsa(dictionary[inputHouse]);
		}
	}

	public static HouseSubStrength BhavaDrishtiBala(Time time)
	{
		return CacheManager.GetCache(new CacheKey("BhavaDrishtiBala", time, Ayanamsa), _calcBhavaDrishtiBala);
		HouseSubStrength _calcBhavaDrishtiBala()
		{
			Dictionary<PlanetName, int> dictionary = goodAndBad();
			double vdrishti;
			Dictionary<string, double> dictionary2 = GetDrishtiKendra(time);
			double num = 0.0;
			Dictionary<HouseName, double> dictionary3 = new Dictionary<HouseName, double>();
			foreach (HouseName allHouse in House.AllHouses)
			{
				num = 0.0;
				foreach (PlanetName all7Planet in PlanetName.All7Planets)
				{
					num += (double)dictionary[all7Planet] * dictionary2[all7Planet.ToString() + allHouse];
				}
				dictionary3[allHouse] = num;
			}
			return new HouseSubStrength(dictionary3, "BhavaDrishtiBala");
			Dictionary<string, double> GetDrishtiKendra(Time time2)
			{
				Dictionary<string, double> dictionary4 = new Dictionary<string, double>();
				foreach (PlanetName all7Planet2 in PlanetName.All7Planets)
				{
					foreach (HouseName allHouse2 in House.AllHouses)
					{
						Angle middleLongitude = HouseLongitude(allHouse2, time2).GetMiddleLongitude();
						Angle angle = PlanetNirayanaLongitude(all7Planet2, time2);
						double num2 = (middleLongitude - angle).TotalDegrees;
						if (num2 < 0.0)
						{
							num2 += 360.0;
						}
						vdrishti = FindViseshaDrishti(num2, all7Planet2);
						if (all7Planet2 == PlanetName.Mercury || all7Planet2 == PlanetName.Jupiter)
						{
							dictionary4[all7Planet2.ToString() + allHouse2] = FindDrishtiValue(num2) + vdrishti;
						}
						else
						{
							dictionary4[all7Planet2.ToString() + allHouse2] = (FindDrishtiValue(num2) + vdrishti) / 4.0;
						}
					}
				}
				return dictionary4;
			}
		}
		Dictionary<PlanetName, int> goodAndBad()
		{
			Dictionary<PlanetName, int> dictionary = new Dictionary<PlanetName, int>();
			foreach (PlanetName all7Planet3 in PlanetName.All7Planets)
			{
				if (all7Planet3 == PlanetName.Mercury)
				{
					dictionary[all7Planet3] = 1;
				}
				else if (IsPlanetBenefic(all7Planet3, time))
				{
					dictionary[all7Planet3] = 1;
				}
				else
				{
					dictionary[all7Planet3] = -1;
				}
			}
			return dictionary;
		}
	}

	public static HouseSubStrength BhavaDigBala(Time time)
	{
		Dictionary<HouseName, double> dictionary = new Dictionary<HouseName, double>();
		int num = 0;
		foreach (HouseName allHouse in House.AllHouses)
		{
			double totalDegrees = HouseLongitude(allHouse, time).GetMiddleLongitude().TotalDegrees;
			HouseSignName(allHouse, time);
			if (totalDegrees >= 210.0 && totalDegrees <= 240.0)
			{
				num = (int)(1 - allHouse);
			}
			else if ((totalDegrees >= 0.0 && totalDegrees <= 60.0) || (totalDegrees >= 120.0 && totalDegrees <= 150.0) || (totalDegrees >= 255.0 && totalDegrees <= 285.0))
			{
				num = (int)(4 - allHouse);
			}
			else if ((totalDegrees >= 60.0 && totalDegrees <= 90.0) || (totalDegrees >= 150.0 && totalDegrees <= 210.0) || (totalDegrees >= 300.0 && totalDegrees <= 330.0) || (totalDegrees >= 240.0 && totalDegrees <= 255.0))
			{
				num = (int)(7 - allHouse);
			}
			else if ((totalDegrees >= 90.0 && totalDegrees <= 120.0) || (totalDegrees >= 330.0 && totalDegrees <= 360.0) || (totalDegrees >= 285.0 && totalDegrees <= 300.0))
			{
				num = (int)(10 - allHouse);
			}
			if (num < 0)
			{
				num += 12;
			}
			if (num > 6)
			{
				num = 12 - num;
			}
			dictionary[allHouse] = (double)num * 10.0;
		}
		return new HouseSubStrength(dictionary, "BhavaDigBala");
	}

	public static HouseSubStrength BhavaAdhipathiBala(Time time)
	{
		return CacheManager.GetCache(new CacheKey("BhavaAdhipathiBala", time, Ayanamsa), _calcBhavaAdhipathiBala);
		HouseSubStrength _calcBhavaAdhipathiBala()
		{
			Dictionary<HouseName, double> dictionary = new Dictionary<HouseName, double>();
			foreach (HouseName allHouse in House.AllHouses)
			{
				PlanetName planetName = LordOfHouse(allHouse, time);
				dictionary[allHouse] = PlanetShadbalaPinda(planetName, time).ToDouble();
			}
			return new HouseSubStrength(dictionary, "BhavaAdhipathiBala");
		}
	}

	public static List<PlanetName> BeneficPlanetListByShadbala(Time personBirthTime, int threshold)
	{
		List<PlanetName> list = new List<PlanetName>();
		foreach (var item in AllPlanetStrength(personBirthTime))
		{
			if (item.Item1 > (double)threshold)
			{
				list.Add(item.Item2);
			}
		}
		return list;
	}

	public static List<PlanetName> BeneficPlanetListByShadbala(Time personBirthTime)
	{
		List<PlanetName> list = AllPlanetOrderedByStrength(personBirthTime);
		return new List<PlanetName> { list[0] };
	}

	public static List<HouseName> BeneficHouseListByShadbala(Time personBirthTime, int threshold)
	{
		List<HouseName> list = new List<HouseName>();
		foreach (HouseName allHouse in House.AllHouses)
		{
			if (HouseStrength(allHouse, personBirthTime).ToDouble() > (double)threshold)
			{
				list.Add(allHouse);
			}
		}
		return list;
	}

	public static List<HouseName> BeneficHouseListByShadbala(Time personBirthTime)
	{
		HouseName[] array = AllHousesOrderedByStrength(personBirthTime);
		return new List<HouseName> { array[0] };
	}

	public static List<PlanetName> MaleficPlanetListByShadbala(Time personBirthTime, int threshold)
	{
		List<PlanetName> list = new List<PlanetName>();
		foreach (var item in AllPlanetStrength(personBirthTime))
		{
			if (item.Item1 < (double)threshold)
			{
				list.Add(item.Item2);
			}
		}
		return list;
	}

	public static List<PlanetName> MaleficPlanetListByShadbala(Time personBirthTime)
	{
		List<PlanetName> list = AllPlanetOrderedByStrength(personBirthTime);
		List<PlanetName> list2 = new List<PlanetName>();
		list2.Add(list[list.Count - 1]);
		return list2;
	}

	public static List<HouseName> MaleficHouseListByShadbala(Time personBirthTime, int threshold)
	{
		List<HouseName> list = new List<HouseName>();
		foreach (HouseName allHouse in House.AllHouses)
		{
			if (HouseStrength(allHouse, personBirthTime).ToDouble() < (double)threshold)
			{
				list.Add(allHouse);
			}
		}
		return list;
	}

	public static List<HouseName> MaleficHouseListByShadbala(Time personBirthTime)
	{
		HouseName[] array = AllHousesOrderedByStrength(personBirthTime);
		return new List<HouseName> { array[^1] };
	}

	public static string GetHouseTags(HouseName house)
	{
		return house switch
		{
			HouseName.House1 => "beginning of life, childhood, health, environment, personality, the physical body and character", 
			HouseName.House2 => "family, face, right eye, food, wealth, literary gift, and manner and source of death, self-acquisition and optimism", 
			HouseName.House3 => "brothers and sisters, intelligence, cousins and other immediate relations", 
			HouseName.House4 => "peace of mind, home life, mother, conveyances, house property, landed and ancestral properties, education and neck and shoulders", 
			HouseName.House5 => "children, grandfather, intelligence, emotions and fame", 
			HouseName.House6 => "debts, diseases, enemies, miseries, sorrows, illness and disappointments", 
			HouseName.House7 => "wife, husband, marriage, urinary organs, marital happiness, sexual diseases, business partner, diplomacy, talent, energies and general happiness", 
			HouseName.House8 => "longevity, legacies and gifts and unearned wealth, cause of death, disgrace, degradation and details pertaining to death", 
			HouseName.House9 => "father, righteousness, preceptor, grandchildren, intuition, religion, sympathy, fame, charities, leadership, journeys and communications with spirits", 
			HouseName.House10 => "occupation, profession, temporal honours, foreign travels, self-respect, knowledge and dignity and means of livelihood", 
			HouseName.House11 => "means of gains, elder brother and freedom from misery", 
			HouseName.House12 => "losses, expenditure, waste, extravagance, sympathy, divine knowledge, Moksha and the state after death", 
			_ => throw new Exception("House details not found!"), 
		};
	}

	public static string GetSignTags(ZodiacName zodiacName)
	{
		return zodiacName switch
		{
			ZodiacName.Aries => "movable, odd, masculine, cruel, fiery, of short ascension, rising by hinder part, powerful during the night", 
			ZodiacName.Taurus => "fixed, even, feminine, mild,earthy, fruitful, of short ascension, rising by hinder part", 
			ZodiacName.Gemini => "common, odd, masculine, cruel, airy, barren, of short ascension, rising by the head.", 
			ZodiacName.Cancer => "even, movable, feminine, mild, watery, of long ascension, rising by the hinder part and fruitful.", 
			ZodiacName.Leo => "fixed, odd, masculine, cruel, fiery, of long ascension, barren, rising by the head.", 
			ZodiacName.Virgo => "common, even, feminine, mild, earthy, of long ascension, rising by the head.", 
			ZodiacName.Libra => "movable, odd, masculine, cruel, airy, of long ascension, rising by the head.", 
			ZodiacName.Scorpio => "fixed, even, feminine, mild, watery, of long ascension, rising by the head.", 
			ZodiacName.Sagittarius => "common, odd, masculine, cruel, fiery, of long ascension, rising by the hinder part.", 
			ZodiacName.Capricorn => "movable, even, feminine, mild, earthy, of long ascension, rising by hinder part", 
			ZodiacName.Aquarius => "fixed, odd, masculine, cruel, fruitful, airy, of short ascension, rising by the head.", 
			ZodiacName.Pisces => "common, feminine, water, even, mild, of short ascension, rising by head and hinder part.", 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public static string GetPlanetTags(List<PlanetName> planetList)
	{
		return planetList.Aggregate("", (string current, PlanetName planet) => current + GetPlanetTags(planet));
	}

	public static string GetPlanetTags(PlanetName lordOfHouse)
	{
		return lordOfHouse.Name switch
		{
			PlanetName.PlanetNameEnum.Sun => "Father, masculine, malefic, copper colour, philosophical tendency, royal, ego, sons, patrimony, self reliance, political power, windy and bilious temperament, month, places of worship, money-lenders, goldsmith, bones, fires, coronation chambers, doctoring capacity", 
			PlanetName.PlanetNameEnum.Moon => "Mother, feminine, mind, benefic when waxing, malefic when waning, white colour, women, sea-men, pearls, gems, water, fishermen, stubbornness, romances, bath-rooms, blood, popularity, human responsibilities", 
			PlanetName.PlanetNameEnum.Mars => "Brothers, masculine, blood-red colour, malefic, refined taste, base metals, vegetation, rotten things, orators, ambassadors, military activities, commerce, aerial journeys, weaving, public speakers.", 
			PlanetName.PlanetNameEnum.Mercury => "Profession, benefic if well associated, hermaphrodite, green colour, mercantile activity, public speakers, cold nervous, intelligence", 
			PlanetName.PlanetNameEnum.Jupiter => "Children, masculine, benefic, bright yellow colour, devotion, truthfulness, religious fervour, philosophical wisdom, corpulence", 
			PlanetName.PlanetNameEnum.Venus => "Wife, feminine, benefic, mixture of all colours, love affairs, sensual pleasure, family bliss, harems of ill-fame, vitality", 
			PlanetName.PlanetNameEnum.Saturn => "Longevity, malefic, hermaphrodite, dark colour, stubbornness, impetuosity, demoralisation, windy diseases, despondency, gambling", 
			PlanetName.PlanetNameEnum.Rahu => "Maternal relations, malefic, feminine, renunciation, corruption, epidemics", 
			PlanetName.PlanetNameEnum.Ketu => "Paternal relations, Hermaphrodite, malefic, religious, sectarian principles, pride, selfishness, occultism, mendicancy", 
			_ => "", 
		};
	}

	public static string GetHouseType(HouseName houseNumber)
	{
		string text = "";
		switch (houseNumber)
		{
		case HouseName.House1:
		case HouseName.House4:
		case HouseName.House7:
		case HouseName.House10:
			text += "Quadrants (kendras)";
			break;
		case HouseName.House5:
		case HouseName.House9:
			text += "Trines (Trikonas)";
			break;
		}
		switch (houseNumber)
		{
		case HouseName.House2:
		case HouseName.House5:
		case HouseName.House8:
		case HouseName.House11:
			text += "Cadent (Panaparas)";
			break;
		case HouseName.House3:
		case HouseName.House6:
		case HouseName.House9:
		case HouseName.House12:
			text += "Succeedent (Apoklimas)";
			break;
		}
		if (houseNumber == HouseName.House3 || houseNumber == HouseName.House6 || (uint)(houseNumber - 10) <= 1u)
		{
			text += "Upachayas";
		}
		return text;
	}

	public static string GetDasaInfoForAscendant(ZodiacName ascendantName)
	{
		return ascendantName switch
		{
			ZodiacName.Aries => "\r\n                        Aries - Saturn, Mercury and Venus are ill-disposed.\r\n                        Jupiter and the Sun are auspicious. The mere combination\r\n                        of Jupiler and Saturn produces no beneficial results. Jupiter\r\n                        is the Yogakaraka or the planet producing success. If Venus\r\n                        becomes a maraka, he will not kill the native but planets like\r\n                        Saturn will bring about death to the person.\r\n                        ", 
			ZodiacName.Taurus => "\r\n                        Taurus - Saturn is the most auspicious and powerful\r\n                        planet. Jupiter, Venus and the Moon are evil planets. Saturn\r\n                        alone produces Rajayoga. The native will be killed in the\r\n                        periods and sub-periods of Jupiter, Venus and the Moon if\r\n                        they get death-inflicting powers.\r\n                        ", 
			ZodiacName.Gemini => "\r\n                        Gemini - Mars, Jupiter and the Sun are evil. Venus alone\r\n                        is most beneficial and in conjunction with Saturn in good signs\r\n                        produces and excellent career of much fame. Combination\r\n                        of Saturn and Jupiter produces similar results as in Aries.\r\n                        Venus and Mercury, when well associated, cause Rajayoga.\r\n                        The Moon will not kill the person even though possessed of\r\n                        death-inflicting powers.\r\n                        ", 
			ZodiacName.Cancer => "\r\n                        Cancer - Venus and Mercury are evil. Jupiter and Mars\r\n                        give beneficial results. Mars is the Rajayogakaraka\r\n                        (conferor of name and fame). The combination of Mars and Jupiter\r\n                        also causes Rajayoga (combination for political success). The\r\n                        Sun does not kill the person although possessed of maraka\r\n                        powers. Venus and other inauspicious planets kill the native.\r\n                        Mars in combination with the Moon or Jupiter in favourable\r\n                        houses especially the 1st, the 5th, the 9th and the 10th\r\n                        produces much reputation.\r\n                        ", 
			ZodiacName.Leo => "\r\n                        Leo - Mars is the most auspicious and favourable planet.\r\n                        The combination of Venus and Jupiter does not cause Rajayoga\r\n                        but the conjunction of Jupiter and Mars in favourable\r\n                        houses produce Rajayoga. Saturn, Venus and Mercury are\r\n                        evil. Saturn does not kill the native when he has the maraka\r\n                        power but Mercury and other evil planets inflict death when\r\n                        they get maraka powers.\r\n                        ", 
			ZodiacName.Virgo => "\r\n                        Virgo - Venus alone is the most powerful. Mercury and\r\n                        Venus when combined together cause Rajayoga. Mars and\r\n                        the Moon are evil. The Sun does not kill the native even if\r\n                        be becomes a maraka but Venus, the Moon and Jupiter will\r\n                        inflict death when they are possessed of death-infticting power.\r\n                        ", 
			ZodiacName.Libra => "\r\n                        Libra - Saturn alone causes Rajayoga. Jupiter, the Sun\r\n                        and Mars are inauspicious. Mercury and Saturn produce good.\r\n                        The conjunction of the Moon and Mercury produces Rajayoga.\r\n                        Mars himself will not kill the person. Jupiter, Venus\r\n                        and Mars when possessed of maraka powers certainly kill the\r\n                        nalive.\r\n                        ", 
			ZodiacName.Scorpio => "\r\n                        Scorpio - Jupiter is beneficial. The Sun and the Moon\r\n                        produce Rajayoga. Mercury and Venus are evil. Jupiter,\r\n                        even if be becomes a maraka, does not inflict death. Mercury\r\n                        and other evil planets, when they get death-inlflicting powers,\r\n                        do not certainly spare the native.\r\n                        ", 
			ZodiacName.Sagittarius => "\r\n                        Sagittarius - Mars is the best planet and in conjunction\r\n                        with Jupiter, produces much good. The Sun and Mars also\r\n                        produce good. Venus is evil. When the Sun and Mars\r\n                        combine together they produce Rajayoga. Saturn does not\r\n                        bring about death even when he is a maraka. But Venus\r\n                        causes death when be gets jurisdiction as a maraka planet.\r\n                        ", 
			ZodiacName.Capricorn => "\r\n                        Capricorn - Venus is the most powerful planet and in\r\n                        conjunction with Mercury produces Rajayoga. Mars, Jupiter\r\n                        and the Moon are evil.\r\n                        ", 
			ZodiacName.Aquarius => "\r\n                        Aquarius - Venus alone is auspicious. The combination of\r\n                        Venus and Mars causes Rajayoga. Jupiter and the Moon are\r\n                        evil.\r\n                        ", 
			ZodiacName.Pisces => "\r\n                        Pisces - The Moon and Mars are auspicious. Mars is\r\n                        most powerful. Mars with the Moon or Jupiter causes Rajayoga.\r\n                        Saturn, Venus, the Sun and Mercury are evil. Mars\r\n                        himself does not kill the person even if he is a maraka.\r\n                        ", 
			_ => throw new ArgumentOutOfRangeException("ascendantName", ascendantName, null), 
		};
	}

	public static PlanetName PickOutStrongestPlanet(List<PlanetName> relatedPlanets, Time birthTime)
	{
		if (relatedPlanets.Count == 1)
		{
			return relatedPlanets[0];
		}
		Dictionary<PlanetName, double> dictionary = new Dictionary<PlanetName, double>();
		foreach (PlanetName relatedPlanet in relatedPlanets)
		{
			dictionary.Add(relatedPlanet, PlanetStrength(relatedPlanet, birthTime).ToDouble());
		}
		return dictionary.Aggregate((KeyValuePair<PlanetName, double> l, KeyValuePair<PlanetName, double> r) => (!(l.Value > r.Value)) ? r : l).Key;
	}

	public static SignProperties SignProperties(ZodiacName inputSign)
	{
		return new SignProperties(inputSign);
	}
}
