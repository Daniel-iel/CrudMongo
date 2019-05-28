using CrudMongo.Collections.Context;
using CrudMongo.Entities;

namespace CrudMongo.Collections
{
    public class ProductCollection : CollectionBase<Product>, IProductCollection
    {
        public ProductCollection(IMongoAccess mongoAccess) : base(mongoAccess)
        {
            Name = "Product";
        }
    }
}
