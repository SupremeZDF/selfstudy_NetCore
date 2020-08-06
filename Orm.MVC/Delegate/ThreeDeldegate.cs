using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Orm.MVC.Delegate
{

    public class A 
    {

        public static Action SomeAction { get; protected set; }

        public A()
        {
            SomeAction = () =>
            {
                //Do something!
            };
        }
    }

    public class ThreeDeldegate:A
    {

        public Action SomeAction { get; private set; }

        Stack<Action> previousActions;

        public ThreeDeldegate()
        {

            new HotDaughter();

            //Stack stack = new Stack();
            //stack.Push("A");
            //stack.Push("B");
            //stack.Push("C");

            ////Stack<Action> names = new Stack<Action>();

            //foreach (var i in stack) 
            //{
            //    Console.WriteLine(i);  //C B A
            //}

            //var name = stack.Peek();
            //Console.WriteLine(name); // C

            //var d = stack.Pop();
            //Console.WriteLine(d); //AC


            //name = stack.Peek();
            //Console.WriteLine(name);//B

            //stack.Push("D");

            //d = stack.Pop();
            //Console.WriteLine(d);  // D 

            //name = stack.Peek();
            //Console.WriteLine(name);//B 

            SomeAction = () => {
                //Do something different!
            };
        }

        protected void AddSomeAction(Action newMethod)
        {
            previousActions.Push(SomeAction);
            SomeAction = newMethod;
        }

        protected void RemoveSomeAction()
        {
            if (previousActions.Count == 0)
                return;

            SomeAction = previousActions.Pop();  //移除最后一个 并返回第一个
        }


        void Main()
        {
            var mother = HotDaughter.Activator().Message;
            //mother = "I am the mother"
            var create = new HotDaughter();
            var daughter = HotDaughter.Activator().Message;
            //daughter = "I am the daughter"
        }

        static Dictionary<string, Action> finalizers;

        /// 在静态的构造函数用调用这个方法
        public static void Assembl() 
        {
            finalizers = new Dictionary<string, Action>();


            // 获得当前运行程序集下所有的类型
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                // 检查类型，我们可以提前定义接口或抽象类
                if (type.IsSubclassOf(typeof(HotDaughter)))
                {
                    // 获得默认无参构造函数
                    var m = type.GetConstructor(Type.EmptyTypes);

                    // 调用这个默认的无参构造函数
                    if (m != null)
                    {
                        var instance = m.Invoke(null) as HotDaughter;
                        //var name = type.Name.Remove("Mother");
                        //var method = instance.MyMethod;
                        //finalizers.Add(name, method);
                    }
                }
            }

        }

    }

    public class B
    {
        public B() 
        {
            //A.SomeAction = () => { };
        }
    }



    class CoolMother
    {
        public static Func<CoolMother> Activator { get; protected set; }

        //We are only doing this to avoid NULL references!
        static CoolMother()  //先执行静态
        {
            Activator = () => new CoolMother();
           
        }

        public CoolMother()  //后执行 动态
        {
            //Message of every mother
            Message = "I am the mother";
        }

        public string Message { get; protected set; }
    }

    class HotDaughter : CoolMother
    {
        public HotDaughter()
        {
            //Once this constructor has been "touched" we set the Activator ...
            Activator = () => new HotDaughter();
            //Message of every daughter
            Message = "I am the daughter";
        }
    }


    public class ForeDelegate 
    {

        public void One() 
        {
            // 下面的代码编译不通过
            //Expression<Func<int, int, int>> expr2 = (x, y) => { return x + y; };
            //Expression<Action<int>> expr3 = x => { };

            Expression<Func<int>> expression = () => 1;
        }

    }

}
