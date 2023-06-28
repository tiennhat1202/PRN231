using BusinessObjects.DTO.ProductDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace IdentityAjaxClient.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        public ProductController()
        {
           
        }
        public IActionResult Index()
        {
            return View();
        }



    }
}
