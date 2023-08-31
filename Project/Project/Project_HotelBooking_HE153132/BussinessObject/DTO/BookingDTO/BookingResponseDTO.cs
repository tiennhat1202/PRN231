using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.BookingDTO
{
    public class BookingResponseDTO
    {
        public int BookingId { get; set; }
        public int? RoomId { get; set; }
        public string? RoomName { get; set; }
        public int? UserId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Status { get; set; }
        public string? username { get; set; }
    }
}
