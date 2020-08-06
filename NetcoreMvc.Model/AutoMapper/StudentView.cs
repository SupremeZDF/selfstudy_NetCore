using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreMvc.Model.AutoMapper
{
    public class StudentView
    {
        public int Id { get; set; }

        public string studentName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Class { get; set; }
    }
}
