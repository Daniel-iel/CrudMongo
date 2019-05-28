using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMongo.Entities
{
    public class Vendor
    {
        public  ObjectId _id { get; set; }
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string  Phone { get; set; }
    }
}
