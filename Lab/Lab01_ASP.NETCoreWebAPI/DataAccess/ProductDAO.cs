﻿using BusinessObjects_;
using Microsoft.EntityFrameworkCore;
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
                using (var context = new DBContext())
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
                using (var context = new DBContext())
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
                using (var context = new DBContext())
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
                using (var context = new DBContext())
                {
                    context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                using (var context = new DBContext())
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
