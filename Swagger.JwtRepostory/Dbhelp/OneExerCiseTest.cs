using System;
using System.Collections.Generic;
using System.Text;

namespace Swagger.JwtRepostory.Dbhelp
{
    public class OneExerCiseTest
    {
        /// <summary>
        /// 测试
        /// </summary>
        public void Name(out int a) 
        {
            a = 12;
        }

        /// <summary>
        /// 测试 2
        /// </summary>
        /// <param name="b"></param>
        public void OneName(ref int a) 
        {
            int c = 12;
        }
    }
}
