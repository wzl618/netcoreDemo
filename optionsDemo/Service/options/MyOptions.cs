using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace optionsDemo.Service.options
{
    /// <summary>
    /// 配置选项
    /// </summary>
    public class MyOptions:IOptions<MyOptions>
    {
        public string MyName { get; set; }

        public int MyAge { get; set; }

        public bool IsMan { get; set; }

        public MyOptions Value => new MyOptions();
    }
}
