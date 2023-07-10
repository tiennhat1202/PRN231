using AutoMapper;
using BussinessObject.DTO.RoomImageDTO;
using BussinessObject.DTO.RoomTypeDTO;
using BussinessObject.Models;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;
        public RoomTypeController(IRoomTypeRepository roomTypeRepository, IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<RoomTypeResponseDTO>> GetRoomTypes()
        {
            return Ok(_mapper.Map<IEnumerable<RoomTypeResponseDTO>>(_roomTypeRepository.GetAllRoomType()).AsQueryable());
        }
        [HttpGet("{id}")]
        public IActionResult GetRoomType(int id)
        {
            return Ok(_mapper.Map<RoomTypeResponseDTO>(_roomTypeRepository.GetRoomTypeById(id)));
        }
        [HttpPost]
        public IActionResult PostRoomType([FromBody] RoomTypeRequestDTO roomTypeRequest)
        {
            _roomTypeRepository.Add(_mapper.Map<RoomType>(roomTypeRequest));
            return Ok(roomTypeRequest);
        }
        [HttpPut("{id}")]
        public IActionResult PutRoomType(int id, [FromBody] RoomTypeRequestDTO roomTypeRequest)
        {
            if (_roomTypeRepository.GetRoomTypeById(id) == null)
            {
                return NotFound();
            }
            _roomTypeRepository.Update(_mapper.Map<RoomType>(roomTypeRequest));
            return Ok(roomTypeRequest);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoomType(int id)
        {
            _roomTypeRepository.Delete(id);
            return Ok();
        }
    }
}
