using DiscUtils.Registry;
using ExPay.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExPay.Core
{
    public class PaymentMethodConfig
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private RegistryKey _key;

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

        public void SetValue(string key, object value)
        {
            _key.SetValue(key, value);
        }

        public object GetValue(string key)
        {
            return _key.GetValue(key);
        }

        public IEnumerable<string> GetValueNames()
        {
            return _key.GetValueNames();
        }
    }
}