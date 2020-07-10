using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Orm.MVC.Model
{
    [Table("T_Question")]
    public class T_Question
    {
        [Key]
        public int id { get; set; }

        public string Image { get; set; }

        public string Headline { get; set; }

        [DisplayName("eqwewqedadasdasdas")]
        public string Content{ get; set; }

        public int IssuestateID { get; set; }

        public int UserID { get; set; }

        public int IssusClassifYid { get; set; }

        public DateTime DataTime { get; set; }

    }

    public class DataContenx : DbContext
    {
        public DataContenx(DbContextOptions<DataContenx> options) : base(options)
        {

        }


        public DataContenx()
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<T_Question> T_Question { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=ZhiHu;Integrated Security=True");
        //}
    }
}
