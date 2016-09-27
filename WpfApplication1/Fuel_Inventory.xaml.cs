using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Fuel_Inventory.xaml
    /// </summary>
    public partial class Fuel_Inventory : MetroWindow
    {
        public Fuel_Inventory()
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
            using (StreamReader reader = new StreamReader(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName).ToString() + "\\Settings.txt"))
            {
                ipaddress = reader.ReadLine();
            }
            return ipaddress;
        }
        private void TextBoxCapacity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("`^0-9`");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Add_New_Fuel_Tank_Click(object sender, RoutedEventArgs e)
        {
            Add_New_Fuel_Tank newFuelTank = new Add_New_Fuel_Tank();
            newFuelTank.ShowDialog();
        }
    }
}
