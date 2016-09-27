using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Work_order_management.xaml
    /// </summary>
    public partial class Work_order_management : MetroWindow
    {
        public Work_order_management()
        {
            InitializeComponent();
}
private void ButtonSettings_Click(object sender, RoutedEventArgs e)
{
(new Settings()).ShowDialog();
}
        public static string GetServerAddress()
        {
            string ipaddress = "";
            using (StreamReader reader = new StreamReader(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName).ToString() + "\\Settings.txt"))
            {
                ipaddress = reader.ReadLine();
            }
            return ipaddress;
        }
        private void WorkOrderManagement_Loaded(object sender, RoutedEventArgs e)
        {
            (new PM_shedule()).ComboPupulate("SELECT * FROM `Work Order Status`","Value",ComboBoxWOStatus);
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            //if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            //{
            //    Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
            //    // sizing of the element.
            //    DataGridWorOrderManagement.Measure(pageSize);
            //    DataGridWorOrderManagement.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
            //    Printdlg.PrintVisual(DataGridWorOrderManagement, Title);
            //}
        }
    }
}
