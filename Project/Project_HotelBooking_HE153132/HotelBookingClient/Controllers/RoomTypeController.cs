using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class RoomTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
