using System;

namespace VedAstro.Library;

public struct Shashtiamsa(double shashtiamsa)
{
	public static readonly Shashtiamsa Zero = new Shashtiamsa(0.0);

	private double _shashtiamsaAsDouble = shashtiamsa;

	public double ToDouble()
	{
		return _shashtiamsaAsDouble;
	}

	public double ToDouble(int roundPrecision)
	{
		return Math.Round(_shashtiamsaAsDouble, roundPrecision);
	}

	public double ToRupa()
	{
		return _shashtiamsaAsDouble / 60.0;
	}

	public static Shashtiamsa operator +(Shashtiamsa left, Shashtiamsa right)
	{
		return new Shashtiamsa(left._shashtiamsaAsDouble + right._shashtiamsaAsDouble);
	}

	public static Shashtiamsa operator -(Shashtiamsa left, Shashtiamsa right)
	{
		return new Shashtiamsa(left._shashtiamsaAsDouble - right._shashtiamsaAsDouble);
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(Shashtiamsa))
		{
			Shashtiamsa shashtiamsa = (Shashtiamsa)value;
			return GetHashCode() == shashtiamsa.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _shashtiamsaAsDouble.GetHashCode();
	}

	public override string ToString()
	{
		return $"{_shashtiamsaAsDouble}";
	}
}
