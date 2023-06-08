using BusinessObject;
using eStoreAPI.DTO.OrderDetailDTO;
using eStoreAPI.DTO.OrderDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderRepository orderRepository = new OrderRepository();

        [HttpGet]
        public ActionResult<IEnumerable<GetOrderResponse>> GetOrders()
        {
            List<Order> ordes = orderRepository.GetOrders();
            List<GetOrderResponse> result = GetOrderResponse.ToDTO(ordes);
            return Ok(result);
        }

        [HttpGet("TotalSales")]
        public ActionResult<List<GetTotalSaleResponse>> GetTotalSales()
        {
            List<Order> ordes = orderRepository.GetOrders();
            List<GetTotalSaleResponse> result = GetTotalSaleResponse.ToDTO(ordes);
            return Ok(result);
        }

        [HttpGet("FilterTotalSales")]
        public ActionResult<GetTotalSaleResponse> GetTotalSales(DateTime dateFrom, DateTime dateTo, string? sort)
        {
            List<Order> ordes = orderRepository.FilterDateOrder(dateFrom, dateTo);
            List<GetTotalSaleResponse> result = GetTotalSaleResponse.ToDTO(ordes);

            if(sort != null)
            {
                QuickSort(result, 0, result.Count - 1);
            }

            return Ok(result);
        }

        // QuickSort
        public static void QuickSort(List<GetTotalSaleResponse> getTotalSales, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(getTotalSales, low, high);

                QuickSort(getTotalSales, low, pivotIndex - 1);
                QuickSort(getTotalSales, pivotIndex + 1, high);
            }
        }
        //sub-func quickSort
        public static int Partition(List<GetTotalSaleResponse> getTotalSales, int low, int high)
        {
            decimal pivot = getTotalSales[high].TotalSale;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (getTotalSales[j].TotalSale > pivot)
                {
                    i++;
                    Swap(getTotalSales, i, j);
                }
            }

            Swap(getTotalSales, i + 1, high);
            return i + 1;
        }
        //sub-func quickSort
        public static void Swap(List<GetTotalSaleResponse> getTotalSales, int i, int j)
        {
            GetTotalSaleResponse temp = getTotalSales[i];
            getTotalSales[i] = getTotalSales[j];
            getTotalSales[j] = temp;
        }


        [HttpGet("{id}/OrderDetails")]
        public ActionResult<List<GetOrderDetailResponse>> GetOrderDetailsByOid(int id)
        {
            List<OrderDetail> orderDetails = orderRepository.GetOrderDetailsByOid(id);
            List<GetOrderDetailResponse> getOrderDetails = GetOrderDetailResponse.ToDTO(orderDetails);
            return Ok(getOrderDetails);
        }

        [HttpGet("{id}")]
        public ActionResult<GetOrderResponse> GetOrderById(int id)
        {
            Order order = orderRepository.GetOrderById(id);
            GetOrderResponse getOrderResponse = new GetOrderResponse(order);
            return Ok(getOrderResponse);
        }

        [HttpPost]
        public IActionResult PostOrder([FromBody] CreateOrderRequest createOrder)
        {
            Order order = new Order()
            {
                MemberId = createOrder.MemberId,
                OrderDate = DateTime.Now,
                RequireDate = createOrder.RequireDate,
                ShippedDate = createOrder.ShippedDate,
                Freight = createOrder.Freight,
            };
            orderRepository.AddOrder(order);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] UpdateOrderRequest updateOrder)
        {
            var found = orderRepository.GetOrderById(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                Order o = new Order()
                {
                    OrderId = found.OrderId,
                    MemberId = found.MemberId,
                    OrderDate = found.OrderDate,
                    ShippedDate = updateOrder.ShippedDate,
                    RequireDate = updateOrder.RequireDate,
                    Freight = updateOrder.Freight,
                };
                orderRepository.UpdateOrder(o);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var found = orderRepository.GetOrderById(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                orderRepository.DeleteOrder(id);
                return NoContent();
            }
        }
    }
}
