using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreFilter.Sample.Filters
{
    public class AuthorizationFilter : IAsyncAuthorizationFilter
    {
        public async  Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //do something
        }
    }
}
