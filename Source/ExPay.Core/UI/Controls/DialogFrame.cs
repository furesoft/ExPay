using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Windows.Input;

namespace ExPay.Core.UI.Controls
{
    public class DialogResult
    {
        public enum DialogState { Cancel, Ok }
        public DialogState State { get; set; }
        public object Result { get; set; }
    }

    public class DialogFrame : ContentControl
    {
        public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<DialogFrame, string>(nameof(Title));

        public string Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly StyledProperty<DialogResult> ResultProperty =
        AvaloniaProperty.Register<DialogFrame, DialogResult>(nameof(Result));

        public DialogResult Result
        {
            get { return GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            var okBtn = e.NameScope.Find<Button>("okBtn");
            var cancelBtn = e.NameScope.Find<Button>("cancelBtn");

            cancelBtn.Click += (_, __) =>
            {
                Result = new DialogResult { State = DialogResult.DialogState.Cancel, Result = DataContext };
                DialogService.CloseDialog();
            };

            okBtn.Click += (_, __) =>
            {
                Result = new DialogResult { State = DialogResult.DialogState.Ok, Result = DataContext };
                DialogService.CloseDialog();
            };
        }
    }
}