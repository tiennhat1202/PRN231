using AutoMapper;
using BussinessObject.DTO.PaymentDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class PaymentMapper : Profile
    {
        public PaymentMapper()
        {
            CreateMap<Payment, PaymentRequestDTO>().ReverseMap();
            CreateMap<Payment, PaymentResponseDTO>().ReverseMap();
        }
    }
}
