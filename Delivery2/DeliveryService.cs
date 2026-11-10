using System;
using System.Collections.Generic;

namespace Delivery
{
    public class DeliveryService : IDeliveryService //листи інфи
    {
        private List<Transport> Transports = new List<Transport>(); //din
        private List<Order> ActiveOrders = new List<Order>();
        private List<Order> History = new List<Order>();

        public void AddTransport(Transport t)
        {
            Transports.Add(t);
            Console.WriteLine(t.Name + " до " + t.MaxWeight + " кг");
        }

        public void ShowCosts(Order order) //показати ціну
        {
            Console.WriteLine("Вартість замовлення №" + order.Number + " (" + order.Description + "):");
            bool found = false;
            foreach (Transport t in Transports)
            {
                if (t.CanTake(order))
                {
                    Console.WriteLine("  " + t.Name + ": " + t.CalculateCost(order) + " грн");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("  Жоден транспорт не може взяти це замовлення");
            }
        }

        public void Assign(Order order, Transport t) //призначення
        {
            if (order.AssignedTransport != null)
            {
                Console.WriteLine("Не вийшло: замовлення №" + order.Number + " вже призначене");
            }
            else if (t.IsBusy)
            {
                Console.WriteLine("Не вийшло: " + t.Name + " зайнятий");
            }
            else if (!t.CanTake(order))
            {
                Console.WriteLine("Не вийшло: " + t.Name + " не може взяти замовлення №" + order.Number);
            }
            else
            {
                t.IsBusy = true;
                order.AssignedTransport = t;
                order.Cost = t.CalculateCost(order);
                ActiveOrders.Add(order);
                Console.WriteLine("Замовлення №" + order.Number + " призначено на " + t.Name);
            }
        }

        public void Deliver(Order order, IPayment payment) //доставка
        {
            if (!ActiveOrders.Contains(order))
            {
                Console.WriteLine("Замовлення №" + order.Number + " не є активним");
                return;
            }
            payment.Pay(order.Cost);
            order.PaymentName = payment.Name;
            order.AssignedTransport!.IsBusy = false;
            ActiveOrders.Remove(order);
            History.Add(order);
            Console.WriteLine("Замовлення №" + order.Number + " доставлено");
        }

        public void PrintAll() //вивід актив замовлень
        {
            Console.WriteLine("Статус транспорту");
            foreach (Transport t in Transports)
            {
                string status = "вільний";
                if (t.IsBusy)
                    status = "зайнятий";
                Console.WriteLine(t.Name + ": " + status);
            }
            Console.WriteLine("Активні замовлення");
            foreach (Order o in ActiveOrders)
                Console.WriteLine("№" + o.Number + " " + o.Description + " (" + o.AssignedTransport!.Name + ")");
            Console.WriteLine("Історія доставок");
            foreach (Order o in History)
                Console.WriteLine("№" + o.Number + " " + o.Description + ": " + o.AssignedTransport!.Name
                                  + ", " + o.Cost + " грн, " + o.PaymentName);
        }
    }
}
