using CrudMongo.Collections;
using CrudMongo.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace CrudMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductCollection productCollection;

        public ProductController(IProductCollection productCollection)
        {
            this.productCollection = productCollection;
        }

        [HttpGet("{cnpj}")]
        public async Task<IActionResult> Get(string cnpj)
        {
            var products = await productCollection.FindAllSync(c => c.Cnpj == cnpj);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string cnpj, string id)
        {
            var product = productCollection.FindSync(c => c._id == new ObjectId(id) && c.Cnpj == cnpj);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await productCollection.InsertOneAsync(product);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            await productCollection.ReplaceOneAsync(c => c._id == product._id, product);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await productCollection.DeleteOneAsync(c => c._id == new ObjectId(id));

            return Ok();
        }
    }
}