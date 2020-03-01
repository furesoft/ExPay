﻿using ExPay.Core.Contracts;
using NBitcoin;
using System.Composition;
using System.Threading.Tasks;

namespace TestPlugin
{
    [Export(typeof(IPaymentMethod))]
    public class BitcoinPaymentMethod : IPaymentMethod
    {
        public PaymentMethodInfo Info => new PaymentMethodInfo("urn:bitcoin", "Bitcoin", "https://en.bitcoin.it/w/images/en/6/69/Btc-sans.png");

        public Task<object> BeforePay()
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
            throw new System.NotImplementedException();
        }

        public bool IsConfigured()
        {
            //ToDo: check if xpubkey is configured in custom registry, only get Key for this specific Plugin, no access to other keys
            return false;
        }
    }
}