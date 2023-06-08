using BusinessObject;

namespace eStoreAPI.DTO.OrderDetailDTO
{
    public class GetOrderDetailResponse
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double? Discount { get; set; }

        public GetOrderDetailResponse(OrderDetail od)
        {
            OrderId = od.OrderId;
            ProductId = od.ProductId;
            UnitPrice = od.UnitPrice;
            Quantity = od.Quantity;
            Discount = od.Discount;
        }
        public static List<GetOrderDetailResponse> ToDTO(List<OrderDetail> listOrderDetails)
        {
            List<GetOrderDetailResponse> getOrderDetails = new List<GetOrderDetailResponse>();
            foreach (var item in listOrderDetails) getOrderDetails.Add(new GetOrderDetailResponse(item));
            return getOrderDetails;
        }
    }
}
