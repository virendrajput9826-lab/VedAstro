using System;
using System.Collections.Generic;
using SwissEphNet;

namespace VedAstro.Library;

public static class Krishnamurti
{
	public static readonly List<PlanetName> All9Planets = new List<PlanetName>
	{
		PlanetName.Ketu,
		PlanetName.Venus,
		PlanetName.Sun,
		PlanetName.Moon,
		PlanetName.Mars,
		PlanetName.Rahu,
		PlanetName.Jupiter,
		PlanetName.Saturn,
		PlanetName.Mercury
	};

	public static Dictionary<HouseName, Angle> AllHouseCuspLongitudes(Time time, int horaryNumber = 0, double rotateDegrees = 0.0)
	{
		return CacheManager.GetCache(new CacheKey("AllHouseCuspLongitudes", time, Calculate.Ayanamsa), _allHouseCuspLongitudes);
		Dictionary<HouseName, Angle> _allHouseCuspLongitudes()
		{
			bool num = horaryNumber != 0;
			bool flag = Math.Abs(rotateDegrees) > 0.0001;
			if (num)
			{
				return flag ? AllHouseCuspLongitudesRotateHorary(time, horaryNumber, rotateDegrees) : AllHouseCuspLongitudesHorary(time, horaryNumber);
			}
			return flag ? AllHouseCuspLongitudesRotateKundali(time, rotateDegrees) : AllHouseCuspLongitudesKundali(time);
		}
		static Dictionary<HouseName, Angle> AllHouseCuspLongitudesHorary(Time time2, int num5)
		{
			GeoLocation geoLocation = time2.GetGeoLocation();
			Console.WriteLine("Inside AllHouseCuspLongHorary with GeoLoc {0}", geoLocation.Latitude());
			SwissEph swissEph = new SwissEph();
			string arg = swissEph.swe_version();
			Console.WriteLine("{0}", arg);
			string arg2 = swissEph.swe_get_library_path();
			Console.WriteLine("{0}", arg2);
			swissEph.swe_set_ephe_path(null);
			double[] array = new double[13];
			_ = new double[10];
			double num = 1.0;
			Console.WriteLine("Ecliptic Obliquity eps {0}", num);
			double num2 = 0.5;
			Console.WriteLine("siderealAsc Degrees {0}", num2);
			double num3 = num2 + Calculate.AyanamsaDegree(time2).TotalDegrees;
			Console.WriteLine("tropAsc Degrees {0}", num3);
			double num4 = 0.9;
			Console.WriteLine("armc {0}", num4);
			Console.WriteLine("Latitude {0}", geoLocation.Latitude());
			swissEph.swe_set_sid_mode(Calculate.Ayanamsa, 0.0, 0.0);
			Calculate.TimeToJulianDay(time2);
			Console.Write("Ayanamsa {0}; Ayanamsa Degrees {1}, ", Calculate.Ayanamsa, Calculate.AyanamsaDegree(time2));
			Angle angle = Calculate.AyanamsaDegree(time2);
			Console.WriteLine("Ayanamsa Degree is {0}, {1} Deg {2} Min {3} Secs ", angle.Rounded, angle.Degrees, angle.Minutes, angle.Seconds);
			Dictionary<HouseName, Angle> dictionary = new Dictionary<HouseName, Angle>();
			foreach (HouseName allHouse in House.AllHouses)
			{
				_ = array[(int)allHouse];
				double value = 0.7;
				dictionary.Add(allHouse, Angle.FromDegrees(value));
			}
			return dictionary;
		}
		static Dictionary<HouseName, Angle> AllHouseCuspLongitudesKundali(Time time2)
		{
			time2.GetGeoLocation();
			Calculate.TimeToJulianDay(time2);
			new SwissEph();
			double[] array = new double[13];
			_ = new double[10];
			Dictionary<HouseName, Angle> dictionary = new Dictionary<HouseName, Angle>();
			foreach (HouseName allHouse2 in House.AllHouses)
			{
				double value = array[(int)allHouse2];
				dictionary.Add(allHouse2, Angle.FromDegrees(value));
			}
			return dictionary;
		}
		static Dictionary<HouseName, Angle> AllHouseCuspLongitudesRotateHorary(Time time2, int horaryNumber2, double ascendant)
		{
			GeoLocation geoLocation = time2.GetGeoLocation();
			SwissEph swissEph = new SwissEph();
			double[] array = new double[13];
			double[] ascmc = new double[10];
			swissEph.swe_set_sid_mode(Calculate.Ayanamsa, 0.0, 0.0);
			double num = Calculate.EclipticObliquity(time2);
			double num2 = HoraryNumberToSiderealAscendant(horaryNumber2);
			double num3 = Calculate.AscendantDegreesToARMC(num2, num, geoLocation.Latitude(), time2);
			double num4 = geoLocation.Latitude();
			Console.WriteLine("armc {0} eps {1} tropAsc {2} lat {3}", num3, num, num2, num4);
			swissEph.swe_houses_armc(num3, num4, num, 'P', array, ascmc);
			num3 = Calculate.AscendantDegreesToARMC(ascendant, num, geoLocation.Latitude(), time2);
			Dictionary<HouseName, Angle> dictionary = new Dictionary<HouseName, Angle>();
			foreach (HouseName allHouse3 in House.AllHouses)
			{
				double value = array[(int)allHouse3];
				dictionary.Add(allHouse3, Angle.FromDegrees(value));
			}
			return dictionary;
		}
		static Dictionary<HouseName, Angle> AllHouseCuspLongitudesRotateKundali(Time time2, double num)
		{
			GeoLocation geoLocation = time2.GetGeoLocation();
			SwissEph swissEph = new SwissEph();
			double[] array = new double[13];
			_ = new double[10];
			swissEph.swe_set_sid_mode(Calculate.Ayanamsa, 0.0, 0.0);
			geoLocation.Latitude();
			Dictionary<HouseName, Angle> dictionary = new Dictionary<HouseName, Angle>();
			foreach (HouseName allHouse4 in House.AllHouses)
			{
				double value = array[(int)allHouse4];
				dictionary.Add(allHouse4, Angle.FromDegrees(value));
			}
			return dictionary;
		}
	}

