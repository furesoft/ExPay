using System.Globalization;

namespace ExPay.Core.Localisation
{
    public abstract class CatalogBase
    {
        public abstract string GetString(string key);

        public abstract string FileExtension { get; }

        public string Name { get; set; }

        public abstract void Load(string filename);
    }
}