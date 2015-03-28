using CrossOver.Contracts.Model;
using CrossOver.Contracts.Repositories;
using CrossOver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.Repositories
{
    public class UserRepository : IUserRepository
    {
        public  IUserProfile SearchUserBy(string userName)
        {
            using(var db = new CrossOverContext())
            {
                return db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            }
        }

        public bool CreateUser(string userName)
        {
            var user = new UserProfile() { UserName = userName };
            using (var db = new CrossOverContext())
            {
                db.UserProfiles.Add(user);
                db.SaveChanges();
            }
            return true;
        }
        
    }
}
