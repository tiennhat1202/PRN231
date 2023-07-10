using AutoMapper;
using BussinessObject.DTO.UserDTO;
using BussinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO userLogin)
        {

            User user = _userRepository.GetUserLogin(userLogin.Username, userLogin.Password);
            if (user == null)
            {
                return NotFound("Account incorrect!");
            }
            UserLoginResponse userLoginResponse = new UserLoginResponse()
            {
                Username = user.Username,
                Password = user.Password,
                RoleId = user.RoleId
            };
            return Ok(userLoginResponse);
        }
    }
}
