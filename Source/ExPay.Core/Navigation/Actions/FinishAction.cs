using Avalonia.Controls;
using ExPay_Service.Core.Navigation;

namespace ExPay.Core.Navigation.Actions
{
    internal class FinishAction : INavigatorAction
    {
        public Window Parent { get; set; }

        public FinishAction(object result)
        {
            this.result = result;
        }

        public void Invoke()
        {
            var oldPage = Parent?.FindControl<ContentControl>("content").Content as IFinished;

            if (oldPage != null)
            {
                oldPage.OnFinish();
            }

            var btn = Parent?.FindControl<Button>("nextBtn");
            btn.Content = I18N._("Pay");

            btn.Click += (s, e) =>
            {
                Navigator.SetResult(result);
            };
        }

        private object result;
    }
}