using Avalonia.Controls;
using ExPay_Service.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExPay.Core.Navigation.Actions
{
    class SwitchPageAction : INavigatorAction
    {
        Control content;

        public SwitchPageAction(Control content)
        {
            this.content = content;
        }

        public void Invoke()
        {
            Navigator.Navigate(content);
        }
    }
}