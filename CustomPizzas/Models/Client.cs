namespace CustomPizzas.Models
{
    internal class Client
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
