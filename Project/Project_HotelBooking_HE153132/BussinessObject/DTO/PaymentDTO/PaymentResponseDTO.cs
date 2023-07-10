using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.PaymentDTO
{
    public class PaymentResponseDTO
    {
        public int PaymentId { get; set; }
        public int? BookingId { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
