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

            Tag = new PaymentRequestSubmitResult { Status = PaymentRequestStatus.Canceled };
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