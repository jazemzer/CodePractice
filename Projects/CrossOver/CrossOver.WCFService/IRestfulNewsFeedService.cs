using CrossOver.Contracts.Model;
using CrossOver.Models;
using CrossOver.WCFService.DTO;
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
    public interface IRestfulNewsFeedService
    {

        [OperationContract]
        [WebGet(UriTemplate = "category/{newsCategory}",ResponseFormat=WebMessageFormat.Json )]
        List<NewsFeed> GetNews(string newsCategory); 

    }
}
