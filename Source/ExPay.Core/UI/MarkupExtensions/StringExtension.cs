using Avalonia.Markup.Xaml;
using System;

namespace ExPay.Core.UI.MarkupExtensions
{
    public class StringExtension : MarkupExtension
    {
        public StringExtension(string key)
        {
            Key = key;
        }

        public string Key { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return I18N._(Key);
        }
    }
}