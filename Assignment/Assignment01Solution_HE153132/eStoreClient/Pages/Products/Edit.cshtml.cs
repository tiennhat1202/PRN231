using eStoreClient.DTO.CategoryDTO;
using eStoreClient.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ProductApiUrl = "", CategoryApiUrl = "";

        [BindProperty]
        public UpdateProductRequest? UpdateProduct { get; set; }

        public List<GetCategoryResponse> listCategories = new List<GetCategoryResponse>();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public EditModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:5289/api/Products";
            CategoryApiUrl = "http://localhost:5289/api/Categories";
        }

        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("User") != "Admin")
                {
                    return NotFound();
                }

                HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/" + id);
                string strData = await response.Content.ReadAsStringAsync();

                GetProductResponse getProductResponse = JsonSerializer.Deserialize<GetProductResponse>(strData, options)!;
                UpdateProduct = new UpdateProductRequest()
                {
                    ProductId = getProductResponse.ProductId,
                    ProductName = getProductResponse.ProductName,
                    CategoryId = getProductResponse.CategoryId,
                    UnitPrice = getProductResponse.UnitPrice,
                    Weight = getProductResponse.Weight,
                    UnitsInStock = getProductResponse.UnitsInStock,
                };

                //api listCategories
                response = await client.GetAsync(CategoryApiUrl);
                strData = await response.Content.ReadAsStringAsync();
                listCategories = JsonSerializer.Deserialize<List<GetCategoryResponse>>(strData, options)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (UpdateProduct != null)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(ProductApiUrl + "/" + UpdateProduct.ProductId, UpdateProduct);
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
