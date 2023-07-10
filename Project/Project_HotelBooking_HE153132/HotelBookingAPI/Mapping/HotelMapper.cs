using AutoMapper;
using BussinessObject.DTO.HotelDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class HotelMapper : Profile
    {
        public HotelMapper() {
            CreateMap<Hotel, HotelResponseDTO>().ReverseMap();
            CreateMap<Hotel, HotelRequestDTO>().ReverseMap();   
        }
    }
}
