using System;
using System.Collections.Generic;

namespace VedAstro.Library;

[Serializable]
public struct House(HouseName houseNumber, Angle beginLongitude, Angle middleLongitude, Angle endLongitude)
{
	private Angle _middleLongitude = middleLongitude;

	private Angle _beginLongitude = beginLongitude;

	private Angle _endLongitude = endLongitude;

	private HouseName _houseNumber = houseNumber;

	public static readonly List<HouseName> AllHouses = new List<HouseName>
	{
		HouseName.House1,
		HouseName.House2,
		HouseName.House3,
		HouseName.House4,
		HouseName.House5,
		HouseName.House6,
		HouseName.House7,
		HouseName.House8,
		HouseName.House9,
		HouseName.House10,
		HouseName.House11,
		HouseName.House12
	};

	public HouseName GetHouseName()
	{
		return _houseNumber;
	}

	public Angle GetMiddleLongitude()
	{
		return _middleLongitude;
	}

	public Angle GetBeginLongitude()
	{
		return _beginLongitude;
	}

	public Angle GetEndLongitude()
	{
		return _endLongitude;
	}

	public bool IsLongitudeInHouseRange(Angle longitude)
	{
		if (_endLongitude < _beginLongitude)
		{
			if (longitude >= _beginLongitude && longitude <= Angle.Degrees360)
			{
				return true;
			}
			if (longitude >= Angle.Zero && longitude < _endLongitude)
			{
				return true;
			}
		}
		else if (longitude >= _beginLongitude && longitude < _endLongitude)
		{
			return true;
		}
		return false;
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(House))
		{
			House house = (House)value;
			return GetHashCode() == house.GetHashCode();
		}
		return false;
	}

	public override string ToString()
	{
		return $"House {_houseNumber} - Begin:{_beginLongitude.Rounded}, Middle:{_middleLongitude.Rounded}, End:{_endLongitude.Rounded}";
	}

	public override int GetHashCode()
	{
		int hashCode = _houseNumber.GetHashCode();
		int hashCode2 = _beginLongitude.GetHashCode();
		int hashCode3 = _middleLongitude.GetHashCode();
		int hashCode4 = _endLongitude.GetHashCode();
		return hashCode + hashCode2 + hashCode3 + hashCode4;
	}
}
