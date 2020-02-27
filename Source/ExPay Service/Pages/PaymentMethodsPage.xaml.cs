using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ExPay_Service.Pages
{
    public class PaymentMethodsPage : UserControl
    {
        public PaymentMethodsPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
