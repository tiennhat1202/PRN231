using BusinessObject.DTO.RoleDTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStoreClient.Controllers
{
    public class RoleController : Controller
    {
        private readonly HttpClient httpClient = null;

        public RoleController()
        {
            httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        }

        /// <summary>
        /// GET Role/Index
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login"); ;
            }
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7196/api/Role");
            string stringData = await response.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<RoleDTO> listRoles = JsonSerializer.Deserialize<List<RoleDTO>>(stringData, option);
            return View(listRoles);
        }

        /// <summary>
        /// GET ROLE/CREATE
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://localhost:7196/api/Role");
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<RoleDTO> categoriesResponse = JsonSerializer.Deserialize<List<RoleDTO>>(stringData, option);
            return View(categoriesResponse);
        }

        /// <summary>
        /// POST Role/Create
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleDTO role)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:7196/api/Role", httpContent);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// GET Role/Edit/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int id)
        {
            string url = "https://localhost:7196/api/Role" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            RoleDTO roleResponse = JsonSerializer.Deserialize<RoleDTO>(stringData, option);
            return View(roleResponse);
        }
        /// <summary>
        /// POST Role/Edit/Id
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RoleDTO role)
        {
            string url = "https://localhost:7196/api/Role" + "/" + id;
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
            HttpResponseMessage requestMessage = await httpClient.PutAsync(url, httpContent);
            string stringData = await requestMessage.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET Role/Delete/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int id)
        {
            string url = "https://localhost:7196/api/Role" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            RoleDTO productResponse = JsonSerializer.Deserialize<RoleDTO>(stringData, option);
            return View(productResponse);
        }

        /// <summary>
        /// POST Role/Delete/Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            string url = "https://localhost:7196/api/Role" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(url);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET Role/Details/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            string url = "https://localhost:7196/api/Role" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            RoleDTO roleResponse = JsonSerializer.Deserialize<RoleDTO>(stringData, option);
            return View(roleResponse);
        }
    }
}
