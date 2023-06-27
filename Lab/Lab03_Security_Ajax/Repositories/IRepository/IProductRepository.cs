using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        List<Category> GetCategories();
        void SaveProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProductById(int id);
    }
}
