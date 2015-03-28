using CrossOver.Contracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CrossOver.Models
{
    [Table("UserProfile")]
    public class UserProfile : IUserProfile
    {
        public UserProfile()
        {
            //this.NewsArticles = new HashSet<NewsArticle>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<INewsArticle> NewsArticles { get; set; }
    }
}
