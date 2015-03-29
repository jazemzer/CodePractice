using CrossOver.Contracts.Services;
using CrossOver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrossOver.Web.Controllers
{
    public class NewsController : Controller
    {
        private INewsService _newsService;
        private IUserService _userService;

        public NewsController(INewsService newsService, IUserService userService)
        {
            _newsService = newsService;
            _userService = userService;
        }

        //
        // GET: /News/

        public ActionResult Index()
        {
            var articles = _newsService.GetLatestArticles();

            var allCategories = _newsService.GetAllNewsCategories();
            foreach(var article in articles)
            {
                article.UserProfile = _userService.FindUser(article.WrittenBy);
                article.NewsCategory = allCategories.FirstOrDefault(c => c.CategoryId == article.CategoryId);
            }

            return View(articles);
        }

        //
        // GET: /News/Details/5

        public ActionResult Details(Guid id)
        {
            var newsarticle = _newsService.FindArticle(id);
            if (newsarticle == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsCategory = _newsService.GetAllNewsCategories().Where(n => n.CategoryId == newsarticle.CategoryId).FirstOrDefault();
            ViewBag.Author = _userService.FindUser(newsarticle.WrittenBy).UserName;
            return View(newsarticle);
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            ViewBag.NewsCategories = new SelectList(_newsService.GetAllNewsCategories(), "CategoryId", "CategoryName", 1);
            return View();
        }

        //
        // POST: /News/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsArticle newsarticle)
        {
            if (ModelState.IsValid)
            {
                newsarticle.ArticleId = Guid.NewGuid();
                newsarticle.PublishedOn = DateTime.Now;

                var userProfile = _userService.FindUser(User.Identity.Name);
                newsarticle.UserProfile = userProfile;
                newsarticle.WrittenBy = userProfile.UserId;

                _newsService.SaveArticle(newsarticle);
                return RedirectToAction("Index");
            }

            ViewBag.NewsCategories = new SelectList(_newsService.GetAllNewsCategories(), "CategoryId", "CategoryName", newsarticle.CategoryId);

            return View(newsarticle);

        }

        //
        // GET: /News/Edit/5

        public ActionResult Edit(Guid id)
        {
            var newsarticle = _newsService.FindArticle(id);
            if (newsarticle == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsCategories = new SelectList(_newsService.GetAllNewsCategories(), "CategoryId", "CategoryName", newsarticle.CategoryId);

            return View(newsarticle);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsArticle newsarticle)
        {
            if (ModelState.IsValid)
            {
                var articleToUpdate = _newsService.FindArticle(newsarticle.ArticleId);

                if (articleToUpdate != null)
                {
                    articleToUpdate.Title = newsarticle.Title;
                    articleToUpdate.PublishedOn = DateTime.Now;
                    articleToUpdate.FormattedContent = newsarticle.FormattedContent;
                    articleToUpdate.CategoryId = newsarticle.CategoryId;

                    _newsService.UpdateArticle(articleToUpdate);
                }
                return RedirectToAction("Index");
            }

            ViewBag.NewsCategories = new SelectList(_newsService.GetAllNewsCategories(), "CategoryId", "CategoryName", newsarticle.CategoryId);

            return View(newsarticle);
        }

        //
        // GET: /News/Delete/5

        public ActionResult Delete(Guid id)
        {
            var newsarticle = _newsService.FindArticle(id);
            if (newsarticle == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsCategory = _newsService.GetAllNewsCategories().Where(n => n.CategoryId == newsarticle.CategoryId).FirstOrDefault();
            ViewBag.Author = _userService.FindUser(newsarticle.WrittenBy).UserName;

            return View(newsarticle);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var articleToDelete = _newsService.FindArticle(id);
            _newsService.DeleteArticle(articleToDelete);

            return RedirectToAction("Index");
        }
    }
}
