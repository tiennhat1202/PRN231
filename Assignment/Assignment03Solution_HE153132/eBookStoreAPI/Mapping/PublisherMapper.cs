using AutoMapper;
using BusinessObject.Models;
using BusinessObject.DTO.PublisherDTO;

namespace eBookStoreAPI.Services
{
    public class PublisherMapper : Profile
    {
        public PublisherMapper() {
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
            CreateMap<Publisher, PublisherRequestDTO>().ReverseMap();  
        }
    }
}
