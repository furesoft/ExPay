using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ExPay.Core;
using ExPay.Core.API;
using ExPay.Core.Models;
using ExPay.Core.UI.Controls;
using ExPay_Service.Dialogs;
using NLog;
using System;

namespace ExPay_Service.Views
{
    public class PayView : Window
    {
        public PayView()
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
            DialogService.OpenDialog(new PaymentStatusDialog(), TimeSpan.FromSeconds(3));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}