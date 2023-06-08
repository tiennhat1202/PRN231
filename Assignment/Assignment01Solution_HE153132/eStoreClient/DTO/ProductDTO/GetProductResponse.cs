using BusinessObject;
using System.ComponentModel.DataAnnotations;

namespace eStoreClient.DTO.ProductDTO
{
    public class GetProductResponse
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public double Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
    }
}
