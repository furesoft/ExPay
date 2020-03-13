using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Metadata;

namespace ExPay.Core.UI.Controls
{

    public class ContentDialog : TemplatedControl
    {

        public static readonly StyledProperty<bool> IsOpenedProperty =
        AvaloniaProperty.Register<ContentDialog, bool>(nameof(IsOpened));

        public static readonly StyledProperty<object> ContentProperty =
        AvaloniaProperty.Register<ContentDialog, object>(nameof(Content));

        public static readonly StyledProperty<int> DialogMaxWidthProperty =
        AvaloniaProperty.Register<ContentDialog, int>(nameof(DialogMaxWidth));

        public static readonly StyledProperty<int> DialogMaxHeigthProperty =
        AvaloniaProperty.Register<ContentDialog, int>(nameof(DialogMaxHeigth));

        static ContentDialog()
        {
            IsOpenedProperty.OverrideDefaultValue(typeof(bool), false);
        }

        public bool IsOpened
        {
            get { return GetValue(IsOpenedProperty); }
            set { SetValue(IsOpenedProperty, value); }
        }

        public int DialogMaxHeigth
        {
            get { return GetValue(DialogMaxHeigthProperty); }
            set { SetValue(DialogMaxHeigthProperty, value); }
        }

        public int DialogMaxWidth
        {
            get { return GetValue(DialogMaxWidthProperty); }
            set { SetValue(DialogMaxWidthProperty, value); }
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