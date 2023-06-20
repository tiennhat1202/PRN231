using BusinessObject.DTO.BookDTO;

namespace eBookStoreClient.Models
{
    public class BookIndexModel
    {
        public IEnumerable<BookDTO> BookLists { get; set; }
        public BookDTO SearchBook { get; set; }

    }
}
