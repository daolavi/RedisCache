using System;
using System.Collections.Generic;
using StackExchange.Redis.Extensions.Binary;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Protobuf;
using StackExchange.Redis.Extensions.Utf8Json;

namespace AwsElastiCache
{
    public class CacheManager
    {
        private static readonly Lazy<CacheManager> lazy = new Lazy<CacheManager>(() => new CacheManager());

        private static StackExchangeRedisCacheClient cacheClient;

        public static CacheManager Instance => lazy.Value;

        private CacheManager()
        {
            //var serializer = new ProtobufSerializer();
            //var serializer = new BinarySerializer();
            var serializer = new Utf8JsonSerializer();
            var redisConfiguration = new RedisConfiguration()
            {
                Hosts = new RedisHost[]
                {
                    new RedisHost(){Host = "127.0.0.1", Port = 6379},
                },
            };
            cacheClient = new StackExchangeRedisCacheClient(serializer, redisConfiguration);
        }

        public Dictionary<string,string> GetCacheInfo()
        {
            return cacheClient.GetInfo();
        }

        public bool Add<T>(string key, T value)
        {
            return cacheClient.Add(key, value);
        }

        public T Get<T>(string key)
        {
            return cacheClient.Get<T>(key);
        }
    }
}
