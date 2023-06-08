using eStoreClient.DTO.MemberDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string MemberApiUrl = "";

        public List<GetMemberResponse> listMembers = new List<GetMemberResponse>();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:5289/api/Members";
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("User") != "Admin")
            {
                return NotFound();
            }

            HttpResponseMessage response = await client.GetAsync(MemberApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            listMembers = JsonSerializer.Deserialize<List<GetMemberResponse>>(strData, options)!;
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteMember(int id)
        {
            await client.DeleteAsync(MemberApiUrl + "/" + id);
            return RedirectToPage();
        }
    }
}
