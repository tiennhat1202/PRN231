using eStoreClient.DTO.MemberDTO;
using eStoreClient.DTO.OrderDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string OrderApiUrl = "", MemberApiUrl = "";

        [BindProperty]
        public CreateOrderRequest? CreateOrder { get; set; }

        public List<GetMemberResponse> listMembers = new List<GetMemberResponse>();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public CreateModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            OrderApiUrl = "http://localhost:5289/api/Orders";
            MemberApiUrl = "http://localhost:5289/api/Members";
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("User") != "Admin")
            {
                return NotFound();
            }

            //api listMembers
            HttpResponseMessage response = await client.GetAsync(MemberApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            listMembers = JsonSerializer.Deserialize<List<GetMemberResponse>>(strData, options)!;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (CreateOrder != null)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(OrderApiUrl, CreateOrder);
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
