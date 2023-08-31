using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserAccount()
        {
            if (HttpContext.Session.GetInt32("UserId") == null && HttpContext.Session.GetInt32("RoleId") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            // Pass session data to the view
            ViewData["Email"] = HttpContext.Session.GetString("Email");
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            ViewData["Phone"] = HttpContext.Session.GetString("Phone");
            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId");

           
            return View();
        }

        public IActionResult UserBooking()
        {
            return View();
        }
    }
}
