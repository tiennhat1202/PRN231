using BussinessObject.DTO.StatisticalDTO;
using HotelBookingClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HotelBookingClient.Controllers
{
    public class AdminController : Controller
    {
        private readonly HttpClient client = null;
        private string StatisticalURL = "";

        public AdminController()
        {
            //client = new HttpClient();
            //var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            //client.DefaultRequestHeaders.Accept.Add(contentType);
            //StatisticalURL = "https://localhost:7152/api/Statistical?month=7";
            
        }

       // [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            if (HttpContext.Session.GetInt32("UserId") == null && HttpContext.Session.GetInt32("RoleId") == null)
            {
                return RedirectToAction("Login", "Auth");
            }else if(HttpContext.Session.GetInt32("UserId") != null && HttpContext.Session.GetInt32("RoleId") != 1)
            {
                return RedirectToAction("Customer_Home", "Customer");
            }
            //HttpResponseMessage response = await client.GetAsync(StatisticalURL);
            //string stringData = await response.Content.ReadAsStringAsync();
            //stringData.Substring(1, stringData.Length - 1).Replace("\\", "");
            //ViewData["data"] = stringData;
            return View();
        }

    }
}   