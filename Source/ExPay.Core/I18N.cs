using NGettext;
using System.Globalization;

namespace ExPay.Core
{
    public static class I18N
    {
        public static string _(string value)
        {
            return catalog.GetString(value);
        }

        private static ICatalog catalog = new Catalog("Expay", "./Locale", new CultureInfo("en"));
    }
}