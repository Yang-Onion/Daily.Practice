using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Asp.NetCore.Costom.Authorize.MiddleWare
{
    public static class ApiAuthorizeExtension
    {
        public static IApplicationBuilder UseApiAuthorize(this IApplicationBuilder builder)
        {
            if (builder==null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            return builder.UseMiddleware<ApiAuthorizeMiddleWare>();
        }

        public static IApplicationBuilder UseApiAuthorize(this IApplicationBuilder builder, ApiAuthorizeOptions opt)
        {
            if (builder==null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (opt==null)
            {
                throw new ArgumentNullException(nameof(opt));
            }
            return builder.UseMiddleware<ApiAuthorizeMiddleWare>(Options.Create(opt));
        }
    }
}
