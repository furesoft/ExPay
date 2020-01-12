using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging.Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExPay_Service
{
    public static class Utils
    {
        [STAThread]
        public static TResult ShowDialog<TResult, TDialog>(object context = null)
            where TDialog : Window, new()
        {
            var tcs = new TaskCompletionSource<TResult>();

            var t = new Thread(() =>
           {
               if (a == null)
               {
                   a = BuildAvaloniaApp();
                   a.SetupWithoutStarting();
               }

               var dialog = new TDialog();
               dialog.DataContext = context;
               dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;

               dialog.Closed += (s, e) =>
               {
                   tcs.SetResult((TResult)dialog.Tag);
               };

               a.Instance.Run(dialog);
           });

            t.Start();

            return tcs.Task.Result;
        }

        private static AppBuilder a;

        private static AppBuilder BuildAvaloniaApp()
                    => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();
    }
}