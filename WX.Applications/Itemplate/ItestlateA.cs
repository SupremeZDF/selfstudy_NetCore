using System;
using System.Collections.Generic;
using System.Text;

namespace WX.Applications.Itemplate
{
    public interface ItestlateA
    {
    }
    public interface ItestlateB    
    {
    }
    public interface ItestlateC
    {
    }
    public interface ItestlateD
    {
    }
    //public interface ItestlateA
    //{

    //}
    //public interface ItestlateA
    //{

    //}

    public class testlateA: ItestlateA
    {
        public string A() 
        {
            return "A";
        }
    }
    public class testlateB: ItestlateB
    {
        public string B()
        {
            return "B";
        }
    }
    public class testlateC: ItestlateC
    {
        public string C()
        {
            return "C";
        }
    }
    public class testlateD: ItestlateD
    {
        public string D()
        {
            return "D";
        }
    }
}
