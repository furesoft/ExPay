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

            this.Initialized += FinishPayPage_Initialized;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void FinishPayPage_Initialized(object sender, System.EventArgs e)
        {
            this.FindControl<TextBlock>("statusLbl").Text = I18N._("Success");
        }
    }
}