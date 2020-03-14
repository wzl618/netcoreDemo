using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacDemo.Services
{
    /// <summary>
    /// AOP拦截类
    /// </summary>
    public class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"方法开始执行之前，方法名称：{invocation.Method.Name}");
            //执行拦截的方法
            invocation.Proceed();
            Console.WriteLine($"方法执行完成，方法名称：{invocation.Method.Name}");
        }
    }
}
