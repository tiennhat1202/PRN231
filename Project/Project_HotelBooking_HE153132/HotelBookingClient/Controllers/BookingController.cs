using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
