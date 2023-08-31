using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") == null && HttpContext.Session.GetInt32("RoleId") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else if (HttpContext.Session.GetInt32("UserId") != null && HttpContext.Session.GetInt32("RoleId") != 1)
            {
                return RedirectToAction("Customer_Home", "Customer");
            }
            return View();
        }
        public IActionResult Detail(int id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null && HttpContext.Session.GetInt32("RoleId") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else if (HttpContext.Session.GetInt32("UserId") != null && HttpContext.Session.GetInt32("RoleId") != 1)
            {
                return RedirectToAction("Customer_Home", "Customer");
            }
            return View();
        }
    }
}
