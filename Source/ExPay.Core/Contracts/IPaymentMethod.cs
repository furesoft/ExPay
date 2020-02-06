namespace ExPay.Core.Contracts
{
    public interface IPaymentMethod
    {
        PaymentMethodInfo GetInfo();

        bool Invoke(object data);
    }
}