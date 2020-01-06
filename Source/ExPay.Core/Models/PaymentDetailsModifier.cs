using System;
using System.Collections.Generic;

namespace ExPay.Core.Models
{
    public class PaymentDetailsModifier
    {
        public IEnumerable<PaymentItem> AdditionalDisplayItems { get; }

        public string JsonData { get; }

        public IEnumerable<string> SupportedMethodIds { get; }

        public PaymentItem Total { get; }

        public PaymentDetailsModifier()
        {
        }

        public PaymentDetailsModifier(IEnumerable<string> supportedMethodIds, PaymentItem total, IEnumerable<PaymentItem> additionalDisplayItems)
        {
            SupportedMethodIds = supportedMethodIds;
            Total = total;
            AdditionalDisplayItems = additionalDisplayItems;
        }

        public PaymentDetailsModifier(IEnumerable<string> supportedMethodIds, PaymentItem total, IEnumerable<PaymentItem> additionalDisplayItems, string jsonData)
        {
            SupportedMethodIds = supportedMethodIds;
            Total = total;
            AdditionalDisplayItems = additionalDisplayItems;
            JsonData = jsonData;
        }

        public PaymentDetailsModifier(IEnumerable<string> supportedMethodIds, PaymentItem total)
        {
            SupportedMethodIds = supportedMethodIds;
            Total = total;
        }
    }
}