using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.DTO.ProductDTO
{
    public class CreateProductRequest
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int? UnitsInStock { get; set; }
    }
}
