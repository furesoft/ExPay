using Avalonia.Media.Imaging;
using ExPay.Core;
using ExPay.Core.Contracts;
using NBitcoin;
using System;
using System.Composition;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestPlugin
{
    [Export(typeof(IPaymentMethod))]
    public class BitcoinPaymentMethod : IPaymentMethod
    {
        public PaymentMethodInfo Info => new PaymentMethodInfo("urn:bitcoin", "Bitcoin");

        public Task<object> BeforePay(object data)
        {
            var addr = GenerateAddress();

            return Task.FromResult<object>(new { hello = "world" });
        }

        string GenerateAddress()
        {
            var pubkey = ExtPubKey.Parse("xpub6CUGRUonZSQ4TWtTMmzXdrXDtypWKiKrhko4egpiMZbpiaQL2jkwSB1icqYh2cfDfVxdx4df189oLKnC5fSwqPfgyP3hooxujYzAu3fDVmz", Network.Main);
            var newAddress = pubkey.Derive(0).Derive(0).PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
            return newAddress.ToString();
        }

        public void Initialize()
        {
        }

        public bool Invoke(object data)
        {
            return true;
        }

        public bool IsConfigured()
        {
            var config = new PaymentMethodConfig();

            return !config.GetValueNames().Contains("xpub");
        }

        public Bitmap Image
        {
            get
            {
                var handler = new Func<Task<Bitmap>>(async () =>
                {
                    HttpClient client = new HttpClient();
                    var strm = await client.GetStreamAsync("https://en.bitcoin.it/w/images/en/6/69/Btc-sans.png");

                    return new Bitmap(strm);
                });

                return handler().Result;
            }
        }
    }
}