using System.Text.RegularExpressions;

namespace VedAstro.Library;

public static class Format
{
	public static string FormatName(dynamic obj)
	{
		dynamic val = obj.ToString();
		dynamic val2 = Format.SplitCamelCase(val);
		return val2;
	}

	public static string FormatName(string nameWithoutSpaces)
	{
		if (string.IsNullOrEmpty(nameWithoutSpaces))
		{
			return "";
		}
		return SplitCamelCase(nameWithoutSpaces);
	}

	private static string SplitCamelCase(string str)
	{
		return Regex.Replace(Regex.Replace(str, "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"), "(\\p{Ll})(\\P{Ll})", "$1 $2");
	}
}
