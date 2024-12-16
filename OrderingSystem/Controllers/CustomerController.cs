using Microsoft.AspNetCore.Mvc;
using OrderingSystem.DAL.Interface;

namespace OrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            //return Ok(customers);

            // Below result set is for display purpose on swagger
            var customerNames = customers.Select(c => c.Name).ToList();

            return Ok(customerNames);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            var orderDetails = customer.Orders.Select(o => new
            {
                OrderId = o.Id,
                OrderProducts = o.OrderProducts.Select(op => op.Product.Name).ToList() // Get the names of products in the order
            }).ToList(); return Ok(new
            {
                CustomerName = customer.Name,
                Orders = orderDetails
            }); //for display purpose on swagger showing name only
            //return Ok(customer);
        }
    }
}
