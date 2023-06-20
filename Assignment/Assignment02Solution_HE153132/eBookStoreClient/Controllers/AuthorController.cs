using BusinessObject.DTO.AuthorDTO;
using BusinessObject.DTO.PublisherDTO;
using eBookStoreClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStoreClient.Controllers
{
    public class AuthorController : Controller
    {
        private readonly HttpClient httpClient;
        public AuthorController()
        {
            httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        }
        public async Task<IActionResult> Index(AuthorIndexModel authorIndexModel)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login"); ;
            }
            if (authorIndexModel.SearchAuthor == null)
            {
                HttpResponseMessage auResponse = await httpClient.GetAsync("https://localhost:7196/api/Author");
                string stringDataAu = await auResponse.Content.ReadAsStringAsync();
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<AuthorDTO> authorResponse = JsonSerializer.Deserialize<List<AuthorDTO>>(stringDataAu, option);
                AuthorIndexModel authorIndex = new AuthorIndexModel();
                authorIndex.AuthorList = authorResponse;
                return View(authorIndex);
            }
            else
            {
                string url; 
                AuthorDTO searchAuthor = authorIndexModel.SearchAuthor;
                if(searchAuthor.AuthorId != 0)
                {
                     url = "https://localhost:7196/api/Author" + "?$filter=AuthorId eq " + searchAuthor.AuthorId;
                }
                else
                {
                     url = "https://localhost:7196/api/Author" + "?$filter=contains(LastName,'" + searchAuthor.LastName + "') and contains(FirstName, '" + searchAuthor.FirstName + "') and contains(City, '" + searchAuthor.City + "')";
                }
                HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                string stringData = await responseMessage.Content.ReadAsStringAsync();
                var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<AuthorDTO> list = JsonSerializer.Deserialize<List<AuthorDTO>>(stringData, option);
                AuthorIndexModel i = new AuthorIndexModel();
                i.AuthorList = list;
                return View(i);
            }
        }

        /// <summary>
        /// GET Author/Create
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://localhost:7196/api/Author");
            string stringDataAu = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<AuthorRequestDTO> auResponse = JsonSerializer.Deserialize<List<AuthorRequestDTO>>(stringDataAu, option);
            return View(auResponse);
        }

        /// <summary>
        /// POST Author/Create
        /// </summary>
        /// <param name="au"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorRequestDTO au)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(au), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:7196/api/Author", httpContent);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// GET Publisher/Edit/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int id)
        {
            string url = "https://localhost:7196/api/Author" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            string stringDataAu = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            AuthorDTO auResponse = JsonSerializer.Deserialize<AuthorDTO>(stringDataAu, option);
            return View(auResponse);
        }
        /// <summary>
        /// POST Publisher/Edit/Id
        /// </summary>
        /// <param name="au"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AuthorDTO au)
        {
            string url = "https://localhost:7196/api/Author" + "/" + id;
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(au), Encoding.UTF8, "application/json");
            HttpResponseMessage requestMessage = await httpClient.PutAsync(url, httpContent);
            string stringData = await requestMessage.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET Author/Delete/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int id)
        {
            string url = "https://localhost:7196/api/Author" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            string stringDataAu = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            AuthorDTO auResponse = JsonSerializer.Deserialize<AuthorDTO>(stringDataAu, option);
            return View(auResponse);
        }

        /// <summary>
        /// POST Author/Delete/Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            string url = "https://localhost:7196/api/Author" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(url);
            return RedirectToAction("Index");
        }
    }
}
