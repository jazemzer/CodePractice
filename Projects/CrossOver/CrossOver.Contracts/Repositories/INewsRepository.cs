using CrossOver.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.Contracts.Repositories
{
    public interface INewsRepository
    {
        IEnumerable<INewsArticle> GetLatestArticles();
        IEnumerable<INewsArticle> GetLatestArticles(int categoryId);

        INewsArticle FetchArticle(Guid articleId);
        bool SaveArticle(INewsArticle newsArticle);
        bool UpdateArticle(INewsArticle newsArticle);
        bool DeleteArticle(INewsArticle newsArticle);

        IEnumerable<INewsCategory> FetchAllNewsCategories();
    }
}
