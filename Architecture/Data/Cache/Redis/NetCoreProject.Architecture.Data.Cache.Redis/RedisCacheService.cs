using Microsoft.Extensions.Caching.Distributed;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace NetCoreProject.Architecture.Data.Cache.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _redisDb;
        private readonly IConnectionMultiplexer _multiplexer;
        public async Task<IEnumerable<T>> GetAll<T>(string pattern = "*", Func<T, bool> filterFunction = null)
        {
            var keys = _multiplexer
                .GetServer(_multiplexer
                    .GetEndPoints()
                    .First())
                .Keys(pattern: pattern ?? "*");

            List<T> result = new List<T>();
            foreach (var key in keys)
            {
                var currentData = JsonConvert.DeserializeObject<T>(_redisDb.GetString(key));
                result.Add(currentData);
            };
            return filterFunction is not null ? result.Where(filterFunction) : result;
        }

        public async Task<IEnumerable<T>> GetAllWithId<T>(string pattern = "*", Func<T, bool> filterFunction = null) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByKey<T>(string key)
        {
            var keyData = await _redisDb.GetStringAsync(key);
            if (!string.IsNullOrEmpty(keyData))
            {
                return JsonConvert.DeserializeObject<T>(keyData);
            }

            return default;
        }

        public async Task RemoveData(string key)
        {
            string isKeyExist = await _redisDb.GetStringAsync(key);
            if (!string.IsNullOrEmpty(isKeyExist))
                await _redisDb.RemoveAsync(key);
        }

        public async Task SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expireTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var cacheOptions = new DistributedCacheEntryOptions().SetSlidingExpiration(expireTime);
            await _redisDb.SetStringAsync(key, JsonConvert.SerializeObject(value), cacheOptions);
        }
    }
}
