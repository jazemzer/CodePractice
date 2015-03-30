using CrossOver.Contracts.Model;
using CrossOver.Contracts.Services;
using CrossOver.Models;
using CrossOver.Repositories;
using CrossOver.Services;
using CrossOver.WCFService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace CrossOver.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RestfulNewsFeedService : IRestfulNewsFeedService
    {
        private INewsService _newsService;
        private IUserService _userService;
        public RestfulNewsFeedService()
        {
            _newsService = new NewsService(new NewsRepository());
            _userService = new UserService(new UserRepository());
        }

        //TODO: Facing issues with injecting Unity in WCF
        public RestfulNewsFeedService(INewsService newsService, IUserService userService)
        {
            _newsService = newsService;
            _userService = userService;
        }

        public List<NewsFeed> GetNews(string newsCategory)
        {
           
            var temp =_newsService.GetLatestArticles(newsCategory);

            var result = new List<NewsFeed>();

            var allnewsCategories = _newsService.GetAllNewsCategories();
            foreach(var article in temp)
            {
                result.Add(new NewsFeed()
                    {
                        ArticleId = article.ArticleId,
                        FormattedContent = article.FormattedContent,
                        ImageTile = article.ImageTile,
                        PublishedOn = article.PublishedOn,
                        Title = article.Title,
                        NewsCategory = allnewsCategories.Where(x => x.CategoryId == article.CategoryId).FirstOrDefault().CategoryName
                    });
            }


            return result;
        }
    }
}
