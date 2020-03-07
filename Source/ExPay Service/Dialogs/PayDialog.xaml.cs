using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ExPay.Core;
using ExPay.Core.API;
using ExPay.Core.Models;
using ExPay.Core.Navigation;
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
            this.FindControl<Button>("cancelBtn").Content = I18N._("Cancel");
            this.FindControl<Button>("nextBtn").Content = I18N._("Next");

            var frame = this.FindControl<ContentControl>("content");
            Navigator.Init(this, frame, new PaymentDetailsPage());

            Navigator.AddAction(NavigatorAction.SwitchPage(new PaymentShippingPage()));
            Navigator.AddAction(NavigatorAction.SwitchPage(new PaymentMethodsPage()));
            Navigator.AddAction(NavigatorAction.Finish(new PaymentRequestSubmitResult() { Status = PaymentRequestStatus.Succeeded, Response = new PaymentResponse() { } }));

            var req = (PaymentRequest)DataContext;

            if (req.MerchantInfo.ImageUrl != null)
            {
                this.FindControl<Image>("merchantImage").Source = Utils.DownloadBitmap(req.MerchantInfo.ImageUrl.ToString());
            }
            else
            {
                this.FindControl<TextBlock>("merchantName").IsVisible = true;
                this.FindControl<Image>("merchantImage").IsVisible = false;
            }
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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