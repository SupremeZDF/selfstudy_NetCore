using System;
using System.Collections.Generic;
using System.Text;

namespace Orm.MVC.IOC
{
    public interface Itypeservice<T>
    {
         
    }

    public class TpeyServcie<T>:Itypeservice<T>
    {
        public T Data;

        public TpeyServcie(T d) 
        {
            Data = d;
        }
    }
}
