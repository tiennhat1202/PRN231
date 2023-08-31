using AutoMapper;
using BussinessObject.DTO.RoomDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<Room, RoomRequestDTO>()
                .ReverseMap();
            CreateMap<Room, RoomResponseDTO>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType!.RoomTypeName))
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel!.HotelName))
                .ReverseMap();
            CreateMap<Room, RoomResponseHomeCustomerDTO>()
                .ForMember(x => x.RoomTypeName, opt => opt.MapFrom(src => src.RoomType!.RoomTypeName))
                .ForMember(x => x.HotelName, opt => opt.MapFrom(src => src.Hotel!.HotelName))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Hotel!.Address))
                .ForMember(x => x.State, opt => opt.MapFrom(src => src.Hotel!.State))
                .ForMember(X => X.Country, opt => opt.MapFrom(src => src.Hotel!.Country))
                .ForMember(x => x.Contact, opt => opt.MapFrom(src => src.Hotel!.Contact))
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Hotel!.Email))
                .ForMember(x => x.HotelDescription, opt => opt.MapFrom(src => src.Hotel!.Description))
                .ForMember(x => x.RoomImages, opt => opt.MapFrom(src => src.RoomImages));
        }
    }
}
