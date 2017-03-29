using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViewComponentDemo.Controllers
{
    public class BaseController : Controller
    {
        public ClaimsIdentity CIdentity { get; set; }
        // GET: /<controller>/
       public BaseController() {
            List<Claim> list = new List<Claim>();
            var claim = new Claim("FamilyName", "Yang");
            list.Add(claim);
            var claimIdentity = new ClaimsIdentity(list);
            CIdentity = claimIdentity;
        }
    }
}
