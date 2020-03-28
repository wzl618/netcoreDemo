using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace optionsDemo.Service
{
    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IMyService
    {
        /// <summary>
        /// 打印配置信息
        /// </summary>
        public void PrintMyOptions();
    }
}
