using Microsoft.Extensions.Configuration;
using System;

namespace ConfigurationEnvironmentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            #region 获取所有配置的环境变量
            ////配置添加环境变量，获取所有的配置环境变量
            //builder.AddEnvironmentVariables();

            ////获取配置根目录
            //IConfigurationRoot configurationRoot = builder.Build();

            ////根据获取分组的Section
            //var section1 = configurationRoot.GetSection("SECTION1:SECTION2");

            ////根据环境变量的key去获取value
            //Console.WriteLine($"KEY1:{configurationRoot["KEY1"]}");

            ////根据分组的Section去获取环境变量
            //Console.WriteLine($"SECTION1-SECTION2-KEY4:{section1["KEY4"]}");
            #endregion

            #region 根据前缀来过滤配置的环境变量
            //配置添加环境变量，根据前缀获取环境变量
            builder.AddEnvironmentVariables("WZL_");

            //获取配置根目录
            IConfigurationRoot configurationRoot = builder.Build();

            Console.WriteLine($"WZL_KEY5:{configurationRoot["KEY5"]}");

            //KEY2不在前缀获取的环境变量的范围内，所以没有获取到
            Console.WriteLine($"KEY2:{configurationRoot["KEY2"]}");
            #endregion



            Console.ReadKey();
        }
    }
}
