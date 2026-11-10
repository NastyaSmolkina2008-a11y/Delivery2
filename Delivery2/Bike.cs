namespace Delivery
{
    public class Bike : Transport
    {
        public Bike() : base(5, "Велосипед") { }

        public override double CalculateCost(Order order)
        {
            return 20 + 5 * order.Distance;
        }

        // перевизначає CanTake: вага (від батька) І відстань до 10 км
        public override bool CanTake(Order order)
        {
            if (base.CanTake(order) && order.Distance <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
