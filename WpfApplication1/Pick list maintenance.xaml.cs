using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Pick_list_maintenance.xaml
    /// </summary>
    public partial class Pick_list_maintenance : Window
    {
        public Pick_list_maintenance()
        {
            InitializeComponent();
        }
        // Establishing Connection String from Configuration File
        string _ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private void ButtonPickListMaintainanceAdd_Click(object sender, RoutedEventArgs e)
        {
            New_Value nv = new New_Value();
            switch (ComboBoxMaintenance.SelectedValue.ToString())
            {
                case "Colors":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Cost Center":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Destination":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Employee Categories":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Employee Certificates":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Employee Status":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Employee Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Equiment Usage Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Expiration Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Fleet Status":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Fluid Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Fuel Brand":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Fuel Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "General Expense Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Makes":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Models":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "PM Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Part Categories":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Part Manufacturers":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Payment Terms":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Repair Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Shipping Methods":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "State/Prov":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Units Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Vehicle/Equip Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Vendor Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Work Order Status":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Work Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
            }
            nv.ShowDialog();
        }


        private void ComboBoxMaintenance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }
        
        public void RefreshList()
        {
            ListBoxMainList.Items.Clear();
            try
            {
                SqlConnection _Conn = new SqlConnection(_ConnectionString);
                string query = "";
                // Open the Database Connection
                _Conn.Open();

                switch (ComboBoxMaintenance.SelectedValue.ToString())
                {
                    case "Colors":
                        query = "SELECT * FROM [Colors]";
                        break;
                    case "Cost Center":
                        query = "SELECT * FROM [Cost Center]";
                        break;
                    case "Destination":
                        query = "SELECT * FROM [Destination]";
                        break;
                    case "Employee Categories":
                        query = "SELECT * FROM [Employee Categories]";
                        break;
                    case "Employee Certificates":
                        query = "SELECT * FROM [Employee Certificates]";
                        break;
                    case "Employee Status":
                        query = "SELECT * FROM [Employee Status]";
                        break;
                    case "Employee Types":
                        query = "SELECT * FROM [Employee Types]";
                        break;
                    case "Equiment Usage Type":
                        query = "SELECT * FROM [Equiment Usage Type]";
                        break;
                    case "Expiration Type":
                        query = "SELECT * FROM [Expiration Type]";
                        break;
                    case "Fleet Status":
                        query = "SELECT * FROM [Fleet Status]";
                        break;
                    case "Fluid Types":
                        query = "SELECT * FROM [Fluid Types]";
                        break;
                    case "Fuel Brand":
                        query = "SELECT * FROM [Fuel Brand]";
                        break;
                    case "Fuel Type":
                        query = "SELECT * FROM [Fuel Type]";
                        break;
                    case "General Expense Types":
                        query = "SELECT * FROM [General Expense Types]";
                        break;
                    case "Makes":
                        query = "SELECT * FROM [Makes]";
                        break;
                    case "Models":
                        query = "SELECT * FROM [Models]";
                        break;
                    case "PM Types":
                        query = "SELECT * FROM [PM Types]";
                        break;
                    case "Part Categories":
                        query = "SELECT * FROM [Part Categories]";
                        break;
                    case "Part Manufacturers":
                        query = "SELECT * FROM [Part Manufacturers]";
                        break;
                    case "Payment Terms":
                        query = "SELECT * FROM [Payment Terms]";
                        break;
                    case "Repair Types":
                        query = "SELECT * FROM [Repair Types]";
                        break;
                    case "Shipping Methods":
                        query = "SELECT * FROM [Shipping Methods]";
                        break;
                    case "State/Prov":
                        query = "SELECT * FROM [State/Prov]";
                        break;
                    case "Units Type":
                        query = "SELECT * FROM [Units Type]";
                        break;
                    case "Vehicle/Equip Types":
                        query = "SELECT * FROM [Vehicle/Equip Types]";
                        break;
                    case "Vendor Type":
                        query = "SELECT * FROM [Vendor Type]";
                        break;
                    case "Work Order Status":
                        query = "SELECT * FROM [Work Order Status]";
                        break;
                    case "Work Type":
                        query = "SELECT * FROM [Work Type]";
                        break;
                }

                // Initialize the command query and connection
                SqlCommand _cmd = new SqlCommand(query, _Conn);

                SqlDataReader _Reader = _cmd.ExecuteReader();
                while (_Reader.Read())
                {
                    ListBoxMainList.Items.Add(_Reader["Value"].ToString());
                }
                _Reader.Close();
                _Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PKListMaintainance_Loaded(object sender, RoutedEventArgs e)
        {
            if (ComboBoxMaintenance.SelectedValue != null)
            {
                RefreshList();
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            New_Value nv = new New_Value();
            switch (ComboBoxMaintenance.SelectedValue.ToString())
            {
                case "Colors":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Cost Center":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Destination":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Employee Categories":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Employee Certificates":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Employee Status":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Employee Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Equiment Usage Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Expiration Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Fleet Status":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Fluid Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Fuel Brand":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Fuel Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "General Expense Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Makes":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Models":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "PM Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Part Categories":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Part Manufacturers":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Payment Terms":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Repair Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Shipping Methods":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "State/Prov":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Units Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Vehicle/Equip Types":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Vendor Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Work Order Status":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
                case "Work Type":
                    nv.choice = ComboBoxMaintenance.SelectedValue.ToString();
                    break;
            }
            nv.TextBoxNewValue.Text = ListBoxMainList.SelectedValue.ToString();
            nv.value= ListBoxMainList.SelectedValue.ToString();
            nv.option = 1;
            nv.ShowDialog();
        }
    }
}
