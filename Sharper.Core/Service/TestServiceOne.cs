using Autofac.Extras.DynamicProxy;
using Sharper.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sharper.Core.Service
{
    [Intercept(typeof(ServiceAOP))]
    public class TestServiceOne : ITestServiceOne
    {
        public async Task FirstMethod()
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"业务方法：TestServiceOne.FirstMethod()执行成功...");
            });
        }
    }
}
