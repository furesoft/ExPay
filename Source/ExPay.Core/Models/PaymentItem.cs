namespace ExPay.Core.Models
{
    public class PaymentItem
    {
        public PaymentCurrencyAmount Amount { get; set; }

        public string Name { get; set; }

        public PaymentItem()
        {
        }

        public PaymentItem(string name, PaymentCurrencyAmount amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}