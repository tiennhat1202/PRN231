using AutoMapper;
using BusinessObject.Models;
using BusinessObject.DTO.AuthorDTO;

namespace eBookStoreAPI.Services
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper() {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Author, AuthorRequestDTO>().ReverseMap();
        }
    }
}
