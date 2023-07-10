using AutoMapper;
using BussinessObject.DTO.RoleDTO;
using BussinessObject.Models;

namespace HotelBookingAPI.Mapping
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleRequestDTO>().ReverseMap();
            CreateMap<Role, RoleResponseDTO>().ReverseMap();
        }
    }
}
