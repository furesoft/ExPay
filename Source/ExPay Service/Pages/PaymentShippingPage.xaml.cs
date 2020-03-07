using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core;

namespace ExPay_Service.Pages
{
    public class PaymentShippingPage : UserControl
    {
        public PaymentShippingPage()
        {
            this.InitializeComponent();
            this.Initialized += PaymentShippingPage_Initialized;
        }

        private void PaymentShippingPage_Initialized(object sender, System.EventArgs e)
        {
            this.FindControl<TextBox>("firstNameTb").Watermark = I18N._("Firstname");
            this.FindControl<TextBox>("secondNameTb").Watermark = I18N._("Firstname");

            this.FindControl<TextBox>("adressLineTb").Watermark = I18N._("Street");
            this.FindControl<TextBox>("postalcodeTb").Watermark = I18N._("Postal Code");
            this.FindControl<TextBox>("cityTb").Watermark = I18N._("City");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}