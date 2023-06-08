namespace eStoreClient.DTO.OrderDTO
{
    public class GetTotalSaleResponse
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequireDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalSale { get; set; }
    }
}
