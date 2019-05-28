using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrudMongo.Collections.Context
{
    public class CollectionBase<T> : IMongoMethods<T>
    {
        protected string Name { get; set; }

        private readonly IMongoAccess mongoAccess;

        public CollectionBase(IMongoAccess mongoAccess)
        {
            this.mongoAccess = mongoAccess;
        }

        public async Task InsertOneAsync(T document)
        {
            var collection = mongoAccess.GetCollection<T>(Name);

            await collection.InsertOneAsync(document);
        }

        public async Task<T> FindSync(Expression<Func<T, bool>> filter)
        {
            var collection = mongoAccess.GetCollection<T>(Name);

            return await collection.FindSync<T>(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> FindAllSync(Expression<Func<T, bool>> filter)
        {
            var collection = mongoAccess.GetCollection<T>(Name);

            return await collection.Find(filter).ToListAsync();
        }


        public async Task ReplaceOneAsync(Expression<Func<T, bool>> filter, T data)
        {
            var collection = mongoAccess.GetCollection<T>(Name);

            var persistedData = await FindSync(filter);
            if (persistedData != null)
            {
                await collection.ReplaceOneAsync(filter, data);
            }        
        }

        public async Task DeleteOneAsync(Expression<Func<T, bool>> filter)
        {
            var collection = mongoAccess.GetCollection<T>(Name);

            await collection.DeleteOneAsync(filter);
        }
    }
}