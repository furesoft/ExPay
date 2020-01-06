namespace ExPay.Core.Models
{
    public class PaymentMethodData
    {
        public object Data { get; set; }

        public string URN { get; set; }

        public PaymentMethodData(string uRN, object data)
        {
            URN = uRN;
            Data = data;
        }
    }
}