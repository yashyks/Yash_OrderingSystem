using Microsoft.AspNetCore.Mvc;
using OrderingSystem.DAL.Interface;

namespace OrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            var totalPrice = order.OrderProducts.Sum(p => p.Product.Price);
            var orderNameList = order.OrderProducts.Select(x=> x.Product).Select(x=> x.Name).ToList();
            return Ok(new
            {
                Order = orderNameList,
                TotalPrice = totalPrice
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreationRequest request)
        {
            var result = await _orderRepository.CreateOrderAsync(request.CustomerId, request.ProductIds);
            if (!result) return BadRequest("Invalid request or unfulfilled orders.");

            return Ok("Order created successfully.");
        }
    }

    public class OrderCreationRequest
    {
        public int CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
