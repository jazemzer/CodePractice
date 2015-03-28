using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.Contracts.Model
{
    public interface IUserProfile
    {
        int UserId { get; set; }
        string UserName { get; set; }
        ICollection<INewsArticle> NewsArticles { get; set; }

    }
}
