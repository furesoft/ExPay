namespace ExPay.Core.Models
{
    public sealed class PaymentResponse
    {
        public string PayerEmail { get; set; }
        public string PayerName { get; set; }
        public string PayerPhoneNumber { get; set; }
        public string PaymentToken { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public PaymentShippingOption ShippingOption { get; set; }
    }
}