using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

[Serializable]
public struct ZodiacSign(ZodiacName signName, Angle degreesInSign) : IToJson
{
	public static readonly List<ZodiacName> All12ZodiacNames = new List<ZodiacName>
	{
		ZodiacName.Aries,
		ZodiacName.Taurus,
		ZodiacName.Gemini,
		ZodiacName.Cancer,
		ZodiacName.Leo,
		ZodiacName.Virgo,
		ZodiacName.Libra,
		ZodiacName.Scorpio,
		ZodiacName.Sagittarius,
		ZodiacName.Capricorn,
		ZodiacName.Aquarius,
		ZodiacName.Pisces
	};

	private readonly ZodiacName _signName = signName;

	private readonly Angle _degreesInSign = degreesInSign;

	public static ZodiacSign Empty = new ZodiacSign(ZodiacName.Empty, Angle.Zero);

	public ZodiacName GetSignName()
	{
		return _signName;
	}

	public Angle GetDegreesInSign()
	{
		return _degreesInSign;
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(ZodiacSign))
		{
			ZodiacSign zodiacSign = (ZodiacSign)value;
			return GetHashCode() == zodiacSign.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = _signName.GetHashCode();
		int hashCode2 = _degreesInSign.GetHashCode();
		return hashCode + hashCode2;
	}

	public override string ToString()
	{
		string value = $"{_degreesInSign?.Degrees ?? 0}° {Math.Abs(_degreesInSign?.Minutes ?? 0)}' {Math.Abs(_degreesInSign?.Seconds ?? 0)}";
		return $"{_signName} : {value}";
	}

	public JObject ToJson()
	{
		return new JObject
		{
			["Name"] = _signName.ToString(),
			["DegreesIn"] = _degreesInSign?.ToJson() ?? new JObject()
		};
	}
}
