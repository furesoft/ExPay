using Avalonia.Markup.Xaml;
using System;

namespace ExPay.Core.UI.MarkupExtensions
{
    public class PaymentConfigExtension : MarkupExtension
    {
        public PaymentConfigExtension(string key)
        {
            Key = key;
        }

        public string Key { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return PaymentConfig.GetValue<object>(Key);
        }
    }
}