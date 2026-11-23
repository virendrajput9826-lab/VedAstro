using System.Collections.Generic;
using System.Linq;

namespace VedAstro.Library;

public static class Ashtakavarga
{
	private static readonly Dictionary<string, int[]> ShortcutTable = new Dictionary<string, int[]>
	{
		{
			PlanetName.Sun.ToString(),
			new int[12]
			{
				3, 3, 3, 3, 2, 3, 4, 5, 3, 5,
				7, 2
			}
		},
		{
			PlanetName.Moon.ToString(),
			new int[12]
			{
				2, 3, 5, 2, 2, 5, 2, 2, 2, 3,
				7, 1
			}
		},
		{
			PlanetName.Mars.ToString(),
			new int[12]
			{
				4, 5, 3, 4, 3, 3, 4, 4, 4, 6,
				7, 2
			}
		},
		{
			PlanetName.Mercury.ToString(),
			new int[12]
			{
				3, 1, 5, 2, 6, 6, 1, 2, 5, 5,
				7, 3
			}
		},
		{
			PlanetName.Jupiter.ToString(),
			new int[12]
			{
				2, 1, 1, 2, 3, 4, 2, 4, 2, 4,
				7, 4
			}
		},
		{
			PlanetName.Venus.ToString(),
			new int[12]
			{
				2, 3, 3, 3, 4, 4, 2, 3, 4, 3,
				6, 3
			}
		},
		{
			PlanetName.Saturn.ToString(),
			new int[12]
			{
				3, 2, 4, 4, 4, 3, 3, 4, 4, 4,
				6, 1
			}
		},
		{
			"Ascendant",
			new int[12]
			{
				5, 3, 5, 5, 2, 6, 1, 2, 2, 6,
				7, 1
			}
		}
	};

	public static Prastaraka PlanetPrastaraka(PlanetName inputPlanet, Time birthTime)
	{
		List<string> list = PlanetName.All7Planets.Select((PlanetName e) => e.ToString()).ToList();
		list.Add("Ascendant");
		Dictionary<string, int[]> dictionary = new Dictionary<string, int[]>();
		foreach (string item in list)
		{
			int[] value = PlanetBeneficAshtakaHouse(inputPlanet.Name.ToString(), item);
			dictionary.Add(item, value);
		}
		Prastaraka prastaraka = new Prastaraka();
		foreach (string item2 in list)
		{
			ZodiacName inputSign = ((item2 == "Ascendant") ? Calculate.HouseSignName(HouseName.House1, birthTime) : Calculate.PlanetZodiacSign(PlanetName.Parse(item2), birthTime).GetSignName());
			Dictionary<ZodiacName, int> dictionary2 = ZodiacNameExtensions.AllZodiacSignsDictionary(0);
			int[] array = dictionary[item2];
			foreach (int countToNextSign in array)
			{
				ZodiacName key = Calculate.SignCountedFromInputSign(inputSign, countToNextSign);
				dictionary2[key] = 1;
			}
			prastaraka[item2] = dictionary2;
		}
		return prastaraka;
	}

	public static Sarvashtakavarga SarvashtakavargaChart(Time birthTime)
	{
		Sarvashtakavarga result = new Sarvashtakavarga();
		Bhinnashtakavarga bhinnashtakavarga = Calculate.BhinnashtakavargaChart(birthTime);
		Dictionary<ZodiacName, int> first = ZodiacNameExtensions.AllZodiacSignsDictionary(0);
		foreach (KeyValuePair<PlanetName, Dictionary<ZodiacName, int>> item in bhinnashtakavarga.Dictionary)
		{
			Dictionary<ZodiacName, int> value = item.Value;
			first = (from kvp in first.Concat(value)
				group kvp by kvp.Key).ToDictionary((IGrouping<ZodiacName, KeyValuePair<ZodiacName, int>> group) => group.Key, (IGrouping<ZodiacName, KeyValuePair<ZodiacName, int>> group) => group.Sum((KeyValuePair<ZodiacName, int> kvp) => kvp.Value));
		}
		return result;
	}

