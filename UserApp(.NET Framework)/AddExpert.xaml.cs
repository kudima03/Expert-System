using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
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
    /// Логика взаимодействия для AddExpert.xaml
    /// </summary>
    public partial class AddExpert : Window
    {
        string fileName;
        bool isEmpty = true, isEmptyTwo = true, isEmptyThree = true, isEmptyFour = true;
        private IAdminAccess module;
        public AddExpert(IAdminAccess module)
        {
            fileName = ConfigurationManager.AppSettings.Get("defaultPhotoPath");
            this.module = module;
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddExpert_Click(object sender, RoutedEventArgs e)
        {
            var answer = module.RegisterNewExpert(new DatabaseEntities.Expert(loginInputBox.Text, passwordInputBox.Text, new Bitmap(fileName), double.Parse(totalRateInput.Text)));
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

        private void loginInputBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                loginInputBox.Text = "";
                isEmpty = false;
            }
            if (loginInputBox.Text == "Введите логин")
            {
                loginInputBox.Text = "";
            }
            if (passwordInputBox.Text == "")
            {
                passwordInputBox.Text = "Введите пароль";
            }
            if (passwordInputBoxRepeat.Text == "")
            {
                passwordInputBoxRepeat.Text = "Повторите пароль";
            }
            if (totalRateInput.Text == "")
            {
                passwordInputBoxRepeat.Text = "Введите вес оценки";
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

        private void passwordInputBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyTwo)
            {
                passwordInputBox.Text = "";
                isEmptyTwo = false;
            }
            if (passwordInputBox.Text == "Введите пароль")
            {
                passwordInputBox.Text = "";
            }
            if (loginInputBox.Text == "")
            {
                loginInputBox.Text = "Введите логин";
            }
            if (passwordInputBoxRepeat.Text == "")
            {
                passwordInputBoxRepeat.Text = "Повторите пароль";
            }
            if (totalRateInput.Text == "")
            {
                passwordInputBoxRepeat.Text = "Введите вес оценки";
            }
        }

        private void passwordInputBoxRepeat_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyThree)
            {
                passwordInputBoxRepeat.Text = "";
                isEmptyThree = false;
            }
            if (passwordInputBoxRepeat.Text == "Повторите пароль")
            {
                passwordInputBoxRepeat.Text = "";
            }
            if (loginInputBox.Text == "")
            {
                loginInputBox.Text = "Введите логин";
            }
            if (passwordInputBox.Text == "")
            {
                passwordInputBox.Text = "Введите пароль";
            }
            if (totalRateInput.Text == "")
            {
                totalRateInput.Text = "Введите вес оценки";
            }
        }

        private void totalRateInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyFour)
            {
                totalRateInput.Text = "";
                isEmptyFour = false;
            }
            if (totalRateInput.Text == "Введите вес оценки")
            {
                totalRateInput.Text = "";
            }
            if (loginInputBox.Text == "")
            {
                loginInputBox.Text = "Введите логин";
            }
            if (passwordInputBox.Text == "")
            {
                passwordInputBox.Text = "Повторите пароль";
            }
            if (passwordInputBoxRepeat.Text == "")
            {
                passwordInputBoxRepeat.Text = "Повторите пароль";
            }
        }
    }
}
