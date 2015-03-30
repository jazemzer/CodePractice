using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace CrossOver.WCFService
{
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(Rss20FeedFormatter))]
    public interface IRssNewsFeedService
    {

        [OperationContract]
        [WebGet(UriTemplate = "news/rss?category={category}")]
        SyndicationFeedFormatter GetNews(string category); 

    }
}
