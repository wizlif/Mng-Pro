﻿using System;
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
    /// Interaction logic for Purchase_order_parts_received.xaml
    /// </summary>
    public partial class Purchase_order_parts_received : MetroWindow
    {
        public Purchase_order_parts_received()
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
    }
}
