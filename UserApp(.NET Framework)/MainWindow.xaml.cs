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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TCPConnectionAPIClientModule_C_sharp_;
using ClassLibraryForTCPConnectionAPI_C_sharp_;
namespace UserApp_.NET_Framework_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isEmpty = true;
        private bool isEmptyTwo = true;
        private ClientConnectionModule module;

        public MainWindow()
        {
            module = new ClientConnectionModule();
            InitializeComponent();
        }

        public MainWindow(ClientConnectionModule module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void LoginInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var login = loginInputBox.Text;
            var password = passwordInputBox.Text;
            var answer = module.Authorization(login, password);
            switch (answer)
            {
                case TypeOfUser.Admin:
                    {
                        AdminMainWindow mainContentWindow = new AdminMainWindow(module);
                        mainContentWindow.Show();
                        this.Close();
                        break;
                    }
                case TypeOfUser.Client:
                    {
                        UserMainWindow userMainWindow = new UserMainWindow(module);
                        userMainWindow.Show();
                        this.Close();
                        break;
                    }
                case TypeOfUser.Expert:
                    {
                        ExpertMenu expertMenu = new ExpertMenu(module);
                        expertMenu.Show();
                        this.Close();
                        break;
                    }
                case TypeOfUser.Undefined:
                    {
                        MessageBox.Show("Error!");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Error!");
                        break;
                    }
            }
        }

        private void HyperlinkRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration(module);
            registration.Show();
            this.Close();
        }

        private void PasswordInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void loginInputBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                loginInputBox.Text = "";
                isEmpty = false;
            }
            if (passwordInputBox.Text == "")
            {
                passwordInputBox.Text = "Пароль";
            }
            if(loginInputBox.Text == "Логин")
            {
                loginInputBox.Text = "";
            }
        }

        private void passwordInputBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyTwo)
            {
                passwordInputBox.Text = "";
                isEmptyTwo = false;
            }
            if (loginInputBox.Text == "")
            {
                loginInputBox.Text = "Логин";
            }
            if (passwordInputBox.Text == "Пароль")
            {
                passwordInputBox.Text = "";
            }
        }
    }
}
