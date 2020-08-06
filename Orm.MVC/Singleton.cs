using System;
using System.Collections.Generic;
using System.Text;
using Orm.MVC.Implate;

namespace Orm.MVC
{
    public class Singleton : ISingleton,IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Name()
        {
            Console.WriteLine($"Singleton  {this.GetHashCode()}");
        }
    }
}
