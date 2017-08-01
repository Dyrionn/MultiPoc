using System;

namespace MultiPoc.Repository
{
    public interface IRedisRepository<T> where T : class
    {

        bool Add(string key, T entity);
        bool AddWithExpiration(string key, int expireTime, T entity);
        bool Update(string key, T entity);
        bool Delete(string key);
        Object ListById(string key);
    }
}
