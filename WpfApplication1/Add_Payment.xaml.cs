using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Add_Payment.xaml
    /// </summary>
    public partial class Add_Payment : Window
    {
        public Add_Payment()
        {
            InitializeComponent();
        }



        private void RadioButtonCreditCard_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCheck.IsEnabled = false;
            TextBoxCreditCard.IsEnabled = true;
            TextBoxNameOnCard.IsEnabled = true;
            TextBoxTransaction.IsEnabled = true;
            TextBoxOther.IsEnabled = false;

            ComboBoxExpirationMonth.IsEnabled = true;
            ComboBoxExpirationYear.IsEnabled = true;

            LabelNameOnCard.IsEnabled = true;
            LabelExpirationMonth.IsEnabled = true;
            LabelExpirationYear.IsEnabled = true;
            LabelTransaction.IsEnabled = true;
            
        }

        private void RadioButtonOther_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCheck.IsEnabled = false;
            TextBoxCreditCard.IsEnabled = false;
            TextBoxNameOnCard.IsEnabled = false;
            TextBoxTransaction.IsEnabled = false;
            TextBoxOther.IsEnabled = true;

            ComboBoxExpirationMonth.IsEnabled = false;
            ComboBoxExpirationYear.IsEnabled = false;

            LabelNameOnCard.IsEnabled = false;
            LabelExpirationMonth.IsEnabled = false;
            LabelExpirationYear.IsEnabled = false;
            LabelTransaction.IsEnabled = false;
        }

        private void RadioButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCheck.IsEnabled = true;
            TextBoxCreditCard.IsEnabled = false;
            TextBoxNameOnCard.IsEnabled = false;
            TextBoxTransaction.IsEnabled = false;
            TextBoxOther.IsEnabled = false;

            ComboBoxExpirationMonth.IsEnabled = false;
            ComboBoxExpirationYear.IsEnabled = false;

            LabelNameOnCard.IsEnabled = false;
            LabelExpirationMonth.IsEnabled = false;
            LabelExpirationYear.IsEnabled = false;
            LabelTransaction.IsEnabled = false;
        }

    }
}
