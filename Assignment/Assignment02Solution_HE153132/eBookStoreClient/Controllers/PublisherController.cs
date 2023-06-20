using BusinessObject.DTO.PublisherDTO;
using BusinessObject.DTO.RoleDTO;
using BusinessObject.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStoreClient.Controllers
{
    public class PublisherController : Controller
    {
        private readonly HttpClient httpClient;
        public PublisherController()
        {
            httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login"); ;
            }
            HttpResponseMessage pubResponse = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
            string stringDataPub = await pubResponse.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<PublisherDTO> listPublishers = JsonSerializer.Deserialize<List<PublisherDTO>>(stringDataPub, option);
            return View(listPublishers);
        }


        /// <summary>
        /// GET Publisher/Create
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<PublisherRequestDTO> pubResponse = JsonSerializer.Deserialize<List<PublisherRequestDTO>>(stringData, option);
            return View(pubResponse);
        }

        /// <summary>
        /// POST Publisher/Create
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublisherRequestDTO role)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:7196/api/Publisher", httpContent);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET Publisher/Edit/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int id)
        {
            string url = "https://localhost:7196/api/Publisher" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            PublisherDTO pubResponse = JsonSerializer.Deserialize<PublisherDTO>(stringData, option);
            return View(pubResponse);
        }
        /// <summary>
        /// POST Publisher/Edit/Id
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PublisherDTO pub)
        {
            string url = "https://localhost:7196/api/Publisher" + "/" + id;
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(pub), Encoding.UTF8, "application/json");
            HttpResponseMessage requestMessage = await httpClient.PutAsync(url, httpContent);
            string stringData = await requestMessage.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET Publisher/Delete/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int id)
        {
            string url = "https://localhost:7196/api/Publisher" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            PublisherDTO pubResponse = JsonSerializer.Deserialize<PublisherDTO>(stringData, option);
            return View(pubResponse);
        }

        /// <summary>
        /// POST Publisher/Delete/Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            string url = "https://localhost:7196/api/Publisher" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(url);
            return RedirectToAction("Index");
        }

    }
}
