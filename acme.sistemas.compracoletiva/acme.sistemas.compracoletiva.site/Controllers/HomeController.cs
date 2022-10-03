using acme.sistemas.compracoletiva.site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace acme.sistemas.compracoletiva.site.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //ILogger<HomeController> logger
        public HomeController()
        {
            //_logger = logger;
        }

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
            //new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
            return View();
        }
    }
}