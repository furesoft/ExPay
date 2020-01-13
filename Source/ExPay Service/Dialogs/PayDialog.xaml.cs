using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core.API;
using System;

namespace ExPay_Service.Dialogs
{
    public class PayDialog : Window
    {
        public PayDialog()
        {
            this.InitializeComponent();

            Tag = new PaymentRequestSubmitResult { Status = ExPay.Core.Models.PaymentRequestStatus.Canceled };
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}