﻿using Avalonia.Media.Imaging;
using ExPay.Core;
using ExPay.Core.Contracts;
using ExPay.Core.Navigation;
using ExPay_Service.Core.Navigation;
using NBitcoin;
using System;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace TestPlugin
{
    [Export(typeof(IPaymentMethod))]
    public class BitcoinPaymentMethod : IPaymentMethod
    {
        public PaymentMethodInfo Info => new PaymentMethodInfo("urn:bitcoin", "Bitcoin");

        public Task<object> BeforePay(object data)
        {
            Navigator.AddAction(NavigatorAction.SwitchPage(new TestPage()), NavigationTarget.BeforeFinish);

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

        public Bitmap Image => ExPay.Core.Utils.DownloadBitmap("https://en.bitcoin.it/w/images/en/6/69/Btc-sans.png");
    }
}