using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork.Infrastructure.Core;
using UnitOfWork.Infrastructure.Data;

namespace UnitOfWork.Infrastructure
{
    public static class EFServiceExtensions
    {
        public static AppSrvBuilder AddUnitOfWork(this IServiceCollection services)
        {
            var builder=new AppSrvBuilder(services);
            builder.Services.AddScoped(typeof (IDemoUnit), typeof (UnitDbContext));
            return builder;
        }
    }
}
