using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("email_address")]
        public string? EmailAddress { get; set; }

        public string? Password { get; set; }

        public string? Source { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("middle_name")]
        public string? MiddleName { get; set; }
        [Column("last_name")]
        public string? LastName { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [ForeignKey("Publisher")]
        public int PubId { get; set; }

        [Column("hire_date")]
        public DateTime? HireDate { get; set; }

        public virtual Role Role { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
