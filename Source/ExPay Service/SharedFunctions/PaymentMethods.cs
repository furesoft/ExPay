using ExPay.Core.API;
using ExPay.Core.Models;
using ExPay_Service.Dialogs;
using Furesoft.Signals.Attributes;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class PaymentMethods
    {
        [SharedFunction((int)SharedMethodIds.Complete)]
        public static void Complete()
        {
        }

        [SharedFunction((int)SharedMethodIds.SubmitPaymentRequest)]
        public static PaymentRequestSubmitResult SubmitPaymentRequest(PaymentRequest req)
        {
            var result = Utils.ShowDialog<PaymentRequestSubmitResult, PayDialog>();

            return result;
        }
    }
}