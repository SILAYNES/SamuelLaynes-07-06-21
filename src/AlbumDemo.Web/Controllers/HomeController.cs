using AlbumDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AlbumDemo.Web.Configurations;
using Newtonsoft.Json;

namespace AlbumDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UrlApiConfig _config;
        
        public HomeController(ILogger<HomeController> logger, UrlApiConfig config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(_config.Name + "Album/all");
            var viewModel = new HomeViewModel();
            viewModel.ActionText = "Visualizar Album";
            viewModel.Albums = JsonConvert.DeserializeObject<List<AlbumViewModel>>(json);
            return View(viewModel);
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
