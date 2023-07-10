using Microsoft.AspNetCore.Mvc;

namespace eBookAjax.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            string userEmail = HttpContext.Session.GetString("UserEmail");
            string password = HttpContext.Session.GetString("Password");
            var role = HttpContext.Session.GetString("User");
            ViewBag.UserEmail = userEmail;
            ViewBag.Password = password;
            ViewBag.Role = role;
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login"); ;
            }
            return View();
        }
    }
}
