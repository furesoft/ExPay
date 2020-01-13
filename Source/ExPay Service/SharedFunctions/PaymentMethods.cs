using ExPay.Core.API;
using ExPay.Core.Models;
using ExPay_Service.Dialogs;
using Furesoft.Signals.Attributes;
using System.ComponentModel;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class PaymentMethods
    {
        [SharedFunction((int)SharedMethodIds.Complete)]
        [Description("Complete the Payment")]
        public static void Complete()
        {
        }

        [SharedFunction((int)SharedMethodIds.GetPaymentStatus)]
        [Description("Get Result of current Payment")]
        public static int GetPaymentStatus()
        {
            return 0;
        }

        [SharedFunction((int)SharedMethodIds.SubmitPaymentRequest)]
        [Description("Submit the Payment Request")]
        public static PaymentRequestSubmitResult SubmitPaymentRequest(PaymentRequest req)
        {
            var result = Utils.ShowDialog<PaymentRequestSubmitResult, TestDialog>(req);

            return result.Result;
        }
    }
}