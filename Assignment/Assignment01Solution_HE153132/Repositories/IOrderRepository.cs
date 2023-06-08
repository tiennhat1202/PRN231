using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order o);
        List<OrderDetail> GetOrderDetailsByOid(int oid);
        Order GetOrderById(int id);
        void DeleteOrder(int id);
        void UpdateOrder(Order p);
        List<Order> GetOrders();
        List<Order> FilterDateOrder(DateTime dateFrom, DateTime dateTo);
        decimal GetTotalSalesByOid(int oid);
    }
}
