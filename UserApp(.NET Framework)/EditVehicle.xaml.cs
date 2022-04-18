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
    /// Логика взаимодействия для EditVehicle.xaml
    /// </summary>
    public partial class EditVehicle : Window
    {
        bool isEmpty = true;
        private IAdminAccess module;
        public EditVehicle(IAdminAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void SaveVehicle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindVehicle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegNumInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                RegNumInput.Text = "";
                isEmpty = false;
            }
        }
    }
}
