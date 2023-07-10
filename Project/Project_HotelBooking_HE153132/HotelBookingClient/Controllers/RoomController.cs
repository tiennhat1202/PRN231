using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
