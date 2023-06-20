using AutoMapper;
using BusinessObject.DTO.UserDTO;
using BusinessObject.Models;

namespace eBookStoreAPI.Services
{
    public class UserMapper : Profile
    {
        public UserMapper() {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserRequestDTO>().ReverseMap();
            CreateMap<User, UserFormLoginDTO>().ReverseMap();
            CreateMap<User, UserUpdateRequestDTO>().ReverseMap();
        }
    }
}
