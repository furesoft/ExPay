using ExPay.Core.API;
using ExPay_Service.Dialogs;
using Furesoft.Signals.Attributes;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class SharedUI
    {
        [SharedFunction((int)SharedMethodIds.OpenDialogTest)]
        public static int OpenDialog()
        {
            return Utils.ShowDialog<int, TestDialog>();
        }
    }
}