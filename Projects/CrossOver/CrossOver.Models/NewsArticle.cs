using CrossOver.Contracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CrossOver.Models
{
    [Table("NewsArticle", Schema="CrossOver")]
    public class NewsArticle : INewsArticle
    {
        [Key]
        public System.Guid ArticleId { get; set; }

        [Required(ErrorMessage="News Title cannot be empty")]
        public string Title { get; set; }

        public string ImageTile { get; set; }

        
        [UIHint("tinymce_jquery_full"), AllowHtml]
        [Required(ErrorMessage = "News Content cannot be empty")]
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
