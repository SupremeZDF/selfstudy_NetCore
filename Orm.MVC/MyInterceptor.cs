using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Autofac.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Orm.MVC
{
    public class MyInterceptor : IInterceptor   //拦截
    {
        public void Intercept(IInvocation invocation)
        {
            //throw new NotImplementedException();

            Console.WriteLine($"InterCeptor:{invocation.Method.Name}");
            //invocation.Proceed();
            Console.WriteLine($"InterCeptor{invocation.Method.Name}");
        }
    }
}
