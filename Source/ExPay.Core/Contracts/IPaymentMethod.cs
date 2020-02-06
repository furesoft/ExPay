namespace ExPay.Core.Contracts
{
    public interface IPaymentMethod
    {
        PaymentMethodInfo GetInfo();

        void Initialize();

        bool Invoke(object data);
    }
}