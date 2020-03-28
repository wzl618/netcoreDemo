using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using optionsDemo.Service;
using optionsDemo.Service.options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace optionsDemo.Extensions
{
    /// <summary>
    /// 服务静态扩展方法
    /// </summary>
    public static class MyServicesExtensions
    {
        public static IServiceCollection AddMyServices(IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<MyOptions>(configuration);
            services.AddScoped<IMyService,MyService>();
            return services;
        }
    }
}
