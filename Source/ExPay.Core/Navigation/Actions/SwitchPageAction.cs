using Avalonia.Controls;
using ExPay_Service.Core.Navigation;

namespace ExPay.Core.Navigation.Actions
{
    internal class SwitchPageAction : INavigatorAction
    {
        public Window Parent { get; set; }
        public SwitchPageAction(Control content)
        {
            this.content = content;
        }

        public void Invoke()
        {
            Navigator.Navigate(content);
        }

        private Control content;
    }
}