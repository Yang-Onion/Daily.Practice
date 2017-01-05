using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore.OAuth2._0.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return DateTime.Now.ToString();
        }

        [Route("temp/{str}")]
        public string GetValue(string str)
        {
            return $"value:{str}";
        }


    }
}
