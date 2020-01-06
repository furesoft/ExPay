using System;

namespace ExPay.Core.Models
{
    public class PaymentMerchantInfo
    {
        public Uri URN { get; set; }

        public PaymentMerchantInfo(Uri uRN)
        {
            URN = uRN;
        }
    }
}