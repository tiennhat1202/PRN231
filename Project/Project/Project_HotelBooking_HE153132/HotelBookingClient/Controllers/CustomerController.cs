using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController() {
         
        }
        public IActionResult Customer_Home()
        {
            return View();
        }

        public IActionResult Customer_List()
        {
            return View();
        }

        public IActionResult Customer_Search()
        {
            return View();
        }

        public IActionResult Customer_Room_Detail()
        {
            string email = HttpContext.Session.GetString("Email");
            string username = HttpContext.Session.GetString("Username");
            string phone = HttpContext.Session.GetString("Phone");
            int? userId = HttpContext.Session.GetInt32("UserId");

            // Pass session data to the view
            ViewData["Email"] = email;
            ViewData["Username"] = username;
            ViewData["Phone"] = phone;
            ViewData["UserId"] = userId;
            return View();
        }
    }
}
