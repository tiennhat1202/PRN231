using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
            RoomImages = new HashSet<RoomImage>();
        }

        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public int? RoomTypeId { get; set; }
        public decimal? PricePerNight { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public int? HotelId { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public virtual RoomType? RoomType { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<RoomImage> RoomImages { get; set; }
    }
}
