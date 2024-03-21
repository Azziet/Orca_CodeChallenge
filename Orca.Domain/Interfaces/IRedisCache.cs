namespace Orca.Domain.Interfaces
{
    public interface IRedisCache
    {
        T GetCacheData<T>(string key);
        bool SetCacheData<T>(string key, T value);
        bool SetCacheData<T>(string key, T value, DateTimeOffset expirationTime);
        bool RemoveData(string key);
    }
}
