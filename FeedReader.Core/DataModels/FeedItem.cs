using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Core.DataModels
{
    public class FeedItem
    {
        public string Url { get; set; }
        public string Title { get; set; }

        public string Summary { get; set; }

        public DateTimeOffset PublishDate { get; set; }

        public static FeedItem AsFeedItem(SyndicationItem syndicationItem)
        {
            return new FeedItem
            {
                Url = syndicationItem.Id,
                Title = syndicationItem.Title.Text,
                Summary = syndicationItem.Summary.Text,
                PublishDate = syndicationItem.PublishDate
            };
        }
    }
}
