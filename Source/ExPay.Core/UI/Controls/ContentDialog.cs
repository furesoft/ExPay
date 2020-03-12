using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Metadata;

namespace ExPay.Core.UI.Controls
{

    public class ContentDialog : TemplatedControl
    {

        public static readonly StyledProperty<bool> IsOpenedProperty =
        AvaloniaProperty.Register<ContentDialog, bool>(nameof(IsOpened));

        public static readonly StyledProperty<object> ContentProperty =
        AvaloniaProperty.Register<ContentDialog, object>(nameof(Content));

        static ContentDialog()
        {
            IsOpenedProperty.OverrideDefaultValue(typeof(bool), false);
        }

        public bool IsOpened
        {
            get { return GetValue(IsOpenedProperty); }
            set { SetValue(IsOpenedProperty, value); }
        }

        [Content]
        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly StyledProperty<object> DialogContentProperty =
       AvaloniaProperty.Register<ContentDialog, object>(nameof(DialogContent));

        public object DialogContent
        {
            get { return GetValue(DialogContentProperty); }
            set { SetValue(DialogContentProperty, value); }
        }

    }
}