using System;
using System.Collections.Generic;

namespace VedAstro.Library;

public static class Vargas
{
	public static Dictionary<ZodiacName, Dictionary<DegreeRange, ZodiacName>> HoraTable = new Dictionary<ZodiacName, Dictionary<DegreeRange, ZodiacName>>
	{
		{
			ZodiacName.Aries,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Leo
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Cancer
				}
			}
		},
		{
			ZodiacName.Taurus,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Leo
				}
			}
		},
		{
			ZodiacName.Gemini,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Leo
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Cancer
				}
			}
		},
		{
			ZodiacName.Cancer,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Leo
				}
			}
		},
		{
			ZodiacName.Leo,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Leo
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Cancer
				}
			}
		},
		{
			ZodiacName.Virgo,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Leo
				}
			}
		},
		{
			ZodiacName.Libra,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Leo
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Cancer
				}
			}
		},
		{
			ZodiacName.Scorpio,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Leo
				}
			}
		},
		{
			ZodiacName.Sagittarius,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Leo
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Cancer
				}
			}
		},
		{
			ZodiacName.Capricorn,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Leo
				}
			}
		},
		{
			ZodiacName.Aquarius,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Leo
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Cancer
				}
			}
		},
		{
			ZodiacName.Pisces,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 15.0),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(15.0, 30.0),
					ZodiacName.Leo
				}
			}
		}
	};

	public static Dictionary<ZodiacName, Dictionary<DegreeRange, ZodiacName>> DrekkanaTable = new Dictionary<ZodiacName, Dictionary<DegreeRange, ZodiacName>>
	{
		{
			ZodiacName.Aries,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Aries
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Leo
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Sagittarius
				}
			}
		},
		{
			ZodiacName.Taurus,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Taurus
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Virgo
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Capricorn
				}
			}
		},
		{
			ZodiacName.Gemini,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Gemini
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Libra
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Aquarius
				}
			}
		},
		{
			ZodiacName.Cancer,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Scorpio
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Pisces
				}
			}
		},
		{
			ZodiacName.Leo,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Leo
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Sagittarius
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Aries
				}
			}
		},
		{
			ZodiacName.Virgo,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Virgo
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Capricorn
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Taurus
				}
			}
		},
		{
			ZodiacName.Libra,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Libra
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Aquarius
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Gemini
				}
			}
		},
		{
			ZodiacName.Scorpio,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Scorpio
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Pisces
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Cancer
				}
			}
		},
		{
			ZodiacName.Sagittarius,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Sagittarius
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Aries
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Leo
				}
			}
		},
		{
			ZodiacName.Capricorn,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Capricorn
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Taurus
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Virgo
				}
			}
		},
		{
			ZodiacName.Aquarius,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Aquarius
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Gemini
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Libra
				}
			}
		},
		{
			ZodiacName.Pisces,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 10.0),
					ZodiacName.Pisces
				},
				{
					new DegreeRange(10.0, 20.0),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(20.0, 30.0),
					ZodiacName.Scorpio
				}
			}
		}
	};

	public static Dictionary<ZodiacName, Dictionary<DegreeRange, ZodiacName>> ChaturthamshaTable = new Dictionary<ZodiacName, Dictionary<DegreeRange, ZodiacName>>
	{
		{
			ZodiacName.Aries,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Aries
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Libra
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Capricorn
				}
			}
		},
		{
			ZodiacName.Taurus,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Taurus
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Leo
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Scorpio
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Aquarius
				}
			}
		},
		{
			ZodiacName.Gemini,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Gemini
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Virgo
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Sagittarius
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Pisces
				}
			}
		},
		{
			ZodiacName.Cancer,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Libra
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Capricorn
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Aries
				}
			}
		},
		{
			ZodiacName.Leo,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Leo
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Scorpio
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Aquarius
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Taurus
				}
			}
		},
		{
			ZodiacName.Virgo,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Virgo
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Sagittarius
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Pisces
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Gemini
				}
			}
		},
		{
			ZodiacName.Libra,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Libra
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Capricorn
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Aries
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Cancer
				}
			}
		},
		{
			ZodiacName.Scorpio,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Scorpio
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Aquarius
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Taurus
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Leo
				}
			}
		},
		{
			ZodiacName.Sagittarius,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Sagittarius
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Pisces
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Gemini
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Virgo
				}
			}
		},
		{
			ZodiacName.Capricorn,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Capricorn
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Aries
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Cancer
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Libra
				}
			}
		},
		{
			ZodiacName.Aquarius,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Aquarius
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Taurus
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Leo
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Scorpio
				}
			}
		},
		{
			ZodiacName.Pisces,
			new Dictionary<DegreeRange, ZodiacName>
			{
				{
					new DegreeRange(0.0, 7.5),
					ZodiacName.Pisces
				},
				{
					new DegreeRange(7.5, 15.0),
					ZodiacName.Gemini
				},
				{
					new DegreeRange(15.0, 22.5),
					ZodiacName.Virgo
				},
				{
					new DegreeRange(22.5, 30.0),
					ZodiacName.Sagittarius
				}
			}
		}
	};

	public static ZodiacSign VargasCoreCalculator(ZodiacSign zodiacSign, Dictionary<DegreeRange, ZodiacName> precomputedTable, int divisionNumber)
	{
		double totalDegrees = zodiacSign.GetDegreesInSign().TotalDegrees;
		foreach (KeyValuePair<DegreeRange, ZodiacName> item in precomputedTable)
		{
			bool num = item.Key.IsWithinRange(totalDegrees);
			ZodiacName value = item.Value;
			if (num)
			{
				Angle degreesInSign = Calculate.DivisionalLongitude(totalDegrees, divisionNumber);
				return new ZodiacSign(value, degreesInSign);
			}
		}
		throw new Exception("END OF LINE!");
	}
}
