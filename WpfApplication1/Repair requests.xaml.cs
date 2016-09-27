using System.Windows;
using MahApps.Metro.Controls;
using System.Diagnostics;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Repair_requests.xaml
    /// </summary>
    public partial class Repair_requests : MetroWindow
    {
        public Repair_requests()
        {
            InitializeComponent();
}
private void ButtonSettings_Click(object sender, RoutedEventArgs e)
{
(new Settings()).ShowDialog();
}

        private void Btnrequestedby_Click(object sender, RoutedEventArgs e)
        {
            (new Add_employee()).ShowDialog();
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
    }
}
