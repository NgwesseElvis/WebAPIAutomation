
using System;
using System.Runtime.Caching;
using WebAPIAutomation.RestSharpHandler.Interface;

namespace WebAPIAutomation.RestSharpHandler
{
    public class CacheService : ICacheService
    {
        public T Get<T>(string cacheKey) where T : class
        {
            return MemoryCache.Default.Get(cacheKey) as T;
        }

        public void Set(string cacheKey, object item, int minutes=5)
        {
            if (item != null)
            {
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(minutes));
            }
        }
    }
}
