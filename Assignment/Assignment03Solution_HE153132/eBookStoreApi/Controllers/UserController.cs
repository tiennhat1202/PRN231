using AutoMapper;
using BusinessObject.DTO.UserDTO;
using BusinessObject.Models;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreApi.Controllers
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
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(_userRepository.Get()).AsQueryable());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetUserById(id));
        }

        [HttpGet("user")]
        public IActionResult GetUser(string username, string password)
        {
            var user = _userRepository.Get(username, password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("emailAdress")]
        public IActionResult GetUserByEmail(string email)
        {
            User user = _userRepository.GetUserByEmail(email);
            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserFormLoginDTO userForm)
        {
            User user = _userRepository.Get(userForm.EmailAddress, userForm.Password);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] UserRequestDTO user)
        {
            _userRepository.Add(_mapper.Map<User>(user));
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody] UserRequestDTO user)
        {
            if(_userRepository.GetUserById(id) == null)
            {
                return NotFound();
            }
            _userRepository.Update(_mapper.Map<User>(user));
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok();
        }
    }
}
