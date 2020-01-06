using System.Collections.Generic;

namespace ExPay.Core.Models
{
    public class PaymentDetails
    {
        public IEnumerable<PaymentItem> DisplayItems { get; set; }

        public PaymentDetailsModifier[] Modifiers { get; set; }

        public IEnumerable<PaymentShippingOption> ShippingOptions { get; set; }

        public PaymentItem Total { get; set; }

        public PaymentDetails()
        {
        }
    }
}