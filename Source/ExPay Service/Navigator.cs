using Avalonia.Controls;

namespace ExPay_Service
{
    public static class Navigator
    {
        private static ContentControl _frame;

        public static void Init(ContentControl frame, object defaultContent = null)
        {
            if (frame is null)
            {
                throw new System.ArgumentNullException(nameof(frame));
            }

            _frame = frame;

            if (defaultContent != null)
            {
                _frame.Content = defaultContent;
            }
        }

        public static void Navigate(Control control)
        {
            _frame.Content = control;
        }
    }
}