﻿using ExPay.Core.Models;
using Furesoft.Signals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExPay.Core.API
{
    public class PaymentMediator
    {
        public PaymentMediator()
        {
            channel = Signal.CreateSenderChannel("ExPay");
        }

        public async Task<PaymentCanMakePaymentResultStatus> CanMakePaymentAsync(PaymentRequest paymentRequest)
        {
            return await Task.Run(() =>
            {
                var ping = Signal.CallMethod<bool>(channel, (int)SharedMethodIds.Ping);

                if (ping)
                {
                    //ToDo: check if paymentmethodid is registered
                    //ToDo: check if payment provider is configured

                    return PaymentCanMakePaymentResultStatus.Yes;
                }

                return PaymentCanMakePaymentResultStatus.No;
            });
        }

        public Task Complete(PaymentRequestCompletionStatus succeeded)
        {
            channel.Dispose();

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<string>> GetSupportedMethodIdsAsync()
        {
            return await Task.Run(() =>
            {
                //ToDo: load payment methodid from plugin database
                return new[] { "https://pay.microsoft.com/microsoftpay" };
            });
        }

        public Task<PaymentRequestSubmitResult> SubmitPaymentRequestAsync(PaymentRequest paymentRequest)
        {
            return Task.Run(() =>
            {
                var result = Signal.CallMethod<PaymentRequestSubmitResult>(channel, (int)SharedMethodIds.SubmitPaymentRequest, paymentRequest);

                return result;
            });
        }

        private IpcChannel channel;
    }
}