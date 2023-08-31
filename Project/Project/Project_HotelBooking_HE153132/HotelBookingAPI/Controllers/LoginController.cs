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

            User user = _userRepository.GetUserLogin(userLogin.Email, userLogin.Password);
            if (user == null)
            {
                return NotFound("Account incorrect!");
            }
            UserLoginResponse userLoginResponse = new UserLoginResponse()
            {
                UserId = user.UserId,
                Email = user.Email,
                RoleId = user.RoleId,
                Username = user.Username,
                Phone = user.Phone
            };
            return Ok(userLoginResponse);
        }

        [HttpPost("reset")]
        public IActionResult Reset([FromBody] UserResetPasswordDTO userReset) {
            User user = _userRepository.GetEmailResetPassword(userReset.Email);
            if (user == null)
            {
                return NotFound("Email incorrect!");
            }
            UserResetPasswordDTO userResetPasswordDTO = new UserResetPasswordDTO()
            {
                UserId = user.UserId,
                RoleId = user.RoleId,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                Phone = user.Phone
            };
            return Ok(userResetPasswordDTO);
        }
    }
}
