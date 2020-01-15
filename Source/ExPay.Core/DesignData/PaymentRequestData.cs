using Avalonia.Markup.Xaml;
using ExPay.Core.Models;
using System;

namespace ExPay.Core.DesignData
{
    public class PaymentRequestData : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var pr = new PaymentRequest();
            pr.MerchantInfo = new PaymentMerchantInfo("Design Store");

            return pr;
        }
    }
}