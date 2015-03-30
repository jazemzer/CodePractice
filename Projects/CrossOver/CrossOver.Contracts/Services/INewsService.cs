using CrossOver.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.Contracts.Services
{
    public interface INewsService
    {
        bool DeleteArticle(INewsArticle newsArticle);
        INewsArticle FindArticle(Guid articleId);
        IEnumerable<INewsArticle> GetLatestArticles();
        IEnumerable<INewsArticle> GetLatestArticles(string category);
        bool SaveArticle(INewsArticle newsArticle);
        bool UpdateArticle(INewsArticle newsArticle);
        IEnumerable<INewsCategory> GetAllNewsCategories();
    }
}
