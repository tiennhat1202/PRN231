using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
