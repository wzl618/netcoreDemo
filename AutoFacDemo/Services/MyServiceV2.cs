using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacDemo.Services
{
    /// <summary>
    /// 具有属性的服务类
    /// </summary>
    public class MyServiceV2:IService
    {
        public ServiceName serviceName { get; set; }

        public void ShowMyCode()
        {
            Console.WriteLine($"MyServiceV2.ShowMyCode:{this.GetHashCode()},serviceName是否为空:{this.serviceName == null}");
        }
    }

    public class ServiceName 
    {
    
    }
}
