using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ExPay_Service.Pages
{
    public class PaymentDetailsPage : UserControl
    {
        public PaymentDetailsPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
