using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using NetcoreMvc.Model.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NetcoreMvc.Model.Registoory
{
    public class AppDBContent : IdentityDbContext<IdentityUser>
    {
        public AppDBContent(DbContextOptions<AppDBContent> dbContextOptions) : base(dbContextOptions) 
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }
    }
}
