using ExPay.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ExPay_Service
{
    public static class Utils
    {
        [STAThread]
        public static TResult ShowDialog<TResult, TDialog>(object context = null)
            where TDialog : Window, new()
        {
            var tcs = new TaskCompletionSource<TResult>();

            Thread uiThread = new Thread(() =>
            {
                var a = Singleton<Application>.Instance;

                var dialog = new TDialog();
                dialog.DataContext = context;

                a.MainWindow = dialog;
                a.ShutdownMode = ShutdownMode.OnExplicitShutdown;

                a.MainWindow.ShowDialog();

                a.Exit += (s, e) =>
                {
                    tcs.SetResult((TResult)dialog.Tag);
                    a.Shutdown();
                };

                a.Run();
            });

            uiThread.SetApartmentState(ApartmentState.STA);
            uiThread.Start();

            return tcs.Task.Result;
        }
    }
}