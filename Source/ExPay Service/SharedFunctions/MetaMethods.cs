using ExPay.Core.API;
using Furesoft.Signals.Attributes;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class MetaMethods
    {
        [SharedFunction((int)SharedMethodIds.GetSupportedMethodIds)]
        public string[] GetSupportedMethodIds()
        {
            return null;
        }
    }
}