using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.RoomTypeDTO
{
    public class RoomTypeRequestDTO
    {
        public int RoomTypeId { get; set; }
        public string? RoomTypeName { get; set; }
        public string? Description { get; set; }
    }
}
