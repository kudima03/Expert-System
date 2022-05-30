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
    /// Логика взаимодействия для AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Window
    {
        bool isEmpty = true, isEmptyTwo = true, isEmptyThree = true;
        private IAdminAccess module;
        public AddAdmin(IAdminAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (passwordInputBox.Text != passwordInputBoxRepeat.Text)
            {
                MessageBox.Show("Error!");
            }
            else
            {
                var answer = module.RegisterNewAdmin(new DatabaseEntities.Admin(loginInputBox.Text, passwordInputBox.Text));
                switch (answer)
                {
                    case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.Successfully:
                        {
                            MessageBox.Show("Успешно!");
                            break;
                        }
                    case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.Error:
                        {
                            MessageBox.Show("Ошибка добавления!");
                            break;
                        }
                    case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.UnknownCommand:
                        {
                            MessageBox.Show("Ошибка добавления!");
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void loginInputBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                loginInputBox.Text = "";
                isEmpty = false;
            }
            if(loginInputBox.Text == "Введите логин")
            {
                loginInputBox.Text = "";
            }
            if(passwordInputBox.Text == "")
            {
                passwordInputBox.Text = "Введите пароль";
            }
            if (passwordInputBoxRepeat.Text == "")
            {
                passwordInputBoxRepeat.Text = "Повторите пароль";
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
        }
    }
}
