using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoApp.Models;
using CryptoApp.Services;
using System.Threading.Tasks;
using StackExchange.Exceptional;

namespace CryptoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHangfireServices _hangfireServices;

        public HomeController(IHangfireServices hangfireServices)
        {
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

        public async Task Exceptions()
        {
            await ExceptionalMiddleware.HandleRequestAsync(HttpContext).ConfigureAwait(false);
        }
    }
}
