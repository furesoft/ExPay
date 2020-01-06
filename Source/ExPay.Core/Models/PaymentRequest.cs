using System.Collections.Generic;

namespace ExPay.Core.Models
{
    public class PaymentRequest
    {
        public IEnumerable<PaymentMethodData> AcceptedPaymentMethods { get; }

        public PaymentDetails Details { get; }

        public PaymentMerchantInfo MerchantInfo { get; }

        public PaymentOptions Options { get; }

        public PaymentRequest()
        {
        }

        public PaymentRequest(PaymentDetails details, IEnumerable<PaymentMethodData> acceptedPaymentMethods, PaymentMerchantInfo merchantInfo, PaymentOptions options)
        {
            Details = details;
            AcceptedPaymentMethods = acceptedPaymentMethods;
            MerchantInfo = merchantInfo;
            Options = options;
        }
    }
}