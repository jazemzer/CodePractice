using CrossOver.Contracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CrossOver.Models
{
    [Table("NewsArticle", Schema="CrossOver")]
    public class NewsArticle : INewsArticle
    {
        [Key]
        public System.Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string OriginalContent { get; set; }
        public string FormattedContent { get; set; }
        public int CategoryId { get; set; }
        public System.DateTime PublishedOn { get; set; }
        public int WrittenBy { get; set; }

        [ForeignKey("CategoryId")]
        public virtual INewsCategory NewsCategory { get; set; }

        [ForeignKey("WrittenBy")]
        public virtual IUserProfile UserProfile { get; set; }
    }
	
}
