using ExPay.Core.API;
using Furesoft.Signals.Attributes;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class DatabaseFunctions
    {
        [SharedFunction((int)SharedMethodIds.OpenDB)]
        public static void TestDb()
        {
        }
    }
}