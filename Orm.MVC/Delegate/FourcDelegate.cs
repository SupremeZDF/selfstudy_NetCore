using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Orm.MVC.Delegate
{
    public class FourcDelegate
    {
        public void One()
        {
            Expression<Func<int, int>> expression = x => x + 1;
            Console.WriteLine(expression.ToString());

            var landExpr = expression as LambdaExpression;
            Console.WriteLine(landExpr.Body);
            Console.WriteLine(landExpr.ReturnType.ToString());
            foreach (var parameter in landExpr.Parameters)
            {
                Console.WriteLine($"{parameter.Name}casdasdadsda{parameter.Type.ToString()}");
            }
        }

        public void Two()
        {

            //Expression<Action> lambdaExpression2 = () =>
            //{
            //    for (int i = 1; i <= 10; i++)
            //    {
            //        Console.WriteLine("Hello");
            //    }
            //};

            LoopExpression expression = Expression.Loop(Expression.Call(null,
        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
        Expression.Constant("Hello")));

        }
    }
}
