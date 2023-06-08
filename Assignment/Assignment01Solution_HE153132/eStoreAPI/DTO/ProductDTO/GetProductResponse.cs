using BusinessObject;
using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.DTO.ProductDTO
{
    public class GetProductResponse
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public double Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }

        public GetProductResponse(Product product)
        {
            this.ProductId = product.ProductId;
            this.CategoryId = product.CategoryId;
            this.ProductName = product.ProductName;
            this.Weight = product.Weight;
            this.UnitPrice = product.UnitPrice;
            this.UnitsInStock = product.UnitsInStock;
        }
        internal static List<GetProductResponse> ToDTO(List<Product> products)
        {
            List<GetProductResponse> getProductResponses = new List<GetProductResponse>();
            foreach (var item in products) getProductResponses.Add(new GetProductResponse(item));
            return getProductResponses;
        }
    }
}
