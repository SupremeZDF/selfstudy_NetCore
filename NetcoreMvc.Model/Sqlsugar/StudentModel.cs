using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace NetcoreMvc.Model.Sqlsugar
{
    [SugarTable("STUDENT")]
    public class StudentModel
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int FID { get; set; }

        public string FNAME { get; set; }

        public string FNUMBER{ get; set; }

        public string FSEX { get; set; }

        public string FPHONE { get; set; }
    }
}
