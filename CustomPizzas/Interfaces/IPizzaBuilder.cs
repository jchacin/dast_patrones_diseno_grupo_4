using CustomPizzas.Models;
using CustomPizzas.Models.Enums;

namespace CustomPizzas.Interfaces
{
    internal interface IPizzaBuilder
    {
        public void SetSize(PizzaSize size, int pizzaIndex);
        public void SetDough(PizzaDough dough, int pizzaIndex);
        public void SetIngredients(List<Ingredient> ingredients, int pizzaIndex);
        public void HasExtraCheese(bool hasExtraCheese, int pizzaIndex);
    }
}
