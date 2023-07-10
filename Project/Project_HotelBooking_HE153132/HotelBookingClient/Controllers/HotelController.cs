using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
