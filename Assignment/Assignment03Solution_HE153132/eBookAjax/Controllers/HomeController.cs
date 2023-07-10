using eBookAjax.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eBookAjax.Controllers
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
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login"); ;
            }
            if (HttpContext.Session.GetString("User") != null && HttpContext.Session.GetString("User") != "Admin")
            {
                return RedirectToAction("Index", "Profile"); ;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login"); ;
            }
            if (HttpContext.Session.GetString("User") != null && HttpContext.Session.GetString("User") != "Admin")
            {
                return RedirectToAction("Index", "Profile"); ;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}