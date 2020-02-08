using ExPay.Core.API;
using ExPay.Core.Contracts;
using Furesoft.Signals.Attributes;
using System.ComponentModel;
using System.Linq;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class MetaMethods
    {
        [SharedFunction((int)SharedMethodIds.GetSupportedMethodIds)]
        [Description("Get supported Payment Method IDs")]
        public static string[] GetSupportedMethodIds()
        {
            var ids = PluginLoader.Instance.PaymentMethods.Select(_ => _.GetInfo.ID);

            return ids.ToArray();
        }
    }
}