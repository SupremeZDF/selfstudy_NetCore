using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Orm.MVC.Model
{
    public class T_Question
    {
        public int id { get; set; }

        public string Image { get; set; }

        public string Headline { get; set; }

        public string Content{ get; set; }

        public int IssuestateID { get; set; }

        public int UserID { get; set; }

        public int IssusClassifYid { get; set; }

        public DateTime DataTime { get; set; }

    }

    public class DataContenx : DbContext
    {
        public DataContenx(DbContextOptions<DataContenx> options):base(options) 
        {
        
        }
        public DbSet<T_Question> t_Questions { get; set; } 
    }
}
