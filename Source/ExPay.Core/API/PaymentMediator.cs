using ExPay.Core.Events;
using ExPay.Core.Models;
using Furesoft.Signals;
using System;
using System.Collections.Generic;

namespace ExPay.Core.API
{
    public class PaymentMediator
    {
        public PaymentMediator()
        {
            channel = Signal.CreateSenderChannel("ExPay");
            Signal.Subscribe<ConnectionLostEvent>(channel, OnConnectionLost);
        }

        private void OnConnectionLost(ConnectionLostEvent obj)
        {
            Console.WriteLine($"PaymentRequest has stopped: {obj.Reason}");
        }

        public PaymentCanMakePaymentResultStatus CanMakePaymentAsync(PaymentRequest paymentRequest)
        {
            var ping = Signal.CallMethod<bool>(channel, (int)SharedMethodIds.Ping);

            if (ping)
            {
                if (Signal.CallMethod<bool>(channel, (int)SharedMethodIds.IsPaymentConfigured))
                {
                    return PaymentCanMakePaymentResultStatus.Yes;
                }
            }

            return PaymentCanMakePaymentResultStatus.No;
        }

        public PaymentRequestCompletionStatus Complete()
        {
            var status = (PaymentRequestCompletionStatus)Signal.CallMethod<int>(channel, (int)SharedMethodIds.IsPaymentConfigured);

            channel.Dispose();

            return status;
        }

        public IEnumerable<string> GetSupportedMethodIdsAsync()
        {
            return Signal.CallMethod<string[]>(channel, (int)SharedMethodIds.GetSupportedMethodIds);
        }

        public PaymentRequestSubmitResult SubmitPaymentRequestAsync(PaymentRequest paymentRequest)
        {
            return Signal.CallMethod<PaymentRequestSubmitResult>(channel, (int)SharedMethodIds.SubmitPaymentRequest, paymentRequest);
        }

        private IpcChannel channel;
    }
}