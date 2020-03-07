using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KryptoPlugin
{
    public class TestPage : Window
    {
        public TestPage()
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
