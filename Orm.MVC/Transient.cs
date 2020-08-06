using System;
using System.Collections.Generic;
using System.Text;
using Orm.MVC.Implate;

namespace Orm.MVC.Implate
{
    public class Transient : Ittansient
    {
        public void Name()
        {
            Console.WriteLine("Transient");
        }
    }
}
