using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core;
using ExPay.Core.Contracts;
using ExPay.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExPay_Service.Pages
{
    public class PaymentMethodsPage : UserControl, IFinished
    {
        public List<IPaymentMethod> PaymentMethods { get; set; }

        public PaymentMethodsPage()
        {
            this.InitializeComponent();

            this.Initialized += (s, e) =>
             {
                 this.FindControl<TextBlock>("HeaderTb").Text = I18N._("Payment Methods");

                 DataContext = this;
                 PaymentMethods = PluginLoader.Instance.PaymentMethods.ToList();

                 var paymentMethodsLb = this.FindControl<ListBox>("paymentMethodsLb");
                 paymentMethodsLb.Items = PaymentMethods;
             };
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void OnFinish()
        {
            var paymentMethodsLb = this.FindControl<ListBox>("paymentMethodsLb");
            Console.WriteLine("Selected: " + paymentMethodsLb.SelectedItem.ToString());
        }
    }
}