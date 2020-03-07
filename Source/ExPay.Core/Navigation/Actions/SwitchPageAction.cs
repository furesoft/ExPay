using Avalonia.Controls;
using ExPay_Service.Core.Navigation;
using System;

namespace ExPay.Core.Navigation.Actions
{
    internal class SwitchPageAction : INavigatorAction
    {
        public Window Parent { get; set; }

        public SwitchPageAction(Control content, Func<bool> canInvoke)
        {
            this.content = content;
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
            var oldPage = Parent.FindControl<ContentControl>("content").Content as IPageSwitched;

            if (oldPage != null)
            {
                oldPage.OnPageSwitched(content);
            }

            Navigator.Navigate(content);
        }

        private Func<bool> canInvoke;
        private Control content;
    }
}