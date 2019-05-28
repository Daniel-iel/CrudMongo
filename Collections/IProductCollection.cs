using CrudMongo.Collections.Context;
using CrudMongo.Entities;

namespace CrudMongo.Collections
{
    public interface IProductCollection : IMongoMethods<Product>
    {
    }
}