using Sharper.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sharper.Core.Service
{
    public class TestServiceTwo : ITestServiceTwo
    {
        public virtual async Task FirstMethod()
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"业务方法：TestServiceTwo.FirstMethod()执行成功...");
            });
        }
    }
}
