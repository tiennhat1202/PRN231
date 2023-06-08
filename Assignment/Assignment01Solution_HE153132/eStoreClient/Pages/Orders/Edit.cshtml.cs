using eStoreClient.DTO.OrderDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string OrderApiUrl = "";

        [BindProperty]
        public UpdateOrderRequest? UpdateOrder { get; set; }

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public EditModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            OrderApiUrl = "http://localhost:5289/api/Orders";
        }

        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("User") != "Admin")
                {
                    return NotFound();
                }

                HttpResponseMessage response = await client.GetAsync(OrderApiUrl + "/" + id);
                string strData = await response.Content.ReadAsStringAsync();

                GetOrderResponse getOrderResponse = JsonSerializer.Deserialize<GetOrderResponse>(strData, options)!;
                UpdateOrder = new UpdateOrderRequest()
                {
                    OrderId = id,
                    RequireDate = getOrderResponse.RequireDate,
                    ShippedDate = getOrderResponse.ShippedDate,
                    Freight = getOrderResponse.Freight,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (UpdateOrder != null)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(OrderApiUrl + "/" + UpdateOrder.OrderId, UpdateOrder);
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
