using ExPay.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace ExPay_Service
{
    public static class Utils
    {
        public static Notifier MakeNotifier()
        {
            return new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Singleton<Application>.Instance.MainWindow,
                    corner: Corner.TopRight,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Singleton<Application>.Instance.Dispatcher;
            });
        }

        [STAThread]
        public static TResult ShowDialog<TResult, TDialog>(object context = null)
            where TDialog : Window, new()
        {
            var tcs = new TaskCompletionSource<TResult>();

            Thread uiThread = new Thread(() =>
            {
                var a = Singleton<Application>.Instance;
                a.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/ToastNotifications.Messages;component/Themes/Default.xaml") });

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