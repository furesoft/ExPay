using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ExPay.Core;
using ExPay.Core.API;
using ExPay.Core.Models;
using NLog;
using System;

namespace ExPay_Service.Dialogs
{
    public class PayDialog : Window
    {
        public PayDialog()
        {
            this.InitializeComponent();

            this.Activated += PayDialog_Initialized;

            Tag = new PaymentRequestSubmitResult { Status = PaymentRequestStatus.Canceled };
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void PayDialog_Initialized(object sender, EventArgs e)
        {
            this.FindControl<Button>("nextBtn").Content = I18N._("Pay");
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void OnPay(object sender, RoutedEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}