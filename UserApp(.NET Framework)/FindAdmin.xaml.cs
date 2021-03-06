using DatabaseEntities;
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
    /// Логика взаимодействия для FindAdmin.xaml
    /// </summary>
    public partial class FindAdmin : Window
    {
        bool isEmpty = true;
        private IAdminAccess module;
        public FindAdmin(IAdminAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void FindAdmin_Click(object sender, RoutedEventArgs e)
        {
            var admin = module.FindAdminByLogin(AdminLoginInput.Text);
            Show(admin);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Show(Admin admin)
        {
            if (admin == null || admin.Login == "empty")
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                UserImage.Source = App.ConvertToBitmapImage(admin.Photo);
                UserLogin.Text = admin.Login;

                switch (admin.UserStatus)
                {
                    case Status.Banned:
                        {
                            UserStatus.Text = "Заблокирован";
                            break;
                        }
                    case Status.NotBanned:
                        {
                            UserStatus.Text = "Без оганичений";
                            break;
                        }
                    default:
                        {
                            UserStatus.Text = admin.UserStatus.ToString();
                            break;
                        }
                }
                if (admin.IsOnline)
                {
                    UserLastOnline.Text = "В сети";
                }
                else
                {

                    UserLastOnline.Text = admin.LastOnline.ToString();
                }

            }
        }
        private void AdminLoginInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                AdminLoginInput.Text = "";
                isEmpty = false;
            }
        }
    }
}
