using CustomPizzas;
using CustomPizzas.Models;
using CustomPizzas.Models.Enums;

var clientId = Guid.NewGuid();
var availableIngredients = new List<Ingredient>
{
    new Ingredient { Id = 1, Name = "Queso", Price = 500 },
    new Ingredient { Id = 2, Name = "Pepperoni", Price = 1500 },
    new Ingredient { Id = 3, Name = "Jamón", Price = 1000 },
    new Ingredient { Id = 4, Name = "Champiñones", Price = 500 },
    new Ingredient { Id = 5, Name = "Pimientos", Price = 300 },
    new Ingredient { Id = 6, Name = "Cebolla", Price = 300 },
    new Ingredient { Id = 7, Name = "Aceitunas", Price = 400 },
    new Ingredient { Id = 8, Name = "Piña", Price = 300 }
};

Console.WriteLine("Bienvenido al restaurante Grupo 4");
Console.WriteLine("Por favor ingresa el número de pizzas que deceas ordenar");
int nroPizzas = int.Parse(Console.ReadLine());
var builder = new PizzaOrderBuilder();
for (int i = 0; i < nroPizzas; i++) 
{
    builder.AddPizzaToOrder();
    EnterPizzaDough(i);
    EnterPizzaSize(i);
    EnterPizzaIngredients(i);
    AddExtra(i);
    Console.WriteLine($"Pizza {i+1} añadida correctamente a tu pedido");
}

DisplayMenu();

void DisplayMenu() 
{
    Console.WriteLine("-----------------------------------------------------");
    Console.WriteLine($"Ahora que tu pedido está listo, seleciona una de las siguientes opciones:");
    string[] menuOptions =
    [
        $"1 -> Ver valor total de mi pedido",
        $"2 -> Revisar los detalles de mi pedido",
        $"3 -> Finalizar el pedido",
    ];
    PrintSelectableMenu(menuOptions);
    int selectedOption = int.Parse(Console.ReadLine());

    if (selectedOption.Equals(1))
        builder.CalcTotalValue();
    else if (selectedOption.Equals(2))
        builder.ViewOrderDetails();
    else 
    {
        builder.CreateOrder(clientId);
        return;
    }

    DisplayMenu();
}


void EnterPizzaDough(int pizzaIndex)
{
    Console.WriteLine($"Por favor ingresa el tipo de masa de la pizza {pizzaIndex+1} entre las siguietes opciones:");
    string[] options =
    [
        $"1 -> {Enum.GetName(PizzaDough.Delgada)} (${(short)PizzaDough.Delgada})",
        $"2 -> {Enum.GetName(PizzaDough.Gruesa)} (${(short)PizzaDough.Gruesa})",
        $"3 -> {Enum.GetName(PizzaDough.Integral)} (${(short)PizzaDough.Integral})",
    ];
    PrintSelectableMenu(options);
    string? dough = Console.ReadLine();
    var selectedDough = (PizzaDough)Enum.Parse(typeof(PizzaDough), $"{dough}00");
    builder.SetDough(selectedDough, pizzaIndex);
}

void EnterPizzaSize(int pizzaIndex)
{
    Console.WriteLine($"Por favor especifica el tamaño de la pizza {pizzaIndex+1} entre las siguietes opciones:");
    string[] options =
    [
        $"1 -> {Enum.GetName(PizzaSize.Pequeña)} (${(short)PizzaSize.Pequeña})",
        $"2 -> {Enum.GetName(PizzaSize.Mediana)} (${(short)PizzaSize.Mediana})",
        $"3 -> {Enum.GetName(PizzaSize.Grande)} (${(short)PizzaSize.Grande})",
    ];
    PrintSelectableMenu(options);
    string? size = Console.ReadLine();
    var selectedSize = (PizzaSize)Enum.Parse(typeof(PizzaDough), $"{size}00");
    builder.SetSize(selectedSize, pizzaIndex);
}

void EnterPizzaIngredients(int pizzaIndex)
{
    var ingredients = AddIngredients(new List<Ingredient>(), pizzaIndex);
    builder.SetIngredients(ingredients, pizzaIndex);
}

List<Ingredient> AddIngredients(List<Ingredient> currentIngredients, int pizzaIndex) 
{
    Console.WriteLine($"Por favor especifica hasta 4 ingredientes para la pizza {pizzaIndex+1} entre las siguietes opciones:");
    PrintSelectableMenu(availableIngredients.Select(i => $"{i.Id} -> {i.Name} (${i.Price})").ToArray());
    int ingredientId = int.Parse(Console.ReadLine());
    var ingredient = availableIngredients.First(i => i.Id == ingredientId);
    currentIngredients.Add(ingredient);

    bool response = false;
    if (currentIngredients.Count < 4) response = YesNoSelection("¿Quieres añadir otro ingrediente?");

    if (response) return AddIngredients(currentIngredients, pizzaIndex);
    else return currentIngredients;
}

void AddExtra(int pizzaIndex) 
{
    bool addExtra = YesNoSelection($"¿Quieres añadir queso extra en el borde de la masa por un valor adicional de ${builder.GetExtraCheeseValue()}?");
    builder.HasExtraCheese(addExtra, pizzaIndex);
}

bool YesNoSelection(string message) 
{
    Console.WriteLine(message);
    PrintSelectableMenu([
        $"S -> Si",
        $"N -> No"
    ]);
    string response = Console.ReadLine();
    return response.ToUpper() == "S";
}

void PrintSelectableMenu(string[] options)
{
    foreach (string option in options)
    {
        Console.WriteLine(option);
    }
}
