using FeedReader.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using FeedReader.Core.DataModels;
using FeedReader.Core.Services;

namespace FeedReader.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NewsFeedService _newsService;

        public HomeController(ILogger<HomeController> logger, NewsFeedService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
