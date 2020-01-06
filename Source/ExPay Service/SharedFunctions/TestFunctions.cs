using ExPay_Service.Dialogs;
using Furesoft.Signals.Attributes;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class SharedUI
    {
        [SharedFunction(0x3A1)]
        public static int OpenDialog()
        {
            return Utils.ShowDialog<int, TestDialog>();
        }
    }
}