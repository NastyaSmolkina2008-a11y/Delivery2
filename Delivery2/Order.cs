namespace Delivery
{
    public class Order
    {
        public int Number { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public double Distance { get; set; }
        public Transport? AssignedTransport { get; set; } // null = ще нікому не призначене
        public double Cost { get; set; }
        public string? PaymentName { get; set; }

        public Order(int number, double weight, string description, double distance)
        {
            Number = number;
            Weight = weight;
            Description = description;
            Distance = distance;
        }
    }
}
