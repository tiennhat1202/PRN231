using BusinessObjects_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(Product product);
        Product GetProductById(int id);
        void DeleteProduct(Product p);
        void UpdateProduct(Product p);
        List<Category> GetCategories();
        List<Product> GetProducts();
    }
}
