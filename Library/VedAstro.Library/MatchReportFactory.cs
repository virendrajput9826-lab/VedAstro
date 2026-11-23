using System;
using System.Collections.Generic;
using System.Linq;

namespace VedAstro.Library;

public static class MatchReportFactory
{
	public static MatchReport GetNewMatchReport(Person male, Person female, string userId)
	{
		List<Func<Person, Person, MatchPrediction>> obj = new List<Func<Person, Person, MatchPrediction>>
		{
			GrahaMaitram, Rajju, NadiKuta, VasyaKuta, DinaKuta, GunaKuta, Mahendra, StreeDeergha, RasiKuta, VedhaKuta,
			Varna, YoniKuta, LagnaAndHouse7Good, KujaDosa, BadConstellations, SexEnergy
		};
		List<MatchPrediction> list = new List<MatchPrediction>();
		foreach (Func<Person, Person, MatchPrediction> item3 in obj)
		{
			MatchPrediction item;
			try
			{
				item = item3(male, female);
			}
			catch (Exception message)
			{
				LibLogger.Debug(message, "Male:" + male.Name + " Female:" + female.Name);
				item = MatchPrediction.Empty;
			}
			list.Add(item);
		}
		MatchReport report = new MatchReport(Tools.GenerateId(), male, female, 0.0, "...", list, new string[1] { userId });
		report.KutaScore = CalculateTotalPoints(report);
		report.Embeddings = CalculateEmbeddings(report);
		HandleExceptions(ref report);
		return report;
		static double CalculateTotalPoints(MatchReport matchReport)
		{
			double num = 0.0;
			foreach (MatchPrediction prediction in matchReport.PredictionList)
			{
				if (prediction.Nature == EventNature.Good)
				{
					switch (prediction.Name)
					{
					case MatchPredictionName.DinaKuta:
						num += 3.0;
						break;
					case MatchPredictionName.GunaKuta:
						num += 6.0;
						break;
					case MatchPredictionName.NadiKuta:
						num += 8.0;
						break;
					case MatchPredictionName.RasiKuta:
						num += 7.0;
						break;
					case MatchPredictionName.GrahaMaitram:
						num += 5.0;
						break;
					case MatchPredictionName.VasyaKuta:
						num += 2.0;
						break;
					case MatchPredictionName.Varna:
						num++;
						break;
					case MatchPredictionName.YoniKuta:
						num += 4.0;
						break;
					}
				}
			}
			return Math.Round(num / 36.0 * 100.0 / 5.0) * 5.0;
		}
		static void HandleExceptions(ref MatchReport reference)
		{
			List<MatchPrediction> predictionList = reference.PredictionList;
			streeDeerghaException(predictionList);
			rajjuException(predictionList);
			nadiKutaException(predictionList);
		}
		static void nadiKutaException(List<MatchPrediction> list2)
		{
			MatchPrediction matchPrediction = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.NadiKuta);
			MatchPrediction matchPrediction2 = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.RasiKuta);
			MatchPrediction matchPrediction3 = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.Rajju);
			bool num = matchPrediction != null && matchPrediction.Nature == EventNature.Bad;
			bool flag = matchPrediction2 != null && matchPrediction2.Nature == EventNature.Good;
			bool flag2 = matchPrediction3 != null && matchPrediction3.Nature == EventNature.Good;
			if (num & flag & flag2)
			{
				MatchPrediction item2 = new MatchPrediction
				{
					Name = matchPrediction.Name,
					Description = matchPrediction.Description,
					FemaleInfo = matchPrediction.FemaleInfo,
					MaleInfo = matchPrediction.MaleInfo,
					Info = "bad Nadi Kuta is neutralized by good Rasi Kuta and Rajju",
					Nature = EventNature.Neutral
				};
				list2.Remove(matchPrediction);
				list2.Add(item2);
			}
		}
		static void rajjuException(List<MatchPrediction> list2)
		{
			MatchPrediction matchPrediction = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.Rajju);
			MatchPrediction matchPrediction2 = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.GrahaMaitram);
			MatchPrediction matchPrediction3 = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.RasiKuta);
			MatchPrediction matchPrediction4 = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.DinaKuta);
			MatchPrediction matchPrediction5 = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.Mahendra);
			bool num = matchPrediction != null && matchPrediction.Nature == EventNature.Bad;
			bool flag = matchPrediction2 != null && matchPrediction2.Nature == EventNature.Good;
			bool flag2 = matchPrediction3 != null && matchPrediction3.Nature == EventNature.Good;
			bool flag3 = matchPrediction4 != null && matchPrediction4.Nature == EventNature.Good;
			bool flag4 = matchPrediction5 != null && matchPrediction5.Nature == EventNature.Good;
			if (num & flag & flag2 & flag3 & flag4)
			{
				MatchPrediction item2 = new MatchPrediction
				{
					Name = matchPrediction.Name,
					Description = matchPrediction.Description,
					FemaleInfo = matchPrediction.FemaleInfo,
					MaleInfo = matchPrediction.MaleInfo,
					Info = "bad Rajju Kuta is neutralized by good Graha Maitri, Rasi, Dina and Mahendra",
					Nature = EventNature.Neutral
				};
				list2.Remove(matchPrediction);
				list2.Add(item2);
			}
		}
		static void streeDeerghaException(List<MatchPrediction> list2)
		{
			MatchPrediction matchPrediction = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.StreeDeergha);
			MatchPrediction matchPrediction2 = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.RasiKuta);
			MatchPrediction matchPrediction3 = list2.Find((MatchPrediction pr) => pr.Name == MatchPredictionName.GrahaMaitram);
			bool num = matchPrediction != null && matchPrediction.Nature == EventNature.Bad;
			bool flag = matchPrediction2 != null && matchPrediction2.Nature == EventNature.Good;
			bool flag2 = matchPrediction3 != null && matchPrediction3.Nature == EventNature.Good;
			if (num & flag & flag2)
			{
				MatchPrediction item2 = new MatchPrediction
				{
					Name = matchPrediction.Name,
					Description = matchPrediction.Description,
					FemaleInfo = matchPrediction.FemaleInfo,
					MaleInfo = matchPrediction.MaleInfo,
					Info = "bad Stree-Deerga is neutralized by good Rasi Kuta and Graha Maitri",
					Nature = EventNature.Neutral
				};
				list2.Remove(matchPrediction);
				list2.Add(item2);
			}
		}
	}

	public static double[] CalculateEmbeddings(MatchReport report)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		foreach (MatchPrediction prediction in report.PredictionList)
		{
			if (prediction.Nature == EventNature.Good)
			{
				switch (prediction.Name)
				{
				case MatchPredictionName.DinaKuta:
					num8 = 3.0;
					break;
				case MatchPredictionName.GunaKuta:
					num7 = 6.0;
					break;
				case MatchPredictionName.NadiKuta:
					num6 = 8.0;
					break;
				case MatchPredictionName.RasiKuta:
					num5 = 7.0;
					break;
				case MatchPredictionName.GrahaMaitram:
					num4 = 5.0;
					break;
				case MatchPredictionName.VasyaKuta:
					num3 = 2.0;
					break;
				case MatchPredictionName.Varna:
					num2 = 1.0;
					break;
				case MatchPredictionName.YoniKuta:
					num = 4.0;
					break;
				}
			}
		}
		return new double[8] { num8, num7, num6, num5, num4, num3, num2, num };
	}

	public static MatchPrediction Mahendra(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.Mahendra,
			Description = "well-being and longevity"
		};
		Constellation end = Calculate.MoonConstellation(male.BirthTime);
		Constellation start = Calculate.MoonConstellation(female.BirthTime);
		matchPrediction.MaleInfo = end.ToString();
		matchPrediction.FemaleInfo = start.ToString();
		int num = Calculate.CountFromConstellationToConstellation(start, end);
		if (num == 4 || num == 7 || ((num == 10) | (num == 13)) || num == 16 || num == 19 || num == 22 || num == 25)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = $"promotes well-being and increases longevity, count {num}";
		}
		else
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = $"no well-being and no longevity, count {num}";
		}
		return matchPrediction;
	}

	public static MatchPrediction NadiKuta(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.NadiKuta,
			Description = "nervous energy compatibility (important)"
		};
		Constellation constellation = Calculate.MoonConstellation(male.BirthTime);
		Constellation constellation2 = Calculate.MoonConstellation(female.BirthTime);
		string text = getNadi(constellation.GetConstellationName());
		string text2 = getNadi(constellation2.GetConstellationName());
		matchPrediction.MaleInfo = text;
		matchPrediction.FemaleInfo = text2;
		if (text == text2)
		{
			PlanetName planetName = Calculate.LordOfZodiacSign(Calculate.PlanetZodiacSign(PlanetName.Moon, male.BirthTime).GetSignName());
			PlanetName planetName2 = Calculate.LordOfZodiacSign(Calculate.PlanetZodiacSign(PlanetName.Moon, female.BirthTime).GetSignName());
			bool flag = planetName == planetName2;
			PlanetToPlanetRelationship planetToPlanetRelationship = Calculate.PlanetPermanentRelationshipWithPlanet(planetName, planetName2);
			bool flag2 = (uint)(planetToPlanetRelationship - 2) <= 1u;
			bool flag3 = flag2;
			if (flag | flag3)
			{
				matchPrediction.Nature = EventNature.Neutral;
				matchPrediction.Info = "bad, but neutralized by friendly Janma Rasi lord";
			}
			else
			{
				matchPrediction.Nature = EventNature.Bad;
				matchPrediction.Info = "same type, should belong to different";
			}
		}
		else
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "agreement between the couple will be good";
		}
		return matchPrediction;
		static string getNadi(ConstellationName constellationName)
		{
			switch (constellationName)
			{
			case ConstellationName.Aswini:
			case ConstellationName.Aridra:
			case ConstellationName.Punarvasu:
			case ConstellationName.Uttara:
			case ConstellationName.Hasta:
			case ConstellationName.Jyesta:
			case ConstellationName.Moola:
			case ConstellationName.Satabhisha:
			case ConstellationName.Poorvabhadra:
				return "Vatha (wind)";
			case ConstellationName.Bharani:
			case ConstellationName.Mrigasira:
			case ConstellationName.Pushyami:
			case ConstellationName.Pubba:
			case ConstellationName.Chitta:
			case ConstellationName.Anuradha:
			case ConstellationName.Poorvashada:
			case ConstellationName.Dhanishta:
			case ConstellationName.Uttarabhadra:
				return "Pitha (bile)";
			case ConstellationName.Krithika:
			case ConstellationName.Rohini:
			case ConstellationName.Aslesha:
			case ConstellationName.Makha:
			case ConstellationName.Swathi:
			case ConstellationName.Vishhaka:
			case ConstellationName.Uttarashada:
			case ConstellationName.Sravana:
			case ConstellationName.Revathi:
				return "Sleshma (phlegm)";
			default:
				throw new ArgumentOutOfRangeException("constellation", constellationName, null);
			}
		}
	}

	public static MatchPrediction GunaKuta(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.GunaKuta,
			Description = "temperament and character compatibility"
		};
		Constellation start = Calculate.MoonConstellation(male.BirthTime);
		Constellation end = Calculate.MoonConstellation(female.BirthTime);
		Guna guna = getGuna(start.GetConstellationName());
		Guna guna2 = getGuna(end.GetConstellationName());
		matchPrediction.MaleInfo = guna.ToString();
		matchPrediction.FemaleInfo = guna2.ToString();
		bool flag = (uint)(guna - 2) <= 1u;
		bool flag2 = flag;
		bool flag3 = guna2 == Guna.RakshasaDemon;
		flag = (uint)(guna2 - 2) <= 1u;
		bool flag4 = flag;
		bool flag5 = guna == Guna.RakshasaDemon;
		if (guna == guna2)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "both are same " + Format.FormatName(guna2) + " Guna";
		}
		else if (flag2 & flag3)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "Manusha/Deva boy cannot marry a Rakshasa girl unless there are other neutralizing factors";
		}
		else if (flag4 & flag5)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "marriage between a Rakshasa boy and a Deva/Manusha girl is passable";
		}
		else
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "quarrels and disharmony";
		}
		if (Calculate.CountFromConstellationToConstellation(start, end) > 14 && matchPrediction.Nature == EventNature.Bad)
		{
			matchPrediction = new MatchPrediction
			{
				Name = matchPrediction.Name,
				Description = matchPrediction.Description,
				FemaleInfo = matchPrediction.FemaleInfo,
				MaleInfo = matchPrediction.MaleInfo,
				Info = "evil maybe ignored, female star is more than 14th from male's",
				Nature = EventNature.Neutral
			};
		}
		return matchPrediction;
		static Guna getGuna(ConstellationName constellation)
		{
			switch (constellation)
			{
			case ConstellationName.Aswini:
			case ConstellationName.Mrigasira:
			case ConstellationName.Punarvasu:
			case ConstellationName.Pushyami:
			case ConstellationName.Hasta:
			case ConstellationName.Swathi:
			case ConstellationName.Anuradha:
			case ConstellationName.Sravana:
			case ConstellationName.Revathi:
				return Guna.DevaAngel;
			case ConstellationName.Bharani:
			case ConstellationName.Rohini:
			case ConstellationName.Aridra:
			case ConstellationName.Pubba:
			case ConstellationName.Uttara:
			case ConstellationName.Poorvashada:
			case ConstellationName.Uttarashada:
			case ConstellationName.Poorvabhadra:
			case ConstellationName.Uttarabhadra:
				return Guna.ManushaHuman;
			case ConstellationName.Krithika:
			case ConstellationName.Aslesha:
			case ConstellationName.Makha:
			case ConstellationName.Chitta:
			case ConstellationName.Vishhaka:
			case ConstellationName.Jyesta:
			case ConstellationName.Moola:
			case ConstellationName.Dhanishta:
			case ConstellationName.Satabhisha:
				return Guna.RakshasaDemon;
			default:
				throw new Exception("");
			}
		}
	}

	public static MatchPrediction Varna(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.Varna,
			Description = "spiritual/ego compatibility"
		};
		Varna varna = Calculate.BirthVarna(male.BirthTime);
		matchPrediction.MaleInfo = Format.FormatName(varna.ToString());
		Varna varna2 = Calculate.BirthVarna(female.BirthTime);
		matchPrediction.FemaleInfo = Format.FormatName(varna2.ToString());
		if (varna2 > varna)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "girl higher Varna not good match to boy lower Varna";
		}
		if (varna > varna2 || varna == varna2)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "boy higher and girl lower or both same Varna, is good";
		}
		return matchPrediction;
	}

	public static MatchPrediction YoniKuta(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.YoniKuta,
			Description = "sex compatibility"
		};
		ConstellationName constellationName = Calculate.MoonConstellation(male.BirthTime).GetConstellationName();
		ConstellationName constellationName2 = Calculate.MoonConstellation(female.BirthTime).GetConstellationName();
		ConstellationAnimal constellationAnimal = Calculate.YoniKutaAnimalFromConstellation(constellationName);
		ConstellationAnimal constellationAnimal2 = Calculate.YoniKutaAnimalFromConstellation(constellationName2);
		AnimalName animal = constellationAnimal.Animal;
		AnimalName animal2 = constellationAnimal2.Animal;
		string gender = constellationAnimal.Gender;
		string gender2 = constellationAnimal2.Gender;
		int num = getAnimalCompatible(animal, animal2);
		matchPrediction.MaleInfo = $"{animal} - {gender}";
		matchPrediction.FemaleInfo = $"{animal2} - {gender2}";
		if (num <= 2)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "pairs are hostile, should be avoided.";
		}
		else
		{
			bool flag = animal == animal2;
			bool flag2 = gender == gender2;
			if (flag && !flag2)
			{
				matchPrediction.Nature = EventNature.Good;
				matchPrediction.Info = "favourable results to the fullest extent, harmony and progeny";
			}
			else if (flag & flag2)
			{
				matchPrediction.Nature = EventNature.Good;
				matchPrediction.Info = "not perfect, better than normal.";
			}
			bool num2 = num == 3;
			bool flag3 = gender2 == "Female" && gender == "Female";
			if (num2 & flag3)
			{
				matchPrediction.Nature = EventNature.Good;
				matchPrediction.Info = "fair happiness and agreement";
			}
			if (num2 && gender != gender2)
			{
				matchPrediction.Nature = EventNature.Good;
				matchPrediction.Info = "passable, not best but ok";
			}
			if (gender == "Male" && gender2 == "Male")
			{
				matchPrediction.Nature = EventNature.Bad;
				matchPrediction.Info = "both male constellations, constant quarrels and unhappiness";
			}
		}
		return matchPrediction;
		static int getAnimalCompatible(AnimalName a, AnimalName b)
		{
			return (new int[15, 15]
			{
				{
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0
				},
				{
					0, 4, 2, 2, 3, 2, 2, 2, 1, 0,
					1, 3, 3, 2, 1
				},
				{
					0, 2, 4, 3, 3, 2, 2, 2, 2, 3,
					1, 2, 3, 2, 0
				},
				{
					0, 2, 3, 4, 2, 1, 2, 1, 3, 3,
					1, 2, 0, 3, 1
				},
				{
					0, 3, 3, 2, 4, 2, 1, 1, 1, 1,
					2, 2, 2, 0, 2
				},
				{
					0, 2, 2, 1, 2, 4, 2, 1, 2, 2,
					1, 0, 2, 1, 1
				},
				{
					0, 2, 2, 2, 1, 2, 4, 0, 2, 2,
					1, 3, 3, 2, 1
				},
				{
					0, 2, 2, 1, 1, 1, 0, 4, 2, 2,
					2, 2, 2, 1, 2
				},
				{
					0, 1, 2, 3, 1, 2, 2, 2, 4, 3,
					0, 3, 2, 2, 1
				},
				{
					0, 0, 3, 3, 1, 2, 2, 2, 3, 4,
					1, 2, 2, 2, 1
				},
				{
					0, 1, 1, 1, 2, 1, 1, 2, 0, 1,
					4, 1, 1, 2, 1
				},
				{
					0, 1, 2, 2, 2, 0, 3, 2, 3, 2,
					1, 4, 2, 2, 1
				},
				{
					0, 3, 3, 0, 2, 2, 3, 2, 2, 2,
					1, 2, 4, 3, 2
				},
				{
					0, 2, 2, 3, 0, 1, 2, 1, 2, 2,
					2, 2, 3, 4, 2
				},
				{
					0, 1, 0, 1, 2, 1, 1, 2, 1, 2,
					1, 1, 2, 2, 4
				}
			})[(int)a, (int)b];
		}
	}

	public static MatchPrediction VedhaKuta(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.Vedha,
			Description = "birth constellations compatibility"
		};
		ConstellationName constellationName = Calculate.MoonConstellation(male.BirthTime).GetConstellationName();
		ConstellationName constellationName2 = Calculate.MoonConstellation(female.BirthTime).GetConstellationName();
		matchPrediction.MaleInfo = constellationName.ToString();
		matchPrediction.FemaleInfo = constellationName2.ToString();
		bool num = PairFound(constellationName, constellationName2);
		bool flag = PairFound(constellationName2, constellationName);
		if (num | flag)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "hostile constellation pair found";
		}
		else
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "constellation pair not hostile";
		}
		return matchPrediction;
		static bool PairFound(ConstellationName a, ConstellationName b)
		{
			if (a == ConstellationName.Aswini && b == ConstellationName.Jyesta)
			{
				return true;
			}
			if (a == ConstellationName.Bharani && b == ConstellationName.Anuradha)
			{
				return true;
			}
			if (a == ConstellationName.Krithika && b == ConstellationName.Vishhaka)
			{
				return true;
			}
			if (a == ConstellationName.Rohini && b == ConstellationName.Swathi)
			{
				return true;
			}
			if (a == ConstellationName.Aridra && b == ConstellationName.Sravana)
			{
				return true;
			}
			if (a == ConstellationName.Punarvasu && b == ConstellationName.Uttarashada)
			{
				return true;
			}
			if (a == ConstellationName.Pushyami && b == ConstellationName.Poorvashada)
			{
				return true;
			}
			if (a == ConstellationName.Aslesha && b == ConstellationName.Moola)
			{
				return true;
			}
			if (a == ConstellationName.Makha && b == ConstellationName.Revathi)
			{
				return true;
			}
			if (a == ConstellationName.Pubba && b == ConstellationName.Uttarabhadra)
			{
				return true;
			}
			if (a == ConstellationName.Uttara && b == ConstellationName.Poorvabhadra)
			{
				return true;
			}
			if (a == ConstellationName.Hasta && b == ConstellationName.Satabhisha)
			{
				return true;
			}
			if (a == ConstellationName.Mrigasira && b == ConstellationName.Dhanishta)
			{
				return true;
			}
			return false;
		}
	}

	public static MatchPrediction Rajju(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.Rajju,
			Description = "strength/duration of married life (important)"
		};
		ConstellationName constellationName = Calculate.MoonConstellation(male.BirthTime).GetConstellationName();
		ConstellationName constellationName2 = Calculate.MoonConstellation(female.BirthTime).GetConstellationName();
		string text = GetGroupName(constellationName);
		string text2 = GetGroupName(constellationName2);
		matchPrediction.MaleInfo = text;
		matchPrediction.FemaleInfo = text2;
		if (text == text2 && text == "Sira")
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "Sira (head) husband's death is likely";
		}
		else if (text == text2 && text == "Kanta")
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "Kantha (neck) the wife may die";
		}
		else if (text == text2 && text == "Udara")
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "Udara (stomach) the children may die";
		}
		else if (text == text2 && text == "Kati")
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "Kati (waist) poverty may ensue";
		}
		else if (text == text2 && text == "Pada")
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "Pada (foot) the couple may be always wandering";
		}
		else
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "both constellations are in different groups";
		}
		return matchPrediction;
		static string GetGroupName(ConstellationName name)
		{
			if (new List<ConstellationName>
			{
				ConstellationName.Aswini,
				ConstellationName.Aslesha,
				ConstellationName.Makha,
				ConstellationName.Jyesta,
				ConstellationName.Moola,
				ConstellationName.Revathi
			}.FindAll((ConstellationName constellation) => constellation == name).Any())
			{
				return "Pada";
			}
			if (new List<ConstellationName>
			{
				ConstellationName.Bharani,
				ConstellationName.Pushyami,
				ConstellationName.Pubba,
				ConstellationName.Anuradha,
				ConstellationName.Uttarabhadra,
				ConstellationName.Poorvashada
			}.FindAll((ConstellationName constellation) => constellation == name).Any())
			{
				return "Kati";
			}
			if (new List<ConstellationName>
			{
				ConstellationName.Krithika,
				ConstellationName.Punarvasu,
				ConstellationName.Uttara,
				ConstellationName.Vishhaka,
				ConstellationName.Uttarashada,
				ConstellationName.Poorvabhadra
			}.FindAll((ConstellationName constellation) => constellation == name).Any())
			{
				return "Udara";
			}
			if (new List<ConstellationName>
			{
				ConstellationName.Rohini,
				ConstellationName.Aridra,
				ConstellationName.Hasta,
				ConstellationName.Swathi,
				ConstellationName.Sravana,
				ConstellationName.Satabhisha
			}.FindAll((ConstellationName constellation) => constellation == name).Any())
			{
				return "Kanta";
			}
			if (new List<ConstellationName>
			{
				ConstellationName.Dhanishta,
				ConstellationName.Chitta,
				ConstellationName.Mrigasira
			}.FindAll((ConstellationName constellation) => constellation == name).Any())
			{
				return "Sira";
			}
			return "";
		}
	}

	public static MatchPrediction VasyaKuta(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.VasyaKuta,
			Description = "degree of magnetic control"
		};
		ZodiacName signName = Calculate.PlanetZodiacSign(PlanetName.Moon, male.BirthTime).GetSignName();
		ZodiacName signName2 = Calculate.PlanetZodiacSign(PlanetName.Moon, female.BirthTime).GetSignName();
		matchPrediction.MaleInfo = signName.ToString();
		matchPrediction.FemaleInfo = signName2.ToString();
		ZodiacName zodiacName = signName;
		ZodiacName zodiacName2 = signName2;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		while (true)
		{
			if (num == 1)
			{
				zodiacName = signName2;
				zodiacName2 = signName;
			}
			if (zodiacName == ZodiacName.Aries && ((zodiacName2 == ZodiacName.Leo || zodiacName2 == ZodiacName.Scorpio) ? true : false))
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Taurus && ((zodiacName2 == ZodiacName.Cancer || zodiacName2 == ZodiacName.Libra) ? true : false))
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Gemini && zodiacName2 == ZodiacName.Virgo)
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Cancer && (uint)(zodiacName2 - 8) <= 1u)
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Leo && zodiacName2 == ZodiacName.Libra)
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Virgo && ((zodiacName2 == ZodiacName.Gemini || zodiacName2 == ZodiacName.Pisces) ? true : false))
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Libra && ((zodiacName2 == ZodiacName.Virgo || zodiacName2 == ZodiacName.Capricorn) ? true : false))
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Scorpio && zodiacName2 == ZodiacName.Cancer)
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Sagittarius && zodiacName2 == ZodiacName.Pisces)
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Capricorn && ((zodiacName2 == ZodiacName.Aries || zodiacName2 == ZodiacName.Aquarius) ? true : false))
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Aquarius && zodiacName2 == ZodiacName.Aries)
			{
				flag = true;
			}
			if (zodiacName == ZodiacName.Pisces && zodiacName2 == ZodiacName.Capricorn)
			{
				flag = true;
			}
			switch (num)
			{
			case 0:
				goto IL_018f;
			case 1:
				flag2 = flag;
				break;
			}
			break;
			IL_018f:
			flag3 = flag;
			num++;
		}
		if (flag3)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "male controls female";
		}
		else if (flag2)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "female controls male";
		}
		else
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "neither controls the other";
		}
		return matchPrediction;
	}

	public static MatchPrediction GrahaMaitram(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.GrahaMaitram,
			Description = "happiness, mental compatibility (important)"
		};
		ZodiacName signName = Calculate.PlanetZodiacSign(PlanetName.Moon, male.BirthTime).GetSignName();
		ZodiacName signName2 = Calculate.PlanetZodiacSign(PlanetName.Moon, female.BirthTime).GetSignName();
		PlanetName planetName = Calculate.LordOfZodiacSign(signName);
		PlanetName planetName2 = Calculate.LordOfZodiacSign(signName2);
		PlanetToPlanetRelationship planetToPlanetRelationship = Calculate.PlanetPermanentRelationshipWithPlanet(planetName, planetName2);
		PlanetToPlanetRelationship planetToPlanetRelationship2 = Calculate.PlanetPermanentRelationshipWithPlanet(planetName2, planetName);
		matchPrediction.MaleInfo = planetToPlanetRelationship.ToString() + " Sign";
		matchPrediction.FemaleInfo = planetToPlanetRelationship2.ToString() + " Sign";
		bool flag = (uint)(planetToPlanetRelationship - 2) <= 1u;
		bool flag2 = flag;
		flag = (uint)(planetToPlanetRelationship2 - 2) <= 1u;
		bool flag3 = flag;
		flag = (uint)(planetToPlanetRelationship - 4) <= 1u;
		bool flag4 = flag;
		flag = (uint)(planetToPlanetRelationship2 - 4) <= 1u;
		bool flag5 = flag;
		bool flag6 = planetToPlanetRelationship == PlanetToPlanetRelationship.Neutral;
		bool flag7 = planetToPlanetRelationship2 == PlanetToPlanetRelationship.Neutral;
		bool flag8 = flag2 | flag3;
		bool flag9 = flag6 | flag7;
		if (flag2 & flag3)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "Rasi Kuta is said to obtain in full.";
		}
		else if (flag8 & flag9)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "one is friend and the other a neutral, it is passable";
		}
		else if (flag6 & flag7)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "both are neutral Rasi Kuta is very ordinary";
		}
		else if (flag4 & flag5)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "both are enemies, must be avoided";
		}
		else
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "no good connection between these horoscopes";
		}
		return matchPrediction;
	}

	public static MatchPrediction RasiKuta(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.RasiKuta,
			Description = "rasi compatibility"
		};
		ZodiacName signName = Calculate.PlanetZodiacSign(PlanetName.Moon, male.BirthTime).GetSignName();
		ZodiacName signName2 = Calculate.PlanetZodiacSign(PlanetName.Moon, female.BirthTime).GetSignName();
		int num = Calculate.CountFromSignToSign(signName2, signName);
		int num2 = Calculate.CountFromSignToSign(signName, signName2);
		matchPrediction.MaleInfo = signName.ToString();
		matchPrediction.FemaleInfo = signName2.ToString();
		if (num == 2 || num2 == 12)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "evil results will follow";
		}
		if (num == 12 || num2 == 2)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "longevity for the couple";
		}
		if (num == 3)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "misery and sorrow";
		}
		if (num2 == 3)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "happiness";
		}
		if (num == 4)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "great poverty";
		}
		if (num2 == 4)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "great wealth";
		}
		if (num == 5)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "unhappiness";
		}
		if (num2 == 5)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "enjoyment and prosperity";
		}
		if (num2 == 7 && num == 7)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "health, agreement and happiness";
		}
		if (num == 6)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "loss of children";
		}
		if (num2 == 6)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "progeny will prosper";
		}
		if (signName == signName2)
		{
			int constellationNumber = Calculate.MoonConstellation(male.BirthTime).GetConstellationNumber();
			int constellationNumber2 = Calculate.MoonConstellation(female.BirthTime).GetConstellationNumber();
			if (constellationNumber < constellationNumber2)
			{
				matchPrediction.Nature = EventNature.Good;
				matchPrediction.Info = "male constellation precede female, marriage to prove happy";
			}
			if (constellationNumber2 < constellationNumber)
			{
				matchPrediction.Nature = EventNature.Bad;
				matchPrediction.Info = "female constellation precede male, alliance should be rejected.";
			}
			if (constellationNumber2 == constellationNumber)
			{
				matchPrediction.Nature = EventNature.Bad;
				matchPrediction.Info = "same constellation, alliance should be rejected.";
			}
		}
		if (matchPrediction.Nature == EventNature.Bad)
		{
			PlanetName planetName = Calculate.LordOfZodiacSign(Calculate.PlanetZodiacSign(PlanetName.Moon, male.BirthTime).GetSignName());
			PlanetName planetName2 = Calculate.LordOfZodiacSign(Calculate.PlanetZodiacSign(PlanetName.Moon, female.BirthTime).GetSignName());
			bool flag = planetName == planetName2;
			PlanetToPlanetRelationship planetToPlanetRelationship = Calculate.PlanetPermanentRelationshipWithPlanet(planetName, planetName2);
			bool flag2 = (uint)(planetToPlanetRelationship - 2) <= 1u;
			bool flag3 = flag2;
			if (flag | flag3)
			{
				matchPrediction = new MatchPrediction
				{
					Name = matchPrediction.Name,
					Description = matchPrediction.Description,
					FemaleInfo = matchPrediction.FemaleInfo,
					MaleInfo = matchPrediction.MaleInfo,
					Info = "bad, but neutralized by friendly Janma Rasi lord",
					Nature = EventNature.Neutral
				};
			}
		}
		return matchPrediction;
	}

	public static MatchPrediction StreeDeergha(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.StreeDeergha,
			Description = "husband well being, longevity and prosperity"
		};
		Constellation end = Calculate.MoonConstellation(male.BirthTime);
		Constellation start = Calculate.MoonConstellation(female.BirthTime);
		matchPrediction.MaleInfo = end.ToString();
		matchPrediction.FemaleInfo = start.ToString();
		int num = Calculate.CountFromConstellationToConstellation(start, end);
		if (num >= 9)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = $"constellation count beyond 9, it is {num}";
		}
		else
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = $"constellation count lower than 9, it is {num}";
		}
		return matchPrediction;
	}

	public static MatchPrediction DinaKuta(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.DinaKuta,
			Description = "day to day living compatibility"
		};
		ZodiacName signName = Calculate.PlanetZodiacSign(PlanetName.Moon, male.BirthTime).GetSignName();
		ZodiacName signName2 = Calculate.PlanetZodiacSign(PlanetName.Moon, female.BirthTime).GetSignName();
		matchPrediction.MaleInfo = signName.ToString();
		matchPrediction.FemaleInfo = signName2.ToString();
		int num = Calculate.CountFromSignToSign(signName2, signName) % 9;
		if (num == 2 || num == 4 || num == 6 || num == 8 || num == 0)
		{
			matchPrediction.Nature = EventNature.Good;
		}
		else
		{
			matchPrediction.Nature = EventNature.Bad;
		}
		matchPrediction.Info = $"remainder is {num}";
		return matchPrediction;
	}

	public static MatchPrediction LagnaAndHouse7Good(Person male, Person female)
	{
		ZodiacName signName = Calculate.PlanetZodiacSign(PlanetName.Moon, male.BirthTime).GetSignName();
		ZodiacName signName2 = Calculate.PlanetZodiacSign(PlanetName.Moon, female.BirthTime).GetSignName();
		ZodiacName zodiacName = Calculate.HouseSignName(HouseName.House1, male.BirthTime);
		ZodiacName zodiacName2 = Calculate.HouseSignName(HouseName.House1, female.BirthTime);
		bool num = signName2 == zodiacName;
		bool flag = signName == zodiacName2;
		bool num2 = num | flag;
		PlanetName planetName = Calculate.LordOfHouse(HouseName.House7, female.BirthTime);
		PlanetName planetName2 = Calculate.LordOfHouse(HouseName.House7, male.BirthTime);
		ZodiacName signName3 = Calculate.PlanetZodiacSign(planetName, female.BirthTime).GetSignName();
		bool num3 = Calculate.CountFromSignToSign(Calculate.PlanetZodiacSign(planetName2, male.BirthTime).GetSignName(), zodiacName2) == 7;
		bool flag2 = Calculate.CountFromSignToSign(signName3, zodiacName) == 7;
		bool flag3 = num3 | flag2;
		bool num4 = num2 | flag3;
		MatchPrediction matchPrediction = new MatchPrediction();
		if (num4)
		{
			matchPrediction.Name = MatchPredictionName.LagnaAnd7thGood;
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "marriage stable, mutual understanding and affection";
			matchPrediction.Description = "special combination";
			matchPrediction.MaleInfo = zodiacName.ToString();
			matchPrediction.FemaleInfo = zodiacName2.ToString();
		}
		return matchPrediction;
	}

	public static MatchPrediction KujaDosa(Person male, Person female)
	{
		double maleScore = getTotalDosaScore(male.BirthTime);
		double femaleScore = getTotalDosaScore(female.BirthTime);
		return interpretScore(maleScore, femaleScore);
		static double getDosaScoreForPlanet(PlanetName planet, Time birthTime)
		{
			HouseName houseName = Calculate.HousePlanetOccupies(planet, birthTime);
			ZodiacName signName = Calculate.PlanetZodiacSign(planet, birthTime).GetSignName();
			bool flag = houseName == HouseName.House7 || houseName == HouseName.House8;
			bool flag2 = houseName == HouseName.House2 || houseName == HouseName.House4 || houseName == HouseName.House12;
			bool flag3 = planet == PlanetName.Saturn || planet == PlanetName.Rahu || planet == PlanetName.Ketu;
			bool flag4 = planet == PlanetName.Mars;
			bool flag5 = planet == PlanetName.Sun;
			if (!flag && !flag2)
			{
				return 0.0;
			}
			bool flag6 = signName == ZodiacName.Gemini || signName == ZodiacName.Virgo;
			if ((planet == PlanetName.Mars && houseName == HouseName.House2) & flag6)
			{
				return 0.0;
			}
			bool flag7 = signName == ZodiacName.Taurus || signName == ZodiacName.Libra;
			if ((planet == PlanetName.Mars && houseName == HouseName.House12) & flag7)
			{
				return 0.0;
			}
			bool flag8 = signName == ZodiacName.Aries || signName == ZodiacName.Scorpio;
			if ((planet == PlanetName.Mars && houseName == HouseName.House4) & flag8)
			{
				return 0.0;
			}
			bool flag9 = signName == ZodiacName.Capricorn || signName == ZodiacName.Cancer;
			if ((planet == PlanetName.Mars && houseName == HouseName.House7) & flag9)
			{
				return 0.0;
			}
			bool flag10 = signName == ZodiacName.Sagittarius || signName == ZodiacName.Pisces;
			if ((planet == PlanetName.Mars && houseName == HouseName.House8) & flag10)
			{
				return 0.0;
			}
			bool flag11 = signName == ZodiacName.Aquarius || signName == ZodiacName.Leo;
			if ((planet == PlanetName.Mars) & flag11)
			{
				return 0.0;
			}
			bool num = Calculate.IsPlanetConjunctWithPlanet(PlanetName.Mars, PlanetName.Jupiter, birthTime);
			bool flag12 = Calculate.IsPlanetConjunctWithPlanet(PlanetName.Mars, PlanetName.Moon, birthTime);
			if (num & flag12)
			{
				return 0.0;
			}
			bool num2 = Calculate.IsPlanetInHouse(PlanetName.Jupiter, HouseName.House1, birthTime);
			bool flag13 = Calculate.IsPlanetInHouse(PlanetName.Venus, HouseName.House1, birthTime);
			if (num2 | flag13)
			{
				return 0.0;
			}
			bool flag14 = Calculate.IsPlanetDebilitated(planet, birthTime);
			bool flag15 = Calculate.IsPlanetExalted(planet, birthTime);
			if (planet == PlanetName.Rahu || planet == PlanetName.Ketu)
			{
				signName = Calculate.PlanetZodiacSign(planet = Calculate.LordOfZodiacSign(signName), birthTime).GetSignName();
			}
			PlanetToSignRelationship planetToSignRelationship = Calculate.PlanetRelationshipWithSign(planet, signName, birthTime);
			bool flag16 = false;
			bool flag17 = false;
			bool flag18 = false;
			bool flag19 = false;
			switch (planetToSignRelationship)
			{
			case PlanetToSignRelationship.OwnVarga:
				flag17 = true;
				break;
			case PlanetToSignRelationship.BestFriendVarga:
			case PlanetToSignRelationship.FriendVarga:
				flag19 = true;
				break;
			case PlanetToSignRelationship.NeutralVarga:
				flag18 = true;
				break;
			case PlanetToSignRelationship.EnemyVarga:
			case PlanetToSignRelationship.BitterEnemyVarga:
				flag16 = true;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (new bool[6] { flag16, flag17, flag18, flag19, flag14, flag15 }.Sum((bool x) => x ? 1 : 0) > 1)
			{
				throw new Exception("Something wrong, more than 1 relationship found!");
			}
			if (flag)
			{
				if (flag14)
				{
					if (flag4)
					{
						return 100.0;
					}
					if (flag3)
					{
						return 75.0;
					}
					if (flag5)
					{
						return 50.0;
					}
				}
				else if (flag16)
				{
					if (flag4)
					{
						return 90.0;
					}
					if (flag3)
					{
						return 67.5;
					}
					if (flag5)
					{
						return 45.0;
					}
				}
				else if (flag18)
				{
					if (flag4)
					{
						return 80.0;
					}
					if (flag3)
					{
						return 60.0;
					}
					if (flag5)
					{
						return 40.0;
					}
				}
				else if (flag19)
				{
					if (flag4)
					{
						return 70.0;
					}
					if (flag3)
					{
						return 52.5;
					}
					if (flag5)
					{
						return 35.0;
					}
				}
				else if (flag17)
				{
					if (flag4)
					{
						return 60.0;
					}
					if (flag3)
					{
						return 45.0;
					}
					if (flag5)
					{
						return 30.0;
					}
				}
				else if (flag15)
				{
					if (flag4)
					{
						return 50.0;
					}
					if (flag3)
					{
						return 37.5;
					}
					if (flag5)
					{
						return 25.0;
					}
				}
			}
			if (flag2)
			{
				if (flag14)
				{
					if (flag4)
					{
						return 50.0;
					}
					if (flag3)
					{
						return 37.5;
					}
					if (flag5)
					{
						return 25.0;
					}
				}
				else if (flag16)
				{
					if (flag4)
					{
						return 45.0;
					}
					if (flag3)
					{
						return 33.75;
					}
					if (flag5)
					{
						return 22.5;
					}
				}
				else if (flag18)
				{
					if (flag4)
					{
						return 40.0;
					}
					if (flag3)
					{
						return 30.0;
					}
					if (flag5)
					{
						return 20.0;
					}
				}
				else if (flag19)
				{
					if (flag4)
					{
						return 35.0;
					}
					if (flag3)
					{
						return 26.25;
					}
					if (flag5)
					{
						return 17.5;
					}
				}
				else if (flag17)
				{
					if (flag4)
					{
						return 30.0;
					}
					if (flag3)
					{
						return 22.5;
					}
					if (flag5)
					{
						return 15.0;
					}
				}
				else if (flag15)
				{
					if (flag4)
					{
						return 25.0;
					}
					if (flag3)
					{
						return 18.75;
					}
					if (flag5)
					{
						return 12.5;
					}
				}
			}
			return 0.0;
		}
		static double getTotalDosaScore(Time birthTime)
		{
			List<PlanetName> obj = new List<PlanetName>
			{
				PlanetName.Mars,
				PlanetName.Saturn,
				PlanetName.Rahu,
				PlanetName.Ketu,
				PlanetName.Sun
			};
			double num = 0.0;
			foreach (PlanetName item in obj)
			{
				num += getDosaScoreForPlanet(item, birthTime);
			}
			return num;
		}
		MatchPrediction interpretScore(double scoreMale, double scoreFemale)
		{
			MatchPrediction matchPrediction = new MatchPrediction
			{
				Name = MatchPredictionName.KujaDosa,
				Description = "if bad, may cause death/bad health to spouse"
			};
			matchPrediction.MaleInfo = maleScore.ToString();
			matchPrediction.FemaleInfo = femaleScore.ToString();
			double num = Math.Abs(scoreMale - scoreFemale);
			int num2 = 5;
			bool flag = num <= (double)num2;
			if (flag)
			{
				matchPrediction.Nature = EventNature.Good;
				matchPrediction.Info = "match is good, dosha in both are equal or close";
			}
			else if (scoreFemale > scoreMale)
			{
				matchPrediction.Nature = EventNature.Bad;
				matchPrediction.Info = "charts cannot be matched, female chart has more dosha";
			}
			if (scoreMale > scoreFemale && !flag)
			{
				double num3 = scoreFemale * 0.25;
				if (scoreMale - scoreFemale < num3)
				{
					matchPrediction.Nature = EventNature.Good;
					matchPrediction.Info = "it is passable, male dosha below 25% of female";
				}
				else
				{
					matchPrediction.Nature = EventNature.Bad;
					matchPrediction.Info = "charts cannot be matched, male dosha above 25% of female";
				}
			}
			return matchPrediction;
		}
	}

	public static MatchPrediction BadConstellations(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.BadConstellation,
			Description = "checks if evil constellation is in chart"
		};
		Constellation constellation = Calculate.MoonConstellation(female.BirthTime);
		Constellation constellation2 = Calculate.MoonConstellation(male.BirthTime);
		bool num = constellation.GetConstellationName() == ConstellationName.Moola && constellation.GetQuarter() == 1;
		bool flag = constellation2.GetConstellationName() == ConstellationName.Moola && constellation2.GetQuarter() == 1;
		if (num | flag)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "cause the death of the father-in-law";
		}
		if (constellation.GetConstellationName() == ConstellationName.Aslesha && constellation.GetQuarter() == 1)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "cause evil to husband's mother";
		}
		if (constellation.GetConstellationName() == ConstellationName.Jyesta && constellation.GetQuarter() == 1)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "cause evil to husband's elder brother";
		}
		if (constellation.GetConstellationName() == ConstellationName.Vishhaka && constellation.GetQuarter() == 4)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "cause evil to husband's younger brother";
		}
		if (matchPrediction.Info == "")
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "no evil constellation in either person";
		}
		return matchPrediction;
	}

	public static MatchPrediction SexEnergy(Person male, Person female)
	{
		MatchPrediction matchPrediction = new MatchPrediction
		{
			Name = MatchPredictionName.SexEnergy,
			Description = "sexual compatibility based on planets in 7th house"
		};
		bool occuring = CalculateHoroscope.MarsVenusIn7th(male.BirthTime).Occuring;
		bool occuring2 = CalculateHoroscope.MarsVenusIn7th(female.BirthTime).Occuring;
		bool occuring3 = CalculateHoroscope.MercuryOrJupiterIn7th(male.BirthTime).Occuring;
		bool occuring4 = CalculateHoroscope.MercuryOrJupiterIn7th(female.BirthTime).Occuring;
		if (occuring)
		{
			matchPrediction.MaleInfo = "Strong Sex";
		}
		if (occuring2)
		{
			matchPrediction.FemaleInfo = "Strong Sex";
		}
		if (occuring3)
		{
			matchPrediction.MaleInfo = "Under-Sexed";
		}
		if (occuring4)
		{
			matchPrediction.FemaleInfo = "Under-Sexed";
		}
		bool num = occuring & occuring3;
		bool flag = occuring2 & occuring4;
		if (num | flag)
		{
			return matchPrediction;
		}
		if (occuring & occuring2)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "both horoscope Mars & Venus In 7th (strong sex)";
		}
		if (occuring3 & occuring4)
		{
			matchPrediction.Nature = EventNature.Good;
			matchPrediction.Info = "both horoscope Mercury Or Jupiter In 7th (under-sexed)";
		}
		if (occuring3 & occuring2)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "male under-sexed & female strong sex";
		}
		if (occuring & occuring4)
		{
			matchPrediction.Nature = EventNature.Bad;
			matchPrediction.Info = "male strong sex & female under-sexed";
		}
		if (matchPrediction.Info == "")
		{
			matchPrediction.Nature = EventNature.Neutral;
			matchPrediction.Info = "no evil or good, neutral result";
		}
		return matchPrediction;
	}
}
