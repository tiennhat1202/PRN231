using AutoMapper;
using BussinessObject.DTO.BookingDTO;
using BussinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private IMapper _mapper;

        public BookingController(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<BookingResponseDTO>> GetBookings()
        {
            return Ok(_mapper.Map<IEnumerable<BookingResponseDTO>>(_bookingRepository.GetAllBooking()).AsQueryable());
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            return Ok(_bookingRepository.GetBookingById(id));
        }

        [HttpPost]
        public IActionResult PostBooking([FromBody] BookingRequestDTO bookingRequest)
        {
            _bookingRepository.Add(_mapper.Map<Booking>(bookingRequest));
            return Ok(bookingRequest);
        }

        [HttpPut("{id}")]
        public IActionResult PutBooking(int id, [FromBody] BookingRequestDTO bookingRequest)
        {
            if(_bookingRepository.GetBookingById(id) == null)
            {
                return NotFound();
            }
            _bookingRepository.Update(_mapper.Map<Booking>(bookingRequest));
            return Ok(bookingRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            _bookingRepository.Delete(id);
            return Ok();
        }
    }
}
    