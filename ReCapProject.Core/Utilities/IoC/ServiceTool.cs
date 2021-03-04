using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ReCapProject.Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
