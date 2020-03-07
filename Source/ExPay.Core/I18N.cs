using NGettext;

namespace ExPay.Core
{
    public static class I18N
    {
        public static string Domain = "ExPay";

        public static string _(string value)
        {
            return catalog.GetString(value);
        }

        private static ICatalog catalog = new Catalog(Domain, "./Locale");
    }
}