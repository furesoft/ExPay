namespace ExPay.Core.Contracts
{
    public class PaymentMethodInfo
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public PaymentMethodInfo(string iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}