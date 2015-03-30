using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossOver.WCFService.DTO
{
    public class NewsFeed
    {
        public System.Guid ArticleId { get; set; }

        public string Title { get; set; }

        public string ImageTile { get; set; }

        public string FormattedContent { get; set; }
        
        public System.DateTime PublishedOn { get; set; }

        public string NewsCategory { get; set; }

        public string Author { get; set; }
    }
}