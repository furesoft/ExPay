using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using ExPay.Core.UI.Controls;

namespace ExPay_Service.Dialogs
{
    public class TestWindow : Window
    {
        public TestWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();

            this.Initialized += TestWindow_Initialized;
#endif
        }

        private void TestWindow_Initialized(object sender, System.EventArgs e)
        {
            var toggle = this.FindControl<ToggleButton>("toggle");
            toggle.Click += (s, e) =>
         {
             var dialog = this.FindControl<ContentDialog>("cd");
             dialog.IsOpened = toggle.IsChecked.Value;
         };
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }


}
