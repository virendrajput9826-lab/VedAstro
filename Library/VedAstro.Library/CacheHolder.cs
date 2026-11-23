using System;

namespace VedAstro.Library;

[Serializable]
public class CacheHolder
{
	public readonly CacheKey Key;

	public readonly object Value;

	public CacheHolder(CacheKey key, object value)
	{
		Key = key;
		Value = value;
	}
}
