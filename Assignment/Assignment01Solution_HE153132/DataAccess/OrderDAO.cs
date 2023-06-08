using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    listOrders = context.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrders;
        }

        public static List<Order> FilterDateOrder(DateTime dateFrom, DateTime dateTo)
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    listOrders = context.Orders.Where(o => o.OrderDate >= dateFrom && o.OrderDate <= dateTo)
                                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrders;
        }

        public static decimal TotalSalesByOid(int oid)
        {
            decimal total = 0;
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    total = context.OrderDetails.Where(od => od.OrderId == oid).Sum(od => od.UnitPrice);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return total;
        }

        public static List<OrderDetail> FindOrderDetailsByOid(int oid)
        {
            var order = new List<OrderDetail>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    order = context.OrderDetails.Where(od => od.OrderId == oid).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return order;
        }

        public static Order FindOrderById(int id)
        {
            var order = new Order();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    order = context.Orders.SingleOrDefault(o => o.OrderId == id)!;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return order;
        }

        public static void AddOrder(Order o)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Orders.Add(o);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrder(Order newOrder)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    Order oldOrder = context.Orders.SingleOrDefault(o => o.OrderId == newOrder.OrderId)!;
                    if (oldOrder != null)
                    {
                        oldOrder.RequireDate = newOrder.RequireDate;
                        oldOrder.ShippedDate = newOrder.ShippedDate;
                        oldOrder.Freight = newOrder.Freight;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("This order does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteOrder(int id)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    var order = context.Orders.SingleOrDefault(o => o.OrderId == id)!;
                    var orderDetails = context.OrderDetails.Where(od => od.OrderId == id).ToList();
                    foreach (var item in orderDetails)
                    {
                        context.OrderDetails.Remove(item);
                    }
                    context.Orders.Remove(order);
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
