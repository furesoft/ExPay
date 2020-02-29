using Avalonia.Controls;
using ExPay_Service.Core.Navigation;

namespace ExPay.Core.Navigation.Actions
{
    class FinishAction : INavigatorAction
    {
        private object result;

        public FinishAction(object result)
        {
            this.result = result;
        }

        public Window Parent { get; set; }

        public void Invoke()
        {
            var btn = Parent.FindControl<Button>("nextBtn");
            btn.Content = "Pay";

            btn.Click += (s, e) =>
            {
                Navigator.SetResult(result);
            };
        }
    }
}