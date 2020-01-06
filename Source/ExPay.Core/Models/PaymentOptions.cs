namespace ExPay.Core.Models
{
    public class PaymentOptions
    {
        public PaymentOptionPresence RequestPayerEmail { get; set; }
        public PaymentOptionPresence RequestPayerName { get; set; }
        public PaymentOptionPresence RequestPayerPhoneNumber { get; set; }
        public bool RequestShipping { get; set; }
        public PaymentShippingType ShippingType { get; set; }
    }
}