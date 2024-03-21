using Newtonsoft.Json;
using Orca.Domain.Interfaces;
using Orca.Infrastructure.Helper;
using StackExchange.Redis;

namespace Orca.Infrastructure.Repositories
{
    public class RedisCache : IRedisCache
    {
        private IDatabase _db;
        public RedisCache()
        {
            ConfigureRedis();
        }

        private void ConfigureRedis()
        {
            _db = ConnectionHelper.Connection.GetDatabase();
        }

        public T GetCacheData<T>(string key)
        {
            var value = _db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public bool RemoveData(string key)
        {
            bool _isKeyExist = _db.KeyExists(key);
            if (_isKeyExist == true)
            {
                return _db.KeyDelete(key);
            }
            return false;
        }

        public bool SetCacheData<T>(string key, T value)
        {
            var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value));
            return isSet;
        }

        public bool SetCacheData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
    }
}
