using Avalonia.Controls;
using ExPay_Service.Core.Navigation;
using System;

namespace ExPay.Core.Navigation.Actions
{
    internal class DelegateAction : INavigatorAction
    {
        public Window Parent { get; set; }

        Func<bool> canInvoke;

        public DelegateAction(Action action, Func<bool> canInvoke)
        {
            this.action = action;
            this.canInvoke = canInvoke;
        }

        public void Invoke()
        {
            action();
        }

        public bool CanInvoke()
        {
            return canInvoke();
        }

        private Action action;
    }
}