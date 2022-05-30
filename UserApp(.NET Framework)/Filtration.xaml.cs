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
    /// Логика взаимодействия для Filtration.xaml
    /// </summary>
    enum ParamToFilter
    {
        Rating
    }
    public partial class Filtration : Window
    {
        int counter = 0;
        ParamToFilter choosenParam;
        private IDataViewAccess module;
        List<DatabaseEntities.Vehicle> vehicles;
        public Filtration(IDataViewAccess module)
        {
            choosenParam = ParamToFilter.Rating;
            this.module = module;
            vehicles = module.GetAllVehicles();
            InitializeComponent();
            if (vehicles.Count == 0)
                MessageBox.Show("Нет данных!");
            else
                Show(vehicles[0]);
        }
        private void FindSome_Click(object sender, RoutedEventArgs e)
        {
            vehicles.Clear();
            vehicles = module.GetAllVehicles();
            double value1, value2;
            try
            {
                value1 = double.Parse(FirstValue.Text);
                value2 = double.Parse(SecondValue.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода!");
                return;
            }
            switch (choosenParam)
            {
                case ParamToFilter.Rating:
                    {
                        vehicles = vehicles.Where(c => (c.TotalRate >= value1 && c.TotalRate <= value2)).ToList();
                        break;
                    }
                default:
                    break;
            }

            counter = 0;
            if (vehicles.Count == 0)
            {
                MessageBox.Show("Нет данных!");
                FirstValue.Text = "";
                SecondValue.Text = "";
                vehicles = module.GetAllVehicles();
            }
            if (vehicles.Count == 0)
                MessageBox.Show("Ошибка!");
            else
                Show(vehicles[counter]);
        }
        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (vehicles.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                if (counter == 0)
                {
                    Show(vehicles[0]);
                }
                else
                {
                    counter--;
                    Show(vehicles[counter]);
                }
            }
        }
        private void Show(DatabaseEntities.Vehicle vehicle)
        {
            if (vehicle == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {

                VehicleImage.Source = App.ConvertToBitmapImage(vehicle.Photo);
                VehicleDealer.Text = vehicle.Dealer;
                VehicleRegNum.Text = vehicle.RegistrationNumber;
                VehicleTotalRate.Text = vehicle.TotalRate.ToString();
                VehicleModel.Text = vehicle.Model;
                VehicleColor.Text = vehicle.Colour;
            }
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            if (vehicles.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else if (vehicles.Count == 1)
            {
                Show(vehicles[counter]);
            }
            else
            {
                if (counter + 1 == vehicles.Count)
                {
                    Show(vehicles[counter]);
                }
                else
                {
                    counter++;
                    Show(vehicles[counter]);
                }
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FilterByRating_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFilter.Rating;
            TopMenuItem.Header = "Фильтрация по рейтингу";
        }
    }
}
