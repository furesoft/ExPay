using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ExPay.Core.API;

namespace ExPay_Service.Dialogs
{
    public class TestDialog : Window
    {
        public TestDialog()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tag = new PaymentRequestSubmitResult();
            Close();
        }
    }
}