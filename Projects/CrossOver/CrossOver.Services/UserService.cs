using CrossOver.Contracts.Model;
using CrossOver.Contracts.Repositories;
using CrossOver.Contracts.Services;
using CrossOver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IUserProfile FindUser(string userName)
        {
            return _userRepository.SearchUserBy(userName);
        }

        public IUserProfile FindUser(int userId)
        {
            return _userRepository.SearchUserBy(userId);
        }
    }
}
