using System;

namespace VedAstro.Library;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public sealed class HoroscopeCalculatorAttribute : Attribute
{
	public HoroscopeName HoroscopeName { get; set; }

	public HoroscopeCalculatorAttribute(HoroscopeName horoscopeName)
	{
		HoroscopeName = horoscopeName;
	}
}
