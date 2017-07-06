using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace AspNetCoreConsulClientWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ServiceUrlConfigure> _config;
        public  HomeController(IOptions<ServiceUrlConfigure> config)
        {
            _config = config;
        }
        public async Task<IActionResult> Index()
        {
            string responseContent = string.Empty;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_config.Value.ServiceUrl);
                responseContent = await response.Content.ReadAsStringAsync();
            }
            return Content(responseContent);
        }
    }
}
