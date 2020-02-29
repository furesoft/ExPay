using Avalonia.Controls;
using ExPay_Service.Core.Navigation;
using System;

namespace ExPay.Core.Navigation.Actions
{
    internal class DelegateAction : INavigatorAction
    {
        public Window Parent { get; set; }

        public DelegateAction(Action action)
        {
            this.action = action;
        }

        public void Invoke()
        {
            action();
        }

        private Action action;
    }
}