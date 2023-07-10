using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            HotelImages = new HashSet<HotelImage>();
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<HotelImage> HotelImages { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
