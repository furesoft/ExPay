using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace ExPay.Core.UI.Controls
{
    public class ContentDialog : ContentControl
    {
        #region Styled properties

        public static readonly StyledProperty<bool> IsOpenedProperty =
        AvaloniaProperty.Register<ContentDialog, bool>(nameof(IsOpened));

        public bool IsOpened
        {
            get { return GetValue(IsOpenedProperty); }
            set { SetValue(IsOpenedProperty, value); }
        }



        public static readonly StyledProperty<object> DialogContentProperty =
       AvaloniaProperty.Register<ContentDialog, object>(nameof(DialogContent));

        public object DialogContent
        {
            get { return GetValue(DialogContentProperty); }
            set { SetValue(DialogContentProperty, value); }
        }

        #endregion Styled properties



        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            base.OnTemplateApplied(e);


        }
    }
}