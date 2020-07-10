using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Orm.MVC.SqlClient
{
    public class NoteContext:DbContext
    {

        public NoteContext(DbContextOptions<NoteContext> options)
           : base(options)
        {
            // 暂无其他代码
        }

        public DbSet<Product> Products { get; set; }
    }
}
