using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core;
using ExPay.Core.Contracts;
using ExPay.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExPay_Service.Pages
{
    public class PaymentMethodsPage : UserControl
    {
        public List<IPaymentMethod> PaymentMethods { get; set; }

        public PaymentMethodsPage()
        {
            this.InitializeComponent();

            this.Initialized += (s, e) =>
             {

                 _request = Singleton<PaymentRequest>.Instance;
                 DataContext = this;

                 PaymentMethods = PluginLoader.Instance.PaymentMethods.ToList();

                 var paymentMethodsLb = this.FindControl<ListBox>("paymentMethodsLb");
                 paymentMethodsLb.Items = PaymentMethods;
             };
        }

        public async void OnFinish()
        {
            var paymentMethodsLb = this.FindControl<ListBox>("paymentMethodsLb");

            var selectedMethod = (IPaymentMethod)paymentMethodsLb.SelectedItem;
            var accpt_pi = _request.AcceptedPaymentMethods.Where(_ => _.URN == selectedMethod?.Info.ID).FirstOrDefault();

            var data = await selectedMethod?.BeforePay(accpt_pi?.Data);

            selectedMethod.Invoke(data);
        }

        private PaymentRequest _request;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}