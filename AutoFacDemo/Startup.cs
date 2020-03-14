using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoFacDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutoFacDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //默认容器注册
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder) 
        {
            //接口注册方式
            
            //builder.RegisterType<MyServiceV2>().As<IService>();
            //builder.RegisterType<MyService>().As<IService>();

            //命名注册方式
            // builder.RegisterType<MyService>().Named<IService>("myService");

            //属性注册方式,公有属性才能注册成功，私有属性注册不成功
            //builder.RegisterType<ServiceName>();
            //builder.RegisterType<MyServiceV2>().Named<IService>("myServiceV2").PropertiesAutowired();

            //aop
            //属性注册
            //builder.RegisterType<ServiceName>();
            //注册拦截器
            //builder.RegisterType<Interceptor>();
            //aop拦截方法
            //builder.RegisterType<MyServiceV2>().As<IService>().PropertiesAutowired().InterceptedBy(typeof(Interceptor)).EnableInterfaceInterceptors();

            //子容器
            builder.RegisterType<MyService>().As<IService>().InstancePerMatchingLifetimeScope("myScope");
        }

        private ILifetimeScope AutofacContainer { get; set; }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //获取Autofac的根容器
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            //从容器中获取实例
            //var myService = this.AutofacContainer.Resolve<IService>();
            //var myService1 = this.AutofacContainer.Resolve<IService>();

            //myService.ShowMyCode();
            //myService1.ShowMyCode();

            //命名注册方式从容器中获取实例
            // var myServiceV2 = this.AutofacContainer.ResolveNamed<IService>("myServiceV2");

            // myService.ShowMyCode();
            // myServiceV2.ShowMyCode();
            //获取子容器里的对象(子容器里的对象是单例模式的)
            using (var container = AutofacContainer.BeginLifetimeScope("myScope"))
            {
                var service = container.Resolve<IService>();
                var service1 = container.Resolve<IService>();
                service.ShowMyCode();
                service1.ShowMyCode();
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
