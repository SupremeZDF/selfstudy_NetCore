using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using NetcoreMvc.Model.Registoory;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreMvc.Model.DBCotenxTool
{
    public static class DBInitTool
    {
        public static void Sennd(IServiceProvider serviceProvider)
        {
            using (var sqlserver = serviceProvider.GetRequiredService<AppDBContent>())
            {
                if (sqlserver.Users.Any())
                {
                    return;
                }

                sqlserver.Users.AddRange(
                    new Model.User() { name = "123", age = 12, username = "dadasd" },
                              new Model.User() { name = "123", age = 12, username = "dadasd" },
                            new Model.User() { name = "123", age = 12, username = "dadasd" },
                      new Model.User() { name = "123", age = 12, username = "dadasd" },
                             new Model.User() { name = "123", age = 12, username = "dadasd" },
                       new Model.User() { name = "123", age = 12, username = "dadasd" }
                    );

                sqlserver.SaveChanges();
            }
        }
    }
}
