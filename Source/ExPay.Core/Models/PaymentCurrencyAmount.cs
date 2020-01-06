namespace ExPay.Core.Models
{
    public class PaymentCurrencyAmount
    {
        public string Currency { get; set; }
        public decimal Value { get; set; }

        public PaymentCurrencyAmount(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}