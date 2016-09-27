using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows;
using MahApps.Metro.Controls;
using System.IO;
using System.Diagnostics;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Add_Vendor.xaml
    /// </summary>
    public partial class Add_Vendor : MetroWindow
    {
        public Add_Vendor()
        {
            InitializeComponent();
}
private void ButtonSettings_Click(object sender, RoutedEventArgs e)
{
(new Settings()).ShowDialog();
}
        // Establishing Connection String from Configuration File
        public static string cs = "Server="+GetServerAddress()+";Database=mpro;Uid=mis;Pwd=isaacobella;";
		MySqlConnection _Conn = new MySqlConnection(cs);
        public static string GetServerAddress()
        {
            string ipaddress = "";
            using (StreamReader reader = new StreamReader(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName).ToString() + "\\Settings.txt"))
            {
                ipaddress = reader.ReadLine();
            }
            return ipaddress;
        }
        private void ButtonAddVendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                // Open the Database Connection
                _Conn.Open();
                

                // Command String
                string _Insert = @"INSERT INTO Vendors VALUES('" + TextBoxVendorName.Text + "','" + TextBoxContact.Text + "','" + TextBoxAddress1.Text + "','" + TextBoxAddress2.Text + "','" + TextBoxCity.Text + "','" + TextBoxState.Text + "','" + TextBoxPostalCode.Text + "','" + TextBoxCountry.Text + "','" + TextBoxPhone1.Text + "','" + TextBoxPhone2.Text + "','" + TextBoxFax.Text + "','" + TextBoxEmail.Text + "','" + TextBoxLocation.Text + "','" + TextBoxType.Text + "','" + TextBoxWebsite.Text + "','" + TextBoxComments.Text +  "')";

                // Initialize the command query and connection
                MySqlCommand _cmd = new MySqlCommand(_Insert, _Conn);

                // Execute the command
                _cmd.ExecuteNonQuery();

                MessageBox.Show("Saved");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DataGridPOHistory_Loaded(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).DataGridBinding("SELECT `PO`,CONVERT(VARCHAR,`Date`,101) AS `Date`,`Status`,CONVERT(VARCHAR,`Date Required`,101) AS `Date Required`,CONVERT(VARCHAR,`Status Val`,101) AS `Status Val` FROM `Purchase Order`", "POHistory", DataGridPOHistory);
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).DataGridBinding("SELECT * FROM `Work order`", "WOHistory", DataGridWOHistory);
        }
    }
}
