using BusinessObjects;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(Product p);
        void DeleteProduct(Product p);
        void UpdateProduct(Product p);
        Product GetProductById(int id);
        List<Category> GetCategories();
        List<Product> GetProducts();
    }
}