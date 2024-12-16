using Microsoft.EntityFrameworkCore;
using OrderingSystem.DAL.Interface;
using OrderingSystem.Models;

namespace OrderingSystem.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBContext _context;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(AppDBContext context, ILogger<CustomerRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            try
            {

                return await _context.Customers.Include(c => c.Orders).ThenInclude(o => o.OrderProducts).ThenInclude(x=>x.Product).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching all customers");
                throw ex;
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                return await _context.Customers.Include(c => c.Orders).ThenInclude(o => o.OrderProducts).ThenInclude(x=> x.Product).FirstOrDefaultAsync(c => c.Id == id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching customer by ID: {id}");
                throw ex;
            }        
        }
    }
}
