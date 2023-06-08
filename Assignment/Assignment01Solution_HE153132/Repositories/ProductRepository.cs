using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product p) => ProductDAO.AddProduct(p);

        public void DeleteProduct(int id) => ProductDAO.DeleteProduct(id);

        public Product GetProductById(int id) => ProductDAO.FindProductById(id);

        public List<Product> GetProducts() => ProductDAO.GetProducts();

        public List<Product> GetProductsByFilter(string searchString) => ProductDAO.GetProductsByFilter(searchString);

        public void UpdateProduct(Product p) => ProductDAO.UpdateProduct(p);
    }
}
