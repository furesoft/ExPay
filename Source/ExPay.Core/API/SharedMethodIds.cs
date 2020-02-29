namespace ExPay.Core.API
{
    public enum SharedMethodIds
    {
        Ping = 0xAA,
        GetSupportedMethodIds = 0x1D,
        SubmitPaymentRequest = 0xEE,
        IsPaymentConfigured = 0xCD,
        GetPaymentStatus = 0x3A,

        OpenDialogTest = 0x3A1,
    }
}