using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Migration.Demo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private AppContext _context;
        private ILogger _loger;
        public ValuesController(AppContext context, ILoggerFactory loggerFactory) {
            _context = context;
            _loger = loggerFactory.CreateLogger(typeof(ValuesController));
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            try {
                var student = _context.Student.FirstOrDefault();

                return student == null ? "No Student" : student.StuName;
            }
            catch (Exception ex) {
                _loger.LogError(ex.Message);
                throw;
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
    }
}
