using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core;
using ExPay.Core.API;
using ExPay.Core.Models;
using ExPay.Core.Navigation;
using System;

namespace ExPay_Service.Pages
{
    public class PaymentShippingPage : UserControl, IPageSwitched
    {
        public PaymentShippingPage()
        {
            this.InitializeComponent();
            this.Initialized += PaymentShippingPage_Initialized;
        }

        private void PaymentShippingPage_Initialized(object sender, System.EventArgs e)
        {
            this.FindControl<TextBox>("firstNameTb").Watermark = I18N._("Firstname");
            this.FindControl<TextBox>("secondNameTb").Watermark = I18N._("Lastname");

            this.FindControl<TextBox>("adressLineTb").Watermark = I18N._("Street");
            this.FindControl<TextBox>("postalcodeTb").Watermark = I18N._("Postal Code");
            this.FindControl<TextBox>("cityTb").Watermark = I18N._("City");

            this.FindControl<TextBlock>("HeaderTb").Text = I18N._("Shipping Address");

            LoadConfiguredData();
        }

        private void LoadConfiguredData()
        {
            this.FindControl<TextBox>("firstNameTb").Text = PaymentConfig.GetValue("firstname");
            this.FindControl<TextBox>("secondNameTb").Text = PaymentConfig.GetValue("lastname");

            this.FindControl<TextBox>("adressLineTb").Text = PaymentConfig.GetValue("adressline");
            this.FindControl<TextBox>("postalcodeTb").Text = PaymentConfig.GetValue("postalcode");
            this.FindControl<TextBox>("cityTb").Text = PaymentConfig.GetValue("city");
        }

        private void SaveData()
        {
            PaymentConfig.SetValue("firstname", this.FindControl<TextBox>("firstNameTb").Text);
            PaymentConfig.SetValue("lastname", this.FindControl<TextBox>("secondNameTb").Text);

            PaymentConfig.SetValue("adressline", this.FindControl<TextBox>("adressLineTb").Text);
            PaymentConfig.SetValue("postalcode", this.FindControl<TextBox>("postalcodeTb").Text);
            PaymentConfig.SetValue("city", this.FindControl<TextBox>("cityTb").Text);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void OnPageSwitched(Control newPage)
        {
            SaveData();

            var req = Singleton<PaymentRequestSubmitResult>.Instance;
            req.Response.ShippingAddress = CreateAddress();
            req.Response.PayerName = string.Join(' ', this.FindControl<TextBox>("firstNameTb").Text, this.FindControl<TextBox>("secondNameTb").Text);
        }

        private ShippingAddress CreateAddress()
        {
            var sa = new ShippingAddress();

            sa.StreetLine = this.FindControl<TextBox>("adressLineTb").Text;
            sa.PostalCode = this.FindControl<TextBox>("postalcodeTb").Text;
            sa.City = this.FindControl<TextBox>("cityTb").Text;

            return sa;
        }
    }
}