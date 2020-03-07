using DiscUtils.Registry;
using ExPay.Core.Contracts;
using ExPay.Core.PlatformDependent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExPay.Core
{
    public static class PaymentConfig
    {
        public static RegistryKey AddPaymentMethod(string id)
        {
            if (_methods.GetSubKeyNames().Contains(id))
            {
                return _methods.OpenSubKey(id);
            }

            return _methods.CreateSubKey(id);
        }

        public static void Init()
        {
            if (File.Exists(configFilename))
            {
                if (_hive == null && _methods == null)
                {
                    _hive = new RegistryHive(File.Open(configFilename, FileMode.OpenOrCreate));
                    _methods = _hive.Root.OpenSubKey("payment_methods");
                    _payer = _hive.Root.OpenSubKey("payer_information");
                }
            }
            else
            {
                _hive = RegistryHive.Create(File.Open(configFilename, FileMode.OpenOrCreate));
                _methods = _hive.Root.CreateSubKey("payment_methods");
                _payer = _hive.Root.CreateSubKey("payer_information");
            }

            Dispose.Add(_hive);
            Logger.Trace("PaymentConfig initialized");
        }

        public static void InitMethods(IEnumerable<IPaymentMethod> paymentMethods)
        {
            foreach (var pm in paymentMethods)
            {
                AddPaymentMethod(pm.Info.ID);
            }
        }

        public static bool IsConfigured(string id)
        {
            if (_methods != null)
            {
                return _methods.GetSubKeyNames().Contains(id);
            }

            return false;
        }

        public static string GetValue(string key)
        {
            return _payer.GetValue(key).ToString();
        }

        public static void SetValue(string key, object value)
        {
            _payer.SetValue(key, value);
        }

        internal static RegistryKey _methods;
        private static RegistryKey _payer;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static RegistryHive _hive;
        private static string configFilename = Allocator.New<IDefaultPath>().SettingsPath;
    }
}