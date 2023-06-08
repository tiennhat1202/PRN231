using eStoreClient.DTO.CategoryDTO;
using eStoreClient.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ProductApiUrl = "", CategoryApiUrl = "";

        [BindProperty]
        public CreateProductRequest? ProductRequest { get; set; }

        public List<GetCategoryResponse> listCategories = new List<GetCategoryResponse>();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public CreateModel()
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

            //api listCategories
            HttpResponseMessage response = await client.GetAsync(CategoryApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            listCategories = JsonSerializer.Deserialize<List<GetCategoryResponse>>(strData, options)!;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ProductRequest != null)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(ProductApiUrl, ProductRequest);
                response.EnsureSuccessStatusCode();
                return RedirectToPage("./Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
