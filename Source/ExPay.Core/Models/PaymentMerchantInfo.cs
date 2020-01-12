using System;

namespace ExPay.Core.Models
{
    public class PaymentMerchantInfo
    {
        public Uri Image { get; set; }
        public string Name { get; set; }

        public PaymentMerchantInfo()
        {
        }

        public PaymentMerchantInfo(string name)
        {
            Name = name;
        }

        public PaymentMerchantInfo(string name, Uri image)
            : this(name)
        {
            Image = image;
        }
    }
}