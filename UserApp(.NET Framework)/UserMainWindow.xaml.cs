﻿using System;
using System.Collections.Generic;
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
using TCPConnectionAPIClientModule_C_sharp_;
namespace UserApp_.NET_Framework_
{
    /// <summary>
    /// Логика взаимодействия для UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        private IClientAccess module;
        public UserMainWindow(IClientAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            module.PreviousRoom();
            MainWindow mainWindow = new MainWindow(module as ClientConnectionModule);
            mainWindow.Show();
            this.Close();
        }

        private void FindVehicle_Click(object sender, RoutedEventArgs e)
        {
            FindVehicle findVehicle = new FindVehicle(module);
            findVehicle.ShowDialog();
        }
    }
}
