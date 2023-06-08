using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    listProducts = context.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listProducts;
        }

        public static List<Product> GetProductsByFilter(string searchString)
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    listProducts = context.Products
                        .Where(p => p.ProductName!.Contains(searchString) || p.UnitPrice.ToString().Contains(searchString)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listProducts;
        }

        public static Product FindProductById(int id)
        {
            var product = new Product();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    product = context.Products.SingleOrDefault(p => p.ProductId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return product!;
        }

        public static void AddProduct(Product p)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateProduct(Product newProduct)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    Product oldProduct = context.Products.SingleOrDefault(p => p.ProductId == newProduct.ProductId)!;
                    if (oldProduct != null)
                    {
                        oldProduct.CategoryId = newProduct.CategoryId;
                        oldProduct.ProductName = newProduct.ProductName;
                        oldProduct.Weight = newProduct.Weight;
                        oldProduct.UnitPrice = newProduct.UnitPrice;
                        oldProduct.UnitsInStock = newProduct.UnitsInStock;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("This product does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProduct(int id)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Products.Remove(context.Products.SingleOrDefault(p => p.ProductId == id)!);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
