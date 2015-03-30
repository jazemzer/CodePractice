using CrossOver.Contracts.Services;
using CrossOver.Repositories;
using CrossOver.Services;
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
    public class RssNewsFeedService : IRssNewsFeedService
    {
        private IUserService _userService;
        private INewsService _newsService;
        public RssNewsFeedService()
        {
            _newsService = new NewsService(new NewsRepository());
            _userService = new UserService(new UserRepository());
        }

        //TODO: Facing issues with injecting Unity in WCF
        public RssNewsFeedService(INewsService newsService, IUserService userService)
        {
            _newsService = newsService;
            _userService = userService;
        }

        public SyndicationFeedFormatter GetNews(string category)
        {
            SyndicationFeed feed = new SyndicationFeed("CrossOver News", "This is Cross Over news feed", new Uri("http://jabezeliezer.me"));
            feed.Authors.Add(new SyndicationPerson("jabezeliezer.m@gmail.com"));
            feed.Categories.Add(new SyndicationCategory("News Articles"));
            feed.Description = new TextSyndicationContent("This is just a sample to demonstrate how to expose a feed using RSS with WCF");

            var result =_newsService.GetLatestArticles(category);

            if (result != null)
            {
                List<SyndicationItem> items = new List<SyndicationItem>();

                foreach (var article in result)
                {
                    var item = new SyndicationItem(article.Title, article.FormattedContent, new System.Uri("http://localhost:64031/news/details/" + article.ArticleId), article.ArticleId.ToString(), article.PublishedOn);
                    items.Add(item);
                }
                feed.Items = items;

            }
            

            return new Rss20FeedFormatter(feed);
        }
    }
}
