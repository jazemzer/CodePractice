using CrossOver.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.Contracts.Services
{
    public interface IUserService
    {
        IUserProfile FindUser(string userName);
        IUserProfile FindUser(int userId);
    }
}
