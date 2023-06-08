using BusinessObject;
using Repositories;

namespace eStoreAPI.DTO.OrderDTO
{
    public class GetTotalSaleResponse
    {
        private IOrderRepository orderRepository = new OrderRepository();
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequireDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalSale { get; set; }

        public GetTotalSaleResponse(Order o)
        {
            OrderId = o.OrderId;
            MemberId = o.MemberId;
            OrderDate = o.OrderDate;
            RequireDate = o.RequireDate;
            ShippedDate = o.ShippedDate;
            Freight = o.Freight;
            TotalSale = orderRepository.GetTotalSalesByOid(o.OrderId);
        }
        public static List<GetTotalSaleResponse> ToDTO(List<Order> listOrders)
        {
            List<GetTotalSaleResponse> getTotalSales = new List<GetTotalSaleResponse>();
            foreach (var item in listOrders) getTotalSales.Add(new GetTotalSaleResponse(item));
            return getTotalSales;
        }

    }
}
