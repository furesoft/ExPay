using DiscUtils.Registry;
using ExPay.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExPay.Core
{
    public class PaymentMethodConfig
    {
        public PaymentMethodConfig()
        {
            var frame = new StackFrame(1, true);
            var method = frame.GetMethod();
            var type = method.DeclaringType;
            var typeInstance = (IPaymentMethod)Activator.CreateInstance(type);
            var id = typeInstance.Info.ID;

            Logger.Trace($"Payment Method Config for '{id}' opened");

            _key = PaymentConfig._methods.OpenSubKey(id);
        }

        public object GetValue(string key)
        {
            return _key.GetValue(key);
        }

        public IEnumerable<string> GetValueNames()
        {
            return _key.GetValueNames();
        }

        public void SetValue(string key, object value)
        {
            _key.SetValue(key, value);
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private RegistryKey _key;
    }
}