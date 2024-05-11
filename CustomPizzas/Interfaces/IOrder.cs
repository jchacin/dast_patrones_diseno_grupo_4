namespace CustomPizzas.Interfaces
{
    internal interface IOrder
    {
        public void AddPizzaToOrder();
        public void CalcTotalValue();
        public void ViewOrderDetails();
        public void CreateOrder(Guid clientId);
        public int GetExtraCheeseValue();
    }
}
