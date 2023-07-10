using Microsoft.AspNetCore.Mvc;

namespace eBookAjax.Controllers
{
    public class BookController : Controller
    {
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
    }
}
