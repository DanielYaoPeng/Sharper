using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharper.Core
{
    public class TestServiceTwoAOP : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("我要收集用户的请求参数，发给我们算法模型同学 \"{0}\"  参数是 {1}... ", invocation.Method.Name, string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            DoSomething();

            //执行真实业务方法
            invocation.Proceed();

        }

        public void DoSomething()
        {
            Console.WriteLine("AOP,我先说话，你们service稍后再发言!");
        }
    }
}
