using System;
using System.Collections.Generic;
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
    /// Interaction logic for PM_ckeck1.xaml
    /// </summary>
    public partial class PM_ckeck : MetroWindow
    {
        public PM_ckeck()
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

        private void ButtonPMCheckNext_Click(object sender, RoutedEventArgs e)
        {
            if (PMCheck1.Visibility == Visibility.Visible)
            {
                PMCheck1.Visibility = Visibility.Collapsed;
                PMCheck2.Visibility = Visibility.Visible;
                if (ButtonPMBack.IsEnabled == false)
                {
                    ButtonPMBack.IsEnabled = true;
                }
            }
            else if(PMCheck2.Visibility == Visibility.Visible)
            {
                PMCheck2.Visibility = Visibility.Collapsed;
                PMCheck3.Visibility = Visibility.Visible;
                if (ButtonPMBack.IsEnabled == false)
                {
                    ButtonPMBack.IsEnabled = true;
                }
            }
            else if (PMCheck3.Visibility == Visibility.Visible)
            {
                PMCheck3.Visibility = Visibility.Collapsed;
                PMCheck4.Visibility = Visibility.Visible;
                ButtonPMCheckNext.IsEnabled = false;
            }
        }

        private void ButtonPMBack_Click(object sender, RoutedEventArgs e)
        {
            
            if (PMCheck2.Visibility == Visibility.Visible)
            {
                PMCheck2.Visibility = Visibility.Collapsed;
                PMCheck1.Visibility = Visibility.Visible;
                ButtonPMBack.IsEnabled = false;
            }
            else if (PMCheck3.Visibility == Visibility.Visible)
            {
                PMCheck3.Visibility = Visibility.Collapsed;
                PMCheck2.Visibility = Visibility.Visible;
                if (ButtonPMCheckNext.IsEnabled == false)
                {
                    ButtonPMCheckNext.IsEnabled = true;
                }
            }
            else if (PMCheck4.Visibility == Visibility.Visible)
            {
                PMCheck4.Visibility = Visibility.Collapsed;
                PMCheck3.Visibility = Visibility.Visible;
                if (ButtonPMCheckNext.IsEnabled == false)
                {
                    ButtonPMCheckNext.IsEnabled = true;
                }
            }
        }
    }
}
