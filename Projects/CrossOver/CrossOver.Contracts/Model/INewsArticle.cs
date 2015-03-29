using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.Contracts.Model
{
    public interface INewsArticle
    {
        Guid ArticleId { get; set; }
        string Title { get; set; }
        string ImageTile { get; set;}
        string FormattedContent { get; set; }
        int CategoryId { get; set; }
        DateTime PublishedOn { get; set; }
        int WrittenBy { get; set; }

        INewsCategory NewsCategory { get; set; }
        IUserProfile UserProfile { get; set; }
    }
}
