using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product p);
        Product GetProductById(int id);
        void DeleteProduct(int id);
        void UpdateProduct(Product p);
        List<Product> GetProducts();
        List<Product> GetProductsByFilter(string searchString);
    }
}
