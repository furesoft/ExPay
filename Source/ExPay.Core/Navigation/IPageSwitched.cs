using Avalonia.Controls;

namespace ExPay.Core.Navigation
{
    public interface IPageSwitched
    {
        void OnPageSwitched(Control newPage);
    }
}