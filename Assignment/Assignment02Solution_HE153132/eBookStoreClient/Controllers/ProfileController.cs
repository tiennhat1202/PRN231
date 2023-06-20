using BusinessObject.DTO.PublisherDTO;
using BusinessObject.DTO.RoleDTO;
using BusinessObject.DTO.UserDTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStoreClient.Controllers
{
    public class ProfileController : Controller
    {
        private readonly HttpClient httpClient;
        public ProfileController()
        {
            httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        }

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        public async Task<IActionResult> Index()
        {
            try
            {
                if (HttpContext.Session.GetString("User") == null)
                {
                    return RedirectToAction("Index", "Login"); ;
                }

                string email = HttpContext.Session.GetString("UserEmail");

                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7196/api/User" + "/emailAdress?email=" + email);
                HttpResponseMessage roleResponse = await httpClient.GetAsync("https://localhost:7196/api/Role");
                HttpResponseMessage pubResponse = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
                string roleData = await roleResponse.Content.ReadAsStringAsync();
                string pubData = await pubResponse.Content.ReadAsStringAsync();
                string strData = await response.Content.ReadAsStringAsync();
                UserUpdateRequestDTO userUpdate = JsonSerializer.Deserialize<UserUpdateRequestDTO>(strData, options)!;
                List<RoleDTO> roleResponses = JsonSerializer.Deserialize<List<RoleDTO>>(roleData, options);
                List<PublisherDTO> pubResponses = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, options);
                ViewBag.roles = roleResponses;
                ViewBag.pubs = pubResponses;
                return View(userUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UserUpdateRequestDTO user)
        {
            string url = "https://localhost:7196/api/User" + "/" + id;
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            HttpResponseMessage requestMessage = await httpClient.PutAsync(url, httpContent);
            string stringData = await requestMessage.Content.ReadAsStringAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
