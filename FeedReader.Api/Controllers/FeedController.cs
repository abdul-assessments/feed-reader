using FeedReader.Api.Models;
using FeedReader.Core.DataModels;
using FeedReader.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedReader.Api.Controllers
{
    [Route("api/feed")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private NewsFeedService _newsService;
        public FeedController(NewsFeedService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        [Route("archive")]
        public IActionResult Archives(int page, int posts, string sort, string order)
        {
            return Ok(new FeedResponse { IsLatest = false, Feed = _newsService.GetArchive(page, posts, sort, order) });
        }

        [HttpGet]
        [Route("latest")]
        public IActionResult Latest(string sort, string order)
        {
            FeedResponse response = new FeedResponse
            {
                Feed = _newsService.GetLatestFeed(sort, order),
                IsLatest = _newsService.IsLatest
            };
            return Ok(response);
        }
    }
}
