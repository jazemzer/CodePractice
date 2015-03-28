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
        string OriginalContent { get; set; }
        string FormattedContent { get; set; }
        DateTime PublishedOn { get; set; }

        INewsCategory NewsCategory { get; set; }
        IUserProfile UserProfile { get; set; }
    }
}
