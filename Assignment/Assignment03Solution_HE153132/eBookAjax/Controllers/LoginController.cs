using BusinessObject.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eBookAjax.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient httpClient;
        public LoginController()
        {
            httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        }
        [BindProperty(SupportsGet = true)]
        public UserFormLoginDTO formLogin { get; set; } = new UserFormLoginDTO();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> HandlerLogin()
        {
            if (formLogin != null)
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("https://localhost:7026/api/User/login", formLogin);
                if ((int)responseMessage.StatusCode == 400)
                {
                    ViewData["Error"] = "Wrong email or password";
                    return View("Index");
                }
                string strData = await responseMessage.Content.ReadAsStringAsync();
                UserFormLoginDTO getMember = JsonSerializer.Deserialize<UserFormLoginDTO>(strData, options)!;

                if (getMember != null)
                {
                    IConfigurationRoot configJson = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                    string adminEmail = configJson.GetSection("Admin")["Email"];
                    string adminPw = configJson.GetSection("Admin")["Password"];

                    if (getMember.EmailAddress.Equals(adminEmail) && getMember.Password.Equals(adminPw))
                    {
                        if (HttpContext.Session.GetString("User") != null)
                        {
                            HttpContext.Session.Clear();
                        }
                        else
                        {
                            HttpContext.Session.SetString("User", "Admin");
                            HttpContext.Session.SetString("UserEmail", getMember.EmailAddress);
                            HttpContext.Session.SetString("Password", getMember.Password);
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
                            HttpContext.Session.SetString("UserEmail", getMember.EmailAddress);
                            HttpContext.Session.SetString("Password", getMember.Password);
                        }
                    }
                }
                if (HttpContext.Session.GetString("User") == "Admin")
                {
                    return RedirectToAction("Index", "Home"); ;
                }
                {
                    return RedirectToAction("Index", "Profile");
                }
                
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
