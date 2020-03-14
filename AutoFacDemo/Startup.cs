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
            //Ĭ������ע��
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder) 
        {
            //�ӿ�ע�᷽ʽ
            
            //builder.RegisterType<MyServiceV2>().As<IService>();
            //builder.RegisterType<MyService>().As<IService>();

            //����ע�᷽ʽ
            // builder.RegisterType<MyService>().Named<IService>("myService");

            //����ע�᷽ʽ,�������Բ���ע��ɹ���˽������ע�᲻�ɹ�
            //builder.RegisterType<ServiceName>();
            //builder.RegisterType<MyServiceV2>().Named<IService>("myServiceV2").PropertiesAutowired();

            //aop
            //����ע��
            //builder.RegisterType<ServiceName>();
            //ע��������
            //builder.RegisterType<Interceptor>();
            //aop���ط���
            //builder.RegisterType<MyServiceV2>().As<IService>().PropertiesAutowired().InterceptedBy(typeof(Interceptor)).EnableInterfaceInterceptors();

            //������
            builder.RegisterType<MyService>().As<IService>().InstancePerMatchingLifetimeScope("myScope");
        }

        private ILifetimeScope AutofacContainer { get; set; }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //��ȡAutofac�ĸ�����
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            //�������л�ȡʵ��
            //var myService = this.AutofacContainer.Resolve<IService>();
            //var myService1 = this.AutofacContainer.Resolve<IService>();

            //myService.ShowMyCode();
            //myService1.ShowMyCode();

            //����ע�᷽ʽ�������л�ȡʵ��
            // var myServiceV2 = this.AutofacContainer.ResolveNamed<IService>("myServiceV2");

            // myService.ShowMyCode();
            // myServiceV2.ShowMyCode();
            //��ȡ��������Ķ���(��������Ķ����ǵ���ģʽ��)
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
