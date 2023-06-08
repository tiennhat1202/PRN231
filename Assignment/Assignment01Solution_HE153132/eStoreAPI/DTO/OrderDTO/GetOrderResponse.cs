using BusinessObject;

namespace eStoreAPI.DTO.OrderDTO
{
    public class GetOrderResponse
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequireDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }

        public GetOrderResponse(Order o)
        {
            OrderId = o.OrderId;
            MemberId = o.MemberId;
            OrderDate = o.OrderDate;
            RequireDate = o.RequireDate;
            ShippedDate = o.ShippedDate;
            Freight = o.Freight;
        }
        public static List<GetOrderResponse> ToDTO(List<Order> listOrders)
        {
            List<GetOrderResponse> getOrderResponse = new List<GetOrderResponse>();
            foreach (var item in listOrders) getOrderResponse.Add(new GetOrderResponse(item));
            return getOrderResponse;
        }

    }
}
