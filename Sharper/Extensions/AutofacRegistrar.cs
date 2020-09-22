using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Sharper.Core;
using Sharper.Core.Interface;
using Sharper.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sharper.Extensions
{
    public static class AutofacRegistrar
    {

        public static void Registrar(this ContainerBuilder builder)
        {
            builder.RegisterType<TestServiceTwoAOP>().As<IInterceptor>().InstancePerDependency();

            //第一种方式
            builder.RegisterType<TestServiceTwo>().As<ITestServiceTwo>().InterceptedBy(typeof(IInterceptor))
                .InstancePerDependency().EnableClassInterceptors();

            //第二种方式
            builder.Register(c => new ServiceAOP());
            var serviceAsm = Assembly.Load(new AssemblyName("Sharper.Core"));
            builder.RegisterAssemblyTypes(serviceAsm)
                       .Where(t => typeof(ITagService).IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract)
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope()
                       .EnableInterfaceInterceptors();//进行aop拦截


        }
    }
}
