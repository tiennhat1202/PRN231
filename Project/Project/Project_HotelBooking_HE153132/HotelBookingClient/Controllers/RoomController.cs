using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class RoomController : Controller
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
    }
}
