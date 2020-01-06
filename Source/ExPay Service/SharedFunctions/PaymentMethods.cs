using ExPay.Core.API;
using ExPay.Core.Models;
using Furesoft.Signals.Attributes;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class PaymentMethods
    {
        [SharedFunction((int)SharedMethodIds.Complete)]
        public void Complete()
        {
        }

        [SharedFunction((int)SharedMethodIds.SubmitPaymentRequest)]
        public int SubmitPaymentRequest(PaymentRequest req)
        {
            return 0;
        }
    }
}