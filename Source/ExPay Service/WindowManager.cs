using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Dialogs;
using Avalonia.Logging.Serilog;
using Avalonia.Threading;
using ExPay.Core;
using ExPay_Service.Views;
using System;
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
            Logger.Trace("WindowManager initialized");
        }

        public static async void Shutdown()
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var lifetime = (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;
                Logger.Trace("WindowManager Stoped");

                lifetime.Shutdown();
            });
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private static AppBuilder BuildAvaloniaApp()
                    => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseManagedSystemDialogs()
                .LogToDebug();
    }
}