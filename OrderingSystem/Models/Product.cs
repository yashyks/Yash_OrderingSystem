namespace OrderingSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // Navigation property for the many-to-many relationship with Order
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
