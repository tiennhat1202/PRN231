using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.HotelImageDTO
{
    public class HotelImageRequestDTO
    {
        public int ImageId { get; set; }
        public int? HotelId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
