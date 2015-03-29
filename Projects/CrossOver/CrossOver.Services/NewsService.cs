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
    public class NewsService : INewsService
    {
        private INewsRepository _newsRepository;
        public NewsService(INewsRepository newsRepository)
        {
            this._newsRepository = newsRepository;
        }

        public IEnumerable<INewsArticle> GetLatestArticles()
        {
            return _newsRepository.GetLatestArticles();
        }

        public INewsArticle FindArticle(Guid articleId)
        {
            return _newsRepository.FetchArticle(articleId);
        }

        public bool SaveArticle(INewsArticle newsArticle)
        {
            return _newsRepository.SaveArticle(newsArticle);
        }


        public bool UpdateArticle(INewsArticle newsArticle)
        {
            return _newsRepository.UpdateArticle(newsArticle);
        }


        public bool DeleteArticle(INewsArticle newsArticle)
        {
            return _newsRepository.DeleteArticle(newsArticle);
        }


        public IEnumerable<INewsCategory> GetAllNewsCategories()
        {
            return _newsRepository.FetchAllNewsCategories();
        }
    }
}
