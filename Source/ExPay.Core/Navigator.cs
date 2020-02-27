using Avalonia.Controls;
using System.Collections.Generic;

namespace ExPay_Service.Core
{
    public static class Navigator
    {
        private static ContentControl _frame;

        public static int PageIndex = 0;
        public static List<Control> Pages = new List<Control>();

        public static void Forward()
        {
            if (PageIndex < Pages.Count - 1)
            {
                PageIndex++;

                Navigate(Pages[PageIndex]);
            }
        }

        public static void Init(ContentControl frame, Control defaultContent = null)
        {
            if (frame is null)
            {
                throw new System.ArgumentNullException(nameof(frame));
            }

            _frame = frame;

            if (defaultContent != null)
            {
                _frame.Content = defaultContent;

                Pages.Add(defaultContent);
            }
        }

        public static void Navigate(Control control)
        {
            _frame.Content = control;

            PageIndex++;
        }
    }
}