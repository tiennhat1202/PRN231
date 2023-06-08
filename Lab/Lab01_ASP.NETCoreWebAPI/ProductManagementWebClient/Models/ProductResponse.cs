using BusinessObjects_;
using System.Text.Json.Serialization;

namespace ProductManagementWebClient.Models
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual CategoryResponse Category { get; set; }

        public ProductResponse(Product product)
        {
            this.ProductId = product.ProductId;
            this.ProductName = product.ProductName;
            this.CategoryId = product.CategoryId;
            this.UnitsInStock = product.UnitsInStock;
            this.UnitPrice = product.UnitPrice;
            this.Category = new CategoryResponse(product.Category);
        }

        [JsonConstructor]
        public ProductResponse(int productId, string productName, int categoryId, int unitsInStock, decimal unitPrice, CategoryResponse category)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            UnitsInStock = unitsInStock;
            UnitPrice = unitPrice;
            Category = category;
        }
        public static List<ProductResponse> DTO(List<Product> products)
        {
            List<ProductResponse> productResponse = new List<ProductResponse>();
            foreach (var item in products)
            {
                productResponse.Add(new ProductResponse(item));
            }
            return productResponse;
        }
    }
}
