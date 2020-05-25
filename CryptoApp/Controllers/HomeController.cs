using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoApp.Models;
using CryptoApp.Services;

namespace CryptoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHangfireServices _hangfireServices;


        public HomeController(ILogger<HomeController> logger, IHangfireServices hangfireServices)
        {
            _logger = logger;
            _hangfireServices = hangfireServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string FireJob()
        {
            _hangfireServices.FireJob();
            return "Jobs";
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
