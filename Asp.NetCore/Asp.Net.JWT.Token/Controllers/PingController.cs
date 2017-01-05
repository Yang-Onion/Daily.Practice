using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.Net.JWT.Token.Controllers
{
    [Route("api/[Controller]")]
    public class PingController : Controller
    {
        [HttpGet]
        [Authorize("Bearer")]
        public string Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var id = claimsIdentity?.Claims.FirstOrDefault(g => g.Type.Equals("ID")).Value;
            return $"Hello! {HttpContext.User.Identity.Name},your Id is{id}";
        }

    }
}
