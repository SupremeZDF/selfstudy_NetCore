using Orm.MVC.Implate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orm.MVC
{
    public class MyserviceB : IMyservice
    {

        public MyNameService MyNameService { get; set; }

        public void showCode()
        {
            Console.WriteLine("B" + this.GetHashCode() +"属性");
        }
    }

    public class MyNameService 
    {
        
    }

}
