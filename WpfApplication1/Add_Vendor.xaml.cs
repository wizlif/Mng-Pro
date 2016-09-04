using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Add_Vendor.xaml
    /// </summary>
    public partial class Add_Vendor : Window
    {
        public Add_Vendor()
        {
            InitializeComponent();
        }
        // Establishing Connection String from Configuration File
        string _ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        private void ButtonAddVendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection _Conn = new SqlConnection(_ConnectionString);

                // Open the Database Connection
                _Conn.Open();
                

                // Command String
                string _Insert = @"INSERT INTO Vendors VALUES('" + TextBoxVendorName.Text + "','" + TextBoxContact.Text + "','" + TextBoxAddress1.Text + "','" + TextBoxAddress2.Text + "','" + TextBoxCity.Text + "','" + TextBoxState.Text + "','" + TextBoxPostalCode.Text + "','" + TextBoxCountry.Text + "','" + TextBoxPhone1.Text + "','" + TextBoxPhone2.Text + "','" + TextBoxFax.Text + "','" + TextBoxEmail.Text + "','" + TextBoxLocation.Text + "','" + TextBoxType.Text + "','" + TextBoxWebsite.Text + "','" + TextBoxComments.Text +  "')";

                // Initialize the command query and connection
                SqlCommand _cmd = new SqlCommand(_Insert, _Conn);

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
            (new MainWindow()).DataGridBinding("SELECT [PO],CONVERT(VARCHAR,[Date],101) AS [Date],[Status],CONVERT(VARCHAR,[Date Required],101) AS [Date Required],CONVERT(VARCHAR,[Status Val],101) AS [Status Val] FROM [Purchase Order]", "POHistory", DataGridPOHistory);
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).DataGridBinding("SELECT * FROM [Work order]", "WOHistory", DataGridWOHistory);
        }
    }
}
