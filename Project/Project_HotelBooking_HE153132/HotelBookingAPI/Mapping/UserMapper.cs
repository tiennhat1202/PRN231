using AutoMapper;
using BussinessObject.DTO.UserDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserRequestDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserLoginResponse>().ReverseMap();
        }
    }
}
