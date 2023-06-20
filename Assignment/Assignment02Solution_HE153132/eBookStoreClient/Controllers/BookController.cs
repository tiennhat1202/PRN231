using BusinessObject.DTO.AuthorDTO;
using BusinessObject.DTO.BookDTO;
using BusinessObject.DTO.PublisherDTO;
using BusinessObject.DTO.RoleDTO;
using BusinessObject.DTO.UserDTO;
using eBookStoreClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStoreClient.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient httpClient;

        public BookController()
        {
            httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        }
        public async Task<IActionResult> Index(BookIndexModel bookIndexModel)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login"); ;
            }
            if (bookIndexModel.SearchBook == null)
            {
                HttpResponseMessage bookResponse = await httpClient.GetAsync("https://localhost:7196/api/Book");
                HttpResponseMessage pubResponseMessage = await httpClient.GetAsync("https://localhost:7196/api/Publisher");

                string stringDataBook = await bookResponse.Content.ReadAsStringAsync();
                string pubData = await pubResponseMessage.Content.ReadAsStringAsync();

                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<BookDTO> bookResponses = JsonSerializer.Deserialize<List<BookDTO>>(stringDataBook, option);
                List<PublisherDTO> pubResponse = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, option);
                ViewBag.pubs = pubResponse;
                BookIndexModel bookIndex = new BookIndexModel();
                bookIndex.BookLists = bookResponses;
                return View(bookIndex);
            }
            else
            {
                string url;
                BookDTO searchBook = bookIndexModel.SearchBook;
                
                if(searchBook.BookId != 0)
                {
                    url = "https://localhost:7196/api/Book" + "?$filter=BookId eq " + searchBook.BookId;
                }
                else if (searchBook.Price != null)
                {
                    url = "https://localhost:7196/api/Book" + "?$filter=Price eq " + searchBook.Price;
                }
                else if(searchBook.Price != null && searchBook.BookId != 0 )
                {
                    url = "https://localhost:7196/api/Book" + "?$filter=BookId eq " + searchBook.BookId + " and Price eq " + searchBook.Price;
                }
                else
                {
                    url = "https://localhost:7196/api/Book" + "?$filter=contains(Title,'" + searchBook.Title + "') and contains(Type, '" + searchBook.Type + "') and contains(Notes, '" + searchBook.Notes + "')";
                }
                HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                HttpResponseMessage pubResponseMessage = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
                string pubData = await pubResponseMessage.Content.ReadAsStringAsync();
                string stringData = await responseMessage.Content.ReadAsStringAsync();
                var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<BookDTO> list = JsonSerializer.Deserialize<List<BookDTO>>(stringData, option);
                List<PublisherDTO> pubResponse = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, option);
                ViewBag.pubs = pubResponse;
                BookIndexModel i = new BookIndexModel();
                i.BookLists= list;
                return View(i);
            }
           
        }

        /// <summary>
        /// GET Book/Create
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://localhost:7196/api/Book");
            HttpResponseMessage pubResponseMessage = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
            string stringDataBook = await responseMessage.Content.ReadAsStringAsync();
            string pubData = await pubResponseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<BookRequestDTO> auResponse = JsonSerializer.Deserialize<List<BookRequestDTO>>(stringDataBook, option);
            List<PublisherDTO> pubResponse = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, option);
            ViewBag.pubs = pubResponse;
            return View(auResponse);
        }

        /// <summary>
        /// POST Book/Create
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookRequestDTO book)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:7196/api/Book", httpContent);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET Book/Edit/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage pubResponse = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
            HttpResponseMessage userResponse = await httpClient.GetAsync("https://localhost:7196/api/Book" + "/" + id);

            string pubData = await pubResponse.Content.ReadAsStringAsync();
            string bookData = await userResponse.Content.ReadAsStringAsync();


            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<PublisherDTO> pubResponses = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, option);
            BookDTO bookRes = JsonSerializer.Deserialize<BookDTO>(bookData, option);
            ViewBag.pubs = pubResponses;

            return View(bookRes);
        }
        /// <summary>
        /// POST Book/Edit/Id
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BookDTO book)
        {
            string url = "https://localhost:7196/api/Book" + "/" + id;
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json");
            HttpResponseMessage requestMessage = await httpClient.PutAsync(url, httpContent);
            string stringData = await requestMessage.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage bookResponse = await httpClient.GetAsync("https://localhost:7196/api/Book" + "/" + id);
            HttpResponseMessage pubResponse = await httpClient.GetAsync("https://localhost:7196/api/Publisher");

            string bookData = await bookResponse.Content.ReadAsStringAsync();
            string pubData = await pubResponse.Content.ReadAsStringAsync();


            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<PublisherDTO> pubResponses = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, option);
            BookDTO bookResponses = JsonSerializer.Deserialize<BookDTO>(bookData, option);

            // Find RoleDescription for the user
            var pub = pubResponses.FirstOrDefault(r => r.PubId == bookResponses.PubId);
            if (pub != null)
            {
                bookResponses.PublisherName = pub.PublisherName;
            }
          
            return View(bookResponses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            string url = "https://localhost:7196/api/Book" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(url);
            return RedirectToAction("Index");
        }
    }
}
