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
    /// Interaction logic for vendors_databse.xaml
    /// </summary>
    public partial class Vendors_Databse : Window
    {
        public Vendors_Databse()
        {
            InitializeComponent();
        }

        private void VendorDatabasePage_Loaded(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).DataGridBinding("SELECT * FROM [Vendors]", "VendorsDatabase", DataGridVendorsDatabase);
        }
    }
}
