using ExPay.Core.Contracts;
using System.Composition;

namespace TestPlugin
{
    [Export(typeof(IPaymentMethod))]
    public class BitcoinPaymentMethod : IPaymentMethod
    {
        public PaymentMethodInfo Info => new PaymentMethodInfo("urn:bitcoin", "Bitcoin", "https://en.bitcoin.it/w/images/en/6/69/Btc-sans.png");

        public void Initialize()
        {
        }

        public bool Invoke(object data)
        {
            throw new System.NotImplementedException();
        }
    }
}