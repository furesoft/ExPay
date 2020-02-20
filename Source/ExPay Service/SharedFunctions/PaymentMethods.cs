using ExPay.Core.API;
using ExPay.Core.Contracts;
using ExPay.Core.Models;
using ExPay_Service.Dialogs;
using Furesoft.Signals.Attributes;
using System;
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
            var isavailable = PluginLoader.Instance.IsPaymentMethodAvailable(req.AcceptedPaymentMethods);

            if (isavailable)
            {
                var result = Utils.ShowDialog<PaymentRequestSubmitResult, PayDialog>(req);

                return result.Result;
            }
            else
            {
                var errorDlg = Utils.ShowDialog<PaymentRequestSubmitResult, MessageDialog>("No Payment Method is configured or available for this Request");

                return errorDlg.Result;
            }
        }

    }
}