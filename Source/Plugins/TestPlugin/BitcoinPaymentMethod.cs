using ExPay.Core.Contracts;
using System.Composition;

namespace TestPlugin
{
    [Export(typeof(IPaymentMethod))]
    public class BitcoinPaymentMethod : IPaymentMethod
    {
        public PaymentMethodInfo Info => new PaymentMethodInfo("urn:bitcoin", "Bitcoin", null);

        public void Initialize()
        {
        }

        public bool Invoke(object data)
        {
            throw new System.NotImplementedException();
        }
    }
}