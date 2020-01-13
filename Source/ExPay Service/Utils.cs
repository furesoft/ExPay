using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging.Serilog;
using Avalonia.Threading;
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

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                var dialog = new TDialog();
                dialog.DataContext = context;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                dialog.Closed += (s, e) =>
                {
                    tcs.SetResult((TResult)dialog.Tag);
                };

                WindowManager.AppBuilder.Instance.Run(dialog);
            });

            return tcs.Task.Result;
        }
    }
}