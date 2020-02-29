using Avalonia.Controls;

namespace ExPay_Service.Core.Navigation
{
    public interface INavigatorAction
    {
        Window Parent { get; set; }
        void Invoke();
    }
}