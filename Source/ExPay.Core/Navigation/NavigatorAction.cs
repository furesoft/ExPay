using Avalonia.Controls;
using ExPay.Core.Navigation.Actions;
using ExPay_Service.Core.Navigation;
using System;

namespace ExPay.Core.Navigation
{
    public static class NavigatorAction
    {
        public static INavigatorAction Dialog<TDialog, TResult>(object context)
            where TDialog : Window, new()
        {
            return new DelegateAction(async () =>
            {
                await Utils.ShowDialog<TResult, TDialog>(context);
            });
        }

        public static INavigatorAction Finish(object result)
        {
            return new FinishAction(result);
        }

        public static INavigatorAction New(Action callback, Func<bool> canInvoke = null)
        {
            return new DelegateAction(callback, canInvoke);
        }

        public static INavigatorAction New<T>(params object[] args)
            where T : INavigatorAction, new()
        {
            var type = typeof(T);

            return (INavigatorAction)Activator.CreateInstance(type, args);
        }

        public static INavigatorAction SwitchPage(Control defaultContent, Func<bool> canInvoke = null)
        {
            return new SwitchPageAction(defaultContent, canInvoke);
        }
    }
}