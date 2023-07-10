using AutoMapper;
using BusinessObject.DTO.RoleDTO;
using BusinessObject.Models;

namespace eBookStoreApi.Services
{
    public class RoleMapper : Profile
    {
        public RoleMapper() {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
