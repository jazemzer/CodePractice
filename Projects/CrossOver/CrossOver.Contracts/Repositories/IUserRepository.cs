using CrossOver.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.Contracts.Repositories
{
    public interface IUserRepository
    {
        IUserProfile SearchUserBy(string userName);
        IUserProfile SearchUserBy(int userId);
        bool CreateUser(string userName);
    }
}
