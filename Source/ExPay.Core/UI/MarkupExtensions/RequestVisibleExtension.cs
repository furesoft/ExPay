using Avalonia.Markup.Xaml;
using ExPay.Core.Models;
using System;

namespace ExPay.Core.UI.MarkupExtensions
{
    public class RequestVisibleExtension : MarkupExtension
    {
        public RequestVisibleExtension(string propertyname)
        {
            Propertyname = propertyname;
        }

        public string Propertyname { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var req = Singleton<PaymentRequest>.Instance.Options;
            var reqType = req.GetType();

            var prop = reqType.GetProperty(Propertyname);
            if (prop.PropertyType == typeof(PaymentOptionPresence))
            {
                var value = (PaymentOptionPresence)prop.GetValue(req);

                if (value == PaymentOptionPresence.None) return false;
            }
            else if (prop.PropertyType == typeof(bool))
            {
                var value = (bool)prop.GetValue(req);

                return value;
            }

            return true;
        }
    }
}