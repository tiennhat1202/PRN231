using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.BookAuthorDTO
{
    public class BookAuthorDTO
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public int AuthorOrder { get; set; }
        public double RoyaltyPercentage { get; set; }
    }
}
