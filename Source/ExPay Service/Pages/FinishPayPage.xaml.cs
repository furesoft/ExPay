using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ExPay.Core;
using ExPay.Core.Contracts;
using ExPay.Core.Models;
using ExPay.Core.UI.Controls;
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

        private void FinishPayPage_Initialized(object sender, System.EventArgs e)
        {
            var paymentMethodsCb = this.FindControl<ComboBox>("paymentMethodsCb");
            paymentMethodsCb.Items = PluginLoader.Instance.PaymentMethods.ToList();
            paymentMethodsCb.SelectedIndex = PaymentConfig.GetValue<int>("defaultPaymentMethod");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}