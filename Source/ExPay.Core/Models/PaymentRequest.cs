using System.Collections.Generic;

namespace ExPay.Core.Models
{
    public class PaymentRequest
    {
        public IEnumerable<PaymentMethodData> AcceptedPaymentMethods { get; set; }

        public PaymentDetails Details { get; set; }

        public PaymentMerchantInfo MerchantInfo { get; set; }

        public PaymentOptions Options { get; set; }

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