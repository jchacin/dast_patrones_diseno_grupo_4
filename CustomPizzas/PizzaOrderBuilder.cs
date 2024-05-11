using CustomPizzas.Interfaces;
using CustomPizzas.Models;
using CustomPizzas.Models.Enums;

namespace CustomPizzas
{
    internal class PizzaOrderBuilder : IOrder, IPizzaBuilder
    {
        private Order _order;
        private const int _extraCheeseValue = 100;

        public PizzaOrderBuilder() 
        {
            _order = new Order();
        }

        public void AddPizzaToOrder()
        {
            _order.Pizzas.Add(new Pizza());
        }

        public void CalcTotalValue()
        {
            decimal totalValue = 0;
            foreach (var pizza in _order.Pizzas)
            {
                if (pizza.HasExtraCheese)
                    totalValue += _extraCheeseValue;

                totalValue += (int)Enum.Parse(typeof(PizzaSize), pizza.Size.ToString());
                totalValue += (int)Enum.Parse(typeof(PizzaDough), pizza.Dough.ToString());
                pizza.Ingredients.ForEach(i => totalValue += i.Price);
            }
            _order.TotalAmount = totalValue;
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"El valor total de tu pedido es: ${totalValue}");
        }

        public void CreateOrder(Guid clientId)
        {
            _order.Id = Guid.NewGuid();
            _order.ClientId = clientId;
            _order.Pizzas.ForEach(pizza => pizza.Id = Guid.NewGuid());
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Tu pedido ha sido creado con el ID: {_order.Id}. Pronto recibirás una notificación del domicilio.");
            Console.WriteLine("¡Gracias por tu compra!");
            Console.WriteLine("Porfavor presiona Enter para salir.");
            Console.Read();
        }

        public void HasExtraCheese(bool hasExtraCheese, int pizzaIndex)
        {
            _order.Pizzas.ElementAt(pizzaIndex).HasExtraCheese = hasExtraCheese;
        }

        public void SetDough(PizzaDough dough, int pizzaIndex)
        {
            _order.Pizzas.ElementAt(pizzaIndex).Dough = dough;
        }

        public void SetIngredients(List<Ingredient> ingredients, int pizzaIndex)
        {
            _order.Pizzas.ElementAt(pizzaIndex).Ingredients = ingredients;
        }

        public void SetSize(PizzaSize size, int pizzaIndex)
        {
            _order.Pizzas.ElementAt(pizzaIndex).Size = size;
        }

        public void ViewOrderDetails()
        {
            Console.WriteLine("Estos son los detalles de tu pedido:");
            Console.WriteLine($"Nro de pizzas: {_order.Pizzas.Count}");
            for (int i = 0; i < _order.Pizzas.Count; i++)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"Detalles de la pizza {i+1}");
                Console.WriteLine($"Tipo de masa: {_order.Pizzas[i].Dough}");
                Console.WriteLine($"Tamaño: {_order.Pizzas[i].Size}");
                Console.WriteLine(string.Format("Con bordes de queso: {0}", _order.Pizzas[i].HasExtraCheese ? "Si" : "No"));
                Console.WriteLine(string.Format("Ingredientes: {0}", string.Join(", ", _order.Pizzas[i].Ingredients.Select(i => i.Name))));
            }
        }

        public int GetExtraCheeseValue()
        {
            return _extraCheeseValue;
        }
    }
}
