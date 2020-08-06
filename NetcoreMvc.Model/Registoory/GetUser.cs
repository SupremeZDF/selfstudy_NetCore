using NetcoreMvc.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetcoreMvc.Model.Registoory
{
    public class GetUser : IGetUser
    {

        public readonly AppDBContent _AppDBContent;

        public GetUser(AppDBContent appDBContent) 
        {
            _AppDBContent = appDBContent;
        }

        public User GetUserFirst(int id)
        {
            return _AppDBContent.Users.Where(i => i.id == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _AppDBContent.Users.ToList();
        }
    }
}
