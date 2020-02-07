namespace ExPay.Core.Contracts
{
    public interface IPaymentMethod
    {
        PaymentMethodInfo GetInfo { get; }

        void Initialize();

        bool Invoke(object data);
    }
}