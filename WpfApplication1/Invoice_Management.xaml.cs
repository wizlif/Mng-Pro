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
    /// Interaction logic for Invoice_Management.xaml
    /// </summary>
    public partial class Invoice_Management : Window
    {
        public Invoice_Management()
        {
            InitializeComponent();
        }

        private void ButtonAddInvoice_Click(object sender, RoutedEventArgs e)
        {
            (new Add_Invoice()).ShowDialog();
        }

        private void ButtonEditInvoice_Click(object sender, RoutedEventArgs e)
        {
            (new Add_Invoice()).ShowDialog();
        }
    }
}
