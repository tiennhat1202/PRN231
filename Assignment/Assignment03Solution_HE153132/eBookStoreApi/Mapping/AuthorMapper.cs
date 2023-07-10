using AutoMapper;
using BusinessObject.Models;
using BusinessObject.DTO.AuthorDTO;

namespace eBookStoreApi.Services
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper() {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Author, AuthorRequestDTO>().ReverseMap();
        }
    }
}
