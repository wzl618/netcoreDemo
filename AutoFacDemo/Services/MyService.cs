using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacDemo.Services
{
    /// <summary>
    /// 自定义服务接口
    /// </summary>
    public class MyService : IService
    {
        public void ShowMyCode()
        {
            //输出对象哈希值
            Console.WriteLine($"MyService.ShowMyCode:{this.GetHashCode()}");
        }
    }
}
