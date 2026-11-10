namespace Delivery
{
    public class Car : Transport
    {
        public Car() : base(200, "Автомобіль") { }

        public override double CalculateCost(Order order)
        {
            return 50 + (8 * order.Distance) + (1 * order.Weight);
        }
    }
}
