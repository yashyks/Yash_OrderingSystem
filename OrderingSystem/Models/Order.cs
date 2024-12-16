namespace OrderingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        // Navigation property: Each order belongs to a customer.
        public Customer Customer { get; set; }
        // Navigation property: An order can have many products.
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public bool IsFulfilled { get; set; }

        // Calculating total price based on products associated with the order.
        public decimal TotalPrice => OrderProducts.Sum(p => p.Product.Price);
    }
}
