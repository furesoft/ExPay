using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ExPay.Core.API;
using ExPay.Core.Navigation;
using ExPay_Service.Core;
using ExPay_Service.Core.Navigation;
using ExPay_Service.Pages;
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

            Tag = new PaymentRequestSubmitResult { Status = ExPay.Core.Models.PaymentRequestStatus.Failed };
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void PayDialog_Initialized(object sender, EventArgs e)
        {
            var frame = this.FindControl<ContentControl>("content");
            Navigator.Init(this, frame, new PaymentDetailsPage());

            Navigator.AddAction(NavigatorAction.SwitchPage(new PaymentMethodsPage()));
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public void OnCancel(object sender, RoutedEventArgs e)
        {
            Logger.Info("Payment canceled");

            Tag = new PaymentRequestSubmitResult { Status = ExPay.Core.Models.PaymentRequestStatus.Canceled };
            Close();
        }

        public void OnPay(object sender, RoutedEventArgs e)
        {
            Navigator.Forward();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}