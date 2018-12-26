using ShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Product[] products = new Product[]
        {
            new Product  { Id = 0, Name = "Jigsaw", Category = "Power-Tools", Price = 299.99M },
            new Product  { Id = 1, Name = "Tree", Category = "Nursery", Price = 399.99M },
            new Product  { Id = 2, Name = "Iron", Category = "Houseware", Price = 49.99M },
            new Product  { Id = 3, Name = "Drill", Category = "Power-Tools", Price = 199.99M },
            new Product  { Id = 4, Name = "Frying Pan", Category = "Kitchenware", Price = 99.99M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return products;
        }

        [HttpGet("{Id}", Name = "GetProduct")]
        public IActionResult GetById(int Id)
        {
            var productId = products.FirstOrDefault((p) => p.Id == Id);
            if (productId == null)  
            {
                return NotFound();
            }
            return Ok(productId);
        }
    }
}