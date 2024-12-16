using Azure.Core;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.DAL.Interface;
using OrderingSystem.Models;

namespace OrderingSystem.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _context;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(AppDBContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            try
            {
                return await _context.Orders.Include(o => o.OrderProducts).ThenInclude(x=> x.Product).FirstOrDefaultAsync(o => o.Id == id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching order with ID: {id}");
                throw;
            }        
        }

        public async Task<bool> CreateOrderAsync(int customerId, List<int> productIds)
        {
            try
            {
                // Check if the customer exists
                var customer = await _context.Customers.FindAsync(customerId);
                if (customer == null) return false;

                // Check for unfulfilled orders
                var hasUnfulfilledOrder = await _context.Orders.AnyAsync(o => o.CustomerId == customerId && !o.IsFulfilled);

                if (hasUnfulfilledOrder) return false;

                // Get product details
                var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

                if (products.Count != productIds.Count) return false;

                // Create the order
                var order = new Order
                {
                    CustomerId = customerId,
                    IsFulfilled = false
                };

                // Add the products to the order through the OrderProduct join table
                var orderProducts = products.Select(p => new OrderProduct
                {
                    Product = p,
                    Order = order
                }).ToList();

                // Add the order and the related products to the context
                _context.Orders.Add(order);
                _context.OrderProducts.AddRange(orderProducts);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Order successfully created for customer");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order.");
                throw;
            }
        }
    }
}