	public static Sarvashtakavarga SarvashtakavargaChart2(Time birthTime)
	{
		Sarvashtakavarga sarvashtakavarga = new Sarvashtakavarga();
		foreach (KeyValuePair<string, int[]> item in ShortcutTable)
		{
			int num = (int)((item.Key == "Ascendant") ? Calculate.HouseSignName(HouseName.House1, birthTime) : Calculate.PlanetZodiacSign(PlanetName.Parse(item.Key), birthTime).GetSignName());
			int[] value = item.Value;
			int num2 = value.Length + 1;
			int[] value2 = value.Skip(num2 - num).Concat(value.Take(num2 - num)).ToArray();
			sarvashtakavarga[item.Key] = value2;
		}
		foreach (KeyValuePair<ZodiacName, int> item2 in ZodiacNameExtensions.AllZodiacSignsDictionary(0))
		{
			int key = (int)item2.Key;
			int num3 = 0;
			foreach (KeyValuePair<string, int[]> row in sarvashtakavarga.Rows)
			{
				num3 += row.Value[key - 1];
			}
			sarvashtakavarga.SarvashtakavargaRow[item2.Key] = num3;
		}
		return sarvashtakavarga;
	}

	public static Dictionary<ZodiacName, int> BhinnashtakavargaChartForPlanet(PlanetName mainPlanet, Time birthTime)
	{
		PlanetName.PlanetNameEnum name = mainPlanet.Name;
		if ((uint)(name - 8) <= 1u)
		{
			return new Dictionary<ZodiacName, int>();
		}
		List<string> list = PlanetName.All7Planets.Select((PlanetName e) => e.ToString()).ToList();
		list.Add("ascendant");
		Dictionary<string, int[]> dictionary = new Dictionary<string, int[]>();
		foreach (string item in list)
		{
			int[] value = PlanetBeneficAshtakaHouse(mainPlanet.ToString(), item);
			dictionary.Add(item, value);
		}
		Dictionary<ZodiacName, int> dictionary2 = ZodiacNameExtensions.AllZodiacSignsDictionary(0);
		foreach (string item2 in list)
		{
			ZodiacName inputSign = ((item2 == "ascendant") ? Calculate.HouseSignName(HouseName.House1, birthTime) : Calculate.PlanetZodiacSign(PlanetName.Parse(item2), birthTime).GetSignName());
			int[] array = dictionary[item2];
			foreach (int countToNextSign in array)
			{
				dictionary2[Calculate.SignCountedFromInputSign(inputSign, countToNextSign)]++;
			}
		}
		return dictionary2;
	}

