using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace GraphQLDemo.MiddleWare
{
    public static class GraphQlMiddlewareExtensions
    {
        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder builder) {

            return null;//builder.UseMiddleware<>();
        }
    }

}
