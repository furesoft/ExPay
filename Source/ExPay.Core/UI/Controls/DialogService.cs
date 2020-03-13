using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using System;

namespace ExPay.Core.UI.Controls
{
    public class DialogService
    {
        public static readonly AttachedProperty<bool> DialogHostProperty =
        AvaloniaProperty.RegisterAttached<DialogService, ContentDialog, bool>("DialogHost");

        public static readonly AttachedProperty<bool> CloseDialogProperty =
       AvaloniaProperty.RegisterAttached<DialogService, Button, bool>("CloseDialog");

        private static ContentDialog _host;

        public static bool GetDialogHost(ContentDialog element)
        {
            return element.GetValue(DialogHostProperty);
        }

        public static void SetDialogHost(ContentDialog element, bool value)
        {
            element.SetValue(DialogHostProperty, value);
            _host = element;
        }

        public static bool GetCloseDialog(Button element)
        {
            return element.GetValue(CloseDialogProperty);
        }

        public static void SetCloseDialog(Button element, bool value)
        {
            element.SetValue(CloseDialogProperty, value);

            element.Click += (s, e) => CloseDialog();
        }

        public static void OpenDialog(Control content, TimeSpan autoCloseTime = default)
        {
            if (_host != null)
            {
                _host.DialogContent = content;
                _host.IsOpened = true;

                if (autoCloseTime != default)
                {
                    EventHandler start_autoclose = null;
                    start_autoclose = (s, e) =>
                    {
                        var timer = new DispatcherTimer();
                        timer.Tick += (_, __) =>
                        {
                            CloseDialog();
                            content.Initialized -= start_autoclose;
                            timer.Stop();
                        };

                        timer.Interval = autoCloseTime;
                        timer.Start();
                    };

                    content.Initialized += start_autoclose;
                }
            }
        }

        public static void CloseDialog()
        {
            if (_host != null)
            {
                _host.IsOpened = false;
            }
        }
    }
}