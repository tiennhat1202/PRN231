using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    [Table("BookAuthor")]
    public class BookAuthor
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int BookId { get; set; }

        public int AuthorOrder { get; set; }

        public double RoyaltyPercentage { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
