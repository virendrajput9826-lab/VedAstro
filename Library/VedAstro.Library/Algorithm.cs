using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VedAstro.Library;

public static class Algorithm
{
	private static double _scoreStepSize = 1.0;

	public static MethodInfo[] All => (from m in typeof(Algorithm).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
		where !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_")
		select m).ToArray();

	public static double Neutral(Event foundEvent, Person person)
	{
		return 0.0;
	}

	public static double General(Event foundEvent, Person person)
	{
		double result = 0.0;
		switch (foundEvent?.Nature)
		{
		case EventNature.Good:
			result = 3.0;
			break;
		case EventNature.Bad:
			result = -3.0;
			break;
		}
		return result;
	}

	public static double GocharaAshtakvargaBindu(Event foundEvent, Person person)
	{
		if (!foundEvent.Name.ToString().Contains("Gochara"))
		{
			return 0.0;
		}
		HouseName houseNumber = foundEvent.GetRelatedHouse()[0];
		PlanetName planetName = foundEvent.GetRelatedPlanet()[0];
		PlanetName.PlanetNameEnum name = planetName.Name;
		if ((uint)(name - 8) <= 1u)
		{
			return 0.0;
		}
		ZodiacName signToCheck = Calculate.HouseSignName(houseNumber, foundEvent.StartTime);
		int num = Calculate.PlanetAshtakvargaBindu(planetName, signToCheck, person.BirthTime);
		switch (num)
		{
		case 0:
			return -3.0;
		case 1:
			return -2.0;
		case 2:
		case 3:
			return -1.0;
		default:
			if (num >= 4 && num <= 5)
			{
				return 1.0;
			}
			if (num >= 6 && num <= 7)
			{
				return 2.0;
			}
			if (num == 8)
			{
				return 3.0;
			}
			throw new Exception("Not meant to hit here");
		}
	}

	public static double StrongestPlanet(Event foundEvent, Person person)
	{
		List<PlanetName> list = Calculate.AllPlanetOrderedByStrength(person.BirthTime);
		PlanetName planetName = list[0];
		PlanetName planetName2 = list[1];
		double num = 0.0;
		foreach (PlanetName item in foundEvent.GetRelatedPlanet())
		{
			if (item == planetName || item == planetName2)
			{
				num += _scoreStepSize;
			}
		}
		return num;
	}

	public static double WeakestPlanet(Event foundEvent, Person person)
	{
		List<PlanetName> list = Calculate.AllPlanetOrderedByStrength(person.BirthTime);
		PlanetName planetName = list[8];
		PlanetName planetName2 = list[7];
		double num = 0.0;
		foreach (PlanetName item in foundEvent.GetRelatedPlanet())
		{
			if (item == planetName || item == planetName2)
			{
				num += 0.0 - _scoreStepSize;
			}
		}
		return num;
	}

	public static double StrongestHouse(Event foundEvent, Person person)
	{
		HouseName houseName = Calculate.AllHousesOrderedByStrength(person.BirthTime)[0];
		double num = 0.0;
		foreach (HouseName item in foundEvent.GetRelatedHouse())
		{
			if (item == houseName)
			{
				num += _scoreStepSize;
			}
		}
		return num;
	}

	public static double WeakestHouse(Event foundEvent, Person person)
	{
		HouseName houseName = Calculate.AllHousesOrderedByStrength(person.BirthTime)[11];
		double num = 0.0;
		foreach (HouseName item in foundEvent.GetRelatedHouse())
		{
			if (item == houseName)
			{
				num += 0.0 - _scoreStepSize;
			}
		}
		return num;
	}

	public static double CombinedBad(Event foundEvent, Person person)
	{
		if (!foundEvent.GetRelatedPlanet().All((PlanetName pln) => !Calculate.IsPlanetStrongInShadbala(pln, person.BirthTime)))
		{
			return 0.0;
		}
		if (!foundEvent.GetRelatedHouse().All((HouseName hse) => !Calculate.IsHouseBeneficInShadbala(hse, person.BirthTime, 450.0)))
		{
			return 0.0;
		}
		return 0.0 - _scoreStepSize;
	}

	public static double IshtaKashtaPhala(Event foundEvent, Person person)
	{
		if (!foundEvent.Name.ToString().Contains("PD"))
		{
			return 0.0;
		}
		return Calculate.PlanetIshtaKashtaScore(Calculate.PickOutStrongestPlanet(foundEvent.GetRelatedPlanet(), person.BirthTime), person.BirthTime);
	}

	public static double IshtaKashtaPhalaDegree(Event foundEvent, Person person)
	{
		if (!foundEvent.Name.ToString().Contains("PD"))
		{
			return 0.0;
		}
		return Calculate.PlanetIshtaKashtaScoreDegree(Calculate.PickOutStrongestPlanet(foundEvent.GetRelatedPlanet(), person.BirthTime), person.BirthTime);
	}

	public static double PlanetStrengthDegree(Event foundEvent, Person person)
	{
		double num = 0.0;
		foreach (PlanetName item in foundEvent.GetRelatedPlanet())
		{
			double num2 = Calculate.PlanetPowerPercentage(item, person.BirthTime);
			double num3 = 0.0;
			num3 = ((!(num2 > 50.0)) ? num2.Remap(0.0, 100.0, -1.0, 0.0) : num2.Remap(0.0, 100.0, 0.0, 1.0));
			num += num3;
		}
		return num;
	}
}
