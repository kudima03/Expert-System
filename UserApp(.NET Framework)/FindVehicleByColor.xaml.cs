using System;
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
    /// Логика взаимодействия для FindVehicleByColor.xaml
    /// </summary>
    public partial class FindVehicleByColor : Window
    {
        bool isEmpty = true;
        private IDataViewAccess module;
        public FindVehicleByColor(IDataViewAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void FindVehicle_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void VehicleColorInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                VehicleColorInput.Text = "";
                isEmpty = false;
            }
        }
    }
}
