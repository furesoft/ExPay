﻿namespace ExPay.Core.API
{
    public enum SharedMethodIds
    {
        Ping = 0xAA,
        GetSupportedMethodIds = 0x1D,
        SubmitPaymentRequest = 0xEE,
        Complete = 0xCC,

        OpenDialogTest = 0x3A1,
    }
}