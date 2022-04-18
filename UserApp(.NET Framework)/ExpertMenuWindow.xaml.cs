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
    /// Логика взаимодействия для ExpertMenu.xaml
    /// </summary>
    public partial class ExpertMenu : Window
    {
        private IExpertAccess module;
        public ExpertMenu(IExpertAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            module.PreviousRoom();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVehicle = new AddVehicle(module as ClientConnectionModule);
            addVehicle.ShowDialog();
        }

        private void EditVehicle_Click(object sender, RoutedEventArgs e)
        {
            EditVehicle editVehicle = new EditVehicle(module as ClientConnectionModule);
            editVehicle.ShowDialog();
        }

        private void DeleteVehicle_Click(object sender, RoutedEventArgs e)
        {
            DeleteVehicle deleteVehicle = new DeleteVehicle(module as ClientConnectionModule);
            deleteVehicle.ShowDialog();
        }

        private void FindVehicleWithColour_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByColor findVehicleByColor = new FindVehicleByColor(module as ClientConnectionModule);
            findVehicleByColor.ShowDialog();
        }

        private void FindVehicleWithDealer_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByDealer findVehicleByDealer = new FindVehicleByDealer(module as ClientConnectionModule);
            findVehicleByDealer.ShowDialog();
        }

        private void FindVehicleWithModel_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByModel findVehicleByModel = new FindVehicleByModel(module as ClientConnectionModule);
            findVehicleByModel.ShowDialog();
        }

        private void FindVehicleWithRegistrationNumber_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByRegistrationNumber findVehicleByRegistrationNumber = new FindVehicleByRegistrationNumber(module as ClientConnectionModule);
            findVehicleByRegistrationNumber.ShowDialog();
        }

        private void FindVehicleWithTotalRate_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByTotalRating findVehicleByTotalRating = new FindVehicleByTotalRating(module as ClientConnectionModule);
            findVehicleByTotalRating.ShowDialog();
        }
    }
}
