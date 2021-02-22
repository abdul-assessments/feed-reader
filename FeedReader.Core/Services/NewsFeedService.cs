using FeedReader.Core.Config;
using FeedReader.Core.DataModels;
using FeedReader.Core.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedReader.Core.Services
{
    public class NewsFeedService
    {
        private IDataService _dataService;
        private List<FeedItem> _feed;
        private string _feedUrl;

        public bool IsLatest { get; set; }
        public NewsFeedService(IDataService dataService, IOptions<FeedConfig> config)
        {
            _dataService = dataService;
            _feed = _dataService.GetStorage<FeedItem>();
            _feedUrl = config.Value.FeedUrl;

            if (!_feed.Any())
            {
                GetLatestFeed("", "d");
            }
        }

        #region Public Methods
        public List<FeedItem> GetLatestFeed(string sort, string order)
        {
            var latestFeed = GetRssFeed();
            IsLatest = latestFeed.Any();
            List<FeedItem> data = _feed;

            if (IsLatest)
            {
                PersistData(latestFeed);
                data = latestFeed;
            }

            IOrderedEnumerable<FeedItem> orderedFeed = GetSortedFeed(data, sort, order);

            return orderedFeed.ToList();
        }
        public List<FeedItem> GetArchive(int page, int posts, string sort, string order)
        {
            List<FeedItem> data = _feed;
            IOrderedEnumerable<FeedItem> orderedFeed = GetSortedFeed(data, sort, order);

            try
            {
                return orderedFeed
                    .Select((feed, index) => new { feed, index })
                    .GroupBy(x => x.index / posts, y => y.feed)
                    .Skip(page - 1)
                    .Select(x => x.ToList())
                    .First();
            }
            catch
            {
                return new List<FeedItem>();
            }
        }
        #endregion

        #region Private Methods
        private IOrderedEnumerable<FeedItem> GetSortedFeed(List<FeedItem> data, string sort, string order)
        {
            IOrderedEnumerable<FeedItem> orderedFeed;

            //Sort by title or date
            if (sort.ToLower() == "t")
            {
                if (order.ToLower() == "d")
                    orderedFeed = data.OrderByDescending(x => x.Title);
                else
                    orderedFeed = data.OrderBy(x => x.Title);
            }
            else
            {
                if (order.ToLower() == "d")
                    orderedFeed = data.OrderByDescending(x => x.PublishDate);
                else
                    orderedFeed = data.OrderBy(x => x.PublishDate);
            }
            return orderedFeed;
        }
        private void PersistData(List<FeedItem> data)
        {
            //1st remove duplicates as there might be updates
            _feed.RemoveAll(feed => data.Select(x => x.Url).Contains(feed.Url));

            //add data to in memory object
            _feed.AddRange(data);            

            PersistFeedToDisk();
        }
        private List<FeedItem> GetRssFeed()
        {
            using (var reader = XmlReader.Create(_feedUrl))
            {
                try
                {
                    return SyndicationFeed.Load(reader)
                        .Items
                        .Select(x => FeedItem.AsFeedItem(x))
                        .ToList();
                }
                catch
                {
                    return new List<FeedItem>();
                }
            }                        
        }
        private void PersistFeedToDisk()
        {
            try
            {
                Task.Factory.StartNew(() => _dataService.UpdateStorage(_feed));
            }
            catch
            {
                //if another task is still running, we can exit.
                return;
            }
        }
        #endregion
    }
}
