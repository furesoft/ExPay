using DiscUtils.Registry;
using ExPay.Core.Contracts;
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
                }
            }
            else
            {
                _hive = RegistryHive.Create(File.Open(configFilename, FileMode.OpenOrCreate));
                _methods = _hive.Root.CreateSubKey("payment_methods");
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

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static RegistryHive _hive;
        private static RegistryKey _methods;
        private static string configFilename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Expay.config";
    }
}