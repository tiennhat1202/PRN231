using AutoMapper;
using BussinessObject.DTO.HotelImageDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class HotelImageMapper : Profile
    {
        public HotelImageMapper()
        {
            CreateMap<HotelImage, HotelImageRequestDTO>().ReverseMap();
            CreateMap<HotelImage, HotelImageResponseDTO>().ReverseMap();
        }
    }
}
