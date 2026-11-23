using System;
using System.ComponentModel;
using System.Globalization;

namespace VedAstro.Library;

public class PlanetNameTypeConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return base.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string name)
		{
			return PlanetName.Parse(name);
		}
		return base.ConvertFrom(context, culture, value);
	}
}
