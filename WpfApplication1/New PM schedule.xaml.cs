using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for New_PM_schedule.xaml
    /// </summary>
    public partial class New_PM_schedule : Window
    {
        // Establishing Connection String from Configuration File
        string _ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public New_PM_schedule()
        {
            InitializeComponent();
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
                SqlConnection _Conn = new SqlConnection(_ConnectionString);

                // Open the Database Connection
                _Conn.Open();


                // Command String
                string _Select = @"SELECT COUNT(*) FROM Schedule WHERE [Name]='" + TextBoxScheduleName.Text + "'";

                // Initialize the command query and connection
                SqlCommand _cmd = new SqlCommand(_Select, _Conn);

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
                        SqlCommand _cmd1 = new SqlCommand(_Insert, _Conn);

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
