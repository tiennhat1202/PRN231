using BusinessObjects.DBContext;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    listProducts = context.Products.Include(x => x.Category).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProducts;
        }
        public static Product FindProductById(int prodId)
        {
            Product product = null;
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    product = context.Products.Include(x => x.Category).SingleOrDefault(x => x.ProductId == prodId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public static void SaveProduct(Product product)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                   // context.Products.Update(product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteProduct(Product product)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    var p1 = context.Products.SingleOrDefault(x => x.ProductId == product.ProductId);
                    context.Products.Remove(p1);
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
