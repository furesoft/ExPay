using ExPay.Core.API;
using ExPay_Service.Dialogs;
using Furesoft.Signals.Attributes;
using System.ComponentModel;

namespace ExPay_Service.SharedFunctions
{
    [Shared]
    public class SharedUI
    {
        [SharedFunction((int)SharedMethodIds.OpenDialogTest)]
        [Description("Show a TestDialog")]
        public static int OpenDialog()
        {
            return Utils.ShowDialog<int, TestDialog>().Result;
        }
    }
}