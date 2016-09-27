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
    /// Interaction logic for New_PM_schedule.xaml
    /// </summary>
    public partial class New_PM_schedule : MetroWindow
    {
        // Establishing Connection String from Configuration File
        public static string cs = "Server="+GetServerAddress()+";Database=mpro;Uid=mis;Pwd=isaacobella;";
		MySqlConnection _Conn = new MySqlConnection(cs);
        public New_PM_schedule()
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
        private void CheckBoxTrackByMeterPrim_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxTrackByMeterPrim.IsChecked == true)
            {
                ComboBoxTrackByMeterPrim.IsEnabled = true;
            }
            else
            {
                ComboBoxTrackByMeterPrim.IsEnabled = false;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                // Open the Database Connection
                _Conn.Open();


                // Command String
                string _Select = @"SELECT COUNT(*) FROM Schedule WHERE `Name`='" + TextBoxScheduleName.Text + "'";

                // Initialize the command query and connection
                MySqlCommand _cmd = new MySqlCommand(_Select, _Conn);

                if ((int)_cmd.ExecuteScalar() > 0)
                {
                    MessageBox.Show(TextBoxScheduleName.Text + " already exists");
                }
                else
                {

                    try
                    {
                        // Command String
                        string _Insert = @"INSERT INTO Schedule VALUES('" + TextBoxScheduleName.Text + "','" + CheckBoxTrackByDate.IsChecked.ToString() + "','" + CheckBoxTrackByFuel.IsChecked.ToString() + "','" + CheckBoxTrackByMeterPrim.IsChecked.ToString() + "','" + CheckBoxTrackByMeterSec.IsChecked.ToString() + "','" + ComboBoxTrackByMeterPrim.Text + "','" + ComboBoxTrackByMeterSec.Text + "')";

                        // Initialize the command query and connection
                        MySqlCommand _cmd1 = new MySqlCommand(_Insert, _Conn);

                        // Execute the command
                        _cmd1.ExecuteNonQuery();
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }

        private void CheckBoxTrackByMeterSec_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxTrackByMeterSec.IsChecked == true)
            {
                ComboBoxTrackByMeterSec.IsEnabled = true;
            }
            else
            {
                ComboBoxTrackByMeterSec.IsEnabled = false;
            }
        }
    }
}
