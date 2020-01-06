using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ExPay_Service.UI
{
    internal class CurrencyConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0:F2}", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new CurrencyConverter();
        }
    }
}