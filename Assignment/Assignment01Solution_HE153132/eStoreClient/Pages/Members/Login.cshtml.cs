using eStoreClient.DTO;
using eStoreClient.DTO.MemberDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace eStoreClient.Pages.Members
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient client = null!;
        private string MemberApiUrl = "";

        [BindProperty(SupportsGet = true)]
        public FormLogin formLogin { get; set; } = new FormLogin();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };



        public LoginModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:5289/api/Members";
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (formLogin != null)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(MemberApiUrl + "/Login", formLogin);
                if ((int)response.StatusCode == 400)
                {
                    ViewData["Error"] = "Wrong email or password";
                    return Page();
                }

                string strData = await response.Content.ReadAsStringAsync();
                GetMemberResponse getMember = JsonSerializer.Deserialize<GetMemberResponse>(strData, options)!;

                if (getMember != null)
                {
                    IConfigurationRoot configJson = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                    string adminEmail = configJson.GetSection("Admin")["Email"];
                    string adminPw = configJson.GetSection("Admin")["Password"];

                    if (getMember.Email.Equals(adminEmail) && getMember.Password.Equals(adminPw))
                    {
                        if (HttpContext.Session.GetString("User") != null)
                        {
                            HttpContext.Session.Clear();
                        }
                        else
                        {
                            HttpContext.Session.SetString("User", "Admin");
                            HttpContext.Session.SetString("UserEmail", getMember.Email);
                        }
                    }
                    else
                    {
                        if (HttpContext.Session.GetString("User") != null)
                        {
                            HttpContext.Session.Clear();
                        }
                        else
                        {
                            HttpContext.Session.SetString("User", "User");
                            HttpContext.Session.SetString("UserEmail", getMember.Email);
                        }
                    }
                }
                return RedirectToPage("/Index");
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
