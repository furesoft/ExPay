using Avalonia;
using Avalonia.Markup.Xaml;

namespace ExPay_Service
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}