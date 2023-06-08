using System.ComponentModel.DataAnnotations;

namespace eStoreClient.DTO.OrderDTO
{
    public class UpdateOrderRequest
    {
        public int OrderId { get; set; }
        [Required]
        public DateTime? RequireDate { get; set; }
        [Required]
        public DateTime? ShippedDate { get; set; }
        [Required]
        public decimal Freight { get; set; }
    }
}
