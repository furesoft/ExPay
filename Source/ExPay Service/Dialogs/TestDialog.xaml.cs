using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ExPay_Service.Dialogs
{
    public class TestDialog : Window
    {
        public TestDialog()
        {
            this.InitializeComponent();
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