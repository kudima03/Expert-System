using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Window
    {
        string fileName;
        bool isEmpty = true, isEmptyTwo = true, isEmptyThree = true, isEmptyFour = true;
        private IAdminAccess module;
        public AddVehicle(IAdminAccess module)
        {
            fileName = ConfigurationManager.AppSettings.Get("defaultPhotoPath");
            this.module = module;
            InitializeComponent();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            var answer = module.CreateVehicle(new DatabaseEntities.Vehicle(Dealer.Text, Model.Text, Colour.Text, RegistrationNumber.Text) { Photo = new System.Drawing.Bitmap(fileName) });
            switch (answer)
            {
                case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.Successfully:
                    {
                        MessageBox.Show("Успешно!");
                        break;
                    }
                case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.Error:
                    {
                        MessageBox.Show("Ошибка!");
                        break;
                    }
                case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.UnknownCommand:
                    {
                        MessageBox.Show("Ошибка!");
                        break;
                    }
                default:
                    break;
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dealer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                Dealer.Text = "";
                isEmpty = false;
            }
            if (Dealer.Text == "Введите дилера")
            {
                Dealer.Text = "";
            }
            if (Model.Text == "")
            {
                Model.Text = "Введите модель";
            }
            if (Colour.Text == "")
            {
                Colour.Text = "Введите цвет";
            }
            if (RegistrationNumber.Text == "")
            {
                RegistrationNumber.Text = "Введите рег. номер";
            }

        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                fileName = op.FileName;
            }
        }

        private void Model_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyTwo)
            {
                Model.Text = "";
                isEmptyTwo = false;
            }
            if (Model.Text == "Введите модель")
            {
                Model.Text = "";
            }
            if (Dealer.Text == "")
            {
                Dealer.Text = "Введите дилера";
            }
            if (Colour.Text == "")
            {
                Colour.Text = "Введите цвет";
            }
            if (RegistrationNumber.Text == "")
            {
                RegistrationNumber.Text = "Введите рег. номер";
            }
        }

        private void Colour_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyThree)
            {
                Colour.Text = "";
                isEmptyThree = false;
            }
            if (Colour.Text == "Введите цвет")
            {
                Colour.Text = "";
            }
            if (Model.Text == "")
            {
                Model.Text = "Введите модель";
            }
            if (Dealer.Text == "")
            {
                Dealer.Text = "Введите дилера";
            }
            if (RegistrationNumber.Text == "")
            {
                RegistrationNumber.Text = "Введите рег. номер";
            }
        }

        private void RegistrationNumber_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyFour)
            {
                RegistrationNumber.Text = "";
                isEmptyFour = false;
            }
            if (RegistrationNumber.Text == "Введите рег. номер")
            {
                RegistrationNumber.Text = "";
            }
            if (Model.Text == "")
            {
                Model.Text = "Введите модель";
            }
            if (Colour.Text == "")
            {
                Colour.Text = "Введите цвет";
            }
            if (Dealer.Text == "")
            {
                Dealer.Text = "Введите дилера";
            }

        }
    }
}
