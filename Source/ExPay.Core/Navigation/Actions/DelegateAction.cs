using Avalonia.Controls;
using ExPay_Service.Core.Navigation;
using System;

namespace ExPay.Core.Navigation.Actions
{
    internal class DelegateAction : INavigatorAction
    {
        public Window Parent { get; set; }

        public DelegateAction(Action action, Func<bool> canInvoke = null)
        {
            this.action = action;
            this.canInvoke = canInvoke;
        }

        public bool CanInvoke()
        {
            if (canInvoke != null)
                return canInvoke();
            return true;
        }

        public void Invoke()
        {
            action();
        }

        private Action action;
        private Func<bool> canInvoke;
    }
}