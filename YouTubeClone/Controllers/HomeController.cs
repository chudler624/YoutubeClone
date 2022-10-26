using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YouTubeClone.Models;
using YouTubeClone.Services;

namespace YouTubeClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SearchResultPage(string searchTerm)
        {
            var youtubeApi = new YoutubeApi();
            var searchResultModel = youtubeApi.GetVideoInfo(searchTerm);

            return View(searchResultModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}