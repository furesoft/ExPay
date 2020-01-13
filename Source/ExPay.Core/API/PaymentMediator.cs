using ExPay.Core.Models;
using Furesoft.Signals;
using System.Collections.Generic;

namespace ExPay.Core.API
{
    public class PaymentMediator
    {
        public PaymentMediator()
        {
            channel = Signal.CreateSenderChannel("ExPay");
        }

        public PaymentCanMakePaymentResultStatus CanMakePaymentAsync(PaymentRequest paymentRequest)
        {
            var ping = Signal.CallMethod<bool>(channel, (int)SharedMethodIds.Ping);

            if (ping)
            {
                //ToDo: check if paymentmethodid is registered
                //ToDo: check if payment provider is configured

                return PaymentCanMakePaymentResultStatus.Yes;
            }

            return PaymentCanMakePaymentResultStatus.No;
        }

        public PaymentRequestCompletionStatus Complete()
        {
            var status = (PaymentRequestCompletionStatus)Signal.CallMethod<int>(channel, (int)SharedMethodIds.GetPaymentStatus);

            channel.Dispose();

            return status;
        }

        public IEnumerable<string> GetSupportedMethodIdsAsync()
        {
            //ToDo: load payment methodid from plugin database
            return new[] { "https://pay.microsoft.com/microsoftpay" };
        }

        public PaymentRequestSubmitResult SubmitPaymentRequestAsync(PaymentRequest paymentRequest)
        {
            return Signal.CallMethod<PaymentRequestSubmitResult>(channel, (int)SharedMethodIds.SubmitPaymentRequest, paymentRequest);
        }

        private IpcChannel channel;
    }
}