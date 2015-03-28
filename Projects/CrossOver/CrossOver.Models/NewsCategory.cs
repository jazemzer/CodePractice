using CrossOver.Contracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CrossOver.Models
{
    [Table("NewsCategory", Schema = "CrossOver")]
    public class NewsCategory : INewsCategory
    {
        public NewsCategory()
        {
            //this.NewsArticles = new HashSet<NewsArticle>();
        }

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<INewsArticle> NewsArticles { get; set; }
    }
}
