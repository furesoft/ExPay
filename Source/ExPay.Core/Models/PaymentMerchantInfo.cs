using System;

namespace ExPay.Core.Models
{
    public class PaymentMerchantInfo
    {
        public string Name { get; set; }

        public PaymentMerchantInfo()
        {
        }

        public PaymentMerchantInfo(string name)
        {
            Name = name;
        }
    }
}