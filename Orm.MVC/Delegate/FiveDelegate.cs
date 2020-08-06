using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Orm.MVC.Delegate
{
    public class FiveDelegate
    {
        public void Run() 
        {
            //Expression<Func<int, int,int,int>> expression = (a, b, c) =>  (a * b) + (c * a);

            //Console.WriteLine(expression);

            //var data = expression.Compile();  //将 expression 表达式树 编译为 可执行的 lambda 表达式的委托

            //var s = data(1,2,3);  //parameter 参数化

            //ParameterExpression a = Expression.Parameter(typeof(int), "a");
            //ParameterExpression b = Expression.Parameter(typeof(int), "a");
            //ParameterExpression c = Expression.Parameter(typeof(int), "a");
            //ParameterExpression d = Expression.Parameter(typeof(int), "a");


            //Expression expression1 = Expression.Multiply(a,b);
            //Expression expression2 = Expression.Multiply(c, d);

            ParameterExpression a = Expression.Parameter(typeof(int), "i");

            Console.WriteLine(a.ToString());
            ParameterExpression b = Expression.Parameter(typeof(int), "j");

            Console.WriteLine(b.ToString());
            Expression r1 = Expression.Multiply(a, b);      //乘法运行

            Console.WriteLine(r1.ToString());

            ParameterExpression c = Expression.Parameter(typeof(int), "x");
            ParameterExpression d = Expression.Parameter(typeof(int), "y");
            Expression r2 = Expression.Multiply(c, d);      //乘法运行

            Console.WriteLine(r2.ToString());
            Expression result = Expression.Add(r1, r2);     //相加

            Console.WriteLine(result.ToString());
            //以上代码产生结点
            //生成表达式
            Expression<Func<int, int, int, int, int>> func = Expression.Lambda<Func<int, int, int, int, int>>(result, a, b, c, d);

            Console.WriteLine(func.ToString());
            var com = func.Compile();
            Console.WriteLine("表达式" + func);
            Console.WriteLine(com(12, 12, 13, 13));
        }
        
    } 
}
