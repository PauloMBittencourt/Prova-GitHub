using Prova_Github.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Prova_Github.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Tomato Soup", Descricao = "Groceries", Linguaguem = "cs" },
            new Product { Name = "Yo-yo", Descricao = "Toys", Linguaguem = "cs"},
            new Product { Name = "Hammer", Descricao = "Hardware", Linguaguem = "cs"}
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(string linguaguem)
        {
            var product = products.FirstOrDefault((p) => p.Linguaguem == linguaguem);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
