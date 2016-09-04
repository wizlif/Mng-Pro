using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Windows.Controls.Ribbon;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        // Establishing Connection String from Configuration File
        string _ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public String operation = "0";
        public Add()
        {
            InitializeComponent();

        }      

        

        private void LabelCustomField_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            (new Add_Customer()).ShowDialog();
        }

        private void ButtonAddMaintSched_Click(object sender, RoutedEventArgs e)
        {
            (new PM_shedule()).ShowDialog();
            TextBoxMaintSched_Loaded(this, e);
        }

        private void ButtonAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            (new Add_New_Emloyee()).ShowDialog();
        }

        private void buttonAddNewEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "0")
            {
                try
                {
                    SqlConnection _Conn = new SqlConnection(_ConnectionString);

                    // Open the Database Connection
                    _Conn.Open();

                    string _Date = TextBoxBaseDate.DisplayDate.ToShortDateString();

                    // Command String
                    string _Insert = @"INSERT INTO Equipment VALUES('" + TextBoxEquipmentNo.Text + "','" + TextBoxDescription.Text + "','" + TextBoxYear.Text + "','" + TextBoxMake.Text + "','" + TextBoxModel.Text + "','" + TextBoxSerial.Text + "','" + TextBoxType.Text + "','" + TextBoxColor.Text + "','" + TextBoxIdentification.Text + "','" + TextBoxStatus.Text + "','" + TextBoxOwnership.Text + "','" + TextBoxCustomer.Text + "','" + TextBoxJobSite.Text + "','" + TextBoxRecipients.Text + "','" + TextBoxMaintSched.Text + "','" + TextBoxNoMeter.Text + "','" + TextBoxBaseMeter.Text + "','" + TextBoxBaseDate.Text + "','" + TextBoxAssignTo.Text + "','" + TextBoxCostCenter.Text + "','" + TextBoxParent.Text + "','" + TextBoxCategory.Text + "','" + TextBoxCustom1.Text + "','" + TextBoxCustom2.Text + "','" + TextBoxCustom3.Text + "','" + TextBoxCustom4.Text + "','" + TextBoxCustom5.Text + "','" + TextBoxCustom6.Text + "','" + TextBoxCustom7.Text + "')";

                    // Initialize the command query and connection
                    SqlCommand _cmd = new SqlCommand(_Insert, _Conn);

                    // Execute the command
                    _cmd.ExecuteNonQuery();

                    MessageBox.Show("Saved");
                    TextBoxEquipmentNo.Text = string.Empty;
                    TextBoxDescription.Text = string.Empty;
                    TextBoxYear.Text = string.Empty;
                    TextBoxMake.Text = string.Empty;
                    TextBoxModel.Text = string.Empty;
                    TextBoxSerial.Text = string.Empty;
                    TextBoxType.Text = string.Empty;
                    TextBoxColor.Text = string.Empty;
                    TextBoxIdentification.Text = string.Empty;
                    TextBoxStatus.Text = string.Empty;
                    TextBoxOwnership.Text = string.Empty;
                    TextBoxCustomer.Text = string.Empty;
                    TextBoxJobSite.Text = string.Empty;
                    TextBoxRecipients.Text = string.Empty;
                    TextBoxMaintSched.Text = string.Empty;
                    TextBoxNoMeter.Text = string.Empty;
                    TextBoxBaseMeter.Text = string.Empty;
                    TextBoxBaseDate.Text = string.Empty;
                    TextBoxAssignTo.Text = string.Empty;
                    TextBoxCostCenter.Text = string.Empty;
                    TextBoxParent.Text = string.Empty;
                    TextBoxCategory.Text = string.Empty;
                    TextBoxCustom1.Text = string.Empty;
                    TextBoxCustom2.Text = string.Empty;
                    TextBoxCustom3.Text = string.Empty;
                    TextBoxCustom4.Text = string.Empty;
                    TextBoxCustom5.Text = string.Empty;
                    TextBoxCustom6.Text = string.Empty;
                    TextBoxCustom7.Text = string.Empty;

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).BindGrid();
                        }
                    }
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    SqlConnection _Conn = new SqlConnection(_ConnectionString);

                    // Open the Database Connection
                    _Conn.Open();

                    string _Date = TextBoxBaseDate.DisplayDate.ToShortDateString();

                    // Command String
                    string _Update = @"UPDATE Equipment SET [Description]='" + TextBoxDescription.Text + "',[Year]='" + TextBoxYear.Text + "',[Make]='" + TextBoxMake.Text + "',[Model]='" + TextBoxModel.Text + "',[Serial no]='" + TextBoxSerial.Text + "',[Type]='" + TextBoxType.Text + "',[Color]='" + TextBoxColor.Text + "',[Identification]='" + TextBoxIdentification.Text + "',[Status]='" + TextBoxStatus.Text + "',[Ownership]='" + TextBoxOwnership.Text + "',[Customer]='" + TextBoxCustomer.Text + "',[Job site]='" + TextBoxJobSite.Text + "',[Email Recipients]='" + TextBoxRecipients.Text + "',[Maint schedule]='" + TextBoxMaintSched.Text + "',[No Meter]='" + TextBoxNoMeter.Text + "',[Base meter]='" + TextBoxBaseMeter.Text + "',[Base date]='" + TextBoxBaseDate.Text + "',[Assigned to]='" + TextBoxAssignTo.Text + "',[Cost Center]='" + TextBoxCostCenter.Text + "',[Parent]='" + TextBoxParent.Text + "',[Category]='" + TextBoxCategory.Text + "',[Custom1]='" + TextBoxCustom1.Text + "',[Custom2]='" + TextBoxCustom2.Text + "',[Custom3]='" + TextBoxCustom3.Text + "',[Custom4]='" + TextBoxCustom4.Text + "',[Custom5]='" + TextBoxCustom5.Text + "',[Custom6]='" + TextBoxCustom6.Text + "',[Custom7]='" + TextBoxCustom7.Text + "' WHERE [Equipment no]='" + TextBoxEquipmentNo.Text + "'";

                    // Initialize the command query and connection
                    SqlCommand _cmd = new SqlCommand(_Update, _Conn);

                    // Execute the command
                    _cmd.ExecuteNonQuery();

                    MessageBox.Show("Saved");
                    TextBoxEquipmentNo.Text = string.Empty;
                    TextBoxDescription.Text = string.Empty;
                    TextBoxYear.Text = string.Empty;
                    TextBoxMake.Text = string.Empty;
                    TextBoxModel.Text = string.Empty;
                    TextBoxSerial.Text = string.Empty;
                    TextBoxType.Text = string.Empty;
                    TextBoxColor.Text = string.Empty;
                    TextBoxIdentification.Text = string.Empty;
                    TextBoxStatus.Text = string.Empty;
                    TextBoxOwnership.Text = string.Empty;
                    TextBoxCustomer.Text = string.Empty;
                    TextBoxJobSite.Text = string.Empty;
                    TextBoxRecipients.Text = string.Empty;
                    TextBoxMaintSched.Text = string.Empty;
                    TextBoxNoMeter.Text = string.Empty;
                    TextBoxBaseMeter.Text = string.Empty;
                    TextBoxBaseDate.Text = string.Empty;
                    TextBoxAssignTo.Text = string.Empty;
                    TextBoxCostCenter.Text = string.Empty;
                    TextBoxParent.Text = string.Empty;
                    TextBoxCategory.Text = string.Empty;
                    TextBoxCustom1.Text = string.Empty;
                    TextBoxCustom2.Text = string.Empty;
                    TextBoxCustom3.Text = string.Empty;
                    TextBoxCustom4.Text = string.Empty;
                    TextBoxCustom5.Text = string.Empty;
                    TextBoxCustom6.Text = string.Empty;
                    TextBoxCustom7.Text = string.Empty;

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).BindGrid();
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

        private void ButtonAddVendor_Click(object sender, RoutedEventArgs e)
        {
            Add_Vendor addVendor = new Add_Vendor();
            addVendor.ShowDialog();
        }

        private void TextBoxMaintSched_Loaded(object sender, RoutedEventArgs e)
        {
            (new PM_shedule()).ComboPupulate("SELECT * FROM Schedule", "Name", TextBoxMaintSched);
        }
    }
}
