using System.Collections.Generic;
using System.Linq;

namespace VedAstro.Library;

public class CalculateHoroscope
{
	[HoroscopeCalculator(HoroscopeName.MoonAshtakavargaYoga1A)]
	public static CalculatorResult MoonAshtakavargaYoga1A(Time time)
	{
		var planet = PlanetName.Moon;
		var sign = Calculate.PlanetZodiacSign(planet, time).GetSignName();
		var points = Calculate.PlanetAshtakvargaBindu(planet, sign, time);
		return CalculatorResult.New(points is >= 1 and <= 3, new[] { planet }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonAshtakavargaYoga2B)]
	public static CalculatorResult MoonAshtakavargaYoga2B(Time time)
	{
		var planet = PlanetName.Moon;
		var sign = Calculate.PlanetZodiacSign(planet, time).GetSignName();
		var points = Calculate.PlanetAshtakvargaBindu(planet, sign, time);
		var house = Calculate.HousePlanetOccupies(planet, time);
		return CalculatorResult.New(points > 6 && house is HouseName.House6 or HouseName.House11, new[] { planet }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonAshtakavargaYoga4)]
	public static CalculatorResult MoonAshtakavargaYoga4(Time time)
	{
		var planet = PlanetName.Moon;
		var sign = Calculate.PlanetZodiacSign(planet, time).GetSignName();
		var points = Calculate.PlanetAshtakvargaBindu(planet, sign, time);
		return CalculatorResult.New(points is 7 or 8 && Calculate.IsPlanetInKendra(planet, time), new[] { planet }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga19)]
	public static CalculatorResult MarsAshtakavargaYoga19(Time time)
	{
		var planet = PlanetName.Mars;
		var sign = Calculate.PlanetZodiacSign(planet, time).GetSignName();
		var points = Calculate.PlanetAshtakvargaBindu(planet, sign, time);
		var house = Calculate.HousePlanetOccupies(planet, time);
		return CalculatorResult.New(points == 3 && house == HouseName.House3, new[] { planet }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga5)]
	public static CalculatorResult MarsAshtakavargaYoga5(Time time)
	{
		var planet = PlanetName.Mars;
		var sign = Calculate.PlanetZodiacSign(planet, time).GetSignName();
		var points = Calculate.PlanetAshtakvargaBindu(planet, sign, time);
		var house = Calculate.HousePlanetOccupies(planet, time);
		return CalculatorResult.New(points == 8 && house is HouseName.House1 or HouseName.House2 or HouseName.House10, new[] { planet }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga11)]
	public static CalculatorResult MarsAshtakavargaYoga11(Time time)
	{
		var planet = PlanetName.Mars;
		var sign = Calculate.PlanetZodiacSign(planet, time).GetSignName();
		var points = Calculate.PlanetAshtakvargaBindu(planet, sign, time);
		var house = Calculate.HousePlanetOccupies(planet, time);
		return CalculatorResult.New(points == 4 && (house == HouseName.House5 || Calculate.IsPlanetInKendra(planet, time)), new[] { planet }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunAshtakavargaYoga5)]
	public static CalculatorResult SunAshtakavargaYoga5(Time time)
	{
		var planet = PlanetName.Sun;
		var sign = Calculate.PlanetZodiacSign(planet, time).GetSignName();
		var points = Calculate.PlanetAshtakvargaBindu(planet, sign, time);
		return CalculatorResult.New(points > 5 && (Calculate.IsPlanetInKendra(planet, time) || Calculate.IsPlanetInTrikona(planet, time)), new[] { planet }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunAshtakavargaYoga11)]
	public static CalculatorResult SunAshtakavargaYoga11(Time time)
	{
		var planet = PlanetName.Sun;
		var sign = Calculate.PlanetZodiacSign(planet, time).GetSignName();
		var points = Calculate.PlanetAshtakvargaBindu(planet, sign, time);
		return CalculatorResult.New(points >= 5 && (Calculate.IsPlanetInKendra(planet, time) || Calculate.IsPlanetInTrikona(planet, time)), new[] { planet }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonAshtakavargaYoga)]
	public static CalculatorResult MoonAshtakavargaYoga(Time birthTime)
	{
		ZodiacSign zodiacSign = Calculate.PlanetZodiacSign(PlanetName.Moon, birthTime);
		int num = Calculate.PlanetAshtakvargaBindu(PlanetName.Moon, zodiacSign.GetSignName(), birthTime);
		return CalculatorResult.New(num == 1 || num == 2 || num == 3, new PlanetName[1] { PlanetName.Moon }, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.MoonAshtakavargaYoga2)]
	public static CalculatorResult MoonAshtakavargaYoga2(Time birthTime)
	{
		return CalculatorResult.NotOccuring();
	}

