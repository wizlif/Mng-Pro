using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Interaction logic for New_Value.xaml
    /// </summary>
    public partial class New_Value : Window
    {
        string _ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public string choice;
        public string value;
        public int option;
        public New_Value()
        {
            InitializeComponent();
        }

        private void ButtonAddNewPickList_Click(object sender, RoutedEventArgs e)
        {
            if (choice != null && option != 1)
            {
                try
                {
                    SqlConnection _Conn = new SqlConnection(_ConnectionString);

                    // Open the Database Connection
                    _Conn.Open();


                    // Command String
                    string _Insert = @"INSERT INTO [" + choice + "] VALUES('" + TextBoxNewValue.Text + "')";

                    // Initialize the command query and connection
                    SqlCommand _cmd = new SqlCommand(_Insert, _Conn);

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
                    SqlConnection _Conn = new SqlConnection(_ConnectionString);

                    // Open the Database Connection
                    _Conn.Open();


                    // Command String
                    string _Update = @"UPDATE [" + choice + "] SET [Value]='" + TextBoxNewValue.Text + "' WHERE [Value]='" + value + "'";

                    // Initialize the command query and connection
                    SqlCommand _cmd = new SqlCommand(_Update, _Conn);

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

