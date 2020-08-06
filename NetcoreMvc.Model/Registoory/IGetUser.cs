using Microsoft.AspNetCore.Identity;
using NetcoreMvc.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreMvc.Model.Registoory
{
    public interface IGetUser
    {
        List<User> GetUsers();

        User GetUserFirst(int id);
    }
}
