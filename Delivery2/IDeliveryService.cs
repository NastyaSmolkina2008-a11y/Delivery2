namespace Delivery
{
    public interface IDeliveryService
    {
        void AddTransport(Transport t);
        void ShowCosts(Order order);
        void Assign(Order order, Transport t);
        void Deliver(Order order, IPayment payment);
        void PrintAll();
    }
}
