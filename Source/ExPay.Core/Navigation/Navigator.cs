using Avalonia.Controls;
using ExPay.Core.Navigation;
using System.Collections.Generic;

namespace ExPay_Service.Core.Navigation
{
    public static class Navigator
    {
        private static ContentControl _frame;

        public static int PageIndex = 0;
        public static List<INavigatorAction> Pages = new List<INavigatorAction>();
        private static Window _parent;

        public static void Forward()
        {
            if (PageIndex < Pages.Count - 1)
            {
                PageIndex++;

                Pages[PageIndex].Invoke();
            }
        }

        public static Window GetParent() => _parent;

        public static void SetResult(object result)
        {
            _parent.Tag = result;
            _parent.Close();
        }

        public static void Init(Window parent, ContentControl frame, Control defaultContent = null)
        {
            if (frame is null)
            {
                throw new System.ArgumentNullException(nameof(frame));
            }

            _frame = frame;

            if (defaultContent != null)
            {
                _frame.Content = defaultContent;

                Pages.Add(NavigatorAction.SwitchPage(defaultContent));
            }

            _parent = parent;
        }

        public static void Navigate(Control control)
        {
            _frame.Content = control;

            PageIndex++;
        }
    }
}