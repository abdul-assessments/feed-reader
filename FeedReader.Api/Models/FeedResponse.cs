using FeedReader.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedReader.Api.Models
{
    public class FeedResponse
    {
        public bool IsLatest { get; set; }
        public List<FeedItem> Feed { get; set; }
    }
}
