using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
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
    /// Interaction logic for New_Value.xaml
    /// </summary>
    public partial class New_Value : MetroWindow
    {
        public static string cs = "Server="+GetServerAddress()+";Database=mpro;Uid=mis;Pwd=isaacobella;";
		MySqlConnection _Conn = new MySqlConnection(cs);
        public string choice;
        public string value;
        public int option;
        public New_Value()
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
        private void ButtonAddNewPickList_Click(object sender, RoutedEventArgs e)
        {
            if (choice != null && option != 1)
            {
                try
                {
                    

                    // Open the Database Connection
                    _Conn.Open();


                    // Command String
                    string _Insert = @"INSERT INTO `" + choice + "` VALUES('" + TextBoxNewValue.Text + "')";

                    // Initialize the command query and connection
                    MySqlCommand _cmd = new MySqlCommand(_Insert, _Conn);

                    // Execute the command
                    _cmd.ExecuteNonQuery();
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(Pick_list_maintenance))
                        {
                            (window as Pick_list_maintenance).RefreshList();
                        }
                    }
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (option == 1)
            {
                try
                {
                    

                    // Open the Database Connection
                    _Conn.Open();


                    // Command String
                    string _Update = @"UPDATE `" + choice + "` SET `Value`='" + TextBoxNewValue.Text + "' WHERE `Value`='" + value + "'";

                    // Initialize the command query and connection
                    MySqlCommand _cmd = new MySqlCommand(_Update, _Conn);

                    // Execute the command
                    _cmd.ExecuteNonQuery();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(Pick_list_maintenance))
                        {
                            (window as Pick_list_maintenance).RefreshList();
                        }
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