	public static double HoraryNumberToSiderealAscendant(int horaryNumber)
	{
		double num = 0.0;
		List<PlanetName> all9Planets = All9Planets;
		List<ConstellationName> allConstellation = Constellation.AllConstellation;
		List<Tuple<int, ZodiacName, PlanetName, ConstellationName, PlanetName, PlanetName, double>> list = new List<Tuple<int, ZodiacName, PlanetName, ConstellationName, PlanetName, PlanetName, double>>();
		double num2 = 0.0;
		foreach (ConstellationName item in allConstellation)
		{
			PlanetName planetName = Calculate.LordOfConstellation(item);
			PlanetName[] array = all9Planets.ToArray();
			int i = 0;
			int num3 = 0;
			for (; i <= 8; i++)
			{
				if (array[i] == planetName)
				{
					num3 = i;
					break;
				}
			}
			PlanetName[] array2 = new PlanetName[9];
			int num4 = 0;
			while (num4 <= 8)
			{
				array2[num4] = array[num3];
				num4++;
				num3++;
				if (num3 == array.Length)
				{
					num3 = 0;
				}
			}
			Calculate.ZodiacSignAtLongitude(Angle.FromDegrees(num2));
			Calculate.LordOfConstellation(Calculate.ConstellationAtLongitude(Angle.FromDegrees(num2)).GetConstellationName());
			num2 += num;
			Calculate.LordOfZodiacSign(Calculate.ZodiacSignAtLongitude(Angle.FromDegrees(num2)).GetSignName());
			Calculate.LordOfConstellation(Calculate.ConstellationAtLongitude(Angle.FromDegrees(num2)).GetConstellationName());
		}
		for (int j = 0; j <= 248; j++)
		{
			if (horaryNumber == 1)
			{
				num2 = 0.0;
				break;
			}
			if (list[j].Item1 == horaryNumber)
			{
				num2 = list[j - 1].Item7;
				break;
			}
		}
		return num2;
	}

	public static PlanetName SubLordAtLongitude(Angle longitude)
	{
		double num = 0.0;
		List<PlanetName> all9Planets = All9Planets;
		List<ConstellationName> allConstellation = Constellation.AllConstellation;
		List<Tuple<int, ZodiacName, PlanetName, ConstellationName, PlanetName, PlanetName, double>> list = new List<Tuple<int, ZodiacName, PlanetName, ConstellationName, PlanetName, PlanetName, double>>();
		double num2 = 0.0;
		foreach (ConstellationName item2 in allConstellation)
		{
			PlanetName planetName = Calculate.LordOfConstellation(item2);
			PlanetName[] array = all9Planets.ToArray();
			int i = 0;
			int num3 = 0;
			for (; i <= 8; i++)
			{
				if (array[i] == planetName)
				{
					num3 = i;
					break;
				}
			}
			PlanetName[] array2 = new PlanetName[9];
			int num4 = 0;
			while (num4 <= 8)
			{
				array2[num4] = array[num3];
				num4++;
				num3++;
				if (num3 == array.Length)
				{
					num3 = 0;
				}
			}
			PlanetName[] array3 = array2;
			for (int j = 0; j < array3.Length; j++)
			{
				_ = array3[j];
				Calculate.ZodiacSignAtLongitude(Angle.FromDegrees(num2));
				Calculate.LordOfConstellation(Calculate.ConstellationAtLongitude(Angle.FromDegrees(num2)).GetConstellationName());
				num2 += num;
				Calculate.LordOfZodiacSign(Calculate.ZodiacSignAtLongitude(Angle.FromDegrees(num2)).GetSignName());
				Calculate.LordOfConstellation(Calculate.ConstellationAtLongitude(Angle.FromDegrees(num2)).GetConstellationName());
			}
		}
		int k = 0;
		PlanetName item = list[k].Item6;
		for (; k <= 248; k++)
		{
			if (longitude.TotalDegrees < list[0].Item7)
			{
				item = list[0].Item6;
				break;
			}
			if (list[k].Item7 <= longitude.TotalDegrees && longitude.TotalDegrees <= list[k + 1].Item7)
			{
				item = list[k + 1].Item6;
				break;
			}
		}
		return item;
	}
}
