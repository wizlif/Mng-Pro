using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        //String cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Employee.mdf;Integrated Security = True; Connect Timeout = 30";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Establishing Connection String from Configuration File
        string _ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public void DataGridBinding(String query, String binding, DataGrid datagrid)
        {
            try {
                SqlConnection _Conn = new SqlConnection(_ConnectionString);

                // Open the Database Connection
                _Conn.Open();

                SqlDataAdapter _Adapter = new SqlDataAdapter(query, _Conn);

                DataSet _Bind = new DataSet();
                _Adapter.Fill(_Bind, binding);


                datagrid.DataContext = _Bind;

                // Close the Database Connection
                _Conn.Close();
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void BindGrid()
        {
            DataGridBinding("Select * from Equipment", "EquipmentBinding", MainPageEquipmentDatagrid);
            DataGridBinding("Select * from [Work order]", "OpenWorkOrderBinding", MainPageOpenWorkOrdersDatagrid);
            DataGridBinding("Select * from Parts", "InventoryLowStockBinding", MainPageDataDataInventoryLowStockgrid);
            DataGridBinding("SELECT [Employee id],[Expir Name],[Expir Issued],[Expir Expires],[Expr Notes],CONCAT([First Name],' ',[MI],' ',[Last Name]) AS Name FROM Employee", "EmployeeRenewalsBind", MainPageEmployeeRenewalsagrid);
            DataGridBinding("SELECT * FROM Invoice", "OpenInvoicesBind", MainPageOpenInvoicesDatagrid);
            DataGridBinding("SELECT * FROM [Purchase Order]", "OpenPSsBind", MainPageOpenPSsDatagrid);
        }



        private void Record_Fuel_Click(object sender, RoutedEventArgs e)
        {
            Add_Fuel_Entry fuelEntry = new Add_Fuel_Entry();
            fuelEntry.ShowDialog();
        }

        private void Generate_Invoice_Click(object sender, RoutedEventArgs e)
        {
            Add_Invoice addInvoice = new Add_Invoice();
            addInvoice.ShowDialog();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            BindGrid();
        }

        private void RibbonButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }

        private void RibbonButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MainPageEquipmentDatagrid.SelectedValue != null)
            {
                DataRowView drv = (DataRowView)MainPageEquipmentDatagrid.SelectedItem;
                String res = (drv["Equipment no"]).ToString();
                MessageBox.Show("You have chosen to permanently delete item with unit "+res+", All data will be lost Are you sure?");
                try
                {
                    SqlConnection _conn = new SqlConnection(_ConnectionString);

                    // Open Database Connection
                    _conn.Open();

                    // Command String
                    string _DelCmd = @"Delete from Equipment
                              Where [Equipment no]='" + res + "'";

                    // Initialize the command query and connection
                    SqlCommand _CmdDelete = new SqlCommand(_DelCmd, _conn);

                    // Execute the command
                    _CmdDelete.ExecuteNonQuery();

                    this.BindGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {

            }
        }

        private void RibbonButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RibbonButtonServiceAssociationsConfiguration_Click(object sender, RoutedEventArgs e)
        {
            Service_associations serviceAssoc = new Service_associations();
            serviceAssoc.ShowDialog();
        }

        private void RibbonButtonEmployeeManagement_Click(object sender, RoutedEventArgs e)
        {
            (new EmployManagement()).ShowDialog();
        }

        private void RibbonButtonCustomerDatabase_Click(object sender, RoutedEventArgs e)
        {
            (new CustomerDatabase()).ShowDialog();
        }

        private void RibbonButtonVendorsDatabase_Click(object sender, RoutedEventArgs e)
        {
            (new Vendors_Databse()).ShowDialog();
        }



        private void RibbonMenuItemGenerateWorkOrders_Click(object sender, RoutedEventArgs e)
        {
            (new Generate_Work_Orders()).ShowDialog();
        }

        private void RibbonMenuItemRepairRequests_Click(object sender, RoutedEventArgs e)
        {
            (new Repair_requests()).ShowDialog();
        }

        private void RibbonButtonInspection_Click(object sender, RoutedEventArgs e)
        {
            (new Inspections()).ShowDialog();
        }

        private void RibbonButtonCurrentMaintainanceStatus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RibbonMenuItemMaintainanceHistory_Click(object sender, RoutedEventArgs e)
        {
            (new Histories()).ShowDialog();
        }

        private void RibbonButtonLastPMSetup_Click(object sender, RoutedEventArgs e)
        {
            (new Last_Pm()).ShowDialog();
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            (new Meter_replacements()).ShowDialog();
        }

        private void RibbonMenuItemSelectedEquipment_Click(object sender, RoutedEventArgs e)
        {
            (new Generate_Work_Orders()).ShowDialog();
        }

        private void RibbonButtonWorOrderManagement_Click(object sender, RoutedEventArgs e)
        {
            (new Work_order_management()).ShowDialog();
        }

        private void RibbonButtonJobSiteHistory_Click(object sender, RoutedEventArgs e)
        {
            (new Job_Site_History()).ShowDialog();
        }

        private void RibbonButtonCostStatistics_Click(object sender, RoutedEventArgs e)
        {
            (new Cost_Statistics()).ShowDialog();
        }

        private void RibbonButtonEmailLog_Click(object sender, RoutedEventArgs e)
        {
            (new Email_Log()).ShowDialog();
        }

        private void RibbonButtonPartsInventoryListing_Click(object sender, RoutedEventArgs e)
        {
            (new Parts_inventory_management()).ShowDialog();
        }

        private void RibbonButtonPurchaseOrdersBrowse_Click(object sender, RoutedEventArgs e)
        {
            (new Purchase_order_browse()).ShowDialog();
        }

        private void RibbonButtonAdjustReceiveInentory_Click(object sender, RoutedEventArgs e)
        {
            (new Adjust_Inventory_Part()).ShowDialog();
        }

        private void RibbonButtonBrowseInvoices_Click(object sender, RoutedEventArgs e)
        {
            (new Invoice_Management()).ShowDialog();
        }

        private void RibbonButtonRecordPayment_Click(object sender, RoutedEventArgs e)
        {
            (new Add_Payment()).ShowDialog();
        }

        private void RibbonButtonBrowsePayments_Click(object sender, RoutedEventArgs e)
        {
            (new Payments_received()).ShowDialog();
        }

        private void RibbonMenuItemEquipAssignmentDetailedJobSite_Click(object sender, RoutedEventArgs e)
        {
            (new Report_Viewer()).ShowDialog();
        }

        private void ButtonIssueWO_Click(object sender, RoutedEventArgs e)
        {
            (new Generate_Work_Orders()).ShowDialog();
        }

        private void RibbonButtonFueInventory_Click(object sender, RoutedEventArgs e)
        {
            (new Fuel_Inventory()).ShowDialog();
        }

        private void RibbonButtonAddDuplicate_Click(object sender, RoutedEventArgs e)
        {
            if (MainPageEquipmentDatagrid.SelectedValue != null)
            {
                DataRowView drv = (DataRowView)MainPageEquipmentDatagrid.SelectedItem;
                String res = (drv["Equipment no"]).ToString();
                try
                {
                    SqlConnection _Conn = new SqlConnection(_ConnectionString);

                    // Open the Database Connection
                    _Conn.Open();



                    // Command String
                    string _Select = @"SELECT * FROM Equipment WHERE [Equipment no]='" + res + "'";

                    // Initialize the command query and connection
                    SqlCommand _cmd = new SqlCommand(_Select, _Conn);
                    SqlDataReader _reader = _cmd.ExecuteReader();
                    Add addDup = new Add();
                    while (_reader.Read())
                    {
                        addDup.TextBoxEquipmentNo.Text = _reader["Equipment no"].ToString();
                        addDup.TextBoxDescription.Text = _reader["Description"].ToString();
                        addDup.TextBoxYear.Text = _reader["Year"].ToString();
                        addDup.TextBoxMake.Text = _reader["Make"].ToString();
                        addDup.TextBoxModel.Text = _reader["Model"].ToString();
                        addDup.TextBoxSerial.Text = _reader["Serial no"].ToString();
                        addDup.TextBoxType.Text = _reader["Type"].ToString();
                        addDup.TextBoxColor.Text = _reader["Color"].ToString();
                        addDup.TextBoxIdentification.Text = _reader["Identification"].ToString();
                        addDup.TextBoxStatus.Text = _reader["Status"].ToString();
                        addDup.TextBoxOwnership.Text = _reader["Ownership"].ToString();
                        addDup.TextBoxCustomer.Text = _reader["Customer"].ToString();
                        addDup.TextBoxJobSite.Text = _reader["Job site"].ToString();
                        //addDup.TextBoxE.Text = _reader["Email recipients"].ToString();
                        addDup.TextBoxMaintSched.Text = _reader["Maint schedule"].ToString();
                        addDup.TextBoxNoMeter.Text = _reader["No meter"].ToString();
                        addDup.TextBoxBaseMeter.Text = _reader["Base meter"].ToString();
                        addDup.TextBoxBaseMeter.Text = _reader["Base date"].ToString();
                        //addDup.TextBoxAssignTo.Text = _reader["Assign to"].ToString();
                        addDup.TextBoxCostCenter.Text = _reader["Cost center"].ToString();
                        addDup.TextBoxParent.Text = _reader["Parent"].ToString();
                        addDup.TextBoxCategory.Text = _reader["Category"].ToString();
                        addDup.TextBoxCustom1.Text = _reader["Custom1"].ToString();
                        addDup.TextBoxCustom2.Text = _reader["Custom2"].ToString();
                        addDup.TextBoxCustom3.Text = _reader["Custom3"].ToString();
                        addDup.TextBoxCustom4.Text = _reader["Custom4"].ToString();
                        addDup.TextBoxCustom5.Text = _reader["Custom5"].ToString();
                        addDup.TextBoxCustom6.Text = _reader["Custom6"].ToString();
                        addDup.TextBoxCustom7.Text = _reader["Custom7"].ToString();
                    }
                    addDup.ShowDialog();
                }
                catch (SqlException ex)
                {

                }
            }
        }

        private void RibbonButtonUpdateMeterLogs_Click(object sender, RoutedEventArgs e)
        {
            (new Meter_update_log()).ShowDialog();
        }

        private void RibbonButtonUpdateMeterReadings_Click(object sender, RoutedEventArgs e)
        {
            //(new Meter_replacements()).ShowDialog();
        }

        private void RibbonButtonPurchaseOrdersAdd_Click(object sender, RoutedEventArgs e)
        {
            (new purchase_order_item()).ShowDialog();
        }

        private void RibbonButtonMeterReplacements_Click(object sender, RoutedEventArgs e)
        {
            (new Meter_replacements()).ShowDialog();
        }

        private void RibbonButtonBackupDatafiles_Click(object sender, RoutedEventArgs e)
        {
            (new Backup_datafiles()).ShowDialog();
        }

        private void RibbonButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            (new Add_category()).ShowDialog();
        }

        private void RibbonButtonRestoreDatafiles_Click(object sender, RoutedEventArgs e)
        {
            (new Restore_data_files()).ShowDialog();
        }

        private void RibbonButtonPMSchedule_Click(object sender, RoutedEventArgs e)
        {
            (new PM_shedule()).ShowDialog();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridBinding("SELECT [Equipment no],[Description] FROM [Equipment] WHERE [Equipment no] LIKE '%" + TextBoxSearch.Text + "%' OR [Description] LIKE '%" + TextBoxSearch.Text + "%'", "searchBind", dataGridSearch);
        }

        private void TextBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            dataGridSearch.Visibility = Visibility.Visible;
        }

        private void TextBoxSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (dataGridSearch.SelectedValue == null)
            {
                dataGridSearch.Visibility = Visibility.Collapsed;
                TextBoxSearch.Clear();
            }
            //else
            //{
            //    DataRowView drv = (DataRowView)dataGridSearch.SelectedItem;
            //    TextBoxSearch.Text = (drv["Unit #"]).ToString();
            //    dataGridSearch.Visibility = Visibility.Collapsed;
            //}

        }

        private void dataGridSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataRowView drv = (DataRowView)dataGridSearch.SelectedItem;
            //TextBoxSearch.Text = (drv["Equipment no"]).ToString();
            //dataGridSearch.Visibility = Visibility.Collapsed;
        }

        private void RibbonButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (MainPageEquipmentDatagrid.SelectedValue != null)
            {
                DataRowView drv = (DataRowView)MainPageEquipmentDatagrid.SelectedItem;
                String res = (drv["Equipment no"]).ToString();
                try
                {
                    SqlConnection _Conn = new SqlConnection(_ConnectionString);

                    // Open the Database Connection
                    _Conn.Open();



                    // Command String
                    string _Select = @"SELECT * FROM Equipment WHERE [Equipment no]='" + res + "'";

                    // Initialize the command query and connection
                    SqlCommand _cmd = new SqlCommand(_Select, _Conn);
                    SqlDataReader _reader = _cmd.ExecuteReader();
                    Add addDup = new Add();
                    while (_reader.Read())
                    {
                        addDup.TextBoxEquipmentNo.Text = _reader["Equipment no"].ToString();
                        addDup.TextBoxDescription.Text = _reader["Description"].ToString();
                        addDup.TextBoxYear.Text = _reader["Year"].ToString();
                        addDup.TextBoxMake.Text = _reader["Make"].ToString();
                        addDup.TextBoxModel.Text = _reader["Model"].ToString();
                        addDup.TextBoxSerial.Text = _reader["Serial no"].ToString();
                        addDup.TextBoxType.Text = _reader["Type"].ToString();
                        addDup.TextBoxColor.Text = _reader["Color"].ToString();
                        addDup.TextBoxIdentification.Text = _reader["Identification"].ToString();
                        addDup.TextBoxStatus.Text = _reader["Status"].ToString();
                        addDup.TextBoxOwnership.Text = _reader["Ownership"].ToString();
                        addDup.TextBoxCustomer.Text = _reader["Customer"].ToString();
                        addDup.TextBoxJobSite.Text = _reader["Job site"].ToString();
                        //addDup.TextBoxE.Text = _reader["Email recipients"].ToString();
                        addDup.TextBoxMaintSched.Text = _reader["Maint schedule"].ToString();
                        addDup.TextBoxNoMeter.Text = _reader["No meter"].ToString();
                        addDup.TextBoxBaseMeter.Text = _reader["Base meter"].ToString();
                        addDup.TextBoxBaseDate.Text = _reader["Base date"].ToString();
                        addDup.TextBoxAssignTo.Text = _reader["Assigned to"].ToString();
                        addDup.TextBoxCostCenter.Text = _reader["Cost center"].ToString();
                        addDup.TextBoxParent.Text = _reader["Parent"].ToString();
                        addDup.TextBoxCategory.Text = _reader["Category"].ToString();
                        addDup.TextBoxCustom1.Text = _reader["Custom1"].ToString();
                        addDup.TextBoxCustom2.Text = _reader["Custom2"].ToString();
                        addDup.TextBoxCustom3.Text = _reader["Custom3"].ToString();
                        addDup.TextBoxCustom4.Text = _reader["Custom4"].ToString();
                        addDup.TextBoxCustom5.Text = _reader["Custom5"].ToString();
                        addDup.TextBoxCustom6.Text = _reader["Custom6"].ToString();
                        addDup.TextBoxCustom7.Text = _reader["Custom7"].ToString();
                    }
                    addDup.TextBoxEquipmentNo.IsEnabled = false;
                    addDup.operation = "1";
                    addDup.ShowDialog();
                }
                catch (SqlException ex)
                {

                }
            }
        }

        private void RibbonMenuItemCostCenters_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Cost Center";
            pk.ShowDialog();
        }

        private void RibbonMenuItemCategories_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Employee Categories";
            pk.ShowDialog();
        }

        private void RibbonMenuItemExpirations_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Employee Certificates";
            pk.ShowDialog();
        }

        private void RibbonMenuItemStatus_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Employee Status";
            pk.ShowDialog();
        }

        private void RibbonMenuItemTypes_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Employee Types";
            pk.ShowDialog();
        }

        private void RibbonMenuItemExpirations1_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Expiration Type";
            pk.ShowDialog();
        }

        private void RibbonMenuItemMakes_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Makes";
            pk.ShowDialog();
        }

        private void RibbonMenuItemModels_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Models";
            pk.ShowDialog();
        }

        private void RibbonMenuItemTypes1_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Vehicle/Equip Types";
            pk.ShowDialog();
        }

        private void RibbonMenuItemColors_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Colors";
            pk.ShowDialog();
        }

        private void RibbonMenuItemStatus1_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Fleet Status";
            pk.ShowDialog();
        }

        private void RibbonMenuItemDestination_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Destination";
            pk.ShowDialog();
        }

        private void RibbonMenuItemType_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Equiment Usage Type";
            pk.ShowDialog();
        }

        private void RibbonMenuItemFluidTypes_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Fluid Types";
            pk.ShowDialog();
        }

        private void RibbonMenuItemUnitsType_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Units Type";
            pk.ShowDialog();
        }

        private void RibbonMenuItemFuelType_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Fuel Type";
            pk.ShowDialog();
        }

        private void RibbonMenuItemFuelBrand_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Fuel Brand";
            pk.ShowDialog();
        }

        private void RibbonMenuItemStateProv_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "State/Prov";
            pk.ShowDialog();
        }

        private void RibbonMenuItemGenerateExpenseTypes_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "General Expense Types";
            pk.ShowDialog();
        }

        private void RibbonMenuItemCommonRepairsList_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "";
            pk.ShowDialog();
        }

        private void RibbonMenuItemPMTypes_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "PM Types";
            pk.ShowDialog();
        }

        private void RibbonMenuItemRepairTypes_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Repair Types";
            pk.ShowDialog();
        }

        private void RibbonMenuItemPartCategories_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Part Categories";
            pk.ShowDialog();
        }

        private void RibbonMenuItemPartManufacturers_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Part Manufacturers";
            pk.ShowDialog();
        }

        private void RibbonMenuItemUnitsType1_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Units Type";
            pk.ShowDialog();
        }

        private void RibbonMenuItemWareHouse_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "";
            pk.ShowDialog();
        }

        private void RibbonMenuItemPaymentTerms_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Payment Terms";
            pk.ShowDialog();
        }

        private void RibbonMenuItemShipToAddress_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "";
            pk.ShowDialog();
        }

        private void RibbonMenuItemShippingMethods_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Shipping Methods";
            pk.ShowDialog();
        }

        private void RibbonMenuItemVendorType_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Vendor Type";
            pk.ShowDialog();
        }

        private void RibbonMenuItemWOStatus_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Work Order Status";
            pk.ShowDialog();
        }

        private void RibbonMenuItemWorTypes_Click(object sender, RoutedEventArgs e)
        {
            Pick_list_maintenance pk = new Pick_list_maintenance();
            pk.ComboBoxMaintenance.SelectedValue = "Work Type";
            pk.ShowDialog();
        }
    }
    }
