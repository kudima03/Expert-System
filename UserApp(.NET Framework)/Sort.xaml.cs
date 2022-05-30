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
    /// Логика взаимодействия для Sort.xaml
    /// </summary>
    enum ParamToSort
    {
        Model,
        Color,
        Dealer,
        Rating,
        RegNum
    }
    public partial class Sort : Window
    {
        int counter = 0;
        ParamToSort choosenParam;
        private IDataViewAccess module;
        List<DatabaseEntities.Vehicle> vehicles;
        public Sort(IDataViewAccess module)
        {
            choosenParam = ParamToSort.Model;
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
            if (vehicles.Count == 0)
                MessageBox.Show("Ошибка!");
            else
                Show(vehicles[0]);
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
        private void SortByModel_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToSort.Model;
            TopMenuItem.Header = "Сортировка по модели";
            vehicles = vehicles.OrderBy(c => c.Model).ToList();
        }

        private void SortByColor_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToSort.Color;
            TopMenuItem.Header = "Сортировка по цвету";
            vehicles = vehicles.OrderBy(c => c.Colour).ToList();
        }

        private void SortByDealer_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToSort.Dealer;
            TopMenuItem.Header = "Сортировка по дилеру";
            vehicles = vehicles.OrderBy(c => c.Dealer).ToList();
        }

        private void SortByRegNum_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToSort.RegNum;
            TopMenuItem.Header = "Сортировка по рег. номеру";
            vehicles = vehicles.OrderBy(c => c.RegistrationNumber).ToList();
        }

        private void SortByRating_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToSort.Rating;
            TopMenuItem.Header = "Сортировка по рейтингу";
            vehicles = vehicles.OrderBy(c => c.TotalRate).ToList();
        }
    }
}
