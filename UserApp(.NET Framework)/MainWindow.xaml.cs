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
namespace UserApp_.NET_Framework_
    //
    //  goToPreviousRoom() (Несколько раз) -> При отключении. (КРЕСТИК).
    //
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isEmpty = true;
        bool isEmptyTwo = true;
        private ClientConnectionModule module = new ClientConnectionModule();
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(ClientConnectionModule module)
        {
            this.module = module;
            InitializeComponent();
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var login = loginInputBox.Text;
            var password = passwordInputBox.Text;
            var answer = module.Authorization(login, password);
            switch (answer)
            {
                case ClassLibraryForTCPConnectionAPI_C_sharp_.TypeOfUser.Admin:
                    {
                        MainContentWindow mainContentWindow = new MainContentWindow(module);
                        mainContentWindow.Show();
                        this.Close();
                        break;
                    }
                case ClassLibraryForTCPConnectionAPI_C_sharp_.TypeOfUser.Client:
                    {
                        UserMainWindow userMainWindow = new UserMainWindow(module);
                        userMainWindow.Show();
                        this.Close();
                        break;
                    }
                case ClassLibraryForTCPConnectionAPI_C_sharp_.TypeOfUser.Expert:
                    {
                        ExpertMenu expertMenu = new ExpertMenu(module);
                        expertMenu.Show();
                        this.Close();
                        break;
                    }
                case ClassLibraryForTCPConnectionAPI_C_sharp_.TypeOfUser.Undefined:
                    {
                        MessageBox.Show("Ошибка!");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Ошибка!");
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
