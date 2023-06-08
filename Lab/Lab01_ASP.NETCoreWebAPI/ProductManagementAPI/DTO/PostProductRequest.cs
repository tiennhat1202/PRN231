using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.DTO
{
    public class PostProductRequest
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int UnitsInStock { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
    }
}
