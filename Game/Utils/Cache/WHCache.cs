using System;
using System.Collections.Generic;
using System.Threading;
namespace Game.Utils.Cache
{
	public class WHCache
	{
		private static volatile WHCache _instance;
		private static object lockObj = new object();
		public static WHCache Default
		{
			get
			{
				if (WHCache._instance == null)
				{
					object obj;
					Monitor.Enter(obj = WHCache.lockObj);
					try
					{
						if (WHCache._instance == null)
						{
							WHCache._instance = new WHCache();
						}
					}
					finally
					{
						Monitor.Exit(obj);
					}
				}
				return WHCache._instance;
			}
		}
		public void Save<CacheType>(string key, object value) where CacheType : ICache, new()
		{
			ICache cache = (default(CacheType) == null) ? Activator.CreateInstance<CacheType>() : default(CacheType);
			cache.Add(key, value);
		}
		public void Save<CacheType>(string key, object value, int? timeout) where CacheType : ICache, new()
		{
			ICache cache = (default(CacheType) == null) ? Activator.CreateInstance<CacheType>() : default(CacheType);
			cache.Add(key, value, timeout);
		}
		public void Save<CacheType>(Dictionary<string, object> dic) where CacheType : ICache, new()
		{
			ICache cache = (default(CacheType) == null) ? Activator.CreateInstance<CacheType>() : default(CacheType);
			cache.Add(dic);
		}
		public void Save<CacheType>(Dictionary<string, object> dic, int? timeout) where CacheType : ICache, new()
		{
			ICache cache = (default(CacheType) == null) ? Activator.CreateInstance<CacheType>() : default(CacheType);
			cache.Add(dic, timeout);
		}
		public object Get<CacheType>(string key) where CacheType : ICache, new()
		{
			ICache cache = (default(CacheType) == null) ? Activator.CreateInstance<CacheType>() : default(CacheType);
			return cache.GetValue(key);
		}
		public void Clear<CacheType>() where CacheType : ICache, new()
		{
			ICache cache = (default(CacheType) == null) ? Activator.CreateInstance<CacheType>() : default(CacheType);
			cache.Delete();
		}
		public void Delete<CacheType>(string key) where CacheType : ICache, new()
		{
			ICache cache = (default(CacheType) == null) ? Activator.CreateInstance<CacheType>() : default(CacheType);
			cache.Delete(key);
		}
	}
}
