using ExPay.Core.Contracts;
using System.Composition;

namespace TestPlugin
{
    [Export(typeof(IPaymentMethod))]
    public class MsPayPaymentMethod : IPaymentMethod
    {
        public PaymentMethodInfo Info => new PaymentMethodInfo("https://pay.microsoft.com/microsoftpay", "Microsoft Pay", null);

        public void Initialize()
        {
        }

        public bool Invoke(object data)
        {
            throw new System.NotImplementedException();
        }
    }
}