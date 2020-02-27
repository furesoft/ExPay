using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core.Contracts;
using System.Collections.Generic;

namespace ExPay_Service.Pages
{
    public class PaymentMethodsPage : UserControl
    {
        public IEnumerable<IPaymentMethod> PaymentMethods { get; set; }

        public PaymentMethodsPage()
        {
            this.InitializeComponent();

            this.Initialized += (s, e) =>
             {
                 DataContext = this;
                 PaymentMethods = PluginLoader.Instance.PaymentMethods;
             };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
