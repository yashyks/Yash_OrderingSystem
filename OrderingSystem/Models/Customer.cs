namespace OrderingSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        // Navigation property: A customer can have many orders.
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
