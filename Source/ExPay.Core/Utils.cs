using Avalonia.Controls;
using Avalonia.Threading;
using System.Threading.Tasks;

namespace ExPay.Core
{
    public static class Utils
    {
        public static Task<TResult> ShowDialog<TResult, TDialog>(object context = null)
            where TDialog : Window, new()
        {
            var tcs = new TaskCompletionSource<TResult>();

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                var dialog = new TDialog();
                dialog.DataContext = context;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                dialog.Closing += (s, e) =>
                {
                    tcs.SetResult((TResult)dialog.Tag);
                };

                dialog.Show();
            }).ConfigureAwait(false);

            return tcs.Task;
        }
    }
}