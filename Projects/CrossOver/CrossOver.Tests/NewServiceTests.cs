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
    public class NewServiceTests
    {
        private INewsRepository _mockedNewsRepository;
        private IUserRepository _mockedUserRepository;

        private Guid _articleId = Guid.NewGuid();
        private INewsArticle _dummyArticle = null;

        [TestInitialize]
        public void TestInit()
        {

            _dummyArticle = new NewsArticle()
            {
                ArticleId = _articleId,
                Title = "Test Article",
                FormattedContent = "Test body",
                WrittenBy = 1
            };

            var newsRepository = new Mock<INewsRepository>();
            newsRepository.Setup(x => x.FetchArticle(It.IsAny<Guid>())).Returns(_dummyArticle);

            _mockedNewsRepository = newsRepository.Object;


            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.SearchUserBy(It.IsAny<int>())).Returns(new UserProfile()
            {
                UserId = 1,
                UserName = "Jabez"
            });

            _mockedUserRepository = userRepository.Object;
        }

        [TestMethod]
        public void FindArticle()
        {
            var newsService = new NewsService(_mockedNewsRepository);
            var result = newsService.FindArticle(_articleId);

            Assert.AreEqual(result.ArticleId, _dummyArticle.ArticleId);
        }
    }
}
