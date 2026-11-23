using System;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

[Serializable]
public struct LunarDay(int lunarDateNumber) : IToJson
{
	private readonly int _lunarDateNumber = lunarDateNumber;

	private readonly int _lunarDayNumber = ConvertLunarDateNumberToLunarDayNumber(lunarDateNumber);

	public int GetLunarDayNumber()
	{
		return _lunarDayNumber;
	}

	public int GetLunarDateNumber()
	{
		return _lunarDateNumber;
	}

	public LunarDayGroup GetLunarDayGroup()
	{
		if (_lunarDayNumber == 1 || _lunarDayNumber == 6 || _lunarDayNumber == 11)
		{
			return LunarDayGroup.Nanda;
		}
		if (_lunarDayNumber == 2 || _lunarDayNumber == 7 || _lunarDayNumber == 12)
		{
			return LunarDayGroup.Bhadra;
		}
		if (_lunarDayNumber == 3 || _lunarDayNumber == 8 || _lunarDayNumber == 13)
		{
			return LunarDayGroup.Jaya;
		}
		if (_lunarDayNumber == 4 || _lunarDayNumber == 9 || _lunarDayNumber == 14)
		{
			return LunarDayGroup.Rikta;
		}
		if (_lunarDayNumber == 5 || _lunarDayNumber == 10 || _lunarDayNumber == 15)
		{
			return LunarDayGroup.Purna;
		}
		throw new Exception("No lunar day group found!");
	}

	public MoonPhase GetMoonPhase()
	{
		if (_lunarDateNumber >= 1 && _lunarDateNumber <= 15)
		{
			return MoonPhase.BrightHalf;
		}
		if (_lunarDateNumber >= 16 && _lunarDateNumber <= 30)
		{
			return MoonPhase.DarkHalf;
		}
		throw new Exception("Moon phase not found, error!");
	}

	public string GetPaksha()
	{
		return GetMoonPhase() switch
		{
			MoonPhase.BrightHalf => "Sukla", 
			MoonPhase.DarkHalf => "Krishna", 
			_ => throw new Exception("END OF LINE!"), 
		};
	}

	public string GetTithiName()
	{
		return _lunarDateNumber switch
		{
			1 => "Padyami", 
			2 => "Vidiya", 
			3 => "Tadiya", 
			4 => "Chavithi", 
			5 => "Panchimi", 
			6 => "Sashti", 
			7 => "Saptami", 
			8 => "Ashtami", 
			9 => "Navami", 
			10 => "Dasimi", 
			11 => "Ekadasi", 
			12 => "Dwadasi", 
			13 => "Triodasi", 
			14 => "Chaturdasi", 
			15 => "Poornima", 
			16 => "Padyami", 
			17 => "Vidiya", 
			18 => "Tadiya", 
			19 => "Chavithi", 
			20 => "Panchimi", 
			21 => "Sashti", 
			22 => "Saptami", 
			23 => "Ashtami", 
			24 => "Navami", 
			25 => "Dasimi", 
			26 => "Ekadasi", 
			27 => "Dwadasi", 
			28 => "Triodasi", 
			29 => "Chaturdasi", 
			30 => "Amavasya", 
			_ => throw new Exception("END OF THE LINE!"), 
		};
	}

	private static int ConvertLunarDateNumberToLunarDayNumber(int lunarDateNumber)
	{
		int num = 0;
		if (lunarDateNumber <= 15)
		{
			return lunarDateNumber;
		}
		return lunarDateNumber - 15;
	}

	public override string ToString()
	{
		return $"Date:{_lunarDateNumber}/30 Day:{_lunarDayNumber}/15";
	}

	public JObject ToJson()
	{
		return new JObject
		{
			["Name"] = GetTithiName(),
			["Paksha"] = GetPaksha(),
			["Date"] = $"{_lunarDateNumber}/30",
			["Day"] = $"{_lunarDayNumber}/15",
			["Phase"] = GetMoonPhase().ToString()
		};
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(LunarDay))
		{
			LunarDay lunarDay = (LunarDay)value;
			return GetHashCode() == lunarDay.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = _lunarDateNumber.GetHashCode();
		int hashCode2 = _lunarDayNumber.GetHashCode();
		return hashCode + hashCode2;
	}
}
