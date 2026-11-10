using System;

namespace Delivery
{
    public class CashPayment : IPayment
    {
        public string Name { get { return "готівка"; } }

        public void Pay(double amount)
        {
            Console.WriteLine("Готівкою: " + amount + " грн");
        }
    }
}
