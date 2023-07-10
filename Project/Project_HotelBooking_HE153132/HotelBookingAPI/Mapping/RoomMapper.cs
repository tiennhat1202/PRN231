using AutoMapper;
using BussinessObject.DTO.RoomDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<Room, RoomRequestDTO>().ReverseMap();
            CreateMap<Room, RoomResponseDTO>().ReverseMap();
        }
    }
}
