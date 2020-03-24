using Microsoft.Extensions.Configuration;
using System;

namespace ConfigurationByJson
{
    class Program
    {
        /// <summary>
        /// 演示读取Json文件的配置
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //添加配置读取json文件
            var builder = new ConfigurationBuilder();
            //当json配置文件发生变更时，重新加载
            //optional为false,当json文件找不到会报错；optional为true，当json文件找不到忽略报错
            builder.AddJsonFile("./appsetting.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configurationRoot = builder.Build();

            var section = configurationRoot.GetSection("JsonSection1");

            Console.WriteLine($"JsonKey1:{configurationRoot["JsonKey1"]}");

            Console.WriteLine($"JsonSection1-Key1:{section["JsonSection1-Key1"]}");

            Console.ReadKey();
        }
    }
}
