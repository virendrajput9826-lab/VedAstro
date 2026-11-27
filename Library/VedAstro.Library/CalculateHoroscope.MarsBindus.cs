using System;
namespace VedAstro.Library;

public partial class CalculateHoroscope
{
	// In the Mars Ashtakavarga section, sample the Mars table at the occupant's sign.
	private sealed class MarsBinduChart
	{
		private readonly Time time;
		private static readonly PlanetName mars = PlanetName.Mars;
		private static readonly PlanetName saturn = PlanetName.Saturn;
		public MarsBinduChart(Time time) => this.time = time;
		private ZodiacName lagna => Calculate.LagnaSignName(time);
		private ZodiacName Sign(PlanetName p) => Calculate.PlanetZodiacSign(p, time).GetSignName();
		private int House(PlanetName p) => (int)Calculate.HousePlanetOccupies(p, time);
		private int Points(PlanetName p) => Calculate.PlanetAshtakvargaBindu(mars, Sign(p), time);
		private int FromMoon(PlanetName p) => Calculate.SignDistanceFromPlanetToPlanet(PlanetName.Moon, p, time);
		private bool MarsCombustOrDebilitatedWithWaxingMoon() =>
			Points(mars) == 6 && House(mars) is 6 or 8 or 12 &&
			(Calculate.IsPlanetDebilitated(mars, time) || Calculate.DistanceBetweenPlanets(mars, PlanetName.Sun, time).TotalDegrees < 17) &&
			Calculate.IsWaxingMoon(time) && Calculate.IsPlanetConjunctWithPlanet(mars, PlanetName.Moon, time);
		private bool ThirdHouseCombination(Func<ZodiacName, bool> parity) =>
			((House(mars) == 3 && Points(mars) is >= 1 and <= 3) ||
			(House(saturn) == 3 && Points(saturn) is >= 1 and <= 3)) &&
			(parity(Sign(Calculate.LordOfHouse(HouseName.House3, time))) ||
			parity(Sign(Calculate.LordOfZodiacSign(Sign(mars)))));

		public bool MarsAshtakavargaYoga7()
		{
			return Points(mars) >= 4 && (House(mars) == 1 || FromMoon(mars) is 1 or 9 or 10) && (Calculate.IsPlanetInOwnHouse(mars, time) || Sign(mars) == Calculate.PlanetExaltationPoint(mars).GetSignName());
		}

		public bool MarsAshtakavargaYoga10A()
		{
			return MarsCombustOrDebilitatedWithWaxingMoon();
		}

		public bool MarsAshtakavargaYoga10B()
		{
			return MarsCombustOrDebilitatedWithWaxingMoon() && Calculate.IsPlanetStrongInShadbala(mars, time);
		}

		public bool MarsAshtakavargaYoga12A()
		{
			return ThirdHouseCombination(Calculate.IsEvenSign);
		}

		public bool MarsAshtakavargaYoga12B()
		{
			return ThirdHouseCombination(Calculate.IsOddSign);
		}

		public bool MarsAshtakavargaYoga13A()
		{
			return (Calculate.IsMovableSign(lagna) && Points(saturn) is >= 1 and <= 3 && Calculate.IsCommonSign(Sign(saturn))) || (Calculate.IsCommonSign(lagna) && Calculate.IsMovableSign(Sign(saturn)));
		}

		public bool MarsAshtakavargaYoga13B()
		{
			return Calculate.IsFixedSign(lagna) && (Points(mars) is >= 1 and <= 3 || Points(saturn) is >= 1 and <= 3);
		}

		public bool MarsAshtakavargaYoga14()
		{
			return Calculate.IsMovableSign(lagna) && Points(saturn) == 5 && !Calculate.IsCommonSign(Sign(saturn));
		}

		public bool MarsAshtakavargaYoga15()
		{
			var thirdLord = Calculate.LordOfHouse(HouseName.House3, time);
			return Calculate.IsFixedSign(lagna) && Calculate.IsCommonSign(Sign(thirdLord)) && Points(thirdLord) == 5;
		}
	}

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga7)]
	public static CalculatorResult MarsAshtakavargaYoga7(Time time) =>
		CalculatorResult.New(new MarsBinduChart(time).MarsAshtakavargaYoga7(), new[] { PlanetName.Mars }, time);

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga10A)]
	public static CalculatorResult MarsAshtakavargaYoga10A(Time time) =>
		CalculatorResult.New(new MarsBinduChart(time).MarsAshtakavargaYoga10A(), new[] { PlanetName.Mars }, time);

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga10B)]
	public static CalculatorResult MarsAshtakavargaYoga10B(Time time) =>
		CalculatorResult.New(new MarsBinduChart(time).MarsAshtakavargaYoga10B(), new[] { PlanetName.Mars }, time);

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga12A)]
	public static CalculatorResult MarsAshtakavargaYoga12A(Time time) =>
		CalculatorResult.New(new MarsBinduChart(time).MarsAshtakavargaYoga12A(), new[] { PlanetName.Mars }, time);

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga12B)]
	public static CalculatorResult MarsAshtakavargaYoga12B(Time time) =>
		CalculatorResult.New(new MarsBinduChart(time).MarsAshtakavargaYoga12B(), new[] { PlanetName.Mars }, time);

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga13A)]
	public static CalculatorResult MarsAshtakavargaYoga13A(Time time) =>
		CalculatorResult.New(new MarsBinduChart(time).MarsAshtakavargaYoga13A(), new[] { PlanetName.Mars }, time);

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga13B)]
	public static CalculatorResult MarsAshtakavargaYoga13B(Time time) =>
		CalculatorResult.New(new MarsBinduChart(time).MarsAshtakavargaYoga13B(), new[] { PlanetName.Mars }, time);

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga14)]
	public static CalculatorResult MarsAshtakavargaYoga14(Time time) =>
		CalculatorResult.New(new MarsBinduChart(time).MarsAshtakavargaYoga14(), new[] { PlanetName.Mars }, time);

	[HoroscopeCalculator(HoroscopeName.MarsAshtakavargaYoga15)]
	public static CalculatorResult MarsAshtakavargaYoga15(Time time) =>
		CalculatorResult.New(new MarsBinduChart(time).MarsAshtakavargaYoga15(), new[] { PlanetName.Mars }, time);
}
