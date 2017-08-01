using System;
using MultiPoc.Domain;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MultiPoc.Repository
{
    public class RedisRepository<T> : IRedisRepository<T> where T : class
    {
        //private IRedisClientsPool redisDataCache;
        private IDatabase redisDataCache;
        ConfigurationOptions databaseConfig;
        public ConnectionMultiplexer redis { get; set; }

        public RedisRepository()
        {

        }

        public RedisRepository(string dbcontext)
        {
            databaseConfig = new ConfigurationOptions();

            databaseConfig.EndPoints.Add(dbcontext + ":6379");
            databaseConfig.Password = "testeSenha";
            databaseConfig.ConnectTimeout = 100000;
            databaseConfig.SyncTimeout = 100000;

            redis = ConnectionMultiplexer.Connect(databaseConfig); //Placeholder
            redisDataCache = redis.GetDatabase();
        }


        public bool Add(string key, T entity)
        {
            // Reference for this "TEST" = https://stackoverflow.com/questions/4273743/static-implicit-operator
            RedisValue valueToInsert = JsonConvert.SerializeObject(entity);

            redisDataCache.StringSet(key, valueToInsert);

            return redisDataCache.StringSet(key, valueToInsert);
        }

        public bool AddWithExpiration(string key, int expireTime, T entity)
        {
            //Same reference as "ADD"
            RedisValue valueToInsert = JsonConvert.SerializeObject(entity);
            return redisDataCache.StringSet(key, valueToInsert, TimeSpan.FromSeconds(expireTime));
        }

        public bool Delete(string key)
        {
            return redisDataCache.KeyDelete(key);
        }

        public Object ListById(string key)
        {

            RedisValue valueToReturn = redisDataCache.StringGet(key);

            //CAST Horroroso que deveria ser substituído na Business
            return JsonConvert.DeserializeObject<Client>(valueToReturn);
        }

        public bool Update(string key, T entity)
        {
            throw new NotImplementedException();
        }

    }
}
