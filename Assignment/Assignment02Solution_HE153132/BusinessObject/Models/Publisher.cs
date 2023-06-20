using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        [Column("pub_id")]
        public int PubId { get; set; }

        [Column("publisher_name")]
        public string? PublisherName { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
