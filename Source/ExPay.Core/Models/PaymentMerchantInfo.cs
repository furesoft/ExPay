using Avalonia.Media.Imaging;
using System;

namespace ExPay.Core.Models
{
    public class PaymentMerchantInfo
    {
        public Uri ImageUrl { get; set; }
        public string Name { get; set; }
        public Bitmap Image { get; set; }

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
            ImageUrl = image;
        }
    }
}