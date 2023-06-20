using BusinessObject.DTO.AuthorDTO;

namespace eBookStoreClient.Models
{
    public class AuthorIndexModel
    {
        public IEnumerable<AuthorDTO> AuthorList { get; set; }  
        public AuthorDTO SearchAuthor { get; set; }
    }
}
