using AutoMapper;
using BussinessObject.DTO.RoleDTO;
using BussinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<RoleResponseDTO>> GetRoles()
        {
            return Ok(_mapper.Map<IEnumerable<RoleResponseDTO>>(_roleRepository.GetAllRole()).AsQueryable());
        }
        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            return Ok(_mapper.Map<RoleResponseDTO>(_roleRepository.GetRoleById(id)));
        }

        [HttpPost]
        public IActionResult PostRole([FromBody] RoleRequestDTO roleRequest)
        {
            _roleRepository.Add(_mapper.Map<Role>(roleRequest));
            return Ok(roleRequest);
        }

        [HttpPut("{id}")]
        public IActionResult PutRole(int id, [FromBody] RoleRequestDTO roleRequest)
        {
            if (_roleRepository.GetRoleById(id) == null)
            {
                return NotFound();
            }
            _roleRepository.Update(_mapper.Map<Role>(roleRequest));
            return Ok(roleRequest);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            _roleRepository.Delete(id);
            return Ok();
        }
    }
}
