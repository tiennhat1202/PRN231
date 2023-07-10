using AutoMapper;
using BusinessObject.DTO.BookDTO;
using BusinessObject.Models;

namespace eBookStoreAPI.Mapping
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookRequestDTO>().ReverseMap();    
        }
    }
}
