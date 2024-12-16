using OrderingSystem.Models;

namespace OrderingSystem.DAL.Interface
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task<bool> CreateOrderAsync(int customerId, List<int> productIds);
    }
}
