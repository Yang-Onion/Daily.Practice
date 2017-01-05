using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Costom.Authorize.MiddleWare
{
    public static class ApiAuthorizeServicesExtension
    {
        public static IServiceCollection AddApiAuthorize(this IServiceCollection service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }
            return service;
        }

        public static IServiceCollection AddApiAuthorize(this IServiceCollection service, Action<ApiAuthorizeOptions> opt)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }
            if (opt == null)
            {
                throw new ArgumentNullException(nameof(opt));
            }
            service.Configure(opt);
            return service;
        }
    }
}
