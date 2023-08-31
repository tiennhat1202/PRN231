using BussinessObject.DTO.RoomImageDTO;
using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.RoomDTO
{
    public class RoomResponseHomeCustomerDTO
    {
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public int? RoomTypeId { get; set; }
        public decimal? PricePerNight { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public int? HotelId { get; set; }
        public string? RoomTypeName { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? HotelDescription { get; set; }
        public List<RoomImageResponseDTO> RoomImages { get; set; }

    }
}
