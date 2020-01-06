using ExPay.Core.Models;

namespace ExPay.Core.API
{
    public class PaymentRequestSubmitResult
    {
        public PaymentResponse Response { get; set; }
        public PaymentRequestStatus Status { get; set; }
    }
}