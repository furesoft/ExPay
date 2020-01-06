using System;

namespace ExPay.Core.Contracts
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PaymentAttribute : Attribute
    {
        public string Name { get; set; }
        public string URN { get; set; }

        public PaymentAttribute(string name, string uRN)
        {
            URN = uRN;
            Name = name;
        }
    }
}