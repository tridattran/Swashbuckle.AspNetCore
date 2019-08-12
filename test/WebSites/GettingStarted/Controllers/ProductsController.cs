using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GettingStarted.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        public int CreateProduct([FromBody]Product product)
        {
            return 123;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts([FromQuery]string keywords)
        {
            return new[]
            {
                new Product
                {
                    Id = 123,
                    Description = "A product"
                }
            };
        }

        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return new Product
            {
                Id = id,
                Description = "A product"
            };
        }

    }

    public class Product
    {
        public int Id { get; internal set; }
        public string Description { get; set; }
    }
}
