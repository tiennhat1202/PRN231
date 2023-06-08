using eStoreClient.DTO.CategoryDTO;
using eStoreClient.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string ProductApiUrl = "", CategoryApiUrl = "";

        [BindProperty]
        public GetProductResponse? getProduct { get; set; }

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public DetailsModel()
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

                getProduct = new GetProductResponse()
                {
                    ProductId = id,
                    CategoryId = getProductResponse!.CategoryId,
                    ProductName = getProductResponse!.ProductName,
                    Weight = getProductResponse!.Weight,
                    UnitPrice = getProductResponse!.UnitPrice,
                    UnitsInStock = getProductResponse!.UnitsInStock,
                };

                response = await client.GetAsync(CategoryApiUrl);
                strData = await response.Content.ReadAsStringAsync();
                List<GetCategoryResponse> listCategories = JsonSerializer.Deserialize<List<GetCategoryResponse>>(strData, options)!;
                foreach (var item in listCategories)
                {
                    if (getProduct.CategoryId == item.CategoryId) ViewData["CategoryName"] = item.CategoryName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Page();
        }
    }
}
