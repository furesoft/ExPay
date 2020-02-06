﻿using Avalonia;
using Avalonia.Logging.Serilog;
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

                    AppBuilder.StartWithClassicDesktopLifetime(null);
                    Application = AppBuilder.Instance;
                }
            });

            UIThread.Start();
        }

        private static AppBuilder BuildAvaloniaApp()
                    => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();
    }
}