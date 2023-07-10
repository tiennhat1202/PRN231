using AutoMapper;
using BussinessObject.DTO.BookingDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class BookingMapper : Profile
    {
        public BookingMapper()
        {
            CreateMap<Booking, BookingResponseDTO>()
                .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.User.Username))
                .ReverseMap();
            CreateMap<Booking, BookingRequestDTO>().ReverseMap();

        }
    }
}
