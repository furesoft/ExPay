﻿using Avalonia.Controls;
using Avalonia.Threading;
using System.Threading.Tasks;

namespace ExPay_Service
{
    public static class Utils
    {
        public static async Task<TResult> ShowDialog<TResult, TDialog>(object context = null)
            where TDialog : Window, new()
        {
            var tcs = new TaskCompletionSource<TResult>();

            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var dialog = new TDialog();
                dialog.DataContext = context;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                dialog.Closed += (s, e) =>
                {
                    tcs.SetResult((TResult)dialog.Tag);
                };

                dialog.Show();
            });

            return tcs.Task.Result;
        }
    }
}