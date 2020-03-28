using Microsoft.Extensions.Options;
using optionsDemo.Service.options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace optionsDemo.Service
{
    public class MyService : IMyService
    {
        private readonly IOptions<MyOptions> _myOptions;

        public MyService(IOptions<MyOptions> myOptions) 
        {
            this._myOptions = myOptions;
        }
        public void PrintMyOptions()
        {
            Console.WriteLine($@"myOptions.MyName:{_myOptions.Value.MyName}\n
                                 myOptions.MyAge:{_myOptions.Value.MyAge}\n
                                 myOptions.IsMan:{_myOptions.Value.IsMan}\n");
        }
    }
}
