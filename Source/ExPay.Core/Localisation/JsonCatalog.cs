using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ExPay.Core.Localisation
{
    public class JsonCatalog : CatalogBase
    {
        private JToken _keys;

        public override string FileExtension => ".json";

        public override string GetString(string key)
        {
            try
            {
                return _keys[key].Value<string>();
            }
            catch (ArgumentNullException)
            {

            }

            return key;
        }

        public override void Load(string filename)
        {
            var obj = JObject.Parse(File.ReadAllText(filename));
            Name = obj["name"].Value<string>();

            _keys = obj["keys"];
        }
    }
}