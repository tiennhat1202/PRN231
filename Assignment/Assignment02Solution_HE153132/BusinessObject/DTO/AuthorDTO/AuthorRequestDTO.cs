using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.AuthorDTO
{
    public class AuthorRequestDTO
    {
        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? City { get; set; }

        public string? EmailAddress { get; set; }
    }
}
