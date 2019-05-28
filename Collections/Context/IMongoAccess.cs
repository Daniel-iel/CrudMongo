using MongoDB.Driver;

namespace CrudMongo.Collections.Context
{
    public interface IMongoAccess
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}