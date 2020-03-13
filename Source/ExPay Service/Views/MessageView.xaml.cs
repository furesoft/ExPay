﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core.API;

namespace ExPay_Service.Views
{
    public class MessageView : Window
    {
        public MessageView()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            Tag = new PaymentRequestSubmitResult { Status = ExPay.Core.Models.PaymentRequestStatus.Failed };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}