	[HoroscopeCalculator(HoroscopeName.MoonAshtakavargaYoga3)]
	public static CalculatorResult MoonAshtakavargaYoga3(Time birthTime)
	{
		HouseName houseName = Calculate.HousePlanetOccupies(PlanetName.Moon, birthTime);
		bool num = houseName == HouseName.House6 || houseName == HouseName.House11;
		ZodiacSign zodiacSign = Calculate.PlanetZodiacSign(PlanetName.Moon, birthTime);
		bool flag = Calculate.PlanetAshtakvargaBindu(PlanetName.Moon, zodiacSign.GetSignName(), birthTime) >= 6;
		return CalculatorResult.New(num & flag, new PlanetName[1] { PlanetName.Moon }, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.GajakesariYoga)]
	public static CalculatorResult GajakesariYoga(Time birthTime)
	{
		return CalculatorResult.New(Calculate.IsPlanetInKendraFromPlanet(PlanetName.Jupiter, PlanetName.Moon, birthTime), new PlanetName[2]
		{
			PlanetName.Jupiter,
			PlanetName.Moon
		}, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.SunaphaYoga)]
	public static CalculatorResult SunaphaYoga(Time birthTime)
	{
		bool num = Calculate.SignDistanceFromPlanetToPlanet(PlanetName.Moon, PlanetName.Sun, birthTime) != 2;
		List<PlanetName> source = Calculate.PlanetsInSign(Calculate.SignCountedFromPlanetSign(2, PlanetName.Moon, birthTime), birthTime);
		return CalculatorResult.New(num && source.Any(), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Moon }, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.AnaphaYoga)]
	public static CalculatorResult AnaphaYoga(Time birthTime)
	{
		List<PlanetName> list = Calculate.PlanetsInSign(Calculate.SignCountedFromPlanetSign(12, PlanetName.Moon, birthTime), birthTime);
		list.RemoveAll((PlanetName x) => x.Name == PlanetName.PlanetNameEnum.Sun);
		return CalculatorResult.New(list.Any(), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Moon }, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.DhurdhuraYoga)]
	public static CalculatorResult DhurdhuraYoga(Time birthTime)
	{
		bool flag = Calculate.PlanetsInSign(Calculate.SignCountedFromPlanetSign(2, PlanetName.Moon, birthTime), birthTime).Any();
		return CalculatorResult.New(Calculate.PlanetsInSign(Calculate.SignCountedFromPlanetSign(12, PlanetName.Moon, birthTime), birthTime).Any() | flag, new PlanetName[1] { PlanetName.Moon }, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.KemadrumaYoga)]
	public static CalculatorResult KemadrumaYoga(Time birthTime)
	{
		bool flag = !Calculate.PlanetsInSign(Calculate.SignCountedFromPlanetSign(2, PlanetName.Moon, birthTime), birthTime).Any();
		return CalculatorResult.New(!Calculate.PlanetsInSign(Calculate.SignCountedFromPlanetSign(12, PlanetName.Moon, birthTime), birthTime).Any() & flag, new PlanetName[1] { PlanetName.Moon }, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.ChandraMangalaYoga)]
	public static CalculatorResult ChandraMangalaYoga(Time birthTime)
	{
		return CalculatorResult.New(Calculate.IsPlanetConjunctWithPlanet(PlanetName.Mars, PlanetName.Moon, birthTime), new PlanetName[2]
		{
			PlanetName.Moon,
			PlanetName.Mars
		}, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.AdhiYoga)]
	public static CalculatorResult AdhiYoga(Time birthTime)
	{
		int[] signsFromList = new int[3] { 6, 7, 8 };
		PlanetName[] planetList = new PlanetName[3]
		{
			PlanetName.Mercury,
			PlanetName.Jupiter,
			PlanetName.Venus
		};
		return CalculatorResult.New(Calculate.IsPlanetsInSignsFromPlanet(signsFromList, planetList, PlanetName.Moon, birthTime), new PlanetName[1] { PlanetName.Moon }, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.ChatussagaraYoga)]
	public static CalculatorResult ChatussagaraYoga(Time birthTime)
	{
		bool occuring = true;
		HouseName[] array = new HouseName[4]
		{
			HouseName.House1,
			HouseName.House4,
			HouseName.House7,
			HouseName.House10
		};
		HouseName[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			if (!Calculate.PlanetsInHouse(array2[i], birthTime).Any())
			{
				occuring = false;
				break;
			}
		}
		return CalculatorResult.New(occuring, array, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.VasumathiYoga)]
	public static CalculatorResult VasumathiYoga(Time birthTime)
	{
		int[] signsFromList = new int[4] { 3, 6, 10, 11 };
		bool flag = Calculate.IsBeneficsInSignsFromLagna(signsFromList, birthTime);
		bool flag2 = Calculate.IsBeneficsInSignsFromPlanet(signsFromList, PlanetName.Moon, birthTime);
		return CalculatorResult.New(flag | flag2);
	}

	[HoroscopeCalculator(HoroscopeName.RajalakshanaYoga)]
	public static CalculatorResult RajalakshanaYoga(Time birthTime)
	{
		PlanetName[] obj = new PlanetName[4]
		{
			PlanetName.Jupiter,
			PlanetName.Venus,
			PlanetName.Mercury,
			PlanetName.Moon
		};
		bool flag = Calculate.IsPlanetInKendra(obj, birthTime);
		bool flag2 = Calculate.IsAnyPlanetInHouse(obj.ToList(), HouseName.House1, birthTime);
		return CalculatorResult.New(flag | flag2);
	}

	[HoroscopeCalculator(HoroscopeName.VanchanaChoraBheethiYoga)]
	public static CalculatorResult VanchanaChoraBheethiYoga(Time birthTime)
	{
		return CalculatorResult.NotOccuring();
	}

	[HoroscopeCalculator(HoroscopeName.SakataYoga)]
	public static CalculatorResult SakataYoga(Time birthTime)
	{
		int[] signsFromList = new int[3] { 6, 8, 12 };
		PlanetName[] planetList = new PlanetName[1] { PlanetName.Moon };
		return CalculatorResult.New(Calculate.IsPlanetsInSignsFromPlanet(signsFromList, planetList, PlanetName.Jupiter, birthTime), new PlanetName[2]
		{
			PlanetName.Moon,
			PlanetName.Jupiter
		}, birthTime);
	}

	[HoroscopeCalculator(HoroscopeName.AmalaYoga)]
	public static CalculatorResult AmalaYoga(Time birthTime)
	{
		int[] signsFromList = new int[1] { 10 };
		bool flag = Calculate.IsBeneficsInSignsFromPlanet(signsFromList, PlanetName.Moon, birthTime);
		bool flag2 = Calculate.IsBeneficsInSignsFromLagna(signsFromList, birthTime);
		return CalculatorResult.New(flag | flag2);
	}

	[HoroscopeCalculator(HoroscopeName.ParvataYoga)]
	public static CalculatorResult ParvataYoga(Time birthTime)
	{
		bool num = Calculate.IsBeneficsInKendra(birthTime);
		bool num2 = Calculate.PlanetsInHouse(HouseName.House6, birthTime).Count == 0;
		bool flag = Calculate.PlanetsInHouse(HouseName.House8, birthTime).Count == 0;
		bool flag2 = num2 & flag;
		bool num3 = Calculate.IsBeneficPlanetInHouse(HouseName.House6, birthTime);
		bool flag3 = Calculate.IsBeneficPlanetInHouse(HouseName.House8, birthTime);
		bool flag4 = num3 & flag3;
		return CalculatorResult.New(num && (flag2 | flag4));
	}

	[HoroscopeCalculator(HoroscopeName.KahalaYoga)]
	public static CalculatorResult KahalaYoga(Time birthTime)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House4, birthTime);
		PlanetName planetName2 = Calculate.LordOfHouse(HouseName.House9, birthTime);
		bool num = Calculate.IsPlanetInKendraFromPlanet(planetName2, planetName, birthTime);
		bool flag = Calculate.IsPlanetInKendraFromPlanet(planetName, planetName2, birthTime);
		bool num2 = num | flag;
		bool flag2 = Calculate.IsPlanetStrongInShadbala(Calculate.LordOfHouse(HouseName.House1, birthTime), birthTime);
		return CalculatorResult.New(num2 & flag2);
	}

	[HoroscopeCalculator(HoroscopeName.VesiYoga)]
	public static CalculatorResult VesiYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.VasiYoga)]
	public static CalculatorResult VasiYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.ObhayachariYoga)]
	public static CalculatorResult ObhayachariYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.HamsaYoga)]
	public static CalculatorResult HamsaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.MalavyaYoga)]
	public static CalculatorResult MalavyaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.SasaYoga)]
	public static CalculatorResult SasaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.RuchakaYoga)]
	public static CalculatorResult RuchakaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.BhadraYoga)]
	public static CalculatorResult BhadraYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.BudhaAdityaYoga)]
	public static CalculatorResult BudhaAdityaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.MahabhagyaYogaMale)]
	public static CalculatorResult MahabhagyaYogaMale(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.MahabhagyaYogaFemale)]
	public static CalculatorResult MahabhagyaYogaFemale(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.PushkalaYoga)]
	public static CalculatorResult PushkalaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.LakshmiYoga)]
	public static CalculatorResult LakshmiYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.GauriYoga)]
	public static CalculatorResult GauriYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.BharathiYoga)]
	public static CalculatorResult BharathiYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.ChapaYoga)]
	public static CalculatorResult ChapaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.SreenathaYoga)]
	public static CalculatorResult SreenathaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.LagnaMalikaYoga)]
	public static CalculatorResult LagnaMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.DhanaMalikaYoga)]
	public static CalculatorResult DhanaMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.VikramaMalikaYoga)]
	public static CalculatorResult VikramaMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.SukhaMalikaYoga)]
	public static CalculatorResult SukhaMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.PutraMalikaYoga)]
	public static CalculatorResult PutraMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.SatruMalikaYoga)]
	public static CalculatorResult SatruMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.KalatraMalikaYoga)]
	public static CalculatorResult KalatraMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.RandhraMalikaYoga)]
	public static CalculatorResult RandhraMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.BhagyaMalikaYoga)]
	public static CalculatorResult BhagyaMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.KarmaMalikaYoga)]
	public static CalculatorResult KarmaMalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.MalikaYoga)]
	public static CalculatorResult MalikaYoga(Time birthTime)
	{
		return CalculatorResult.New(occuring: false);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse1)]
	public static CalculatorResult SunInHouse1(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House1, time), new HouseName[1] { HouseName.House1 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse1)]
	public static CalculatorResult MoonInHouse1(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House1, time), new HouseName[1] { HouseName.House1 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse1)]
	public static CalculatorResult MarsInHouse1(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House1, time), new HouseName[1] { HouseName.House1 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse1)]
	public static CalculatorResult MercuryInHouse1(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House1, time), new HouseName[1] { HouseName.House1 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse1)]
	public static CalculatorResult JupiterInHouse1(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House1, time), new HouseName[1] { HouseName.House1 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse1)]
	public static CalculatorResult VenusInHouse1(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House1, time), new HouseName[1] { HouseName.House1 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse1)]
	public static CalculatorResult SaturnInHouse1(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House1, time), new HouseName[1] { HouseName.House1 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse1)]
	public static CalculatorResult RahuInHouse1(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House1, time), new HouseName[1] { HouseName.House1 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse1)]
	public static CalculatorResult KetuInHouse1(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House1, time), new HouseName[1] { HouseName.House1 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse2)]
	public static CalculatorResult SunInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House2, time), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse2)]
	public static CalculatorResult MoonInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House2, time), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse2)]
	public static CalculatorResult MarsInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House2, time), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse2)]
	public static CalculatorResult MercuryInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House2, time), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse2)]
	public static CalculatorResult JupiterInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House2, time), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse2)]
	public static CalculatorResult VenusInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House2, time), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse2)]
	public static CalculatorResult SaturnInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House2, time), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse2)]
	public static CalculatorResult RahuInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House2, time), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse2)]
	public static CalculatorResult KetuInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House2, time), new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse3)]
	public static CalculatorResult SunInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House3, time), new HouseName[1] { HouseName.House3 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse3)]
	public static CalculatorResult MoonInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House3, time), new HouseName[1] { HouseName.House3 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse3)]
	public static CalculatorResult MarsInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House3, time), new HouseName[1] { HouseName.House3 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse3)]
	public static CalculatorResult MercuryInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House3, time), new HouseName[1] { HouseName.House3 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse3)]
	public static CalculatorResult JupiterInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House3, time), new HouseName[1] { HouseName.House3 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse3)]
	public static CalculatorResult VenusInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House3, time), new HouseName[1] { HouseName.House3 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse3)]
	public static CalculatorResult SaturnInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House3, time), new HouseName[1] { HouseName.House3 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse3)]
	public static CalculatorResult RahuInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House3, time), new HouseName[1] { HouseName.House3 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse3)]
	public static CalculatorResult KetuInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House3, time), new HouseName[1] { HouseName.House3 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse4)]
	public static CalculatorResult SunInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House4, time), new HouseName[1] { HouseName.House4 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse4)]
	public static CalculatorResult MoonInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House4, time), new HouseName[1] { HouseName.House4 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse4)]
	public static CalculatorResult MarsInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House4, time), new HouseName[1] { HouseName.House4 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse4)]
	public static CalculatorResult MercuryInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House4, time), new HouseName[1] { HouseName.House4 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse4)]
	public static CalculatorResult JupiterInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House4, time), new HouseName[1] { HouseName.House4 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse4)]
	public static CalculatorResult VenusInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House4, time), new HouseName[1] { HouseName.House4 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse4)]
	public static CalculatorResult SaturnInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House4, time), new HouseName[1] { HouseName.House4 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse4)]
	public static CalculatorResult RahuInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House4, time), new HouseName[1] { HouseName.House4 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse4)]
	public static CalculatorResult KetuInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House4, time), new HouseName[1] { HouseName.House4 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse5)]
	public static CalculatorResult SunInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House5, time), new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse5)]
	public static CalculatorResult MoonInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House5, time), new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse5)]
	public static CalculatorResult MarsInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House5, time), new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse5)]
	public static CalculatorResult MercuryInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House5, time), new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse5)]
	public static CalculatorResult JupiterInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House5, time), new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse5)]
	public static CalculatorResult VenusInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House5, time), new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse5)]
	public static CalculatorResult SaturnInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House5, time), new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse5)]
	public static CalculatorResult RahuInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House5, time), new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse5)]
	public static CalculatorResult KetuInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House5, time), new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse6)]
	public static CalculatorResult SunInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House6, time), new HouseName[1] { HouseName.House6 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse6)]
	public static CalculatorResult MoonInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House6, time), new HouseName[1] { HouseName.House6 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse6)]
	public static CalculatorResult MarsInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House6, time), new HouseName[1] { HouseName.House6 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse6)]
	public static CalculatorResult MercuryInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House6, time), new HouseName[1] { HouseName.House6 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse6)]
	public static CalculatorResult JupiterInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House6, time), new HouseName[1] { HouseName.House6 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse6)]
	public static CalculatorResult VenusInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House6, time), new HouseName[1] { HouseName.House6 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse6)]
	public static CalculatorResult SaturnInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House6, time), new HouseName[1] { HouseName.House6 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse6)]
	public static CalculatorResult RahuInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House6, time), new HouseName[1] { HouseName.House6 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse6)]
	public static CalculatorResult KetuInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House6, time), new HouseName[1] { HouseName.House6 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse7)]
	public static CalculatorResult SunInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House7, time), new HouseName[1] { HouseName.House7 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse7)]
	public static CalculatorResult MoonInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House7, time), new HouseName[1] { HouseName.House7 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse7)]
	public static CalculatorResult MarsInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House7, time), new HouseName[1] { HouseName.House7 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse7)]
	public static CalculatorResult MercuryInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House7, time), new HouseName[1] { HouseName.House7 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse7)]
	public static CalculatorResult JupiterInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House7, time), new HouseName[1] { HouseName.House7 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse7)]
	public static CalculatorResult VenusInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House7, time), new HouseName[1] { HouseName.House7 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse7)]
	public static CalculatorResult SaturnInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House7, time), new HouseName[1] { HouseName.House7 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse7)]
	public static CalculatorResult RahuInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House7, time), new HouseName[1] { HouseName.House7 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse7)]
	public static CalculatorResult KetuInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House7, time), new HouseName[1] { HouseName.House7 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse8)]
	public static CalculatorResult SunInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House8, time), new HouseName[1] { HouseName.House8 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse8)]
	public static CalculatorResult MoonInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House8, time), new HouseName[1] { HouseName.House8 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse8)]
	public static CalculatorResult MarsInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House8, time), new HouseName[1] { HouseName.House8 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse8)]
	public static CalculatorResult MercuryInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House8, time), new HouseName[1] { HouseName.House8 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse8)]
	public static CalculatorResult JupiterInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House8, time), new HouseName[1] { HouseName.House8 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse8)]
	public static CalculatorResult VenusInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House8, time), new HouseName[1] { HouseName.House8 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse8)]
	public static CalculatorResult SaturnInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House8, time), new HouseName[1] { HouseName.House8 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse8)]
	public static CalculatorResult RahuInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House8, time), new HouseName[1] { HouseName.House8 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse8)]
	public static CalculatorResult KetuInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House8, time), new HouseName[1] { HouseName.House8 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse9)]
	public static CalculatorResult SunInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House9, time), new HouseName[1] { HouseName.House9 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse9)]
	public static CalculatorResult MoonInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House9, time), new HouseName[1] { HouseName.House9 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse9)]
	public static CalculatorResult MarsInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House9, time), new HouseName[1] { HouseName.House9 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse9)]
	public static CalculatorResult MercuryInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House9, time), new HouseName[1] { HouseName.House9 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse9)]
	public static CalculatorResult JupiterInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House9, time), new HouseName[1] { HouseName.House9 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse9)]
	public static CalculatorResult VenusInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House9, time), new HouseName[1] { HouseName.House9 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse9)]
	public static CalculatorResult SaturnInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House9, time), new HouseName[1] { HouseName.House9 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse9)]
	public static CalculatorResult RahuInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House9, time), new HouseName[1] { HouseName.House9 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse9)]
	public static CalculatorResult KetuInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House9, time), new HouseName[1] { HouseName.House9 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse10)]
	public static CalculatorResult SunInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House10, time), new HouseName[1] { HouseName.House10 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse10)]
	public static CalculatorResult MoonInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House10, time), new HouseName[1] { HouseName.House10 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse10)]
	public static CalculatorResult MarsInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House10, time), new HouseName[1] { HouseName.House10 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse10)]
	public static CalculatorResult MercuryInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House10, time), new HouseName[1] { HouseName.House10 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse10)]
	public static CalculatorResult JupiterInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House10, time), new HouseName[1] { HouseName.House10 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse10)]
	public static CalculatorResult VenusInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House10, time), new HouseName[1] { HouseName.House10 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse10)]
	public static CalculatorResult SaturnInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House10, time), new HouseName[1] { HouseName.House10 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse10)]
	public static CalculatorResult RahuInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House10, time), new HouseName[1] { HouseName.House10 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse10)]
	public static CalculatorResult KetuInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House10, time), new HouseName[1] { HouseName.House10 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse11)]
	public static CalculatorResult SunInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House11, time), new HouseName[1] { HouseName.House11 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse11)]
	public static CalculatorResult MoonInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House11, time), new HouseName[1] { HouseName.House11 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse11)]
	public static CalculatorResult MarsInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House11, time), new HouseName[1] { HouseName.House11 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse11)]
	public static CalculatorResult MercuryInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House11, time), new HouseName[1] { HouseName.House11 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse11)]
	public static CalculatorResult JupiterInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House11, time), new HouseName[1] { HouseName.House11 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse11)]
	public static CalculatorResult VenusInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House11, time), new HouseName[1] { HouseName.House11 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse11)]
	public static CalculatorResult SaturnInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House11, time), new HouseName[1] { HouseName.House11 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse11)]
	public static CalculatorResult RahuInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House11, time), new HouseName[1] { HouseName.House11 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse11)]
	public static CalculatorResult KetuInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House11, time), new HouseName[1] { HouseName.House11 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInHouse12)]
	public static CalculatorResult SunInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House12, time), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInHouse12)]
	public static CalculatorResult MoonInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House12, time), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Moon }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInHouse12)]
	public static CalculatorResult MarsInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House12, time), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Mars }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInHouse12)]
	public static CalculatorResult MercuryInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House12, time), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Mercury }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInHouse12)]
	public static CalculatorResult JupiterInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House12, time), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Jupiter }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInHouse12)]
	public static CalculatorResult VenusInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House12, time), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Venus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInHouse12)]
	public static CalculatorResult SaturnInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House12, time), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Saturn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.RahuInHouse12)]
	public static CalculatorResult RahuInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Rahu, HouseName.House12, time), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Rahu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.KetuInHouse12)]
	public static CalculatorResult KetuInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInHouse(PlanetName.Ketu, HouseName.House12, time), new HouseName[1] { HouseName.House12 }, new PlanetName[1] { PlanetName.Ketu }, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse1Fortified)]
	public static CalculatorResult House1LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse2)]
	public static CalculatorResult House1LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse3)]
	public static CalculatorResult House1LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse4)]
	public static CalculatorResult House1LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse5)]
	public static CalculatorResult House1LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse6)]
	public static CalculatorResult House1LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse7)]
	public static CalculatorResult House1LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse8)]
	public static CalculatorResult House1LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse9)]
	public static CalculatorResult House1LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse10)]
	public static CalculatorResult House1LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse11)]
	public static CalculatorResult House1LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House1LordInHouse12)]
	public static CalculatorResult House1LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House1,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse1)]
	public static CalculatorResult House2LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse1With9thOrSun)]
	public static CalculatorResult House2LordInHouse1With9thOrSun(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse2)]
	public static CalculatorResult House2LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse3)]
	public static CalculatorResult House2LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse4)]
	public static CalculatorResult House2LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse4Afflicted)]
	public static CalculatorResult House2LordInHouse4Afflicted(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse4Fortified)]
	public static CalculatorResult House2LordInHouse4Fortified(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse5)]
	public static CalculatorResult House2LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse6Fortified)]
	public static CalculatorResult House2LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse6Afflicted)]
	public static CalculatorResult House2LordInHouse6Afflicted(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse7)]
	public static CalculatorResult House2LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse8)]
	public static CalculatorResult House2LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse9)]
	public static CalculatorResult House2LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse10)]
	public static CalculatorResult House2LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse11)]
	public static CalculatorResult House2LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse12)]
	public static CalculatorResult House2LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House2LordInHouse12Afflicted)]
	public static CalculatorResult House2LordInHouse12Afflicted(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House2, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House2,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse1)]
	public static CalculatorResult House3LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse2)]
	public static CalculatorResult House3LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse3)]
	public static CalculatorResult House3LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse4)]
	public static CalculatorResult House3LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse4Fortified)]
	public static CalculatorResult House3LordInHouse4Fortified(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse4WeakMars)]
	public static CalculatorResult House3LordInHouse4WeakMars(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse4Strong9th)]
	public static CalculatorResult House3LordInHouse4Strong9th(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse5)]
	public static CalculatorResult House3LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse6)]
	public static CalculatorResult House3LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse6Lord3rd)]
	public static CalculatorResult House3LordInHouse6Lord3rd(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse6Lord3rdAfflicted)]
	public static CalculatorResult House3LordInHouse6Lord3rdAfflicted(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse7)]
	public static CalculatorResult House3LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse8)]
	public static CalculatorResult House3LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse9)]
	public static CalculatorResult House3LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse10)]
	public static CalculatorResult House3LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse11)]
	public static CalculatorResult House3LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House3LordInHouse12)]
	public static CalculatorResult House3LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House3, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House3,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse1)]
	public static CalculatorResult House4LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse2)]
	public static CalculatorResult House4LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse3)]
	public static CalculatorResult House4LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse4)]
	public static CalculatorResult House4LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse5)]
	public static CalculatorResult House4LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse6)]
	public static CalculatorResult House4LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse7)]
	public static CalculatorResult House4LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse8)]
	public static CalculatorResult House4LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse9)]
	public static CalculatorResult House4LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse10)]
	public static CalculatorResult House4LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse10Afflicted)]
	public static CalculatorResult House4LordInHouse10Afflicted(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse11)]
	public static CalculatorResult House4LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House4LordInHouse12)]
	public static CalculatorResult House4LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House4, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House4,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse1Fortified)]
	public static CalculatorResult House5LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse1Afflicted)]
	public static CalculatorResult House5LordInHouse1Afflicted(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse1AfflictedModerate)]
	public static CalculatorResult House5LordInHouse1AfflictedModerate(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse2)]
	public static CalculatorResult House5LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse3Fortified)]
	public static CalculatorResult House5LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse3Afflicted)]
	public static CalculatorResult House5LordInHouse3Afflicted(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse4)]
	public static CalculatorResult House5LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse5)]
	public static CalculatorResult House5LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse6)]
	public static CalculatorResult House5LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse7)]
	public static CalculatorResult House5LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse8)]
	public static CalculatorResult House5LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse9)]
	public static CalculatorResult House5LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse9Afflicted)]
	public static CalculatorResult House5LordInHouse9Afflicted(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse10)]
	public static CalculatorResult House5LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse11)]
	public static CalculatorResult House5LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House5LordInHouse12)]
	public static CalculatorResult House5LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House5, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House5,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse1Fortified)]
	public static CalculatorResult House6LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse1Afflicted)]
	public static CalculatorResult House6LordInHouse1Afflicted(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse2)]
	public static CalculatorResult House6LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse3)]
	public static CalculatorResult House6LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse4)]
	public static CalculatorResult House6LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse5)]
	public static CalculatorResult House6LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse6)]
	public static CalculatorResult House6LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse7)]
	public static CalculatorResult House6LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse8)]
	public static CalculatorResult House6LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse9)]
	public static CalculatorResult House6LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse10)]
	public static CalculatorResult House6LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse11)]
	public static CalculatorResult House6LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House6LordInHouse12)]
	public static CalculatorResult House6LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House6, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House6,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse1)]
	public static CalculatorResult House7LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse2)]
	public static CalculatorResult House7LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse3)]
	public static CalculatorResult House7LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse4)]
	public static CalculatorResult House7LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse5)]
	public static CalculatorResult House7LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse6)]
	public static CalculatorResult House7LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse7)]
	public static CalculatorResult House7LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse8)]
	public static CalculatorResult House7LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse9)]
	public static CalculatorResult House7LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse10)]
	public static CalculatorResult House7LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse11)]
	public static CalculatorResult House7LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House7LordInHouse12)]
	public static CalculatorResult House7LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House7,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse1)]
	public static CalculatorResult House8LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse2)]
	public static CalculatorResult House8LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse3)]
	public static CalculatorResult House8LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse4)]
	public static CalculatorResult House8LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse5)]
	public static CalculatorResult House8LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse6)]
	public static CalculatorResult House8LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse7)]
	public static CalculatorResult House8LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse8)]
	public static CalculatorResult House8LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse9)]
	public static CalculatorResult House8LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse10)]
	public static CalculatorResult House8LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse11)]
	public static CalculatorResult House8LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House8LordInHouse12)]
	public static CalculatorResult House8LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House8, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House8,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse1)]
	public static CalculatorResult House9LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse2)]
	public static CalculatorResult House9LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse3)]
	public static CalculatorResult House9LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse4)]
	public static CalculatorResult House9LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse5)]
	public static CalculatorResult House9LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse6)]
	public static CalculatorResult House9LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse7)]
	public static CalculatorResult House9LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse8)]
	public static CalculatorResult House9LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse9)]
	public static CalculatorResult House9LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse10)]
	public static CalculatorResult House9LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse11)]
	public static CalculatorResult House9LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House9LordInHouse12)]
	public static CalculatorResult House9LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House9, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House9,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse1)]
	public static CalculatorResult House10LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse2)]
	public static CalculatorResult House10LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse3)]
	public static CalculatorResult House10LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse4)]
	public static CalculatorResult House10LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse5)]
	public static CalculatorResult House10LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse6)]
	public static CalculatorResult House10LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse7)]
	public static CalculatorResult House10LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse8)]
	public static CalculatorResult House10LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse9)]
	public static CalculatorResult House10LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse10)]
	public static CalculatorResult House10LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse11)]
	public static CalculatorResult House10LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House10LordInHouse12)]
	public static CalculatorResult House10LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House10, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House10,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse1)]
	public static CalculatorResult House11LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse2)]
	public static CalculatorResult House11LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse3)]
	public static CalculatorResult House11LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse4)]
	public static CalculatorResult House11LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse5)]
	public static CalculatorResult House11LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse6)]
	public static CalculatorResult House11LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse7)]
	public static CalculatorResult House11LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse8)]
	public static CalculatorResult House11LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse9)]
	public static CalculatorResult House11LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse10)]
	public static CalculatorResult House11LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse11)]
	public static CalculatorResult House11LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House11LordInHouse12)]
	public static CalculatorResult House11LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House11, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House11,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse1)]
	public static CalculatorResult House12LordInHouse1Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House1, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House1
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse2)]
	public static CalculatorResult House12LordInHouse2Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House2, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House2
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse3)]
	public static CalculatorResult House12LordInHouse3Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House3, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House3
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse4)]
	public static CalculatorResult House12LordInHouse4Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House4, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House4
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse5)]
	public static CalculatorResult House12LordInHouse5Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House5, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House5
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse6)]
	public static CalculatorResult House12LordInHouse6Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House6, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House6
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse7)]
	public static CalculatorResult House12LordInHouse7Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House7, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House7
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse8)]
	public static CalculatorResult House12LordInHouse8Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House8, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House8
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse9)]
	public static CalculatorResult House12LordInHouse9Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House9, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House9
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse10)]
	public static CalculatorResult House12LordInHouse10Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House10, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House10
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse11)]
	public static CalculatorResult House12LordInHouse11Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House11, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House11
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.House12LordInHouse12)]
	public static CalculatorResult House12LordInHouse12Occuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseLordInHouse(HouseName.House12, HouseName.House12, time), new HouseName[2]
		{
			HouseName.House12,
			HouseName.House12
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.AriesRising)]
	public static CalculatorResult AriesRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Aries, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Aries }, time);
	}

	[HoroscopeCalculator(HoroscopeName.TaurusRising)]
	public static CalculatorResult TaurusRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Taurus, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Taurus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.GeminiRising)]
	public static CalculatorResult GeminiRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Gemini, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Gemini }, time);
	}

	[HoroscopeCalculator(HoroscopeName.CancerRising)]
	public static CalculatorResult CancerRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Cancer, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Cancer }, time);
	}

	[HoroscopeCalculator(HoroscopeName.LeoRising)]
	public static CalculatorResult LeoRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Leo, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Leo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VirgoRising)]
	public static CalculatorResult VirgoRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Virgo, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Virgo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.LibraRising)]
	public static CalculatorResult LibraRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Libra, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Libra }, time);
	}

	[HoroscopeCalculator(HoroscopeName.ScorpioRising)]
	public static CalculatorResult ScorpioRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Scorpio, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Scorpio }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SagittariusRising)]
	public static CalculatorResult SagittariusRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Sagittarius, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Sagittarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.CapricornRising)]
	public static CalculatorResult CapricornRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Capricorn, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Capricorn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.AquariusRising)]
	public static CalculatorResult AquariusRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Aquarius, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Aquarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.PiscesRising)]
	public static CalculatorResult PiscesRisingOccuring(Time time)
	{
		return CalculatorResult.New(Calculate.IsHouseSignName(HouseName.House1, ZodiacName.Pisces, time), new HouseName[1] { HouseName.House1 }, new ZodiacName[1] { ZodiacName.Pisces }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2WithEvilInHouse)]
	public static CalculatorResult Lord2WithEvilInHouse(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		if (Calculate.HousePlanetOccupies(planetName, time) != HouseName.House2)
		{
			return CalculatorResult.NotOccuring();
		}
		bool num = Calculate.IsMaleficPlanetInHouse(HouseName.House2, time);
		bool flag = Calculate.IsPlanetAspectedByMaleficPlanets(planetName, time);
		return CalculatorResult.New(num | flag, planetName);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnIn2WithVenus)]
	public static CalculatorResult SaturnIn2WithVenus(Time time)
	{
		if (Calculate.HousePlanetOccupies(PlanetName.Saturn, time) != HouseName.House2)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.New(Calculate.IsPlanetAspectedByPlanet(PlanetName.Saturn, PlanetName.Venus, time), new HouseName[1] { HouseName.House2 }, new PlanetName[2]
		{
			PlanetName.Saturn,
			PlanetName.Venus
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonMarsIn2WithSaturnAspect)]
	public static CalculatorResult MoonMarsIn2WithSaturnAspect(Time time)
	{
		bool num = Calculate.HousePlanetOccupies(PlanetName.Moon, time) == HouseName.House2;
		bool flag = Calculate.HousePlanetOccupies(PlanetName.Mars, time) == HouseName.House2;
		bool flag2 = Calculate.IsHouseAspectedByPlanet(HouseName.House2, PlanetName.Saturn, time);
		return CalculatorResult.New(num & flag & flag2, new HouseName[1] { HouseName.House2 }, new PlanetName[3]
		{
			PlanetName.Moon,
			PlanetName.Mars,
			PlanetName.Saturn
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryAndEvilIn2WithMoonAspect)]
	public static CalculatorResult MercuryAndEvilIn2WithMoonAspect(Time time)
	{
		bool num = Calculate.HousePlanetOccupies(PlanetName.Mercury, time) == HouseName.House2;
		bool flag = Calculate.IsMaleficPlanetInHouse(HouseName.House2, time);
		bool flag2 = Calculate.IsHouseAspectedByPlanet(HouseName.House2, PlanetName.Moon, time);
		return CalculatorResult.New(num & flag & flag2, new HouseName[1] { HouseName.House2 }, new PlanetName[2]
		{
			PlanetName.Moon,
			PlanetName.Mercury
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunIn2WithNoSaturnAspect)]
	public static CalculatorResult SunIn2WithNoSaturnAspect(Time time)
	{
		bool num = Calculate.HousePlanetOccupies(PlanetName.Sun, time) == HouseName.House2;
		bool flag = !Calculate.IsHouseAspectedByPlanet(HouseName.House2, PlanetName.Saturn, time);
		return CalculatorResult.New(num & flag, new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonIn2WithMercuryAspect)]
	public static CalculatorResult MoonIn2WithMercuryAspect(Time time)
	{
		bool num = Calculate.HousePlanetOccupies(PlanetName.Moon, time) == HouseName.House2;
		bool flag = Calculate.IsHouseAspectedByPlanet(HouseName.House2, PlanetName.Mercury, time);
		return CalculatorResult.New(num & flag, new HouseName[1] { HouseName.House2 }, new PlanetName[2]
		{
			PlanetName.Moon,
			PlanetName.Mercury
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2And3In6WithEvilPlanet)]
	public static CalculatorResult Lord2And3In6WithEvilPlanet(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		bool num = Calculate.HousePlanetOccupies(planetName, time) == HouseName.House6;
		PlanetName planetName2 = Calculate.LordOfHouse(HouseName.House3, time);
		bool flag = Calculate.HousePlanetOccupies(planetName2, time) == HouseName.House6;
		bool num2 = Calculate.IsMaleficPlanetInHouse(HouseName.House6, time);
		bool flag2 = Calculate.IsMaleficPlanetAspectHouse(HouseName.House6, time);
		bool flag3 = num2 | flag2;
		return CalculatorResult.New(num & flag & flag3, new HouseName[3]
		{
			HouseName.House2,
			HouseName.House3,
			HouseName.House6
		}, new PlanetName[2] { planetName, planetName2 }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse1)]
	public static CalculatorResult Lord2InHouse1(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New(Calculate.HousePlanetOccupies(planetName, time) == HouseName.House1, new HouseName[1] { HouseName.House1 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse1AndLord1InHouse2)]
	public static CalculatorResult Lord2InHouse1AndLord1InHouse2(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House1, time);
		bool flag = Calculate.HousePlanetOccupies(planetName, time) == HouseName.House2;
		PlanetName planetName2 = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New((Calculate.HousePlanetOccupies(planetName2, time) == HouseName.House1) & flag, new HouseName[2]
		{
			HouseName.House1,
			HouseName.House2
		}, new PlanetName[2] { planetName, planetName2 }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse3)]
	public static CalculatorResult Lord2InHouse3(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New(Calculate.HousePlanetOccupies(planetName, time) == HouseName.House3, new HouseName[1] { HouseName.House3 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse4)]
	public static CalculatorResult Lord2InHouse4(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New(Calculate.HousePlanetOccupies(planetName, time) == HouseName.House4, new HouseName[1] { HouseName.House4 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse5)]
	public static CalculatorResult Lord2InHouse5(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New(Calculate.HousePlanetOccupies(planetName, time) == HouseName.House5, new HouseName[1] { HouseName.House5 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse6)]
	public static CalculatorResult Lord2InHouse6(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New(Calculate.HousePlanetOccupies(planetName, time) == HouseName.House6, new HouseName[1] { HouseName.House6 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse7)]
	public static CalculatorResult Lord2InHouse7(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New(Calculate.HousePlanetOccupies(planetName, time) == HouseName.House7, new HouseName[1] { HouseName.House7 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse8)]
	public static CalculatorResult Lord2InHouse8(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New(Calculate.HousePlanetOccupies(planetName, time) == HouseName.House8, new HouseName[1] { HouseName.House8 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse9)]
	public static CalculatorResult Lord2InHouse9(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		bool occuring = Calculate.HousePlanetOccupies(planetName, time) == HouseName.House9;
		_ = $"Lord 2:{planetName}";
		return CalculatorResult.New(occuring, new HouseName[1] { HouseName.House9 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse10)]
	public static CalculatorResult Lord2InHouse10(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New(Calculate.HousePlanetOccupies(planetName, time) == HouseName.House10, new HouseName[1] { HouseName.House10 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse11)]
	public static CalculatorResult Lord2InHouse11(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		return CalculatorResult.New(Calculate.HousePlanetOccupies(planetName, time) == HouseName.House11, new HouseName[1] { HouseName.House11 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.Lord2InHouse12)]
	public static CalculatorResult Lord2InHouse12(Time time)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, time);
		bool occuring = Calculate.HousePlanetOccupies(planetName, time) == HouseName.House12;
		_ = $"Lord 2:{planetName}";
		return CalculatorResult.New(occuring, new HouseName[1] { HouseName.House12 }, new PlanetName[1] { planetName }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MaleficIn11FromArudha)]
	public static CalculatorResult MaleficIn11FromArudha(Time time)
	{
		ZodiacName sign = Calculate.SignCountedFromInputSign(Calculate.ArudhaLagnaSign(time), 11);
		return CalculatorResult.New(Calculate.IsMaleficPlanetInSign(sign, time), planetNames: Calculate.MaleficPlanetListInSign(sign, time).ToArray(), houseNames: new HouseName[1] { HouseName.House11 }, time: time);
	}

	[HoroscopeCalculator(HoroscopeName.BeneficIn11FromArudha)]
	public static CalculatorResult BeneficIn11FromArudha(Time time)
	{
		ZodiacName sign = Calculate.SignCountedFromInputSign(Calculate.ArudhaLagnaSign(time), 11);
		return CalculatorResult.New(Calculate.IsBeneficPlanetInSign(sign, time), planetNames: Calculate.BeneficPlanetListInSign(sign, time).ToArray(), houseNames: new HouseName[1] { HouseName.House11 }, time: time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInAries)]
	public static CalculatorResult SunInAries(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Aries, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Aries }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInTaurus)]
	public static CalculatorResult SunInTaurus(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Taurus, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Taurus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInGemini)]
	public static CalculatorResult SunInGemini(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Gemini, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Gemini }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInCancer)]
	public static CalculatorResult SunInCancer(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Cancer, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Cancer }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInLeo)]
	public static CalculatorResult SunInLeo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Leo, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Leo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInVirgo)]
	public static CalculatorResult SunInVirgo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Virgo, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Virgo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInLibra)]
	public static CalculatorResult SunInLibra(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Libra, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Libra }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInScorpio)]
	public static CalculatorResult SunInScorpio(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Scorpio, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Scorpio }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInSagittarius)]
	public static CalculatorResult SunInSagittarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Sagittarius, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Sagittarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInCapricorn)]
	public static CalculatorResult SunInCapricorn(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Capricorn, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Capricorn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInAquarius)]
	public static CalculatorResult SunInAquarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Aquarius, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Aquarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SunInPisces)]
	public static CalculatorResult SunInPisces(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Sun, ZodiacName.Pisces, time), new PlanetName[1] { PlanetName.Sun }, new ZodiacName[1] { ZodiacName.Pisces }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInAries)]
	public static CalculatorResult MoonInAries(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Aries, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Aries }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInTaurus)]
	public static CalculatorResult MoonInTaurus(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Taurus, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Taurus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInGemini)]
	public static CalculatorResult MoonInGemini(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Gemini, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Gemini }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInCancer)]
	public static CalculatorResult MoonInCancer(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Cancer, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Cancer }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInLeo)]
	public static CalculatorResult MoonInLeo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Leo, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Leo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInVirgo)]
	public static CalculatorResult MoonInVirgo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Virgo, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Virgo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInLibra)]
	public static CalculatorResult MoonInLibra(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Libra, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Libra }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInScorpio)]
	public static CalculatorResult MoonInScorpio(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Scorpio, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Scorpio }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInSagittarius)]
	public static CalculatorResult MoonInSagittarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Sagittarius, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Sagittarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInCapricorn)]
	public static CalculatorResult MoonInCapricorn(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Capricorn, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Capricorn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInAquarius)]
	public static CalculatorResult MoonInAquarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Aquarius, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Aquarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MoonInPisces)]
	public static CalculatorResult MoonInPisces(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Moon, ZodiacName.Pisces, time), new PlanetName[1] { PlanetName.Moon }, new ZodiacName[1] { ZodiacName.Pisces }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInAries)]
	public static CalculatorResult MarsInAries(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Aries, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Aries }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInTaurus)]
	public static CalculatorResult MarsInTaurus(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Taurus, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Taurus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInGemini)]
	public static CalculatorResult MarsInGemini(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Gemini, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Gemini }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInCancer)]
	public static CalculatorResult MarsInCancer(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Cancer, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Cancer }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInLeo)]
	public static CalculatorResult MarsInLeo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Leo, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Leo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInVirgo)]
	public static CalculatorResult MarsInVirgo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Virgo, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Virgo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInLibra)]
	public static CalculatorResult MarsInLibra(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Libra, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Libra }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInScorpio)]
	public static CalculatorResult MarsInScorpio(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Scorpio, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Scorpio }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInSagittarius)]
	public static CalculatorResult MarsInSagittarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Sagittarius, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Sagittarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInCapricorn)]
	public static CalculatorResult MarsInCapricorn(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Capricorn, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Capricorn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInAquarius)]
	public static CalculatorResult MarsInAquarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Aquarius, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Aquarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsInPisces)]
	public static CalculatorResult MarsInPisces(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mars, ZodiacName.Pisces, time), new PlanetName[1] { PlanetName.Mars }, new ZodiacName[1] { ZodiacName.Pisces }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInAries)]
	public static CalculatorResult MercuryInAries(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Aries, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Aries }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInTaurus)]
	public static CalculatorResult MercuryInTaurus(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Taurus, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Taurus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInGemini)]
	public static CalculatorResult MercuryInGemini(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Gemini, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Gemini }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInCancer)]
	public static CalculatorResult MercuryInCancer(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Cancer, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Cancer }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInLeo)]
	public static CalculatorResult MercuryInLeo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Leo, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Leo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInVirgo)]
	public static CalculatorResult MercuryInVirgo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Virgo, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Virgo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInLibra)]
	public static CalculatorResult MercuryInLibra(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Libra, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Libra }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInScorpio)]
	public static CalculatorResult MercuryInScorpio(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Scorpio, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Scorpio }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInSagittarius)]
	public static CalculatorResult MercuryInSagittarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Sagittarius, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Sagittarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInCapricorn)]
	public static CalculatorResult MercuryInCapricorn(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Capricorn, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Capricorn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInAquarius)]
	public static CalculatorResult MercuryInAquarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Aquarius, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Aquarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryInPisces)]
	public static CalculatorResult MercuryInPisces(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Mercury, ZodiacName.Pisces, time), new PlanetName[1] { PlanetName.Mercury }, new ZodiacName[1] { ZodiacName.Pisces }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInAries)]
	public static CalculatorResult JupiterInAries(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Aries, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Aries }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInTaurus)]
	public static CalculatorResult JupiterInTaurus(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Taurus, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Taurus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInGemini)]
	public static CalculatorResult JupiterInGemini(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Gemini, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Gemini }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInCancer)]
	public static CalculatorResult JupiterInCancer(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Cancer, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Cancer }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInLeo)]
	public static CalculatorResult JupiterInLeo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Leo, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Leo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInVirgo)]
	public static CalculatorResult JupiterInVirgo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Virgo, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Virgo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInLibra)]
	public static CalculatorResult JupiterInLibra(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Libra, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Libra }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInScorpio)]
	public static CalculatorResult JupiterInScorpio(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Scorpio, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Scorpio }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInSagittarius)]
	public static CalculatorResult JupiterInSagittarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Sagittarius, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Sagittarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInCapricorn)]
	public static CalculatorResult JupiterInCapricorn(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Capricorn, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Capricorn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInAquarius)]
	public static CalculatorResult JupiterInAquarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Aquarius, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Aquarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.JupiterInPisces)]
	public static CalculatorResult JupiterInPisces(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Jupiter, ZodiacName.Pisces, time), new PlanetName[1] { PlanetName.Jupiter }, new ZodiacName[1] { ZodiacName.Pisces }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInAries)]
	public static CalculatorResult VenusInAries(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Aries, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Aries }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInTaurus)]
	public static CalculatorResult VenusInTaurus(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Taurus, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Taurus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInGemini)]
	public static CalculatorResult VenusInGemini(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Gemini, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Gemini }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInCancer)]
	public static CalculatorResult VenusInCancer(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Cancer, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Cancer }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInLeo)]
	public static CalculatorResult VenusInLeo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Leo, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Leo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInVirgo)]
	public static CalculatorResult VenusInVirgo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Virgo, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Virgo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInLibra)]
	public static CalculatorResult VenusInLibra(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Libra, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Libra }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInScorpio)]
	public static CalculatorResult VenusInScorpio(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Scorpio, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Scorpio }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInSagittarius)]
	public static CalculatorResult VenusInSagittarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Sagittarius, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Sagittarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInCapricorn)]
	public static CalculatorResult VenusInCapricorn(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Capricorn, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Capricorn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInAquarius)]
	public static CalculatorResult VenusInAquarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Aquarius, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Aquarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.VenusInPisces)]
	public static CalculatorResult VenusInPisces(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Venus, ZodiacName.Pisces, time), new PlanetName[1] { PlanetName.Venus }, new ZodiacName[1] { ZodiacName.Pisces }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInAries)]
	public static CalculatorResult SaturnInAries(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Aries, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Aries }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInTaurus)]
	public static CalculatorResult SaturnInTaurus(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Taurus, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Taurus }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInGemini)]
	public static CalculatorResult SaturnInGemini(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Gemini, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Gemini }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInCancer)]
	public static CalculatorResult SaturnInCancer(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Cancer, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Cancer }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInLeo)]
	public static CalculatorResult SaturnInLeo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Leo, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Leo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInVirgo)]
	public static CalculatorResult SaturnInVirgo(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Virgo, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Virgo }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInLibra)]
	public static CalculatorResult SaturnInLibra(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Libra, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Libra }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInScorpio)]
	public static CalculatorResult SaturnInScorpio(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Scorpio, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Scorpio }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInSagittarius)]
	public static CalculatorResult SaturnInSagittarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Sagittarius, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Sagittarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInCapricorn)]
	public static CalculatorResult SaturnInCapricorn(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Capricorn, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Capricorn }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInAquarius)]
	public static CalculatorResult SaturnInAquarius(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Aquarius, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Aquarius }, time);
	}

	[HoroscopeCalculator(HoroscopeName.SaturnInPisces)]
	public static CalculatorResult SaturnInPisces(Time time)
	{
		return CalculatorResult.New(Calculate.IsPlanetInSign(PlanetName.Saturn, ZodiacName.Pisces, time), new PlanetName[1] { PlanetName.Saturn }, new ZodiacName[1] { ZodiacName.Pisces }, time);
	}

	[HoroscopeCalculator(HoroscopeName.MarsVenusIn7th)]
	public static CalculatorResult MarsVenusIn7th(Time time)
	{
		bool num = Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House7, time);
		bool flag = Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House7, time);
		return CalculatorResult.New(num & flag, new HouseName[1] { HouseName.House7 }, new PlanetName[2]
		{
			PlanetName.Mars,
			PlanetName.Venus
		}, time);
	}

	[HoroscopeCalculator(HoroscopeName.MercuryOrJupiterIn7th)]
	public static CalculatorResult MercuryOrJupiterIn7th(Time time)
	{
		bool num = Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House7, time);
		bool flag = Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House7, time);
		bool occuring = num | flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[HoroscopeCalculator(HoroscopeName.LeoLagna7thLordSaturnIn2)]
	public static CalculatorResult LeoLagna7thLordSaturnIn2(Time time)
	{
		bool num = Calculate.HouseSignName(HouseName.House1, time) == ZodiacName.Leo;
		bool flag = Calculate.LordOfHouse(HouseName.House7, time) == PlanetName.Saturn;
		bool flag2 = Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House2, time);
		bool occuring = num & flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[HoroscopeCalculator(HoroscopeName.SaturnIn7thNotLagnaLord)]
	public static CalculatorResult SaturnIn7thNotLagnaLord(Time time)
	{
		bool num = Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House7, time);
		bool flag = Calculate.LordOfHouse(HouseName.House1, time) != PlanetName.Saturn;
		bool flag2 = Calculate.LordOfHouse(HouseName.House7, time) != PlanetName.Saturn;
		bool occuring = num & flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[HoroscopeCalculator(HoroscopeName.MarsIn7thNoBenefics)]
	public static CalculatorResult MarsIn7thNoBenefics(Time time)
	{
		bool num = Calculate.IsPlanetInHouse(PlanetName.Mars, HouseName.House7, time);
		bool flag = !Calculate.IsBeneficPlanetAspectHouse(HouseName.House7, time);
		bool flag2 = !Calculate.IsBeneficPlanetInHouse(HouseName.House7, time);
		bool occuring = num & flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[HoroscopeCalculator(HoroscopeName.SunVenusIn5th7th9th)]
	public static CalculatorResult SunVenusIn5th7th9th(Time time)
	{
		bool num = Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House5, time);
		bool flag = Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House5, time);
		bool num2 = num & flag;
		bool num3 = Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House7, time);
		bool flag2 = Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House7, time);
		bool flag3 = num3 & flag2;
		bool num4 = Calculate.IsPlanetInHouse(PlanetName.Sun, HouseName.House9, time);
		bool flag4 = Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House9, time);
		bool flag5 = num4 & flag4;
		bool occuring = num2 | flag3 | flag5;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[HoroscopeCalculator(HoroscopeName.Lord7And1Friends)]
	public static CalculatorResult Lord7And1Friends(Time time)
	{
		PlanetName mainPlanet = Calculate.LordOfHouse(HouseName.House7, time);
		PlanetName secondaryPlanet = Calculate.LordOfHouse(HouseName.House1, time);
		PlanetToPlanetRelationship planetToPlanetRelationship = Calculate.PlanetCombinedRelationshipWithPlanet(mainPlanet, secondaryPlanet, time);
		bool occuring = planetToPlanetRelationship == PlanetToPlanetRelationship.BestFriend || planetToPlanetRelationship == PlanetToPlanetRelationship.Friend;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[HoroscopeCalculator(HoroscopeName.Lord7And1NotFriends)]
	public static CalculatorResult Lord7And1NotFriends(Time time)
	{
		PlanetName mainPlanet = Calculate.LordOfHouse(HouseName.House7, time);
		PlanetName secondaryPlanet = Calculate.LordOfHouse(HouseName.House1, time);
		PlanetToPlanetRelationship planetToPlanetRelationship = Calculate.PlanetCombinedRelationshipWithPlanet(mainPlanet, secondaryPlanet, time);
		bool occuring = planetToPlanetRelationship == PlanetToPlanetRelationship.BitterEnemy || planetToPlanetRelationship == PlanetToPlanetRelationship.Enemy;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[HoroscopeCalculator(HoroscopeName.SaturnIn7th)]
	public static CalculatorResult SaturnIn7th(Time time)
	{
		bool occuring = Calculate.IsPlanetInHouse(PlanetName.Saturn, HouseName.House7, time);
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[HoroscopeCalculator(HoroscopeName.GeminiRisingWithEvilPlanet)]
	public static CalculatorResult GeminiRisingWithEvilPlanet(Time time)
	{
		bool num = Calculate.HouseSignName(HouseName.House1, time) == ZodiacName.Gemini;
		IEnumerable<PlanetName> source = from planet in Calculate.PlanetInSign(ZodiacName.Gemini, time)
			where Calculate.IsPlanetMalefic(planet, time)
			select planet;
		bool flag = source.Any();
		return CalculatorResult.New(num & flag, new HouseName[1] { HouseName.House1 }, source.ToArray(), new ZodiacName[1] { ZodiacName.Gemini }, time);
	}

	[HoroscopeCalculator(HoroscopeName.AriesRisingWithEvilPlanet)]
	public static CalculatorResult AriesRisingWithEvilPlanet(Time time)
	{
		bool num = Calculate.HouseSignName(HouseName.House1, time) == ZodiacName.Aries;
		List<PlanetName> list = Calculate.PlanetInSign(ZodiacName.Aries, time);
		bool flag = list.Contains(PlanetName.Saturn) || list.Contains(PlanetName.Moon);
		return CalculatorResult.New(num & flag, new HouseName[1] { HouseName.House1 }, new PlanetName[2]
		{
			PlanetName.Saturn,
			PlanetName.Moon
		}, new ZodiacName[1] { ZodiacName.Aries }, time);
	}
}
