using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asp.NetCoreFilter.Sample.Models;
using Asp.NetCoreFilter.Sample.Filters;

namespace Asp.NetCoreFilter.Sample.Controllers
{
    [TypeFilter(typeof(AuthorizationFilter))]
    public class HomeController : Controller
    {
        [TypeFilter(typeof(ActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        [TypeFilter(typeof(ExceptionFilter))]
        public IActionResult Error()
        {
            throw new Exception("Test Exception Filter");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
