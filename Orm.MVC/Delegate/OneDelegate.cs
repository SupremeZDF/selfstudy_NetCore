using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Orm.MVC.Model;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace Orm.MVC.Delegate
{
    public class OneDelegate
    {

        public delegate int Name(int i);
        public void One() 
        {
            Func<double, double> func = delegate (double c) { return c * c; };


            Action name = () => { Console.WriteLine(""); };

            Func<double, double> func1 = c => c * c;

            Func<double, Task<int>> func2 = async (c)=> { return await Task.Run<int>(() =>
            {
                return (int)c;
            }); };

            Name name1 = new Name(c=> c);

            Func<int, int> func3 = (i) => i * 3;

            var c = func3(1);

        }

        public async Task<int> Two(double name) 
        {


            return await Task.Run<int>(() =>
             {
                 return (int)name;
             });
        }

        public async void Three() 
        {
            //var i = 1;
            string[] s = new string[10];
           
            //for (var i = 0; i < s.Count(); i++) 
            //{
            //    s[i]= i.ToString();
            //}
        }

        public  void DoSomeStuff()
        {
            var coeff = 10;

            Func<int, int> compute = x => coeff * x;

            Action modifier = () =>
            {
                coeff = 5;
            };

            var result1 = DoMoreStuff(compute);

            ModifyStuff(modifier);

            var result2 = DoMoreStuff(compute);
        }

        public int DoMoreStuff(Func<int, int> computer)
        {
            return computer(5);
        }

        public void ModifyStuff(Action modifier)
        {
            modifier();
        }


        public void Expressions() 
        {
            Expression<Func<T_Question, int>> expr = model => model.id;
            var member = expr.Body as MemberExpression;
            var propertyName = member.Member.Name;
        }
    }


    class StandardBenchmark 
    {
        const int LENGTH = 100000;
        static double[] A;
        static double[] B;

        static void Init()
        {
            var r = new Random();
            A = new double[LENGTH];
            B = new double[LENGTH];

            for (var i = 0; i < LENGTH; i++)
            {
                A[i] = r.NextDouble();
                B[i] = r.NextDouble();
            }
        }

        static long LambdaBenchmark()
        {
            Func<double> Perform = () =>
            {
                var sum = 0.0;

                for (var i = 0; i < LENGTH; i++)
                    sum += A[i] * B[i];

                return sum;
            };
            var iterations = new double[100];
            var timing = new Stopwatch();
            timing.Start();

            for (var j = 0; j < iterations.Length; j++)
                iterations[j] = Perform();

            timing.Stop();
            Console.WriteLine("Time for Lambda-Benchmark: \t {0}ms", timing.ElapsedMilliseconds);
            return timing.ElapsedMilliseconds;
        }

        static long NormalBenchmark()
        {
            var iterations = new double[100];
            var timing = new Stopwatch();
            timing.Start();

            for (var j = 0; j < iterations.Length; j++)
                iterations[j] = NormalPerform();

            timing.Stop();
            Console.WriteLine("Time for Normal-Benchmark: \t {0}ms", timing.ElapsedMilliseconds);
            return timing.ElapsedMilliseconds;
        }

        static double NormalPerform()
        {
            var sum = 0.0;

            for (var i = 0; i < LENGTH; i++)
                sum += A[i] * B[i];

            return sum;
        }
    }



    public class TwoDelegate
    {
        public void One()
        {
            string Text = "Please wait ...";
            two(() => { Console.WriteLine("123"); return 1; });
        }

        public int two(Func<int> name)
        {
            return name();
        }

        public async void Three()
        {

            //await(async (string s, int no) => {
            //    // 用Task异步执行这里的代码
            //})("Example", 8);

            var person = new
            {
                Name = "Jesse",
                Age = 28,
                Ask = (Action<string>)((string question) => {
                    Console.WriteLine("The answer to `" + question + "` is certainly 42!");
                })
            };

            dynamic dynamic = person;

            dynamic.Ask("sss");


            var lang = "de";
            //Get language - e.g. by current OS settings
            var smn = Foue(lang);
            var name = Console.ReadLine();
            var sentence = smn(name);
            Console.WriteLine(sentence);

            Dictionary<string, Func<string, string>> keyValuePairs = new Dictionary<string, Func<string, string>>();

            keyValuePairs.Add("s", s => "s" + s);

        }

        public Func<string,string> Foue(string language) 
        {

            switch (language.ToLower())
            {
                case "fr":
                    return name => {
                        return "Je m'appelle " + name + ".";
                    };
                case "de":
                    return name => {
                        return "Mein Name ist " + name + ".";
                    };
                default:
                    return name => {
                        return "My name is " + name + ".";
                    };
            }
        }

        int prime;

        public Func<int> Func { get; set; }

        public void Five() 
        {
            Func = () =>
            {
                prime = 2;
                Func = () =>
                {
                    return prime;
                };
                return prime;
            };
        }
    }
}


