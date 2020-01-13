using ExPay.Core.API;
using Furesoft.Signals.Attributes;
using System.ComponentModel;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class PingMethod
    {
        [SharedFunction((int)SharedMethodIds.Ping)]
        [Description("Ping")]
        public static bool Ping()
        {
            return true;
        }
    }
}