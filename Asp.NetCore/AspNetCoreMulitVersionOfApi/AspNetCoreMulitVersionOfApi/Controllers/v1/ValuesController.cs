using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreMulitVersionOfApi.Controllers.v1
{
    //弃用 Deprecated,弃用了仍然可以调用,返回的header中有api-deprecated-versions →1.0
    [ApiVersion("1.0",Deprecated =true)]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Version1";
        }
        [HttpGet,MapToApiVersion("3.0")]
        public string GetV3()
        {
            return "Version3";
        }
    }
}
