using Orm.MVC.Implate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orm.MVC
{
    public class MyserviceA : IMyservice
    {
        public virtual void showCode()
        {
            Console.WriteLine("A" + this.GetHashCode());
        }
    }
}
