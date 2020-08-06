using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreMvc.Model.Model
{
    public class User
    {
        public int id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string username { get; set; }

        public bool? IsinStock { get; set; }
    }
}
