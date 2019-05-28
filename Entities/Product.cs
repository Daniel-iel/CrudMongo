using MongoDB.Bson;

namespace CrudMongo.Entities
{
    public class Product
    {
        public ObjectId _id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Price { get; set; }
        public string Cnpj { get; set; }
    }
}
