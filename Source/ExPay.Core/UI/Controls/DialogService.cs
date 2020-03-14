using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.Threading.Tasks;

namespace ExPay.Core.UI.Controls
{
    public class DialogService
    {
        public static readonly AttachedProperty<bool> DialogHostProperty =
        AvaloniaProperty.RegisterAttached<DialogService, ContentDialog, bool>("DialogHost");

        public static readonly AttachedProperty<bool> CloseDialogProperty =
       AvaloniaProperty.RegisterAttached<DialogService, Button, bool>("CloseDialog");

        public static readonly AttachedProperty<TimeSpan> AutoCloseDialogProperty =
       AvaloniaProperty.RegisterAttached<DialogService, Button, TimeSpan>("AutoCloseDialog");

        private static ContentDialog _host;

        public static event Action<Control> DialogClosed;

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

        public static TimeSpan GetAutoCloseDialog(Button element)
        {
            return element.GetValue(AutoCloseDialogProperty);
        }

        public static void SetAutoCloseDialog(Button element, TimeSpan value)
        {
            element.SetValue(AutoCloseDialogProperty, value);

            var timer = new DispatcherTimer();
            timer.Tick += (_, __) =>
            {
                CloseDialog();

                timer.Stop();
            };

            timer.Interval = value;
            timer.Start();
        }

        public static Task<DialogResult> ShowDialog(string title, Control content, object context = null)
        {
            var tcs = new TaskCompletionSource<DialogResult>();

            var frame = new DialogFrame();
            frame.Content = content;
            frame.Title = title;

            Action<Control> closed = null;
            closed = new Action<Control>((_) =>
            {
                DialogClosed -= closed;
                tcs.SetResult(frame.Result);
            });

            DialogClosed += closed;

            OpenDialog(frame, context: context);

            return tcs.Task;
        }

        public static void OpenDialog(Control content, TimeSpan autoCloseTime = default, object context = null)
        {
            if (_host != null)
            {
                _host.DialogContent = content;
                _host.IsOpened = true;

                if (context != null)
                {
                    content.DataContext = context;
                }

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
                DialogClosed?.Invoke((Control)_host.Content);
            }
        }
    }
}