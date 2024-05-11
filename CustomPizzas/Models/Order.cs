namespace CustomPizzas.Models
{
    internal class Order
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = new Client();
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
