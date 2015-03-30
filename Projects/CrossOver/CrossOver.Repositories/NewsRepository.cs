using CrossOver.Contracts.Model;
using CrossOver.Contracts.Repositories;
using CrossOver.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CrossOver.Repositories
{
    public class NewsRepository : INewsRepository
    {

        public IEnumerable<INewsArticle> GetLatestArticles()
        {
            using(var db = new CrossOverContext())
            {
                return db.NewsArticles.OrderByDescending(n => n.PublishedOn).Take(10).ToList();
            }
        }

        public IEnumerable<INewsArticle> GetLatestArticles(int categoryId)
        {
            using (var db = new CrossOverContext())
            {
                return db.NewsArticles.Where(x => x.CategoryId == categoryId).OrderByDescending(n => n.PublishedOn).Take(10).ToList();
            }
        }


        public INewsArticle FetchArticle(Guid articleId)
        {
            using (var db = new CrossOverContext())
            {
                return db.NewsArticles.Find(articleId);
            }
        }

        public bool SaveArticle(INewsArticle newsArticle)
        {
            using (var db = new CrossOverContext())
            {
                db.NewsArticles.Add(newsArticle as NewsArticle);
                db.SaveChanges();
            }
            return true;
        }


        public bool UpdateArticle(INewsArticle newsArticle)
        {
            using (var db = new CrossOverContext())
            {
                db.Entry(newsArticle as NewsArticle).State = EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }


        public bool DeleteArticle(INewsArticle newsArticle)
        {
            using (var db = new CrossOverContext())
            {
                db.NewsArticles.Remove(newsArticle as NewsArticle);
                db.SaveChanges();
            }
            return true;
        }


        public IEnumerable<INewsCategory> FetchAllNewsCategories()
        {
            using (var db = new CrossOverContext())
            {
                return db.NewsCategories.ToList();
            }
        }
    }
}
