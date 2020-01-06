namespace ExPay.Core.Contracts
{
    public interface IPaymentMethod
    {
        bool Invoke(object data);
    }
}