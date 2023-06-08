using eStoreClient.DTO.CategoryDTO;
using eStoreClient.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ProductApiUrl = "", CategoryApiUrl = "";

        public List<GetProductResponse> listProducts = new List<GetProductResponse>();

        public List<GetCategoryResponse> listCategories = new List<GetCategoryResponse>();
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:5289/api/Products";
            CategoryApiUrl = "http://localhost:5289/api/Categories";
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("User") != "Admin")
            {
                return NotFound();
            }

            //api listProducts
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            listProducts = JsonSerializer.Deserialize<List<GetProductResponse>>(strData, options)!;

            if (!String.IsNullOrEmpty(SearchString))
            {
                // Send the GET request
                response = await client.GetAsync(ProductApiUrl + "/Filter?SearchString=" + SearchString);
                strData = await response.Content.ReadAsStringAsync();
                listProducts = JsonSerializer.Deserialize<List<GetProductResponse>>(strData, options)!;
            }

            //api listCategories
            response = await client.GetAsync(CategoryApiUrl);
            strData = await response.Content.ReadAsStringAsync();
            listCategories = JsonSerializer.Deserialize<List<GetCategoryResponse>>(strData, options)!;

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteProduct(int id)
        {
            await client.DeleteAsync(ProductApiUrl + "/" + id);
            return RedirectToPage();
        }
    }
}
