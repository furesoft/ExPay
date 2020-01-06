using ExPay.Core.API;
using Furesoft.Signals.Attributes;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class PingMethod
    {
        [SharedFunction((int)SharedMethodIds.Ping)]
        public static bool Ping()
        {
            return true;
        }
    }
}