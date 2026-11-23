using System;
using System.Collections.Generic;
using System.Linq;

namespace VedAstro.Library;

[Serializable]
public struct Constellation
{
	private const int QuarterMax = 4;

	private const int QuarterMin = 1;

	public static Constellation Empty = new Constellation(1, 1, Angle.FromDegrees(0.0));

	private readonly ConstellationName _name;

	private readonly int _quarter;

	private readonly Angle _degreeInConstellation;

	public static List<ConstellationName> AllConstellation => new List<ConstellationName>(((ConstellationName[])Enum.GetValues(typeof(ConstellationName))).Where((ConstellationName e) => e != ConstellationName.Empty));

	public Constellation(int constellationNumber, int quarter, Angle degreeInConstellation)
	{
		_name = (ConstellationName)constellationNumber;
		_quarter = quarter;
		_degreeInConstellation = degreeInConstellation;
		Angle zero = Angle.Zero;
		Angle angle = new Angle(0.0, 800.0, 0L);
		if (_degreeInConstellation < zero || _degreeInConstellation > angle)
		{
			throw new Exception("Degrees in constellation not valid!");
		}
	}

	public int GetConstellationNumber()
	{
		return (int)_name;
	}

	public ConstellationName GetConstellationName()
	{
		return _name;
	}

	public int GetQuarter()
	{
		return _quarter;
	}

	public Angle GetDegreesInConstellation()
	{
		return _degreeInConstellation;
	}

	public static bool operator ==(Constellation left, Constellation right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Constellation left, Constellation right)
	{
		return !(left == right);
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(Constellation))
		{
			Constellation constellation = (Constellation)value;
			return GetHashCode() == constellation.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = _name.GetHashCode();
		int hashCode2 = _quarter.GetHashCode();
		return hashCode + hashCode2;
	}

	public override string ToString()
	{
		return $"{_name} - {_quarter}";
	}
}
