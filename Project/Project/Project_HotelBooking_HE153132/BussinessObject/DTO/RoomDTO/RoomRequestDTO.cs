using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.RoomDTO
{
    public class RoomRequestDTO
    {
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public int? RoomTypeId { get; set; }
        public decimal? PricePerNight { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public int? HotelId { get; set; }
    }
}
