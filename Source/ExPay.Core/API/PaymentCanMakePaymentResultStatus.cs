namespace ExPay.Core.API
{
    public enum PaymentCanMakePaymentResultStatus
    {
        Unknown,
        Yes,
        No,
        NotAllowed,
        SpecifiedPaymentMethodIdsNotSupported,
    }
}