using BussinessObject.DTO.UserDTO;
using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace HotelBookingClient.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient httpClient;
        public AuthController()
        {
            httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [BindProperty(SupportsGet = true)]
        public UserLoginDTO formLogin { get; set; } = new UserLoginDTO();
        [BindProperty(SupportsGet = true)]
        public UserResetPasswordDTO emailReset { get; set; } = new UserResetPasswordDTO();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };


        [HttpPost]
        public async Task<IActionResult> HandlerLoginAsync()
        {
            if (string.IsNullOrEmpty(formLogin.Email) || string.IsNullOrEmpty(formLogin.Password))
            {
                TempData["Error"] = "Email and password are required";
                return View("Login");
            }
            HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("https://localhost:7152/api/Login/login", formLogin);
            if ((int)responseMessage.StatusCode == 404)
            {
                TempData["Error"] = "Wrong email or password";
                return View("Login");
            }
            string strData = await responseMessage.Content.ReadAsStringAsync();
            UserLoginResponse userResponse = JsonSerializer.Deserialize<UserLoginResponse>(strData, options);
            if (userResponse != null)
            {
                HttpContext.Session.SetInt32("UserId", userResponse.UserId);
                HttpContext.Session.SetString("Email", userResponse.Email);
                HttpContext.Session.SetInt32("RoleId", userResponse.RoleId.GetValueOrDefault());
                HttpContext.Session.SetString("Username", userResponse.Username);
                HttpContext.Session.SetString("Phone", userResponse.Phone);

                if (userResponse.RoleId == 1)
                {
                    return RedirectToAction("Index", "Booking");
                }
                else if (userResponse.RoleId == 2)
                {
                    return RedirectToAction("Customer_Home", "Customer");
                }
            }
            return View(userResponse);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HandlerResetPasswordAsync()
        {
            if (string.IsNullOrEmpty(emailReset.Email))
            {
                TempData["Error"] = "Email are required";
                return View("ResetPassword");
            }
            HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("https://localhost:7152/api/Login/reset", emailReset);
            if ((int)responseMessage.StatusCode == 404)
            {
                ViewData["Error"] = "Wrong email";
                return View("ResetPassword");
            }
            string strData = await responseMessage.Content.ReadAsStringAsync();
            UserResetPasswordDTO resetResponse = JsonSerializer.Deserialize<UserResetPasswordDTO>(strData, options);
            if (resetResponse != null)
            {
                var newPassword = GenerateNewPassword();
                // Call api update

                UserRequestDTO dataUpdate = new UserRequestDTO()
                {
                    UserId = resetResponse.UserId,
                    RoleId = resetResponse.RoleId,
                    Username = resetResponse.Username,
                    Password = newPassword,
                    Email = resetResponse.Email,
                    Phone = resetResponse.Phone
                };

                // Gọi hàm UpdatePassword
                string url = "https://localhost:7152/api/User" + "/" + resetResponse.UserId;
                HttpContent httpContent = new StringContent(JsonSerializer.Serialize(dataUpdate), Encoding.UTF8, "application/json");
                HttpResponseMessage requestMessage = await httpClient.PutAsync(url, httpContent);

                if (!requestMessage.IsSuccessStatusCode)
                {
                    ViewData["Error"] = "Failed to update the password.";
                    return View("ResetPassword");
                }

                SendPasswordEmail(resetResponse.Email, newPassword);

                // Set the success message in ViewData
                ViewData["Success"] = "Reset Success";

            }
            return View("ResetPassword");
        }

        private string GenerateNewPassword()
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=";
            const int passwordLength = 8;

            var random = new Random();
            var newPassword = new StringBuilder();

            for (int i = 0; i < passwordLength; i++)
            {
                int index = random.Next(allowedChars.Length);
                newPassword.Append(allowedChars[index]);
            }

            return newPassword.ToString();
        }
        private void SendPasswordEmail(string email, string newPassword)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("managementcoffeeG1@gmail.com", "xdswzxbizecjpskr"),
                EnableSsl = true,
                UseDefaultCredentials = false
            };

            // Set the custom display name for the sender
            string senderDisplayName = "Hotel Booking";

            // Specify the sender email address and display name using the MailAddress constructor
            var senderAddress = new MailAddress("managementcoffeeG1@gmail.com", senderDisplayName);
            var message = new MailMessage
            {
                From = new MailAddress(senderAddress.Address, senderAddress.DisplayName),
                Subject = "Reset Password Hotel Booking",
                Body = $"Mật khẩu được đặt lại của bạn là: {newPassword}"
            };

            message.To.Add(email);

            smtpClient.Send(message);
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Customer_Home", "Customer");
        }
    }
}
