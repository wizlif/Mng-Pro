using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Generate_Work_Orders.xaml
    /// </summary>
    public partial class Generate_Work_Orders : Window
    {
        public Generate_Work_Orders()
        {
            InitializeComponent();
        }



        private void RadioButtonDateOnly_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxDateOnly.IsEnabled = true;
        }

        private void RadioButtonDateOnly_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxDateOnly.IsEnabled = false;
        }

        private void CheckBoxDateOnly_Checked(object sender, RoutedEventArgs e)
        {
            DatePickerFrom.IsEnabled = true;
            DatePickerTo.IsEnabled = true;
        }

        private void CheckBoxDateOnly_Unchecked(object sender, RoutedEventArgs e)
        {
            DatePickerFrom.IsEnabled = false;
            DatePickerTo.IsEnabled = false;
        }

        private void CheckBoxDue_Unchecked(object sender, RoutedEventArgs e)
        {
            GroupBoxTasks.IsEnabled = false;
        }

        private void CheckBoxDue_Checked(object sender, RoutedEventArgs e)
        {
            GroupBoxTasks.IsEnabled = true;
        }

        private void CheckBoxSelected_Checked(object sender, RoutedEventArgs e)
        {
            ListViewSelected.IsEnabled = true;
        }

        private void CheckBoxSelected_Unchecked(object sender, RoutedEventArgs e)
        {
            ListViewSelected.IsEnabled = false;
        }
    }
}
