using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order o) => OrderDAO.AddOrder(o);

        public void DeleteOrder(int id) => OrderDAO.DeleteOrder(id);

        public List<OrderDetail> GetOrderDetailsByOid(int oid) => OrderDAO.FindOrderDetailsByOid(oid);

        public Order GetOrderById(int id) => OrderDAO.FindOrderById(id);

        public List<Order> GetOrders() => OrderDAO.GetOrders();

        public void UpdateOrder(Order p) => OrderDAO.UpdateOrder(p);

        public decimal GetTotalSalesByOid(int id) => OrderDAO.TotalSalesByOid(id);

        public List<Order> FilterDateOrder(DateTime dateFrom, DateTime dateTo) => OrderDAO.FilterDateOrder(dateFrom, dateTo);

    }
}
