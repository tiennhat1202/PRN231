using AutoMapper;
using BussinessObject.DTO.PaymentDTO;
using BussinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<PaymentResponseDTO>> GetPayments()
        {
            return Ok(_mapper.Map<IEnumerable<PaymentResponseDTO>>(_paymentRepository.GetAllPayment()).AsQueryable());
        }
        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            return Ok(_mapper.Map<PaymentResponseDTO>(_paymentRepository.GetPaymentById(id)));
        }

        [HttpPost]
        public IActionResult PostPayment([FromBody] PaymentResponseDTO paymentResponse)
        {
            _paymentRepository.Add(_mapper.Map<Payment>(paymentResponse));
            return Ok(paymentResponse);
        }

        [HttpPut("{id}")]
        public IActionResult PutPayment(int id, [FromBody] PaymentRequestDTO paymentRequest) {
            if(_paymentRepository.GetPaymentById(id) == null)
            {
                return NotFound();
            }
            _paymentRepository.Update(_mapper.Map<Payment>(paymentRequest));
            return Ok(paymentRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            _paymentRepository.Delete(id);
            return Ok();
        }
    }
}
