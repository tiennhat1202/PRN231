using eStoreClient.DTO.MemberDTO;
using eStoreClient.DTO.OrderDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string OrderApiUrl = "", MemberApiUrl = "";

        // add property ToalSale
        public List<GetTotalSaleResponse> listNewOrders = new List<GetTotalSaleResponse>();

        public List<GetMemberResponse> listMembers = new List<GetMemberResponse>();

        [BindProperty(SupportsGet = true)]
        public DateTime? DateFrom { get; set; } = null;
        [BindProperty(SupportsGet = true)]
        public DateTime? DateTo { get; set; } = null;
        [BindProperty(SupportsGet = true)]
        public string? Sort { get; set; } = null;

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            OrderApiUrl = "http://localhost:5289/api/Orders";
            MemberApiUrl = "http://localhost:5289/api/Members";
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToPage("/Members/Login");
            }

            //api listOrders
            HttpResponseMessage response = await client.GetAsync(OrderApiUrl + "/TotalSales");
            string strData = await response.Content.ReadAsStringAsync();
            listNewOrders = JsonSerializer.Deserialize<List<GetTotalSaleResponse>>(strData, options)!;

            if (DateFrom != null && DateTo != null)
            {
                //http://localhost:5289/api/Orders/FilterTotalSale?dateFrom=2023-01-01&dateTo=2023-03-03&sort=1
                string endPoint = OrderApiUrl + "/FilterTotalSales?dateFrom=" + DateFrom + "&dateTo=" + DateTo;
                if (Sort != null)
                {
                    endPoint += "&sort=descTotalSale";
                }
                response = await client.GetAsync(endPoint);
                strData = await response.Content.ReadAsStringAsync();
                listNewOrders = JsonSerializer.Deserialize<List<GetTotalSaleResponse>>(strData, options)!;
            }

            if (HttpContext.Session.GetString("User") != "Admin")
            {
                string email = HttpContext.Session.GetString("UserEmail");
                response = await client.GetAsync(MemberApiUrl + "/email?email=" + email);
                strData = await response.Content.ReadAsStringAsync();
                GetMemberResponse getMemberResponse = JsonSerializer.Deserialize<GetMemberResponse>(strData, options)!;

                List<GetTotalSaleResponse> listOrdersUser = new List<GetTotalSaleResponse>();
                foreach (var item in listNewOrders)
                {
                    if (item.MemberId == getMemberResponse.MemberId)
                    {
                        listOrdersUser.Add(item);
                    }
                }
                listNewOrders = listOrdersUser;
            }

            //api listMembers
            response = await client.GetAsync(MemberApiUrl);
            strData = await response.Content.ReadAsStringAsync();
            listMembers = JsonSerializer.Deserialize<List<GetMemberResponse>>(strData, options)!;
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteOrder(int id)
        {
            await client.DeleteAsync(OrderApiUrl + "/" + id);
            return RedirectToPage();
        }
    }
}
