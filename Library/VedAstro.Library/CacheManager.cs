using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace VedAstro.Library;

public static class CacheManager
{
	private static object sync = new object();

	private static object cacheCounter = new
	{
		count = 0
	};

	private const int CacheFileLimit = 5000;

	private static ConcurrentDictionary<string, ConcurrentDictionary<CacheKey, object>> _cacheList = new ConcurrentDictionary<string, ConcurrentDictionary<CacheKey, object>>();

	public static int CacheUseCount = 0;

	public static int CacheNotUseCount = 0;

	private static Func<MemoryCache, object>? _getEntriesCollection;
	private static bool _getEntriesCollectionAttempted = false;

	private static Func<MemoryCache, object>? TryGetEntriesCollectionAccessor()
	{
		if (_getEntriesCollectionAttempted) return _getEntriesCollection;
		_getEntriesCollectionAttempted = true;

		try
		{
			var prop = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.Instance | BindingFlags.NonPublic);
			var getter = prop?.GetGetMethod(nonPublic: true);
			if (getter != null)
			{
				_getEntriesCollection = Delegate.CreateDelegate(typeof(Func<MemoryCache, object>), getter, throwOnBindFailure: false) as Func<MemoryCache, object>;
			}
		}
		catch
		{
			_getEntriesCollection = null;
		}

		return _getEntriesCollection;
	}

	public static void SaveCacheToDisk()
	{
		int cacheFileCount = 0;
		foreach (KeyValuePair<string, ConcurrentDictionary<CacheKey, object>> cache in _cacheList)
		{
			string methodName = cache.Key;
			ConcurrentDictionary<CacheKey, object> value = cache.Value;
			int itemsSaved = 0;
			ConcurrentDictionary<CacheKey, object> tempCacheList = new ConcurrentDictionary<CacheKey, object>();
			foreach (KeyValuePair<CacheKey, object> item in value)
			{
				if (itemsSaved >= 5000)
				{
					flushTempList();
				}
				tempCacheList.TryAdd(item.Key, item.Value);
				itemsSaved++;
			}
			if (tempCacheList.Count > 0)
			{
				flushTempList();
			}
			cacheFileCount = 0;
			void flushTempList()
			{
				cacheFileCount++;
				saveCacheInNewFile(methodName, cacheFileCount, tempCacheList);
				tempCacheList.Clear();
				itemsSaved = 0;
			}
		}
	}

	public static void LoadCacheFromDisk0()
	{
		Parallel.ForEach(Directory.GetFiles(Syntax.CacheFilePath, "cache*", SearchOption.TopDirectoryOnly), delegate(string file)
		{
			using FileStream serializationStream = File.OpenRead(file);
			ConcurrentDictionary<CacheKey, object> value = new BinaryFormatter().Deserialize(serializationStream) as ConcurrentDictionary<CacheKey, object>;
			string key = file.Split('_')[1];
			_cacheList.TryAdd(key, value);
		});
	}

	public static void LoadCacheFromDisk()
	{
		new Thread(_loadCacheFromDisk).Start();
	}

	private static void _loadCacheFromDisk()
	{
		Parallel.ForEach(Directory.GetFiles(Syntax.CacheFilePath, "cache*", SearchOption.TopDirectoryOnly), delegate(string file)
		{
			using FileStream serializationStream = File.OpenRead(file);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			string[] array = file.Split('_');
			string text = array[1];
			ConcurrentDictionary<CacheKey, object> concurrentDictionary;
			try
			{
				concurrentDictionary = binaryFormatter.Deserialize(serializationStream) as ConcurrentDictionary<CacheKey, object>;
			}
			catch (Exception)
			{
				LogManager.Error($"Loading cache failed : {array}");
				return;
			}
			if (!_cacheList.TryAdd(text, concurrentDictionary))
			{
				ConcurrentDictionary<CacheKey, object> methodCache = getMethodCache(text);
				Parallel.ForEach(concurrentDictionary, delegate(KeyValuePair<CacheKey, object> cache)
				{
					methodCache.TryAdd(cache.Key, cache.Value);
				});
			}
			LibLogger.Debug("Cache Loaded: " + text);
		});
		LibLogger.Debug("All Cache Loaded");
	}

	public static T GetCache<T>(CacheKey key, Func<T> heavyComputation)
	{
		if (!RuntimeInformation.IsOSPlatform(OSPlatform.Create("WEBASSEMBLY")))
		{
			ConcurrentDictionary<CacheKey, object> methodCache = getMethodCache(key.Function);
			if (methodCache.TryGetValue(key, out var value))
			{
				CacheUseCount++;
				return (T)value;
			}
			CacheNotUseCount++;
			object obj = (methodCache[key] = heavyComputation());
			value = obj;
			return (T)value;
		}
		return heavyComputation();
	}

	public static IEnumerable GetKeys(this IMemoryCache memoryCache)
	{
		if (memoryCache is MemoryCache mc)
		{
			var accessor = TryGetEntriesCollectionAccessor();
			if (accessor != null)
			{
				try
				{
					var entries = accessor(mc);
					if (entries is IDictionary dict)
					{
						return dict.Keys;
					}
				}
				catch
				{
					// Ignore runtime reflection errors on modern .NET runtimes
				}
			}
		}
		return Array.Empty<object>();
	}

	public static IEnumerable<T> GetKeys<T>(this IMemoryCache memoryCache)
	{
		return memoryCache.GetKeys().OfType<T>();
	}

	private static void deleteCacheFiles()
	{
		string[] files = Directory.GetFiles(Syntax.CacheFilePath, "cache*", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			File.Delete(files[i]);
		}
	}

	private static void saveCacheInNewFile(string cacheFileName, int count, object tempCacheList)
	{
		while (true)
		{
			string path = $"{Syntax.CacheFileName}_{cacheFileName}_{count}.dat";
			try
			{
				FileStream fileStream = File.Create(path);
				new BinaryFormatter().Serialize(fileStream, tempCacheList);
				fileStream.Close();
				break;
			}
			catch (Exception)
			{
				LogManager.Error("Saving cache file failed!");
				count++;
			}
		}
	}

	private static int getCacheFileCount()
	{
		return Directory.GetFiles(Syntax.CacheFilePath, "cache*", SearchOption.TopDirectoryOnly).Length;
	}

	private static ConcurrentDictionary<CacheKey, object> getMethodCache(string methodName)
	{
		if (_cacheList.TryGetValue(methodName, out var value))
		{
			if (value != null)
			{
				return value;
			}
			LibLogger.Debug("Cache said to be loaded, but not here!");
		}
		return _cacheList[methodName] = new ConcurrentDictionary<CacheKey, object>();
	}
}
