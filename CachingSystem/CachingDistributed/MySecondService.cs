using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace CachingSystem.CachingDistributed
{
    internal class MySecondService : IMyService
    {
        private readonly IDistributedCache _DistributedCache;

        public MySecondService(IDistributedCache distributedCache)
        {
            _DistributedCache = distributedCache;
        }
        public void StoreSomeData<T>(string key, T myData)
        {
            byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(myData));
            _DistributedCache.Set(key, data);
        }
        public T RetrieveData<T>(string key)
        {
            byte[] cachedData = _DistributedCache.Get(key);

            if (cachedData is not null)
            {
                return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(cachedData));
            }

            throw new ArgumentOutOfRangeException(key);
        }
        public void DeleteData(string key)
        {
            _DistributedCache.Remove(key);
        }
    }
}
