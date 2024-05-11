using CustomPizzas.Models.Enums;

namespace CustomPizzas.Models
{
    internal class Pizza
    {
        public Guid Id { get; set; }
        public PizzaSize Size { get; set; }
        public PizzaDough Dough { get; set; }
        public bool HasExtraCheese { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
    }
}
