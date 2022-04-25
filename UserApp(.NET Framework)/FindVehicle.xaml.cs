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
    enum ParamToFind
    {
        Color,
        Dealer,
        RegistationNumber,
        Model,
        TotalRate,
        None
    }
    public partial class FindVehicle : Window
    {
        int counter = 0;
        ParamToFind choosenParam;
        bool isEmpty = true;
        private IDataViewAccess module;
        List<DatabaseEntities.Vehicle> vehicles;
        public FindVehicle(IDataViewAccess module)
        {
            choosenParam = ParamToFind.Color;
            this.module = module;
            vehicles = module.GetAllVehicles();
            InitializeComponent();
            Show(vehicles[0]);
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
                VehicleModel.Text = vehicle.Model;
                VehicleTotalRate.Text = vehicle.TotalRate.ToString();
                VehicleRegNum.Text = vehicle.RegistrationNumber.ToString();
                VehicleDealer.Text = vehicle.Dealer;
                VehicleColor.Text = vehicle.Colour;
            }
        }
        private void FindVehicle_Click(object sender, RoutedEventArgs e)
        {
            vehicles.Clear();
            switch (choosenParam)
            {
                case ParamToFind.Color:
                    {
                        vehicles = module.FindVehicleWithColour(VehicleInput.Text);
                        break;
                    }
                case ParamToFind.Dealer:
                    {
                        vehicles = module.FindVehicleWithDealer(VehicleInput.Text);
                        break;
                    }
                case ParamToFind.RegistationNumber:
                    {
                        vehicles = module.FindVehicleWithRegistrationNumber(VehicleInput.Text);
                        break;
                    }
                case ParamToFind.Model:
                    {
                        vehicles = module.FindVehicleWithModel(VehicleInput.Text);
                        break;
                    }
                case ParamToFind.TotalRate:
                    {
                        vehicles = module.FindVehicleWithTotalRate(double.Parse(VehicleInput.Text));
                        break;
                    }
                case ParamToFind.None:
                    {
                        vehicles = module.GetAllVehicles();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Повторите попытку!");
                        break;
                    }
            }

            if (vehicles.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                Show(vehicles[0]);
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            if (vehicles.Count == 0)
            {
                MessageBox.Show("Не найдено!");
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

        private void FindByDealer_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFind.Dealer;
            TopMenuItem.Header = "Поиск по дилеру";
        }

        private void FindByColor_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFind.Color;
            TopMenuItem.Header = "Поиск по цвету";
        }

        private void FindByModel_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFind.Model;
            TopMenuItem.Header = "Поиск по модели";
        }

        private void FindByRegNumber_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFind.RegistationNumber;
            TopMenuItem.Header = "Поиск по номеру";
        }

        private void FindByTotalRating_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFind.TotalRate;
            TopMenuItem.Header = "Поиск по рейтингу";
        }

        private void VehicleInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                VehicleInput.Text = "";
                isEmpty = false;
            }
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFind.None;
            TopMenuItem.Header = "Показать всё";
        }
    }
}
