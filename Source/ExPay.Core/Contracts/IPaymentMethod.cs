namespace ExPay.Core.Contracts
{
    public interface IPaymentMethod
    {
        PaymentMethodInfo Info { get; }

        void Initialize();

        bool Invoke(object data);
    }
}