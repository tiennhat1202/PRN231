using AutoMapper;
using BussinessObject.DTO.RoomDTO;
using BussinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomController(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<RoomResponseDTO>> GetRooms()
        {
            return Ok(_mapper.Map<IEnumerable<RoomResponseDTO>>(_roomRepository.GetAllRoom()).AsQueryable());
        }
        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            return Ok(_mapper.Map<RoomResponseDTO>(_roomRepository.GetRoomById(id)));
        }
        [HttpPost]
        public IActionResult PostRoom([FromBody] RoomRequestDTO roomRequest)
        {
            _roomRepository.Add(_mapper.Map<Room>(roomRequest));
            return Ok(roomRequest);
        }
        [HttpPut("{id}")]
        public IActionResult PutRoom(int id, [FromBody] RoomRequestDTO roomRequest)
        {
            if(_roomRepository.GetRoomById(id) == null)
            {
                return NotFound();
            }
            _roomRepository.Update(_mapper.Map<Room>(roomRequest));
            return Ok(roomRequest);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            _roomRepository.Delete(id);
            return Ok();
        }
    }

}
