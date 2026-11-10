using System;
using System.Collections.Generic;

namespace Delivery
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            IDeliveryService service = new DeliveryService();

            Console.WriteLine("Транспорт");
            Bike bike = new Bike();
            Car car = new Car();
            Truck truck = new Truck();
            service.AddTransport(bike);
            service.AddTransport(car);
            service.AddTransport(truck);

            Order o1 = new Order(1, 2, "Картон", 5);          // only bike
            Order o2 = new Order(2, 50, "Компʼютер", 8);      // except bike
            Order o3 = new Order(3, 3, "Телевізор", 30);      // car
            Order o4 = new Order(4, 300, "Меблі", 15);        // even truck
            Order o5 = new Order(5, 200000, "Дім", 10);       // no one

            Console.WriteLine("\n Ціна різним транспортом");
            service.ShowCosts(o1);
            service.ShowCosts(o2);
            service.ShowCosts(o3);
            service.ShowCosts(o4);
            service.ShowCosts(o5);

            Console.WriteLine("\n Призначення");
            service.Assign(o1, bike);   // успішно
            service.Assign(o2, bike);   // велосипед зайнятий
            service.Assign(o4, car);    // авто не бере (вага)
            service.Assign(o4, truck);  // успішно
            service.Assign(o1, car);    // o1 вже призначене
            service.Assign(o5, truck);  // вантажівка зайнята

            Console.WriteLine();
            service.PrintAll();

            Console.WriteLine("\n Доставка");
            service.Deliver(o1, new CardPayment());  // карткою
            service.Deliver(o4, new CashPayment());  // готівкою
            service.Deliver(o3, new CardPayment());  // o3 не активне (не призначене)
            service.Deliver(o1, new CardPayment());  // o1 вже доставлене

            Console.WriteLine("\n Призначення після звільнення транспорту");
            service.Assign(o3, bike);  // велосипед вільний, але 30 км - забагато
            service.Assign(o2, car);   // успішно

            Console.WriteLine();
            service.PrintAll();
        }
    }
}
