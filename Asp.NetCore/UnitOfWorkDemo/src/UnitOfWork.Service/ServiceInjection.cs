using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork.Infrastructure.Core;
using UnitOfWork.Service.Impl;

namespace UnitOfWork.Service
{
    public static class ServiceInjection
    {
        public static AppSrvBuilder AddService(this AppSrvBuilder builder)
        {
            builder.AddScoped(typeof(IUnit), typeof(UnitService));

            return builder;
        }
    }
}
