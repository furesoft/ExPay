using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ExPay.Core
{
    public static class Utils
    {
        public static Bitmap DownloadBitmap(string uri)
        {
            var client = new WebClient();
            var strm = client.DownloadData(uri);

            return new Bitmap(new MemoryStream(strm));
        }

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