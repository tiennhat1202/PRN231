using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.RoomImageDTO
{
    public class RoomImageResponseDTO
    {
        public int ImageId { get; set; }
        public int? RoomId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
