namespace Delivery
{
    public interface IPayment
    {
        string Name { get; }
        void Pay(double amount);
    }
}
