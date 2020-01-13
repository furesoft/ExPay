using ExPay.Core.API;
using Furesoft.Signals.Attributes;
using System.ComponentModel;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class MetaMethods
    {
        [SharedFunction((int)SharedMethodIds.GetSupportedMethodIds)]
        [Description("Get supported Payment Method IDs")]
        public static string[] GetSupportedMethodIds()
        {
            return null;
        }
    }
}