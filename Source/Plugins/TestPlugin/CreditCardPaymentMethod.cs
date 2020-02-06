using ExPay.Core.Contracts;
using System.Composition;

namespace TestPlugin
{
    [Export(typeof(IPaymentMethod))]
    public class CreditCardPaymentMethod : IPaymentMethod
    {
        public PaymentMethodInfo GetInfo() => new PaymentMethodInfo("creditCard", "CreditCard", null);

        public void Initialize()
        {
        }

        public bool Invoke(object data)
        {
            throw new System.NotImplementedException();
        }
    }
}