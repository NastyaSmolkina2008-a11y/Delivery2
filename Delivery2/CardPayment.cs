using System;

namespace Delivery
{
    public class CardPayment : IPayment
    {
        public string Name { get { return "картка"; } }

        public void Pay(double amount)
        {
            Console.WriteLine("Карткою: " + amount + " грн");
        }
    }
}
