namespace Delivery
{
    public abstract class Transport
    {
        public bool IsBusy { get; set; }
        public double MaxWeight { get; set; }
        public string Name { get; set; }

        public Transport(double maxweight, string name)
        {
            MaxWeight = maxweight;
            Name = name;
        }

        public abstract double CalculateCost(Order order);

        public virtual bool CanTake(Order order)
        {
            return order.Weight <= MaxWeight;
        }
    }
}
