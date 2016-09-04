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
    /// Interaction logic for Parts_inventory_management.xaml
    /// </summary>
    public partial class Parts_inventory_management : Window
    {
        public Parts_inventory_management()
        {
            InitializeComponent();
        }

        private void ButtonAddNewPart_Click(object sender, RoutedEventArgs e)
        {
            (new Add_New_Part()).ShowDialog();
        }
    }
}
