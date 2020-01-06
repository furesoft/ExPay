using System;

namespace ExPay.Core.Models
{
    public class PaymentMerchantInfo
    {
        public string Name { get; set; }
        public Uri URN { get; set; }

        public PaymentMerchantInfo()
        {
        }

        public PaymentMerchantInfo(Uri uRN)
        {
            URN = uRN;
        }
    }
}