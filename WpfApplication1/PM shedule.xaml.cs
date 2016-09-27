using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using System.IO;
using System.Diagnostics;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for PM_shedule.xaml
    /// </summary>
    public partial class PM_shedule : MetroWindow
    {
        public static string cs = "Server="+GetServerAddress()+";Database=mpro;Uid=mis;Pwd=isaacobella;";
		MySqlConnection _Conn = new MySqlConnection(cs);
        public PM_shedule()
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
        private void ButtonAddNewSchedule_Click(object sender, RoutedEventArgs e)
        {
            (new New_PM_schedule()).ShowDialog();
            ComboBoxSchedule_Loaded(this, e);
        }

        public void ComboPupulate(String query,String column, ComboBox cb)
        {
            cb.Items.Clear();
            try
            {
                // Open the Database Connection
                _Conn.Open();

                // Initialize the command query and connection
                MySqlCommand _cmd = new MySqlCommand(query, _Conn);

                MySqlDataReader _Reader = _cmd.ExecuteReader();
                while (_Reader.Read())
                {
                    cb.Items.Add(_Reader[column].ToString());
                }
                _Reader.Close();
                _Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ComboBoxSchedule_Loaded(object sender, RoutedEventArgs e)
        {
            ComboPupulate("SELECT * FROM Schedule", "Name", ComboBoxSchedule);
        }

        private void ButtonEditSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxSchedule.SelectedItem != null)
            {
                try
                {
                    

                    // Open the Database Connection
                    _Conn.Open();



                    // Command String
                    string _Select = @"SELECT * FROM Schedule WHERE `Name`='" + ComboBoxSchedule.SelectedItem.ToString() + "'";

                    // Initialize the command query and connection
                    MySqlCommand _cmd = new MySqlCommand(_Select, _Conn);
                    MySqlDataReader _reader = _cmd.ExecuteReader();
                    New_PM_schedule editSchedule = new New_PM_schedule();
                    while (_reader.Read())
                    {
                        editSchedule.TextBoxScheduleName.Text = _reader["Name"].ToString();
                        editSchedule.CheckBoxTrackByDate.IsChecked = Convert.ToBoolean(_reader["Track By Date"]);
                        editSchedule.CheckBoxTrackByFuel.IsChecked= Convert.ToBoolean(_reader["Track By Fuel"]);
                        editSchedule.CheckBoxTrackByMeterPrim.IsChecked = Convert.ToBoolean(_reader["Track By Meter Prim Check"]);
                        editSchedule.CheckBoxTrackByMeterSec.IsChecked = Convert.ToBoolean(_reader["Track By Meter Sec Check"]);
                        if (editSchedule.CheckBoxTrackByMeterPrim.IsChecked == true)
                        {
                            editSchedule.ComboBoxTrackByMeterPrim.IsEnabled = true;
                        }
                        if (editSchedule.CheckBoxTrackByMeterSec.IsChecked == true)
                        {
                            editSchedule.ComboBoxTrackByMeterSec.IsEnabled = true;
                        }
                        editSchedule.ComboBoxTrackByMeterPrim.SelectedValue =  _reader["Track By Meter Prim"].ToString();
                        editSchedule.ComboBoxTrackByMeterSec.SelectedValue= _reader["Track By Meter Sec"].ToString();
                    }
                    editSchedule.ShowDialog();
                }
                catch (Exception)
                {

                }
            }
        }

        private void ButtonDeleteSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxSchedule.SelectedItem != null)
            {
                try
                {
                    

                    // Open the Database Connection
                    _Conn.Open();



                    // Command String
                    string _DelCmd = @"DELETE FROM Schedule WHERE `Name`='" + ComboBoxSchedule.SelectedItem.ToString() + "'";

                    // Initialize the command query and connection
                    MySqlCommand _CmdDelete = new MySqlCommand(_DelCmd, _Conn);
                    // Execute the command
                    _CmdDelete.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                ComboPupulate("SELECT * FROM Schedule", "Name", ComboBoxSchedule);
            }
                }

        private void ButtonAddMService_Click(object sender, RoutedEventArgs e)
        {
            (new Add_pm_service()).ShowDialog();
        }
    }
}
