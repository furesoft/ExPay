using ExPay.Core.Models;

namespace ExPay.Core.API
{
    public class PaymentRequestSubmitResult
    {
        public PaymentResponse Response { get; set; } = new PaymentResponse();
        public PaymentRequestStatus Status { get; set; }
    }
}