using System;
using System.Windows.Input;

namespace ExPay.Core.UI
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action<object> handler;

        public DelegateCommand(Action<object> handler)
        {
            this.handler = handler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            handler?.Invoke(parameter);
        }
    }
}