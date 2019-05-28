using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CrudMongo.Collections.Context
{
    public class MongoContext : IMongoAccess
    {
        private readonly IConfiguration configuration;

        public MongoContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private IMongoDatabase _database;
        public IMongoDatabase Database
        => _database ?? GetMongoDatabase();

        private IMongoClient _client;
        public IMongoClient Client
        => _client ?? GetMongoClient();
        
        private MongoClient GetMongoClient()
        {
            var strCon = this.configuration.GetConnectionString("mongo");

            return new MongoClient(strCon);
        }

        private IMongoDatabase GetMongoDatabase()
        {
            return Client.GetDatabase("DBCrudMongo");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }
    }
}
