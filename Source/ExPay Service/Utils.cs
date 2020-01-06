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
        public static T ShowDialog<T, U>()
            where U : Window, new()
        {
            var tcs = new TaskCompletionSource<T>();

            var uiThread = new Thread(() =>
            {
                var a = new Application();
                var dialog = new U();

                a.MainWindow = dialog;
                a.MainWindow.ShowDialog();

                a.Exit += (s, e) =>
                {
                    tcs.SetResult((T)dialog.Tag);
                };

                a.Run();
            });

            uiThread.SetApartmentState(ApartmentState.STA);
            uiThread.Start();

            return tcs.Task.Result;
        }
    }
}