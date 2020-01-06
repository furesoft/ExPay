using System.Windows;

namespace ExPay_Service.Dialogs
{
    public partial class TestDialog : Window
    {
        public TestDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tag = 1;
            Close();
        }
    }
}