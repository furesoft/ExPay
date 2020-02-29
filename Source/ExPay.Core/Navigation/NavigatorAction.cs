using Avalonia.Controls;
using ExPay.Core.Navigation.Actions;
using ExPay_Service.Core.Navigation;
using System;

namespace ExPay.Core.Navigation
{
    public static class NavigatorAction
    {
        public static INavigatorAction SwitchPage(Control defaultContent)
        {
            return new SwitchPageAction(defaultContent);
        }

        public static INavigatorAction New(Action callback)
        {
            return new DelegateAction(callback);
        }

        public static INavigatorAction New<T>(params object[] args)
            where T : INavigatorAction, new()
        {
            var type = typeof(T);

            return (INavigatorAction)Activator.CreateInstance(type, args);
        }

        public static INavigatorAction Dialog<TDialog, TResult>(object context)
            where TDialog : Window, new()
        {
            return new DelegateAction(async () =>
            {
                await Utils.ShowDialog<TResult, TDialog>(context);
            });
        }
    }
}