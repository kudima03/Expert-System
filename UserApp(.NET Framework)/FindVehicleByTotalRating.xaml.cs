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
    /// Логика взаимодействия для FindVehicleByTotalRating.xaml
    /// </summary>
    public partial class FindVehicleByTotalRating : Window
    {
        bool isEmpty = true;
        private IAdminAccess module;
        public FindVehicleByTotalRating(IAdminAccess module)
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

        private void TotalRateInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                TotalRateInput.Text = "";
                isEmpty = false;
            }
        }
    }
}
