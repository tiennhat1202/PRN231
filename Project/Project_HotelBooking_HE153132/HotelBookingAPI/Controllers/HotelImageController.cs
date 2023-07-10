using AutoMapper;
using BussinessObject.DTO.HotelDTO;
using BussinessObject.DTO.HotelImageDTO;
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
    public class HotelImageController : ControllerBase
    {
        private readonly IHotelImageRepository _hotelImgRepository;
        private readonly IMapper _mapper;

        public HotelImageController(IHotelImageRepository hotelImgRepository, IMapper mapper)
        {
            _hotelImgRepository = hotelImgRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<HotelImageResponseDTO>> GetHotelImages()
        {
            return Ok(_mapper.Map<IEnumerable<HotelImageResponseDTO>>(_hotelImgRepository.GetAllHotelImg()).AsQueryable());
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelImgById(int id)
        {
            return Ok(_mapper.Map<HotelImageResponseDTO>(_hotelImgRepository.GetHotelImgById(id)));
        }

        [HttpPost]
        public IActionResult PostHotelImg([FromBody] HotelImageRequestDTO hotelImgRequest)
        {
            _hotelImgRepository.Add(_mapper.Map<HotelImage>(hotelImgRequest));
            return Ok(hotelImgRequest);
        }

        [HttpPut("{id}")]
        public IActionResult PutHotelImg(int id, [FromBody] HotelImageRequestDTO hotelImgRequest)
        {
            if (_hotelImgRepository.GetHotelImgById(id) == null)
            {
                return NotFound();
            }
            _hotelImgRepository.Update(_mapper.Map<HotelImage>(hotelImgRequest));
            return Ok(hotelImgRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotelImg(int id)
        {
            _hotelImgRepository.Delete(id);
            return Ok();
        }
    }
}
