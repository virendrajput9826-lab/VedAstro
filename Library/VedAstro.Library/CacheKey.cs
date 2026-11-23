using System;

namespace VedAstro.Library;

[Serializable]
public class CacheKey
{
	public string Function;

	private int _ultimateHash;

	public CacheKey(string function, params object[] args)
	{
		Function = function;
		int hashCode = function.GetHashCode();
		int hashCodeForArray = GetHashCodeForArray(args);
		_ultimateHash = hashCode + hashCodeForArray;
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(CacheKey))
		{
			CacheKey cacheKey = (CacheKey)value;
			return GetHashCode() == cacheKey.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _ultimateHash;
	}

	private int GetHashCodeForArray(object[] array)
	{
		if (array != null)
		{
			int num = 17;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * 23 + (array[i]?.GetHashCode() ?? 0);
			}
			return num;
		}
		return 0;
	}
}
