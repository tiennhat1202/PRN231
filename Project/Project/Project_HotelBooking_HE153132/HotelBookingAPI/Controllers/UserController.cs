using AutoMapper;
using BussinessObject.DTO.RoleDTO;
using BussinessObject.DTO.UserDTO;
using BussinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<UserResponseDTO>> GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<UserResponseDTO>>(_userRepository.GetAllUser()).AsQueryable());
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_mapper.Map<UserResponseDTO>(_userRepository.GetUserById(id)));
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] UserRequestDTO userRequest)
        {
            _userRepository.Add(_mapper.Map<User>(userRequest));
            return Ok(userRequest);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody] UserRequestDTO userRequest)
        {
            if (_userRepository.GetUserById(id) == null)
            {
                return NotFound();
            }
            _userRepository.Update(_mapper.Map<User>(userRequest));
            return Ok(userRequest);
        }

        [HttpPut("changepassword/{id}")]
        public IActionResult ChangePassword(int id, [FromBody] UserChangePasswordDTO userChangePasswordDTO)
        {
            var userGet = _userRepository.GetUserById(id);
            if (userGet == null)
            {
                return NotFound();
            }

            User userChangePassword = new User
            {
                Password = userChangePasswordDTO.Password,
                UserId = userChangePasswordDTO.UserId,
                RoleId = userGet.RoleId,
                Username = userGet.Username,
                Email = userGet.Email,
                Phone = userGet.Phone
            };

            _userRepository.Update(_mapper.Map<User>(userChangePassword));
            return Ok(userChangePasswordDTO);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok();
        }

        
    }
}
