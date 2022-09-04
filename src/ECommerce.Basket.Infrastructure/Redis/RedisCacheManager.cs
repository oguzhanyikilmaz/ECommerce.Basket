using ECommerce.Basket.Infrastructure.Configurations;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Basket.Infrastructure.Redis
{
    public class RedisCacheManager : ICacheService
    {
        private readonly IRedisConnectionFactory _connection;

        private readonly IDatabase _database;
        public RedisCacheManager(IRedisConnectionFactory connection)
        {
            _connection = connection;
            _database = _connection.Connection().GetDatabase(db:0);
        }
        public void Add(string key, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);

            _database.StringSet(key, jsonData);
        }

        public bool Any(string key)
        {
            return _database.KeyExists(key);
        }

        public void Clear()
        {
            _database.Multiplexer.GetServer(hostAndPort:"http:localhost:6379").FlushDatabase();
        }

        public T Get<T>(string key)
        {
            if (!Any(key)) return default;

            string stringData = _database.StringGet(key);

            var jsonData= JsonConvert.DeserializeObject<T>(stringData);

            return jsonData;
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }
    }
}
