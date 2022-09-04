using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Basket.Infrastructure.Configurations
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;

        public RedisConnectionFactory()
        {
            _connection = new Lazy<ConnectionMultiplexer>(()=> ConnectionMultiplexer.Connect(configuration:"localhost:6379"));
        }

        public ConnectionMultiplexer Connection()
        {
            return _connection.Value;
        }
    }
}
