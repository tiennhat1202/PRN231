using eStoreClient.DTO.OrderDetailDTO;
using eStoreClient.DTO.OrderDTO;
using eStoreClient.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string OrderApiUrl = "", ProductApiUrl = "";

        public List<GetOrderDetailResponse> orderDetails = new List<GetOrderDetailResponse>();
        public List<GetProductResponse> products = new List<GetProductResponse>();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public DetailsModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            OrderApiUrl = "http://localhost:5289/api/Orders";
            ProductApiUrl = "http://localhost:5289/api/Products";
        }

        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("User") == null)
                {
                    return NotFound();
                }

                HttpResponseMessage response = await client.GetAsync(OrderApiUrl + "/" + id + "/OrderDetails");
                string strData = await response.Content.ReadAsStringAsync();
                orderDetails = JsonSerializer.Deserialize<List<GetOrderDetailResponse>>(strData, options)!;

                response = await client.GetAsync(ProductApiUrl);
                strData = await response.Content.ReadAsStringAsync();
                products = JsonSerializer.Deserialize<List<GetProductResponse>>(strData, options)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Page();
        }
    }
}
