using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiAsyncAndAwait.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task Get()
        {
            try
            {
                await InnerException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
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


        public async Task InnerException()
        {
            try
            {
                using (var httpclient = new HttpClient())
                {
                    await httpclient.GetStringAsync("http://www.cnblogs.com");
                }
                throw new Exception("Inner Exception");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }
            
    }
}
