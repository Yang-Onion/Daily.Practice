using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCore.ModelConvention.Demo.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        //[HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [Route("open"),AllowAnonymous]
        public IActionResult OpenEndpoint()
        {
            return Ok();
        }

        
    }
}
