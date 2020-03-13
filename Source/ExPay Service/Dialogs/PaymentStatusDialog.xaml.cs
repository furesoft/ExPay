using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core;

namespace ExPay_Service.Dialogs
{
    public class PaymentStatusDialog : UserControl
    {
        public PaymentStatusDialog()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}