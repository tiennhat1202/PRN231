using AutoMapper;
using BusinessObject.DTO.BookAuthorDTO;
using BusinessObject.Models;

namespace eBookStoreAPI.Mapping
{
    public class BookAuthorMapper: Profile
    {
        public BookAuthorMapper() {
            CreateMap<BookAuthor, BookAuthorDTO>().ReverseMap();
        }
    }
}
