namespace ExPay.Core.Contracts
{
    public class PaymentMethodInfo
    {
        public string IconUrl { get; set; }

        public string ID { get; set; }

        public string Name { get; set; }

        public PaymentMethodInfo(string iD, string name, string iconUrl)
        {
            ID = iD;
            Name = name;
            IconUrl = iconUrl;
        }
    }
}