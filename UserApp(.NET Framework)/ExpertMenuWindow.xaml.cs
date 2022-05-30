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
            MainWindow mainWindow = new MainWindow(module as ClientConnectionModule);
            mainWindow.Show();
            this.Close();
        }   

        private void FindVehicle_Click(object sender, RoutedEventArgs e)
        {
            FindVehicle findVehicle = new FindVehicle(module);
            findVehicle.ShowDialog();
        }

        private void RateVehicle_Click(object sender, RoutedEventArgs e)
        {
            RateVehicle rateVehicle = new RateVehicle(module);
            rateVehicle.ShowDialog();
        }
        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            Sort sort = new Sort(module);
            sort.ShowDialog();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            Filtration filtration = new Filtration(module);
            filtration.ShowDialog();
        }
    }
}
