using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrudMongo.Collections.Context
{
    public interface IMongoMethods<T>
    {
        Task InsertOneAsync(T document);
        Task<T> FindSync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> FindAllSync(Expression<Func<T, bool>> filter);
        Task ReplaceOneAsync(Expression<Func<T, bool>> filter, T data);
        Task DeleteOneAsync(Expression<Func<T, bool>> filter);
    }
}