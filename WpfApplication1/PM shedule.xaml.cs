using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for PM_shedule.xaml
    /// </summary>
    public partial class PM_shedule : Window
    {
        string _ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public PM_shedule()
        {
            InitializeComponent();
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
                SqlConnection _Conn = new SqlConnection(_ConnectionString);

                // Open the Database Connection
                _Conn.Open();

                // Initialize the command query and connection
                SqlCommand _cmd = new SqlCommand(query, _Conn);

                SqlDataReader _Reader = _cmd.ExecuteReader();
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
                    SqlConnection _Conn = new SqlConnection(_ConnectionString);

                    // Open the Database Connection
                    _Conn.Open();



                    // Command String
                    string _Select = @"SELECT * FROM Schedule WHERE [Name]='" + ComboBoxSchedule.SelectedItem.ToString() + "'";

                    // Initialize the command query and connection
                    SqlCommand _cmd = new SqlCommand(_Select, _Conn);
                    SqlDataReader _reader = _cmd.ExecuteReader();
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
                catch (SqlException ex)
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
                    SqlConnection _Conn = new SqlConnection(_ConnectionString);

                    // Open the Database Connection
                    _Conn.Open();



                    // Command String
                    string _DelCmd = @"DELETE FROM Schedule WHERE [Name]='" + ComboBoxSchedule.SelectedItem.ToString() + "'";

                    // Initialize the command query and connection
                    SqlCommand _CmdDelete = new SqlCommand(_DelCmd, _Conn);
                    // Execute the command
                    _CmdDelete.ExecuteNonQuery();
                }
                catch (SqlException ex)
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
