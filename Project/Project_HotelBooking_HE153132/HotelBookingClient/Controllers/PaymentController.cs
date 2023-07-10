using Microsoft.AspNetCore.Mvc;

namespace HotelBookingClient.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
