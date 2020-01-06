using ExPay.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExPay.Core.API
{
    public class PaymentMediator
    {
        public Task<PaymentCanMakePaymentResultStatus> CanMakePaymentAsync(PaymentRequest paymentRequest)
        {
            return null;
        }

        public Task<IEnumerable<string>> GetSupportedMethodIdsAsync()
        {
            return null;
        }

        public Task<PaymentRequestSubmitResult> SubmitPaymentRequestAsync(PaymentRequest paymentRequest)
        {
            return null;
        }
    }
}