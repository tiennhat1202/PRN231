using AutoMapper;
using BusinessObject.DTO.BookAuthorDTO;
using BusinessObject.Models;

namespace eBookStoreApi.Mapping
{
    public class BookAuthorMapper: Profile
    {
        public BookAuthorMapper() {
            CreateMap<BookAuthor, BookAuthorDTO>().ReverseMap();
        }
    }
}
