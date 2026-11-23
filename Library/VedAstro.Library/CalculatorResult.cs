using System.Collections.Generic;
using System.Linq;

namespace VedAstro.Library;

public class CalculatorResult
{
	public bool Occuring { get; set; }

	public EventNature NatureOverride { get; set; }

	public string DescriptionOverride { get; set; } = "";

	public RelatedBody RelatedBody { get; set; } = new RelatedBody();

	public static CalculatorResult NotOccuring()
	{
		return new CalculatorResult
		{
			Occuring = false
		};
	}

	public static CalculatorResult IsOccuring()
	{
		return new CalculatorResult
		{
			Occuring = true
		};
	}

	public static CalculatorResult New(bool occuring)
	{
		return new CalculatorResult
		{
			Occuring = occuring
		};
	}

	public static CalculatorResult New(bool occuring, HouseName[] houseNames, Time time)
	{
		CalculatorResult calculatorResult = new CalculatorResult();
		calculatorResult.Occuring = occuring;
		calculatorResult.RelatedBody.RelatedHouses.AddRange(houseNames.ToList());
		List<PlanetName> source = Calculate.LordOfHouseList(calculatorResult.RelatedBody.RelatedHouses, time);
		calculatorResult.RelatedBody.RelatedPlanets.AddRange(source.ToList());
		return calculatorResult;
	}

	public static CalculatorResult New(bool occuring, PlanetName lord)
	{
		return new CalculatorResult
		{
			Occuring = occuring,
			RelatedBody = 
			{
				RelatedPlanets = { lord }
			}
		};
	}

	public static CalculatorResult New(bool occuring, PlanetName[] planetNames, Time birthTime)
	{
		CalculatorResult calculatorResult = new CalculatorResult();
		calculatorResult.Occuring = occuring;
		calculatorResult.RelatedBody.RelatedPlanets.AddRange(planetNames.ToList());
		return calculatorResult;
	}

	public static CalculatorResult New(bool occuring, HouseName[] houseNames, ZodiacName[] signNames, Time time)
	{
		CalculatorResult calculatorResult = New(occuring, houseNames, time);
		calculatorResult.RelatedBody.RelatedZodiac.AddRange(signNames.ToList());
		return calculatorResult;
	}

	public static CalculatorResult New(bool occuring, HouseName[] houseNames, PlanetName[] planetNames, ZodiacName[] signNames, Time time)
	{
		CalculatorResult calculatorResult = New(occuring, houseNames, planetNames, time);
		calculatorResult.RelatedBody.RelatedZodiac.AddRange(signNames.ToList());
		return calculatorResult;
	}

	public static CalculatorResult New(bool occuring, PlanetName[] planetNames, ZodiacName[] signNames, Time timeInput)
	{
		CalculatorResult calculatorResult = New(occuring, planetNames, timeInput);
		calculatorResult.RelatedBody.RelatedZodiac.AddRange(signNames.ToList());
		return calculatorResult;
	}

	public static CalculatorResult New(bool occuring, HouseName[] houseNames, PlanetName[] planetNames, Time time)
	{
		CalculatorResult calculatorResult = New(occuring, houseNames, time);
		calculatorResult.RelatedBody.RelatedPlanets.AddRange(planetNames.ToList());
		return calculatorResult;
	}

	public static CalculatorResult New(bool occuring, HouseName houseNumber, Time time)
	{
		CalculatorResult obj = new CalculatorResult
		{
			Occuring = occuring,
			RelatedBody = 
			{
				RelatedHouses = { houseNumber }
			}
		};
		PlanetName item = Calculate.LordOfHouse(houseNumber, time);
		obj.RelatedBody.RelatedPlanets.Add(item);
		return obj;
	}
}
