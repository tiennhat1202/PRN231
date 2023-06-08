using eStoreClient.DTO.MemberDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";

        [BindProperty]
        public CreateMemberRequest? MemberRequest { get; set; }

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public CreateModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:5289/api/Members";
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("User") != "Admin")
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (MemberRequest != null)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(MemberApiUrl, MemberRequest);
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
