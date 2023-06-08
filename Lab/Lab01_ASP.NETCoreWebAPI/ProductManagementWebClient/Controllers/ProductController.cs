using Microsoft.AspNetCore.Mvc;
using ProductManagementWebClient.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        private string CategoryApiUrl = "";

        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7002/api/Products";
            CategoryApiUrl = "https://localhost:7002/api/Category";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string stringData = await response.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<ProductResponse> listProducts = JsonSerializer.Deserialize<List<ProductResponse>>(stringData, option);
            return View(listProducts);
        }
        //GET Product/Details/Id
        public async Task<ActionResult> Details(int id)
        {
            string url = ProductApiUrl + "/" + id;
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            ProductResponse product = JsonSerializer.Deserialize<ProductResponse>(stringData, option);
            return View(product);
        }

        //GET Product/Create
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(CategoryApiUrl);
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<CategoryResponse> categoriesResponse = JsonSerializer.Deserialize<List<CategoryResponse>>(stringData, option);
            return View(categoriesResponse);
        }

        // POST Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostProductRequest product)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(ProductApiUrl, httpContent);
            return RedirectToAction("Index");
        }

        // GET Product/Edit/Id
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(CategoryApiUrl);
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<CategoryResponse> categoryResponses = JsonSerializer.Deserialize<List<CategoryResponse>>(stringData, option);
            ViewBag.categories = categoryResponses;

            string url = ProductApiUrl + "/" + id;
            responseMessage = await client.GetAsync(url);
            stringData = await responseMessage.Content.ReadAsStringAsync();
            ProductResponse productResponse = JsonSerializer.Deserialize<ProductResponse>(stringData, option);
            return View(productResponse);
        }
        // POST Product/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PostProductRequest product)
        {
            string url = ProductApiUrl + "/" + id;
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            HttpResponseMessage requestMessage = await client.PutAsync(url, httpContent);
            string stringData = await requestMessage.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        // GET Product/Delete/Id
        public async Task<ActionResult> Delete(int id)
        {
            string url = ProductApiUrl + "/" + id;
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            string stringData = await responseMessage.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            ProductResponse productResponse = JsonSerializer.Deserialize<ProductResponse>(stringData, option);
            return View(productResponse);
        }

        // POST Product/Delete/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            string url = ProductApiUrl + "/" + id;
            HttpResponseMessage responseMessage = await client.DeleteAsync(url);
            return RedirectToAction("Index");
        }
    }
}

