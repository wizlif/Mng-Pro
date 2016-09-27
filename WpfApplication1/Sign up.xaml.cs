using System.Windows;
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.IO;
using System.Diagnostics;

namespace WpfApplication1
{
    
    /// <summary>
    /// Interaction logic for Sign_up.xaml
    /// </summary>
    public partial class Sign_up : MetroWindow
    {
        public static string cs = "Server=localhost;Database=mpro;Uid=mis;Pwd=isaacobella;";
        MySqlConnection _conn = new MySqlConnection(cs);
        MySqlCommand _cmd;
        public Sign_up()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            (new Login()).Show();
            this.Close();
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            (new Settings()).ShowDialog();
        }

        private async void ButtonSignup_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxUsername.Text == "")
            {
                await this.ShowMessageAsync("Error", "Please insert a username");
            }
            else {
                if (PasswordBoxPassword.Password == PasswordBoxConfirmPassword.Password)
                {
                    if (PasswordBoxPassword.Password.Length > 8)
                    {
                        // MySQL Statement
                        string _Query = @"SELECT COUNT(*) FROM Accounts WHERE Username='" + TextBoxUsername.Text + "'";
                        _cmd = new MySqlCommand(_Query, _conn);

                        // Check If Account Exists

                        try
                        {
                            _conn.Open();
                            if (Convert.ToInt32(_cmd.ExecuteScalar()) > 0)
                            {
                                await this.ShowMessageAsync("Error", "Account Exists");
                            }
                            else
                            {
                                _conn.Close();

                                /// Create Account
                                NEW_ACCOUNT(ComboBoxAccount.Text, TextBoxUsername.Text, PasswordBoxPassword.Password);
                            }

                        }
                        catch (Exception)
                        {
                            await this.ShowMessageAsync("Error", "Server Errror check your server connection");
                        }
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "Password too short, It should exceed 8 chracters");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Passwords don't match");
                }
            }
        }

        public async void NEW_ACCOUNT(string _Account, string _Username, string _Password)
        {
            //// MySQL Statement
            //string _Query = @"INSERT INTO Accounts VALUES(NULL,'"+_Account+"','"+_Username+"','"+_Password+"')";
            //_cmd = new MySqlCommand(_Query, _conn);

            //// Open and Execute

            //try {
            //    _conn.Open();

            //    if (_cmd.ExecuteNonQuery() > 0)
            //    {
            //        await this.ShowMessageAsync("Sign up", "Account created successfully");

            //        (new NewEmployee()).Show();
            //    }

            //    _conn.Close();
            //}
            //catch (Exception)
            //{
            //    await this.ShowMessageAsync("Error", "Server Errror check your server connection");
            //}
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
    }
}
