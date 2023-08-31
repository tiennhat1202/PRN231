using AutoMapper;
using BussinessObject.DTO.HotelDTO;
using BussinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelController(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<HotelResponseDTO>> GetHotels()
        {
            return Ok(_mapper.Map<IEnumerable<HotelResponseDTO>>(_hotelRepository.GetAllHotels()).AsQueryable());
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            return Ok(_mapper.Map<HotelResponseDTO>(_hotelRepository.GetHotelById(id)));
        }

        [HttpPost]
        public IActionResult PostHotel([FromBody] HotelRequestDTO hotelRequest)
        {
            _hotelRepository.Add(_mapper.Map<Hotel>(hotelRequest));
            return Ok(hotelRequest);
        }

        [HttpPut("{id}")]
        public IActionResult PutHotel(int id, [FromBody] HotelRequestDTO hotelRequest)
        {
            if(_hotelRepository.GetHotelById(id) == null)
            {
                return NotFound();
            }
            _hotelRepository.Update(_mapper.Map<Hotel>(hotelRequest));
            return Ok(hotelRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            _hotelRepository.Delete(id);
            return Ok();
        }

    }
}
