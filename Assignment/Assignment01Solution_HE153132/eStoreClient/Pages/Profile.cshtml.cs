using eStoreClient.DTO.MemberDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string MemberApiUrl = "";

        [BindProperty]
        public UpdateMemberRequest? UpdateMember { get; set; }

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public ProfileModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:5289/api/Members";
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (HttpContext.Session.GetString("User") == null)
                {
                    return RedirectToPage("./Members/Login");
                }

                string email = HttpContext.Session.GetString("UserEmail"); 

                HttpResponseMessage response = await client.GetAsync(MemberApiUrl + "/email?email=" + email);
                string strData = await response.Content.ReadAsStringAsync();

                GetMemberResponse getMemberResponse = JsonSerializer.Deserialize<GetMemberResponse>(strData, options)!;
                UpdateMember = new UpdateMemberRequest()
                {
                    MemberId = getMemberResponse.MemberId,
                    Email = getMemberResponse.Email,
                    CompanyName = getMemberResponse.CompanyName,
                    City = getMemberResponse.City,
                    Country = getMemberResponse.Country,
                    Password = getMemberResponse.Password,
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
            if (UpdateMember != null)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(MemberApiUrl + "/" + UpdateMember.MemberId, UpdateMember);
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
