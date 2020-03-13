using Avalonia;
using Avalonia.Controls;

namespace ExPay.Core.UI.Controls
{
    public class DialogService
    {
        public static readonly AttachedProperty<bool> DialogHostProperty =
        AvaloniaProperty.RegisterAttached<DialogService, ContentDialog, bool>("DialogHost");

        public static readonly AttachedProperty<bool> CloseDialogProperty =
       AvaloniaProperty.RegisterAttached<DialogService, ContentDialog, bool>("CloseDialog");

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

        public static bool GetCloseDialog(ContentDialog element)
        {
            return element.GetValue(CloseDialogProperty);
        }

        public static void SetCloseDialog(ContentDialog element, bool value)
        {
            element.SetValue(CloseDialogProperty, value);
            CloseDialog();
        }

        public static void OpenDialog(Control content)
        {
            if (_host != null)
            {
                _host.DialogContent = content;
                _host.IsOpened = true;
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