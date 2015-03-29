using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrossOver.Models;
using CrossOver.Contracts.Repositories;
using CrossOver.Contracts.Model;
using Moq;
using CrossOver.Services;

namespace CrossOver.Tests
{
    /// <summary>
    /// Summary description for NewServiceTests
    /// </summary>
    [TestClass]
    public class UserServiceTests
    {
        private IUserRepository _mockedUserRepository;


        [TestInitialize]
        public void TestInit()
        {

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.SearchUserBy(It.IsAny<int>())).Returns(new UserProfile()
            {
                UserId = 1,
                UserName = "Jabez"
            });

            _mockedUserRepository = userRepository.Object;
        }

        [TestMethod]
        public void FindUser()
        {
            var userService = new UserService(_mockedUserRepository);
            var result = userService.FindUser(1);

            Assert.AreEqual(result.UserName, "Jabez");
        }
    }
}
