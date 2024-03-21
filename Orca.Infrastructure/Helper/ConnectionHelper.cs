using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Orca.Infrastructure.Helper
{
    public class ConnectionHelper
    {
        //public static IConfiguration AppSetting { get; }
        private static readonly Lazy<ConnectionMultiplexer> lazyConnection;
        static ConnectionHelper()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]);
            });
        }

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
