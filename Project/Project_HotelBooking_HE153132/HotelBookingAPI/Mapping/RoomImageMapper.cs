using AutoMapper;
using BussinessObject.DTO.RoomImageDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class RoomImageMapper : Profile
    {
        public RoomImageMapper()
        {
            CreateMap<RoomImage, RoomImageRequestDTO>().ReverseMap();
            CreateMap<RoomImage, RoomImageResponseDTO>().ReverseMap();
        }
    }
}
