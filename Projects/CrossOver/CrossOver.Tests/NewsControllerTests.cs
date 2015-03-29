using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrossOver.Web.Controllers;
using CrossOver.Contracts.Services;
using Moq;
using CrossOver.Models;
using System.Web.Mvc;
using CrossOver.Contracts.Model;

namespace CrossOver.Tests
{
    [TestClass]
    public class NewsControllerTests
    {
        private INewsService _mockedNewsService;
        private IUserService _mockedUserService;
        
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

            var newsService = new Mock<INewsService>();
            newsService.Setup(x => x.FindArticle(It.IsAny<Guid>())).Returns(_dummyArticle);

            _mockedNewsService = newsService.Object;


            var userService = new Mock<IUserService>();
            userService.Setup(x => x.FindUser(It.IsAny<int>())).Returns(new UserProfile()
                {
                    UserId = 1,
                    UserName = "Jabez"
                });

            _mockedUserService = userService.Object;
        }

        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new NewsController(_mockedNewsService, _mockedUserService);
            var view = controller.Details(_articleId) as ViewResult;

            var result = view.Model as INewsArticle;

            Assert.AreEqual(result.ArticleId, _dummyArticle.ArticleId);
        }

        [TestMethod]
        public void TestEditView()
        {
            var controller = new NewsController(_mockedNewsService, _mockedUserService);
            var view = controller.Edit(_articleId) as ViewResult;

            var result = view.Model as INewsArticle;

            Assert.AreEqual(result.ArticleId, _dummyArticle.ArticleId);
        }

        [TestMethod]
        public void TestDeleteView()
        {
            var controller = new NewsController(_mockedNewsService, _mockedUserService);
            var view = controller.Delete(_articleId) as ViewResult;

            var result = view.Model as INewsArticle;

            Assert.AreEqual(result.ArticleId, _dummyArticle.ArticleId);
        }
    }
}
