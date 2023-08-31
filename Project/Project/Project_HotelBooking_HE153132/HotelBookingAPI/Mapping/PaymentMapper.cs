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
            CreateMap<Payment, PaymentResponseDTO>()
                .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.PaymentId))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Booking.Room.RoomName))
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.Booking.BookingId))
                .ForMember(dest => dest.CheckInDate, opt => opt.MapFrom(src => src.Booking.CheckInDate))
                .ForMember(dest => dest.CheckOutDate, opt => opt.MapFrom(src => src.Booking.CheckOutDate))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Booking.TotalPrice))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Booking.User.Username))
                .ReverseMap();
        }
    }
}
