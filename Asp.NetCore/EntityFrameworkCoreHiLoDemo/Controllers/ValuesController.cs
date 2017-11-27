using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCoreHiLoDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            using (var context = new AppDbContext())
            {
                context.Categroys.Add(new Category { CategoryName = "CategoryName_1" });
                context.Categroys.Add(new Category { CategoryName = "CategoryName_2" });
                context.Categroys.Add(new Category { CategoryName = "CategoryName_3" });

                context.Products.Add(new Product { ProductName = "Product_1" });
                context.Products.Add(new Product { ProductName = "Product_2" });
                context.Products.Add(new Product { ProductName = "Product_3" });

                context.SaveChanges();
            }

            return DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
