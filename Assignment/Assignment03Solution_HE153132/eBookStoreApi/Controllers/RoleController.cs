using AutoMapper;
using BusinessObject.DBContext;
using BusinessObject.DTO.RoleDTO;
using BusinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreApi.Controllers
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
        public ActionResult<IEnumerable<RoleDTO>> GetRoles()
        {
            return Ok(_mapper.Map<IEnumerable<RoleDTO>>(_roleRepository.Get()).AsQueryable());
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            return Ok(_roleRepository.GetRoleById(id));
        }

        [HttpPost]
        public IActionResult PostRole([FromBody] RoleDTO role)
        {
            _roleRepository.Add(_mapper.Map<Role>(role));
            return Ok(role);
        }

        [HttpPut("{id}")]
        public IActionResult PutRole(int id, [FromBody] RoleDTO role)
        {
           if (_roleRepository.GetRoleById(id) == null)
            {
                return NotFound();
            }
            _roleRepository.Update(_mapper.Map<Role>(role));
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            _roleRepository.Delete(id);
            return Ok();
        }
    }
}
