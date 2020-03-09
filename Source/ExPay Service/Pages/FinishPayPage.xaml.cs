using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core;
using ExPay.Core.Contracts;
using ExPay.Core.Models;
using ExPay_Service.Dialogs;
using System.Linq;

namespace ExPay_Service.Pages
{
    public class FinishPayPage : UserControl
    {
        public FinishPayPage()
        {
            this.InitializeComponent();

            this.Initialized += FinishPayPage_Initialized;
        }

        public async void OnFinish()
        {
            var paymentMethodsLb = this.FindControl<ComboBox>("paymentMethodsCb");

            var selectedMethod = (IPaymentMethod)paymentMethodsLb.SelectedItem;
            var accpt_pi = Singleton<PaymentRequest>.Instance.AcceptedPaymentMethods.Where(_ => _.URN == selectedMethod?.Info.ID).FirstOrDefault();

            var data = await selectedMethod?.BeforePay(accpt_pi?.Data);

            selectedMethod.Invoke(data);
        }

        public void OnClick(object sender, System.EventArgs e)
        {
            var td = new TestWindow();
            td.Show();
        }

        private void FinishPayPage_Initialized(object sender, System.EventArgs e)
        {
            var paymentMethodsCb = this.FindControl<ComboBox>("paymentMethodsCb");
            paymentMethodsCb.Items = PluginLoader.Instance.PaymentMethods.ToList();
            paymentMethodsCb.SelectedIndex = PaymentConfig.GetValue<int>("defaultPaymentMethod");

            //init labels
            this.FindControl<TextBlock>("paymentMethodLbl").Text = I18N._("Pay with");
            this.FindControl<TextBlock>("shipToLbl").Text = I18N._("Ship to");
            this.FindControl<TextBlock>("shippingOptionsLbl").Text = I18N._("Shipping Options");
            this.FindControl<TextBlock>("emailLbl").Text = I18N._("Email receipt to");
            this.FindControl<TextBlock>("phoneLbl").Text = I18N._("Phone");

            this.FindControl<Button>("test").Click += OnClick;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}