	public static int[] PlanetBeneficAshtakaHouse(string mainPlanet, string minorPlanet)
	{
		Dictionary<(string, string), int[]> dictionary = new Dictionary<(string, string), int[]>();
		dictionary.Add(("sun", "sun"), new int[8] { 1, 2, 4, 7, 8, 9, 10, 11 });
		dictionary.Add(("sun", "mars"), new int[8] { 1, 2, 4, 7, 8, 9, 10, 11 });
		dictionary.Add(("sun", "saturn"), new int[8] { 1, 2, 4, 7, 8, 9, 10, 11 });
		dictionary.Add(("sun", "jupiter"), new int[4] { 5, 6, 9, 11 });
		dictionary.Add(("sun", "moon"), new int[4] { 3, 6, 10, 11 });
		dictionary.Add(("sun", "mercury"), new int[7] { 3, 5, 6, 9, 10, 11, 12 });
		dictionary.Add(("sun", "ascendant"), new int[6] { 3, 4, 6, 10, 11, 12 });
		dictionary.Add(("sun", "venus"), new int[3] { 6, 7, 12 });
		dictionary.Add(("moon", "ascendant"), new int[4] { 3, 6, 10, 11 });
		dictionary.Add(("moon", "mars"), new int[7] { 2, 3, 5, 6, 9, 10, 11 });
		dictionary.Add(("moon", "moon"), new int[6] { 1, 3, 6, 7, 10, 11 });
		dictionary.Add(("moon", "sun"), new int[6] { 3, 6, 7, 8, 10, 11 });
		dictionary.Add(("moon", "saturn"), new int[4] { 3, 5, 6, 11 });
		dictionary.Add(("moon", "mercury"), new int[8] { 1, 3, 4, 5, 7, 8, 10, 11 });
		dictionary.Add(("moon", "jupiter"), new int[7] { 1, 4, 7, 8, 10, 11, 12 });
		dictionary.Add(("moon", "venus"), new int[7] { 3, 4, 5, 7, 9, 10, 11 });
		dictionary.Add(("mars", "sun"), new int[5] { 3, 5, 6, 10, 11 });
		dictionary.Add(("mars", "ascendant"), new int[5] { 1, 3, 6, 10, 11 });
		dictionary.Add(("mars", "moon"), new int[3] { 3, 6, 11 });
		dictionary.Add(("mars", "mars"), new int[7] { 1, 2, 4, 7, 8, 10, 11 });
		dictionary.Add(("mars", "saturn"), new int[7] { 1, 4, 7, 8, 9, 10, 11 });
		dictionary.Add(("mars", "mercury"), new int[4] { 3, 5, 6, 11 });
		dictionary.Add(("mars", "venus"), new int[4] { 6, 8, 11, 12 });
		dictionary.Add(("mars", "jupiter"), new int[4] { 6, 10, 11, 12 });
		dictionary.Add(("mercury", "venus"), new int[8] { 1, 2, 3, 4, 5, 8, 9, 11 });
		dictionary.Add(("mercury", "mars"), new int[8] { 1, 2, 4, 7, 8, 9, 10, 11 });
		dictionary.Add(("mercury", "saturn"), new int[8] { 1, 2, 4, 7, 8, 9, 10, 11 });
		dictionary.Add(("mercury", "jupiter"), new int[4] { 6, 8, 11, 12 });
		dictionary.Add(("mercury", "sun"), new int[5] { 5, 6, 9, 11, 12 });
		dictionary.Add(("mercury", "mercury"), new int[8] { 1, 3, 5, 6, 9, 10, 11, 12 });
		dictionary.Add(("mercury", "moon"), new int[6] { 2, 4, 6, 8, 10, 11 });
		dictionary.Add(("mercury", "ascendant"), new int[7] { 1, 2, 4, 6, 8, 10, 11 });
		dictionary.Add(("jupiter", "mars"), new int[7] { 1, 2, 4, 7, 8, 10, 11 });
		dictionary.Add(("jupiter", "jupiter"), new int[8] { 1, 2, 3, 4, 7, 8, 10, 11 });
		dictionary.Add(("jupiter", "sun"), new int[9] { 1, 2, 3, 4, 7, 8, 9, 10, 11 });
		dictionary.Add(("jupiter", "venus"), new int[6] { 2, 5, 6, 9, 10, 11 });
		dictionary.Add(("jupiter", "moon"), new int[5] { 2, 5, 7, 9, 11 });
		dictionary.Add(("jupiter", "saturn"), new int[4] { 3, 5, 6, 12 });
		dictionary.Add(("jupiter", "mercury"), new int[8] { 1, 2, 4, 5, 6, 9, 10, 11 });
		dictionary.Add(("jupiter", "ascendant"), new int[9] { 1, 2, 4, 5, 6, 7, 9, 10, 11 });
		dictionary.Add(("venus", "ascendant"), new int[8] { 1, 2, 3, 4, 5, 8, 9, 11 });
		dictionary.Add(("venus", "moon"), new int[9] { 1, 2, 3, 4, 5, 8, 9, 11, 12 });
		dictionary.Add(("venus", "venus"), new int[9] { 1, 2, 3, 4, 5, 8, 9, 10, 11 });
		dictionary.Add(("venus", "saturn"), new int[7] { 3, 4, 5, 8, 9, 10, 11 });
		dictionary.Add(("venus", "sun"), new int[3] { 8, 11, 12 });
		dictionary.Add(("venus", "jupiter"), new int[5] { 5, 8, 9, 10, 11 });
		dictionary.Add(("venus", "mercury"), new int[5] { 3, 5, 6, 9, 11 });
		dictionary.Add(("venus", "mars"), new int[6] { 3, 5, 6, 9, 11, 12 });
		dictionary.Add(("saturn", "saturn"), new int[4] { 3, 5, 6, 11 });
		dictionary.Add(("saturn", "mars"), new int[6] { 3, 5, 6, 10, 11, 12 });
		dictionary.Add(("saturn", "sun"), new int[7] { 1, 2, 4, 7, 8, 10, 11 });
		dictionary.Add(("saturn", "ascendant"), new int[6] { 1, 3, 4, 6, 10, 11 });
		dictionary.Add(("saturn", "mercury"), new int[6] { 6, 8, 9, 10, 11, 12 });
		dictionary.Add(("saturn", "moon"), new int[3] { 3, 6, 11 });
		dictionary.Add(("saturn", "venus"), new int[3] { 6, 11, 12 });
		dictionary.Add(("saturn", "jupiter"), new int[4] { 5, 6, 11, 12 });
		mainPlanet = mainPlanet.ToLower();
		minorPlanet = minorPlanet.ToLower();
		return dictionary[(mainPlanet, minorPlanet)];
	}
}
