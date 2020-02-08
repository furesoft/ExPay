using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Dialogs;
using Avalonia.Logging.Serilog;
using Avalonia.Threading;
using System.Threading;

namespace ExPay_Service
{
    public static class WindowManager
    {
        public static AppBuilder AppBuilder;
        public static Application Application;
        public static Thread UIThread;

        public static void Init()
        {
            UIThread = new Thread(() =>
            {
                if (AppBuilder == null)
                {
                    AppBuilder = BuildAvaloniaApp();

                    AppBuilder.StartWithClassicDesktopLifetime(null, Avalonia.Controls.ShutdownMode.OnExplicitShutdown);
                    Application = AppBuilder.Instance;
                }
            });

            UIThread.Start();
        }

        public static async void Shutdown()
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var lifetime = (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;
                lifetime.Shutdown();
            });
        }

        private static AppBuilder BuildAvaloniaApp()
                    => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseManagedSystemDialogs()
                .LogToDebug();
    }
}