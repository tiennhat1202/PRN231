using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.HotelDTO
{
    public class HotelRequestDTO
    {
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }
}
