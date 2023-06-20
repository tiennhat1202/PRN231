using BusinessObject.DTO.PublisherDTO;
using BusinessObject.DTO.RoleDTO;
using BusinessObject.DTO.UserDTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStoreClient.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient httpClient;
        public UserController()
        {
            httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        }

        /// <summary>
        /// Get Role/Index
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login"); ;
            }
            HttpResponseMessage userResponse = await httpClient.GetAsync("https://localhost:7196/api/User");
            string stringDataUser = await userResponse.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<UserDTO> listUsers = JsonSerializer.Deserialize<List<UserDTO>>(stringDataUser, option);

            // Get Role descriptions for users
            HttpResponseMessage roleResponse = await httpClient.GetAsync("https://localhost:7196/api/Role");
            string stringDataRole = await roleResponse.Content.ReadAsStringAsync();
            List<RoleDTO> roleList = JsonSerializer.Deserialize<List<RoleDTO>>(stringDataRole, option);

            // Get Publisher names for users
            HttpResponseMessage pubResponse = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
            string stringDataPub = await pubResponse.Content.ReadAsStringAsync();
            List<PublisherDTO> pubList = JsonSerializer.Deserialize<List<PublisherDTO>>(stringDataPub, option);

            foreach (var user in listUsers)
            {
                // Find RoleDescription for the user
                var role = roleList.FirstOrDefault(r => r.RoleId == user.RoleId);
                if (role != null)
                {
                    user.RoleDescription = role.RoleDesc;
                }

                // Find PublisherName for the user
                var publisher = pubList.FirstOrDefault(p => p.PubId == user.PubId);
                if (publisher != null)
                {
                    user.PublisherName = publisher.PublisherName;
                }
            }

            return View(listUsers);
        }

        /// <summary>
        /// GET Role/Create
        /// GET Pub/Create
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage roleResponse = await httpClient.GetAsync("https://localhost:7196/api/Role");
            HttpResponseMessage pubResponse = await httpClient.GetAsync("https://localhost:7196/api/Publisher");


            string roleData = await roleResponse.Content.ReadAsStringAsync();
            string pubData = await pubResponse.Content.ReadAsStringAsync();

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<RoleDTO> roleResponses = JsonSerializer.Deserialize<List<RoleDTO>>(roleData, option);
            List<PublisherDTO> pubResponses = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, option);

            ViewBag.roles = roleResponses;
            ViewBag.pubs = pubResponses;

            return View();
        }

        /// <summary>
        /// Post User/Create
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRequestDTO user)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:7196/api/User", httpContent);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET Role/Edit/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage roleResponse = await httpClient.GetAsync("https://localhost:7196/api/Role");
            HttpResponseMessage pubResponse = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
            HttpResponseMessage userResponse = await httpClient.GetAsync("https://localhost:7196/api/User" + "/" + id);

            string roleData = await roleResponse.Content.ReadAsStringAsync();
            string pubData = await pubResponse.Content.ReadAsStringAsync();
            string userData = await userResponse.Content.ReadAsStringAsync();


            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<RoleDTO> roleResponses = JsonSerializer.Deserialize<List<RoleDTO>>(roleData, option);
            List<PublisherDTO> pubResponses = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, option);
            UserDTO userResponses = JsonSerializer.Deserialize<UserDTO>(userData, option);
            ViewBag.roles = roleResponses;
            ViewBag.pubs = pubResponses;

            return View(userResponses);
        }
        /// <summary>
        /// POST Role/Edit/Id
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UserRequestDTO user)
        {
            string url = "https://localhost:7196/api/User" + "/" + id;
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            HttpResponseMessage requestMessage = await httpClient.PutAsync(url, httpContent);
            string stringData = await requestMessage.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage roleResponse = await httpClient.GetAsync("https://localhost:7196/api/Role");
            HttpResponseMessage pubResponse = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
            HttpResponseMessage userResponse = await httpClient.GetAsync("https://localhost:7196/api/User" + "/" + id);

            string roleData = await roleResponse.Content.ReadAsStringAsync();
            string pubData = await pubResponse.Content.ReadAsStringAsync();
            string userData = await userResponse.Content.ReadAsStringAsync();


            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<RoleDTO> roleResponses = JsonSerializer.Deserialize<List<RoleDTO>>(roleData, option);
            List<PublisherDTO> pubResponses = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, option);
            UserDTO userResponses = JsonSerializer.Deserialize<UserDTO>(userData, option);

            // Find RoleDescription for the user
            var role = roleResponses.FirstOrDefault(r => r.RoleId == userResponses.RoleId);
            if (role != null)
            {
                userResponses.RoleDescription = role.RoleDesc;
            }
            // Find PublisherName for the user
            var publisher = pubResponses.FirstOrDefault(p => p.PubId == userResponses.PubId);
            if (publisher != null)
            {
                userResponses.PublisherName = publisher.PublisherName;
            }
            return View(userResponses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            string url = "https://localhost:7196/api/User" + "/" + id;
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(url);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details (int id)
        {
            HttpResponseMessage roleResponse = await httpClient.GetAsync("https://localhost:7196/api/Role");
            HttpResponseMessage pubResponse = await httpClient.GetAsync("https://localhost:7196/api/Publisher");
            HttpResponseMessage userResponse = await httpClient.GetAsync("https://localhost:7196/api/User" + "/" + id);

            string roleData = await roleResponse.Content.ReadAsStringAsync();
            string pubData = await pubResponse.Content.ReadAsStringAsync();
            string userData = await userResponse.Content.ReadAsStringAsync();


            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<RoleDTO> roleResponses = JsonSerializer.Deserialize<List<RoleDTO>>(roleData, option);
            List<PublisherDTO> pubResponses = JsonSerializer.Deserialize<List<PublisherDTO>>(pubData, option);
            UserDTO userResponses = JsonSerializer.Deserialize<UserDTO>(userData, option);

            // Find RoleDescription for the user
            var role = roleResponses.FirstOrDefault(r => r.RoleId == userResponses.RoleId);
            if (role != null)
            {
                userResponses.RoleDescription = role.RoleDesc;
            }
            // Find PublisherName for the user
            var publisher = pubResponses.FirstOrDefault(p => p.PubId == userResponses.PubId);
            if (publisher != null)
            {
                userResponses.PublisherName = publisher.PublisherName;
            }
            return View(userResponses);
        }
    }
}
