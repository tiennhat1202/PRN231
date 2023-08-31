using AutoMapper;
using BussinessObject.DTO.RoomTypeDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class RoomTypeMapper : Profile
    {
        public RoomTypeMapper()
        {
            CreateMap<RoomType, RoomTypeRequestDTO>().ReverseMap();
            CreateMap<RoomType, RoomTypeResponseDTO>().ReverseMap();
        }
    }
}
