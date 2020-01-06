namespace ExPay.Core.Models
{
    public class PaymentShippingOption
    {
        public PaymentCurrencyAmount Amount { get; set; }

        public string Name { get; set; }

        public PaymentShippingOption()
        {
        }

        public PaymentShippingOption(string name, PaymentCurrencyAmount amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}