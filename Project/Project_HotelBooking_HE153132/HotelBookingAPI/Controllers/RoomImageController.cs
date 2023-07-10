using AutoMapper;
using BussinessObject.DTO.RoomImageDTO;
using BussinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomImageController : ControllerBase
    {
        private readonly IRoomImageRepository _roomImageRepository;
        private readonly IMapper _mapper;
        public RoomImageController(IRoomImageRepository roomImageRepository, IMapper mapper)
        {
            _roomImageRepository = roomImageRepository;
            _mapper = mapper;
        }
        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<RoomImageResponseDTO>> GetRoomImages()
        {
            return Ok(_mapper.Map<IEnumerable<RoomImageResponseDTO>>(_roomImageRepository.GetAllRoomImage()).AsQueryable());
        }
        [HttpGet("{id}")]
        public IActionResult GetRoomImage(int id)
        {
            return Ok(_mapper.Map<RoomImageResponseDTO>(_roomImageRepository.GetRoomImageById(id)));
        }
        [HttpPost]
        public IActionResult PostRoomImage([FromBody] RoomImageRequestDTO roomImageRequest)
        {
            _roomImageRepository.Add(_mapper.Map<RoomImage>(roomImageRequest));
            return Ok(roomImageRequest);
        }
        [HttpPut("{id}")]
        public IActionResult PutRoomImage(int id, [FromBody] RoomImageRequestDTO roomImageRequest)
        {
            if (_roomImageRepository.GetRoomImageById(id) == null)
            {
                return NotFound();
            }
            _roomImageRepository.Update(_mapper.Map<RoomImage>(roomImageRequest));
            return Ok(roomImageRequest);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoomImage(int id)
        {
            _roomImageRepository.Delete(id);
            return Ok();
        }
    }
}
