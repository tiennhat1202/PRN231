using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [Column("book_id")]
        public int BookId { get; set; }

        public string? Title { get; set; }

        public string? Type { get; set; }

        [ForeignKey("Publisher")]
        public int PubId { get; set; }

        public double? Price { get; set; }

        public double? Advance { get; set; }

        public double? Royalty { get; set; }

        public double? YtdSales { get; set; }

        public string? Notes { get; set; }

        [Column("published_date")]
        public DateTime? PublishedDate { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
