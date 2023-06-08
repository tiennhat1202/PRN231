using System.ComponentModel.DataAnnotations;

namespace eStoreClient.DTO.OrderDTO
{
    public class CreateOrderRequest
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public DateTime? RequireDate { get; set; }
        [Required]
        public DateTime? ShippedDate { get; set; }
        [Required]
        public decimal Freight { get; set; }
    }
}
