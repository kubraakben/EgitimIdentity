using API1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        //api/product/GetProducts
        //todo kubra
        // [Authorize] 
        //[Authorize(Policy = "ReadProduct")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>() {
            new Product { Id = 1, Name = "kalem", Price = 100, Stock = 500 },
            new Product { Id = 2, Name = "defter", Price = 100, Stock = 500 },
            new Product { Id = 3, Name = "silgi", Price = 100, Stock = 500 },
            new Product { Id = 4, Name = "kitap", Price = 100, Stock = 500 }
            };
            return Ok(productList);

        }

        [Authorize(Policy = "UpdateorCreate")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"id si{id} ürün güncellenmiştir");
        }
        [Authorize(Policy = "UpdateorCreate")]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(product);
        }
    }
}
