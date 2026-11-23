using System;
using System.Collections.Generic;
using System.Linq;

namespace VedAstro.Library;

public static class EventCalculatorMethods
{
	[EventCalculator(EventName.Empty)]
	public static CalculatorResult Empty(Time time, Person person)
	{
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.BirdRuling)]
	public static CalculatorResult BirdRuling(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.MainActivity(person.BirthTime, time) == BirdActivity.Ruling)
		};
	}

	[EventCalculator(EventName.BirdEating)]
	public static CalculatorResult BirdEating(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.MainActivity(person.BirthTime, time) == BirdActivity.Eating)
		};
	}

	[EventCalculator(EventName.BirdWalking)]
	public static CalculatorResult BirdWalking(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.MainActivity(person.BirthTime, time) == BirdActivity.Walking)
		};
	}

	[EventCalculator(EventName.BirdSleeping)]
	public static CalculatorResult BirdSleeping(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.MainActivity(person.BirthTime, time) == BirdActivity.Sleeping)
		};
	}

	[EventCalculator(EventName.BirdDying)]
	public static CalculatorResult BirdDying(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.MainActivity(person.BirthTime, time) == BirdActivity.Dying)
		};
	}

	[EventCalculator(EventName.GoodLunarDayForTravel)]
	public static CalculatorResult GoodLunarDayForTravel(Time time, Person person)
	{
		int lunarDayNumber = Calculate.LunarDay(time).GetLunarDayNumber();
		bool occuring = lunarDayNumber == 2 || lunarDayNumber == 3 || lunarDayNumber == 5 || lunarDayNumber == 7 || lunarDayNumber == 10 || lunarDayNumber == 11 || lunarDayNumber == 13;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.BadLunarDayForTravel)]
	public static CalculatorResult BadLunarDayForTravel(Time time, Person person)
	{
		int lunarDayNumber = Calculate.LunarDay(time).GetLunarDayNumber();
		bool occuring = lunarDayNumber == 1 || lunarDayNumber == 14 || lunarDayNumber == 15;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GoodConstellationForTravel)]
	public static CalculatorResult GoodConstellationForTravel(Time time, Person person)
	{
		Constellation constellation = Calculate.MoonConstellation(time);
		ConstellationName constellationName = constellation.GetConstellationName();
		bool flag = false;
		if (constellationName == ConstellationName.Mrigasira || constellationName == ConstellationName.Aswini || constellationName == ConstellationName.Pushyami || constellationName == ConstellationName.Punarvasu || constellationName == ConstellationName.Hasta || constellationName == ConstellationName.Anuradha || constellationName == ConstellationName.Sravana || constellationName == ConstellationName.Moola || constellationName == ConstellationName.Dhanishta || constellationName == ConstellationName.Revathi)
		{
			flag = true;
		}
		bool flag2 = constellation.GetQuarter() != 1;
		bool occuring = flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.BadConstellationForTravel)]
	public static CalculatorResult BadConstellationForTravel(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		bool flag = false;
		if (constellationName == ConstellationName.Krithika || constellationName == ConstellationName.Bharani || constellationName == ConstellationName.Aslesha || constellationName == ConstellationName.Vishhaka || constellationName == ConstellationName.Pubba || constellationName == ConstellationName.Poorvabhadra || constellationName == ConstellationName.Aridra)
		{
			flag = true;
		}
		bool occuring = flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.BadWeekdayForTravelEast)]
	public static CalculatorResult BadWeekdayForTravelEast(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Saturday)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.BadWeekdayForTravelSouth)]
	public static CalculatorResult BadWeekdayForTravelSouth(Time time, Person person)
	{
		if (Calculate.DayOfWeek(time) == DayOfWeek.Thursday)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.BadWeekdayForTravelWest)]
	public static CalculatorResult BadWeekdayForTravelWest(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Friday)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.BadWeekdayForTravelNorth)]
	public static CalculatorResult BadWeekdayForTravelNorth(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if ((uint)(dayOfWeek - 3) <= 1u)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodLagnaForTravel)]
	public static CalculatorResult GoodLagnaForTravel(Time time, Person person)
	{
		ZodiacName zodiacName = Calculate.HouseSignName(HouseName.House1, time);
		if (zodiacName == ZodiacName.Aries || zodiacName == ZodiacName.Taurus || zodiacName == ZodiacName.Cancer || zodiacName == ZodiacName.Leo || zodiacName == ZodiacName.Libra || zodiacName == ZodiacName.Sagittarius)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.BestLagnaForTravel)]
	public static CalculatorResult BestLagnaForTravel(Time time, Person person)
	{
		ZodiacName num = Calculate.MoonSignName(person.BirthTime);
		ZodiacName zodiacName = Calculate.HouseSignName(HouseName.House1, time);
		if (num == zodiacName)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.WorstLagnaForTravel)]
	public static CalculatorResult WorstLagnaForTravel(Time time, Person person)
	{
		ZodiacName num = Calculate.HouseSignName(HouseName.House1, person.BirthTime);
		ZodiacName zodiacName = Calculate.HouseSignName(HouseName.House1, time);
		if (num == zodiacName)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.BadLagnaForTravel)]
	public static CalculatorResult BadLagnaForTravel(Time time, Person person)
	{
		ZodiacName zodiacName = Calculate.HouseSignName(HouseName.House1, person.BirthTime);
		ZodiacName num = Calculate.SignCountedFromLagnaSign(5, time);
		ZodiacName zodiacName2 = Calculate.SignCountedFromLagnaSign(7, time);
		ZodiacName zodiacName3 = Calculate.SignCountedFromLagnaSign(9, time);
		if (num == zodiacName || zodiacName2 == zodiacName || zodiacName3 == zodiacName)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodPlanetsInLagnaForTravel)]
	public static CalculatorResult GoodPlanetsInLagnaForTravel(Time time, Person person)
	{
		foreach (PlanetName item in Calculate.PlanetsInHouse(HouseName.House1, time))
		{
			if (item == PlanetName.Jupiter || item == PlanetName.Venus)
			{
				PlanetToSignRelationship planetToSignRelationship = Calculate.PlanetRelationshipWithHouse(HouseName.House1, item, time);
				if (planetToSignRelationship != PlanetToSignRelationship.EnemyVarga || planetToSignRelationship != PlanetToSignRelationship.BitterEnemyVarga)
				{
					return CalculatorResult.IsOccuring();
				}
			}
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodMoonJupiterTravelYoga)]
	public static CalculatorResult GoodMoonJupiterTravelYoga(Time time, Person person)
	{
		bool flag = Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House3, time) || Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House6, time) || Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House9, time) || Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House12, time);
		bool occuring = Calculate.IsPlanetInKendra(PlanetName.Jupiter, time) & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.FortifiedMoonTravelYoga)]
	public static CalculatorResult FortifiedMoonTravelYoga(Time time, Person person)
	{
		bool flag = Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House1, time);
		bool flag2 = Calculate.IsPlanetInKendra(new PlanetName[2]
		{
			PlanetName.Jupiter,
			PlanetName.Venus
		}, time);
		bool occuring = flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.StrongJupiterTravelYoga)]
	public static CalculatorResult StrongJupiterTravelYoga(Time time, Person person)
	{
		bool num = Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House1, time);
		bool flag = Calculate.IsPlanetStrongInShadbala(PlanetName.Jupiter, time);
		bool flag2 = !Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House8, time);
		bool occuring = num & flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.EasyPeacefulTravelYoga)]
	public static CalculatorResult EasyPeacefulTravelYoga(Time time, Person person)
	{
		bool num = Calculate.IsPlanetInHouse(PlanetName.Moon, HouseName.House7, time);
		bool flag = Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House4, time);
		bool flag2 = Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House4, time);
		bool occuring = num & flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.NeutralizeBadTravelYoga)]
	public static CalculatorResult NeutralizeBadTravelYoga(Time time, Person person)
	{
		bool num = Calculate.IsPlanetInHouse(PlanetName.Mercury, HouseName.House4, time);
		bool flag = Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House2, time);
		bool flag2 = Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House7, time);
		bool occuring = num | flag | flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.StrongBeneficsTravelYoga)]
	public static CalculatorResult StrongBeneficsTravelYoga(Time time, Person person)
	{
		foreach (PlanetName item in Calculate.BeneficPlanetList(time))
		{
			bool flag = Calculate.IsPlanetInKendra(item, time);
			bool flag2 = Calculate.IsPlanetInTrikona(item, time);
			bool num = flag | flag2;
			bool flag3 = Calculate.IsPlanetStrongInShadbala(item, time);
			if (num & flag3)
			{
				return CalculatorResult.IsOccuring();
			}
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.IdealPlanetsTravelYoga)]
	public static CalculatorResult IdealPlanetsTravelYoga(Time time, Person person)
	{
		bool num = Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House1, time);
		bool flag = Calculate.IsAllMaleficsInUpachayas(time);
		bool flag2 = !Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House7, time);
		bool occuring = num & flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GhatakaMoonSign)]
	public static CalculatorResult GhatakaMoonSign(Time time, Person person)
	{
		string item = "MoonSign";
		return CalculatorResult.New(Calculate.GhatakaChakra(time, person.BirthTime).Contains(item));
	}

	[EventCalculator(EventName.GhatakaTithiGroup)]
	public static CalculatorResult GhatakaTithiGroup(Time time, Person person)
	{
		string item = "TithiGroup";
		return CalculatorResult.New(Calculate.GhatakaChakra(time, person.BirthTime).Contains(item));
	}

	[EventCalculator(EventName.GhatakaWeekDay)]
	public static CalculatorResult WeekDayGroup(Time time, Person person)
	{
		string item = "WeekDay";
		return CalculatorResult.New(Calculate.GhatakaChakra(time, person.BirthTime).Contains(item));
	}

	[EventCalculator(EventName.GhatakaMoonConstellation)]
	public static CalculatorResult MoonConstellationGroup(Time time, Person person)
	{
		string item = "MoonConstellation";
		return CalculatorResult.New(Calculate.GhatakaChakra(time, person.BirthTime).Contains(item));
	}

	[EventCalculator(EventName.GhatakaLagna)]
	public static CalculatorResult GhatakaLagna(Time time, Person person)
	{
		string item = "LagnaSameSex";
		return CalculatorResult.New(Calculate.GhatakaChakra(time, person.BirthTime).Contains(item));
	}

	public static CalculatorResult IsGoodTarabalaOccuring(Time time, Person person)
	{
		return Calculate.Tarabala(time, person).GetName() switch
		{
			TarabalaName.Sampat => CalculatorResult.IsOccuring(), 
			TarabalaName.Kshema => CalculatorResult.IsOccuring(), 
			TarabalaName.Sadhana => CalculatorResult.IsOccuring(), 
			TarabalaName.Mitra => CalculatorResult.IsOccuring(), 
			TarabalaName.ParamaMitra => CalculatorResult.IsOccuring(), 
			_ => CalculatorResult.NotOccuring(), 
		};
	}

	public static CalculatorResult IsBadTarabalaOccuring(Time time, Person person)
	{
		return Calculate.Tarabala(time, person).GetName() switch
		{
			TarabalaName.Janma => CalculatorResult.IsOccuring(), 
			TarabalaName.Vipat => CalculatorResult.IsOccuring(), 
			TarabalaName.Pratyak => CalculatorResult.IsOccuring(), 
			TarabalaName.Naidhana => CalculatorResult.IsOccuring(), 
			_ => CalculatorResult.NotOccuring(), 
		};
	}

	[EventCalculator(EventName.TarabalaJanmaStrong)]
	public static CalculatorResult IsTarabalaJanmaStrongOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Janma && tarabala.GetCycle() == 1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaSampatStrong)]
	public static CalculatorResult IsTarabalaSampatStrongOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Sampat && tarabala.GetCycle() == 1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaVipatStrong)]
	public static CalculatorResult IsTarabalaVipatStrongOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Vipat && tarabala.GetCycle() == 1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaKshemaStrong)]
	public static CalculatorResult IsTarabalaKshemaStrongOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Kshema && tarabala.GetCycle() == 1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaPratyakStrong)]
	public static CalculatorResult IsTarabalaPratyakStrongOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Pratyak && tarabala.GetCycle() == 1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaSadhanaStrong)]
	public static CalculatorResult IsTarabalaSadhanaStrongOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Sadhana && tarabala.GetCycle() == 1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaNaidhanaStrong)]
	public static CalculatorResult IsTarabalaNaidhanaStrongOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Naidhana && tarabala.GetCycle() == 1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaMitraStrong)]
	public static CalculatorResult IsTarabalaMitraStrongOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Mitra && tarabala.GetCycle() == 1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaParamaMitraStrong)]
	public static CalculatorResult IsTarabalaParamaMitraStrongOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.ParamaMitra && tarabala.GetCycle() == 1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaJanmaMiddling)]
	public static CalculatorResult IsTarabalaJanmaMiddlingOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Janma && tarabala.GetCycle() == 2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaSampatMiddling)]
	public static CalculatorResult IsTarabalaSampatMiddlingOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Sampat && tarabala.GetCycle() == 2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaVipatMiddling)]
	public static CalculatorResult IsTarabalaVipatMiddlingOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Vipat && tarabala.GetCycle() == 2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaKshemaMiddling)]
	public static CalculatorResult IsTarabalaKshemaMiddlingOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Kshema && tarabala.GetCycle() == 2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaPratyakMiddling)]
	public static CalculatorResult IsTarabalaPratyakMiddlingOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Pratyak && tarabala.GetCycle() == 2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaSadhanaMiddling)]
	public static CalculatorResult IsTarabalaSadhanaMiddlingOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Sadhana && tarabala.GetCycle() == 2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaNaidhanaMiddling)]
	public static CalculatorResult IsTarabalaNaidhanaMiddlingOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Naidhana && tarabala.GetCycle() == 2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaMitraMiddling)]
	public static CalculatorResult IsTarabalaMitraMiddlingOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Mitra && tarabala.GetCycle() == 2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaParamaMitraMiddling)]
	public static CalculatorResult IsTarabalaParamaMitraMiddlingOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.ParamaMitra && tarabala.GetCycle() == 2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaJanmaWeak)]
	public static CalculatorResult IsTarabalaJanmaWeakOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Janma && tarabala.GetCycle() == 3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaSampatWeak)]
	public static CalculatorResult IsTarabalaSampatWeakOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Sampat && tarabala.GetCycle() == 3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaVipatWeak)]
	public static CalculatorResult IsTarabalaVipatWeakOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Vipat && tarabala.GetCycle() == 3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaKshemaWeak)]
	public static CalculatorResult IsTarabalaKshemaWeakOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Kshema && tarabala.GetCycle() == 3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaPratyakWeak)]
	public static CalculatorResult IsTarabalaPratyakWeakOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Pratyak && tarabala.GetCycle() == 3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaSadhanaWeak)]
	public static CalculatorResult IsTarabalaSadhanaWeakOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Sadhana && tarabala.GetCycle() == 3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaNaidhanaWeak)]
	public static CalculatorResult IsTarabalaNaidhanaWeakOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Naidhana && tarabala.GetCycle() == 3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaMitraWeak)]
	public static CalculatorResult IsTarabalaMitraWeakOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.Mitra && tarabala.GetCycle() == 3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TarabalaParamaMitraWeak)]
	public static CalculatorResult IsTarabalaParamaMitraWeakOccuring(Time time, Person person)
	{
		Tarabala tarabala = Calculate.Tarabala(time, person);
		bool occuring = tarabala.GetName() == TarabalaName.ParamaMitra && tarabala.GetCycle() == 3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GoodChandrabala)]
	public static CalculatorResult IsGoodChandrabalaOccuring(Time time, Person person)
	{
		if (IsBadChandrabalaOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.BadChandrabala)]
	public static CalculatorResult IsBadChandrabalaOccuring(Time time, Person person)
	{
		switch (Calculate.Chandrabala(time, person))
		{
		case 6:
			return CalculatorResult.IsOccuring();
		case 8:
			if (condition() || condition2() || condition3())
			{
				return CalculatorResult.NotOccuring();
			}
			return CalculatorResult.IsOccuring();
		case 12:
			return CalculatorResult.IsOccuring();
		default:
			return CalculatorResult.NotOccuring();
		}
		bool condition()
		{
			if (Calculate.LunarDay(time).GetMoonPhase() != MoonPhase.BrightHalf)
			{
				return false;
			}
			ZodiacSign zodiacSign = Calculate.PlanetZodiacSign(PlanetName.Moon, time);
			PlanetToSignRelationship planetToSignRelationship = Calculate.PlanetRelationshipWithSign(PlanetName.Moon, zodiacSign.GetSignName(), time);
			if (planetToSignRelationship != PlanetToSignRelationship.OwnVarga && planetToSignRelationship != PlanetToSignRelationship.FriendVarga && planetToSignRelationship != PlanetToSignRelationship.BestFriendVarga)
			{
				return false;
			}
			ZodiacName zodiacSignName = Calculate.PlanetNavamsaSign(PlanetName.Moon, time);
			PlanetToSignRelationship planetToSignRelationship2 = Calculate.PlanetRelationshipWithSign(PlanetName.Moon, zodiacSignName, time);
			if (planetToSignRelationship2 != PlanetToSignRelationship.OwnVarga && planetToSignRelationship2 != PlanetToSignRelationship.FriendVarga && planetToSignRelationship2 != PlanetToSignRelationship.BestFriendVarga)
			{
				return false;
			}
			return true;
		}
		bool condition2()
		{
			return IsGoodTarabalaOccuring(time, person).Occuring;
		}
		bool condition3()
		{
			PlanetName secondaryPlanet = Calculate.LordOfHouse(HouseName.House8, time);
			PlanetToPlanetRelationship planetToPlanetRelationship = Calculate.PlanetCombinedRelationshipWithPlanet(PlanetName.Moon, secondaryPlanet, time);
			if (planetToPlanetRelationship != PlanetToPlanetRelationship.BestFriend)
			{
				return planetToPlanetRelationship == PlanetToPlanetRelationship.Friend;
			}
			return true;
		}
	}

	[EventCalculator(EventName.GoodPanchaka)]
	public static CalculatorResult IsGoodPanchakaOccuring(Time time, Person person)
	{
		if (Calculate.Panchaka(time) == PanchakaName.Shubha)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.BadPanchaka)]
	public static CalculatorResult IsBadPanchakaOccuring(Time time, Person person)
	{
		if (IsGoodPanchakaOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.JanmaNakshatraRulling)]
	public static CalculatorResult IsJanmaNakshatraRullingOccuring(Time time, Person person)
	{
		Constellation constellation = Calculate.MoonConstellation(person.BirthTime);
		Constellation constellation2 = Calculate.MoonConstellation(time);
		bool occuring = constellation.GetConstellationName() == constellation2.GetConstellationName();
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.UgraYoga)]
	public static CalculatorResult IsUgraYogaOccuring(Time time, Person person)
	{
		int lunarDayNumber = Calculate.LunarDay(time).GetLunarDayNumber();
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if ((lunarDayNumber == 3 || lunarDayNumber == 9 || lunarDayNumber == 4 || lunarDayNumber == 5 || lunarDayNumber == 6 || lunarDayNumber == 7 || lunarDayNumber == 10 || lunarDayNumber == 12 || lunarDayNumber == 13) && (constellationName == ConstellationName.Rohini || constellationName == ConstellationName.Uttara || constellationName == ConstellationName.Sravana || constellationName == ConstellationName.Mrigasira || constellationName == ConstellationName.Revathi || constellationName == ConstellationName.Krithika || constellationName == ConstellationName.Pushyami || constellationName == ConstellationName.Anuradha || constellationName == ConstellationName.Makha))
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodTakingInjections)]
	public static CalculatorResult IsGoodTakingInjectionsOccuring(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek != DayOfWeek.Saturday && dayOfWeek != DayOfWeek.Monday)
		{
			return CalculatorResult.NotOccuring();
		}
		ZodiacName zodiacName = Calculate.HouseSignName(HouseName.House1, time);
		if (zodiacName != ZodiacName.Aries && zodiacName != ZodiacName.Taurus && zodiacName != ZodiacName.Cancer && zodiacName != ZodiacName.Virgo)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.PlanetsInHouse(HouseName.House8, time).Any())
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.IsMercuryAfflicted(time))
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	public static CalculatorResult IsCustomEventOccuring(Time time, Person person)
	{
		bool occuring = IsGoodTarabalaOccuring(time, person).Occuring;
		bool occuring2 = IsGoodChandrabalaOccuring(time, person).Occuring;
		bool occuring3 = IsUgraYogaOccuring(time, person).Occuring;
		if (occuring & occuring2 & occuring3)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.TaitulaKarana)]
	public static CalculatorResult IsTaitulaKaranaOccuring(Time time, Person person)
	{
		bool occuring = Calculate.Karana(time) == Karana.Taitula;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SakunaKarana)]
	public static CalculatorResult IsSakunaKaranaOccuring(Time time, Person person)
	{
		bool occuring = Calculate.Karana(time) == Karana.Sakuna;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.BavaKarana)]
	public static CalculatorResult IsBavaKaranaOccuring(Time time, Person person)
	{
		bool occuring = Calculate.Karana(time) == Karana.Bava;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.BhadraKarana)]
	public static CalculatorResult IsBhadraKaranaOccuring(Time time, Person person)
	{
		bool occuring = Calculate.Karana(time) == Karana.Visti;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Ekadashi)]
	public static CalculatorResult IsEkadashiOccuring(Time time, Person person)
	{
		if (Calculate.LunarDay(time).GetLunarDayNumber() != 11)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.BhriguShatka)]
	public static CalculatorResult IsBhriguShatkaOccuring(Time time, Person person)
	{
		if (Calculate.HousePlanetOccupies(PlanetName.Venus, time) == HouseName.House6)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.Kujasthama)]
	public static CalculatorResult IsKujasthamaOccuring(Time time, Person person)
	{
		if (Calculate.HousePlanetOccupies(PlanetName.Mars, time) == HouseName.House8)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.KarthariDosha)]
	public static CalculatorResult IsKarthariDoshaOccuring(Time time, Person person)
	{
		List<PlanetName> list = Calculate.MaleficPlanetList(time);
		bool flag = false;
		bool flag2 = false;
		List<PlanetName> list2 = Calculate.PlanetsInHouse(HouseName.House12, time);
		foreach (PlanetName item in list)
		{
			flag = list2.Contains(item);
			if (flag)
			{
				break;
			}
		}
		if (flag)
		{
			List<PlanetName> list3 = Calculate.PlanetsInHouse(HouseName.House2, time);
			foreach (PlanetName item2 in list)
			{
				flag2 = list3.Contains(item2);
				if (flag2)
				{
					break;
				}
			}
		}
		if (flag & flag2)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.ShashtashtaRiphagathaChandraDosha)]
	public static CalculatorResult IsShashtashtaRiphagathaChandraDoshaOccuring(Time time, Person person)
	{
		HouseName houseName = Calculate.HousePlanetOccupies(PlanetName.Moon, time);
		if (houseName == HouseName.House6 || houseName == HouseName.House8 || houseName == HouseName.House12)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.SagrahaChandraDosha)]
	public static CalculatorResult IsSagrahaChandraDoshaOccuring(Time time, Person person)
	{
		if (Calculate.PlanetsInConjuction(PlanetName.Moon, time).Count > 0)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.UdayasthaSuddhi)]
	public static CalculatorResult IsUdayasthaSuddhiOccuring(Time time, Person person)
	{
		bool flag = IsStrongLagnaOccuring(time);
		if (!flag)
		{
			return CalculatorResult.NotOccuring();
		}
		bool flag2 = IsStrongHouse7Occuring(time);
		bool occuring = flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
		static bool Is7thLordAspectingNavamsa7thOccuring(Time time2)
		{
			List<ZodiacName> list = Calculate.SignsPlanetIsAspecting(Calculate.LordOfHouse(HouseName.House7, time2), time2);
			ZodiacName item = Calculate.HouseNavamsaSign(HouseName.House7, time2);
			if (list.Contains(item))
			{
				return true;
			}
			return false;
		}
		static bool Is7thLordInNavamsa7thOccuring(Time time2)
		{
			ZodiacName num = Calculate.PlanetNavamsaSign(Calculate.LordOfHouse(HouseName.House7, time2), time2);
			ZodiacName zodiacName = Calculate.HouseNavamsaSign(HouseName.House7, time2);
			if (num == zodiacName)
			{
				return true;
			}
			return false;
		}
		static bool IsLagnaLordAspectingNavamsaLagnaOccuring(Time time2)
		{
			List<ZodiacName> list = Calculate.SignsPlanetIsAspecting(Calculate.LordOfHouse(HouseName.House1, time2), time2);
			ZodiacName item = Calculate.HouseNavamsaSign(HouseName.House1, time2);
			if (list.Contains(item))
			{
				return true;
			}
			return false;
		}
		static bool IsLagnaLordInNavamsaLagnaOccuring(Time time2)
		{
			ZodiacName num = Calculate.PlanetNavamsaSign(Calculate.LordOfHouse(HouseName.House1, time2), time2);
			ZodiacName zodiacName = Calculate.HouseNavamsaSign(HouseName.House1, time2);
			if (num == zodiacName)
			{
				return true;
			}
			return false;
		}
		static bool IsNavamsa7thLordAspecting7th(Time time2)
		{
			List<ZodiacName> list = Calculate.SignsPlanetIsAspecting(Calculate.LordOfZodiacSign(Calculate.HouseNavamsaSign(HouseName.House7, time2)), time2);
			ZodiacName item = Calculate.HouseSignName(HouseName.House7, time2);
			if (list.Contains(item))
			{
				return true;
			}
			return false;
		}
		bool IsNavamsa7thLordIn7th(Time time2)
		{
			ZodiacName signName = Calculate.PlanetZodiacSign(Calculate.LordOfZodiacSign(Calculate.HouseNavamsaSign(HouseName.House7, time2)), person.BirthTime).GetSignName();
			if (Calculate.HouseSignName(HouseName.House7, time2) == signName)
			{
				return true;
			}
			return false;
		}
		static bool IsNavamsa7thLordInNavamsa7thOccuring(Time time2)
		{
			ZodiacName zodiacName = Calculate.HouseNavamsaSign(HouseName.House7, time2);
			if (Calculate.PlanetNavamsaSign(Calculate.LordOfZodiacSign(zodiacName), time2) == zodiacName)
			{
				return true;
			}
			return false;
		}
		static bool IsNavamsaLagnaLordAspectingLagna(Time time2)
		{
			List<ZodiacName> list = Calculate.SignsPlanetIsAspecting(Calculate.LordOfZodiacSign(Calculate.HouseNavamsaSign(HouseName.House1, time2)), time2);
			ZodiacName item = Calculate.HouseSignName(HouseName.House1, time2);
			if (list.Contains(item))
			{
				return true;
			}
			return false;
		}
		bool IsNavamsaLagnaLordInLagna(Time time2)
		{
			ZodiacName signName = Calculate.PlanetZodiacSign(Calculate.LordOfZodiacSign(Calculate.HouseNavamsaSign(HouseName.House1, time2)), person.BirthTime).GetSignName();
			if (Calculate.HouseSignName(HouseName.House1, time2) == signName)
			{
				return true;
			}
			return false;
		}
		static bool IsNavamsaLagnaLordInNavamsaLagnaOccuring(Time time2)
		{
			ZodiacName zodiacName = Calculate.HouseNavamsaSign(HouseName.House1, time2);
			if (Calculate.PlanetNavamsaSign(Calculate.LordOfZodiacSign(zodiacName), time2) == zodiacName)
			{
				return true;
			}
			return false;
		}
		bool IsStrongHouse7Occuring(Time time2)
		{
			bool num = Calculate.IsHouseLordInHouse(HouseName.House7, HouseName.House7, time2);
			bool flag3 = IsNavamsa7thLordInNavamsa7thOccuring(time2);
			if (num & flag3)
			{
				return true;
			}
			bool num2 = IsNavamsa7thLordIn7th(time2);
			bool flag4 = Is7thLordInNavamsa7thOccuring(time2);
			if (num2 & flag4)
			{
				return true;
			}
			bool num3 = Is7thLordAspectingNavamsa7thOccuring(time2);
			bool flag5 = IsNavamsa7thLordAspecting7th(time2);
			if (num3 & flag5)
			{
				return true;
			}
			return false;
		}
		bool IsStrongLagnaOccuring(Time time2)
		{
			bool num = Calculate.IsHouseLordInHouse(HouseName.House1, HouseName.House1, time2);
			bool flag3 = IsNavamsaLagnaLordInNavamsaLagnaOccuring(time2);
			if (num & flag3)
			{
				return true;
			}
			bool num2 = IsNavamsaLagnaLordInLagna(time2);
			bool flag4 = IsLagnaLordInNavamsaLagnaOccuring(time2);
			if (num2 & flag4)
			{
				return true;
			}
			bool num3 = IsLagnaLordAspectingNavamsaLagnaOccuring(time2);
			bool flag5 = IsNavamsaLagnaLordAspectingLagna(time2);
			if (num3 & flag5)
			{
				return true;
			}
			return false;
		}
	}

	[EventCalculator(EventName.LagnaThyajya)]
	public static CalculatorResult IsLagnaThyajyaOccuring(Time time, Person person)
	{
		ZodiacSign zodiacSign = Calculate.ZodiacSignAtLongitude(Calculate.HouseLongitude(HouseName.House1, time).GetMiddleLongitude());
		ZodiacName signName = zodiacSign.GetSignName();
		double totalDegrees = zodiacSign.GetDegreesInSign().TotalDegrees;
		switch (signName)
		{
		case ZodiacName.Aries:
		case ZodiacName.Taurus:
		case ZodiacName.Virgo:
		case ZodiacName.Sagittarius:
			if (totalDegrees >= 0.0 && totalDegrees < 4.0)
			{
				return CalculatorResult.IsOccuring();
			}
			return CalculatorResult.NotOccuring();
		case ZodiacName.Cancer:
		case ZodiacName.Scorpio:
		case ZodiacName.Capricorn:
		case ZodiacName.Pisces:
			if (totalDegrees >= 27.0 && totalDegrees <= 30.0)
			{
				return CalculatorResult.IsOccuring();
			}
			return CalculatorResult.NotOccuring();
		case ZodiacName.Gemini:
		case ZodiacName.Leo:
		case ZodiacName.Libra:
		case ZodiacName.Aquarius:
			if (totalDegrees >= 13.5 && totalDegrees <= 16.5)
			{
				return CalculatorResult.IsOccuring();
			}
			return CalculatorResult.NotOccuring();
		default:
			return CalculatorResult.NotOccuring();
		}
	}

	[EventCalculator(EventName.NotAuspiciousDay)]
	public static CalculatorResult IsNotAuspiciousDayOccuring(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek == DayOfWeek.Tuesday && isAfterMidday())
		{
			return CalculatorResult.NotOccuring();
		}
		if (dayOfWeek == DayOfWeek.Tuesday || dayOfWeek == DayOfWeek.Saturday)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
		bool isAfterMidday()
		{
			DateTime dateTime = Calculate.LocalApparentTime(time);
			DateTime dateTime2 = Calculate.NoonTime(time);
			return dateTime > dateTime2;
		}
	}

	[EventCalculator(EventName.GoodPlanetsInLagna)]
	public static CalculatorResult IsGoodPlanetsInLagnaOccuring(Time time, Person person)
	{
		List<PlanetName> list = Calculate.PlanetsInHouse(HouseName.House1, time);
		List<PlanetName> list2 = new List<PlanetName>
		{
			PlanetName.Venus,
			PlanetName.Mercury,
			PlanetName.Jupiter
		};
		foreach (PlanetName item in list)
		{
			if (list2.Contains(item))
			{
				return CalculatorResult.IsOccuring();
			}
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodPlanetsIn11th)]
	public static CalculatorResult IsGoodPlanetsIn11thOccuring(Time time, Person person)
	{
		List<PlanetName> list = Calculate.PlanetsInHouse(HouseName.House11, time);
		List<PlanetName> list2 = new List<PlanetName>
		{
			PlanetName.Moon,
			PlanetName.Sun
		};
		foreach (PlanetName item in list)
		{
			if (list2.Contains(item))
			{
				return CalculatorResult.IsOccuring();
			}
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodPlanetsInKendra)]
	public static CalculatorResult IsGoodPlanetsInKendraOccuring(Time time, Person person)
	{
		if (!Calculate.IsPlanetInKendra(PlanetName.Jupiter, time) && !Calculate.IsPlanetInKendra(PlanetName.Venus, time))
		{
			return CalculatorResult.NotOccuring();
		}
		if (!isAllMaleficsIn3rd6th11th())
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
		bool isAllMaleficsIn3rd6th11th()
		{
			foreach (PlanetName item in Calculate.MaleficPlanetList(time))
			{
				HouseName houseName = Calculate.HousePlanetOccupies(item, time);
				if (houseName != HouseName.House3 && houseName != HouseName.House6 && houseName != HouseName.House11)
				{
					return false;
				}
			}
			return true;
		}
	}

	[EventCalculator(EventName.GoodRullingConstellation)]
	public static CalculatorResult IsGoodRullingConstellationOccuring(Time time, Person person)
	{
		if (Calculate.MoonConstellation(time).GetConstellationName() != ConstellationName.Pushyami)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.BadRullingConstellation)]
	public static CalculatorResult IsBadRullingConstellationOccuring(Time time, Person person)
	{
		Constellation constellation = Calculate.MoonConstellation(time);
		switch (constellation.GetConstellationName())
		{
		case ConstellationName.Bharani:
		case ConstellationName.Krithika:
			return CalculatorResult.IsOccuring();
		case ConstellationName.Aslesha:
		case ConstellationName.Jyesta:
		case ConstellationName.Revathi:
			if (constellation.GetQuarter() == 4)
			{
				return CalculatorResult.IsOccuring();
			}
			break;
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.SiddhaYoga)]
	public static CalculatorResult IsSiddhaYogaOccuring(Time time, Person person)
	{
		bool num = IsSiddhaYogaMondayOccuring(time, person);
		bool flag = IsSiddhaYogaTuesdayOccuring(time, person);
		bool flag2 = IsSiddhaYogaWednesdayOccuring(time, person);
		bool flag3 = IsSiddhaYogaThursdayOccuring(time, person);
		bool flag4 = IsSiddhaYogaFridayOccuring(time, person);
		bool flag5 = IsSiddhaYogaSaturdayOccuring(time, person);
		bool flag6 = IsSiddhaYogaSundayOccuring(time, person);
		if (num | flag | flag2 | flag3 | flag4 | flag5 | flag6)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
		static bool IsSiddhaYogaFridayOccuring(Time time2, Person person2)
		{
			DayOfWeek num2 = Calculate.DayOfWeek(time2);
			LunarDayGroup lunarDayGroup = Calculate.LunarDay(time2).GetLunarDayGroup();
			ConstellationName constellationName = Calculate.MoonConstellation(time2).GetConstellationName();
			if (num2 == DayOfWeek.Friday)
			{
				if ((lunarDayGroup == LunarDayGroup.Bhadra || lunarDayGroup == LunarDayGroup.Nanda) && (constellationName == ConstellationName.Aswini || constellationName == ConstellationName.Bharani || constellationName == ConstellationName.Aridra || constellationName == ConstellationName.Uttara || constellationName == ConstellationName.Chitta || constellationName == ConstellationName.Swathi || constellationName == ConstellationName.Poorvashada || constellationName == ConstellationName.Revathi))
				{
					return true;
				}
				if (lunarDayGroup == LunarDayGroup.Nanda)
				{
					return true;
				}
			}
			return false;
		}
		static bool IsSiddhaYogaMondayOccuring(Time time2, Person person2)
		{
			DayOfWeek num2 = Calculate.DayOfWeek(time2);
			int lunarDayNumber = Calculate.LunarDay(time2).GetLunarDayNumber();
			ConstellationName constellationName = Calculate.MoonConstellation(time2).GetConstellationName();
			if (num2 == DayOfWeek.Monday && (lunarDayNumber == 2 || lunarDayNumber == 7 || lunarDayNumber == 12) && (constellationName == ConstellationName.Rohini || constellationName == ConstellationName.Mrigasira || constellationName == ConstellationName.Punarvasu || constellationName == ConstellationName.Chitta || constellationName == ConstellationName.Sravana || constellationName == ConstellationName.Satabhisha || constellationName == ConstellationName.Dhanishta || constellationName == ConstellationName.Poorvabhadra))
			{
				return true;
			}
			return false;
		}
		static bool IsSiddhaYogaSaturdayOccuring(Time time2, Person person2)
		{
			DayOfWeek num2 = Calculate.DayOfWeek(time2);
			LunarDayGroup lunarDayGroup = Calculate.LunarDay(time2).GetLunarDayGroup();
			ConstellationName constellationName = Calculate.MoonConstellation(time2).GetConstellationName();
			if (num2 == DayOfWeek.Saturday)
			{
				if ((lunarDayGroup == LunarDayGroup.Bhadra || lunarDayGroup == LunarDayGroup.Rikta) && (constellationName == ConstellationName.Swathi || constellationName == ConstellationName.Rohini || constellationName == ConstellationName.Vishhaka || constellationName == ConstellationName.Anuradha || constellationName == ConstellationName.Dhanishta || constellationName == ConstellationName.Satabhisha))
				{
					return true;
				}
				if (lunarDayGroup == LunarDayGroup.Rikta)
				{
					return true;
				}
			}
			return false;
		}
		static bool IsSiddhaYogaSundayOccuring(Time time2, Person person2)
		{
			DayOfWeek num2 = Calculate.DayOfWeek(time2);
			int lunarDayNumber = Calculate.LunarDay(time2).GetLunarDayNumber();
			ConstellationName constellationName = Calculate.MoonConstellation(time2).GetConstellationName();
			if (num2 == DayOfWeek.Sunday && (lunarDayNumber == 1 || lunarDayNumber == 4 || lunarDayNumber == 6 || lunarDayNumber == 7 || lunarDayNumber == 12) && (constellationName == ConstellationName.Pushyami || constellationName == ConstellationName.Hasta || constellationName == ConstellationName.Uttara || constellationName == ConstellationName.Uttarashada || constellationName == ConstellationName.Moola || constellationName == ConstellationName.Sravana || constellationName == ConstellationName.Uttarashada))
			{
				return true;
			}
			return false;
		}
		static bool IsSiddhaYogaThursdayOccuring(Time time2, Person person2)
		{
			DayOfWeek num2 = Calculate.DayOfWeek(time2);
			int lunarDayNumber = Calculate.LunarDay(time2).GetLunarDayNumber();
			LunarDayGroup lunarDayGroup = Calculate.LunarDay(time2).GetLunarDayGroup();
			ConstellationName constellationName = Calculate.MoonConstellation(time2).GetConstellationName();
			if (num2 == DayOfWeek.Thursday)
			{
				if ((lunarDayNumber == 4 || lunarDayNumber == 5 || lunarDayNumber == 7 || lunarDayNumber == 9 || lunarDayNumber == 13 || lunarDayNumber == 14) && (constellationName == ConstellationName.Makha || constellationName == ConstellationName.Pushyami || constellationName == ConstellationName.Punarvasu || constellationName == ConstellationName.Swathi || constellationName == ConstellationName.Poorvashada || constellationName == ConstellationName.Poorvabhadra || constellationName == ConstellationName.Revathi || constellationName == ConstellationName.Aswini))
				{
					return true;
				}
				if (lunarDayGroup == LunarDayGroup.Purna)
				{
					return true;
				}
			}
			return false;
		}
		static bool IsSiddhaYogaTuesdayOccuring(Time time2, Person person2)
		{
			DayOfWeek num2 = Calculate.DayOfWeek(time2);
			LunarDayGroup lunarDayGroup = Calculate.LunarDay(time2).GetLunarDayGroup();
			ConstellationName constellationName = Calculate.MoonConstellation(time2).GetConstellationName();
			if (num2 == DayOfWeek.Tuesday)
			{
				if (constellationName == ConstellationName.Aswini || constellationName == ConstellationName.Mrigasira || constellationName == ConstellationName.Chitta || constellationName == ConstellationName.Anuradha || constellationName == ConstellationName.Moola || constellationName == ConstellationName.Uttara || constellationName == ConstellationName.Dhanishta || constellationName == ConstellationName.Poorvabhadra)
				{
					return true;
				}
				if (lunarDayGroup == LunarDayGroup.Jaya)
				{
					return true;
				}
			}
			return false;
		}
		static bool IsSiddhaYogaWednesdayOccuring(Time time2, Person person2)
		{
			DayOfWeek num2 = Calculate.DayOfWeek(time2);
			LunarDayGroup lunarDayGroup = Calculate.LunarDay(time2).GetLunarDayGroup();
			ConstellationName constellationName = Calculate.MoonConstellation(time2).GetConstellationName();
			if (num2 == DayOfWeek.Wednesday)
			{
				if ((lunarDayGroup == LunarDayGroup.Bhadra || lunarDayGroup == LunarDayGroup.Jaya) && (constellationName == ConstellationName.Rohini || constellationName == ConstellationName.Mrigasira || constellationName == ConstellationName.Aridra || constellationName == ConstellationName.Uttara || constellationName == ConstellationName.Uttarashada || constellationName == ConstellationName.Anuradha))
				{
					return true;
				}
				if (lunarDayGroup == LunarDayGroup.Bhadra)
				{
					return true;
				}
			}
			return false;
		}
	}

	[EventCalculator(EventName.AmritaSiddhaYoga)]
	public static CalculatorResult IsAmritaSiddhaYogaOccuring(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (dayOfWeek == DayOfWeek.Sunday && constellationName == ConstellationName.Hasta)
		{
			return CalculatorResult.IsOccuring();
		}
		if (dayOfWeek == DayOfWeek.Monday && constellationName == ConstellationName.Sravana)
		{
			return CalculatorResult.IsOccuring();
		}
		if (dayOfWeek == DayOfWeek.Tuesday && constellationName == ConstellationName.Aswini)
		{
			return CalculatorResult.IsOccuring();
		}
		if (dayOfWeek == DayOfWeek.Wednesday && constellationName == ConstellationName.Anuradha)
		{
			return CalculatorResult.IsOccuring();
		}
		if (dayOfWeek == DayOfWeek.Thursday && constellationName == ConstellationName.Pushyami)
		{
			return CalculatorResult.IsOccuring();
		}
		if (dayOfWeek == DayOfWeek.Friday && constellationName == ConstellationName.Revathi)
		{
			return CalculatorResult.IsOccuring();
		}
		if (dayOfWeek == DayOfWeek.Saturday && constellationName == ConstellationName.Rohini)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.PanchangaSuddhi)]
	public static CalculatorResult IsPanchangaSuddhiOccuring(Time time, Person person)
	{
		int lunarDayNumber = Calculate.LunarDay(time).GetLunarDayNumber();
		if (lunarDayNumber == 4 || lunarDayNumber == 6 || lunarDayNumber == 8 || lunarDayNumber == 12 || lunarDayNumber == 14 || lunarDayNumber == 15 || lunarDayNumber == 1)
		{
			return CalculatorResult.NotOccuring();
		}
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek != DayOfWeek.Thursday || dayOfWeek != DayOfWeek.Friday)
		{
			return CalculatorResult.NotOccuring();
		}
		Constellation constellation = Calculate.MoonConstellation(time);
		switch (constellation.GetConstellationName())
		{
		case ConstellationName.Bharani:
		case ConstellationName.Krithika:
			return CalculatorResult.NotOccuring();
		case ConstellationName.Aslesha:
		case ConstellationName.Jyesta:
		case ConstellationName.Revathi:
			if (constellation.GetQuarter() == 4)
			{
				return CalculatorResult.NotOccuring();
			}
			break;
		}
		NithyaYoga nithyaYoga = Calculate.NithyaYoga(time);
		if (nithyaYoga.Name == NithyaYogaName.Atiganda || nithyaYoga.Name == NithyaYogaName.Soola || nithyaYoga.Name == NithyaYogaName.Ganda || nithyaYoga.Name == NithyaYogaName.Vyatapata || nithyaYoga.Name == NithyaYogaName.Vaidhriti)
		{
			return CalculatorResult.NotOccuring();
		}
		Karana karana = Calculate.Karana(time);
		if (karana != Karana.Bava || karana != Karana.Taitula || karana != Karana.Visti || karana != Karana.Sakuna)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.BadNithyaYoga)]
	public static CalculatorResult IsBadNithyaYogaOccuring(Time time, Person person)
	{
		NithyaYoga nithyaYoga = Calculate.NithyaYoga(time);
		if (nithyaYoga.Name == NithyaYogaName.Atiganda || nithyaYoga.Name == NithyaYogaName.Soola || nithyaYoga.Name == NithyaYogaName.Ganda || nithyaYoga.Name == NithyaYogaName.Vyatapata || nithyaYoga.Name == NithyaYogaName.Vaidhriti)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.SuryaSankramana)]
	public static CalculatorResult IsSuryaSankramanaOccuring(Time time, Person person)
	{
		Time time2 = Calculate.TimeSunEnteredCurrentSign(time);
		if (time.Subtract(time2).TotalHours <= 6.4)
		{
			return CalculatorResult.IsOccuring();
		}
		if (Calculate.TimeSunLeavesCurrentSign(time).Subtract(time).TotalHours <= 6.4)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.Papashadvargas)]
	public static CalculatorResult IsPapashadvargasOccuring(Time time, Person person)
	{
		List<PlanetName> list = Calculate.MaleficPlanetList(time);
		list.RemoveAll((PlanetName name) => name == PlanetName.Rahu || name == PlanetName.Ketu);
		foreach (PlanetName item in list)
		{
			if (Calculate.IsPlanetStrongInShadbala(item, time))
			{
				return CalculatorResult.IsOccuring();
			}
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodHairCutting)]
	public static CalculatorResult IsGoodHairCuttingOccuring(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Pushyami && constellationName != ConstellationName.Punarvasu && constellationName != ConstellationName.Revathi && constellationName != ConstellationName.Hasta && constellationName != ConstellationName.Sravana && constellationName != ConstellationName.Dhanishta && constellationName != ConstellationName.Mrigasira && constellationName != ConstellationName.Aswini && constellationName != ConstellationName.Chitta && constellationName != ConstellationName.Jyesta && constellationName != ConstellationName.Satabhisha && constellationName != ConstellationName.Swathi)
		{
			return CalculatorResult.NotOccuring();
		}
		int lunarDayNumber = Calculate.LunarDay(time).GetLunarDayNumber();
		if (lunarDayNumber == 4 || lunarDayNumber == 6 || lunarDayNumber == 14 || lunarDayNumber == 1 || lunarDayNumber == 15)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodNailCutting)]
	public static CalculatorResult IsGoodNailCuttingOccuring(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek == DayOfWeek.Friday || dayOfWeek == DayOfWeek.Saturday)
		{
			return CalculatorResult.NotOccuring();
		}
		int lunarDayNumber = Calculate.LunarDay(time).GetLunarDayNumber();
		if (lunarDayNumber == 8 || lunarDayNumber == 9 || lunarDayNumber == 14 || lunarDayNumber == 1 || lunarDayNumber == 15)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.FixedConstellationRuling)]
	public static CalculatorResult IsFixedConstellationRulingOccuring(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Rohini && constellationName != ConstellationName.Uttara && constellationName != ConstellationName.Uttarashada && constellationName != ConstellationName.Uttarabhadra)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.SoftConstellationRuling)]
	public static CalculatorResult IsSoftConstellationRulingOccuring(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Chitta && constellationName != ConstellationName.Anuradha && constellationName != ConstellationName.Mrigasira && constellationName != ConstellationName.Revathi)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.LightConstellationRuling)]
	public static CalculatorResult IsLightConstellationRulingOccuring(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Aswini && constellationName != ConstellationName.Pushyami && constellationName != ConstellationName.Hasta)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.SharpConstellationRuling)]
	public static CalculatorResult IsSharpConstellationRulingOccuring(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Moola && constellationName != ConstellationName.Jyesta && constellationName != ConstellationName.Aridra && constellationName != ConstellationName.Aslesha)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.MovableConstellationRuling)]
	public static CalculatorResult IsMovableConstellationRulingOccuring(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Sravana && constellationName != ConstellationName.Dhanishta && constellationName != ConstellationName.Satabhisha && constellationName != ConstellationName.Punarvasu && constellationName != ConstellationName.Swathi)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.DreadfulConstellationRuling)]
	public static CalculatorResult IsDreadfulConstellationRulingOccuring(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Pubba && constellationName != ConstellationName.Poorvashada && constellationName != ConstellationName.Poorvabhadra && constellationName != ConstellationName.Bharani && constellationName != ConstellationName.Makha)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.MixedConstellationRuling)]
	public static CalculatorResult IsMixedConstellationRulingOccuring(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Krithika && constellationName != ConstellationName.Vishhaka)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodAnySeedsSowing)]
	public static CalculatorResult IsGoodAnySeedsSowingOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Hasta && constellationName != ConstellationName.Chitta && constellationName != ConstellationName.Swathi && constellationName != ConstellationName.Makha && constellationName != ConstellationName.Pushyami && constellationName != ConstellationName.Uttara && constellationName != ConstellationName.Uttarashada && constellationName != ConstellationName.Uttarabhadra && constellationName != ConstellationName.Rohini && constellationName != ConstellationName.Revathi && constellationName != ConstellationName.Aswini && constellationName != ConstellationName.Moola && constellationName != ConstellationName.Anuradha)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingTrees)]
	public static CalculatorResult IsGoodForPlantingTreesOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.MoonConstellation(time).GetConstellationName() != ConstellationName.Rohini)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingFlowerSeeds)]
	public static CalculatorResult IsGoodForPlantingFlowerSeedsOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Mrigasira && constellationName != ConstellationName.Punarvasu && constellationName != ConstellationName.Hasta && constellationName != ConstellationName.Chitta && constellationName != ConstellationName.Swathi && constellationName != ConstellationName.Anuradha && constellationName != ConstellationName.Revathi)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingSugarcane)]
	public static CalculatorResult IsGoodForPlantingSugarcaneOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.MoonConstellation(time).GetConstellationName() != ConstellationName.Punarvasu)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingFruitTrees)]
	public static CalculatorResult IsGoodForPlantingFruitTreesOccuring(Time time, Person person)
	{
		if (fruitTree() || fruitTree2())
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
		bool fruitTree()
		{
			if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
			{
				return false;
			}
			if (Calculate.DayOfWeek(time) != DayOfWeek.Thursday)
			{
				return false;
			}
			if (!Calculate.PlanetsInHouse(HouseName.House1, time).Contains(PlanetName.Jupiter))
			{
				return false;
			}
			return true;
		}
		bool fruitTree2()
		{
			if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
			{
				return false;
			}
			if (Calculate.DayOfWeek(time) != DayOfWeek.Thursday)
			{
				return false;
			}
			ZodiacName zodiacName = Calculate.HouseSignName(HouseName.House1, time);
			if (zodiacName != ZodiacName.Sagittarius && zodiacName != ZodiacName.Pisces)
			{
				return false;
			}
			return true;
		}
	}

	[EventCalculator(EventName.GoodForPlantingFlowerTrees)]
	public static CalculatorResult IsGoodForPlantingFlowerTreesOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.DayOfWeek(time) != DayOfWeek.Friday)
		{
			return CalculatorResult.NotOccuring();
		}
		if (!Calculate.PlanetsInHouse(HouseName.House1, time).Contains(PlanetName.Venus))
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingFlowers)]
	public static CalculatorResult IsGoodForPlantingFlowersOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.DayOfWeek(time) != DayOfWeek.Tuesday)
		{
			return CalculatorResult.NotOccuring();
		}
		if (!Calculate.PlanetsInHouse(HouseName.House1, time).Contains(PlanetName.Mars))
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingFlowerCuttings)]
	public static CalculatorResult IsGoodForPlantingFlowerCuttingsOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		ZodiacName zodiacName = Calculate.HouseSignName(HouseName.House1, time);
		if (zodiacName != ZodiacName.Taurus && zodiacName != ZodiacName.Libra)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingFloweringPlants)]
	public static CalculatorResult IsGoodForPlantingFloweringPlantsOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Virgo)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingGarlic)]
	public static CalculatorResult IsGoodForPlantingGarlicOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Aries)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingPeachAndOthers)]
	public static CalculatorResult IsGoodForPlantingPeachAndOthersOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Taurus)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingTomatoesAndOthers)]
	public static CalculatorResult IsGoodForPlantingTomatoesAndOthersOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Cancer)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingGrains)]
	public static CalculatorResult IsGoodForPlantingGrainsOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Libra)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingOnionAndOthers)]
	public static CalculatorResult IsGoodForPlantingOnionAndOthersOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Scorpio)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingPepperAndOthers)]
	public static CalculatorResult IsGoodForPlantingPepperAndOthersOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Sagittarius)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingPotatoAndOthers)]
	public static CalculatorResult IsGoodForPlantingPotatoAndOthersOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Capricorn)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingGrainsAndOthers)]
	public static CalculatorResult IsGoodForPlantingGrainsAndOthersOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Aquarius)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForPlantingPumpkinsAndOthers)]
	public static CalculatorResult IsGoodForPlantingPumpkinsAndOthersOccuring(Time time, Person person)
	{
		if (!IsGoodYogaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.HouseSignName(HouseName.House1, time) != ZodiacName.Pisces)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodYogaForAllAgriculture)]
	public static CalculatorResult IsGoodYogaForAllAgricultureOccuring(Time time, Person person)
	{
		if (!IsGoodLunarDayAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (!IsLagnaLordIsWeekdayLordOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (IsBadForStartingAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (IsBadLagnaForAllAgricultureOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.BadForStartingAllAgriculture)]
	public static CalculatorResult IsBadForStartingAllAgricultureOccuring(Time time, Person person)
	{
		if (Calculate.PlanetsInHouse(HouseName.House8, time).Any())
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.LagnaLordIsWeekdayLord)]
	public static CalculatorResult IsLagnaLordIsWeekdayLordOccuring(Time time, Person person)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House1, time);
		if (Calculate.LordOfWeekday(time) == planetName)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodLunarDayAgriculture)]
	public static CalculatorResult IsGoodLunarDayAgricultureOccuring(Time time, Person person)
	{
		int lunarDayNumber = Calculate.LunarDay(time).GetLunarDayNumber();
		if (lunarDayNumber != 1 && lunarDayNumber != 2 && lunarDayNumber != 3 && lunarDayNumber != 4 && lunarDayNumber != 5 && lunarDayNumber != 7 && lunarDayNumber != 11 && lunarDayNumber != 13 && lunarDayNumber != 15)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.BadLagnaForAllAgriculture)]
	public static CalculatorResult IsBadLagnaForAllAgricultureOccuring(Time time, Person person)
	{
		ZodiacName zodiacName = Calculate.HouseSignName(HouseName.House1, time);
		if (zodiacName == ZodiacName.Gemini || zodiacName == ZodiacName.Leo)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodSellingForProfit)]
	public static CalculatorResult IsGoodSellingForProfitOccuring(Time time, Person person)
	{
		if (Calculate.IsPlanetAspectedByPlanet(PlanetName.Moon, PlanetName.Mars, time))
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.IsPlanetAspectedByPlanet(PlanetName.Mercury, PlanetName.Mars, time))
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.IsPlanetConjunctWithPlanet(PlanetName.Moon, PlanetName.Mars, time))
		{
			return CalculatorResult.NotOccuring();
		}
		if (Calculate.IsPlanetConjunctWithPlanet(PlanetName.Mercury, PlanetName.Mars, time))
		{
			return CalculatorResult.NotOccuring();
		}
		ZodiacSign zodiacSign = Calculate.PlanetZodiacSign(PlanetName.Moon, time);
		if (zodiacSign.GetSignName() != ZodiacName.Taurus && zodiacSign.GetSignName() != ZodiacName.Cancer && zodiacSign.GetSignName() != ZodiacName.Pisces)
		{
			return CalculatorResult.NotOccuring();
		}
		bool num = Calculate.IsPlanetInKendra(PlanetName.Mercury, time);
		bool flag = Calculate.IsPlanetInGoodAspectToPlanet(PlanetName.Jupiter, PlanetName.Mercury, time);
		if (!(num | flag))
		{
			return CalculatorResult.NotOccuring();
		}
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek != DayOfWeek.Monday && dayOfWeek != DayOfWeek.Wednesday && dayOfWeek != DayOfWeek.Thursday && dayOfWeek != DayOfWeek.Saturday)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodWeekdayForSelling)]
	public static CalculatorResult IsGoodWeekdayForSellingOccuring(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek != DayOfWeek.Monday && dayOfWeek != DayOfWeek.Wednesday && dayOfWeek != DayOfWeek.Thursday)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodMoonSignForSelling)]
	public static CalculatorResult IsGoodMoonSignForSellingOccuring(Time time, Person person)
	{
		ZodiacSign zodiacSign = Calculate.PlanetZodiacSign(PlanetName.Moon, time);
		if (zodiacSign.GetSignName() != ZodiacName.Taurus && zodiacSign.GetSignName() != ZodiacName.Cancer && zodiacSign.GetSignName() != ZodiacName.Pisces)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.BadForBuyingToolsUtensilsJewellery)]
	public static CalculatorResult IsBadForBuyingToolsUtensilsJewelleryOccuring(Time time, Person person)
	{
		ConstellationName constellationName = Calculate.MoonConstellation(time).GetConstellationName();
		if (constellationName != ConstellationName.Aslesha && constellationName != ConstellationName.Moola && constellationName != ConstellationName.Jyesta)
		{
			return CalculatorResult.NotOccuring();
		}
		int lunarDayNumber = Calculate.LunarDay(time).GetLunarDayNumber();
		if (lunarDayNumber != 8 && lunarDayNumber != 9 && lunarDayNumber != 1)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForBuyingBrassVessels)]
	public static CalculatorResult IsGoodForBuyingBrassVesselsOccuring(Time time, Person person)
	{
		if (IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (!Calculate.IsPlanetInGoodAspectToPlanet(PlanetName.Moon, PlanetName.Jupiter, time))
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForBuyingCopperVessels)]
	public static CalculatorResult IsGoodForBuyingCopperVesselsOccuring(Time time, Person person)
	{
		if (IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (!Calculate.IsPlanetInGoodAspectToPlanet(PlanetName.Mars, PlanetName.Jupiter, time))
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForBuyingSteelIronVessels)]
	public static CalculatorResult IsGoodForBuyingSteelIronVesselsOccuring(Time time, Person person)
	{
		if (IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (!Calculate.IsPlanetInGoodAspectToPlanet(PlanetName.Saturn, PlanetName.Jupiter, time))
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForBuyingSilverVessels)]
	public static CalculatorResult IsGoodForBuyingSilverVesselsOccuring(Time time, Person person)
	{
		if (IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (!Calculate.IsPlanetInGoodAspectToHouse(HouseName.House1, PlanetName.Jupiter, time))
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodForBuyingJewellery)]
	public static CalculatorResult IsGoodForBuyingJewelleryOccuring(Time time, Person person)
	{
		if (IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring)
		{
			return CalculatorResult.NotOccuring();
		}
		if (!SunAndMoonWellSituatedAndAspected())
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
		bool SunAndMoonWellSituatedAndAspected()
		{
			Shashtiamsa shashtiamsa = Calculate.PlanetDrikBala(PlanetName.Sun, time);
			Shashtiamsa shashtiamsa2 = Calculate.PlanetDrikBala(PlanetName.Sun, time);
			if (!(shashtiamsa.ToDouble() > 0.0) || !(shashtiamsa2.ToDouble() > 0.0))
			{
				return false;
			}
			Shashtiamsa shashtiamsa3 = Calculate.PlanetSthanaBala(PlanetName.Sun, time);
			Shashtiamsa shashtiamsa4 = Calculate.PlanetSthanaBala(PlanetName.Moon, time);
			double num = Calculate.PlanetSthanaBalaNeutralPoint(PlanetName.Sun);
			double num2 = Calculate.PlanetSthanaBalaNeutralPoint(PlanetName.Moon);
			if (!(shashtiamsa3.ToDouble() > num) || !(shashtiamsa4.ToDouble() > num2))
			{
				return false;
			}
			return true;
		}
	}

	[EventCalculator(EventName.Yama1)]
	public static CalculatorResult Yama1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.BirthYama(time).YamaCount == 1)
		};
	}

	[EventCalculator(EventName.Yama2)]
	public static CalculatorResult Yama2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.BirthYama(time).YamaCount == 2)
		};
	}

	[EventCalculator(EventName.Yama3)]
	public static CalculatorResult Yama3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.BirthYama(time).YamaCount == 3)
		};
	}

	[EventCalculator(EventName.Yama4)]
	public static CalculatorResult Yama4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.BirthYama(time).YamaCount == 4)
		};
	}

	[EventCalculator(EventName.Yama5)]
	public static CalculatorResult Yama5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = (Calculate.BirthYama(time).YamaCount == 5)
		};
	}

	[EventCalculator(EventName.SunIsStrong)]
	public static CalculatorResult IsSunIsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllPlanetOrderedByStrength(time)[0] == PlanetName.Sun;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonIsStrong)]
	public static CalculatorResult IsMoonIsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllPlanetOrderedByStrength(time)[0] == PlanetName.Moon;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsIsStrong)]
	public static CalculatorResult IsMarsIsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllPlanetOrderedByStrength(time)[0] == PlanetName.Mars;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercuryIsStrong)]
	public static CalculatorResult IsMercuryIsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllPlanetOrderedByStrength(time)[0] == PlanetName.Mercury;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterIsStrong)]
	public static CalculatorResult IsJupiterIsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllPlanetOrderedByStrength(time)[0] == PlanetName.Jupiter;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusIsStrong)]
	public static CalculatorResult IsVenusIsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllPlanetOrderedByStrength(time)[0] == PlanetName.Venus;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnIsStrong)]
	public static CalculatorResult IsSaturnIsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllPlanetOrderedByStrength(time)[0] == PlanetName.Saturn;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House1IsStrong)]
	public static CalculatorResult IsHouse1IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House1;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House2IsStrong)]
	public static CalculatorResult IsHouse2IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House3IsStrong)]
	public static CalculatorResult IsHouse3IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House3;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House4IsStrong)]
	public static CalculatorResult IsHouse4IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House4;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House5IsStrong)]
	public static CalculatorResult IsHouse5IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House5;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House6IsStrong)]
	public static CalculatorResult IsHouse6IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House6;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House7IsStrong)]
	public static CalculatorResult IsHouse7IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House7;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House8IsStrong)]
	public static CalculatorResult IsHouse8IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House8;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House9IsStrong)]
	public static CalculatorResult IsHouse9IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House9;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House10IsStrong)]
	public static CalculatorResult IsHouse10IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House10;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House11IsStrong)]
	public static CalculatorResult IsHouse11IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House11;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.House12IsStrong)]
	public static CalculatorResult IsHouse12IsStrongOccuring(Time time, Person person)
	{
		bool occuring = Calculate.AllHousesOrderedByStrength(time)[0] == HouseName.House12;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Sunrise)]
	public static CalculatorResult IsSunriseOccuring(Time time, Person person)
	{
		Time time2 = Calculate.SunriseTime(time);
		double granularityHours = 0.08333333;
		Time time3 = time2.AddHours(granularityHours);
		Time time4 = time2.SubtractHours(granularityHours);
		bool num = time.GetLmtDateTimeOffset() >= time4.GetLmtDateTimeOffset();
		bool flag = time.GetLmtDateTimeOffset() <= time3.GetLmtDateTimeOffset();
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Sunset)]
	public static CalculatorResult IsSunsetOccuring(Time time, Person person)
	{
		Time time2 = Calculate.SunsetTime(time);
		double granularityHours = 0.08333333;
		Time time3 = time2.AddHours(granularityHours);
		Time time4 = time2.SubtractHours(granularityHours);
		bool num = time.GetLmtDateTimeOffset() >= time4.GetLmtDateTimeOffset();
		bool flag = time.GetLmtDateTimeOffset() <= time3.GetLmtDateTimeOffset();
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Midday)]
	public static CalculatorResult IsMiddayOccuring(Time time, Person person)
	{
		DateTime dateTime = Calculate.LocalApparentTime(time);
		DateTime dateTime2 = Calculate.NoonTime(time);
		double num = 0.08333333;
		DateTime dateTime3 = dateTime2.AddHours(num);
		DateTime dateTime4 = dateTime2.AddHours(0.0 - num);
		bool flag = dateTime >= dateTime4;
		bool flag2 = dateTime <= dateTime3;
		bool occuring = flag & flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.BadLunarMonthForBuilding)]
	public static CalculatorResult BadLunarMonthForBuilding(Time time, Person person)
	{
		bool flag;
		switch (Calculate.LunarMonth(time))
		{
		case LunarMonth.Jyeshtha:
		case LunarMonth.Aashaadha:
		case LunarMonth.Bhaadrapada:
		case LunarMonth.Aaswayuja:
		case LunarMonth.Maargasira:
		case LunarMonth.Pushya:
		case LunarMonth.Phaalguna:
			flag = true;
			break;
		default:
			flag = false;
			break;
		}
		if (flag)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodSunSignForBuilding)]
	public static CalculatorResult GoodSunSignForBuilding(Time time, Person person)
	{
		ZodiacName signName = Calculate.SunSign(time).GetSignName();
		bool flag = Calculate.IsFixedSign(signName);
		bool flag2 = Calculate.IsMovableSign(signName);
		bool occuring = flag | flag2;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.BadSunSignForBuilding)]
	public static CalculatorResult BadSunSignForBuilding(Time time, Person person)
	{
		bool occuring = Calculate.IsCommonSign(Calculate.SunSign(time).GetSignName());
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GoodLunarDayForBuilding)]
	public static CalculatorResult GoodLunarDayForBuilding(Time time, Person person)
	{
		int lunarDayNumber = Calculate.LunarDay(time).GetLunarDayNumber();
		if (lunarDayNumber != 1 && lunarDayNumber != 3 && lunarDayNumber != 5 && lunarDayNumber != 7 && lunarDayNumber != 11 && lunarDayNumber != 13 && lunarDayNumber != 15 && lunarDayNumber != 2 && lunarDayNumber != 6 && lunarDayNumber != 10)
		{
			return CalculatorResult.NotOccuring();
		}
		return CalculatorResult.IsOccuring();
	}

	[EventCalculator(EventName.GoodWeekDayForBuilding)]
	public static CalculatorResult GoodWeekDayForBuilding(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek == DayOfWeek.Monday || (uint)(dayOfWeek - 4) <= 2u)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.BadLunarPhaseForBuilding)]
	public static CalculatorResult BadLunarPhaseForBuilding(Time time, Person person)
	{
		bool occuring = Calculate.LunarDay(time).GetMoonPhase() == MoonPhase.DarkHalf;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.BadWeekDayForBuilding)]
	public static CalculatorResult BadWeekDayForBuilding(Time time, Person person)
	{
		DayOfWeek dayOfWeek = Calculate.DayOfWeek(time);
		if (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Saturday)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.BadWeekDayForRepairs)]
	public static CalculatorResult BadWeekDayForRepairs(Time time, Person person)
	{
		if (Calculate.DayOfWeek(time) == DayOfWeek.Tuesday)
		{
			return CalculatorResult.IsOccuring();
		}
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.GoodYogaForRepairs)]
	public static CalculatorResult GoodYogaForRepairs(Time time, Person person)
	{
		bool num = Calculate.DayOfWeek(time) == DayOfWeek.Friday;
		bool flag = Calculate.HouseSignName(HouseName.House1, time) == ZodiacName.Taurus;
		bool flag2 = Calculate.HouseSignName(HouseName.House1, time) == ZodiacName.Libra;
		bool num2 = num && (flag2 | flag);
		bool num3 = Calculate.DayOfWeek(time) == DayOfWeek.Monday;
		bool flag3 = Calculate.HouseSignName(HouseName.House1, time) == ZodiacName.Cancer;
		bool flag4 = num3 & flag3;
		bool occuring = num2 | flag4;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GoodYogaForRepairs2)]
	public static CalculatorResult GoodYogaForRepairs2(Time time, Person person)
	{
		bool flag = Calculate.IsBeneficPlanetInHouse(HouseName.House1, time);
		bool occuring = Calculate.IsWaterSign(Calculate.MoonSignName(time)) | flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunTransit8Bindu)]
	public static CalculatorResult SunTransit8Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Sun, 8)
		};
	}

	[EventCalculator(EventName.SunTransit7Bindu)]
	public static CalculatorResult SunTransit7Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Sun, 7)
		};
	}

	[EventCalculator(EventName.SunTransit6Bindu)]
	public static CalculatorResult SunTransit6Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Sun, 6)
		};
	}

	[EventCalculator(EventName.SunTransit5Bindu)]
	public static CalculatorResult SunTransit5Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Sun, 5)
		};
	}

	[EventCalculator(EventName.SunTransit4Bindu)]
	public static CalculatorResult SunTransit4Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Sun, 4)
		};
	}

	[EventCalculator(EventName.SunTransit3Bindu)]
	public static CalculatorResult SunTransit3Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Sun, 3)
		};
	}

	[EventCalculator(EventName.SunTransit2Bindu)]
	public static CalculatorResult SunTransit2Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Sun, 2)
		};
	}

	[EventCalculator(EventName.SunTransit1Bindu)]
	public static CalculatorResult SunTransit1Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Sun, 1)
		};
	}

	[EventCalculator(EventName.SunTransit0Bindu)]
	public static CalculatorResult SunTransit0Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Sun, 0)
		};
	}

	[EventCalculator(EventName.MoonTransit8Bindu)]
	public static CalculatorResult MoonTransit8Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Moon, 8)
		};
	}

	[EventCalculator(EventName.MoonTransit7Bindu)]
	public static CalculatorResult MoonTransit7Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Moon, 7)
		};
	}

	[EventCalculator(EventName.MoonTransit6Bindu)]
	public static CalculatorResult MoonTransit6Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Moon, 6)
		};
	}

	[EventCalculator(EventName.MoonTransit5Bindu)]
	public static CalculatorResult MoonTransit5Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Moon, 5)
		};
	}

	[EventCalculator(EventName.MoonTransit4Bindu)]
	public static CalculatorResult MoonTransit4Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Moon, 4)
		};
	}

	[EventCalculator(EventName.MoonTransit3Bindu)]
	public static CalculatorResult MoonTransit3Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Moon, 3)
		};
	}

	[EventCalculator(EventName.MoonTransit2Bindu)]
	public static CalculatorResult MoonTransit2Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Moon, 2)
		};
	}

	[EventCalculator(EventName.MoonTransit1Bindu)]
	public static CalculatorResult MoonTransit1Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Moon, 1)
		};
	}

	[EventCalculator(EventName.MoonTransit0Bindu)]
	public static CalculatorResult MoonTransit0Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Moon, 0)
		};
	}

	[EventCalculator(EventName.MarsTransit8Bindu)]
	public static CalculatorResult MarsTransit8Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mars, 8)
		};
	}

	[EventCalculator(EventName.MarsTransit7Bindu)]
	public static CalculatorResult MarsTransit7Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mars, 7)
		};
	}

	[EventCalculator(EventName.MarsTransit6Bindu)]
	public static CalculatorResult MarsTransit6Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mars, 6)
		};
	}

	[EventCalculator(EventName.MarsTransit5Bindu)]
	public static CalculatorResult MarsTransit5Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mars, 5)
		};
	}

	[EventCalculator(EventName.MarsTransit4Bindu)]
	public static CalculatorResult MarsTransit4Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mars, 4)
		};
	}

	[EventCalculator(EventName.MarsTransit3Bindu)]
	public static CalculatorResult MarsTransit3Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mars, 3)
		};
	}

	[EventCalculator(EventName.MarsTransit2Bindu)]
	public static CalculatorResult MarsTransit2Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mars, 2)
		};
	}

	[EventCalculator(EventName.MarsTransit1Bindu)]
	public static CalculatorResult MarsTransit1Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mars, 1)
		};
	}

	[EventCalculator(EventName.MarsTransit0Bindu)]
	public static CalculatorResult MarsTransit0Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mars, 0)
		};
	}

	[EventCalculator(EventName.MercuryTransit8Bindu)]
	public static CalculatorResult MercuryTransit8Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mercury, 8)
		};
	}

	[EventCalculator(EventName.MercuryTransit7Bindu)]
	public static CalculatorResult MercuryTransit7Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mercury, 7)
		};
	}

	[EventCalculator(EventName.MercuryTransit6Bindu)]
	public static CalculatorResult MercuryTransit6Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mercury, 6)
		};
	}

	[EventCalculator(EventName.MercuryTransit5Bindu)]
	public static CalculatorResult MercuryTransit5Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mercury, 5)
		};
	}

	[EventCalculator(EventName.MercuryTransit4Bindu)]
	public static CalculatorResult MercuryTransit4Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mercury, 4)
		};
	}

	[EventCalculator(EventName.MercuryTransit3Bindu)]
	public static CalculatorResult MercuryTransit3Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mercury, 3)
		};
	}

	[EventCalculator(EventName.MercuryTransit2Bindu)]
	public static CalculatorResult MercuryTransit2Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mercury, 2)
		};
	}

	[EventCalculator(EventName.MercuryTransit1Bindu)]
	public static CalculatorResult MercuryTransit1Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mercury, 1)
		};
	}

	[EventCalculator(EventName.MercuryTransit0Bindu)]
	public static CalculatorResult MercuryTransit0Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Mercury, 0)
		};
	}

	[EventCalculator(EventName.VenusTransit8Bindu)]
	public static CalculatorResult VenusTransit8Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Venus, 8)
		};
	}

	[EventCalculator(EventName.VenusTransit7Bindu)]
	public static CalculatorResult VenusTransit7Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Venus, 7)
		};
	}

	[EventCalculator(EventName.VenusTransit6Bindu)]
	public static CalculatorResult VenusTransit6Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Venus, 6)
		};
	}

	[EventCalculator(EventName.VenusTransit5Bindu)]
	public static CalculatorResult VenusTransit5Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Venus, 5)
		};
	}

	[EventCalculator(EventName.VenusTransit4Bindu)]
	public static CalculatorResult VenusTransit4Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Venus, 4)
		};
	}

	[EventCalculator(EventName.VenusTransit3Bindu)]
	public static CalculatorResult VenusTransit3Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Venus, 3)
		};
	}

	[EventCalculator(EventName.VenusTransit2Bindu)]
	public static CalculatorResult VenusTransit2Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Venus, 2)
		};
	}

	[EventCalculator(EventName.VenusTransit1Bindu)]
	public static CalculatorResult VenusTransit1Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Venus, 1)
		};
	}

	[EventCalculator(EventName.VenusTransit0Bindu)]
	public static CalculatorResult VenusTransit0Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Venus, 0)
		};
	}

	[EventCalculator(EventName.JupiterTransit8Bindu)]
	public static CalculatorResult JupiterTransit8Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Jupiter, 8)
		};
	}

	[EventCalculator(EventName.JupiterTransit7Bindu)]
	public static CalculatorResult JupiterTransit7Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Jupiter, 7)
		};
	}

	[EventCalculator(EventName.JupiterTransit6Bindu)]
	public static CalculatorResult JupiterTransit6Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Jupiter, 6)
		};
	}

	[EventCalculator(EventName.JupiterTransit5Bindu)]
	public static CalculatorResult JupiterTransit5Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Jupiter, 5)
		};
	}

	[EventCalculator(EventName.JupiterTransit4Bindu)]
	public static CalculatorResult JupiterTransit4Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Jupiter, 4)
		};
	}

	[EventCalculator(EventName.JupiterTransit3Bindu)]
	public static CalculatorResult JupiterTransit3Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Jupiter, 3)
		};
	}

	[EventCalculator(EventName.JupiterTransit2Bindu)]
	public static CalculatorResult JupiterTransit2Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Jupiter, 2)
		};
	}

	[EventCalculator(EventName.JupiterTransit1Bindu)]
	public static CalculatorResult JupiterTransit1Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Jupiter, 1)
		};
	}

	[EventCalculator(EventName.JupiterTransit0Bindu)]
	public static CalculatorResult JupiterTransit0Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Jupiter, 0)
		};
	}

	[EventCalculator(EventName.SaturnTransit8Bindu)]
	public static CalculatorResult SaturnTransit8Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Saturn, 8)
		};
	}

	[EventCalculator(EventName.SaturnTransit7Bindu)]
	public static CalculatorResult SaturnTransit7Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Saturn, 7)
		};
	}

	[EventCalculator(EventName.SaturnTransit6Bindu)]
	public static CalculatorResult SaturnTransit6Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Saturn, 6)
		};
	}

	[EventCalculator(EventName.SaturnTransit5Bindu)]
	public static CalculatorResult SaturnTransit5Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Saturn, 5)
		};
	}

	[EventCalculator(EventName.SaturnTransit4Bindu)]
	public static CalculatorResult SaturnTransit4Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Saturn, 4)
		};
	}

	[EventCalculator(EventName.SaturnTransit3Bindu)]
	public static CalculatorResult SaturnTransit3Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Saturn, 3)
		};
	}

	[EventCalculator(EventName.SaturnTransit2Bindu)]
	public static CalculatorResult SaturnTransit2Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Saturn, 2)
		};
	}

	[EventCalculator(EventName.SaturnTransit1Bindu)]
	public static CalculatorResult SaturnTransit1Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Saturn, 1)
		};
	}

	[EventCalculator(EventName.SaturnTransit0Bindu)]
	public static CalculatorResult SaturnTransit0Bindu(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsPlanetGocharaBindu(person.BirthTime, time, PlanetName.Saturn, 0)
		};
	}

	[EventCalculator(EventName.GocharaSummary)]
	public static CalculatorResult GocharaSummary(Time time, Person person)
	{
		return CalculatorResult.NotOccuring();
	}

	[EventCalculator(EventName.SunGocharaInHouse1)]
	public static CalculatorResult SunGocharaInHouse1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 1)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse2)]
	public static CalculatorResult SunGocharaInHouse2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 2)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse3)]
	public static CalculatorResult SunGocharaInHouse3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 3)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse4)]
	public static CalculatorResult SunGocharaInHouse4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 4)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse5)]
	public static CalculatorResult SunGocharaInHouse5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 5)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse6)]
	public static CalculatorResult SunGocharaInHouse6(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 6)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse7)]
	public static CalculatorResult SunGocharaInHouse7(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 7)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse8)]
	public static CalculatorResult SunGocharaInHouse8(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 8)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse9)]
	public static CalculatorResult SunGocharaInHouse9(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 9)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse10)]
	public static CalculatorResult SunGocharaInHouse10(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 10)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse11)]
	public static CalculatorResult SunGocharaInHouse11(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 11)
		};
	}

	[EventCalculator(EventName.SunGocharaInHouse12)]
	public static CalculatorResult SunGocharaInHouse12(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Sun, 12)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse1)]
	public static CalculatorResult MoonGocharaInHouse1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 1)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse2)]
	public static CalculatorResult MoonGocharaInHouse2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 2)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse3)]
	public static CalculatorResult MoonGocharaInHouse3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 3)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse4)]
	public static CalculatorResult MoonGocharaInHouse4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 4)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse5)]
	public static CalculatorResult MoonGocharaInHouse5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 5)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse6)]
	public static CalculatorResult MoonGocharaInHouse6(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 6)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse7)]
	public static CalculatorResult MoonGocharaInHouse7(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 7)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse8)]
	public static CalculatorResult MoonGocharaInHouse8(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 8)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse9)]
	public static CalculatorResult MoonGocharaInHouse9(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 9)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse10)]
	public static CalculatorResult MoonGocharaInHouse10(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 10)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse11)]
	public static CalculatorResult MoonGocharaInHouse11(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 11)
		};
	}

	[EventCalculator(EventName.MoonGocharaInHouse12)]
	public static CalculatorResult MoonGocharaInHouse12(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Moon, 12)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse1)]
	public static CalculatorResult MarsGocharaInHouse1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 1)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse2)]
	public static CalculatorResult MarsGocharaInHouse2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 2)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse3)]
	public static CalculatorResult MarsGocharaInHouse3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 3)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse4)]
	public static CalculatorResult MarsGocharaInHouse4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 4)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse5)]
	public static CalculatorResult MarsGocharaInHouse5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 5)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse6)]
	public static CalculatorResult MarsGocharaInHouse6(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 6)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse7)]
	public static CalculatorResult MarsGocharaInHouse7(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 7)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse8)]
	public static CalculatorResult MarsGocharaInHouse8(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 8)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse9)]
	public static CalculatorResult MarsGocharaInHouse9(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 9)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse10)]
	public static CalculatorResult MarsGocharaInHouse10(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 10)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse11)]
	public static CalculatorResult MarsGocharaInHouse11(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 11)
		};
	}

	[EventCalculator(EventName.MarsGocharaInHouse12)]
	public static CalculatorResult MarsGocharaInHouse12(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mars, 12)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse1)]
	public static CalculatorResult MercuryGocharaInHouse1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 1)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse2)]
	public static CalculatorResult MercuryGocharaInHouse2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 2)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse3)]
	public static CalculatorResult MercuryGocharaInHouse3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 3)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse4)]
	public static CalculatorResult MercuryGocharaInHouse4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 4)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse5)]
	public static CalculatorResult MercuryGocharaInHouse5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 5)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse6)]
	public static CalculatorResult MercuryGocharaInHouse6(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 6)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse7)]
	public static CalculatorResult MercuryGocharaInHouse7(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 7)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse8)]
	public static CalculatorResult MercuryGocharaInHouse8(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 8)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse9)]
	public static CalculatorResult MercuryGocharaInHouse9(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 9)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse10)]
	public static CalculatorResult MercuryGocharaInHouse10(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 10)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse11)]
	public static CalculatorResult MercuryGocharaInHouse11(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 11)
		};
	}

	[EventCalculator(EventName.MercuryGocharaInHouse12)]
	public static CalculatorResult MercuryGocharaInHouse12(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Mercury, 12)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse1)]
	public static CalculatorResult JupiterGocharaInHouse1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 1)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse2)]
	public static CalculatorResult JupiterGocharaInHouse2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 2)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse3)]
	public static CalculatorResult JupiterGocharaInHouse3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 3)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse4)]
	public static CalculatorResult JupiterGocharaInHouse4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 4)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse5)]
	public static CalculatorResult JupiterGocharaInHouse5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 5)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse6)]
	public static CalculatorResult JupiterGocharaInHouse6(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 6)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse7)]
	public static CalculatorResult JupiterGocharaInHouse7(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 7)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse8)]
	public static CalculatorResult JupiterGocharaInHouse8(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 8)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse9)]
	public static CalculatorResult JupiterGocharaInHouse9(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 9)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse10)]
	public static CalculatorResult JupiterGocharaInHouse10(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 10)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse11)]
	public static CalculatorResult JupiterGocharaInHouse11(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 11)
		};
	}

	[EventCalculator(EventName.JupiterGocharaInHouse12)]
	public static CalculatorResult JupiterGocharaInHouse12(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Jupiter, 12)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse1)]
	public static CalculatorResult VenusGocharaInHouse1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 1)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse2)]
	public static CalculatorResult VenusGocharaInHouse2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 2)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse3)]
	public static CalculatorResult VenusGocharaInHouse3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 3)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse4)]
	public static CalculatorResult VenusGocharaInHouse4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 4)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse5)]
	public static CalculatorResult VenusGocharaInHouse5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 5)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse6)]
	public static CalculatorResult VenusGocharaInHouse6(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 6)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse7)]
	public static CalculatorResult VenusGocharaInHouse7(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 7)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse8)]
	public static CalculatorResult VenusGocharaInHouse8(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 8)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse9)]
	public static CalculatorResult VenusGocharaInHouse9(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 9)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse10)]
	public static CalculatorResult VenusGocharaInHouse10(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 10)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse11)]
	public static CalculatorResult VenusGocharaInHouse11(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 11)
		};
	}

	[EventCalculator(EventName.VenusGocharaInHouse12)]
	public static CalculatorResult VenusGocharaInHouse12(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Venus, 12)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse1)]
	public static CalculatorResult SaturnGocharaInHouse1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 1)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse2)]
	public static CalculatorResult SaturnGocharaInHouse2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 2)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse3)]
	public static CalculatorResult SaturnGocharaInHouse3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 3)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse4)]
	public static CalculatorResult SaturnGocharaInHouse4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 4)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse5)]
	public static CalculatorResult SaturnGocharaInHouse5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 5)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse6)]
	public static CalculatorResult SaturnGocharaInHouse6(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 6)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse7)]
	public static CalculatorResult SaturnGocharaInHouse7(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 7)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse8)]
	public static CalculatorResult SaturnGocharaInHouse8(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 8)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse9)]
	public static CalculatorResult SaturnGocharaInHouse9(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 9)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse10)]
	public static CalculatorResult SaturnGocharaInHouse10(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 10)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse11)]
	public static CalculatorResult SaturnGocharaInHouse11(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 11)
		};
	}

	[EventCalculator(EventName.SaturnGocharaInHouse12)]
	public static CalculatorResult SaturnGocharaInHouse12(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Saturn, 12)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse1)]
	public static CalculatorResult RahuGocharaInHouse1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 1)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse2)]
	public static CalculatorResult RahuGocharaInHouse2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 2)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse3)]
	public static CalculatorResult RahuGocharaInHouse3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 3)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse4)]
	public static CalculatorResult RahuGocharaInHouse4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 4)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse5)]
	public static CalculatorResult RahuGocharaInHouse5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 5)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse6)]
	public static CalculatorResult RahuGocharaInHouse6(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 6)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse7)]
	public static CalculatorResult RahuGocharaInHouse7(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 7)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse8)]
	public static CalculatorResult RahuGocharaInHouse8(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 8)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse9)]
	public static CalculatorResult RahuGocharaInHouse9(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 9)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse10)]
	public static CalculatorResult RahuGocharaInHouse10(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 10)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse11)]
	public static CalculatorResult RahuGocharaInHouse11(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 11)
		};
	}

	[EventCalculator(EventName.RahuGocharaInHouse12)]
	public static CalculatorResult RahuGocharaInHouse12(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Rahu, 12)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse1)]
	public static CalculatorResult KetuGocharaInHouse1(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 1)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse2)]
	public static CalculatorResult KetuGocharaInHouse2(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 2)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse3)]
	public static CalculatorResult KetuGocharaInHouse3(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 3)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse4)]
	public static CalculatorResult KetuGocharaInHouse4(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 4)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse5)]
	public static CalculatorResult KetuGocharaInHouse5(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 5)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse6)]
	public static CalculatorResult KetuGocharaInHouse6(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 6)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse7)]
	public static CalculatorResult KetuGocharaInHouse7(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 7)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse8)]
	public static CalculatorResult KetuGocharaInHouse8(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 8)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse9)]
	public static CalculatorResult KetuGocharaInHouse9(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 9)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse10)]
	public static CalculatorResult KetuGocharaInHouse10(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 10)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse11)]
	public static CalculatorResult KetuGocharaInHouse11(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 11)
		};
	}

	[EventCalculator(EventName.KetuGocharaInHouse12)]
	public static CalculatorResult KetuGocharaInHouse12(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = Calculate.IsGocharaOccurring(person.BirthTime, time, PlanetName.Ketu, 12)
		};
	}

	[EventCalculator(EventName.AriesSunPD1)]
	public static CalculatorResult AriesSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Aries;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TaurusSunPD1)]
	public static CalculatorResult TaurusSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Taurus;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GeminiSunPD1)]
	public static CalculatorResult GeminiSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Gemini;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CancerSunPD1)]
	public static CalculatorResult CancerSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Cancer;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LeoSunPD1)]
	public static CalculatorResult LeoSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Leo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VirgoSunPD1)]
	public static CalculatorResult VirgoSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Virgo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LibraSunPD1)]
	public static CalculatorResult LibraSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Libra;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ScorpioSunPD1)]
	public static CalculatorResult ScorpioSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Scorpio;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SagittariusSunPD1)]
	public static CalculatorResult SagittariusSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Sagittarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CapricornSunPD1)]
	public static CalculatorResult CapricornSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Capricorn;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AquariusSunPD1)]
	public static CalculatorResult AquariusSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Aquarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.PiscesSunPD1)]
	public static CalculatorResult PiscesSunPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Sun, person.BirthTime).GetSignName() == ZodiacName.Pisces;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AriesMoonPD1)]
	public static CalculatorResult AriesMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Aries;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TaurusMoonPD1)]
	public static CalculatorResult TaurusMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Taurus;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GeminiMoonPD1)]
	public static CalculatorResult GeminiMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Gemini;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CancerMoonPD1)]
	public static CalculatorResult CancerMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Cancer;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LeoMoonPD1)]
	public static CalculatorResult LeoMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Leo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VirgoMoonPD1)]
	public static CalculatorResult VirgoMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Virgo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LibraMoonPD1)]
	public static CalculatorResult LibraMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Libra;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ScorpioMoonPD1)]
	public static CalculatorResult ScorpioMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Scorpio;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SagittariusMoonPD1)]
	public static CalculatorResult SagittariusMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Sagittarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CapricornMoonPD1)]
	public static CalculatorResult CapricornMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Capricorn;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AquariusMoonPD1)]
	public static CalculatorResult AquariusMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Aquarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.PiscesMoonPD1)]
	public static CalculatorResult PiscesMoonPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Moon, person.BirthTime).GetSignName() == ZodiacName.Pisces;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AriesMarsPD1)]
	public static CalculatorResult AriesMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Aries;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TaurusMarsPD1)]
	public static CalculatorResult TaurusMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Taurus;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GeminiMarsPD1)]
	public static CalculatorResult GeminiMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Gemini;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CancerMarsPD1)]
	public static CalculatorResult CancerMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Cancer;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LeoMarsPD1)]
	public static CalculatorResult LeoMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Leo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VirgoMarsPD1)]
	public static CalculatorResult VirgoMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Virgo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LibraMarsPD1)]
	public static CalculatorResult LibraMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Libra;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ScorpioMarsPD1)]
	public static CalculatorResult ScorpioMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Scorpio;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SagittariusMarsPD1)]
	public static CalculatorResult SagittariusMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Sagittarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CapricornMarsPD1)]
	public static CalculatorResult CapricornMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Capricorn;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AquariusMarsPD1)]
	public static CalculatorResult AquariusMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Aquarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.PiscesMarsPD1)]
	public static CalculatorResult PiscesMarsPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mars, person.BirthTime).GetSignName() == ZodiacName.Pisces;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AriesRahuPD1)]
	public static CalculatorResult AriesRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Aries;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TaurusRahuPD1)]
	public static CalculatorResult TaurusRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Taurus;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GeminiRahuPD1)]
	public static CalculatorResult GeminiRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Gemini;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CancerRahuPD1)]
	public static CalculatorResult CancerRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Cancer;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LeoRahuPD1)]
	public static CalculatorResult LeoRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Leo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VirgoRahuPD1)]
	public static CalculatorResult VirgoRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Virgo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LibraRahuPD1)]
	public static CalculatorResult LibraRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Libra;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ScorpioRahuPD1)]
	public static CalculatorResult ScorpioRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Scorpio;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SagittariusRahuPD1)]
	public static CalculatorResult SagittariusRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Sagittarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CapricornRahuPD1)]
	public static CalculatorResult CapricornRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Capricorn;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AquariusRahuPD1)]
	public static CalculatorResult AquariusRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Aquarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.PiscesRahuPD1)]
	public static CalculatorResult PiscesRahuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Rahu, person.BirthTime).GetSignName() == ZodiacName.Pisces;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AriesJupiterPD1)]
	public static CalculatorResult AriesJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Aries;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TaurusJupiterPD1)]
	public static CalculatorResult TaurusJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Taurus;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GeminiJupiterPD1)]
	public static CalculatorResult GeminiJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Gemini;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CancerJupiterPD1)]
	public static CalculatorResult CancerJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Cancer;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LeoJupiterPD1)]
	public static CalculatorResult LeoJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Leo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VirgoJupiterPD1)]
	public static CalculatorResult VirgoJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Virgo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LibraJupiterPD1)]
	public static CalculatorResult LibraJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Libra;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ScorpioJupiterPD1)]
	public static CalculatorResult ScorpioJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Scorpio;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SagittariusJupiterPD1)]
	public static CalculatorResult SagittariusJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Sagittarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CapricornJupiterPD1)]
	public static CalculatorResult CapricornJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Capricorn;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AquariusJupiterPD1)]
	public static CalculatorResult AquariusJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Aquarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.PiscesJupiterPD1)]
	public static CalculatorResult PiscesJupiterPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Jupiter, person.BirthTime).GetSignName() == ZodiacName.Pisces;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AriesSaturnPD1)]
	public static CalculatorResult AriesSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Aries;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TaurusSaturnPD1)]
	public static CalculatorResult TaurusSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Taurus;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GeminiSaturnPD1)]
	public static CalculatorResult GeminiSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Gemini;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CancerSaturnPD1)]
	public static CalculatorResult CancerSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Cancer;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LeoSaturnPD1)]
	public static CalculatorResult LeoSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Leo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VirgoSaturnPD1)]
	public static CalculatorResult VirgoSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Virgo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LibraSaturnPD1)]
	public static CalculatorResult LibraSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Libra;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ScorpioSaturnPD1)]
	public static CalculatorResult ScorpioSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Scorpio;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SagittariusSaturnPD1)]
	public static CalculatorResult SagittariusSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Sagittarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CapricornSaturnPD1)]
	public static CalculatorResult CapricornSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Capricorn;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AquariusSaturnPD1)]
	public static CalculatorResult AquariusSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Aquarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.PiscesSaturnPD1)]
	public static CalculatorResult PiscesSaturnPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Saturn, person.BirthTime).GetSignName() == ZodiacName.Pisces;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AriesMercuryPD1)]
	public static CalculatorResult AriesMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Aries;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TaurusMercuryPD1)]
	public static CalculatorResult TaurusMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Taurus;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GeminiMercuryPD1)]
	public static CalculatorResult GeminiMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Gemini;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CancerMercuryPD1)]
	public static CalculatorResult CancerMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Cancer;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LeoMercuryPD1)]
	public static CalculatorResult LeoMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Leo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VirgoMercuryPD1)]
	public static CalculatorResult VirgoMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Virgo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LibraMercuryPD1)]
	public static CalculatorResult LibraMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Libra;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ScorpioMercuryPD1)]
	public static CalculatorResult ScorpioMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Scorpio;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SagittariusMercuryPD1)]
	public static CalculatorResult SagittariusMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Sagittarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CapricornMercuryPD1)]
	public static CalculatorResult CapricornMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Capricorn;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AquariusMercuryPD1)]
	public static CalculatorResult AquariusMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Aquarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.PiscesMercuryPD1)]
	public static CalculatorResult PiscesMercuryPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Mercury, person.BirthTime).GetSignName() == ZodiacName.Pisces;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AriesKetuPD1)]
	public static CalculatorResult AriesKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Aries;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TaurusKetuPD1)]
	public static CalculatorResult TaurusKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Taurus;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GeminiKetuPD1)]
	public static CalculatorResult GeminiKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Gemini;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CancerKetuPD1)]
	public static CalculatorResult CancerKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Cancer;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LeoKetuPD1)]
	public static CalculatorResult LeoKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Leo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VirgoKetuPD1)]
	public static CalculatorResult VirgoKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Virgo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LibraKetuPD1)]
	public static CalculatorResult LibraKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Libra;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ScorpioKetuPD1)]
	public static CalculatorResult ScorpioKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Scorpio;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SagittariusKetuPD1)]
	public static CalculatorResult SagittariusKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Sagittarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CapricornKetuPD1)]
	public static CalculatorResult CapricornKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Capricorn;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AquariusKetuPD1)]
	public static CalculatorResult AquariusKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Aquarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.PiscesKetuPD1)]
	public static CalculatorResult PiscesKetuPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Ketu, person.BirthTime).GetSignName() == ZodiacName.Pisces;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AriesVenusPD1)]
	public static CalculatorResult AriesVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Aries;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.TaurusVenusPD1)]
	public static CalculatorResult TaurusVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Taurus;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.GeminiVenusPD1)]
	public static CalculatorResult GeminiVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Gemini;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CancerVenusPD1)]
	public static CalculatorResult CancerVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Cancer;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LeoVenusPD1)]
	public static CalculatorResult LeoVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Leo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VirgoVenusPD1)]
	public static CalculatorResult VirgoVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Virgo;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LibraVenusPD1)]
	public static CalculatorResult LibraVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Libra;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ScorpioVenusPD1)]
	public static CalculatorResult ScorpioVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Scorpio;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SagittariusVenusPD1)]
	public static CalculatorResult SagittariusVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Sagittarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.CapricornVenusPD1)]
	public static CalculatorResult CapricornVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Capricorn;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.AquariusVenusPD1)]
	public static CalculatorResult AquariusVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Aquarius;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.PiscesVenusPD1)]
	public static CalculatorResult PiscesVenusPD1(Time time, Person person)
	{
		bool num = Calculate.PlanetZodiacSign(PlanetName.Venus, person.BirthTime).GetSignName() == ZodiacName.Pisces;
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunSunPD2)]
	public static CalculatorResult SunSunPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Sun;
		bool flag = dasas.PD2 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunMoonPD2)]
	public static CalculatorResult SunMoonPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Sun;
		bool flag = dasas.PD2 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunMarsPD2)]
	public static CalculatorResult SunMarsPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Sun;
		bool flag = dasas.PD2 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunRahuPD2)]
	public static CalculatorResult SunRahuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Sun;
		bool flag = dasas.PD2 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunJupiterPD2)]
	public static CalculatorResult SunJupiterPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Sun;
		bool flag = dasas.PD2 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunSaturnPD2)]
	public static CalculatorResult SunSaturnPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Sun;
		bool flag = dasas.PD2 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunMercuryPD2)]
	public static CalculatorResult SunMercuryPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Sun;
		bool flag = dasas.PD2 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunKetuPD2)]
	public static CalculatorResult SunKetuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Sun;
		bool flag = dasas.PD2 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunVenusPD2)]
	public static CalculatorResult SunVenusPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Sun;
		bool flag = dasas.PD2 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonSunPD2)]
	public static CalculatorResult MoonSunPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Moon;
		bool flag = dasas.PD2 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonMoonPD2)]
	public static CalculatorResult MoonMoonPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Moon;
		bool flag = dasas.PD2 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonMarsPD2)]
	public static CalculatorResult MoonMarsPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Moon;
		bool flag = dasas.PD2 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonRahuPD2)]
	public static CalculatorResult MoonRahuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Moon;
		bool flag = dasas.PD2 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonJupiterPD2)]
	public static CalculatorResult MoonJupiterPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Moon;
		bool flag = dasas.PD2 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonSaturnPD2)]
	public static CalculatorResult MoonSaturnPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Moon;
		bool flag = dasas.PD2 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonMercuryPD2)]
	public static CalculatorResult MoonMercuryPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Moon;
		bool flag = dasas.PD2 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonKetuPD2)]
	public static CalculatorResult MoonKetuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Moon;
		bool flag = dasas.PD2 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MoonVenusPD2)]
	public static CalculatorResult MoonVenusPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Moon;
		bool flag = dasas.PD2 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsSunPD2)]
	public static CalculatorResult MarsSunPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mars;
		bool flag = dasas.PD2 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsMoonPD2)]
	public static CalculatorResult MarsMoonPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mars;
		bool flag = dasas.PD2 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsMarsPD2)]
	public static CalculatorResult MarsMarsPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mars;
		bool flag = dasas.PD2 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsRahuPD2)]
	public static CalculatorResult MarsRahuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mars;
		bool flag = dasas.PD2 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsJupiterPD2)]
	public static CalculatorResult MarsJupiterPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mars;
		bool flag = dasas.PD2 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsSaturnPD2)]
	public static CalculatorResult MarsSaturnPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mars;
		bool flag = dasas.PD2 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsMercuryPD2)]
	public static CalculatorResult MarsMercuryPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mars;
		bool flag = dasas.PD2 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsKetuPD2)]
	public static CalculatorResult MarsKetuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mars;
		bool flag = dasas.PD2 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MarsVenusPD2)]
	public static CalculatorResult MarsVenusPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mars;
		bool flag = dasas.PD2 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.RahuSunPD2)]
	public static CalculatorResult RahuSunPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Rahu;
		bool flag = dasas.PD2 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.RahuMoonPD2)]
	public static CalculatorResult RahuMoonPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Rahu;
		bool flag = dasas.PD2 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.RahuMarsPD2)]
	public static CalculatorResult RahuMarsPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Rahu;
		bool flag = dasas.PD2 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.RahuRahuPD2)]
	public static CalculatorResult RahuRahuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Rahu;
		bool flag = dasas.PD2 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.RahuJupiterPD2)]
	public static CalculatorResult RahuJupiterPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Rahu;
		bool flag = dasas.PD2 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.RahuSaturnPD2)]
	public static CalculatorResult RahuSaturnPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Rahu;
		bool flag = dasas.PD2 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.RahuMercuryPD2)]
	public static CalculatorResult RahuMercuryPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Rahu;
		bool flag = dasas.PD2 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.RahuKetuPD2)]
	public static CalculatorResult RahuKetuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Rahu;
		bool flag = dasas.PD2 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.RahuVenusPD2)]
	public static CalculatorResult RahuVenusPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Rahu;
		bool flag = dasas.PD2 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterSunPD2)]
	public static CalculatorResult JupiterSunPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Jupiter;
		bool flag = dasas.PD2 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterMoonPD2)]
	public static CalculatorResult JupiterMoonPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Jupiter;
		bool flag = dasas.PD2 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterMarsPD2)]
	public static CalculatorResult JupiterMarsPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Jupiter;
		bool flag = dasas.PD2 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterRahuPD2)]
	public static CalculatorResult JupiterRahuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Jupiter;
		bool flag = dasas.PD2 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterJupiterPD2)]
	public static CalculatorResult JupiterJupiterPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Jupiter;
		bool flag = dasas.PD2 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterSaturnPD2)]
	public static CalculatorResult JupiterSaturnPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Jupiter;
		bool flag = dasas.PD2 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterMercuryPD2)]
	public static CalculatorResult JupiterMercuryPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Jupiter;
		bool flag = dasas.PD2 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterKetuPD2)]
	public static CalculatorResult JupiterKetuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Jupiter;
		bool flag = dasas.PD2 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.JupiterVenusPD2)]
	public static CalculatorResult JupiterVenusPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Jupiter;
		bool flag = dasas.PD2 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnSunPD2)]
	public static CalculatorResult SaturnSunPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Saturn;
		bool flag = dasas.PD2 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnMoonPD2)]
	public static CalculatorResult SaturnMoonPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Saturn;
		bool flag = dasas.PD2 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnMarsPD2)]
	public static CalculatorResult SaturnMarsPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Saturn;
		bool flag = dasas.PD2 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnRahuPD2)]
	public static CalculatorResult SaturnRahuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Saturn;
		bool flag = dasas.PD2 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnJupiterPD2)]
	public static CalculatorResult SaturnJupiterPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Saturn;
		bool flag = dasas.PD2 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnSaturnPD2)]
	public static CalculatorResult SaturnSaturnPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Saturn;
		bool flag = dasas.PD2 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnMercuryPD2)]
	public static CalculatorResult SaturnMercuryPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Saturn;
		bool flag = dasas.PD2 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnKetuPD2)]
	public static CalculatorResult SaturnKetuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Saturn;
		bool flag = dasas.PD2 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SaturnVenusPD2)]
	public static CalculatorResult SaturnVenusPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Saturn;
		bool flag = dasas.PD2 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercurySunPD2)]
	public static CalculatorResult MercurySunPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mercury;
		bool flag = dasas.PD2 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercuryMoonPD2)]
	public static CalculatorResult MercuryMoonPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mercury;
		bool flag = dasas.PD2 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercuryMarsPD2)]
	public static CalculatorResult MercuryMarsPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mercury;
		bool flag = dasas.PD2 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercuryRahuPD2)]
	public static CalculatorResult MercuryRahuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mercury;
		bool flag = dasas.PD2 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercuryJupiterPD2)]
	public static CalculatorResult MercuryJupiterPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mercury;
		bool flag = dasas.PD2 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercurySaturnPD2)]
	public static CalculatorResult MercurySaturnPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mercury;
		bool flag = dasas.PD2 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercuryMercuryPD2)]
	public static CalculatorResult MercuryMercuryPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mercury;
		bool flag = dasas.PD2 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercuryKetuPD2)]
	public static CalculatorResult MercuryKetuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mercury;
		bool flag = dasas.PD2 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.MercuryVenusPD2)]
	public static CalculatorResult MercuryVenusPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Mercury;
		bool flag = dasas.PD2 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.KetuSunPD2)]
	public static CalculatorResult KetuSunPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Ketu;
		bool flag = dasas.PD2 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.KetuMoonPD2)]
	public static CalculatorResult KetuMoonPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Ketu;
		bool flag = dasas.PD2 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.KetuMarsPD2)]
	public static CalculatorResult KetuMarsPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Ketu;
		bool flag = dasas.PD2 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.KetuRahuPD2)]
	public static CalculatorResult KetuRahuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Ketu;
		bool flag = dasas.PD2 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.KetuJupiterPD2)]
	public static CalculatorResult KetuJupiterPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Ketu;
		bool flag = dasas.PD2 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.KetuSaturnPD2)]
	public static CalculatorResult KetuSaturnPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Ketu;
		bool flag = dasas.PD2 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.KetuMercuryPD2)]
	public static CalculatorResult KetuMercuryPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Ketu;
		bool flag = dasas.PD2 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.KetuKetuPD2)]
	public static CalculatorResult KetuKetuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Ketu;
		bool flag = dasas.PD2 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.KetuVenusPD2)]
	public static CalculatorResult KetuVenusPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Ketu;
		bool flag = dasas.PD2 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusSunPD2)]
	public static CalculatorResult VenusSunPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Venus;
		bool flag = dasas.PD2 == PlanetName.Sun;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusMoonPD2)]
	public static CalculatorResult VenusMoonPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Venus;
		bool flag = dasas.PD2 == PlanetName.Moon;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusMarsPD2)]
	public static CalculatorResult VenusMarsPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Venus;
		bool flag = dasas.PD2 == PlanetName.Mars;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusRahuPD2)]
	public static CalculatorResult VenusRahuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Venus;
		bool flag = dasas.PD2 == PlanetName.Rahu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusJupiterPD2)]
	public static CalculatorResult VenusJupiterPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Venus;
		bool flag = dasas.PD2 == PlanetName.Jupiter;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusSaturnPD2)]
	public static CalculatorResult VenusSaturnPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Venus;
		bool flag = dasas.PD2 == PlanetName.Saturn;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusMercuryPD2)]
	public static CalculatorResult VenusMercuryPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Venus;
		bool flag = dasas.PD2 == PlanetName.Mercury;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusKetuPD2)]
	public static CalculatorResult VenusKetuPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Venus;
		bool flag = dasas.PD2 == PlanetName.Ketu;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.VenusVenusPD2)]
	public static CalculatorResult VenusVenusPD2(Time time, Person person)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD1 == PlanetName.Venus;
		bool flag = dasas.PD2 == PlanetName.Venus;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.SunSunPD3)]
	public static CalculatorResult SunSunPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Sun, PlanetName.Sun);
	}

	[EventCalculator(EventName.MoonSunPD3)]
	public static CalculatorResult MoonSunPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Moon, PlanetName.Sun);
	}

	[EventCalculator(EventName.MarsSunPD3)]
	public static CalculatorResult MarsSunPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mars, PlanetName.Sun);
	}

	[EventCalculator(EventName.RahuSunPD3)]
	public static CalculatorResult RahuSunPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Rahu, PlanetName.Sun);
	}

	[EventCalculator(EventName.JupiterSunPD3)]
	public static CalculatorResult JupiterSunPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Jupiter, PlanetName.Sun);
	}

	[EventCalculator(EventName.SaturnSunPD3)]
	public static CalculatorResult SaturnSunPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Saturn, PlanetName.Sun);
	}

	[EventCalculator(EventName.MercurySunPD3)]
	public static CalculatorResult MercurySunPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mercury, PlanetName.Sun);
	}

	[EventCalculator(EventName.KetuSunPD3)]
	public static CalculatorResult KetuSunPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Ketu, PlanetName.Sun);
	}

	[EventCalculator(EventName.VenusSunPD3)]
	public static CalculatorResult VenusSunPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Venus, PlanetName.Sun);
	}

	[EventCalculator(EventName.SunMoonPD3)]
	public static CalculatorResult SunMoonPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Sun, PlanetName.Moon);
	}

	[EventCalculator(EventName.MoonMoonPD3)]
	public static CalculatorResult MoonMoonPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Moon, PlanetName.Moon);
	}

	[EventCalculator(EventName.MarsMoonPD3)]
	public static CalculatorResult MarsMoonPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mars, PlanetName.Moon);
	}

	[EventCalculator(EventName.RahuMoonPD3)]
	public static CalculatorResult RahuMoonPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Rahu, PlanetName.Moon);
	}

	[EventCalculator(EventName.JupiterMoonPD3)]
	public static CalculatorResult JupiterMoonPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Jupiter, PlanetName.Moon);
	}

	[EventCalculator(EventName.SaturnMoonPD3)]
	public static CalculatorResult SaturnMoonPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Saturn, PlanetName.Moon);
	}

	[EventCalculator(EventName.MercuryMoonPD3)]
	public static CalculatorResult MercuryMoonPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mercury, PlanetName.Moon);
	}

	[EventCalculator(EventName.KetuMoonPD3)]
	public static CalculatorResult KetuMoonPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Ketu, PlanetName.Moon);
	}

	[EventCalculator(EventName.VenusMoonPD3)]
	public static CalculatorResult VenusMoonPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Venus, PlanetName.Moon);
	}

	[EventCalculator(EventName.SunMarsPD3)]
	public static CalculatorResult SunMarsPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Sun, PlanetName.Mars);
	}

	[EventCalculator(EventName.MoonMarsPD3)]
	public static CalculatorResult MoonMarsPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Moon, PlanetName.Mars);
	}

	[EventCalculator(EventName.MarsMarsPD3)]
	public static CalculatorResult MarsMarsPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mars, PlanetName.Mars);
	}

	[EventCalculator(EventName.RahuMarsPD3)]
	public static CalculatorResult RahuMarsPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Rahu, PlanetName.Mars);
	}

	[EventCalculator(EventName.JupiterMarsPD3)]
	public static CalculatorResult JupiterMarsPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Jupiter, PlanetName.Mars);
	}

	[EventCalculator(EventName.SaturnMarsPD3)]
	public static CalculatorResult SaturnMarsPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Saturn, PlanetName.Mars);
	}

	[EventCalculator(EventName.MercuryMarsPD3)]
	public static CalculatorResult MercuryMarsPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mercury, PlanetName.Mars);
	}

	[EventCalculator(EventName.KetuMarsPD3)]
	public static CalculatorResult KetuMarsPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Ketu, PlanetName.Mars);
	}

	[EventCalculator(EventName.VenusMarsPD3)]
	public static CalculatorResult VenusMarsPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Venus, PlanetName.Mars);
	}

	[EventCalculator(EventName.SunRahuPD3)]
	public static CalculatorResult SunRahuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Sun, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MoonRahuPD3)]
	public static CalculatorResult MoonRahuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Moon, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MarsRahuPD3)]
	public static CalculatorResult MarsRahuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mars, PlanetName.Rahu);
	}

	[EventCalculator(EventName.RahuRahuPD3)]
	public static CalculatorResult RahuRahuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Rahu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.JupiterRahuPD3)]
	public static CalculatorResult JupiterRahuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Jupiter, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SaturnRahuPD3)]
	public static CalculatorResult SaturnRahuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Saturn, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MercuryRahuPD3)]
	public static CalculatorResult MercuryRahuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mercury, PlanetName.Rahu);
	}

	[EventCalculator(EventName.KetuRahuPD3)]
	public static CalculatorResult KetuRahuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Ketu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.VenusRahuPD3)]
	public static CalculatorResult VenusRahuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Venus, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SunJupiterPD3)]
	public static CalculatorResult SunJupiterPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Sun, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MoonJupiterPD3)]
	public static CalculatorResult MoonJupiterPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Moon, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MarsJupiterPD3)]
	public static CalculatorResult MarsJupiterPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mars, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.RahuJupiterPD3)]
	public static CalculatorResult RahuJupiterPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Rahu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.JupiterJupiterPD3)]
	public static CalculatorResult JupiterJupiterPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Jupiter, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SaturnJupiterPD3)]
	public static CalculatorResult SaturnJupiterPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Saturn, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MercuryJupiterPD3)]
	public static CalculatorResult MercuryJupiterPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mercury, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.KetuJupiterPD3)]
	public static CalculatorResult KetuJupiterPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Ketu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.VenusJupiterPD3)]
	public static CalculatorResult VenusJupiterPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Venus, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SunSaturnPD3)]
	public static CalculatorResult SunSaturnPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Sun, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MoonSaturnPD3)]
	public static CalculatorResult MoonSaturnPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Moon, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MarsSaturnPD3)]
	public static CalculatorResult MarsSaturnPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mars, PlanetName.Saturn);
	}

	[EventCalculator(EventName.RahuSaturnPD3)]
	public static CalculatorResult RahuSaturnPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Rahu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.JupiterSaturnPD3)]
	public static CalculatorResult JupiterSaturnPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Jupiter, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SaturnSaturnPD3)]
	public static CalculatorResult SaturnSaturnPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Saturn, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MercurySaturnPD3)]
	public static CalculatorResult MercurySaturnPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mercury, PlanetName.Saturn);
	}

	[EventCalculator(EventName.KetuSaturnPD3)]
	public static CalculatorResult KetuSaturnPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Ketu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.VenusSaturnPD3)]
	public static CalculatorResult VenusSaturnPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Venus, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SunMercuryPD3)]
	public static CalculatorResult SunMercuryPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Sun, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MoonMercuryPD3)]
	public static CalculatorResult MoonMercuryPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Moon, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MarsMercuryPD3)]
	public static CalculatorResult MarsMercuryPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mars, PlanetName.Mercury);
	}

	[EventCalculator(EventName.RahuMercuryPD3)]
	public static CalculatorResult RahuMercuryPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Rahu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.JupiterMercuryPD3)]
	public static CalculatorResult JupiterMercuryPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Jupiter, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SaturnMercuryPD3)]
	public static CalculatorResult SaturnMercuryPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Saturn, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MercuryMercuryPD3)]
	public static CalculatorResult MercuryMercuryPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mercury, PlanetName.Mercury);
	}

	[EventCalculator(EventName.KetuMercuryPD3)]
	public static CalculatorResult KetuMercuryPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Ketu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.VenusMercuryPD3)]
	public static CalculatorResult VenusMercuryPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Venus, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SunKetuPD3)]
	public static CalculatorResult SunKetuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Sun, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MoonKetuPD3)]
	public static CalculatorResult MoonKetuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Moon, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MarsKetuPD3)]
	public static CalculatorResult MarsKetuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mars, PlanetName.Ketu);
	}

	[EventCalculator(EventName.RahuKetuPD3)]
	public static CalculatorResult RahuKetuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Rahu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.JupiterKetuPD3)]
	public static CalculatorResult JupiterKetuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Jupiter, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SaturnKetuPD3)]
	public static CalculatorResult SaturnKetuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Saturn, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MercuryKetuPD3)]
	public static CalculatorResult MercuryKetuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mercury, PlanetName.Ketu);
	}

	[EventCalculator(EventName.KetuKetuPD3)]
	public static CalculatorResult KetuKetuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Ketu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.VenusKetuPD3)]
	public static CalculatorResult VenusKetuPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Venus, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SunVenusPD3)]
	public static CalculatorResult SunVenusPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Sun, PlanetName.Venus);
	}

	[EventCalculator(EventName.MoonVenusPD3)]
	public static CalculatorResult MoonVenusPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Moon, PlanetName.Venus);
	}

	[EventCalculator(EventName.MarsVenusPD3)]
	public static CalculatorResult MarsVenusPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mars, PlanetName.Venus);
	}

	[EventCalculator(EventName.RahuVenusPD3)]
	public static CalculatorResult RahuVenusPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Rahu, PlanetName.Venus);
	}

	[EventCalculator(EventName.JupiterVenusPD3)]
	public static CalculatorResult JupiterVenusPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Jupiter, PlanetName.Venus);
	}

	[EventCalculator(EventName.SaturnVenusPD3)]
	public static CalculatorResult SaturnVenusPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Saturn, PlanetName.Venus);
	}

	[EventCalculator(EventName.MercuryVenusPD3)]
	public static CalculatorResult MercuryVenusPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Mercury, PlanetName.Venus);
	}

	[EventCalculator(EventName.KetuVenusPD3)]
	public static CalculatorResult KetuVenusPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Ketu, PlanetName.Venus);
	}

	[EventCalculator(EventName.VenusVenusPD3)]
	public static CalculatorResult VenusVenusPD3(Time time, Person person)
	{
		return PlanetPD2PlanetPD3(time, person, PlanetName.Venus, PlanetName.Venus);
	}

	[EventCalculator(EventName.SunSunPD4)]
	public static CalculatorResult SunSunPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Sun, PlanetName.Sun);
	}

	[EventCalculator(EventName.MoonSunPD4)]
	public static CalculatorResult MoonSunPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Moon, PlanetName.Sun);
	}

	[EventCalculator(EventName.MarsSunPD4)]
	public static CalculatorResult MarsSunPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mars, PlanetName.Sun);
	}

	[EventCalculator(EventName.RahuSunPD4)]
	public static CalculatorResult RahuSunPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Rahu, PlanetName.Sun);
	}

	[EventCalculator(EventName.JupiterSunPD4)]
	public static CalculatorResult JupiterSunPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Jupiter, PlanetName.Sun);
	}

	[EventCalculator(EventName.SaturnSunPD4)]
	public static CalculatorResult SaturnSunPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Saturn, PlanetName.Sun);
	}

	[EventCalculator(EventName.MercurySunPD4)]
	public static CalculatorResult MercurySunPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mercury, PlanetName.Sun);
	}

	[EventCalculator(EventName.KetuSunPD4)]
	public static CalculatorResult KetuSunPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Ketu, PlanetName.Sun);
	}

	[EventCalculator(EventName.VenusSunPD4)]
	public static CalculatorResult VenusSunPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Venus, PlanetName.Sun);
	}

	[EventCalculator(EventName.SunMoonPD4)]
	public static CalculatorResult SunMoonPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Sun, PlanetName.Moon);
	}

	[EventCalculator(EventName.MoonMoonPD4)]
	public static CalculatorResult MoonMoonPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Moon, PlanetName.Moon);
	}

	[EventCalculator(EventName.MarsMoonPD4)]
	public static CalculatorResult MarsMoonPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mars, PlanetName.Moon);
	}

	[EventCalculator(EventName.RahuMoonPD4)]
	public static CalculatorResult RahuMoonPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Rahu, PlanetName.Moon);
	}

	[EventCalculator(EventName.JupiterMoonPD4)]
	public static CalculatorResult JupiterMoonPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Jupiter, PlanetName.Moon);
	}

	[EventCalculator(EventName.SaturnMoonPD4)]
	public static CalculatorResult SaturnMoonPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Saturn, PlanetName.Moon);
	}

	[EventCalculator(EventName.MercuryMoonPD4)]
	public static CalculatorResult MercuryMoonPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mercury, PlanetName.Moon);
	}

	[EventCalculator(EventName.KetuMoonPD4)]
	public static CalculatorResult KetuMoonPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Ketu, PlanetName.Moon);
	}

	[EventCalculator(EventName.VenusMoonPD4)]
	public static CalculatorResult VenusMoonPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Venus, PlanetName.Moon);
	}

	[EventCalculator(EventName.SunMarsPD4)]
	public static CalculatorResult SunMarsPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Sun, PlanetName.Mars);
	}

	[EventCalculator(EventName.MoonMarsPD4)]
	public static CalculatorResult MoonMarsPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Moon, PlanetName.Mars);
	}

	[EventCalculator(EventName.MarsMarsPD4)]
	public static CalculatorResult MarsMarsPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mars, PlanetName.Mars);
	}

	[EventCalculator(EventName.RahuMarsPD4)]
	public static CalculatorResult RahuMarsPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Rahu, PlanetName.Mars);
	}

	[EventCalculator(EventName.JupiterMarsPD4)]
	public static CalculatorResult JupiterMarsPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Jupiter, PlanetName.Mars);
	}

	[EventCalculator(EventName.SaturnMarsPD4)]
	public static CalculatorResult SaturnMarsPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Saturn, PlanetName.Mars);
	}

	[EventCalculator(EventName.MercuryMarsPD4)]
	public static CalculatorResult MercuryMarsPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mercury, PlanetName.Mars);
	}

	[EventCalculator(EventName.KetuMarsPD4)]
	public static CalculatorResult KetuMarsPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Ketu, PlanetName.Mars);
	}

	[EventCalculator(EventName.VenusMarsPD4)]
	public static CalculatorResult VenusMarsPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Venus, PlanetName.Mars);
	}

	[EventCalculator(EventName.SunRahuPD4)]
	public static CalculatorResult SunRahuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Sun, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MoonRahuPD4)]
	public static CalculatorResult MoonRahuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Moon, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MarsRahuPD4)]
	public static CalculatorResult MarsRahuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mars, PlanetName.Rahu);
	}

	[EventCalculator(EventName.RahuRahuPD4)]
	public static CalculatorResult RahuRahuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Rahu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.JupiterRahuPD4)]
	public static CalculatorResult JupiterRahuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Jupiter, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SaturnRahuPD4)]
	public static CalculatorResult SaturnRahuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Saturn, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MercuryRahuPD4)]
	public static CalculatorResult MercuryRahuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mercury, PlanetName.Rahu);
	}

	[EventCalculator(EventName.KetuRahuPD4)]
	public static CalculatorResult KetuRahuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Ketu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.VenusRahuPD4)]
	public static CalculatorResult VenusRahuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Venus, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SunJupiterPD4)]
	public static CalculatorResult SunJupiterPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Sun, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MoonJupiterPD4)]
	public static CalculatorResult MoonJupiterPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Moon, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MarsJupiterPD4)]
	public static CalculatorResult MarsJupiterPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mars, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.RahuJupiterPD4)]
	public static CalculatorResult RahuJupiterPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Rahu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.JupiterJupiterPD4)]
	public static CalculatorResult JupiterJupiterPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Jupiter, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SaturnJupiterPD4)]
	public static CalculatorResult SaturnJupiterPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Saturn, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MercuryJupiterPD4)]
	public static CalculatorResult MercuryJupiterPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mercury, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.KetuJupiterPD4)]
	public static CalculatorResult KetuJupiterPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Ketu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.VenusJupiterPD4)]
	public static CalculatorResult VenusJupiterPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Venus, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SunSaturnPD4)]
	public static CalculatorResult SunSaturnPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Sun, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MoonSaturnPD4)]
	public static CalculatorResult MoonSaturnPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Moon, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MarsSaturnPD4)]
	public static CalculatorResult MarsSaturnPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mars, PlanetName.Saturn);
	}

	[EventCalculator(EventName.RahuSaturnPD4)]
	public static CalculatorResult RahuSaturnPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Rahu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.JupiterSaturnPD4)]
	public static CalculatorResult JupiterSaturnPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Jupiter, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SaturnSaturnPD4)]
	public static CalculatorResult SaturnSaturnPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Saturn, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MercurySaturnPD4)]
	public static CalculatorResult MercurySaturnPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mercury, PlanetName.Saturn);
	}

	[EventCalculator(EventName.KetuSaturnPD4)]
	public static CalculatorResult KetuSaturnPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Ketu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.VenusSaturnPD4)]
	public static CalculatorResult VenusSaturnPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Venus, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SunMercuryPD4)]
	public static CalculatorResult SunMercuryPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Sun, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MoonMercuryPD4)]
	public static CalculatorResult MoonMercuryPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Moon, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MarsMercuryPD4)]
	public static CalculatorResult MarsMercuryPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mars, PlanetName.Mercury);
	}

	[EventCalculator(EventName.RahuMercuryPD4)]
	public static CalculatorResult RahuMercuryPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Rahu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.JupiterMercuryPD4)]
	public static CalculatorResult JupiterMercuryPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Jupiter, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SaturnMercuryPD4)]
	public static CalculatorResult SaturnMercuryPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Saturn, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MercuryMercuryPD4)]
	public static CalculatorResult MercuryMercuryPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mercury, PlanetName.Mercury);
	}

	[EventCalculator(EventName.KetuMercuryPD4)]
	public static CalculatorResult KetuMercuryPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Ketu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.VenusMercuryPD4)]
	public static CalculatorResult VenusMercuryPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Venus, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SunKetuPD4)]
	public static CalculatorResult SunKetuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Sun, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MoonKetuPD4)]
	public static CalculatorResult MoonKetuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Moon, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MarsKetuPD4)]
	public static CalculatorResult MarsKetuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mars, PlanetName.Ketu);
	}

	[EventCalculator(EventName.RahuKetuPD4)]
	public static CalculatorResult RahuKetuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Rahu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.JupiterKetuPD4)]
	public static CalculatorResult JupiterKetuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Jupiter, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SaturnKetuPD4)]
	public static CalculatorResult SaturnKetuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Saturn, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MercuryKetuPD4)]
	public static CalculatorResult MercuryKetuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mercury, PlanetName.Ketu);
	}

	[EventCalculator(EventName.KetuKetuPD4)]
	public static CalculatorResult KetuKetuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Ketu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.VenusKetuPD4)]
	public static CalculatorResult VenusKetuPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Venus, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SunVenusPD4)]
	public static CalculatorResult SunVenusPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Sun, PlanetName.Venus);
	}

	[EventCalculator(EventName.MoonVenusPD4)]
	public static CalculatorResult MoonVenusPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Moon, PlanetName.Venus);
	}

	[EventCalculator(EventName.MarsVenusPD4)]
	public static CalculatorResult MarsVenusPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mars, PlanetName.Venus);
	}

	[EventCalculator(EventName.RahuVenusPD4)]
	public static CalculatorResult RahuVenusPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Rahu, PlanetName.Venus);
	}

	[EventCalculator(EventName.JupiterVenusPD4)]
	public static CalculatorResult JupiterVenusPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Jupiter, PlanetName.Venus);
	}

	[EventCalculator(EventName.SaturnVenusPD4)]
	public static CalculatorResult SaturnVenusPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Saturn, PlanetName.Venus);
	}

	[EventCalculator(EventName.MercuryVenusPD4)]
	public static CalculatorResult MercuryVenusPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Mercury, PlanetName.Venus);
	}

	[EventCalculator(EventName.KetuVenusPD4)]
	public static CalculatorResult KetuVenusPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Ketu, PlanetName.Venus);
	}

	[EventCalculator(EventName.VenusVenusPD4)]
	public static CalculatorResult VenusVenusPD4(Time time, Person person)
	{
		return PlanetPD3PlanetPD4(time, person, PlanetName.Venus, PlanetName.Venus);
	}

	[EventCalculator(EventName.SunSunPD5)]
	public static CalculatorResult SunSunPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Sun, PlanetName.Sun);
	}

	[EventCalculator(EventName.MoonSunPD5)]
	public static CalculatorResult MoonSunPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Moon, PlanetName.Sun);
	}

	[EventCalculator(EventName.MarsSunPD5)]
	public static CalculatorResult MarsSunPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mars, PlanetName.Sun);
	}

	[EventCalculator(EventName.RahuSunPD5)]
	public static CalculatorResult RahuSunPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Rahu, PlanetName.Sun);
	}

	[EventCalculator(EventName.JupiterSunPD5)]
	public static CalculatorResult JupiterSunPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Jupiter, PlanetName.Sun);
	}

	[EventCalculator(EventName.SaturnSunPD5)]
	public static CalculatorResult SaturnSunPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Saturn, PlanetName.Sun);
	}

	[EventCalculator(EventName.MercurySunPD5)]
	public static CalculatorResult MercurySunPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mercury, PlanetName.Sun);
	}

	[EventCalculator(EventName.KetuSunPD5)]
	public static CalculatorResult KetuSunPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Ketu, PlanetName.Sun);
	}

	[EventCalculator(EventName.VenusSunPD5)]
	public static CalculatorResult VenusSunPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Venus, PlanetName.Sun);
	}

	[EventCalculator(EventName.SunMoonPD5)]
	public static CalculatorResult SunMoonPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Sun, PlanetName.Moon);
	}

	[EventCalculator(EventName.MoonMoonPD5)]
	public static CalculatorResult MoonMoonPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Moon, PlanetName.Moon);
	}

	[EventCalculator(EventName.MarsMoonPD5)]
	public static CalculatorResult MarsMoonPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mars, PlanetName.Moon);
	}

	[EventCalculator(EventName.RahuMoonPD5)]
	public static CalculatorResult RahuMoonPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Rahu, PlanetName.Moon);
	}

	[EventCalculator(EventName.JupiterMoonPD5)]
	public static CalculatorResult JupiterMoonPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Jupiter, PlanetName.Moon);
	}

	[EventCalculator(EventName.SaturnMoonPD5)]
	public static CalculatorResult SaturnMoonPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Saturn, PlanetName.Moon);
	}

	[EventCalculator(EventName.MercuryMoonPD5)]
	public static CalculatorResult MercuryMoonPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mercury, PlanetName.Moon);
	}

	[EventCalculator(EventName.KetuMoonPD5)]
	public static CalculatorResult KetuMoonPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Ketu, PlanetName.Moon);
	}

	[EventCalculator(EventName.VenusMoonPD5)]
	public static CalculatorResult VenusMoonPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Venus, PlanetName.Moon);
	}

	[EventCalculator(EventName.SunMarsPD5)]
	public static CalculatorResult SunMarsPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Sun, PlanetName.Mars);
	}

	[EventCalculator(EventName.MoonMarsPD5)]
	public static CalculatorResult MoonMarsPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Moon, PlanetName.Mars);
	}

	[EventCalculator(EventName.MarsMarsPD5)]
	public static CalculatorResult MarsMarsPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mars, PlanetName.Mars);
	}

	[EventCalculator(EventName.RahuMarsPD5)]
	public static CalculatorResult RahuMarsPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Rahu, PlanetName.Mars);
	}

	[EventCalculator(EventName.JupiterMarsPD5)]
	public static CalculatorResult JupiterMarsPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Jupiter, PlanetName.Mars);
	}

	[EventCalculator(EventName.SaturnMarsPD5)]
	public static CalculatorResult SaturnMarsPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Saturn, PlanetName.Mars);
	}

	[EventCalculator(EventName.MercuryMarsPD5)]
	public static CalculatorResult MercuryMarsPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mercury, PlanetName.Mars);
	}

	[EventCalculator(EventName.KetuMarsPD5)]
	public static CalculatorResult KetuMarsPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Ketu, PlanetName.Mars);
	}

	[EventCalculator(EventName.VenusMarsPD5)]
	public static CalculatorResult VenusMarsPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Venus, PlanetName.Mars);
	}

	[EventCalculator(EventName.SunRahuPD5)]
	public static CalculatorResult SunRahuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Sun, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MoonRahuPD5)]
	public static CalculatorResult MoonRahuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Moon, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MarsRahuPD5)]
	public static CalculatorResult MarsRahuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mars, PlanetName.Rahu);
	}

	[EventCalculator(EventName.RahuRahuPD5)]
	public static CalculatorResult RahuRahuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Rahu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.JupiterRahuPD5)]
	public static CalculatorResult JupiterRahuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Jupiter, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SaturnRahuPD5)]
	public static CalculatorResult SaturnRahuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Saturn, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MercuryRahuPD5)]
	public static CalculatorResult MercuryRahuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mercury, PlanetName.Rahu);
	}

	[EventCalculator(EventName.KetuRahuPD5)]
	public static CalculatorResult KetuRahuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Ketu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.VenusRahuPD5)]
	public static CalculatorResult VenusRahuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Venus, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SunJupiterPD5)]
	public static CalculatorResult SunJupiterPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Sun, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MoonJupiterPD5)]
	public static CalculatorResult MoonJupiterPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Moon, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MarsJupiterPD5)]
	public static CalculatorResult MarsJupiterPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mars, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.RahuJupiterPD5)]
	public static CalculatorResult RahuJupiterPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Rahu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.JupiterJupiterPD5)]
	public static CalculatorResult JupiterJupiterPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Jupiter, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SaturnJupiterPD5)]
	public static CalculatorResult SaturnJupiterPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Saturn, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MercuryJupiterPD5)]
	public static CalculatorResult MercuryJupiterPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mercury, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.KetuJupiterPD5)]
	public static CalculatorResult KetuJupiterPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Ketu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.VenusJupiterPD5)]
	public static CalculatorResult VenusJupiterPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Venus, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SunSaturnPD5)]
	public static CalculatorResult SunSaturnPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Sun, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MoonSaturnPD5)]
	public static CalculatorResult MoonSaturnPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Moon, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MarsSaturnPD5)]
	public static CalculatorResult MarsSaturnPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mars, PlanetName.Saturn);
	}

	[EventCalculator(EventName.RahuSaturnPD5)]
	public static CalculatorResult RahuSaturnPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Rahu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.JupiterSaturnPD5)]
	public static CalculatorResult JupiterSaturnPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Jupiter, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SaturnSaturnPD5)]
	public static CalculatorResult SaturnSaturnPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Saturn, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MercurySaturnPD5)]
	public static CalculatorResult MercurySaturnPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mercury, PlanetName.Saturn);
	}

	[EventCalculator(EventName.KetuSaturnPD5)]
	public static CalculatorResult KetuSaturnPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Ketu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.VenusSaturnPD5)]
	public static CalculatorResult VenusSaturnPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Venus, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SunMercuryPD5)]
	public static CalculatorResult SunMercuryPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Sun, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MoonMercuryPD5)]
	public static CalculatorResult MoonMercuryPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Moon, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MarsMercuryPD5)]
	public static CalculatorResult MarsMercuryPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mars, PlanetName.Mercury);
	}

	[EventCalculator(EventName.RahuMercuryPD5)]
	public static CalculatorResult RahuMercuryPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Rahu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.JupiterMercuryPD5)]
	public static CalculatorResult JupiterMercuryPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Jupiter, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SaturnMercuryPD5)]
	public static CalculatorResult SaturnMercuryPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Saturn, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MercuryMercuryPD5)]
	public static CalculatorResult MercuryMercuryPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mercury, PlanetName.Mercury);
	}

	[EventCalculator(EventName.KetuMercuryPD5)]
	public static CalculatorResult KetuMercuryPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Ketu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.VenusMercuryPD5)]
	public static CalculatorResult VenusMercuryPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Venus, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SunKetuPD5)]
	public static CalculatorResult SunKetuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Sun, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MoonKetuPD5)]
	public static CalculatorResult MoonKetuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Moon, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MarsKetuPD5)]
	public static CalculatorResult MarsKetuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mars, PlanetName.Ketu);
	}

	[EventCalculator(EventName.RahuKetuPD5)]
	public static CalculatorResult RahuKetuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Rahu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.JupiterKetuPD5)]
	public static CalculatorResult JupiterKetuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Jupiter, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SaturnKetuPD5)]
	public static CalculatorResult SaturnKetuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Saturn, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MercuryKetuPD5)]
	public static CalculatorResult MercuryKetuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mercury, PlanetName.Ketu);
	}

	[EventCalculator(EventName.KetuKetuPD5)]
	public static CalculatorResult KetuKetuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Ketu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.VenusKetuPD5)]
	public static CalculatorResult VenusKetuPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Venus, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SunVenusPD5)]
	public static CalculatorResult SunVenusPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Sun, PlanetName.Venus);
	}

	[EventCalculator(EventName.MoonVenusPD5)]
	public static CalculatorResult MoonVenusPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Moon, PlanetName.Venus);
	}

	[EventCalculator(EventName.MarsVenusPD5)]
	public static CalculatorResult MarsVenusPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mars, PlanetName.Venus);
	}

	[EventCalculator(EventName.RahuVenusPD5)]
	public static CalculatorResult RahuVenusPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Rahu, PlanetName.Venus);
	}

	[EventCalculator(EventName.JupiterVenusPD5)]
	public static CalculatorResult JupiterVenusPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Jupiter, PlanetName.Venus);
	}

	[EventCalculator(EventName.SaturnVenusPD5)]
	public static CalculatorResult SaturnVenusPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Saturn, PlanetName.Venus);
	}

	[EventCalculator(EventName.MercuryVenusPD5)]
	public static CalculatorResult MercuryVenusPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Mercury, PlanetName.Venus);
	}

	[EventCalculator(EventName.KetuVenusPD5)]
	public static CalculatorResult KetuVenusPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Ketu, PlanetName.Venus);
	}

	[EventCalculator(EventName.VenusVenusPD5)]
	public static CalculatorResult VenusVenusPD5(Time time, Person person)
	{
		return PlanetPD4PlanetPD5(time, person, PlanetName.Venus, PlanetName.Venus);
	}

	[EventCalculator(EventName.SunSunPD6)]
	public static CalculatorResult SunSunPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Sun, PlanetName.Sun);
	}

	[EventCalculator(EventName.MoonSunPD6)]
	public static CalculatorResult MoonSunPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Moon, PlanetName.Sun);
	}

	[EventCalculator(EventName.MarsSunPD6)]
	public static CalculatorResult MarsSunPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mars, PlanetName.Sun);
	}

	[EventCalculator(EventName.RahuSunPD6)]
	public static CalculatorResult RahuSunPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Rahu, PlanetName.Sun);
	}

	[EventCalculator(EventName.JupiterSunPD6)]
	public static CalculatorResult JupiterSunPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Jupiter, PlanetName.Sun);
	}

	[EventCalculator(EventName.SaturnSunPD6)]
	public static CalculatorResult SaturnSunPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Saturn, PlanetName.Sun);
	}

	[EventCalculator(EventName.MercurySunPD6)]
	public static CalculatorResult MercurySunPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mercury, PlanetName.Sun);
	}

	[EventCalculator(EventName.KetuSunPD6)]
	public static CalculatorResult KetuSunPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Ketu, PlanetName.Sun);
	}

	[EventCalculator(EventName.VenusSunPD6)]
	public static CalculatorResult VenusSunPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Venus, PlanetName.Sun);
	}

	[EventCalculator(EventName.SunMoonPD6)]
	public static CalculatorResult SunMoonPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Sun, PlanetName.Moon);
	}

	[EventCalculator(EventName.MoonMoonPD6)]
	public static CalculatorResult MoonMoonPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Moon, PlanetName.Moon);
	}

	[EventCalculator(EventName.MarsMoonPD6)]
	public static CalculatorResult MarsMoonPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mars, PlanetName.Moon);
	}

	[EventCalculator(EventName.RahuMoonPD6)]
	public static CalculatorResult RahuMoonPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Rahu, PlanetName.Moon);
	}

	[EventCalculator(EventName.JupiterMoonPD6)]
	public static CalculatorResult JupiterMoonPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Jupiter, PlanetName.Moon);
	}

	[EventCalculator(EventName.SaturnMoonPD6)]
	public static CalculatorResult SaturnMoonPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Saturn, PlanetName.Moon);
	}

	[EventCalculator(EventName.MercuryMoonPD6)]
	public static CalculatorResult MercuryMoonPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mercury, PlanetName.Moon);
	}

	[EventCalculator(EventName.KetuMoonPD6)]
	public static CalculatorResult KetuMoonPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Ketu, PlanetName.Moon);
	}

	[EventCalculator(EventName.VenusMoonPD6)]
	public static CalculatorResult VenusMoonPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Venus, PlanetName.Moon);
	}

	[EventCalculator(EventName.SunMarsPD6)]
	public static CalculatorResult SunMarsPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Sun, PlanetName.Mars);
	}

	[EventCalculator(EventName.MoonMarsPD6)]
	public static CalculatorResult MoonMarsPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Moon, PlanetName.Mars);
	}

	[EventCalculator(EventName.MarsMarsPD6)]
	public static CalculatorResult MarsMarsPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mars, PlanetName.Mars);
	}

	[EventCalculator(EventName.RahuMarsPD6)]
	public static CalculatorResult RahuMarsPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Rahu, PlanetName.Mars);
	}

	[EventCalculator(EventName.JupiterMarsPD6)]
	public static CalculatorResult JupiterMarsPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Jupiter, PlanetName.Mars);
	}

	[EventCalculator(EventName.SaturnMarsPD6)]
	public static CalculatorResult SaturnMarsPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Saturn, PlanetName.Mars);
	}

	[EventCalculator(EventName.MercuryMarsPD6)]
	public static CalculatorResult MercuryMarsPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mercury, PlanetName.Mars);
	}

	[EventCalculator(EventName.KetuMarsPD6)]
	public static CalculatorResult KetuMarsPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Ketu, PlanetName.Mars);
	}

	[EventCalculator(EventName.VenusMarsPD6)]
	public static CalculatorResult VenusMarsPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Venus, PlanetName.Mars);
	}

	[EventCalculator(EventName.SunRahuPD6)]
	public static CalculatorResult SunRahuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Sun, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MoonRahuPD6)]
	public static CalculatorResult MoonRahuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Moon, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MarsRahuPD6)]
	public static CalculatorResult MarsRahuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mars, PlanetName.Rahu);
	}

	[EventCalculator(EventName.RahuRahuPD6)]
	public static CalculatorResult RahuRahuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Rahu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.JupiterRahuPD6)]
	public static CalculatorResult JupiterRahuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Jupiter, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SaturnRahuPD6)]
	public static CalculatorResult SaturnRahuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Saturn, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MercuryRahuPD6)]
	public static CalculatorResult MercuryRahuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mercury, PlanetName.Rahu);
	}

	[EventCalculator(EventName.KetuRahuPD6)]
	public static CalculatorResult KetuRahuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Ketu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.VenusRahuPD6)]
	public static CalculatorResult VenusRahuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Venus, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SunJupiterPD6)]
	public static CalculatorResult SunJupiterPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Sun, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MoonJupiterPD6)]
	public static CalculatorResult MoonJupiterPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Moon, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MarsJupiterPD6)]
	public static CalculatorResult MarsJupiterPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mars, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.RahuJupiterPD6)]
	public static CalculatorResult RahuJupiterPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Rahu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.JupiterJupiterPD6)]
	public static CalculatorResult JupiterJupiterPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Jupiter, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SaturnJupiterPD6)]
	public static CalculatorResult SaturnJupiterPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Saturn, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MercuryJupiterPD6)]
	public static CalculatorResult MercuryJupiterPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mercury, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.KetuJupiterPD6)]
	public static CalculatorResult KetuJupiterPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Ketu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.VenusJupiterPD6)]
	public static CalculatorResult VenusJupiterPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Venus, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SunSaturnPD6)]
	public static CalculatorResult SunSaturnPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Sun, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MoonSaturnPD6)]
	public static CalculatorResult MoonSaturnPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Moon, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MarsSaturnPD6)]
	public static CalculatorResult MarsSaturnPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mars, PlanetName.Saturn);
	}

	[EventCalculator(EventName.RahuSaturnPD6)]
	public static CalculatorResult RahuSaturnPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Rahu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.JupiterSaturnPD6)]
	public static CalculatorResult JupiterSaturnPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Jupiter, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SaturnSaturnPD6)]
	public static CalculatorResult SaturnSaturnPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Saturn, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MercurySaturnPD6)]
	public static CalculatorResult MercurySaturnPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mercury, PlanetName.Saturn);
	}

	[EventCalculator(EventName.KetuSaturnPD6)]
	public static CalculatorResult KetuSaturnPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Ketu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.VenusSaturnPD6)]
	public static CalculatorResult VenusSaturnPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Venus, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SunMercuryPD6)]
	public static CalculatorResult SunMercuryPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Sun, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MoonMercuryPD6)]
	public static CalculatorResult MoonMercuryPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Moon, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MarsMercuryPD6)]
	public static CalculatorResult MarsMercuryPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mars, PlanetName.Mercury);
	}

	[EventCalculator(EventName.RahuMercuryPD6)]
	public static CalculatorResult RahuMercuryPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Rahu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.JupiterMercuryPD6)]
	public static CalculatorResult JupiterMercuryPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Jupiter, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SaturnMercuryPD6)]
	public static CalculatorResult SaturnMercuryPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Saturn, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MercuryMercuryPD6)]
	public static CalculatorResult MercuryMercuryPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mercury, PlanetName.Mercury);
	}

	[EventCalculator(EventName.KetuMercuryPD6)]
	public static CalculatorResult KetuMercuryPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Ketu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.VenusMercuryPD6)]
	public static CalculatorResult VenusMercuryPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Venus, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SunKetuPD6)]
	public static CalculatorResult SunKetuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Sun, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MoonKetuPD6)]
	public static CalculatorResult MoonKetuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Moon, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MarsKetuPD6)]
	public static CalculatorResult MarsKetuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mars, PlanetName.Ketu);
	}

	[EventCalculator(EventName.RahuKetuPD6)]
	public static CalculatorResult RahuKetuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Rahu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.JupiterKetuPD6)]
	public static CalculatorResult JupiterKetuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Jupiter, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SaturnKetuPD6)]
	public static CalculatorResult SaturnKetuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Saturn, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MercuryKetuPD6)]
	public static CalculatorResult MercuryKetuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mercury, PlanetName.Ketu);
	}

	[EventCalculator(EventName.KetuKetuPD6)]
	public static CalculatorResult KetuKetuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Ketu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.VenusKetuPD6)]
	public static CalculatorResult VenusKetuPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Venus, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SunVenusPD6)]
	public static CalculatorResult SunVenusPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Sun, PlanetName.Venus);
	}

	[EventCalculator(EventName.MoonVenusPD6)]
	public static CalculatorResult MoonVenusPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Moon, PlanetName.Venus);
	}

	[EventCalculator(EventName.MarsVenusPD6)]
	public static CalculatorResult MarsVenusPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mars, PlanetName.Venus);
	}

	[EventCalculator(EventName.RahuVenusPD6)]
	public static CalculatorResult RahuVenusPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Rahu, PlanetName.Venus);
	}

	[EventCalculator(EventName.JupiterVenusPD6)]
	public static CalculatorResult JupiterVenusPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Jupiter, PlanetName.Venus);
	}

	[EventCalculator(EventName.SaturnVenusPD6)]
	public static CalculatorResult SaturnVenusPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Saturn, PlanetName.Venus);
	}

	[EventCalculator(EventName.MercuryVenusPD6)]
	public static CalculatorResult MercuryVenusPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Mercury, PlanetName.Venus);
	}

	[EventCalculator(EventName.KetuVenusPD6)]
	public static CalculatorResult KetuVenusPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Ketu, PlanetName.Venus);
	}

	[EventCalculator(EventName.VenusVenusPD6)]
	public static CalculatorResult VenusVenusPD6(Time time, Person person)
	{
		return PlanetPD5PlanetPD6(time, person, PlanetName.Venus, PlanetName.Venus);
	}

	[EventCalculator(EventName.SunSunPD7)]
	public static CalculatorResult SunSunPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Sun, PlanetName.Sun);
	}

	[EventCalculator(EventName.MoonSunPD7)]
	public static CalculatorResult MoonSunPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Moon, PlanetName.Sun);
	}

	[EventCalculator(EventName.MarsSunPD7)]
	public static CalculatorResult MarsSunPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mars, PlanetName.Sun);
	}

	[EventCalculator(EventName.RahuSunPD7)]
	public static CalculatorResult RahuSunPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Rahu, PlanetName.Sun);
	}

	[EventCalculator(EventName.JupiterSunPD7)]
	public static CalculatorResult JupiterSunPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Jupiter, PlanetName.Sun);
	}

	[EventCalculator(EventName.SaturnSunPD7)]
	public static CalculatorResult SaturnSunPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Saturn, PlanetName.Sun);
	}

	[EventCalculator(EventName.MercurySunPD7)]
	public static CalculatorResult MercurySunPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mercury, PlanetName.Sun);
	}

	[EventCalculator(EventName.KetuSunPD7)]
	public static CalculatorResult KetuSunPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Ketu, PlanetName.Sun);
	}

	[EventCalculator(EventName.VenusSunPD7)]
	public static CalculatorResult VenusSunPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Venus, PlanetName.Sun);
	}

	[EventCalculator(EventName.SunMoonPD7)]
	public static CalculatorResult SunMoonPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Sun, PlanetName.Moon);
	}

	[EventCalculator(EventName.MoonMoonPD7)]
	public static CalculatorResult MoonMoonPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Moon, PlanetName.Moon);
	}

	[EventCalculator(EventName.MarsMoonPD7)]
	public static CalculatorResult MarsMoonPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mars, PlanetName.Moon);
	}

	[EventCalculator(EventName.RahuMoonPD7)]
	public static CalculatorResult RahuMoonPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Rahu, PlanetName.Moon);
	}

	[EventCalculator(EventName.JupiterMoonPD7)]
	public static CalculatorResult JupiterMoonPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Jupiter, PlanetName.Moon);
	}

	[EventCalculator(EventName.SaturnMoonPD7)]
	public static CalculatorResult SaturnMoonPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Saturn, PlanetName.Moon);
	}

	[EventCalculator(EventName.MercuryMoonPD7)]
	public static CalculatorResult MercuryMoonPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mercury, PlanetName.Moon);
	}

	[EventCalculator(EventName.KetuMoonPD7)]
	public static CalculatorResult KetuMoonPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Ketu, PlanetName.Moon);
	}

	[EventCalculator(EventName.VenusMoonPD7)]
	public static CalculatorResult VenusMoonPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Venus, PlanetName.Moon);
	}

	[EventCalculator(EventName.SunMarsPD7)]
	public static CalculatorResult SunMarsPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Sun, PlanetName.Mars);
	}

	[EventCalculator(EventName.MoonMarsPD7)]
	public static CalculatorResult MoonMarsPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Moon, PlanetName.Mars);
	}

	[EventCalculator(EventName.MarsMarsPD7)]
	public static CalculatorResult MarsMarsPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mars, PlanetName.Mars);
	}

	[EventCalculator(EventName.RahuMarsPD7)]
	public static CalculatorResult RahuMarsPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Rahu, PlanetName.Mars);
	}

	[EventCalculator(EventName.JupiterMarsPD7)]
	public static CalculatorResult JupiterMarsPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Jupiter, PlanetName.Mars);
	}

	[EventCalculator(EventName.SaturnMarsPD7)]
	public static CalculatorResult SaturnMarsPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Saturn, PlanetName.Mars);
	}

	[EventCalculator(EventName.MercuryMarsPD7)]
	public static CalculatorResult MercuryMarsPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mercury, PlanetName.Mars);
	}

	[EventCalculator(EventName.KetuMarsPD7)]
	public static CalculatorResult KetuMarsPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Ketu, PlanetName.Mars);
	}

	[EventCalculator(EventName.VenusMarsPD7)]
	public static CalculatorResult VenusMarsPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Venus, PlanetName.Mars);
	}

	[EventCalculator(EventName.SunRahuPD7)]
	public static CalculatorResult SunRahuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Sun, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MoonRahuPD7)]
	public static CalculatorResult MoonRahuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Moon, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MarsRahuPD7)]
	public static CalculatorResult MarsRahuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mars, PlanetName.Rahu);
	}

	[EventCalculator(EventName.RahuRahuPD7)]
	public static CalculatorResult RahuRahuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Rahu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.JupiterRahuPD7)]
	public static CalculatorResult JupiterRahuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Jupiter, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SaturnRahuPD7)]
	public static CalculatorResult SaturnRahuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Saturn, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MercuryRahuPD7)]
	public static CalculatorResult MercuryRahuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mercury, PlanetName.Rahu);
	}

	[EventCalculator(EventName.KetuRahuPD7)]
	public static CalculatorResult KetuRahuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Ketu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.VenusRahuPD7)]
	public static CalculatorResult VenusRahuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Venus, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SunJupiterPD7)]
	public static CalculatorResult SunJupiterPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Sun, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MoonJupiterPD7)]
	public static CalculatorResult MoonJupiterPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Moon, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MarsJupiterPD7)]
	public static CalculatorResult MarsJupiterPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mars, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.RahuJupiterPD7)]
	public static CalculatorResult RahuJupiterPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Rahu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.JupiterJupiterPD7)]
	public static CalculatorResult JupiterJupiterPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Jupiter, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SaturnJupiterPD7)]
	public static CalculatorResult SaturnJupiterPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Saturn, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MercuryJupiterPD7)]
	public static CalculatorResult MercuryJupiterPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mercury, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.KetuJupiterPD7)]
	public static CalculatorResult KetuJupiterPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Ketu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.VenusJupiterPD7)]
	public static CalculatorResult VenusJupiterPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Venus, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SunSaturnPD7)]
	public static CalculatorResult SunSaturnPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Sun, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MoonSaturnPD7)]
	public static CalculatorResult MoonSaturnPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Moon, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MarsSaturnPD7)]
	public static CalculatorResult MarsSaturnPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mars, PlanetName.Saturn);
	}

	[EventCalculator(EventName.RahuSaturnPD7)]
	public static CalculatorResult RahuSaturnPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Rahu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.JupiterSaturnPD7)]
	public static CalculatorResult JupiterSaturnPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Jupiter, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SaturnSaturnPD7)]
	public static CalculatorResult SaturnSaturnPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Saturn, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MercurySaturnPD7)]
	public static CalculatorResult MercurySaturnPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mercury, PlanetName.Saturn);
	}

	[EventCalculator(EventName.KetuSaturnPD7)]
	public static CalculatorResult KetuSaturnPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Ketu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.VenusSaturnPD7)]
	public static CalculatorResult VenusSaturnPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Venus, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SunMercuryPD7)]
	public static CalculatorResult SunMercuryPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Sun, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MoonMercuryPD7)]
	public static CalculatorResult MoonMercuryPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Moon, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MarsMercuryPD7)]
	public static CalculatorResult MarsMercuryPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mars, PlanetName.Mercury);
	}

	[EventCalculator(EventName.RahuMercuryPD7)]
	public static CalculatorResult RahuMercuryPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Rahu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.JupiterMercuryPD7)]
	public static CalculatorResult JupiterMercuryPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Jupiter, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SaturnMercuryPD7)]
	public static CalculatorResult SaturnMercuryPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Saturn, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MercuryMercuryPD7)]
	public static CalculatorResult MercuryMercuryPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mercury, PlanetName.Mercury);
	}

	[EventCalculator(EventName.KetuMercuryPD7)]
	public static CalculatorResult KetuMercuryPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Ketu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.VenusMercuryPD7)]
	public static CalculatorResult VenusMercuryPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Venus, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SunKetuPD7)]
	public static CalculatorResult SunKetuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Sun, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MoonKetuPD7)]
	public static CalculatorResult MoonKetuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Moon, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MarsKetuPD7)]
	public static CalculatorResult MarsKetuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mars, PlanetName.Ketu);
	}

	[EventCalculator(EventName.RahuKetuPD7)]
	public static CalculatorResult RahuKetuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Rahu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.JupiterKetuPD7)]
	public static CalculatorResult JupiterKetuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Jupiter, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SaturnKetuPD7)]
	public static CalculatorResult SaturnKetuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Saturn, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MercuryKetuPD7)]
	public static CalculatorResult MercuryKetuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mercury, PlanetName.Ketu);
	}

	[EventCalculator(EventName.KetuKetuPD7)]
	public static CalculatorResult KetuKetuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Ketu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.VenusKetuPD7)]
	public static CalculatorResult VenusKetuPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Venus, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SunVenusPD7)]
	public static CalculatorResult SunVenusPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Sun, PlanetName.Venus);
	}

	[EventCalculator(EventName.MoonVenusPD7)]
	public static CalculatorResult MoonVenusPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Moon, PlanetName.Venus);
	}

	[EventCalculator(EventName.MarsVenusPD7)]
	public static CalculatorResult MarsVenusPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mars, PlanetName.Venus);
	}

	[EventCalculator(EventName.RahuVenusPD7)]
	public static CalculatorResult RahuVenusPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Rahu, PlanetName.Venus);
	}

	[EventCalculator(EventName.JupiterVenusPD7)]
	public static CalculatorResult JupiterVenusPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Jupiter, PlanetName.Venus);
	}

	[EventCalculator(EventName.SaturnVenusPD7)]
	public static CalculatorResult SaturnVenusPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Saturn, PlanetName.Venus);
	}

	[EventCalculator(EventName.MercuryVenusPD7)]
	public static CalculatorResult MercuryVenusPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Mercury, PlanetName.Venus);
	}

	[EventCalculator(EventName.KetuVenusPD7)]
	public static CalculatorResult KetuVenusPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Ketu, PlanetName.Venus);
	}

	[EventCalculator(EventName.VenusVenusPD7)]
	public static CalculatorResult VenusVenusPD7(Time time, Person person)
	{
		return PlanetPD6PlanetPD7(time, person, PlanetName.Venus, PlanetName.Venus);
	}

	[EventCalculator(EventName.SunSunPD8)]
	public static CalculatorResult SunSunPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Sun, PlanetName.Sun);
	}

	[EventCalculator(EventName.MoonSunPD8)]
	public static CalculatorResult MoonSunPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Moon, PlanetName.Sun);
	}

	[EventCalculator(EventName.MarsSunPD8)]
	public static CalculatorResult MarsSunPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mars, PlanetName.Sun);
	}

	[EventCalculator(EventName.RahuSunPD8)]
	public static CalculatorResult RahuSunPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Rahu, PlanetName.Sun);
	}

	[EventCalculator(EventName.JupiterSunPD8)]
	public static CalculatorResult JupiterSunPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Jupiter, PlanetName.Sun);
	}

	[EventCalculator(EventName.SaturnSunPD8)]
	public static CalculatorResult SaturnSunPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Saturn, PlanetName.Sun);
	}

	[EventCalculator(EventName.MercurySunPD8)]
	public static CalculatorResult MercurySunPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mercury, PlanetName.Sun);
	}

	[EventCalculator(EventName.KetuSunPD8)]
	public static CalculatorResult KetuSunPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Ketu, PlanetName.Sun);
	}

	[EventCalculator(EventName.VenusSunPD8)]
	public static CalculatorResult VenusSunPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Venus, PlanetName.Sun);
	}

	[EventCalculator(EventName.SunMoonPD8)]
	public static CalculatorResult SunMoonPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Sun, PlanetName.Moon);
	}

	[EventCalculator(EventName.MoonMoonPD8)]
	public static CalculatorResult MoonMoonPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Moon, PlanetName.Moon);
	}

	[EventCalculator(EventName.MarsMoonPD8)]
	public static CalculatorResult MarsMoonPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mars, PlanetName.Moon);
	}

	[EventCalculator(EventName.RahuMoonPD8)]
	public static CalculatorResult RahuMoonPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Rahu, PlanetName.Moon);
	}

	[EventCalculator(EventName.JupiterMoonPD8)]
	public static CalculatorResult JupiterMoonPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Jupiter, PlanetName.Moon);
	}

	[EventCalculator(EventName.SaturnMoonPD8)]
	public static CalculatorResult SaturnMoonPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Saturn, PlanetName.Moon);
	}

	[EventCalculator(EventName.MercuryMoonPD8)]
	public static CalculatorResult MercuryMoonPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mercury, PlanetName.Moon);
	}

	[EventCalculator(EventName.KetuMoonPD8)]
	public static CalculatorResult KetuMoonPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Ketu, PlanetName.Moon);
	}

	[EventCalculator(EventName.VenusMoonPD8)]
	public static CalculatorResult VenusMoonPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Venus, PlanetName.Moon);
	}

	[EventCalculator(EventName.SunMarsPD8)]
	public static CalculatorResult SunMarsPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Sun, PlanetName.Mars);
	}

	[EventCalculator(EventName.MoonMarsPD8)]
	public static CalculatorResult MoonMarsPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Moon, PlanetName.Mars);
	}

	[EventCalculator(EventName.MarsMarsPD8)]
	public static CalculatorResult MarsMarsPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mars, PlanetName.Mars);
	}

	[EventCalculator(EventName.RahuMarsPD8)]
	public static CalculatorResult RahuMarsPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Rahu, PlanetName.Mars);
	}

	[EventCalculator(EventName.JupiterMarsPD8)]
	public static CalculatorResult JupiterMarsPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Jupiter, PlanetName.Mars);
	}

	[EventCalculator(EventName.SaturnMarsPD8)]
	public static CalculatorResult SaturnMarsPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Saturn, PlanetName.Mars);
	}

	[EventCalculator(EventName.MercuryMarsPD8)]
	public static CalculatorResult MercuryMarsPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mercury, PlanetName.Mars);
	}

	[EventCalculator(EventName.KetuMarsPD8)]
	public static CalculatorResult KetuMarsPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Ketu, PlanetName.Mars);
	}

	[EventCalculator(EventName.VenusMarsPD8)]
	public static CalculatorResult VenusMarsPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Venus, PlanetName.Mars);
	}

	[EventCalculator(EventName.SunRahuPD8)]
	public static CalculatorResult SunRahuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Sun, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MoonRahuPD8)]
	public static CalculatorResult MoonRahuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Moon, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MarsRahuPD8)]
	public static CalculatorResult MarsRahuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mars, PlanetName.Rahu);
	}

	[EventCalculator(EventName.RahuRahuPD8)]
	public static CalculatorResult RahuRahuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Rahu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.JupiterRahuPD8)]
	public static CalculatorResult JupiterRahuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Jupiter, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SaturnRahuPD8)]
	public static CalculatorResult SaturnRahuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Saturn, PlanetName.Rahu);
	}

	[EventCalculator(EventName.MercuryRahuPD8)]
	public static CalculatorResult MercuryRahuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mercury, PlanetName.Rahu);
	}

	[EventCalculator(EventName.KetuRahuPD8)]
	public static CalculatorResult KetuRahuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Ketu, PlanetName.Rahu);
	}

	[EventCalculator(EventName.VenusRahuPD8)]
	public static CalculatorResult VenusRahuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Venus, PlanetName.Rahu);
	}

	[EventCalculator(EventName.SunJupiterPD8)]
	public static CalculatorResult SunJupiterPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Sun, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MoonJupiterPD8)]
	public static CalculatorResult MoonJupiterPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Moon, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MarsJupiterPD8)]
	public static CalculatorResult MarsJupiterPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mars, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.RahuJupiterPD8)]
	public static CalculatorResult RahuJupiterPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Rahu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.JupiterJupiterPD8)]
	public static CalculatorResult JupiterJupiterPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Jupiter, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SaturnJupiterPD8)]
	public static CalculatorResult SaturnJupiterPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Saturn, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.MercuryJupiterPD8)]
	public static CalculatorResult MercuryJupiterPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mercury, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.KetuJupiterPD8)]
	public static CalculatorResult KetuJupiterPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Ketu, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.VenusJupiterPD8)]
	public static CalculatorResult VenusJupiterPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Venus, PlanetName.Jupiter);
	}

	[EventCalculator(EventName.SunSaturnPD8)]
	public static CalculatorResult SunSaturnPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Sun, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MoonSaturnPD8)]
	public static CalculatorResult MoonSaturnPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Moon, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MarsSaturnPD8)]
	public static CalculatorResult MarsSaturnPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mars, PlanetName.Saturn);
	}

	[EventCalculator(EventName.RahuSaturnPD8)]
	public static CalculatorResult RahuSaturnPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Rahu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.JupiterSaturnPD8)]
	public static CalculatorResult JupiterSaturnPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Jupiter, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SaturnSaturnPD8)]
	public static CalculatorResult SaturnSaturnPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Saturn, PlanetName.Saturn);
	}

	[EventCalculator(EventName.MercurySaturnPD8)]
	public static CalculatorResult MercurySaturnPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mercury, PlanetName.Saturn);
	}

	[EventCalculator(EventName.KetuSaturnPD8)]
	public static CalculatorResult KetuSaturnPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Ketu, PlanetName.Saturn);
	}

	[EventCalculator(EventName.VenusSaturnPD8)]
	public static CalculatorResult VenusSaturnPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Venus, PlanetName.Saturn);
	}

	[EventCalculator(EventName.SunMercuryPD8)]
	public static CalculatorResult SunMercuryPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Sun, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MoonMercuryPD8)]
	public static CalculatorResult MoonMercuryPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Moon, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MarsMercuryPD8)]
	public static CalculatorResult MarsMercuryPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mars, PlanetName.Mercury);
	}

	[EventCalculator(EventName.RahuMercuryPD8)]
	public static CalculatorResult RahuMercuryPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Rahu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.JupiterMercuryPD8)]
	public static CalculatorResult JupiterMercuryPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Jupiter, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SaturnMercuryPD8)]
	public static CalculatorResult SaturnMercuryPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Saturn, PlanetName.Mercury);
	}

	[EventCalculator(EventName.MercuryMercuryPD8)]
	public static CalculatorResult MercuryMercuryPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mercury, PlanetName.Mercury);
	}

	[EventCalculator(EventName.KetuMercuryPD8)]
	public static CalculatorResult KetuMercuryPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Ketu, PlanetName.Mercury);
	}

	[EventCalculator(EventName.VenusMercuryPD8)]
	public static CalculatorResult VenusMercuryPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Venus, PlanetName.Mercury);
	}

	[EventCalculator(EventName.SunKetuPD8)]
	public static CalculatorResult SunKetuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Sun, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MoonKetuPD8)]
	public static CalculatorResult MoonKetuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Moon, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MarsKetuPD8)]
	public static CalculatorResult MarsKetuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mars, PlanetName.Ketu);
	}

	[EventCalculator(EventName.RahuKetuPD8)]
	public static CalculatorResult RahuKetuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Rahu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.JupiterKetuPD8)]
	public static CalculatorResult JupiterKetuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Jupiter, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SaturnKetuPD8)]
	public static CalculatorResult SaturnKetuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Saturn, PlanetName.Ketu);
	}

	[EventCalculator(EventName.MercuryKetuPD8)]
	public static CalculatorResult MercuryKetuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mercury, PlanetName.Ketu);
	}

	[EventCalculator(EventName.KetuKetuPD8)]
	public static CalculatorResult KetuKetuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Ketu, PlanetName.Ketu);
	}

	[EventCalculator(EventName.VenusKetuPD8)]
	public static CalculatorResult VenusKetuPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Venus, PlanetName.Ketu);
	}

	[EventCalculator(EventName.SunVenusPD8)]
	public static CalculatorResult SunVenusPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Sun, PlanetName.Venus);
	}

	[EventCalculator(EventName.MoonVenusPD8)]
	public static CalculatorResult MoonVenusPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Moon, PlanetName.Venus);
	}

	[EventCalculator(EventName.MarsVenusPD8)]
	public static CalculatorResult MarsVenusPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mars, PlanetName.Venus);
	}

	[EventCalculator(EventName.RahuVenusPD8)]
	public static CalculatorResult RahuVenusPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Rahu, PlanetName.Venus);
	}

	[EventCalculator(EventName.JupiterVenusPD8)]
	public static CalculatorResult JupiterVenusPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Jupiter, PlanetName.Venus);
	}

	[EventCalculator(EventName.SaturnVenusPD8)]
	public static CalculatorResult SaturnVenusPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Saturn, PlanetName.Venus);
	}

	[EventCalculator(EventName.MercuryVenusPD8)]
	public static CalculatorResult MercuryVenusPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Mercury, PlanetName.Venus);
	}

	[EventCalculator(EventName.KetuVenusPD8)]
	public static CalculatorResult KetuVenusPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Ketu, PlanetName.Venus);
	}

	[EventCalculator(EventName.VenusVenusPD8)]
	public static CalculatorResult VenusVenusPD8(Time time, Person person)
	{
		return PlanetPD7PlanetPD8(time, person, PlanetName.Venus, PlanetName.Venus);
	}

	[EventCalculator(EventName.Lord6And8Dasa)]
	public static CalculatorResult Lord6And8Dasa(Time time, Person person)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House6, person.BirthTime);
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == planetName;
		PlanetName planetName2 = Calculate.LordOfHouse(HouseName.House8, person.BirthTime);
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == planetName2;
		bool occuring = num | flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Lord5And9Dasa)]
	public static CalculatorResult Lord5And9Dasa(Time time, Person person)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House5, person.BirthTime);
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == planetName;
		PlanetName planetName2 = Calculate.LordOfHouse(HouseName.House9, person.BirthTime);
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == planetName2;
		bool occuring = num | flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Lord5And9DasaBhukti)]
	public static CalculatorResult Lord5And9DasaBhukti(Time time, Person person)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House5, person.BirthTime);
		PlanetName planetName2 = Calculate.LordOfHouse(HouseName.House9, person.BirthTime);
		bool flag = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == planetName;
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD2 == planetName;
		bool flag2 = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == planetName2;
		bool flag3 = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD2 == planetName2;
		bool num2 = num & flag2;
		bool flag4 = flag & flag3;
		bool occuring = num2 | flag4;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.BhuktiDasaLordInBadHouses)]
	public static CalculatorResult BhuktiDasaLordInBadHouses(Time time, Person person)
	{
		PlanetName pD = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD2;
		PlanetName pD2 = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1;
		bool num = Calculate.IsPlanetInHouse(pD, HouseName.House6, person.BirthTime);
		bool flag = Calculate.IsPlanetInHouse(pD2, HouseName.House8, person.BirthTime);
		bool flag2 = num & flag;
		bool num2 = Calculate.IsPlanetInHouse(pD, HouseName.House12, person.BirthTime);
		bool flag3 = Calculate.IsPlanetInHouse(pD2, HouseName.House2, person.BirthTime);
		bool flag4 = num2 & flag3;
		bool occuring = flag2 | flag4;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Lord2Dasa)]
	public static CalculatorResult Lord2Dasa(Time time, Person person)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House2, person.BirthTime);
		bool occuring = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == planetName;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Lord3Dasa)]
	public static CalculatorResult Lord3Dasa(Time time, Person person)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House3, person.BirthTime);
		bool occuring = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == planetName;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.LagnaLordDasa)]
	public static CalculatorResult LagnaLordDasa(Time time, Person person)
	{
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House1, person.BirthTime);
		bool occuring = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == planetName;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Saturn4thDasa)]
	public static CalculatorResult Saturn4thDasa(Time time, Person person)
	{
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Saturn;
		bool flag = VimshottariDasa.CurrentDasaCountFromBirth(person.BirthTime, time) == 4;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.Jupiter6thDasa)]
	public static CalculatorResult Jupiter6thDasa(Time time, Person person)
	{
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Jupiter;
		bool flag = VimshottariDasa.CurrentDasaCountFromBirth(person.BirthTime, time) == 6;
		bool occuring = num & flag;
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	[EventCalculator(EventName.ElevatedSunDasa)]
	public static CalculatorResult ElevatedSunDasa(Time time, Person person)
	{
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool flag = false;
		return CalculatorResult.New(num & flag, PlanetName.Sun);
	}

	[EventCalculator(EventName.SunWithLord9Or10Dasa)]
	public static CalculatorResult SunWithLord9Or10Dasa(Time time, Person person)
	{
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool num2 = Calculate.IsPlanetInOwnHouse(PlanetName.Sun, person.BirthTime);
		bool num3 = Calculate.IsPlanetSameHouseWithHouseLord(9, PlanetName.Sun, person.BirthTime);
		bool flag = Calculate.IsPlanetSameHouseWithHouseLord(10, PlanetName.Sun, person.BirthTime);
		bool flag2 = num3 | flag;
		bool flag3 = num2 | flag2;
		return CalculatorResult.New(num & flag3, new HouseName[2]
		{
			HouseName.House9,
			HouseName.House10
		}, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[EventCalculator(EventName.SunWithLord5Dasa)]
	public static CalculatorResult SunWithLord5Dasa(Time time, Person person)
	{
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool flag = Calculate.IsPlanetSameHouseWithHouseLord(5, PlanetName.Sun, person.BirthTime);
		return CalculatorResult.New(num & flag, new HouseName[1] { HouseName.House5 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[EventCalculator(EventName.SunWithLord2Dasa)]
	public static CalculatorResult SunWithLord2Dasa(Time time, Person person)
	{
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool flag = Calculate.IsPlanetSameHouseWithHouseLord(2, PlanetName.Sun, person.BirthTime);
		return CalculatorResult.New(num & flag, new HouseName[1] { HouseName.House2 }, new PlanetName[1] { PlanetName.Sun }, time);
	}

	[EventCalculator(EventName.SunBadPositionDasa)]
	public static CalculatorResult SunBadPositionDasa(Time time, Person person)
	{
		return new CalculatorResult
		{
			Occuring = false
		};
	}

	[EventCalculator(EventName.ExaltedSunDasa)]
	public static CalculatorResult ExaltedSunDasa(Time time, Person person)
	{
		bool num = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time).PD1 == PlanetName.Sun;
		bool flag = Calculate.IsPlanetExalted(PlanetName.Sun, time);
		return CalculatorResult.New(num & flag, PlanetName.Sun);
	}

	private static CalculatorResult PlanetPD2PlanetPD3(Time time, Person person, PlanetName bhuktiPlanet, PlanetName antaramPlanet)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool flag = dasas.PD2 == bhuktiPlanet;
		bool flag2 = (dasas.PD3 == antaramPlanet) & flag;
		if (flag2)
		{
			(EventNature, string) tuple = VimshottariDasa.PlanetDasaMajorPlanetAndMinorRelationship(bhuktiPlanet, antaramPlanet);
			CalculatorResult obj = new CalculatorResult
			{
				Occuring = flag2
			};
			(obj.NatureOverride, obj.DescriptionOverride) = tuple;
			return obj;
		}
		return CalculatorResult.NotOccuring();
	}

	private static CalculatorResult PlanetPD3PlanetPD4(Time time, Person person, PlanetName antaramPlanet, PlanetName sukshmaPlanet)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD3 == antaramPlanet;
		bool flag = dasas.PD4 == sukshmaPlanet;
		bool flag2 = num & flag;
		if (flag2)
		{
			(EventNature, string) tuple = VimshottariDasa.PlanetDasaMajorPlanetAndMinorRelationship(antaramPlanet, sukshmaPlanet);
			CalculatorResult obj = new CalculatorResult
			{
				Occuring = flag2
			};
			(obj.NatureOverride, obj.DescriptionOverride) = tuple;
			return obj;
		}
		return CalculatorResult.NotOccuring();
	}

	private static CalculatorResult PlanetPD4PlanetPD5(Time time, Person person, PlanetName PD4Planet, PlanetName PD5Planet)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD4 == PD4Planet;
		bool flag = dasas.PD5 == PD5Planet;
		bool flag2 = num & flag;
		if (flag2)
		{
			(EventNature, string) tuple = VimshottariDasa.PlanetDasaMajorPlanetAndMinorRelationship(PD4Planet, PD5Planet);
			CalculatorResult obj = new CalculatorResult
			{
				Occuring = flag2
			};
			(obj.NatureOverride, obj.DescriptionOverride) = tuple;
			return obj;
		}
		return CalculatorResult.NotOccuring();
	}

	private static CalculatorResult PlanetPD5PlanetPD6(Time time, Person person, PlanetName PD5Planet, PlanetName PD6Planet)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD5 == PD5Planet;
		bool flag = dasas.PD6 == PD6Planet;
		bool flag2 = num & flag;
		if (flag2)
		{
			(EventNature, string) tuple = VimshottariDasa.PlanetDasaMajorPlanetAndMinorRelationship(PD5Planet, PD6Planet);
			CalculatorResult obj = new CalculatorResult
			{
				Occuring = flag2
			};
			(obj.NatureOverride, obj.DescriptionOverride) = tuple;
			return obj;
		}
		return CalculatorResult.NotOccuring();
	}

	private static CalculatorResult PlanetPD6PlanetPD7(Time time, Person person, PlanetName PD6Planet, PlanetName PD7Planet)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD6 == PD6Planet;
		bool flag = dasas.PD7 == PD7Planet;
		bool flag2 = num & flag;
		if (flag2)
		{
			(EventNature, string) tuple = VimshottariDasa.PlanetDasaMajorPlanetAndMinorRelationship(PD6Planet, PD7Planet);
			CalculatorResult obj = new CalculatorResult
			{
				Occuring = flag2
			};
			(obj.NatureOverride, obj.DescriptionOverride) = tuple;
			return obj;
		}
		return CalculatorResult.NotOccuring();
	}

	private static CalculatorResult PlanetPD7PlanetPD8(Time time, Person person, PlanetName PD7Planet, PlanetName PD8Planet)
	{
		Dasas dasas = VimshottariDasa.CurrentDasa8Levels(person.BirthTime, time);
		bool num = dasas.PD7 == PD7Planet;
		bool flag = dasas.PD8 == PD8Planet;
		bool flag2 = num & flag;
		if (flag2)
		{
			(EventNature, string) tuple = VimshottariDasa.PlanetDasaMajorPlanetAndMinorRelationship(PD7Planet, PD8Planet);
			CalculatorResult obj = new CalculatorResult
			{
				Occuring = flag2
			};
			(obj.NatureOverride, obj.DescriptionOverride) = tuple;
			return obj;
		}
		return CalculatorResult.NotOccuring();
	}
}
