using Microsoft.Extensions.Caching.Memory;

namespace CachingSystem.CachingInMemory
{
    public class MySecondService : IMyService
    {
        private readonly IMemoryCache _MemoryCache;

        public MySecondService(IMemoryCache memoryCache)
        {
            _MemoryCache = memoryCache;
        }
        public void StoreSomeData<T>(string key, T myData)
        {
            _MemoryCache.Set(key, myData, new MemoryCacheEntryOptions()
                                                .SetSlidingExpiration(TimeSpan.FromSeconds(3))
                                );
        }
        public T RetrieveData<T>(string key)
        {
            if (_MemoryCache.TryGetValue(key, out T cachedData))
            {
                return cachedData;
            }

            throw new ArgumentOutOfRangeException(key);
        }
        public void DeleteData(string key)
        {
            _MemoryCache.Remove(key);
        }
    }
}
