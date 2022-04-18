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
    /// Логика взаимодействия для MainContentWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private IAdminAccess module;
        public AdminMainWindow(IAdminAccess module)
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
        private void BackToAuth_Click(object sender, RoutedEventArgs e)
        {
            module.PreviousRoom();
            MainWindow mainWindow = new MainWindow(module as ClientConnectionModule);
            mainWindow.Show();
            this.Close();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindUser_Click(object sender, RoutedEventArgs e)
        {
            FindUser findUser = new FindUser(module);
            findUser.ShowDialog();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser(module);
            addUser.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void AddExpert_Click(object sender, RoutedEventArgs e)
        {
            AddExpert addExpert = new AddExpert(module);
            addExpert.ShowDialog();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            EditUser editUser = new EditUser(module);
            editUser.ShowDialog();
        }

        private void BlockUser_Click(object sender, RoutedEventArgs e)
        {
            BlockUser blockUser = new BlockUser(module);
            blockUser.ShowDialog();
        }

        private void UnblockUser_Click(object sender, RoutedEventArgs e)
        {
            UnblockUser unblockUser = new UnblockUser(module);
            unblockUser.ShowDialog();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser deleteUser = new DeleteUser(module);
            deleteUser.ShowDialog();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVehicle = new AddVehicle(module);
            addVehicle.ShowDialog();
        }

        private void BlockExpert_Click(object sender, RoutedEventArgs e)
        {
            BlockExpert blockExpert = new BlockExpert(module);
            blockExpert.ShowDialog();
        }

        private void UnblockExpert_Click(object sender, RoutedEventArgs e)
        {
            UnblockExpert unblockExpert = new UnblockExpert(module);
            unblockExpert.ShowDialog();
        }

        private void EditVehicle_Click(object sender, RoutedEventArgs e)
        {
            EditVehicle editVehicle = new EditVehicle(module);
            editVehicle.ShowDialog();
        }

        private void DeleteVehicle_Click(object sender, RoutedEventArgs e)
        {
            DeleteVehicle deleteVehicle = new DeleteVehicle(module);
            deleteVehicle.ShowDialog();
        }

        private void FindVehicleWithColour_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByColor findVehicleByColor = new FindVehicleByColor(module);
            findVehicleByColor.ShowDialog();
        }

        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            AddAdmin addAdmin = new AddAdmin(module);
            addAdmin.ShowDialog();
        }

        private void BlockAdmin_Click(object sender, RoutedEventArgs e)
        {
            BlockAdmin blockAdmin = new BlockAdmin(module);
            blockAdmin.ShowDialog();
        }

        private void UnblockAdmin_Click(object sender, RoutedEventArgs e)
        {
            UnblockAdmin unblockAdmin = new UnblockAdmin(module);
            unblockAdmin.ShowDialog();
        }

        private void DeleteAdmin_Click(object sender, RoutedEventArgs e)
        {
            DeleteAdmin deleteAdmin = new DeleteAdmin(module);
            deleteAdmin.ShowDialog();
        }

        private void DeleteExpert_Click(object sender, RoutedEventArgs e)
        {
            DeleteExpert deleteExpert = new DeleteExpert(module);
            deleteExpert.ShowDialog();
        }

        private void FindVehicleWithDealer_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByDealer findVehicleByDealer = new FindVehicleByDealer(module);
            findVehicleByDealer.ShowDialog();
        }

        private void FindVehicleWithModel_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByModel findVehicleByModel = new FindVehicleByModel(module);
            findVehicleByModel.ShowDialog();
        }

        private void FindVehicleWithRegistrationNumber_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByRegistrationNumber findVehicleByNumber = new FindVehicleByRegistrationNumber(module);
            findVehicleByNumber.ShowDialog();
        }

        private void FindVehicleWithTotalRate_Click(object sender, RoutedEventArgs e)
        {
            FindVehicleByTotalRating findVehicleByTotalRating = new FindVehicleByTotalRating(module);
            findVehicleByTotalRating.ShowDialog();
        }

        private void FindExpert_Click(object sender, RoutedEventArgs e)
        {
            FindExpert findExpert = new FindExpert(module);
            findExpert.ShowDialog();
        }

        private void FindAdmin_Click(object sender, RoutedEventArgs e)
        {
            FindAdmin findAdmin = new FindAdmin(module);
            findAdmin.ShowDialog();
        }
    }
}
